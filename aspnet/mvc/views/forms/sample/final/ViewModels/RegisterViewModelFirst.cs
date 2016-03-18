//#define first
#if first

using System.ComponentModel.DataAnnotations;

namespace FormsTH.ViewModels
{
    public class RegisterViewModel
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}

#endif