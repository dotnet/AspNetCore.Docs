using System;
using System.Collections.Generic;

namespace MVCMovie.Controllers
{
    public class UserRepository : IUserRepository
    {
        private readonly HashSet<string> _emailAddresses = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        public bool VerifyEmail(string email)
        {
            // In real world, adding a new email address would be a separate step. This would be a contains check.
            return _emailAddresses.Add(email);
        }
    }
}
