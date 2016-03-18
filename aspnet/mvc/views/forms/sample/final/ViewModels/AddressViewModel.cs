
namespace FormsTH.ViewModels
{
    public class AddressViewModel
    {
        public string AddressLine1 { get; set; }
    }

    public class RegisterViewModel2
    {
        public string Email { get; set; }

        public string Password { get; set; }
        public AddressViewModel Address { get; set; }
    }
}

