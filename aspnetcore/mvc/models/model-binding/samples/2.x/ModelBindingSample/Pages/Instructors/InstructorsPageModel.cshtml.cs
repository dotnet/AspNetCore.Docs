using ModelBindingSample.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;

namespace ModelBindingSample.Pages.Instructors
{
    public class InstructorsPageModel : PageModel
    {
        protected static List<Instructor> _instructorsInMemoryStore = new List<Instructor>();

        public InstructorsPageModel()
        {
            if (_instructorsInMemoryStore.Count == 0)
            {
                InitializeInstructors();
            }
        }

        private void InitializeInstructors()
        {
            _instructorsInMemoryStore.Add(new Instructor
            {
                ID = 1,
                FirstMidName = "Kim",
                LastName = "Abercrombie",
                HireDate = DateTime.Parse("1995-03-11"),
                OfficeAssignment = new OfficeAssignment { Location = "Smith 17" }
            });
            _instructorsInMemoryStore.Add(new Instructor
            {
                ID = 2,
                FirstMidName = "Fadi",
                LastName = "Fakhouri",
                HireDate = DateTime.Parse("2002-07-06"),
                OfficeAssignment = new OfficeAssignment { Location = "Gowan 27" }
            });
            _instructorsInMemoryStore.Add(new Instructor
            {
                ID = 3,
                FirstMidName = "Roger",
                LastName = "Harui",
                HireDate = DateTime.Parse("1998-07-01"),
                OfficeAssignment = new OfficeAssignment { Location = "Thompson 304" }
            });
        }
    }
}
