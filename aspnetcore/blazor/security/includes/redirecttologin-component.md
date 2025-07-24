The `RedirectToLogin` component (`RedirectToLogin.razor`):

* Manages redirecting unauthorized users to the login page.
* The current URL that the user is attempting to access is maintained by so that they can be returned to that page if authentication is successful using:
  * [Navigation history state](xref:blazor/fundamentals/routing#navigation-history-state) in ASP.NET Core in .NET 7 or later.
  * A query string in ASP.NET Core in .NET 6 or earlier.

Inspect the `RedirectToLogin` component in [reference source](https://github.com/dotnet/aspnetcore/tree/main/src/ProjectTemplates/Web.ProjectTemplates/content/ComponentsWebAssembly-CSharp). The location of the component changed over time, so use GitHub search tools to locate the component.

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]
