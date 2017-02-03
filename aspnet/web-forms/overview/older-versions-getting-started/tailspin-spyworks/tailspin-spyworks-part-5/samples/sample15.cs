//-------------------------------------------------------------------------------------+
public void UpdateShoppingCartDatabase(String cartId, 
                                       ShoppingCartUpdates[] CartItemUpdates)
{
  using (CommerceEntities db = new CommerceEntities())
    {
    try
      {
      int CartItemCOunt = CartItemUpdates.Count();
      var myCart = (from c in db.ViewCarts where c.CartID == cartId select c);
      foreach (var cartItem in myCart)
        {
        // Iterate through all rows within shopping cart list
        for (int i = 0; i < CartItemCOunt; i++)
          {
          if (cartItem.ProductID == CartItemUpdates[i].ProductId)
             {
             if (CartItemUpdates[i].PurchaseQantity < 1 || 
   CartItemUpdates[i].RemoveItem == true)
                {
                RemoveItem(cartId, cartItem.ProductID);
                }
             else 
                {
                UpdateItem(cartId, cartItem.ProductID, 
                                   CartItemUpdates[i].PurchaseQantity);
                }
              }
            }
          }
        }
      catch (Exception exp)
        {
        throw new Exception("ERROR: Unable to Update Cart Database - " + 
                             exp.Message.ToString(), exp);
        }            
    }           
}