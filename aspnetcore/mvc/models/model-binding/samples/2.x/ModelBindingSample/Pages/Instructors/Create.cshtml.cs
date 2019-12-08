using ModelBindingSample.Models;
using Microsoft.AspNetCore.Mvc;

namespace ModelBindingSample.Pages.Instructors
{
    #region snippet_BindProperties
    [BindProperties(SupportsGet = true)]
    public class CreateModel : InstructorsPageModel
    {
        public Instructor Instructor { get; set; }
        #endregion

        #region snippet_HandleMBError
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _instructorsInMemoryStore.Add(Instructor);
            return RedirectToPage("./Index");
        }
        #endregion
    }
}
