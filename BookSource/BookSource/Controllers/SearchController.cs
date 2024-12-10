using BookSource.DAL;
using BookSource.Models;
using BookSource.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BookSource.Controllers
{
    public class SearchController : Controller
    {
        private BookDAL _bookDAL;

        public SearchController(BookDAL bookDAL)
        {
            _bookDAL = bookDAL;
        }

        // Recibe un viewModel con los filtros
        // Devuelve el Book list gestionado
        [HttpGet("search")]
        public IActionResult Index(SearchViewModel model)
        {
            // Sacamos los libros segun los requisitos del modelo y se lo volvemos a pasar al modelo
            model.BookListViewModel.Books = BookViewModel.ListBookMapper(GetBooksByFilter(model));
            return View(model);
        }

        public List<Book> GetBooksByFilter(SearchViewModel model)
        {
            // Obtenemos todos los libros
            List<Book> books = _bookDAL.GetAllBooks();

            // Si se ha intorducido algo en Title, filtramos por titulo
            if (model.Title != "" || model.Title != null)
            {
                books = books.Where(book => book.Title.Contains(model.Title, StringComparison.OrdinalIgnoreCase)).ToList();

            }
            // TODO Si se ha introducido algo en Categoria filtrar cat

            // Ordenar los libros si se ha puesto algo
            if (model.OrderType != null || model.OrderType != "")
            {
                switch (model.OrderType)
                {
                    case "MaxScore":
                        books = books.OrderByDescending(book => book.Score).ToList();
                        break;
                    case "MinScore":
                        books = books.OrderBy(book => book.Score).ToList();
                        break;
                    case "MaxPage":
                        books = books.OrderByDescending(book => book.PageCount).ToList();
                        break;
                    case "MinPage":
                        books = books.OrderBy(book => book.PageCount).ToList();
                        break;
                    case "ByAuthor":
                        books = books.OrderBy(book => book.Author).ToList();
                        break;
                    case "ByEditorial":
                        books = books.OrderBy(book => book.Editorial).ToList();
                        break;
                }
            }
            return books;

        }
    }
}
