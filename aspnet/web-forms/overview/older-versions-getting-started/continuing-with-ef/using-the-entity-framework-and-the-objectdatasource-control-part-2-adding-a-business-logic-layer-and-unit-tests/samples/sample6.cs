private SchoolBL CreateSchoolBL()
{
	var schoolRepository = new MockSchoolRepository();
	var schoolBL = new SchoolBL(schoolRepository);
	schoolBL.InsertDepartment(new Department() { Name = "First Department", DepartmentID = 0, Administrator = 1, Person = new Instructor () { FirstMidName = "Admin", LastName = "One" } });
	schoolBL.InsertDepartment(new Department() { Name = "Second Department", DepartmentID = 1, Administrator = 2, Person = new Instructor() { FirstMidName = "Admin", LastName = "Two" } });
	schoolBL.InsertDepartment(new Department() { Name = "Third Department", DepartmentID = 2, Administrator = 3, Person = new Instructor() { FirstMidName = "Admin", LastName = "Three" } });
	return schoolBL;
}

[TestMethod]
[ExpectedException(typeof(DuplicateAdministratorException))]
public void AdministratorAssignmentRestrictionOnInsert()
{
	var schoolBL = CreateSchoolBL();
	schoolBL.InsertDepartment(new Department() { Name = "Fourth Department", DepartmentID = 3, Administrator = 2, Person = new Instructor() { FirstMidName = "Admin", LastName = "Two" } });
}

[TestMethod]
[ExpectedException(typeof(DuplicateAdministratorException))]
public void AdministratorAssignmentRestrictionOnUpdate()
{
	var schoolBL = CreateSchoolBL();
	var origDepartment = (from d in schoolBL.GetDepartments()
						  where d.Name == "Second Department"
						  select d).First();
	var department = (from d in schoolBL.GetDepartments()
						  where d.Name == "Second Department"
						  select d).First();
	department.Administrator = 1;
	schoolBL.UpdateDepartment(department, origDepartment);
}