protected void Page_Load(object sender, EventArgs e)
{
	using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
	{
		decimal cartTotal = 0;
		cartTotal = usersShoppingCart.GetTotal();
		if (cartTotal > 0)
		{
			// Display Total.
			lblTotal.Text = String.Format("{0:c}", cartTotal);
		}
		else
		{
			LabelTotalText.Text = "";
			lblTotal.Text = "";
			ShoppingCartTitle.InnerText = "Shopping Cart is Empty";
			UpdateBtn.Visible = false;
			CheckoutImageBtn.Visible = false;
		}
	}
}