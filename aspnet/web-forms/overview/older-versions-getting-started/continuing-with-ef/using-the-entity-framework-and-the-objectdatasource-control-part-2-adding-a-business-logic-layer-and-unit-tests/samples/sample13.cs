public IEnumerable<Department> GetDepartmentsByAdministrator(Int32 administrator)
{
	return (from d in departments
			where d.Administrator == administrator
			select d);
}