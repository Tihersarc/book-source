using BookSource.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BookSource.Controllers
{
    public class FeedController : Controller
    {
        public IActionResult Index(FeedViewModel viewModel)
        {
            return View(viewModel);
        }
    }
}
