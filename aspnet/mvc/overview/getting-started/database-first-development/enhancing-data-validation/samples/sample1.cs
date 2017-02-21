namespace ContosoSite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Student
    {
        public Student()
        {
            this.Enrollments = new HashSet<Enrollment>();
        }
    
        public int StudentID { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        public Nullable<System.DateTime> EnrollmentDate { get; set; }
        [StringLength(50)]
        public string MiddleName { get; set; }
    
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}