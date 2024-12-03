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

        public void Insert(Models.Book b)
        {
            try
            {
                Book newBook = new Book()
                {
                    Title = b.Title,
                    Subtitle = b.Subtitle,
                    Author = b.Author,
                    Editorial = b.Publisher,
                    Description = b.Description,
                    PageCount = b.PageCount,
                    ImageUrl = b.ImageLink,
                    Score = b.AverageRating
                };

                db.Book.InsertOnSubmit(newBook);
                db.SubmitChanges();

                foreach (string item in b.GenreList)
                {
                    if (!db.Category.Any(genre => genre.CategoryName == item))
                    {
                        //Add genre if it doesn't exist
                        Category newCategory = new Category
                        {
                            CategoryName = item,
                        };

                        db.Category.InsertOnSubmit(newCategory);
                    }

                    //Create relation in mid table

                    int categoryId = db.Category
                        .Where(genre=> genre.CategoryName == item)
                        .Select(genre => genre.IdCategory)
                        .FirstOrDefault();

                        Book_Category book_Category = new Book_Category
                        {
                            FkIdBook = newBook.IdBook,
                            FkIdCategory = categoryId
                        };

                        db.Book_Category.InsertOnSubmit(book_Category);
                        db.SubmitChanges();                    
                }

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ERROR on Insert:\n" + ex.ToString());
            }
        }
    }
}
