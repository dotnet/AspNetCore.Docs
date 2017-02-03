protected void ObjectDataSource1_Deleted(
    object sender, ObjectDataSourceStatusEventArgs e)
{
    // If we get back a Boolean value from the DeleteProduct method and it's true,
    // then we successfully deleted the product. Set AffectedRows to 1
    if (e.ReturnValue is bool && ((bool)e.ReturnValue) == true)
        e.AffectedRows = 1;
}