using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BookSource.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string username, string password)
        {

            if (username.Length!=0 || password.Length!=0)
            {
                View();
            }
                //var user = "usuario"; // Simulamos un usuario devuelto
                // password = "1234"; // Simulamos una contraseña devuelta
                //if (user && password)
                //{
                //    window.location.href = "/home";
                //}   
                
            return RedirectToAction("Login", "Authentication");
        }



    }
}
