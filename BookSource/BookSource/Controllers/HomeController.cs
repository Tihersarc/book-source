using BookSource.DAL;
using BookSource.Models;
using BookSource.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
namespace BookSource.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BookDAL _bookDAL;

        public HomeController(ILogger<HomeController> logger, BookDAL bookDAL)
        {
            _logger = logger;
            _bookDAL = bookDAL;
        }

        public IActionResult Index()
        {
            List<Book>topTenBooks = _bookDAL.GetTopTenBooks();
            BookListViewModel model = new BookListViewModel() { Books =  BookViewModel.ListBookMapper(topTenBooks)};
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
