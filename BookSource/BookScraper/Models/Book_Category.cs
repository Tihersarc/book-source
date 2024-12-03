using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookScraper.Models
{
    [Table(Name = "Book_Category")]
    internal class Book_Category
    {
        public int FkIdCategory { get; set; }
        public int FkIdBook { get; set; }
    }
}
