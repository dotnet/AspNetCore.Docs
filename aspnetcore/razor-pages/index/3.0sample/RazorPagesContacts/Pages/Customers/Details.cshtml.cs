using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesContacts.Data;
using RazorPagesContacts.Models;
using System.Threading.Tasks;

namespace RazorPagesContacts.Pages.Customers
{
    public class DetailsModel : PageModel
    {
        private readonly CustomerDbContext _context;

        public DetailsModel(CustomerDbContext context)
        {
            _context = context;
        }

        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            // Sample code to test RedirectToPage
            if (id > 4)
            {
                switch (id)
                {
                    case 5:
                        return RedirectToPage("/Index");
                    case 6:
                        return RedirectToPage("./Index");
                    case 7:
                        return RedirectToPage("../Index");
                    default:
                        return RedirectToPage("Index");
                }
            }

            Customer = await _context.Customers.FindAsync(id);

            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
