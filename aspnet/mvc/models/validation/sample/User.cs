using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCMovie.Models
{
    public class User
    {
        public int Id { get; set; }

        [Remote(action: "VerifyEmail", controller: "Users")]
        public string Email { get; set; }
        public string FullName { get; set; }

    }
}
