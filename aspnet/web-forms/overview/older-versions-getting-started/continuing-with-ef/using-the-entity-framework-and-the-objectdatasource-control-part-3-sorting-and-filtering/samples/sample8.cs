public IEnumerable<Department> GetDepartments(string sortExpression)
{
	return schoolRepository.GetDepartments(sortExpression);
}