public IEnumerable<Order> GetOrders()
{
    return db.Orders.Where(o => o.Customer == User.Identity.Name);
}