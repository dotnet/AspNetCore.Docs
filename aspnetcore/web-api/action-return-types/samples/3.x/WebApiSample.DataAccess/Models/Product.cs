using System.ComponentModel.DataAnnotations;

namespace WebApiSample.DataAccess.Models
{
    // <snippet_ProductClass>
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public bool IsOnSale { get; set; }
    }
    // </snippet_ProductClass>
}
