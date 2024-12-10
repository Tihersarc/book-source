using BookSource.DAL;
using BookSource.Models;
using BookSource.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BookSource.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly UserDAL _userDAL;

        public AuthenticationController(UserDAL userDAL)
        {
            _userDAL = userDAL;
        }

        /// <summary>
        /// Vista de login. Redirige al Home si el usuario ya está autenticado.
        /// </summary>
        /// <returns>Vista de Login o redirección al Home</returns>
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Procesa el inicio de sesión
        /// </summary>
        /// <param name="model">Modelo con los datos de inicio de sesión</param>
        /// <returns>Redirección o vista de error</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userDAL.GetUsuarioLogin(model.Username, model.Password);
                if (user == null)
                {
                    model.ErrorMessage = "Usuario o contraseña incorrectos.";
                    return View(model);
                }

                // Almacenar los datos del usuario en la sesión
                HttpContext.Session.SetString("UserName", user.UserName);
                HttpContext.Session.SetString("UserImg", user.ProfileImageUrl ?? string.Empty);

                // Redirigir al home
                return RedirectToAction("Index", "Home");
            }

            model.ErrorMessage = "No pueden estar los campos vacíos.";
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }


        /// <summary>
        /// Vista de registro
        /// </summary>
        /// <returns>Vista de registro o redirección al Home</returns>
        /// 
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {

                // Harcodeamos un poco el user
                User user = new User()
                {
                    UserName = model.Username,
                    Email = model.Email,
                };

                // Si la creación es correcta, devolveremos la vista de nuevo
                if (_userDAL.CreateUser(user, model.Password))
                    return RedirectToAction("Login");
                else
                    Console.WriteLine("Error creando el usuario");

            }
            return View();
        }
    }
}

