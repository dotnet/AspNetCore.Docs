using System.ComponentModel.DataAnnotations;

namespace WebApiSample.Models
{
    public class Product
    {
        public int Id { get; set; }

        public bool IsDiscontinued { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }
    }
}
