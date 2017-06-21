public IEnumerable<Department> GetDepartments(string sortExpression)
{
	if (String.IsNullOrWhiteSpace(sortExpression))
	{
		sortExpression = "Name";
	}
	return context.Departments.Include("Person").OrderBy("it." + sortExpression).ToList();
}