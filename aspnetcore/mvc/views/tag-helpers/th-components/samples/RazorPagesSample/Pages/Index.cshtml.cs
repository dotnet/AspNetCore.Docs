namespace RazorPagesSample.Pages
{
    #region snippet_IndexModelClass
    using System;
    using Microsoft.AspNetCore.Mvc.Razor.TagHelpers;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using RazorPagesSample.TagHelpers;

    public class IndexModel : PageModel
    {
        private readonly ITagHelperComponentManager _tagHelperComponentManager;

        public bool IsWeekend
        {
            get
            {
                var dayOfWeek = DateTime.Now.DayOfWeek;

                return dayOfWeek == DayOfWeek.Saturday ||
                       dayOfWeek == DayOfWeek.Sunday;
            }
        }

        public IndexModel(ITagHelperComponentManager tagHelperComponentManager)
        {
            _tagHelperComponentManager = tagHelperComponentManager;
        }

        public void OnGet()
        {
            string markup;

            if (IsWeekend)
            {
                markup = "<em class='text-warning'>Office closed today!</em>";
            }
            else
            {
                markup = "<em class='text-info'>Office open today!</em>";
            }

            _tagHelperComponentManager.Components.Add(
                new AddressTagHelperComponent(markup, 1));
        }
    }
    #endregion
}
