using BookSource.DAL;
using BookSource.Models;
using BookSource.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace BookSource.Controllers
{
    public class TestController : Controller
    {
        private UserDAL _userDAL;
        private BookDAL _bookDAL;

        public TestController(UserDAL userDAL, BookDAL bookDAL)
        {
            _userDAL = userDAL;
            _bookDAL = bookDAL;
        }
        public IActionResult Login()
        {
            string? BookValue = HttpContext.Session.GetString("TestBook");
            string? UserValue = HttpContext.Session.GetString("TestUser");


            if (BookValue != null)
            {
                ViewBag.book = BookValue;
            }
            if (UserValue != null)
            {
                ViewBag.us = UserValue;
            }
            return View();
        }

        [Obsolete]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Login(TestViewModel model)
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
        public IActionResult Register(TestViewModel model)
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

        [Obsolete]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult GetUser(TestViewModel model)
        {
            model.Password = "hardcoded";
            if (ModelState.IsValid)
            {
                User newUser = _userDAL.GetUserByUserName(model.UserName);
                HttpContext.Session.SetString("TestUser", newUser.UserName);

                //ViewBag.us = newUser.UserName;  //No se guarda porque al cambiar de action no guarda viewBags
            }
            return RedirectToAction("Login");
        }

        public IActionResult GetBook(TestViewModel model)
        {

            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("TestBook", model.Book);
                //ViewBag.book = _bookDAL.GetBookByTitle(model.Book);
            }
                return RedirectToAction("Login");

        }
        public IActionResult DeleteCache()
        {
            HttpContext.Session.Remove("TestUser");
            HttpContext.Session.Remove("TestBook");

            ViewBag.us = "";
            ViewBag.book = "";
            return RedirectToAction("Login");
        }

        public IActionResult GetAllBooks()
        {
            List<Book> libros = _bookDAL.GetAllBooks();

            TestViewModel model = new TestViewModel();
            model.Books = libros;
            return View(model);

        }
    }
}
