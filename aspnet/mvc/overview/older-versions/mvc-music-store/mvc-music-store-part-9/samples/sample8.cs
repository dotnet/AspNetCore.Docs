//
// GET: /Checkout/Complete
public ActionResult Complete(int id)
{
    // Validate customer owns this order
    bool isValid = storeDB.Orders.Any(
        o => o.OrderId == id &&
        o.Username == User.Identity.Name);
 
    if (isValid)
    {
        return View(id);
    }
    else
    {
        return View("Error");
    }
}