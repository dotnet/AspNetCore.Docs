//------------------------------------------------------------------------------------+
public void RemoveItem(string cartID, int  productID)
{
	using (CommerceEntities db = new CommerceEntities())
	{
		try
		{
			var myItem = (from c in db.ShoppingCarts where c.CartID == cartID && 
						 c.ProductID == productID select c).FirstOrDefault();
			if (myItem != null)
			{
				db.DeleteObject(myItem);
				db.SaveChanges();
			}
		}
		catch (Exception exp)
		{
			throw new Exception("ERROR: Unable to Remove Cart Item - " + 
								  exp.Message.ToString(), exp);
		}
	}
}