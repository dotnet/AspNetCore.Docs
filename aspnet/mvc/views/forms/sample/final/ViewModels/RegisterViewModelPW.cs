// define PW
#if PW

using System.ComponentModel.DataAnnotations;

namespace FormsTH.ViewModels
{
    public class RegisterViewModel
    {
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

#endif