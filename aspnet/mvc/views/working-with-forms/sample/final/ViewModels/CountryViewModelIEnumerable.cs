using Microsoft.AspNet.Mvc.Rendering;
using System.Collections.Generic;

public class CountryViewModelIEnumerable
{
    public IEnumerable<string> CountryCodes { get; set; }

    public List<SelectListItem> Countries { get; } = new List<SelectListItem>
    {
        new SelectListItem { Value = "MX", Text = "Mexico" },
        new SelectListItem { Value = "CA", Text = "Canada" },
        new SelectListItem { Value = "US", Text = "USA"    },
        new SelectListItem { Value = "FR", Text = "France" },
        new SelectListItem { Value = "ES", Text = "Spain"  },
        new SelectListItem { Value = "DE", Text = "Germany"}
     };
}

