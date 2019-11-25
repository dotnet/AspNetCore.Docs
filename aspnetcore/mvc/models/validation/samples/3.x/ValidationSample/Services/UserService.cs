using System;
using System.Collections.Generic;

namespace ValidationSample.Services
{
    public class UserService : IUserService
    {
        private readonly HashSet<string> _emailAddresses = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        private readonly HashSet<Name> _names = new HashSet<Name>();

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

        private struct Name
        {
            public Name(string firstName, string lastName)
            {
                FirstName = firstName;
                LastName = lastName;
            }

            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}
