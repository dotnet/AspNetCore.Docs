using DisplayTemplatesTest.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DisplayTemplatesTest.Pages;

public class IndexModel : PageModel
{
    public Person Person { get; set; } =
        new Person
        {
            Name = "Niklas",
            Age = 17
        };
}