using ModelBindingSample.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ModelBindingSample.Pages.Instructors
{
    public class IndexModel : InstructorsPageModel
    {
        // <snippet_SupportsGet>
        [BindProperty(Name = "ai_user", SupportsGet = true)]
        public string ApplicationInsightsCookie { get; set; }
        // </snippet_SupportsGet>

        public List<Instructor> Instructors { get; set; }

        // <snippet_FromHeader>
        public void OnGet([FromHeader(Name = "Accept-Language")] string language)
        // </snippet_FromHeader>
        {
            Instructors = _instructorsInMemoryStore;
            ViewData["Language"] = language;
        }
    }
}
