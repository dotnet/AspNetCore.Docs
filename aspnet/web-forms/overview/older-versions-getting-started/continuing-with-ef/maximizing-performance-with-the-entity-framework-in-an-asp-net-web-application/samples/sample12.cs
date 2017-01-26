public IEnumerable<Department> GetDepartmentsByAdministrator(Int32 administrator)
{
	return context.CompiledDepartmentsByAdministratorQuery(administrator);
}