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

            return View(model);
        }

        public List<Models.Publication> GetBooksByFilter(FeedViewModel model)
        {
            List<Models.Publication> publications = new List<Models.Publication>();

            // Obtenemos todos los publications o los de una categoria
            publications = _publicationDAL.GetAllPublications();

            // Si se ha intorducido algo en Title, filtramos por titulo
            if (model.Title != "" && model.Title != null)
                publications = publications.Where(publication => publication.Title.Contains(model.Title, StringComparison.OrdinalIgnoreCase)).ToList();

            // Ordenar los libros si se ha puesto algo
            if (model.OrderType != null && model.OrderType != "")
            {
                switch (model.OrderType)
                {
                    case "Users":
                        publications = publications.OrderBy(pub => pub.RIdUser).ToList();

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
