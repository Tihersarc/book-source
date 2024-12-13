using BookSource.DAL;
using BookSource.Models;
using BookSource.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace BookSource.Controllers
{
    public class FeedController : Controller
    {
        private UserDAL _userDAL;
        public FeedController(UserDAL userDAL)
        {
            _userDAL = userDAL;
        }

        public IActionResult Index(FeedViewModel model)
        {
            model.Users = _userDAL.GetAllUsers();
            //model.Publications = 
            return View(model);
        }

        //public List<Publications?> GetBooksByFilter(SearchViewModel model)
        //{
        //    List<Book> books = new List<Book>();

        //    // Obtenemos todos los libros o los de una categoria
        //    if (model.Category != "" && model.Category != null)
        //        books = _bookDAL.GetBooksByCategory(model.Category);
        //    else
        //        books = _bookDAL.GetAllBooks();

        //    // Si se ha intorducido algo en Title, filtramos por titulo
        //    if (model.Title != "" && model.Title != null)
        //        books = books.Where(book => book.Title.Contains(model.Title, StringComparison.OrdinalIgnoreCase)).ToList();

        //    // Ordenar los libros si se ha puesto algo
        //    if (model.OrderType != null && model.OrderType != "")
        //    {
        //        switch (model.OrderType)
        //        {
        //            case "MaxScore":
        //                books = books.OrderByDescending(book => book.Score).ToList();
        //                break;
        //            case "MinScore":
        //                books = books.OrderBy(book => book.Score).ToList();
        //                break;
        //            case "MaxPage":
        //                books = books.OrderByDescending(book => book.PageCount).ToList();
        //                break;
        //            case "MinPage":
        //                books = books.OrderBy(book => book.PageCount).ToList();
        //                break;
        //            case "ByAuthor":
        //                books = books.OrderBy(book => book.Author).ToList();
        //                break;
        //            case "ByEditorial":
        //                books = books.OrderBy(book => book.Editorial).ToList();
        //                break;
        //        }
        //    }
        //    return books;

        //}
    }
}
