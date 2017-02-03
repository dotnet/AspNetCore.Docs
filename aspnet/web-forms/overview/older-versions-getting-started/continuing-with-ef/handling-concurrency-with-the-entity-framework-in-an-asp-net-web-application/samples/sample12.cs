public IEnumerable<OfficeAssignment> GetOfficeAssignments(string sortExpression)
{
	if (string.IsNullOrEmpty(sortExpression)) sortExpression = "Person.LastName";
	return schoolRepository.GetOfficeAssignments(sortExpression);
}

public void InsertOfficeAssignment(OfficeAssignment officeAssignment)
{
	try
	{
		schoolRepository.InsertOfficeAssignment(officeAssignment);
	}
	catch (Exception ex)
	{
		//Include catch blocks for specific exceptions first,
		//and handle or log the error as appropriate in each.
		//Include a generic catch block like this one last.
		throw ex;
	}
}

public void DeleteOfficeAssignment(OfficeAssignment officeAssignment)
{
	try
	{
		schoolRepository.DeleteOfficeAssignment(officeAssignment);
	}
	catch (Exception ex)
	{
		//Include catch blocks for specific exceptions first,
		//and handle or log the error as appropriate in each.
		//Include a generic catch block like this one last.
		throw ex;
	}
}

public void UpdateOfficeAssignment(OfficeAssignment officeAssignment, OfficeAssignment origOfficeAssignment)
{
	try
	{
		schoolRepository.UpdateOfficeAssignment(officeAssignment, origOfficeAssignment);
	}
	catch (Exception ex)
	{
		//Include catch blocks for specific exceptions first,
		//and handle or log the error as appropriate in each.
		//Include a generic catch block like this one last.
		throw ex;
	}
}