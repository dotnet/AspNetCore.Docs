public IEnumerable<Department> GetDepartments(string sortExpression)
{
	return GetDepartmentsByName(sortExpression, "");
}