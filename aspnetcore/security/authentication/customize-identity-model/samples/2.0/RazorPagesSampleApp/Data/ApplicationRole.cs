using System;
using Microsoft.AspNetCore.Identity;

namespace RazorPagesSampleApp.Data
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public string Description { get; set; }
    }
}
