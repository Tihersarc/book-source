using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookScraper.DALs
{
    internal class BookDAL
    {
        private BookDataClassesDataContext db;

        public BookDAL()
        {
            db = new BookDataClassesDataContext();
        }

        public void Insert(Models.BookModel b)
        {
            try
            {
                Book book = new Book()
                {
                    Title = b.Title,
                    Subtitle = b.Subtitle,
                    //-----------------------------------Genre
                    Author = b.Author,
                    Editorial = b.Publisher,
                    Description = b.Description,
                    PageCount = b.PageCount,
                    ImageUrl = b.ImageLink,
                    Score = b.AverageRating
                };

                foreach (string item in b.GenreList)
                {
                    if (!db.Category.Any(genre => genre.CategoryName == item))
                    {
                        //Add genre && create relation
                    }
                    else
                    {
                        //Create relation in mid table

                        //db.Book_Category()
                    }
                }

                db.Book.InsertOnSubmit(book);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ERROR on Insert:\n" + ex.ToString());
            }
        }
    }
}
