using ModelBindingSample.Models;
using ModelBindingSample.Models.SchoolViewModels;  // Add VM
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ModelBindingSample.Pages.Instructors
{
    public class IndexModel : InstructorsPageModel
    {
        public IndexModel() : base()
        {
        }

        public List<Course> SelectedInstructorCourses;

        public List<Instructor> Instructors { get; set; }

        public void OnGet(string ai_user)
        {
            Instructors = _instructorsInMemoryStore;
            ViewData["CustomValueProvider"] = ai_user; 
        }
    }
}
