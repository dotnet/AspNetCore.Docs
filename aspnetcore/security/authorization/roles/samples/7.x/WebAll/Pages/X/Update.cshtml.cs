using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAll.Pages
{
    #region snippet
    [Authorize(Policy = "RequireAdministratorRole")]
    public class UpdateModel : PageModel
    {
        public IActionResult OnPost() =>
             Content("OnPost RequireAdministratorRole");
    }
    #endregion
}
