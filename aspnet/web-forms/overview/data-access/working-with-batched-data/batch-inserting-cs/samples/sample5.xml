protected void AddProducts_Click(object sender, EventArgs e)
{
    // TODO: Save the products
    // Revert to the display interface
    ReturnToDisplayInterface();
}
protected void CancelButton_Click(object sender, EventArgs e)
{
    // Revert to the display interface
    ReturnToDisplayInterface();
}
const int firstControlID = 1;
const int lastControlID = 5;
private void ReturnToDisplayInterface()
{
    // Reset the control values in the inserting interface
    Suppliers.SelectedIndex = 0;
    Categories.SelectedIndex = 0;
    for (int i = firstControlID; i <= lastControlID; i++)
    {
        ((TextBox)InsertingInterface.FindControl("ProductName" + i.ToString())).Text =
            string.Empty;
        ((TextBox)InsertingInterface.FindControl("UnitPrice" + i.ToString())).Text = 
            string.Empty;
    }
    DisplayInterface.Visible = true;
    InsertingInterface.Visible = false;
}