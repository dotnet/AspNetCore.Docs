public IEnumerable<OfficeAssignment> GetOfficeAssignments(string sortExpression)
{
	return new ObjectQuery<OfficeAssignment>("SELECT VALUE o FROM OfficeAssignments AS o", context).Include("Person").OrderBy("it." + sortExpression).ToList();
}

public void InsertOfficeAssignment(OfficeAssignment officeAssignment)
{
	context.OfficeAssignments.AddObject(officeAssignment);
	context.SaveChanges();
}

public void DeleteOfficeAssignment(OfficeAssignment officeAssignment)
{
	context.OfficeAssignments.Attach(officeAssignment);
	context.OfficeAssignments.DeleteObject(officeAssignment);
	context.SaveChanges();
}

public void UpdateOfficeAssignment(OfficeAssignment officeAssignment, OfficeAssignment origOfficeAssignment)
{
	context.OfficeAssignments.Attach(origOfficeAssignment);
	context.ApplyCurrentValues("OfficeAssignments", officeAssignment);
	SaveChanges();
}