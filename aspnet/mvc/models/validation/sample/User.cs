using Microsoft.AspNet.Mvc;
using System;

namespace MVCMovie.Models
{
    public class UserRepository : IUserRepository
    {
        [Remote(action: "VerifyEmail", controller: "Users")]
        public string Email { get; set; }

        public bool VerifyEmail()
        {
            // in the real world this would actually verify the email
            throw new NotImplementedException();
        }
    }
}

