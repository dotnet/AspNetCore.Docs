public HttpResponseMessage PostOrder(OrderDTO dto)
{
    if (ModelState.IsValid)
    {
        var order = new Order()
        {
            Customer = User.Identity.Name,
            OrderDetails = (from item in dto.Details select new OrderDetail() 
                { ProductId = item.ProductID, Quantity = item.Quantity }).ToList()
        };

        db.Orders.Add(order);
        db.SaveChanges();

        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, order);
        response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = order.Id }));
        return response;
    }
    else
    {
        return Request.CreateResponse(HttpStatusCode.BadRequest);
    }
}