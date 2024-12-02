﻿using BookScraper.Scripts;
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
            //Book b = await scraper.GetBookById("Y3OypwAACAAJ");
            Book b = await scraper.GetBookById("BcG2dVRXKukC");

            MessageBox.Show("Book:\n" + b.ToString());
        }
    }
}
