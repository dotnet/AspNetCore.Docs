using ContactManager.Data;
using ContactManager.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Pages.Contacts
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public IndexModel(ApplicationDbContext context)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _context = context;
        }

        public IList<Contact> Contact { get;set; }

        public async Task OnGetAsync()
        {
            Contact = await _context.Contact.ToListAsync();
        }
    }
}
