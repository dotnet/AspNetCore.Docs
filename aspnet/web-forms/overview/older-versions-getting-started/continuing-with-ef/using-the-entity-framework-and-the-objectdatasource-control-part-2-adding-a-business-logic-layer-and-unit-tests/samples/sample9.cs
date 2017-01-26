public void InsertDepartment(Department department)
{
	ValidateOneAdministratorAssignmentPerInstructor(department);
	try
	...

public void UpdateDepartment(Department department, Department origDepartment)
{
	ValidateOneAdministratorAssignmentPerInstructor(department);
	try
	...