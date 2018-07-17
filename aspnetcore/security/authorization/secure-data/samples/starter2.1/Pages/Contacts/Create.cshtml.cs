using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ContactManager.Data;
using ContactManager.Models;

namespace ContactManager.Pages.Contacts
{
    public class CreateModel : PageModel
    {
        private readonly ContactManager.Data.ApplicationDbContext _context;

        public CreateModel(ContactManager.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            Contact = new Contact
            {
                Name = "Rick",
                Address = "123 N 456 S",
                City = "GF",
                State = "MT",
                Zip = "59405",
                Email = "rick@rick.com"
            };
            return Page();
        }

        [BindProperty]
        public Contact Contact { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Contact.Add(Contact);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}