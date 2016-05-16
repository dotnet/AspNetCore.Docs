using System.ComponentModel.DataAnnotations;

namespace DependencyInjectionSample.ViewModels.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
