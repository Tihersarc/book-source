using BookSource.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BookSource.Controllers
{
    public class ListOfBooksController : Controller
    {
        public IActionResult Index(string username, int? selectedListId)
        {
            UserListOfBooksViewModel userListOfBooksViewModel = new UserListOfBooksViewModel { 
                UserName = username,
                IdSelectedList=selectedListId,

            };
            return View(userListOfBooksViewModel);
        }
        [HttpPost]
        public IActionResult ChangeList(string? username, UserListOfBooksViewModel userList)
        {
            return RedirectToAction("Index", "ListOfBooks", new { username = username, selectedListId = userList.IdSelectedList});
        }

    }
}
