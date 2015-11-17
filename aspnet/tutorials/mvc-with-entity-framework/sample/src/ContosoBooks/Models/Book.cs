using System.ComponentModel.DataAnnotations;

namespace ContosoBooks.Models
{
    public class Book
    {
        [ScaffoldColumn(false)]
        public int BookID { get; set; }
        [Required]
        public string Title { get; set; }

        public int Year { get; set; }
        [Range(1, 500)]
        public decimal Price { get; set; }

        public string Genre { get; set; }

        [ScaffoldColumn(false)]
        public int AuthorID { get; set; }

        // Navigation property
        public virtual Author Author { get; set; }
    }
}
