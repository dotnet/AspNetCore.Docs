//
// POST: /Checkout/AddressAndPayment
[HttpPost]
public ActionResult AddressAndPayment(FormCollection values)
{
    var order = new Order();
    TryUpdateModel(order);
 
    try
    {
        if (string.Equals(values["PromoCode"], PromoCode,
            StringComparison.OrdinalIgnoreCase) == false)
        {
            return View(order);
        }
        else
        {
            order.Username = User.Identity.Name;
            order.OrderDate = DateTime.Now;
 
            //Save Order
            storeDB.Orders.Add(order);
            storeDB.SaveChanges();
            //Process the order
            var cart = ShoppingCart.GetCart(this.HttpContext);
            cart.CreateOrder(order);
 
            return RedirectToAction("Complete",
                new { id = order.OrderId });
        }
    }
    catch
    {
        //Invalid - redisplay with errors
        return View(order);
    }
}