protected void DataList1_DeleteCommand(object source, DataListCommandEventArgs e)
{
    // Read in the ProductID from the DataKeys collection
    int productID = Convert.ToInt32(DataList1.DataKeys[e.Item.ItemIndex]);
    // Delete the data
    ProductsBLL productsAPI = new ProductsBLL();
    productsAPI.DeleteProduct(productID);
    // Rebind the data to the DataList
    DataList1.DataBind();
}