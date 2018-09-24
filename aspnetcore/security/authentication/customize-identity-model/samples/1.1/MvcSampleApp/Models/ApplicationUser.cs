namespace MvcSampleApp.Models
{
    #region snippet_ApplicationUser
    using System;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public string CustomTag { get; set; }        
    }
    #endregion
}
