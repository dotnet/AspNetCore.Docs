namespace ValidationSample.Services
{
    public class UserService : IUserService
    {
        private readonly HashSet<string> _emailAddresses = new(StringComparer.OrdinalIgnoreCase);
        private readonly HashSet<Name> _names = new();

        public bool VerifyEmail(string email)
        {
            // For demonstration purposes, an email is unique if it hasn't been added before.
            return _emailAddresses.Add(email);
        }

        public bool VerifyName(string firstName, string lastName)
        {
            // For demonstration purposes, a name is unique if it hasn't been added before.
            return _names.Add(new Name(firstName, lastName));
        }

        private record Name(string FirstName, string LastName);
    }
}
