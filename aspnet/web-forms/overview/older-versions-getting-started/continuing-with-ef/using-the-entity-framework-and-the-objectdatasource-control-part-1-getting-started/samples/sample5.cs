protected void Page_Init(object sender, EventArgs e)
{
    DepartmentsGridView.EnableDynamicData(typeof(Department));
}