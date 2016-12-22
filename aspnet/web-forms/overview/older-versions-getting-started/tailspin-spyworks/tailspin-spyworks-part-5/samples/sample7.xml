public const string CartId = "TailSpinSpyWorks_CartID";

//--------------------------------------------------------------------------------------+
public String GetShoppingCartId()
{
  if (Session[CartId] == null)
     {
     Session[CartId] = System.Web.HttpContext.Current.Request.IsAuthenticated ? 
                                        User.Identity.Name : Guid.NewGuid().ToString();
     }
  return Session[CartId].ToString();
}