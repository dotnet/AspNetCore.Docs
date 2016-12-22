//--------------------------------------------------------------------------------------+
public void MigrateCart(String oldCartId, String UserName)
{
  using (CommerceEntities db = new CommerceEntities())
    {
    try
      {
      var myShoppingCart = from cart in db.ShoppingCarts
                           where cart.CartID == oldCartId
                           select cart;

      foreach (ShoppingCart item in myShoppingCart)
        {
        item.CartID = UserName;                 
        }
      db.SaveChanges();
      Session[CartId] = UserName;
      }
    catch (Exception exp)
      {
      throw new Exception("ERROR: Unable to Migrate Shopping Cart - " +     
                           exp.Message.ToString(), exp);
      }
    }           
}