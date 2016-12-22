var order = new Order()
{
    Customer = User.Identity.Name,
    OrderDetails = (from item in dto.Details select new OrderDetail() 
        { ProductId = item.ProductID, Quantity = item.Quantity }).ToList()
};