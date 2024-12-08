using BookSource.DAL;
using BookSource.Models;
using BookSource.Models.ViewModel;
using BookSource.Tools;
using Microsoft.AspNetCore.Mvc;

namespace BookSource.Controllers
{
    public class UserController : Controller
    {
        UserDAL _userDAL;
        public UserController(UserDAL userDAL)
        {
            _userDAL = userDAL;
        }
        public IActionResult Index(string? username,int? selectedListId)
        {
            string? sessionUsername = HttpContext.Session.GetString(Tools.Tools.UserNameSession);
            ViewBag.UserName = sessionUsername;

            if (!string.IsNullOrEmpty(username))
            {
                User? profileUser = _userDAL.GetUserByUserName(username);
                if (profileUser!=null)
                {
                    UserViewModel user = UserViewModel.UserMapper(profileUser);
                    user.IdSelectedListOfBooks = selectedListId;
                    return View(user);
                }
            }
            return View();
        }
        public IActionResult Configuration(string username)
        {
            User? profileUser = _userDAL.GetUserByUserName(username);
            UserViewModel user = UserViewModel.UserMapper(profileUser);
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Configuration(UserViewModel user,int idUser)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(user);
                }
                //TODO Update user
                if (HttpContext.Session.GetString(Tools.Tools.UserNameSession)!= user.UserName)
                    HttpContext.Session.SetString("UserName", user.UserName);
                if (HttpContext.Session.GetString(Tools.Tools.UserImgSession) != user.ProfileImageUrl)
                    HttpContext.Session.SetString("UserImg", user.ProfileImageUrl ?? string.Empty);
                return RedirectToAction("Index", "User", new { username = user.UserName });
            }
            catch (Exception)
            {
                return View(user);
            }
        }

        [HttpPost]
        public IActionResult ChangeList(string? username, UserViewModel user)
        {
            return RedirectToAction("Index","User", new { username = user.UserName, selectedListId = user.IdSelectedListOfBooks });
        }
    }
}
