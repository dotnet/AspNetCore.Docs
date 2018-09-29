using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MvcSampleApp.Models
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public string Description { get; set; }
    }
}
