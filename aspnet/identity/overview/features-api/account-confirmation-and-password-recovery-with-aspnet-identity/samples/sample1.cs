//     Default EntityFramework IUser implementation
public class IdentityUser<TKey, TLogin, TRole, TClaim> : IUser<TKey>
   where TLogin : IdentityUserLogin<TKey>
   where TRole : IdentityUserRole<TKey>
   where TClaim : IdentityUserClaim<TKey>
{
   public IdentityUser()
   {
      Claims = new List<TClaim>();
      Roles = new List<TRole>();
      Logins = new List<TLogin>();
   }

   ///     User ID (Primary Key)
   public virtual TKey Id { get; set; }

   public virtual string Email { get; set; }
   public virtual bool EmailConfirmed { get; set; }

   public virtual string PasswordHash { get; set; }

   ///     A random value that should change whenever a users credentials have changed (password changed, login removed)
   public virtual string SecurityStamp { get; set; }

   public virtual string PhoneNumber { get; set; }
   public virtual bool PhoneNumberConfirmed { get; set; }

   public virtual bool TwoFactorEnabled { get; set; }

   ///     DateTime in UTC when lockout ends, any time in the past is considered not locked out.
   public virtual DateTime? LockoutEndDateUtc { get; set; }

   public virtual bool LockoutEnabled { get; set; }

   ///     Used to record failures for the purposes of lockout
   public virtual int AccessFailedCount { get; set; }
   
   ///     Navigation property for user roles
   public virtual ICollection<TRole> Roles { get; private set; }

   ///     Navigation property for user claims
   public virtual ICollection<TClaim> Claims { get; private set; }

   ///     Navigation property for user logins
   public virtual ICollection<TLogin> Logins { get; private set; }
   
   public virtual string UserName { get; set; }
}