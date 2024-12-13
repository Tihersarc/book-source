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
        private PublicationDAL _publicationDAL;
        public FeedController(UserDAL userDAL, PublicationDAL publicationDAL)
        {
            _userDAL = userDAL;
            _publicationDAL = publicationDAL;
        }

        public IActionResult Index(FeedViewModel model)
        {
            model.Users = _userDAL.GetAllUsers();
            model.Publications = GetBooksByFilter(model);
            model.PublicationsLikes = _publicationDAL.GetAllLikes();
            string? sessionUsername = HttpContext.Session.GetString("UserName");
            ViewBag.UserName = sessionUsername;
            return View(model);
        }
        public IActionResult AddLike(int IdPublication, int IdUser)
        {
            PublicationLikes pubLikes = new PublicationLikes
            {
                RIdPublication = IdPublication,
                RIdUser = IdUser
            };
             _publicationDAL.AddLikeToPublication(pubLikes);

            return RedirectToAction("Index","Feed");
        }

        public List<Models.ViewModel.PublicationViewModel> GetBooksByFilter(FeedViewModel model)
        {
            List<Models.ViewModel.PublicationViewModel> publications = new List<Models.ViewModel.PublicationViewModel>();

            // Obtenemos todos los publications o los de una categoria
            publications = PublicationViewModel.ListPubMapper(_publicationDAL.GetAllPublications());

            // Obtenemos los likes
            foreach (PublicationViewModel item in publications)
            {
                item.likes = _publicationDAL.GetLikesByPublicationId(item.IdPublication);
            }

            // Si se ha intorducido algo en Title, filtramos por titulo
            if (model.Title != "" && model.Title != null)
                publications = publications.Where(publication => publication.Title.Contains(model.Title, StringComparison.OrdinalIgnoreCase)).ToList();

            // Ordenar los libros si se ha puesto algo
            if (model.OrderType != null && model.OrderType != "")
            {
                switch (model.OrderType)
                {
                    case "Users":
                        publications = publications.OrderBy(pub => pub.IdUser).ToList();

                        break;
                    case "MaxLikes": // TODO
                        publications = publications.OrderByDescending(pub => pub.Content).ToList();
                        break;
                    case "MinLikes":
                        publications = publications.OrderBy(pub => pub.Title).ToList();
                        break;
                }
            }
            return publications;
        }
    }
}
