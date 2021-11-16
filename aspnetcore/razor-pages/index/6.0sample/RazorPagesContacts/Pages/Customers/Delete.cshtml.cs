using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesContacts.Data;
using RazorPagesContacts.Models;

namespace RazorPagesContacts.Pages.Customers
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesContacts.Data.CustomerDbContext _context;
#pragma warning disable CS8618
        public DeleteModel(RazorPagesContacts.Data.CustomerDbContext context)
        {
            _context = context;
        }
#pragma warning disable CS8618

        [BindProperty]
        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
#pragma warning disable CS8601
            Customer = await _context.Customer.FirstOrDefaultAsync(m => m.Id == id);
#pragma warning restore CS8601
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
#pragma warning disable CS8601 // Possible null reference assignment.
            Customer = await _context.Customer.FindAsync(id);
#pragma warning restore CS8601 // Possible null reference assignment.
            if (Customer != null)
            {
                _context.Customer.Remove(Customer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
