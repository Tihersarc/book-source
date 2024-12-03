using BookSource.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
namespace BookSource.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            List<BookViewModel> listBooks = Tools.Tools.BookListTemporal();
            BookListViewModel model = new BookListViewModel() { Books=listBooks};
            return View(model);
        }
    }
}
