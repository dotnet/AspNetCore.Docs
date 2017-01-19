public OrderDTO GetOrder(int id)
{
    Order order = db.Orders.Include("OrderDetails.Product")
        .First(o => o.Id == id && o.Customer == User.Identity.Name);
    if (order == null)
    {
        throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
    }

    return new OrderDTO()
    {
        Details = from d in order.OrderDetails
                  select new OrderDTO.Detail()
                      {
                          ProductID = d.Product.Id,
                          Product = d.Product.Name,
                          Price = d.Product.Price,
                          Quantity = d.Quantity
                      }
    };
}