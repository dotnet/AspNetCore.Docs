using Microsoft.AspNetCore.Mvc;
using ViewInjectSample.Model;

namespace ViewInjectSample.Controllers;

public class ProfileController : Controller
{
    public IActionResult Index()
    {
        // A real app would up profile based on the user.
        var profile = new Profile()
        {
            Name = "Rick",
            FavColor = "Blue",
            Gender = "Male",
            State = new State("Ohio","OH")
        };
        return View(profile);
    }
}
