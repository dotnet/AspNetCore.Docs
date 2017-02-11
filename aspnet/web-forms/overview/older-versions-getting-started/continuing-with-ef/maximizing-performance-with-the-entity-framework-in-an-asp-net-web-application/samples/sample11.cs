public IEnumerable<InstructorName> GetInstructorNames()
{
	return context.CompiledInstructorNamesQuery();
}