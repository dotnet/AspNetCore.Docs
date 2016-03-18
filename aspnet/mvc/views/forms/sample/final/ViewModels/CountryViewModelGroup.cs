using Microsoft.AspNet.Mvc.Rendering;
using System.Collections.Generic;

namespace FormsTH.ViewModels
{
    public class CountryViewModelGroup
    {
        public string Country { get; set; }

        public List<SelectListItem> Countrys { get; private set; }
        public CountryViewModelGroup()
        {
            var NorthAmericaGroup = new SelectListGroup { Name = "North America" };
            var EuropeGroup = new SelectListGroup { Name = "Europe" };

            Countrys = new List<SelectListItem>
        {
                new SelectListItem
            {
                Value = "MEX",
                Text = "Mexico",
                Group = NorthAmericaGroup
            },
            new SelectListItem
            {
                Value = "CAN",
                Text = "Canada",
                Group = NorthAmericaGroup
            },
            new SelectListItem
            {
                Value = "US",
                Text = "USA",
                Group = NorthAmericaGroup
            },
            new SelectListItem
            {
                Value = "FR",
                Text = "France",
                Group = EuropeGroup
            },
            new SelectListItem
            {
                Value = "ES",
                Text = "Spain",
                Group = EuropeGroup
            },
            new SelectListItem
            {
                Value = "DE",
                Text = "Germany",
                Group = EuropeGroup
            }
        };
        }
    }
}