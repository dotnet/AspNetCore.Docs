public IEnumerable<InstructorName> GetInstructorNames()
{
	return (from i in context.InstructorNames orderby i.FullName select i).ToList();
}