using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWebApp;

namespace MyWebApp.Pages.ContactPages;

public class DetailsModel : PageModel
{
    private readonly ContactDbContext _context;
    public DetailsModel(ContactDbContext context)
    {
        _context = context;
    }

    public Contact Contact { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var contact = await _context.Contact.FirstOrDefaultAsync(m => m.Id == id);
        if (contact is null)
        {
            return NotFound();
        }
        else
        {
            Contact = contact;
        }

        return Page();
    }
}
