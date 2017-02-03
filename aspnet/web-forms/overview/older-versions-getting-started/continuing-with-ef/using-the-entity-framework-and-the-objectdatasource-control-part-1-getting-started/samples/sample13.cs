public void UpdateDepartment(Department department, Department origDepartment)
{
	try
	{
		context.Departments.Attach(origDepartment);
		context.ApplyCurrentValues("Departments", department);
		context.SaveChanges();
	}
	catch (Exception ex)
	{
		//Include catch blocks for specific exceptions first,
		//and handle or log the error as appropriate in each.
		//Include a generic catch block like this one last.
		throw ex;
	}
}