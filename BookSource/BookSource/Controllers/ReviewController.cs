using BookSource.DAL;
using BookSource.Models;
using BookSource.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BookSource.Controllers
{
    public class ReviewController : Controller
    {
        ReviewDAL _reviewDAL;
        UserDAL _userDAL;
        public ReviewController(ReviewDAL reviewDAL, UserDAL userDAL)
        {
            _reviewDAL = reviewDAL;
            _userDAL = userDAL;
        }
        [HttpGet]
        public ActionResult GetReviewPartialView(int idBook)
        {
            List<Review> reviewList= _reviewDAL.GetReviewsByIdBook(idBook);
            List<ReviewViewModel> viewModelList= new List<ReviewViewModel>();
            foreach (Review review in reviewList)
            {
                User user= _userDAL.GetUserById(review.RIdUser);
                viewModelList.Add(new ReviewViewModel {Comment=review.Comment, UserName=user.UserName,UserImgUrl=user.ProfileImageUrl});
            }
            return PartialView("~/Views/Review/_BookReview.cshtml", (viewModelList, idBook));
        }
        [HttpGet("book/addreview")]
        public IActionResult AddReview(int IdBook)
        {
            // Me tiene que llegar el ID User y el Id Review
            if (HttpContext.Session.GetString("UserName") != null)
            {
                ViewBag.IdUser = _userDAL.GetUserByUserName(HttpContext.Session.GetString("UserName")).IdUser;
            }
            ViewBag.IdBook = IdBook;
            return View();
        }

        [HttpPost("book/addreview")]
        public IActionResult AddReview(Review review)
        {
            if (ModelState.IsValid)
            {
                Review newRev = _reviewDAL.CreateReview(review);
            }
            else
                return View(review);
            return RedirectToAction("BookInfo", "Book", new { bookId = review.RIdBook });

        }
    }
}
