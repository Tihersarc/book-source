using BookSource.Models.ViewModel;

namespace BookSource.Tools
{
    public static class Tools
    {
        public static List<BookViewModel> BookListTemporal()
        {
            List<BookViewModel> bookList = new List<BookViewModel>();
            bookList.Add(new BookViewModel { Author = "Shiro",Categories = CategoryListTemporal(),Description="La mejor loli del mundo",Editorial="Editorial",IdBook=1, ImageLink="https://i.pinimg.com/736x/92/93/90/929390ff37e0213ff37e2ad46290cd0c--anime-characters-video-game.jpg",PageCount=12,Score=5,SubTitle="NGNL",Title="Shiro" });
            bookList.Add(new BookViewModel { Author = "Kanna", Categories = CategoryListTemporal(), Description = "La tercera mejor loli del mundo", Editorial = "Editorial", IdBook = 2, ImageLink = "https://i.pinimg.com/736x/92/93/90/929390ff37e0213ff37e2ad46290cd0c--anime-characters-video-game.jpg", PageCount = 12, Score = 5, SubTitle = "NGNL", Title = "No game no life" });
            bookList.Add(new BookViewModel { Author = "Izuna", Categories = CategoryListTemporal(), Description = "La segunda mejor loli del mundo", Editorial = "Editorial", IdBook = 3, ImageLink = "https://i.pinimg.com/736x/92/93/90/929390ff37e0213ff37e2ad46290cd0c--anime-characters-video-game.jpg", PageCount = 12, Score = 5, SubTitle = "NGNL", Title = "Izuna" });
            bookList.Add(new BookViewModel { Author = "Empty", Categories = CategoryListTemporal(),  Editorial = "Empty", IdBook = 4, PageCount = 12, Score = 5, Title = "Empty" });

            return bookList;
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
    }
}
