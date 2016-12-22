protected void ProductsGrid_RowUpdated(object sender, GridViewUpdatedEventArgs e)
{
    if (e.Exception != null && e.Exception.InnerException != null)
    {
        if (e.Exception.InnerException is System.Data.DBConcurrencyException)
        {
            // Display the warning message and note that the
            // exception has been handled...
            UpdateConflictMessage.Visible = true;
            e.ExceptionHandled = true;
        }
    }
}