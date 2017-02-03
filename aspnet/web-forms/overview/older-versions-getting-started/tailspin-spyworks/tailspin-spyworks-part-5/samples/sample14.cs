//--------------------------------------------------------------------------------------+
public void UpdateItem(string cartID, int productID, int quantity)
{
	using (CommerceEntities db = new CommerceEntities())
	{
		try
		{
			var myItem = (from c in db.ShoppingCarts where c.CartID == cartID && 
					c.ProductID == productID select c).FirstOrDefault();
			if (myItem != null)
			{
				myItem.Quantity = quantity;
				db.SaveChanges();
			}
		}
		catch (Exception exp)
		{
			throw new Exception("ERROR: Unable to Update Cart Item - " +     
								exp.Message.ToString(), exp);
		}
	}
}