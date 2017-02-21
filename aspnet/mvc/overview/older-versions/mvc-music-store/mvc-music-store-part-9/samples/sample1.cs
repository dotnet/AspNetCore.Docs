private void MigrateShoppingCart(string UserName)
{
    // Associate shopping cart items with logged-in user
    var cart = ShoppingCart.GetCart(this.HttpContext);
 
    cart.MigrateCart(UserName);
    Session[ShoppingCart.CartSessionKey] = UserName;
}