public IEnumerable<Department> GetDepartmentsByName(string sortExpression, string nameSearchString)
{
	...
	var departments = new ObjectQuery<Department>("SELECT VALUE d FROM Departments AS d", context).OrderBy("it." + sortExpression).Where(d => d.Name.Contains(nameSearchString)).ToList();
	foreach (Department d in departments)
	{
		d.Courses.Load();
		d.PersonReference.Load();
	}
	return departments;
}