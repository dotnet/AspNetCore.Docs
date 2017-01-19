//------------------------------------------------------------------------------------+
public void AddItem(string cartID, int productID, int quantity)
{
  using (CommerceEntities db = new CommerceEntities())
    {
    try 
      {
      var myItem = (from c in db.ShoppingCarts where c.CartID == cartID && 
                              c.ProductID == productID select c).FirstOrDefault();
      if(myItem == null)
        {
        ShoppingCart cartadd = new ShoppingCart();
        cartadd.CartID = cartID;
        cartadd.Quantity = quantity;
        cartadd.ProductID = productID;
        cartadd.DateCreated = DateTime.Now;
        db.ShoppingCarts.AddObject(cartadd);
        }
      else
        {
        myItem.Quantity += quantity;
        }
      db.SaveChanges();
      }
    catch (Exception exp)
      {
      throw new Exception("ERROR: Unable to Add Item to Cart - " + 
                                                          exp.Message.ToString(), exp);
      }
   }
}