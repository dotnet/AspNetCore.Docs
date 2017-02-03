using System;
using System.ComponentModel.DataAnnotations;

namespace ContosoSite.Models
{
    public class StudentMetadata
    {
        [StringLength(50)]
        [Display(Name="Last Name")]
        public string LastName;

        [StringLength(50)]
        [Display(Name="First Name")]
        public string FirstName;

        [StringLength(50)]
        [Display(Name="Middle Name")]
        public string MiddleName;

        [Display(Name = "Enrollment Date")]
        public Nullable<System.DateTime> EnrollmentDate;
    }

    public class EnrollmentMetadata
    {
        [Range(0, 4)]
        public Nullable<decimal> Grade;
    }
}