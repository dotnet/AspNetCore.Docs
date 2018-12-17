using System;
using Microsoft.AspNetCore.Identity;

namespace RazorPagesSampleApp.Data
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string CustomTag { get; set; }        
    }
}
