using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ValidationSample.Models
{
    public class User
    {
        #region snippet_Email
        [Remote(action: "VerifyEmail", controller: "Users")]
        public string Email { get; set; }
        #endregion

        #region snippet_Name
        [Remote(action: "VerifyName", controller: "Users", AdditionalFields = nameof(LastName))]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Remote(action: "VerifyName", controller: "Users", AdditionalFields = nameof(FirstName))]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        #endregion

        [Remote(action: "VerifyPhone", controller: "Users")]
        public string Phone { get; set; }

        public int Age { get; set; }
    }
}
