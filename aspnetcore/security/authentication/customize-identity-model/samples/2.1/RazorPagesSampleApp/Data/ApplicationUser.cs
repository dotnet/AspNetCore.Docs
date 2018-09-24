namespace RazorPagesSampleApp.Data
{
    #region snippet_ApplicationUser
    using System;
    using Microsoft.AspNetCore.Identity;
    
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string CustomTag { get; set; }
    }
    #endregion
}
