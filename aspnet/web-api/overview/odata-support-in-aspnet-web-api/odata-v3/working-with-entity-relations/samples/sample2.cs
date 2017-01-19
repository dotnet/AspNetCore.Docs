public class Product
{
    public int ID { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }

    // New code
    [ForeignKey("Supplier")]
    public string SupplierId { get; set; }
    public virtual Supplier Supplier { get; set; }
}