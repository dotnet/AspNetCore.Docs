//-------------------------------------------------------------------------------------+
private void WriteAlsoPurchased(int currentProduct)
{
  using (CommerceEntities db = new CommerceEntities())
        {
        try
          {
          var v = db.SelectPurchasedWithProducts(currentProduct);
          RepeaterItemsList.DataSource = v;
          RepeaterItemsList.DataBind();
          }
         catch (Exception exp)
          {
          throw new Exception("ERROR: Unable to Write Also Purchased - " + 
                                                          exp.Message.ToString(), exp);
          }
        }
}