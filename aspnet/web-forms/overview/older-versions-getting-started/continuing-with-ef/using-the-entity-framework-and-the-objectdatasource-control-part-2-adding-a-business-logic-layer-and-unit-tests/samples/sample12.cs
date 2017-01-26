public IEnumerable<Department> GetDepartmentsByAdministrator(Int32 administrator)
{
	return new ObjectQuery<Department>("SELECT VALUE d FROM Departments as d", context, MergeOption.NoTracking).Include("Person").Where(d => d.Administrator == administrator).ToList();
}