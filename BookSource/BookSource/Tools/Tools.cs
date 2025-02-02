﻿using BookSource.Models.ViewModel;
using System.Runtime.CompilerServices;

namespace BookSource.Tools
{
    public static class Tools
    {
        public static string DefaultBookImg = "https://static-01.daraz.pk/p/9c4bbb21ac32475a2f3d8c55d2b7337d.jpg";
        public static string DefaultUserImg = "https://static.vecteezy.com/system/resources/previews/008/442/086/non_2x/illustration-of-human-icon-user-symbol-icon-modern-design-on-blank-background-free-vector.jpg";
        public static string ConfigImg = "https://cdn-icons-png.flaticon.com/512/3524/3524659.png";
        public static string UserNameSession = "UserName";
        public static string UserImgSession = "UserImg";

        public static List<BookViewModel> BookListTemporal()
        {
            List<BookViewModel> bookList = new List<BookViewModel>();
            bookList.Add(new BookViewModel { Author = "Shiro",Categories = CategoryListTemporal(),Description="La mejor loli del mundo",Editorial="Editorial",IdBook=1, ImageLink="https://i.pinimg.com/736x/92/93/90/929390ff37e0213ff37e2ad46290cd0c--anime-characters-video-game.jpg",PageCount=12,Score=5,SubTitle="NGNL",Title="Shiro" });
            bookList.Add(new BookViewModel { Author = "Kanna", Categories = CategoryListTemporal(), Description = "La tercera mejor loli del mundo", Editorial = "Editorial", IdBook = 2, ImageLink = "https://i.pinimg.com/736x/92/93/90/929390ff37e0213ff37e2ad46290cd0c--anime-characters-video-game.jpg", PageCount = 12, Score = 5, SubTitle = "NGNL", Title = "No game no life" });
            bookList.Add(new BookViewModel { Author = "Izuna", Categories = CategoryListTemporal(), Description = "La segunda mejor loli del mundo", Editorial = "Editorial", IdBook = 3, ImageLink = "https://i.pinimg.com/736x/92/93/90/929390ff37e0213ff37e2ad46290cd0c--anime-characters-video-game.jpg", PageCount = 12, Score = 5, SubTitle = "NGNL", Title = "Izuna" });
            bookList.Add(new BookViewModel { Author = "Empty", Categories = CategoryListTemporal(),  Editorial = "Empty", IdBook = 4, PageCount = 12, Score = 5, Title = "Empty" });

            return bookList;
        }


        public static UserViewModel UserTemporal()
        {
            UserViewModel userModel = new UserViewModel()
            {
                IdUser = 1,
                UserName = "Test",
                ProfileImageUrl = DefaultBookImg,
                Birthdate = DateTime.Now,
                Email = "usertest@shiro.com",
                ListOfBooks= ListOfBooksViewModels()
            };
            return userModel;
        }
        public static List<CategoryViewModel> CategoryListTemporal()
        {
            List<CategoryViewModel> list =
            [
                new CategoryViewModel { IdCategory=1,Category="Action"},
                new CategoryViewModel { IdCategory = 2, Category = "Isekai" },
                new CategoryViewModel { IdCategory = 3, Category = "Ecchi" },
            ];

            return list;
        }
        public static List<ListOfBooksViewModel> ListOfBooksViewModels()
        {
            List<ListOfBooksViewModel>list=
                [
                    new ListOfBooksViewModel() { IdListOfBooks = 1 ,Books=BookListTemporal(),ListName="Lista0"},
                    new ListOfBooksViewModel() { IdListOfBooks = 2, Books = BookListTemporal(), ListName = "Lista1" },
                    new ListOfBooksViewModel() { IdListOfBooks = 3, Books = BookListTemporal(), ListName = "Lista2" }
                ];
            return list;
        }
    }
}
