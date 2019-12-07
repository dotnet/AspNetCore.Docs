using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ModelBindingSample.Models
{
    public class Instructor
    {
        #region snippet_BindNever
        [BindNever]
        public int Id { get; set; }
        #endregion

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Hired")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        #region snippet_BindRequired
        [BindRequired]
        public DateTime DateHired { get; set; }
        #endregion

        [BindNever]
        public List<InstructorCourse> InstructorCourses { get; set; } = new List<InstructorCourse>();
    }
}
