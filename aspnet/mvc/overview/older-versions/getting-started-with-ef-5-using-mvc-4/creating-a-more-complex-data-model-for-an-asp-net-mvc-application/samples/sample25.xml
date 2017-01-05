using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
   public class Student
   {
      public int StudentID { get; set; }

      [StringLength(50, MinimumLength = 1)]
      public string LastName { get; set; }

      [StringLength(50, MinimumLength = 1, ErrorMessage = "First name cannot be longer than 50 characters.")]
      [Column("FirstName")]
      public string FirstMidName { get; set; }

      [DataType(DataType.Date)]
      [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
      [Display(Name = "Enrollment Date")]
      public DateTime EnrollmentDate { get; set; }

      public string FullName
      {
         get { return LastName + ", " + FirstMidName; }
      }

      public virtual ICollection<Enrollment> Enrollments { get; set; }
   }
}