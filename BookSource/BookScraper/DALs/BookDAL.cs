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

        public void Insert(Scripts.Book b)
        {
            try
            {
                Book book = new Book()
                {
                    //IdBook = b.IdBook, id auto
                    Title = b.Title,
                    Subtitle = b.Subtitle,
                    //-----------------------------------Genre
                    Author = b.Author,
                    Editorial = b.Publisher,
                    Description = b.Description,
                    PageCount = string.IsNullOrWhiteSpace(b.PageCount) ? int.Parse(b.PageCount) : 0,
                    ImageUrl = b.ImageLink,
                    Score = b.AverageRating
                };

                db.Book.InsertOnSubmit(book);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ERROR on Insert:\n" + ex.ToString());
                throw;
            }
        }
    }
}
