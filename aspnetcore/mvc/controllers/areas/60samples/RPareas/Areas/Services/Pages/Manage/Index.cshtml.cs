using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RPareas.Areas.Services.Pages.Manage;

public class IndexModel : PageModel
{
    public ContentResult OnGet() =>
     Content(PageContext.ToCtxStringP());
}
