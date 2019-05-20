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

        public Dictionary<string, string> SelectedInstructorCourses;

        public List<InstructorWithDictionary> Instructors { get; set; }

        public void OnGet()
        {
            Instructors = _instructorsInMemoryStore;
        }
    }
}
