The `LoginDisplay` component (`Shared/LoginDisplay.razor`) is rendered in the `MainLayout` component (`Shared/MainLayout.razor`) and manages the following behaviors:

* For authenticated users:
  * Displays the current user name.
  * Offers a link to the user profile page in ASP.NET Core Identity.
  * Offers a button to log out of the app.
* For anonymous users:
  * Offers the option to register.
  * Offers the option to log in.

Due to changes in the framework across releases of ASP.NET Core, Razor markup for the `LoginDisplay` component isn't shown in this section. To inspect the markup of the component for a given release, use ***either*** of the following approaches:

* Create an app provisioned for authentication from the default Blazor WebAssembly project template for the version of ASP.NET Core that you intend to use. Inspect the `LoginDisplay` component in the generated app.
* Inspect the `LoginDisplay` component in [reference source](https://github.com/dotnet/aspnetcore/blob/release/7.0/src/ProjectTemplates/Web.ProjectTemplates/content/ComponentsWebAssembly-CSharp/Client/Shared/LoginDisplay.IndividualLocalAuth.razor). The templated content for `Hosted` equal to `true` is used.

  [!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]
