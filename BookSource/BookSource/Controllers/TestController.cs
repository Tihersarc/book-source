using BookSource.DAL;
using BookSource.Models;
using BookSource.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BookSource.Controllers
{
    public class TestController : Controller
    {
        private UserDAL _userDAL;

        public TestController(UserDAL userDAL)
        {
            _userDAL = userDAL;
        }
        public IActionResult Login()
        {
            return View();
        }

        [Obsolete]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Login(UserTestViewModel model)
        {
            if (ModelState.IsValid) 
            {
                ViewBag.us = _userDAL.GetUsuarioLogin(model.UserName, model.Password).UserName;
            }
            return View();      // Aqui pasariamos el model si quisieramos hacer algo con los datos
        }

        [Obsolete]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Register(UserTestViewModel model)
        {
            if (ModelState.IsValid)
            {

                // Harcodeamos un poco el user
                User user = new User()
                {
                    UserName = model.UserName,
                    Email = model.UserName + "@gmail.com",
                };

                // Si la creación es correcta, devolveremos la vista de nuevo
                if (_userDAL.CreateUser(user, model.Password))
                    return RedirectToAction("Test");
                else
                    Console.WriteLine("Error creando el usuario");

            }
            return View();
        }
    }
}
