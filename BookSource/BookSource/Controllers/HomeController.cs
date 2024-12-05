using BookSource.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookSource.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            
            //Simulate user login
            //ViewBag.UserName = "Shiro";

            //ViewBag.UserImg = "https://i.pinimg.com/originals/c8/05/66/c805665abddddfcc04692ff3c92cadfe.jpg";

            // Recuperar los datos del usuario desde la sesi�n
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            ViewBag.UserImg = HttpContext.Session.GetString("UserImg");



            List<BookViewModel> listBooks = Tools.Tools.BookListTemporal();
            BookListViewModel model = new BookListViewModel() { Books = listBooks };
            return View(model);
        }


        public IActionResult About()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
