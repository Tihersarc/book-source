using BookSource.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BookSource.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index(string? username,int? selectedListId)
        {
            string? sessionUsername = HttpContext.Session.GetString("Username");
            ViewBag.Username = sessionUsername;

            if (!string.IsNullOrEmpty(username))
            {
                UserViewModel user= Tools.Tools.UserTemporal();
                //TODO Get user
                user.IdSelectedListOfBooks = selectedListId;
                return View(user);//Enviar el viewModel del usuario obtenido
            }

            return View(Tools.Tools.UserTemporal());
        }
        [HttpPost]
        public IActionResult ChangeList(string? username, UserViewModel user)
        {
            return RedirectToAction("Index","User", new { username = "username", selectedListId = user.IdSelectedListOfBooks });
        }
    }
}
