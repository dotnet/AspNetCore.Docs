public IEnumerable<Department> GetDepartmentsByName(string sortExpression, string nameSearchString)
{
	...
	var departments = new ObjectQuery<Department>("SELECT VALUE d FROM Departments AS d", context).OrderBy("it." + sortExpression).Include("Person").Include("Courses").Where(d => d.Name.Contains(nameSearchString));
	string commandText = ((ObjectQuery)departments).ToTraceString();
	return departments.ToList();
}