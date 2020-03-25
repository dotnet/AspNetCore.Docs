using ModelBindingSample.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;

namespace ModelBindingSample.Pages.InstructorsWithDictionary
{
    public class InstructorsPageModel : PageModel
    {
        protected static List<InstructorWithDictionary> _instructorsInMemoryStore = new List<InstructorWithDictionary>();

        public InstructorsPageModel()
        {
            if (_instructorsInMemoryStore.Count == 0)
            {
                InitializeInstructors();
            }
        }

        private void InitializeInstructors()
        {
            var courseList = new Dictionary<string, string>();
            courseList["1050"] = "Chemistry";
            courseList["4022"] = "Microeconomics";
            courseList["4041"] = "Macroeconomics";

            _instructorsInMemoryStore.Add(new InstructorWithDictionary
            {
                ID = 1,
                FirstMidName = "Kim",
                LastName = "Abercrombie",
                HireDate = DateTime.Parse("1995-03-11"),
                Courses = courseList
            });

            _instructorsInMemoryStore.Add(new InstructorWithDictionary
            {
                ID = 2,
                FirstMidName = "Fadi",
                LastName = "Fakhouri",
                HireDate = DateTime.Parse("2002-07-06"),
                Courses = new Dictionary<string, string>()
            });

            courseList = new Dictionary<string, string>();
            courseList["3141"] = "Trigonometry";
            courseList["2021"] = "Composition";
            courseList["2042"] = "Literature";

            _instructorsInMemoryStore.Add(new InstructorWithDictionary
            {
                ID = 3,
                FirstMidName = "Roger",
                LastName = "Harui",
                HireDate = DateTime.Parse("1998-07-01"),
                Courses = courseList
            });
        }
    }
}
