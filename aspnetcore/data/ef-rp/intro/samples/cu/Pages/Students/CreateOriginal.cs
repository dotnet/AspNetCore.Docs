//#define NEVER

#if NEVER
using ContosoUniversity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace ContosoUniversity.Pages.Students
{
public class CreateModel : PageModel
{
    private readonly ContosoUniversity.Data.SchoolContext _context;

    public CreateModel(ContosoUniversity.Data.SchoolContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public Student Student { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Students.Add(Student);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
}
#endif