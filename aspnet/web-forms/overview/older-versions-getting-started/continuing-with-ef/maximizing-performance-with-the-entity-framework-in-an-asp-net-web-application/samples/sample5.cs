public SchoolRepository()
{
	context.Departments.MergeOption = MergeOption.NoTracking;
	context.InstructorNames.MergeOption = MergeOption.NoTracking;
	context.OfficeAssignments.MergeOption = MergeOption.NoTracking;
}