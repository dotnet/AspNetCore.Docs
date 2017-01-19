protected void CheckoutBtn_Click(object sender, ImageClickEventArgs e)
{
  MyShoppingCart usersShoppingCart = new MyShoppingCart();
  if (usersShoppingCart.SubmitOrder(User.Identity.Name) == true)
    {
    CheckOutHeader.InnerText = "Thank You - Your Order is Complete.";
    Message.Visible = false;
    CheckoutBtn.Visible = false;
    }
  else
    {
    CheckOutHeader.InnerText = "Order Submission Failed - Please try again. ";
    }
}