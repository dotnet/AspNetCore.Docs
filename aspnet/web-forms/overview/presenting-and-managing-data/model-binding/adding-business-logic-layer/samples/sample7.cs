protected void coursesGrid_CallingDataMethods(object sender, CallingDataMethodsEventArgs e)
{
    e.DataMethodsObject = new ContosoUniversityModelBinding.BLL.SchoolBL();
}