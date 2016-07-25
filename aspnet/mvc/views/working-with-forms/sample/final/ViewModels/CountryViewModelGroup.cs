using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace FormsTagHelper.ViewModels
{
    public class CountryViewModelGroup
    {
        public CountryViewModelGroup()
        {
            var NorthAmericaGroup = new SelectListGroup { Name = "North America" };
            var EuropeGroup = new SelectListGroup { Name = "Europe" };

            Countries = new List<SelectListItem>
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

        public string Country { get; set; }

        public List<SelectListItem> Countries { get; }
    }
}