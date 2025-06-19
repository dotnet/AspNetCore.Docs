namespace App.Models;

public class Order
{
    public string Id { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? ShipDate { get; set; }
    public decimal TotalAmount { get; set; }

    public Order()
    {
        Id = Guid.NewGuid().ToString();
    }
}
