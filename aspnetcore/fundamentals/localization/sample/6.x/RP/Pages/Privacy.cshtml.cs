using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace RP.Pages;
public class PrivacyModel : PageModel
{
    [BindProperty]
    public InputModel Input { get; set; } = null!;

    public void OnGet()
    {
    }
    public IActionResult OnPost()
    {
        if (ModelState.IsValid)
        {
            return LocalRedirect("/");
        }
        return Page();
    }
}

public class InputModel
{
    [Required(ErrorMessage = "Required")]
    [MinLength(3, ErrorMessage = "{1} characters or more")]
    [Display(Prompt = "Username", Name = "Your Username")]
    public string UserName { get; set; } = null!;
}