var students = from s in studentRepository.GetStudents()
                select s;
if (!String.IsNullOrEmpty(searchString))
{
	students = students.Where(s => s.LastName.ToUpper().Contains(searchString.ToUpper())
						|| s.FirstMidName.ToUpper().Contains(searchString.ToUpper()));
}