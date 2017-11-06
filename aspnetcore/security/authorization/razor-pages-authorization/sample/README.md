# ASP.NET Core Authorization Sample

This sample illustrates use of Razor Pages authorization by conventions. This sample demonstrates the features described in the [Razor Pages authorization conventions](https://docs.microsoft.com/aspnet/core/security/authorization/razor-pages-authorization) topic.

User authorization in this sample uses the cookie authentication features described in the [Using Cookie Authentication without ASP.NET Core Identity](https://docs.microsoft.com/aspnet/core/security/authentication/cookie) topic. For information on using ASP.NET Core Identity, see the topics in the [Authentication](https://docs.microsoft.com/aspnet/core/security/authentication/index) section of the documentation.

When running the sample, use the email address **maria.rodriguez@contoso.com** to authenticate the user.

## Examples in this sample

| Feature | Description |
| ------- | ----------- |
| [AuthorizePage](https://docs.microsoft.com/dotnet/api/microsoft.extensions.dependencyinjection.pageconventioncollectionextensions.authorizepage) | Adds an [AuthorizeFilter](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.mvc.authorization.authorizefilter) to the page with the specified path. |
| [AuthorizeFolder](https://docs.microsoft.com/dotnet/api/microsoft.extensions.dependencyinjection.pageconventioncollectionextensions.authorizefolder) | Adds an [AuthorizeFilter](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.mvc.authorization.authorizefilter) to all of the pages in a folder with the specified path. |
| [AllowAnonymousToPage](https://docs.microsoft.com/dotnet/api/microsoft.extensions.dependencyinjection.pageconventioncollectionextensions.allowanonymoustopage) | Adds an [AllowAnonymousFilter](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.mvc.authorization.allowanonymousfilter) to a page with the specified path. |
| [AllowAnonymousToFolder](https://docs.microsoft.com/dotnet/api/microsoft.extensions.dependencyinjection.pageconventioncollectionextensions.allowanonymoustofolder) | Adds an [AllowAnonymousFilter](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.mvc.authorization.allowanonymousfilter) to all of the pages in a folder with the specified path. |
