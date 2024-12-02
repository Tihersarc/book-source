using BookScraper.Scripts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                MessageBox.Show("Book:\n" + b.ToString());
        }

        private async void btnQuery_Click(object sender, EventArgs e)
        {
            List<Book> books = new List<Book>();

            for (int currentPage = 0; currentPage < numPages.Value; currentPage++)
            {
                books.AddRange(await scraper.GetBooks(txtQuery.Text, currentPage));
            }

            dgvBooks.DataSource = books;
        }
    }
}
