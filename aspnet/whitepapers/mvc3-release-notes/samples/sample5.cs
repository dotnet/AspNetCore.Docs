public class Product
{
     public int ProductId { get; set; }
     [Required]
     public string Name { get; set; }

     // Product belongs to Category
     public int CategoryId { get; set; }
     public virtual Category Category { get; set; }
}
public class Category
{
     public int CategoryId { get; set; }
     [Required]
     public string Name { get; set; }
}