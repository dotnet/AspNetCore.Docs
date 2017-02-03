public IEnumerable<Department> GetDepartmentsByName(string sortExpression, string nameSearchString)
{
	if (String.IsNullOrWhiteSpace(sortExpression))
	{
		sortExpression = "Name";
	}
	if (String.IsNullOrWhiteSpace(nameSearchString))
	{
		nameSearchString = "";
	}
	return context.Departments.Include("Person").OrderBy("it." + sortExpression).Where(d => d.Name.Contains(nameSearchString)).ToList();
}