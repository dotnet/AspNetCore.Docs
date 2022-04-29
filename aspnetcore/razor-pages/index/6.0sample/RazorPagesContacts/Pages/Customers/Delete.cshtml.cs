using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesContacts.Models;

namespace RazorPagesContacts.Pages.Customers
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesContacts.Data.CustomerDbContext _context;
        public DeleteModel(RazorPagesContacts.Data.CustomerDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Customer? Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _context.Customer.FirstOrDefaultAsync(m => m.Id == id);

            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _context.Customer.FindAsync(id);
            
            if (Customer != null)
            {
                _context.Customer.Remove(Customer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
