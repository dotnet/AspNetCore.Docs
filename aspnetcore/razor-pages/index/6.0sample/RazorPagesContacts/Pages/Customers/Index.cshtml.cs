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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesContacts.Data.CustomerDbContext _context;
#pragma warning disable CS8618
        public IndexModel(RazorPagesContacts.Data.CustomerDbContext context)
        {
            _context = context;
        }
#pragma warning restore CS8618

        public IList<Customer> Customer { get;set; }

        public async Task OnGetAsync()
        {
            Customer = await _context.Customer.ToListAsync();
        }
    }
}
