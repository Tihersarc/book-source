using BookScraper.DALs;
using BookScraper.Scripts;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BookScraper
{
    public partial class Form1 : Form
    {
        Scraper scraper;
        public Form1()
        {
            InitializeComponent();
            scraper = new Scraper();
        }

        private async void btnBookById_Click(object sender, EventArgs e)
        {
            Book b = await scraper.GetBookById(txtId.Text);

            if (b != null)
                MessageBox.Show("BookModel:\n" + b.ToString());
        }

        private async void btnQuery_Click(object sender, EventArgs e)
        {
            List<Book> books = new List<Book>();

            for (int currentPage = 0; currentPage < numPages.Value; currentPage++)
            {
                books.AddRange(await scraper.GetBooks(txtQuery.Text, currentPage));
            }

            dgvBooks.DataSource = books;

            BookDAL dal = new BookDAL();

            foreach (Book book in books)
            {
                dal.Insert(book);
            }
        }
    }
}
