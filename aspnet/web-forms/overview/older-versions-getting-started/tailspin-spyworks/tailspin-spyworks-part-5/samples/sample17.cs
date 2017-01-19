//--------------------------------------------------------------------------------------+
protected void UpdateBtn_Click(object sender, ImageClickEventArgs e)
{
  MyShoppingCart usersShoppingCart = new MyShoppingCart();
  String cartId = usersShoppingCart.GetShoppingCartId();

  ShoppingCartUpdates[] cartUpdates = new ShoppingCartUpdates[MyList.Rows.Count];
  for (int i = 0; i < MyList.Rows.Count; i++)
    {
    IOrderedDictionary rowValues = new OrderedDictionary();
    rowValues = GetValues(MyList.Rows[i]);
    cartUpdates[i].ProductId =  Convert.ToInt32(rowValues["ProductID"]);
    cartUpdates[i].PurchaseQantity = Convert.ToInt32(rowValues["Quantity"]); 

    CheckBox cbRemove = new CheckBox();
    cbRemove = (CheckBox)MyList.Rows[i].FindControl("Remove");
    cartUpdates[i].RemoveItem = cbRemove.Checked;
    }

   usersShoppingCart.UpdateShoppingCartDatabase(cartId, cartUpdates);
   MyList.DataBind();
   lblTotal.Text = String.Format("{0:c}", usersShoppingCart.GetTotal(cartId));
}