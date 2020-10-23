using ModelBindingSample.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ModelBindingSample.Pages.Instructors
{
    public class IndexModel : InstructorsPageModel
    {
        #region snippet_SupportsGet
        [BindProperty(Name = "ai_user", SupportsGet = true)]
        public string ApplicationInsightsCookie { get; set; }
        #endregion

        public List<Instructor> Instructors { get; set; }

        #region snippet_FromHeader
        public void OnGet([FromHeader(Name = "Accept-Language")] string language)
        #endregion
        {
            Instructors = _instructorsInMemoryStore;
            ViewData["Language"] = language;
        }
    }
}
