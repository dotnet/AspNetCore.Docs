private void ValidateOneAdministratorAssignmentPerInstructor(Department department)
{
    if (department.PersonID != null)
    {
        var duplicateDepartment = db.Departments
            .Include("Administrator")
            .Where(d => d.PersonID == department.PersonID)
            .FirstOrDefault();
        if (duplicateDepartment != null && duplicateDepartment.DepartmentID != department.DepartmentID)
        {
            var errorMessage = String.Format(
                "Instructor {0} {1} is already administrator of the {2} department.",
                duplicateDepartment.Administrator.FirstMidName,
                duplicateDepartment.Administrator.LastName,
                duplicateDepartment.Name);
            ModelState.AddModelError(string.Empty, errorMessage);
        }
    }
}