using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesContacts.Data;
using RazorPagesContacts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RazorPagesContacts.Pages.Customers
{
    #region snippet
    public class IndexModel : PageModel
    {
        private readonly CustomerDbContext _context;

        public IndexModel(CustomerDbContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get; set; }

        public async Task OnGetAsync()
        {
            Customer = await _context.Customers.ToListAsync();
        }

        #region snippet2
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var contact = await _context.Customers.FindAsync(id);

            if (contact != null)
            {
                _context.Customers.Remove(contact);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
        #endregion
    }
    #endregion
}
