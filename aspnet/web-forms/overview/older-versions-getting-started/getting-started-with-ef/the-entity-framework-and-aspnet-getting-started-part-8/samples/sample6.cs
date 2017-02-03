using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.DAL
{
    [MetadataType(typeof(StudentMetadata))]
    public partial class Student
    {
    }

    public class StudentMetadata
    {
        [DisplayFormat(DataFormatString="{0:d}", ApplyFormatInEditMode=true)]
        public DateTime EnrollmentDate { get; set; }

        [StringLength(25, ErrorMessage = "First name must be 25 characters or less in length.")]
        [Required(ErrorMessage="First name is required.")]
        public String FirstMidName { get; set; }

        [StringLength(25, ErrorMessage = "Last name must be 25 characters or less in length.")]
        [Required(ErrorMessage = "Last name is required.")]
        public String LastName { get; set; }
    }
}