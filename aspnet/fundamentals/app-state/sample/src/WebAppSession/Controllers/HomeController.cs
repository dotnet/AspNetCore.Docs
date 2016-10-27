using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;

namespace WebAppSession.Controllers
{
    #region snippet_1
    public class HomeController : Controller
    {
        const string sessionKeyName = "Rick";
        const string sessionKeyYearsMember = "YearsMember";
        const string sessionKeyDate = "Date";

        public IActionResult Index()
        {
            var name = HttpContext.Session.GetString(sessionKeyName);
            var yearsMember = HttpContext.Session.GetInt32(sessionKeyYearsMember);

            return Content($"Name: \"{name}\",  Membership years: \"{yearsMember}\"");
        }

        public IActionResult About()
        {
            // add using Microsoft.AspNetCore.Http;
            HttpContext.Session.SetString(sessionKeyName, "Rick");
            HttpContext.Session.SetInt32(sessionKeyYearsMember, 3);
            return View();

        }
        #endregion

        public IActionResult SetDate()
        {
            HttpContext.Session.Set<DateTime>(sessionKeyDate, DateTime.Now);
            return Content("Setting DateTime in session");
        }

        public IActionResult GetDate()
        {
            var date = HttpContext.Session.Get<DateTime>(sessionKeyDate);
            var sessionTime = date.TimeOfDay.ToString();
            var currentTime = DateTime.Now.TimeOfDay.ToString();

            return Content($"Current time: {currentTime} - "
                         + $"session time: {sessionTime}");
        }
    }
}
