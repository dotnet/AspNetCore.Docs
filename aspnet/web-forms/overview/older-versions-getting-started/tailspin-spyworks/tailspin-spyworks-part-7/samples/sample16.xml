//--------------------------------------------------------------------------------------+
protected void Page_PreRender(object sender, EventArgs e)
{
  if (_ProductId < 1)
     {
     // This should never happen but we could expand the use of this control by reducing 
     // the dependency on the query string by selecting a few RANDOME products here. 
     Debug.Fail("ERROR : The Also Purchased Control Can not be used without 
                         setting the ProductId.");
     throw new Exception("ERROR : It is illegal to load the AlsoPurchased COntrol 
                                  without setting a ProductId.");
     }
      
  int ProductCount = 0;
  using (CommerceEntities db = new CommerceEntities())
    {
    try
      {
      var v = db.SelectPurchasedWithProducts(_ProductId);
      ProductCount = v.Count();
      }
    catch (Exception exp)
      {
      throw new Exception("ERROR: Unable to Retrieve Also Purchased Items - " + 
                                  exp.Message.ToString(), exp);
      }
    }

  if (ProductCount > 0)
     {
     WriteAlsoPurchased(_ProductId);              
     }
  else
     {
     WritePopularItems();
     }
}