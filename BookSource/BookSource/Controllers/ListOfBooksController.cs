using BookSource.DAL;
using BookSource.Models;
using BookSource.Models.ViewModel;
using Microsoft.AspNetCore.Http.HttpResults;
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
        [HttpGet]
        public ActionResult GetUserListOfBooksPartialView(int idBook)
        {
            string? sessionUsername = HttpContext.Session.GetString(Tools.Tools.UserNameSession);
            if (sessionUsername!=null)
            {
                User? user = _userDAL.GetUserByUserName(sessionUsername);
                if (user!=null)
                {
                    List<ListOfBooksViewModel> listOfBooks = ListOfBooksViewModel.MapperToViewModel(_listOfBooksDAL.GetListsOfByUserId(user.IdUser));
                    foreach (ListOfBooksViewModel list in listOfBooks)
                        list.Books = BookViewModel.ListBookMapper(_bookDAL.GetBooksByIdList(list.IdListOfBooks));
                    return PartialView("~/Views/ListOfBooks/_BookListOfBook.cshtml", (listOfBooks, idBook));
                }
            }
            return BadRequest();
        }
        [HttpGet]
        public ActionResult GetAddUserListOfBooksPartialView()
        {
            string? sessionUsername = HttpContext.Session.GetString(Tools.Tools.UserNameSession);
            if (sessionUsername != null)
            {
                User? user = _userDAL.GetUserByUserName(sessionUsername);
                if (user != null)
                {
                    return PartialView("~/Views/ListOfBooks/_AddListOfBooks.cshtml");
                }
            }
            return BadRequest();
        }
        [HttpPost]
        public IActionResult AddListOfBooks(string nameList)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult AddBookToList(int idList, int idBook)
        {
            _listOfBooksDAL.AddBookToListOfBooks(idList, idBook);
            return Ok();
        }
        [HttpPost]
        public IActionResult DeleteBookToList(int idList, int idBook)
        {
            _listOfBooksDAL.DeleteBookToListOfBooks(idList, idBook);
            return Ok();
        }


        [HttpPost]
        public IActionResult ChangeList(string? username, UserListOfBooksViewModel userList)
        {
            return RedirectToAction("Index", "ListOfBooks", new { username = username, selectedListId = userList.IdSelectedList});
        }

    }
}
