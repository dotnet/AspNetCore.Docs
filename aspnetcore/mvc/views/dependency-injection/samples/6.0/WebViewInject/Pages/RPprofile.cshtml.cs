using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ViewInjectSample.Model;

namespace WebViewInject.Pages;

public class RPprofileModel : PageModel
{

    [BindProperty(SupportsGet = true)]
    public Profile? MyProfile { get; set; }

    public void OnGet()
    {
        MyProfile = new Profile()
        {
            Name = "Rick",
            FavColor = "Blue",
            Gender = "Male",
            State = new State("Ohio", "OH")
        };
    }
}
