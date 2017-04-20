using System.ComponentModel.DataAnnotations;

namespace BooksAPI.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}