using BookSource.DAL;
using BookSource.Models;
using BookSource.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BookSource.Controllers
{
    public class ListOfBooksController : Controller
    {
        private readonly ListOfBooksDAL _listOfBooksDAL;
        private readonly UserDAL _userDAL;
        private readonly BookDAL _bookDAL;
        public ListOfBooksController(ListOfBooksDAL listOfBooksDAL, UserDAL userDAL, BookDAL bookDAL)
        {
            _listOfBooksDAL = listOfBooksDAL;
            _userDAL = userDAL;
            _bookDAL = bookDAL;
        }
        public IActionResult Index(string username, int? selectedListId)
        {
            UserListOfBooksViewModel userListOfBooksViewModel = InitializeUserListOfBooksViewModel(username,selectedListId);
            return View(userListOfBooksViewModel);
        }
        public UserListOfBooksViewModel InitializeUserListOfBooksViewModel(string username, int? selectedListId)
        {
            User user = _userDAL.GetUserByUserName(username);
            //TODO Si usuario no existe mostrar ventana de error de usuario
            UserListOfBooksViewModel userListOfBooksViewModel = new UserListOfBooksViewModel
            {
                UserName = username,
                IdSelectedList = selectedListId,
                UserListOfBooks = ListOfBooksViewModel.MapperToViewModel(_listOfBooksDAL.GetListsOfByUserId(user.IdUser))
            };
            if (selectedListId!=null && userListOfBooksViewModel.UserListOfBooks.Where(x=>x.IdListOfBooks==selectedListId).Any())
            {
                userListOfBooksViewModel.UserListOfBooks.Where(x => x.IdListOfBooks == selectedListId).First().Books = BookViewModel.ListBookMapper(_bookDAL.GetBooksByIdList((int)selectedListId));
            }
            return userListOfBooksViewModel;
        }
    [HttpPost]
        public IActionResult ChangeList(string? username, UserListOfBooksViewModel userList)
        {
            return RedirectToAction("Index", "ListOfBooks", new { username = username, selectedListId = userList.IdSelectedList});
        }

    }
}
