public class ProductRating
{
    public int ID { get; set; }

    [ForeignKey("Product")]
    public int ProductID { get; set; }
    public virtual Product Product { get; set; }  // Navigation property

    public int Rating { get; set; }
}