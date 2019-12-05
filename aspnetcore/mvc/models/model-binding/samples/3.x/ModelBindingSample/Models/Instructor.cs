using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ModelBindingSample.Models
{
    public class Instructor
    {
        [BindNever]
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [BindRequired]
        [DataType(DataType.Date)]
        [Display(Name = "Date Hired")]
        public DateTime DateHired { get; set; }
    }
}
