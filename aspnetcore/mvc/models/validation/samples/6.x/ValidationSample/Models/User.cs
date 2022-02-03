using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ValidationSample.Models;

public class User
{
    // <snippet_Email>
    [Remote(action: "VerifyEmail", controller: "Users")]
    public string Email { get; set; } = null!;
    // </snippet_Email>

    // <snippet_Name>
    [Remote(action: "VerifyName", controller: "Users", AdditionalFields = nameof(LastName))]
    [Display(Name = "First Name")]
    public string FirstName { get; set; } = null!;

    [Remote(action: "VerifyName", controller: "Users", AdditionalFields = nameof(FirstName))]
    [Display(Name = "Last Name")]
    public string LastName { get; set; } = null!;
    // </snippet_Name>

    [Remote(action: "VerifyPhone", controller: "Users")]
    public string Phone { get; set; } = null!;

    public int Age { get; set; }
}
