using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using PolymorphicModelBindingSample.ModelBinders;

namespace PolymorphicModelBindingSample.Pages
{
    public class AddDeviceModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public AddDeviceModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public List<SelectListItem> DeviceKinds { get; } = new List<SelectListItem>
        {
            new SelectListItem { Text = "Laptop", },
            new SelectListItem { Text = "SmartPhone" },
            new SelectListItem { Text = "Tablet" },
        };

        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public Device Device { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            switch (Device)
            {
                case Laptop laptop:
                    Message = $"You added a Laptop with a CPU Index of {laptop.CPUIndex}.";
                    break;

                case SmartPhone smartPhone:
                    Message = $"You added a SmartPhone with a Screen Size of {smartPhone.ScreenSize}.";
                    break;
            }

            return RedirectToPage("/Index");
        }
    }
}
