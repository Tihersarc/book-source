using BookSource.DAL;
using BookSource.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
namespace BookSource.Controllers
{
    public class BookController : Controller
    {
        private readonly BookDAL _bookDAL;
        private readonly CategoriesDAL _categoriesDAL;


        public BookController(BookDAL bookDAL, CategoriesDAL categoriesDAL)
        {
            _bookDAL = bookDAL;
            _categoriesDAL = categoriesDAL;
        }

        public IActionResult BookInfo(int bookId)
        {
            BookViewModel bookViewModel = BookViewModel.BookMapper(_bookDAL.GetBookById(bookId));
            List<CategoryViewModel> categories = CategoryViewModel.ListCategoryMapper(_categoriesDAL.GetCategoryByBookId(bookId));
            bookViewModel.Categories = categories;

            return View(bookViewModel);
        }

        //public IActionResult BookInfo()
        //{
        //    return View();
        //}

        //public IActionResult BookInfo(string title)
        //{
        //    var book = _bookDAL.GetBookByTitle(title);
        //    if (book == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(book);
        //}
        public IActionResult Index()
        {
            List<BookViewModel> listBooks = Tools.Tools.BookListTemporal();
            BookListViewModel model = new BookListViewModel() { Books=listBooks};
            return View(model);
        }       
    }
}
