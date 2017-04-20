private void ValidateOneAdministratorAssignmentPerInstructor(Department department)
{
	if (department.Administrator != null)
	{
		var duplicateDepartment = schoolRepository.GetDepartmentsByAdministrator(department.Administrator.GetValueOrDefault()).FirstOrDefault();
		if (duplicateDepartment != null && duplicateDepartment.DepartmentID != department.DepartmentID)
		{
			throw new DuplicateAdministratorException(String.Format(
				"Instructor {0} {1} is already administrator of the {2} department.", 
				duplicateDepartment.Person.FirstMidName, 
				duplicateDepartment.Person.LastName, 
				duplicateDepartment.Name));
		}
	}
}