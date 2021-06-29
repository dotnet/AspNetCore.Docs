# ASP.NET Core Authorization Sample

This sample illustrates use of Razor Pages authorization by conventions. This sample demonstrates the features described in the [Razor Pages authorization conventions](../../../../razor-pages-authorization.md) topic.

User authorization in this sample uses the cookie authentication features described in the [Use cookie authentication without ASP.NET Core Identity](../../../../../authentication/cookie.md) topic. The concepts and examples shown in this topic apply equally to apps that use ASP.NET Core Identity. For information on using ASP.NET Core Identity, see [Introduction to Identity on ASP.NET Core](../../../../../authentication/identity.md).

Use the email address **maria.rodriguez@contoso.com** to authenticate the user with any password. The user is authenticated in the `AuthenticateUser` method in the *Pages/Account/Login.cshtml.cs* file. In a real-world example, the user would be authenticated against a database.

## Examples in this sample

| Feature | Description |
| --- | --- |
| [AuthorizePage](/dotnet/api/microsoft.extensions.dependencyinjection.pageconventioncollectionextensions.authorizepage) | Adds an [AuthorizeFilter](/dotnet/api/microsoft.aspnetcore.mvc.authorization.authorizefilter) to the page with the specified path. |
| [AuthorizeFolder](/dotnet/api/microsoft.extensions.dependencyinjection.pageconventioncollectionextensions.authorizefolder) | Adds an [AuthorizeFilter](/dotnet/api/microsoft.aspnetcore.mvc.authorization.authorizefilter) to all of the pages in a folder with the specified path. |
| [AllowAnonymousToPage](/dotnet/api/microsoft.extensions.dependencyinjection.pageconventioncollectionextensions.allowanonymoustopage) | Adds an [AllowAnonymousFilter](/dotnet/api/microsoft.aspnetcore.mvc.authorization.allowanonymousfilter) to a page with the specified path. |
| [AllowAnonymousToFolder](/dotnet/api/microsoft.extensions.dependencyinjection.pageconventioncollectionextensions.allowanonymoustofolder) | Adds an [AllowAnonymousFilter](/dotnet/api/microsoft.aspnetcore.mvc.authorization.allowanonymousfilter) to all of the pages in a folder with the specified path. |