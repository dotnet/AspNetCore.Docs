using ModelBindingSample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace ModelBindingSample.Pages.Instructors
{
    #region snippet_BindProperties
    [BindProperties(SupportsGet=true)]
    public class CreateModel : InstructorsPageModel
    {
        public CreateModel() : base()
        {
        }

        public Instructor Instructor { get; set; }
        #endregion

        public IActionResult OnGet()
        {
            return Page();
        }

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
