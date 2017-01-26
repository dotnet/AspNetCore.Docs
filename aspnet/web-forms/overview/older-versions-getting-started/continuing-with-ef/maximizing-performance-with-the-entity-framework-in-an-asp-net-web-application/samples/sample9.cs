public IEnumerable<Department> GetDepartmentsByAdministrator(Int32 administrator)
{
	context.Departments.MergeOption = MergeOption.NoTracking;
	return (from d in context.Departments where d.Administrator == administrator select d).ToList();
}