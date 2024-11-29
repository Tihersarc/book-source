using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookScraper.Scripts
{
    internal class Book
    {
        string Name {  get; set; }
        string Author { get; set; }
        string Genre { get; set; }
        string Descritpion {  get; set; }

        public Book(string name, string author, string genre, string descripton) {
            Name = name;
            Author = author;
            Genre = genre;
            Descritpion = descripton;
        }
    }
}
