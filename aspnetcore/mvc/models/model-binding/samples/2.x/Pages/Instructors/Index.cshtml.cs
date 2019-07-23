using ModelBindingSample.Models;
using ModelBindingSample.Models.SchoolViewModels;  // Add VM
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ModelBindingSample.Pages.Instructors
{
    public class IndexModel : InstructorsPageModel
    {
        public IndexModel() : base()
        {
        }

        #region snippet_SupportsGet
        [BindProperty(Name ="ai_user", SupportsGet = true)]
        public string ApplicationInsightsCookie { get; set; }
        #endregion

        public List<Course> SelectedInstructorCourses;

        public List<Instructor> Instructors { get; set; }

        #region snippet_FromHeader
        public void OnGet([FromHeader(Name="Accept-Language")] string language)
        #endregion
        {
            Instructors = _instructorsInMemoryStore;
            ViewData["Language"] = language;
        }
    }
}
