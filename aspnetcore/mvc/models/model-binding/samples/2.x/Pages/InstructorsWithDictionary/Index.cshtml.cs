using ModelBindingSample.Models;
using ModelBindingSample.Models.SchoolViewModels;  // Add VM
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ModelBindingSample.Pages.InstructorsWithCollectionWithDictionary
{
    public class IndexModel : InstructorsPageModel
    {
        public IndexModel() : base()
        {
        }

        public Dictionary<int, string> SelectedInstructorCourses;

        public List<InstructorWithDictionary> Instructors { get; set; }
        public int InstructorID { get; set; }
        public int CourseID { get; set; }

        public void OnGet(int? id, int? courseID)
        {
            Instructors = _instructorsInMemoryStore;

            if (id != null)
            {
                InstructorID = id.Value;
                SelectedInstructorCourses = _instructorsInMemoryStore.Single(i => i.ID == InstructorID).Courses;
            }
        }
    }
}
