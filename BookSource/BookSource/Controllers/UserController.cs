using BookSource.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BookSource.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index(string? username)
        {
            string? sessionUsername = HttpContext.Session.GetString("Username");
            ViewBag.Username = sessionUsername;

            if (!string.IsNullOrEmpty(username))
            {
                //TODO Get user

                return View(Tools.Tools.UserTemporal());//Enviar el viewModel del usuario obtenido
            }

            return View(Tools.Tools.UserTemporal());
        }
        [HttpGet]
        public IActionResult ChangeList(UserViewModel? user)
        {
            return View("Index",user);
        }
    }
}
