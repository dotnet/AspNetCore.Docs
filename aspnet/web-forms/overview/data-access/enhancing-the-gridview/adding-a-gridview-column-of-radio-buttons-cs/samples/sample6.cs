protected void Suppliers_RowCreated(object sender, GridViewRowEventArgs e)
{
    if (e.Row.RowType == DataControlRowType.DataRow)
    {
        // Grab a reference to the Literal control
        Literal output = (Literal)e.Row.FindControl("RadioButtonMarkup");
        // Output the markup except for the "checked" attribute
        output.Text = string.Format(
            @"<input type="radio" name="SuppliersGroup" " +
            @"id="RowSelector{0}" value="{0}" />", e.Row.RowIndex);
    }
}