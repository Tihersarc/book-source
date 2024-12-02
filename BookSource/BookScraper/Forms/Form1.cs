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
            //Book b = await scraper.GetBookById("BcG2dVRXKukC");
            Book b = await scraper.GetBookById(txtId.Text);

            if (b != null)
                MessageBox.Show("Book:\n" + b.ToString());
        }

        private async void btnQuery_Click(object sender, EventArgs e)
        {
            List<Book> books = await scraper.GetBooks(txtQuery.Text);

            dgvBooks.DataSource = books;
        }
    }
}
