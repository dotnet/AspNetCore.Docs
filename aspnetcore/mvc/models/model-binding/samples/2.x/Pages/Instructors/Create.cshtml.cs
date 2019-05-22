using ModelBindingSample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace ModelBindingSample.Pages.Instructors
{
    public class CreateModel : InstructorsPageModel
    {
        public CreateModel() : base()
        {
        }

        public IActionResult OnGet()
        {
            Instructor = new Instructor();
            return Page();
        }

        [BindProperty]
        public Instructor Instructor { get; set; }

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
    public class Names
    {
        public string LastName { get; set; }
    }
}
