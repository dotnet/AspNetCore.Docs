//--------------------------------------------------------------------------------------+
public bool SubmitOrder(string UserName)
{
  using (CommerceEntities db = new CommerceEntities())
    {
    try
      {
      //------------------------------------------------------------------------+
      //  Add New Order Record                                                  |
      //------------------------------------------------------------------------+
      Order newOrder = new Order();
      newOrder.CustomerName = UserName;
      newOrder.OrderDate = DateTime.Now;
      newOrder.ShipDate = CalculateShipDate();
      db.Orders.AddObject(newOrder);
      db.SaveChanges();
         
      //------------------------------------------------------------------------+
      //  Create a new OderDetail Record for each item in the Shopping Cart     |
      //------------------------------------------------------------------------+
      String cartId = GetShoppingCartId();
      var myCart = (from c in db.ViewCarts where c.CartID == cartId select c);
      foreach (ViewCart item in myCart)
        {
        int i = 0;
        if (i < 1)
          {
          OrderDetail od = new OrderDetail();
          od.OrderID = newOrder.OrderID;
          od.ProductID = item.ProductID;
          od.Quantity = item.Quantity;
          od.UnitCost = item.UnitCost;
          db.OrderDetails.AddObject(od);
          i++;
          }

        var myItem = (from c in db.ShoppingCarts where c.CartID == item.CartID && 
                         c.ProductID == item.ProductID select c).FirstOrDefault();
        if (myItem != null)
          {
          db.DeleteObject(myItem);
          }
        }
      db.SaveChanges();                    
      }
    catch (Exception exp)
      {
      throw new Exception("ERROR: Unable to Submit Order - " + exp.Message.ToString(), 
                                                               exp);
      }
    } 
  return(true);
}