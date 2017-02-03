public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context) 
{
    var manager = new ApplicationUserManager(new UserStore(context.Get<ExampleStorageContext>()));
    ...
}