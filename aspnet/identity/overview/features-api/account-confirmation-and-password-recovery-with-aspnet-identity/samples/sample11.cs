if (dataProtectionProvider != null)
 {
    manager.UserTokenProvider =
       new DataProtectorTokenProvider<ApplicationUser>
          (dataProtectionProvider.Create("ASP.NET Identity"))
          {                    
             TokenLifespan = TimeSpan.FromHours(3)
          };
 }