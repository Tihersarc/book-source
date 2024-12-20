﻿using BookSource.DAL;
using BookSource.Models;
using BookSource.Models.ViewModel;
using BookSource.Tools;
using Microsoft.AspNetCore.Mvc;

namespace BookSource.Controllers
{
    public class UserController : Controller
    {
        private readonly UserDAL _userDAL;
        private readonly FollowDAL _followDAL;
        private readonly ListOfBooksDAL _listOfBooksDAL;
        private readonly BookDAL _bookDAL;
        public UserController(UserDAL userDAL, FollowDAL followDAL, ListOfBooksDAL listOfBooksDAL, BookDAL bookDAL)
        {
            _userDAL = userDAL;
            _followDAL = followDAL;
            _listOfBooksDAL = listOfBooksDAL;
            _bookDAL = bookDAL;
        }
        public IActionResult Index(string username,int? selectedListId)
        {
            InitializateBags();
            UserViewModel? user = InitializeUserViewModel(username,selectedListId);
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
                if (user != null)
                {
                    user.IdSelectedListOfBooks = selectedListId;
                    return View(user);
                }

            return View();
        }
        public void InitializateBags()
        {
            string? sessionUsername = HttpContext.Session.GetString(Tools.Tools.UserNameSession);
            if (sessionUsername!=null)
            {
                User user = _userDAL.GetUserByUserName(sessionUsername);
                ViewBag.UserName = sessionUsername;
                ViewBag.IdSessionUser = user.IdUser;
            }
        }
        private UserViewModel? InitializeUserViewModel(string username,int? selectedListId)
        {
            User? user = _userDAL.GetUserByUserName(username);
            if (user==null)
            {
                return null; 
            }
            UserViewModel profileUser = UserViewModel.UserMapper(_userDAL.GetUserByUserName(username));
            profileUser.FollowerList = _followDAL.GetFollowerList(profileUser.IdUser);
            profileUser.FollowedList = _followDAL.GetFollowedList(profileUser.IdUser);
            profileUser.ListOfBooks = ListOfBooksViewModel.MapperToViewModel(_listOfBooksDAL.GetListsOfByUserId(profileUser.IdUser));
            if (selectedListId!=null)
            {
                profileUser.ListOfBooks.Where(x => x.IdListOfBooks == selectedListId).First().Books =BookViewModel.ListBookMapper(_bookDAL.GetBooksByIdList((int)selectedListId));
            }

            return profileUser;
        }

        // Seguidores usuario
        public IActionResult Follower(string username, string followType)
        {
            User user = _userDAL.GetUserByUserName(username);

            if (user == null)
            {
                return NotFound("Usuario no encontrado.");
            }

            UserViewModel profileUser = UserViewModel.UserMapper(user);

            // Obtener la lista de seguidores
            if (followType == "follower")
            {
                profileUser.FollowerList = _followDAL.GetFollowerList(profileUser.IdUser);

            }
            else if (followType == "followed")
            {
                profileUser.FollowerList = _followDAL.GetFollowedList(profileUser.IdUser);
            }
            return View(profileUser);
        }

        public IActionResult Follow(string username)
        {
            UserViewModel profileUser = UserViewModel.UserMapper(_userDAL.GetUserByUserName(username));
            UserViewModel sessionUser = UserViewModel.UserMapper(_userDAL.GetUserByUserName(HttpContext.Session.GetString(Tools.Tools.UserNameSession)));
            _followDAL.AddFollower(sessionUser.IdUser,profileUser.IdUser);
            return RedirectToAction("Index", "User", new { username = username }); ;
        }
        public IActionResult UnFollow(string username)
        {
            UserViewModel profileUser = UserViewModel.UserMapper(_userDAL.GetUserByUserName(username));
            UserViewModel sessionUser = UserViewModel.UserMapper(_userDAL.GetUserByUserName(HttpContext.Session.GetString(Tools.Tools.UserNameSession)));
            _followDAL.DeleteFollow(sessionUser.IdUser, profileUser.IdUser);
            return RedirectToAction("Index", "User", new { username = username }); ;
        }
        public IActionResult Configuration(string username)
        {
            User? profileUser = _userDAL.GetUserByUserName(username);
            return View(profileUser);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Configuration(User user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    User updatedUser = _userDAL.UpdateUser(user);
                    if (updatedUser != null)
                    {
                        HttpContext.Session.SetString("UserImg", user.ProfileImageUrl != null ? updatedUser.ProfileImageUrl:string.Empty);
                        return RedirectToAction("Index", "User", new { username = user.UserName });
                    }
                }
                else
                {
                    return View(user);
                }
            }
            catch (Exception)
            {
                return View(user);
            }
            return View(user);
        }

        [HttpPost]
        public IActionResult ChangeList(string? username, UserViewModel user)
        {
            return RedirectToAction("Index","User", new { username = user.UserName, selectedListId = user.IdSelectedListOfBooks });
        }
    }
}
