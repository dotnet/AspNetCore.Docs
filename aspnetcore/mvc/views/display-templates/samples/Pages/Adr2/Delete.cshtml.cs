using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAddress.Data;

namespace WebAddress.Pages.Adr2
{
    public class DeleteModel : PageModel
    {
        private readonly WebAddress.Data.WebAddressContext _context;

        public DeleteModel(WebAddress.Data.WebAddressContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Address Address { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Address == null)
            {
                return NotFound();
            }

            var address = await _context.Address.FirstOrDefaultAsync(m => m.Id == id);

            if (address == null)
            {
                return NotFound();
            }
            else 
            {
                Address = address;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Address == null)
            {
                return NotFound();
            }
            var address = await _context.Address.FindAsync(id);

            if (address != null)
            {
                Address = address;
                _context.Address.Remove(Address);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
