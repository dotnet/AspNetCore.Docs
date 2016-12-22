protected void LoginUser_LoggedIn(object sender, EventArgs e)
{
  MyShoppingCart usersShoppingCart = new MyShoppingCart();
  String cartId = usersShoppingCart.GetShoppingCartId();
  usersShoppingCart.MigrateCart(cartId, LoginUser.UserName);
            
  if(Session["LoginReferrer"] != null)
    {
    Response.Redirect(Session["LoginReferrer"].ToString());
    }

  Session["UserName"] = LoginUser.UserName;
}