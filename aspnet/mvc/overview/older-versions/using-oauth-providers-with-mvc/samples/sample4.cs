public class RegisterExternalLoginModel
{
    [Required]
    [Display(Name = "User name")]
    public string UserName { get; set; }

    public string ExternalLoginData { get; set; }

    [Display(Name = "Full name")]
    public string FullName { get; set; }

    [Display(Name = "Personal page link")]
    public string Link { get; set; }
}