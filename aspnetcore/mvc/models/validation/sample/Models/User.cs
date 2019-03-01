using Microsoft.AspNetCore.Mvc;

namespace ValidationSample.Models
{
    public class User
    {
        #region snippet_UserEmailProperty
        [Remote(action: "VerifyEmail", controller: "Users")]
        public string Email { get; set; }
        #endregion

        #region snippet_UserNameProperties
        [Remote(action: "VerifyName", controller: "Users", AdditionalFields = nameof(LastName))]
        public string FirstName { get; set; }
        [Remote(action: "VerifyName", controller: "Users", AdditionalFields = nameof(FirstName))]
        public string LastName { get; set; }
        #endregion

        [Remote(action: "VerifyPhone", controller: "Users")]
        public string Phone { get; set; }

        public int Age { get; set; }
    }
}
