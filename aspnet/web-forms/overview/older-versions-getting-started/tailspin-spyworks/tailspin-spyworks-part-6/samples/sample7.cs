decimal _CartTotal = 0;

//--------------------------------------------------------------------------------------+
protected void MyList_RowDataBound(object sender, GridViewRowEventArgs e)
{
  if (e.Row.RowType == DataControlRowType.DataRow)
     {
     TailspinSpyworks.Data_Access.ViewCart myCart = new Data_Access.ViewCart();
     myCart = (TailspinSpyworks.Data_Access.ViewCart)e.Row.DataItem;
     _CartTotal += myCart.UnitCost * myCart.Quantity;
     }
   else if (e.Row.RowType == DataControlRowType.Footer)
     {
     if (_CartTotal > 0)
        {
        CheckOutHeader.InnerText = "Review and Submit Your Order";
        LabelCartHeader.Text = "Please check all the information below to be sure
                                                                it&#39;s correct.";
        CheckoutBtn.Visible = true;
        e.Row.Cells[5].Text = "Total: " + _CartTotal.ToString("C");
        }
     }
}