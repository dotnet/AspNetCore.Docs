using System;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesSample.Pages
{
    public class ContactModel : PageModel
    {
        public string Message { get; set; }

        public bool IsWeekend
        {
            get
            {
                var dayOfWeek = DateTime.Now.DayOfWeek;

                return dayOfWeek == DayOfWeek.Saturday ||
                       dayOfWeek == DayOfWeek.Sunday;
            }
        }

        public void OnGet()
        {
            Message = "Your contact page.";
        }
    }
}
