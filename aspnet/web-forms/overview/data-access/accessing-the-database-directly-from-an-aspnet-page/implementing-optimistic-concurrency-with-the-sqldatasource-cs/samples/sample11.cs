protected void Products_RowUpdated(object sender, GridViewUpdatedEventArgs e)
{
    if (e.AffectedRows == 0)
    {
        ConcurrencyViolationMessage.Visible = true;
        e.KeepInEditMode = true;
        // Rebind the data to the GridView to show the latest changes
        Products.DataBind();
    }
}
protected void Products_RowDeleted(object sender, GridViewDeletedEventArgs e)
{
    if (e.AffectedRows == 0)
        ConcurrencyViolationMessage.Visible = true;
}