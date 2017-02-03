protected void CheckoutBtn_Click(object sender, ImageClickEventArgs e)
{
	using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
	{
		Session["payment_amt"] = usersShoppingCart.GetTotal();
	}
	Response.Redirect("Checkout/CheckoutStart.aspx");
}