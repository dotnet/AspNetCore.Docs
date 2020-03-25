using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesContacts.Data;
using RazorPagesContacts.Models;
using System.Threading.Tasks;

namespace RazorPagesContacts.Pages.Customers
{
    #region snippet_PageModel
    public class Create2Model : PageModel
    {
        private readonly CustomerDbContext _context;

        public Create2Model(CustomerDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public Customer Customer { get; set; }

        #region snippet_OnPostAsync
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Customers.Add(Customer);
            await _context.SaveChangesAsync();
            Message = $"Customer {Customer.Name} added";
            return RedirectToPage("./IndexPeek2");
        }
        #endregion
    }
    #endregion
}
