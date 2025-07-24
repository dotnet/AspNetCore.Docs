using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ModelBindingSample.Snippets.Pages;

public class IndexModel : PageModel
{
    // <snippet_SupportsGet>
    [BindProperty(Name = "ai_user", SupportsGet = true)]
    public string? ApplicationInsightsCookie { get; set; }
    // </snippet_SupportsGet>

    // <snippet_FromHeader>
    public void OnGet([FromHeader(Name = "Accept-Language")] string language)
    // </snippet_FromHeader>
    {

    }

    // <snippet_ModelStateInvalid>
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // ...

        return RedirectToPage("./Index");
    }
    // </snippet_ModelStateInvalid>

    public async Task<IActionResult> OnPostAsync()
    {
        var newInstructor = new InstructorExtended();
        var _instructorStore = new List<InstructorExtended>();

        // <snippet_TryUpdateModelAsync>
        if (await TryUpdateModelAsync(
            newInstructor,
            "Instructor",
            x => x.Name, x => x.HireDate!))
        {
            _instructorStore.Add(newInstructor);
            return RedirectToPage("./Index");
        }

        return Page();
        // </snippet_TryUpdateModelAsync>
    }

    public class InstructorExtended
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public DateTime HireDate { get; set; }
    }
}
