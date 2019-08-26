using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesContacts.Data;
using RazorPagesContacts.Model;

namespace RazorPagesContacts.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesContacts.Data.CustomerDbContext _context;

        public IndexModel(RazorPagesContacts.Data.CustomerDbContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; }

        public async Task OnGetAsync()
        {
            Customer = await _context.Customers.ToListAsync();
        }
    }
}
