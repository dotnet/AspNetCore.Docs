using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MvcSampleApp.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string CustomTag { get; set; }        
    }
}
