using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAddress.Data;

namespace WebAddress.Pages.Adr2
{
    public class CreateModel : PageModel
    {
        private readonly WebAddress.Data.WebAddressContext _context;

        public CreateModel(WebAddress.Data.WebAddressContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            Address = new Address
            {
                FirstName = "Rick",
                MiddleName = "M.",
                LastName = "Anderson",
                Street = "123 N 456 W",
                City = "Seattle",
                State = "WA",
                Zipcode = "98009"
            };
            return Page();
        }

        [BindProperty]
        public Address Address { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Address == null || Address == null)
            {
                return Page();
            }

            _context.Address.Add(Address);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
