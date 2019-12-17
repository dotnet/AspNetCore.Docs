using ModelBindingSample.Models;
using System.Collections.Generic;

namespace ModelBindingSample.Pages.InstructorsWithCollection
{
    public class IndexModel : InstructorsPageModel
    {
        public IndexModel() : base()
        {
        }

        public List<InstructorWithCollection> Instructors { get; set; }

        public void OnGet()
        {
            Instructors = _instructorsInMemoryStore;
        }
    }
}
