
using Microsoft.AspNet.Mvc.Rendering;
using System.Collections.Generic;

namespace FormsTH.ViewModels
{
    public class CountryViewModelIEnumerable
    {
        public IEnumerable<string> CountryCodes { get; set; }
    
    public List<SelectListItem> Countrys { get; private set; }
        public CountryViewModelIEnumerable()
        {

            Countrys = new List<SelectListItem>
        {
                new SelectListItem
            {
                Value = "MX",
                Text = "Mexico"
            },
            new SelectListItem
            {
                Value = "CA",
                Text = "Canada"
            },
            new SelectListItem
            {
                Value = "US",
                Text = "USA"
            },
            new SelectListItem
            {
                Value = "FR",
                Text = "France"
            },
            new SelectListItem
            {
                Value = "ES",
                Text = "Spain"
            },
            new SelectListItem
            {
                Value = "DE",
                Text = "Germany"
            }
        };
        }
    }
}
