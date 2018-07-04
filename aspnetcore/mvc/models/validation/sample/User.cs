using Microsoft.AspNetCore.Mvc;

namespace MVCMovie.Models
{
    public class User
    {
        [Remote(action: "VerifyEmail", controller: "Users")]
        public string Email { get; set; }

        [Remote(action: "VerifyName", controller: "Users", AdditionalFields = nameof(LastName))]
        public string FirstName { get; set; }
        [Remote(action: "VerifyName", controller: "Users", AdditionalFields = nameof(FirstName))]
        public string LastName { get; set; }
    }
}
