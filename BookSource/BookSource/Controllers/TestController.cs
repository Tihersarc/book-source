using Microsoft.AspNetCore.Mvc;

namespace BookSource.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
