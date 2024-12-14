using BookSource.DAL;
using BookSource.Models;
using BookSource.Models.ViewModel;
using BookSource.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

            if (sessionUsername != null)
            {
                User sessionUser = _userDAL.GetUserByUserName(sessionUsername);
                foreach (PublicationViewModel item in model.Publications)
                {
                    item.isLiked = false;

                    foreach (var pubLikes in model.PublicationsLikes)
                    {
                        if (pubLikes.RIdPublication == item.IdPublication 
                            && pubLikes.RIdUser == sessionUser.IdUser)
                        {
                            item.isLiked = true;

                        }
                    }
                }
                ViewBag.UserName = sessionUsername;
            }
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
        public IActionResult RemoveLike(int IdPublication, int IdUser)
        {
            PublicationLikes pubLikes = new PublicationLikes
            {
                RIdPublication = IdPublication,
                RIdUser = IdUser
            };
            _publicationDAL.DeleteLikeToPublication(pubLikes);

            return RedirectToAction("Index", "Feed");
        }

        public List<Models.ViewModel.PublicationViewModel> GetBooksByFilter(FeedViewModel model)
        {
            List<Models.ViewModel.PublicationViewModel> publications = new List<Models.ViewModel.PublicationViewModel>();

            // Obtenemos todos los publications o los de una categoria
            publications = PublicationViewModel.ListPubMapper(_publicationDAL.GetAllPublications());

            foreach (PublicationViewModel item in publications)
            {
                // Obtenemos los likes
                item.likes = _publicationDAL.GetLikesByPublicationId(item.IdPublication);

                // Obtenemos la foto y nombre del usuario
                User user = _userDAL.GetUserById(item.IdUser);
                item.UserName = user.UserName;
                item.UserImage = user.ProfileImageUrl != null ? user.ProfileImageUrl : Tools.Tools.DefaultUserImg;
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
                    case "MaxLikes":
                        publications = publications.OrderByDescending(pub => pub.likes).ToList();
                        break;
                    case "MinLikes":
                        publications = publications.OrderBy(pub => pub.likes).ToList();
                        break;
                }
            }
            return publications;
        }

        [HttpGet("feed/addpublication")]
        public IActionResult AddPublication()
        {
            // Se coge el Id del usuario de session y se le pasa a la vista pata que se añada al modelo
            if (HttpContext.Session.GetString("UserName") != null)
            {
                ViewBag.IdUser = _userDAL.GetUserByUserName(HttpContext.Session.GetString("UserName")).IdUser;
            }
            return View();
        }

        [HttpPost("feed/addpublication")]
        public IActionResult AddPublication(Publication publication)
        {
            if (ModelState.IsValid)
            {
                Publication newPub = _publicationDAL.CreatePublication(publication);
            }
            else
                return View(publication);
            return RedirectToAction("Index");
        }
    }
}
