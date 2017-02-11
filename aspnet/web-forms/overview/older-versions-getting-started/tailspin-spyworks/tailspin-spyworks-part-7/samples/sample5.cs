decimal _CartTotal = 0;

protected void MyList_RowDataBound(object sender, GridViewRowEventArgs e)
{
  if (e.Row.RowType == DataControlRowType.DataRow)
     {
     TailspinSpyworks.Data_Access.VewOrderDetail myCart = new 
                                                        Data_Access.VewOrderDetail();
     myCart = (TailspinSpyworks.Data_Access.VewOrderDetail)e.Row.DataItem;
     _CartTotal += Convert.ToDecimal(myCart.UnitCost * myCart.Quantity);
     }
   else if (e.Row.RowType == DataControlRowType.Footer)
     {
     e.Row.Cells[5].Text = "Total: " + _CartTotal.ToString("C");
   }
}