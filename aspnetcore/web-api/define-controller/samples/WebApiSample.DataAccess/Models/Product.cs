using System.ComponentModel.DataAnnotations;

namespace WebApiSample.DataAccess.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
