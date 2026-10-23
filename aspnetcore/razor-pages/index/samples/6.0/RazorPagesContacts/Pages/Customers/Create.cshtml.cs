using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesContacts.Models;

namespace RazorPagesContacts.Pages.Customers
{
    // <snippet_PageModel>
    public class CreateModel : PageModel
    {
        private readonly Data.CustomerDbContext _context;

        public CreateModel(Data.CustomerDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        // <snippet_OnPostAsync>
        [BindProperty]
        public Customer? Customer { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Customer != null) _context.Customer.Add(Customer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        // </snippet_OnPostAsync>
    }
    // </snippet_PageModel>
}
