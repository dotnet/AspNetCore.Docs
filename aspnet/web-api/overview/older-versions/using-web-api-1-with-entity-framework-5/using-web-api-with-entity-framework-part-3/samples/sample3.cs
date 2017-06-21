public class OrdersContext : DbContext
{
    public OrdersContext() : base("name=OrdersContext")
    {
    }

    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Product> Products { get; set; }
}