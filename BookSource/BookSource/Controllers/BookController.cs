using BookSource.DAL;
using BookSource.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
namespace BookSource.Controllers
{
    public class BookController : Controller
    {
        private readonly BookDAL _bookDAL;

        public BookController(BookDAL bookDAL)
        {
            _bookDAL = bookDAL;
        }

        public IActionResult BookInfo(int id)
        {
            // Hardcodear un libro de prueba
            var book = new BookViewModel
            {
                IdBook = 1,
                Title = "It",
                //SubTitle = "Subtítulo de Prueba",
                ImageLink = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.amazon.es%2FBEST-SELLER-Stephen-King%2Fdp%2F8497593790&psig=AOvVaw0dCTt6OxaUEwEpmSlS1CG7&ust=1733825576373000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCNC-gYS6mooDFQAAAAAdAAAAABAE",
                Description = "Tras veintisiete años de tranquilidad y lejanía, una antigua promesa infantil les hace volver al" +
                                " lugar en el que vivieron su infancia y juventud como una terrible pesadilla. Regresan a Derry para enfrentarse con " +
                                "su pasado y enterrar definitivamente la amenaza que los amargó durante su niñez.", 
                Editorial = "Signet books",
                PageCount = 1502,
                Score = 4.5,
                Author = "Stephen King",
                Categories = new List<CategoryViewModel>
                {
                    new CategoryViewModel { IdCategory = 1, Category = "Ficción" },
                    new CategoryViewModel { IdCategory = 2, Category = "Terror" }
                }
            };

            return View(book);
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
