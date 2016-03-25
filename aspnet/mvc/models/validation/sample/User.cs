using Microsoft.AspNet.Mvc;
using System;

namespace MVCMovie.Models
{
    public class User : IUserRepository
    {
        public int Id { get; set; }

        [Remote(action: "VerifyEmail", controller: "Users")]
        public string Email { get; set; }
        public string FullName { get; set; }
        public bool VerifyEmail()
        {
            throw new NotImplementedException();
        }
        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}

