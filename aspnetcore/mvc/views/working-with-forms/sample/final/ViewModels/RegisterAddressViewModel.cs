using System.ComponentModel.DataAnnotations;

namespace FormsTagHelper.ViewModels
{ 
    public class RegisterAddressViewModel
    {
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public AddressViewModel Address { get; set; }
    }
}

