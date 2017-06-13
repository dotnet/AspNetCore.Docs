using System;
using System.Security.Claims;

namespace CustomIdentityProviderSample.CustomProvider
{
    public class ApplicationUser : ClaimsIdentity
    {
        public virtual System.Guid Id { get; set; } = Guid.NewGuid();
        public virtual string UserName { get; set; }
        public virtual string Email { get; set; }
        public virtual bool EmailConfirmed { get; set; }
        public virtual String PasswordHash { get; set; }
        public string NormalizedUserName { get; internal set; }
    }
}
