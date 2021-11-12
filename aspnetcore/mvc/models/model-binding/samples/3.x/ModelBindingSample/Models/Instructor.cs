using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace ModelBindingSample.Models
{
    // <snippet_FromQuery>
    public class Instructor
    {
        public int ID { get; set; }

        [FromQuery(Name = "Note")]
        public string NoteFromQueryString { get; set; }
        // </snippet_FromQuery>
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "First Name")]
        public string FirstMidName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hire Date")]
        public DateTime? HireDate { get; set; }

        public OfficeAssignment OfficeAssignment { get; set; }
    }
}
