using System;
using System.Text;

namespace BookCatalog.Models
{
    /// <summary>
    /// Define a class that will hold the detailed information for a book.
    /// </summary>
    public class BookDetails
    {
        public String Id { get; set; }
        public String Title { get; set; }
        public String Author { get; set; }
        public String Genre { get; set; }
        public Decimal Price { get; set; }
        public DateTime PublishDate { get; set; }
        public String Description { get; set; }
    }
}