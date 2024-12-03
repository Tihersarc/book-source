
using System.Data.Linq.Mapping;

namespace BookScraper.Models
{
    [Table(Name = "Category")]
    internal class Category
    {
        public int IdCategory { get; set; }
        public string CategoyName {  get; set; }
    }
}
