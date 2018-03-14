using System.ComponentModel.DataAnnotations;

namespace CookieAuthWithIdentityCore.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
