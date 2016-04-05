using Microsoft.AspNet.Mvc.Rendering;
using System.Collections.Generic;

public class CountryViewModel
{
    public string Country { get; set; }

    public List<SelectListItem> Countries { get; } = new List<SelectListItem>
    {
        new SelectListItem { Value = "MX", Text = "Mexico" },
        new SelectListItem { Value = "CA", Text = "Canada" },
        new SelectListItem { Value = "US", Text = "USA"  },
    };
}