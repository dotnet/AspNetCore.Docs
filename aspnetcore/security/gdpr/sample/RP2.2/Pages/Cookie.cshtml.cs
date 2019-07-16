using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Net.Http.Headers;
using System;

namespace RPCC.Pages
{
    public class Cookie : PageModel
    {
        [TempData]
        public string ResponseCookies { get; set; }

        public void OnGet()
        {
        }

        #region snippet1
        public IActionResult OnPostCreateEssentialAsync()
        {
            HttpContext.Response.Cookies.Append(Constants.EssentialSec, 
                DateTime.Now.Second.ToString(), 
                new CookieOptions() { IsEssential = true });

            ResponseCookies = Response.Headers[HeaderNames.SetCookie].ToString();

            return RedirectToPage("./Index");
        }
        #endregion

        public IActionResult OnPostCreateAsync()
        {
            HttpContext.Response.Cookies.Append(Constants.NonEssentialMS, 
                DateTime.Now.Millisecond.ToString());

            ResponseCookies = Response.Headers[HeaderNames.SetCookie].ToString();

            return RedirectToPage("./Index");
        }

        public IActionResult OnPostDeleteAsync()
        {
            HttpContext.Response.Cookies.Delete(Constants.NonEssentialMS);
            HttpContext.Response.Cookies.Delete(Constants.EssentialSec);

            return RedirectToPage("./Index");
        }

        public IActionResult OnPostDeleteAllAsync()
        {

            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }

            return RedirectToPage("./Index");
        }
    }
}
