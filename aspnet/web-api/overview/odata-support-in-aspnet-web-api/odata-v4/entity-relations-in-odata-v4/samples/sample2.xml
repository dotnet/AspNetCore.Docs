using System.ComponentModel.DataAnnotations.Schema;

namespace ProductService.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

        // New code:    
        [ForeignKey("Supplier")]
        public int? SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}