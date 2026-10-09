using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesContacts.Models;

namespace RazorPagesContacts.Pages.Customers
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesContacts.Data.CustomerDbContext _context;
        public DetailsModel(RazorPagesContacts.Data.CustomerDbContext context)
        {
            _context = context;
        }

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
    }
}
