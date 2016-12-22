protected void ProductsOptimisticConcurrencyDataSource_Deleted(
    object sender, ObjectDataSourceStatusEventArgs e)
{
    if (e.ReturnValue != null && e.ReturnValue is bool)
    {
        bool deleteReturnValue = (bool)e.ReturnValue;
        if (deleteReturnValue == false)
        {
            // No row was deleted, display the warning message
            DeleteConflictMessage.Visible = true;
        }
    }
}