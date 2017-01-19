public class Supplier
{
    [Key]
    public string Key {get; set; }
    public string Name { get; set; }
}
public class Category
{
    public int ID { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Product> Products { get; set; }
}

public class Product
{
    public int ID { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    [ForeignKey("Category")]
    public int CategoryId { get; set; }
    public Category Category { get; set; }

    [ForeignKey("Supplier")]
    public string SupplierId { get; set; }
    public virtual Supplier Supplier { get; set; }
}