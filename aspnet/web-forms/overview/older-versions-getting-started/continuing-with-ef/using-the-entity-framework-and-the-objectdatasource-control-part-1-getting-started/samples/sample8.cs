public IEnumerable<InstructorName> GetInstructorNames()
{
    return context.InstructorNames.OrderBy("it.FullName").ToList();
}