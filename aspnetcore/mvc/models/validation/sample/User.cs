using Microsoft.AspNetCore.Mvc;

namespace MVCMovie.Models
{
    public class User
    {
        [Remote(action: "VerifyEmail", controller: "Users")]
        public string Email { get; set; }
    }
}
