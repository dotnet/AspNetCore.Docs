using Microsoft.AspNet.Mvc.Rendering;
using System.Collections.Generic;

namespace FormsTH.ViewModels
{
    public class CountryViewModel
    {
        public string Country { get; set; }

        public List<SelectListItem> Countrys { get; private set; }

        public CountryViewModel()
        {

            Countrys = new List<SelectListItem>
              {
            new SelectListItem {Value = "MX", Text = "Mexico" },
            new SelectListItem {Value = "CA", Text = "Canada" },
            new SelectListItem {Value = "US", Text = "USA"    }
              };
        }
    }
}
