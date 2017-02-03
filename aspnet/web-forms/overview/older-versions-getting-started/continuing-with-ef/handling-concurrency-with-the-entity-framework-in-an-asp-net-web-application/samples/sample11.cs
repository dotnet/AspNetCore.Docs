List<OfficeAssignment> officeAssignments = new List<OfficeAssignment>();
        
public IEnumerable<OfficeAssignment> GetOfficeAssignments(string sortExpression)
{
	return officeAssignments;
}

public void InsertOfficeAssignment(OfficeAssignment officeAssignment)
{
	officeAssignments.Add(officeAssignment);
}

public void DeleteOfficeAssignment(OfficeAssignment officeAssignment)
{
	officeAssignments.Remove(officeAssignment);
}

public void UpdateOfficeAssignment(OfficeAssignment officeAssignment, OfficeAssignment origOfficeAssignment)
{
	officeAssignments.Remove(origOfficeAssignment);
	officeAssignments.Add(officeAssignment);
}