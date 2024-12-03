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

        public void Insert(Book b)
        {
            try
            {

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ERROR on Insert:\n" + ex.ToString());
                throw;
            }
            Book book = new Book()
            {
                IdBook = b.IdBook,
                Title = b.Title,
                Subtitle = b.Subtitle,
                //Genre
                Author = b.Author,
                Editorial = b.Editorial,
                Description = b.Description,
                PageCount = b.PageCount,
                ImageUrl = b.ImageUrl,
                Score = b.Score
            };

            db.Book.InsertOnSubmit(book);
            db.SubmitChanges();
            
        }


    }
}
