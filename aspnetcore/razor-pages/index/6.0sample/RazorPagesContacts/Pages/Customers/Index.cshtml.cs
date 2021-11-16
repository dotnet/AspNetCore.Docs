using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesContacts.Models;
#pragma warning disable CS8618

namespace RazorPagesContacts.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly Data.CustomerDbContext _context;
        public IndexModel(Data.CustomerDbContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; }

        public async Task OnGetAsync()
        {
            Customer = await _context.Customer.ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var contact = await _context.Customer.FindAsync(id);

            if (contact != null)
            {
                _context.Customer.Remove(contact);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
#pragma warning restore CS8618
