Support for ASP.NET Core Identity was added to your project
- The code for adding Identity to your project was generated under Areas/Identity.

Configuration of the Identity related services can be found in the Areas/Identity/IdentityHostingStartup.cs file.

If your app was previously configured to use Identity, then you should remove the call to the AddIdentity method from your ConfigureServices method.

The generated UI requires support for static files. To add static files to your app:
1. Call app.UseStaticFiles() from your Configure method

To use ASP.NET Core Identity you also need to enable authentication. To add authentication to your app:
1. Call app.UseAuthentication() from your Configure method (after static files)

The generated UI requires MVC. To add MVC to your app:
1. Call services.AddMvc() from your ConfigureServices method
2. Call app.UseMvc() from your Configure method (after authentication)

The generated database code requires Entity Framework Core Migrations. Run the following commands:
1. dotnet ef migrations add CreateIdentitySchema
2. dotnet ef database update
 Or from the Visual Studio Package Manager Console:
1. Add-Migration CreateIdentitySchema
2. Update-Database

Apps that use ASP.NET Core Identity should also use HTTPS. To enable HTTPS see https://go.microsoft.com/fwlink/?linkid=848054.

