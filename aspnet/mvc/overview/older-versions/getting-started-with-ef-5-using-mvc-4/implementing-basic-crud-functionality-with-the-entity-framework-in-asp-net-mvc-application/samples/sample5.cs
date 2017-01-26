public class Student
{
	public int StudentID { get; set; }
	public string LastName { get; set; }
	public string FirstMidName { get; set; }
	public DateTime EnrollmentDate { get; set; }
	public string Secret { get; set; }

	public virtual ICollection<Enrollment> Enrollments { get; set; }
}