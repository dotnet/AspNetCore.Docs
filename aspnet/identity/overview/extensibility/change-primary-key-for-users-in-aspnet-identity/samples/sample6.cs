public class ApplicationUserManager : UserManager<ApplicationUser, int> 
{ 
    public ApplicationUserManager(IUserStore<ApplicationUser, int> store) 
        : base(store) 
    { 
    } 

    public static ApplicationUserManager Create(
        IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)  
    { 
        var manager = new ApplicationUserManager(
            new CustomUserStore(context.Get<ApplicationDbContext>())); 
        // Configure validation logic for usernames 
        manager.UserValidator = new UserValidator<ApplicationUser, int>(manager) 
        { 
            AllowOnlyAlphanumericUserNames = false, 
            RequireUniqueEmail = true 
        }; 
        // Configure validation logic for passwords 
        manager.PasswordValidator = new PasswordValidator 
        { 
            RequiredLength = 6, 
            RequireNonLetterOrDigit = true, 
            RequireDigit = true, 
            RequireLowercase = true, 
            RequireUppercase = true, 
        }; 
        // Register two factor authentication providers. This application uses Phone 
        // and Emails as a step of receiving a code for verifying the user 
        // You can write your own provider and plug in here. 
        manager.RegisterTwoFactorProvider("PhoneCode", 
            new PhoneNumberTokenProvider<ApplicationUser, int> 
        { 
            MessageFormat = "Your security code is: {0}" 
        }); 
        manager.RegisterTwoFactorProvider("EmailCode", 
            new EmailTokenProvider<ApplicationUser, int> 
        { 
            Subject = "Security Code", 
            BodyFormat = "Your security code is: {0}" 
        }); 
        manager.EmailService = new EmailService(); 
        manager.SmsService = new SmsService(); 
        var dataProtectionProvider = options.DataProtectionProvider; 
        if (dataProtectionProvider != null) 
        { 
            manager.UserTokenProvider = 
                new DataProtectorTokenProvider<ApplicationUser, int>(
                    dataProtectionProvider.Create("ASP.NET Identity")); 
        } 
        return manager; 
    } 
}