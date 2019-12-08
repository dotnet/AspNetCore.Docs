using ModelBindingSample.Models;
using System.Collections.Generic;

namespace ModelBindingSample.Pages.InstructorsWithDictionary
{
    public class IndexModel : InstructorsPageModel
    {
        public List<InstructorWithDictionary> Instructors { get; set; }

        public void OnGet()
        {
            Instructors = _instructorsInMemoryStore;
        }
    }
}
