namespace RazorPagesSampleApp.Data
{
    #region snippet_ApplicationRole
    using System;
    using Microsoft.AspNetCore.Identity;

    public class ApplicationRole : IdentityRole<Guid>
    {
        public string Description { get; set; }
    }
    #endregion
}
