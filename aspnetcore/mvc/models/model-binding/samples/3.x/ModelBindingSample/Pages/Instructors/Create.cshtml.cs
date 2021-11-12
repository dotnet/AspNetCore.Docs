using ModelBindingSample.Models;
using Microsoft.AspNetCore.Mvc;

namespace ModelBindingSample.Pages.Instructors
{
    // <snippet_BindProperties>
    [BindProperties(SupportsGet = true)]
    public class CreateModel : InstructorsPageModel
    {
        public Instructor Instructor { get; set; }
        // </snippet_BindProperties>

        // <snippet_HandleMBError>
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _instructorsInMemoryStore.Add(Instructor);
            return RedirectToPage("./Index");
        }
        // </snippet_HandleMBError>
    }
}
