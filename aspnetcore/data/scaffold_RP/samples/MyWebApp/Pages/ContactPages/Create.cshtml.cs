using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWebApp;

namespace MyWebApp.Pages.ContactPages;

public class CreateModel : PageModel
{
    private readonly ContactDbContext _context;

    public CreateModel(ContactDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public Contact Contact { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Contact.Add(Contact);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
