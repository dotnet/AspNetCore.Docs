protected void ProductsDataSource_Selecting
    (object sender, ObjectDataSourceSelectingEventArgs e)
{
    e.InputParameters["startRowIndex"] = 0;
    e.InputParameters["maximumRows"] = 5;
}