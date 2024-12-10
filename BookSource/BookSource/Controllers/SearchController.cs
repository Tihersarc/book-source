using BookSource.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BookSource.Controllers
{
    public class SearchController : Controller
    {

        // Recibe un viewModel con los filtros
        // Devuelve el Book list gestionado
        [HttpGet("search")]
        public IActionResult Index(SearchViewModel view)
        {
            SearchViewModel viewModel = new SearchViewModel();
            return View(viewModel);

        }
    }
}
