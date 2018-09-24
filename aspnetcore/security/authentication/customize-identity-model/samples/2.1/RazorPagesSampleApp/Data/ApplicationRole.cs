namespace RazorPagesSampleApp.Data
{
    #region snippet_ApplicationRole
    using System;
    using Microsoft.AspNetCore.Identity;

    public class ApplicationRole : IdentityRole<Guid>
    {
    }
    #endregion
}
