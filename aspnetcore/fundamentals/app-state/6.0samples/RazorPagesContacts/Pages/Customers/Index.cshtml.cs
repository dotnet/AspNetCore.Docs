using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesContacts.Models;

namespace RazorPagesContacts.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesContacts.Data.RazorPagesContactsContext _context;

        public IndexModel(RazorPagesContacts.Data.RazorPagesContactsContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; }

        public async Task OnGetAsync()
        {
            Customer = await _context.Customer.ToListAsync();
        }
    }
}
