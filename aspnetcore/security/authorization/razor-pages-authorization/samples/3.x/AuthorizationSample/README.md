# ASP.NET Core Authorization Sample

This sample illustrates use of Razor Pages authorization by conventions. This sample demonstrates the features described in the [Razor Pages authorization conventions](https://learn.microsoft.com/aspnet/core/security/authorization/razor-pages-authorization) topic.

User authorization in this sample uses the cookie authentication features described in the [Use cookie authentication without ASP.NET Core Identity](https://learn.microsoft.com/aspnet/core/security/authentication/cookie) topic. The concepts and examples shown in this topic apply equally to apps that use ASP.NET Core Identity. For information on using ASP.NET Core Identity, see [Introduction to Identity on ASP.NET Core](https://learn.microsoft.com/aspnet/core/security/authentication/identity).

Use the email address **maria.rodriguez@contoso.com** to authenticate the user with any password. The user is authenticated in the `AuthenticateUser` method in the `Pages/Account/Login.cshtml.cs` file. In a real-world example, the user would be authenticated against a database.

## Examples in this sample

| Feature | Description |
| --- | --- |
| [AuthorizePage](https://learn.microsoft.com/dotnet/api/microsoft.extensions.dependencyinjection.pageconventioncollectionextensions.authorizepage) | Adds an [AuthorizeFilter](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.mvc.authorization.authorizefilter) to the page with the specified path. |
| [AuthorizeFolder](https://learn.microsoft.com/dotnet/api/microsoft.extensions.dependencyinjection.pageconventioncollectionextensions.authorizefolder) | Adds an [AuthorizeFilter](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.mvc.authorization.authorizefilter) to all of the pages in a folder with the specified path. |
| [AllowAnonymousToPage](https://learn.microsoft.com/dotnet/api/microsoft.extensions.dependencyinjection.pageconventioncollectionextensions.allowanonymoustopage) | Adds an [AllowAnonymousFilter](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.mvc.authorization.allowanonymousfilter) to a page with the specified path. |
| [AllowAnonymousToFolder](https://learn.microsoft.com/dotnet/api/microsoft.extensions.dependencyinjection.pageconventioncollectionextensions.allowanonymoustofolder) | Adds an [AllowAnonymousFilter](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.mvc.authorization.allowanonymousfilter) to all of the pages in a folder with the specified path. |
