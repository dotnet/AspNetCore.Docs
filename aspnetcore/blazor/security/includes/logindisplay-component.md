The `LoginDisplay` component (`LoginDisplay.razor`) is rendered in the `MainLayout` component (`MainLayout.razor`) and manages the following behaviors:

* For authenticated users:
  * Displays the current user name.
  * Offers a link to the user profile page in ASP.NET Core Identity.
  * Offers a button to log out of the app.
* For anonymous users:
  * Offers the option to register.
  * Offers the option to log in.

Due to changes in the framework across releases of ASP.NET Core, Razor markup for the `LoginDisplay` component isn't shown in this section. To inspect the markup of the component for a given release, use ***either*** of the following approaches:

* Create an app provisioned for authentication from the default Blazor WebAssembly project template for the version of ASP.NET Core that you intend to use. Inspect the `LoginDisplay` component in the generated app.
* Inspect the `LoginDisplay` component in [reference source](https://github.com/dotnet/aspnetcore/tree/main/src/ProjectTemplates/Web.ProjectTemplates/content/ComponentsWebAssembly-CSharp). The location of the component changed over time, so use GitHub search tools to locate the component. The templated content for `Hosted` equal to `true` is used.

  [!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]
