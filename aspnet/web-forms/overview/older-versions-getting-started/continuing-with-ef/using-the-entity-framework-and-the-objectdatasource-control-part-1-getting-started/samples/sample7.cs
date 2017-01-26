public void InsertDepartment(Department department)
{
	try
	{
		department.DepartmentID = GenerateDepartmentID();
		context.Departments.AddObject(department);
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

public void DeleteDepartment(Department department)
{
	try
	{
		context.Departments.Attach(department);
		context.Departments.DeleteObject(department);
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

private Int32 GenerateDepartmentID()
{
	Int32 maxDepartmentID = 0;
	var department = (from d in GetDepartments()
					  orderby d.DepartmentID descending
					  select d).FirstOrDefault();
	if (department != null)
	{
		maxDepartmentID = department.DepartmentID + 1;
	}
	return maxDepartmentID;
}