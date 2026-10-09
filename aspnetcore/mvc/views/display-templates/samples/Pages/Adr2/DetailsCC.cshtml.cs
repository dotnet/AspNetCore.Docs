using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAddress.Pages.Adr2
{
    public class DetailsCCModel : PageModel
    {
        private readonly WebAddress.Data.WebAddressContext _context;

        public DetailsCCModel(WebAddress.Data.WebAddressContext context)
        {
            _context = context;
        }

        public Address Address { get; set; } = default!;

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
    }
}
