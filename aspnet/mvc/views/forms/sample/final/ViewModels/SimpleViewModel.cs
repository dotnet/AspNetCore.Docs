using System.ComponentModel.DataAnnotations;
public class SimpleViewModel
{
    [Required]
    [EmailAddress]
    [Display(Name = "Email Address")]
    public string Email { get; set; }
}

