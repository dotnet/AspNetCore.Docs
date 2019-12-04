using System;
using System.Collections.Generic;

namespace ValidationSample.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly HashSet<string> _emailAddresses = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        private readonly HashSet<Person> _persons = new HashSet<Person>();

        public bool VerifyEmail(string email)
        {
            // In real world, adding a new email address would be a separate step. This would be a contains check.
            return _emailAddresses.Add(email);
        }

        public bool VerifyName(string firstName, string lastName)
        {
            // In real world, adding a new person would be a separate step. This would be a contains check.
            return _persons.Add(new Person()
            {
                FirstName = firstName,
                LastName = lastName
            });
        }

        private struct Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}
