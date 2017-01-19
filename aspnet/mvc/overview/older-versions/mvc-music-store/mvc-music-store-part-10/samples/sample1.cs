//
// GET: /ShoppingCart/CartSummary
[ChildActionOnly]
 public ActionResult CartSummary()
{
    var cart = ShoppingCart.GetCart(this.HttpContext);
 
    ViewData["CartCount"] = cart.GetCount();
    return PartialView("CartSummary");
}