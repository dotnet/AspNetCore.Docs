//--------------------------------------------------------------------------------------+
public decimal GetTotal(string cartID)
{
	using (CommerceEntities db = new CommerceEntities())
	{
		decimal cartTotal = 0;
		try
		{
			var myCart = (from c in db.ViewCarts where c.CartID == cartID select c);
			if (myCart.Count() > 0)
			{
				cartTotal = myCart.Sum(od => (decimal)od.Quantity * (decimal)od.UnitCost);
			}
		}
		catch (Exception exp)
		{
			throw new Exception("ERROR: Unable to Calculate Order Total - " + 
			exp.Message.ToString(), exp);
		}
		return (cartTotal);
	 }
}