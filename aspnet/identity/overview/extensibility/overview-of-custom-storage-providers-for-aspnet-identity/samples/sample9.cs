public void ConfigureAuth(IAppBuilder app)
{
    app.CreatePerOwinContext(ExampleStorageContext.Create);
    app.CreatePerOwinContext(ApplicationUserManager.Create);
    ...