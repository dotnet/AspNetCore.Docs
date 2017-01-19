[RoutePrefix("orders")] 
public class OrdersController : ApiController 
{ 
    [Route("{id}")] 
    public Order Get(int id) { } 
    [Route("{id}/approve")] 
    public Order Approve(int id) { } 
}