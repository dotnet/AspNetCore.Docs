using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesContacts.Data;
using RazorPagesContacts.Model;

namespace RazorPagesContacts.Pages.Customers
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesContacts.Data.CustomerDbContext _context;

        public CreateModel(RazorPagesContacts.Data.CustomerDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            Customer = new Customer { Name = "Joe Smith" };
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Customers.Add(Customer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}