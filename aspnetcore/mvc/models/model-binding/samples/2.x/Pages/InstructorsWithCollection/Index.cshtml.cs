using ModelBindingSample.Models;
using ModelBindingSample.Models.SchoolViewModels;  // Add VM
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ModelBindingSample.Pages.InstructorsWithCollection
{
    public class IndexModel : InstructorsPageModel
    {
        public IndexModel() : base()
        {
        }

        public List<Course> SelectedInstructorCourses;

        public List<InstructorWithCollection> Instructors { get; set; }

        public void OnGet(int? id, int? courseID)
        {
            Instructors = _instructorsInMemoryStore;
        }
    }
}
