public class Student
{
    [Key, Display(Name = "ID")]
    [ScaffoldColumn(false)]
    public int StudentID { get; set; }

    [Required, StringLength(40), Display(Name="Last Name")]
    public string LastName { get; set; }

    [Required, StringLength(20), Display(Name = "First Name")]
    public string FirstName { get; set; }

    [EnumDataType(typeof(YearEnum)), Display(Name = "Academic Year")]
    public YearEnum AcademicYear { get; set; }

    [Range(typeof(DateTime), "1/1/2013", "1/1/3000", ErrorMessage="Please provide an enrollment date after 1/1/2013")]
    [DisplayFormat(ApplyFormatInEditMode=true, DataFormatString="{0:d}")]
    public DateTime EnrollmentDate { get; set; }

    public virtual ICollection Enrollments { get; set; }
}