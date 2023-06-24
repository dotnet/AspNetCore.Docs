The `RedirectToLogin` component (`Shared/RedirectToLogin.razor`):

* Manages redirecting unauthorized users to the login page.
* The current URL that the user is attempting to access is maintained by so that they can be returned to that page if authentication is successful using:
  * [Navigation history state](xref:blazor/fundamentals/routing#navigation-history-state) in ASP.NET Core 7.0 or later.
  * A query string in ASP.NET Core 6.0 or earlier.

Inspect the `RedirectToLogin` component in [reference source](https://github.com/dotnet/aspnetcore/blob/release/7.0/src/ProjectTemplates/Web.ProjectTemplates/content/ComponentsWebAssembly-CSharp/Client/Shared/RedirectToLogin.razor).

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]
