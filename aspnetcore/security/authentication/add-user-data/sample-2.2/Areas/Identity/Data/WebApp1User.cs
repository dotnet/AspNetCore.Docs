using Microsoft.AspNetCore.Identity;
using System;

namespace WebApp1.Areas.Identity.Data
{
    public class WebApp1User : IdentityUser
    {
        [PersonalData]
        public string Name { get; set; }
        [PersonalData]
        public DateTime DOB { get; set; }
    }
}