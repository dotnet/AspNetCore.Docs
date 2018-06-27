using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesContacts.Data;

namespace RazorPagesContacts.Pages.Customers
{
#region snippet_Temp
    public class CreateDotModel : PageModel
    {
        private readonly AppDbContext _db;

        public CreateDotModel(AppDbContext db)
        {
            _db = db;
        }

        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public Customer Customer { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Customers.Add(Customer);
            await _db.SaveChangesAsync();
            Message = $"Customer {Customer.Name} added";
            return RedirectToPage("./Index");
        }
    }
#endregion
}