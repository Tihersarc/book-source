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
        List<Models.Book> books;

        public Form1()
        {
            InitializeComponent();
            scraper = new Scraper();
        }

        private async void btnBookById_Click(object sender, EventArgs e)
        {
            Models.Book b = await scraper.GetBookById(txtId.Text);

            if (b != null)
                MessageBox.Show("BookModel:\n" + b.ToString());
        }

        private async void btnQuery_Click(object sender, EventArgs e)
        {
            books = new List<Models.Book>();

            for (int currentPage = 0; currentPage < numPages.Value; currentPage++)
            {
                books.AddRange(await scraper.GetBooks(txtQuery.Text, currentPage));
            }

            dgvBooks.DataSource = books;
        }

        private void btnAddToDB_Click(object sender, EventArgs e)
        {
            BookDAL dal = new BookDAL();

            foreach (Models.Book book in books)
            {
                dal.Insert(book);
            }
        }
    }
}
