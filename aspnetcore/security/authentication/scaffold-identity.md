---
title: Scaffold Identity in ASP.NET Core projects
author: rick-anderson
description: Learn how to scaffold Identity in an ASP.NET Core project.
monikerRange: '>= aspnetcore-2.1'
ms.author: riande
ms.custom: mvc
ms.date: 04/13/2020
uid: security/authentication/scaffold-identity
---
# Scaffold Identity in ASP.NET Core projects

By [Rick Anderson](https://twitter.com/RickAndMSFT)

::: moniker range=">= aspnetcore-3.0"

ASP.NET Core provides [ASP.NET Core Identity](xref:security/authentication/identity) as a [Razor Class Library](xref:razor-pages/ui-class). Applications that include Identity can apply the scaffolder to selectively add the source code contained in the Identity Razor Class Library (RCL). You might want to generate source code so you can modify the code and change the behavior. For example, you could instruct the scaffolder to generate the code used in registration. Generated code takes precedence over the same code in the Identity RCL. To gain full control of the UI and not use the default RCL, see the section [Create full Identity UI source](#full).

Applications that do **not** include authentication can apply the scaffolder to add the RCL Identity package. You have the option of selecting Identity code to be generated.

Although the scaffolder generates most of the necessary code, you need to update your project to complete the process. This document explains the steps needed to complete an Identity scaffolding update.

We recommend using a source control system that shows file differences and allows you to back out of changes. Inspect the changes after running the Identity scaffolder.

Services are required when using [Two Factor Authentication](xref:security/authentication/identity-enable-qrcodes), [Account confirmation and password recovery](xref:security/authentication/accconfirm), and other security features with Identity. Services or service stubs aren't generated when scaffolding Identity. Services to enable these features must be added manually. For example, see [Require Email Confirmation](xref:security/authentication/accconfirm#require-email-confirmation).

This document contains more complete instructions than the *ScaffoldingReadme.txt* file which is generated when running the scaffolder.

## Scaffold Identity into an empty project

[!INCLUDE[](~/includes/scaffold-identity/id-scaffold-dlg.md)]

Update the `Startup` class with code similar to the following:

[!code-csharp[](scaffold-identity/3.1sample/StartupMVC.cs?name=snippet)]

[!INCLUDE[](~/includes/scaffold-identity/hsts.md)]

[!INCLUDE[](~/includes/scaffold-identity/migrations.md)]

## Scaffold Identity into a Razor project without existing authorization

<!--  Updated for 3.0
set projNam=RPnoAuth
set projType=webapp

dotnet new %projType% -o %projNam%
cd %projNam%
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
dotnet add package Microsoft.AspNetCore.Identity.UI
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet aspnet-codegenerator identity --useDefaultUI
dotnet ef database drop
dotnet ef migrations add CreateIdentitySchema0
dotnet ef database update
-->

<!-- ERROR
There is already an object named 'AspNetRoles' in the database.

Fixed via dotnet ef database drop
before dotnet ef database update
-->

[!INCLUDE[](~/includes/scaffold-identity/id-scaffold-dlg.md)]

Identity is configured in *Areas/Identity/IdentityHostingStartup.cs*. For more information, see [IHostingStartup](xref:fundamentals/configuration/platform-specific-configuration).

<a name="efm"></a>

### Migrations, UseAuthentication, and layout

[!INCLUDE[](~/includes/scaffold-identity/migrations.md)]

<a name="useauthentication"></a>

### Enable authentication

Update the `Startup` class with code similar to the following:

[!code-csharp[](scaffold-identity/3.1sample/StartupRP.cs?name=snippet)]

[!INCLUDE[](~/includes/scaffold-identity/hsts.md)]

### Layout changes

Optional: Add the login partial (`_LoginPartial`) to the layout file:

[!code-html[](scaffold-identity/3.1sample/_Layout.cshtml?highlight=20)]

## Scaffold Identity into a Razor project with authorization

<!--
Use >=2.1: dotnet new webapp -au Individual -o RPauth
Use = 2.0: dotnet new razor -au Individual -o RPauth
uld option: Use Local DB, not SQLite

dotnet new webapp -au Individual -uld -o RPauth
cd RPauth
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet aspnet-codegenerator identity -dc RPauth.Data.ApplicationDbContext --files "Account.Register;Account.Register"
-->

[!INCLUDE[](~/includes/scaffold-identity/id-scaffold-dlg-auth.md)]

Some Identity options are configured in *Areas/Identity/IdentityHostingStartup.cs*. For more information, see [IHostingStartup](xref:fundamentals/configuration/platform-specific-configuration).

## Scaffold Identity into an MVC project without existing authorization

<!--
set projNam=MvcNoAuth
set projType=mvc
set version=2.1.0

dotnet new %projType% -o %projNam%
cd %projNam%
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design -v %version%
dotnet restore
dotnet aspnet-codegenerator identity --useDefaultUI
dotnet ef migrations add CreateIdentitySchema
dotnet ef database update
-->

[!INCLUDE[](~/includes/scaffold-identity/id-scaffold-dlg.md)]

Optional: Add the login partial (`_LoginPartial`) to the *Views/Shared/_Layout.cshtml* file:

[!code-html[](scaffold-identity/3.1sample/_Layout.cshtml?highlight=20)]

* Move the *Pages/Shared/_LoginPartial.cshtml* file to *Views/Shared/_LoginPartial.cshtml*

Identity is configured in *Areas/Identity/IdentityHostingStartup.cs*. For more information, see IHostingStartup.

[!INCLUDE[](~/includes/scaffold-identity/migrations.md)]

Update the `Startup` class with code similar to the following:

[!code-csharp[](scaffold-identity/3.1sample/StartupMVC.cs?name=snippet)]

[!INCLUDE[](~/includes/scaffold-identity/hsts.md)]

## Scaffold Identity into an MVC project with authorization

<!--
dotnet new mvc -au Individual -o MvcAuth
cd MvcAuth
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet restore
dotnet aspnet-codegenerator identity -dc MvcAuth.Data.ApplicationDbContext  --files "Account.Login;Account.Register"
-->

[!INCLUDE[](~/includes/scaffold-identity/id-scaffold-dlg-auth.md)]

## Scaffold Identity into a Blazor Server project without existing authorization

[!INCLUDE[](~/includes/scaffold-identity/id-scaffold-dlg.md)]

Identity is configured in *Areas/Identity/IdentityHostingStartup.cs*. For more information, see [IHostingStartup](xref:fundamentals/configuration/platform-specific-configuration).

### Migrations

[!INCLUDE[](~/includes/scaffold-identity/migrations.md)]

### Pass tokens to the app

Tokens can be passed to components:

* When authentication tokens are provisioned and saved to the authentication cookie, they can be passed to components.
* Razor components can't use `HttpContext` directly, so there's no way to obtain an [anti-request forgery (XSRF) token](xref:security/anti-request-forgery) to POST to Identity's logout endpoint at `/Identity/Account/Logout`. An XSRF token can be passed to components.

For more information and example code, see <xref:security/blazor/server#pass-tokens>. The `TokenProvider` service demonstrated in the topic is used in the `LoginDisplay` component in the following [Layout and authentication flow changes](#layout-and-authentication-flow-changes) section.

### Enable authentication

In the `Startup` class:

* Confirm that Razor Pages services are added in `Startup.ConfigureServices`.
* If using the [TokenProvider](xref:security/blazor/server#pass-tokens), register the service.
* Call `UseDatabaseErrorPage` on the application builder in `Startup.Configure` for the Development environment.
* Call `UseAuthentication` and `UseAuthorization` after `UseRouting`.
* Add an endpoint for Razor Pages.

[!code-csharp[](scaffold-identity/3.1sample/StartupBlazor.cs?highlight=3,6,14,27-28,32)]

[!INCLUDE[](~/includes/scaffold-identity/hsts.md)]

### Layout and authentication flow changes

Add a `RedirectToLogin` component (*RedirectToLogin.razor*) to the app's *Shared* folder in the project root:

```razor
@inject NavigationManager Navigation
@code {
    protected override void OnInitialized()
    {
        Navigation.NavigateTo($"Identity/Account/Login?returnUrl={Navigation.Uri}");
    }
}
```

Add a `LoginDisplay` component (*LoginDisplay.razor*) to the app's *Shared* folder. The [TokenProvider service](xref:security/blazor/server#pass-tokens) provides the XSRF token for the HTML form that POSTs to Identity's logout endpoint:

```razor
@using Microsoft.AspNetCore.Components.Authorization
@inject NavigationManager Navigation
@inject TokenProvider TokenProvider

<AuthorizeView>
    <Authorized>
        <a href="Identity/Account/Manage/Index">
            Hello, @context.User.Identity.Name!
        </a>
        <form action="/Identity/Account/Logout?returnUrl=%2F" method="post">
            <button class="nav-link btn btn-link" type="submit">Logout</button>
            <input name="__RequestVerificationToken" type="hidden" 
                value="@TokenProvider.XsrfToken">
        </form>
    </Authorized>
    <NotAuthorized>
        <a href="Identity/Account/Register">Register</a>
        <a href="Identity/Account/Login">Login</a>
    </NotAuthorized>
</AuthorizeView>
```

In the `MainLayout` component (*Shared/MainLayout.razor*), add the `LoginDisplay` component to the top-row `<div>` element's content:

```razor
<div class="top-row px-4 auth">
    <LoginDisplay />
    <a href="https://docs.microsoft.com/aspnet/" target="_blank">About</a>
</div>
```

In the `App` component (*App.razor*):

* Wrap the `Router` component with the `CascadingAuthenticationState` component.
* Add the `RedirectToLogin` component for unauthorized routes.

The following shows the complete component if the app is also using the [TokenProvider service](xref:security/blazor/server#pass-tokens):

```razor
@inject TokenProvider TokenProvider

<CascadingAuthenticationState>
    <Router AppAssembly="@typeof(Program).Assembly">
        <Found Context="routeData">
            <AuthorizeRouteView RouteData="@routeData"
                                DefaultLayout="@typeof(MainLayout)">
                <NotAuthorized>
                    <RedirectToLogin />
                </NotAuthorized>
            </AuthorizeRouteView>
        </Found>
        <NotFound>
            <LayoutView Layout="@typeof(MainLayout)">
                <p>Sorry, there's nothing at this address.</p>
            </LayoutView>
        </NotFound>
    </Router>
</CascadingAuthenticationState>

@code {
    [Parameter]
    public InitialApplicationState InitialState { get; set; }

    protected override Task OnInitializedAsync()
    {
        TokenProvider.AccessToken = InitialState.AccessToken;
        TokenProvider.RefreshToken = InitialState.RefreshToken;
        TokenProvider.XsrfToken = InitialState.XsrfToken;

        return base.OnInitializedAsync();
    }
}
```

### Style authentication endpoints

Because Blazor Server uses Razor Pages Identity pages, the styling of the UI changes when a visitor navigates between Identity pages and components. You have two options to address the incongruous styles:

* Style the Identity pages with CSS to match Blazor's styles.
* Rebuild Identity pages as Razor components.

## Scaffold Identity into a Blazor Server project with authorization

[!INCLUDE[](~/includes/scaffold-identity/id-scaffold-dlg-auth.md)]

Some Identity options are configured in *Areas/Identity/IdentityHostingStartup.cs*. For more information, see [IHostingStartup](xref:fundamentals/configuration/platform-specific-configuration).

<a name="full"></a>

## Create full Identity UI source

To maintain full control of the Identity UI, run the Identity scaffolder and select **Override all files**.

The following highlighted code shows the changes to replace the default Identity UI with Identity in an ASP.NET Core 2.1 web app. You might want to do this to have full control of the Identity UI.

[!code-csharp[](scaffold-identity/sample/StartupFull.cs?name=snippet1&highlight=13-14,17-999)]

The default Identity is replaced in the following code:

[!code-csharp[](scaffold-identity/sample/StartupFull.cs?name=snippet2)]

The following code sets the [LoginPath](/dotnet/api/microsoft.aspnetcore.authentication.cookies.cookieauthenticationoptions.loginpath), [LogoutPath](/dotnet/api/microsoft.aspnetcore.authentication.cookies.cookieauthenticationoptions.logoutpath), and [AccessDeniedPath](/dotnet/api/microsoft.aspnetcore.authentication.cookies.cookieauthenticationoptions.accessdeniedpath):

[!code-csharp[](scaffold-identity/sample/StartupFull.cs?name=snippet3)]

Register an `IEmailSender` implementation, for example:

[!code-csharp[](scaffold-identity/sample/StartupFull.cs?name=snippet4)]

[!code-csharp[](scaffold-identity/sample/StartupFull.cs?name=snippet)]

<!--
uld option: Use Local DB, not SQLite

dotnet new webapp -au Individual -uld -o RPauth
cd RPauth
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet aspnet-codegenerator identity -dc RPauth.Data.ApplicationDbContext --files "Account.Register;Account.Login;Account.RegisterConfirmation"
-->
## Disable register page

To disable user registration:

* Scaffold Identity. Include Account.Register, Account.Login, and Account.RegisterConfirmation. For example:

  ```dotnetcli
   dotnet aspnet-codegenerator identity -dc RPauth.Data.ApplicationDbContext --files "Account.Register;Account.Login;Account.RegisterConfirmation"
  ```

* Update *Areas/Identity/Pages/Account/Register.cshtml.cs* so users can't register from this endpoint:

  [!code-csharp[](scaffold-identity/sample/Register.cshtml.cs?name=snippet)]

* Update *Areas/Identity/Pages/Account/Register.cshtml* to be consistent with the preceding changes:

  [!code-cshtml[](scaffold-identity/sample/Register.cshtml)]

* Comment out or remove the registration link from *Areas/Identity/Pages/Account/Login.cshtml*

```cshtml
@*
<p>
    <a asp-page="./Register" asp-route-returnUrl="@Model.ReturnUrl">Register as a new user</a>
</p>
*@
```

* Update the *Areas/Identity/Pages/Account/RegisterConfirmation* page.

  * Remove the code and links from the cshtml file.
  * Remove the confirmation code from the `PageModel`:

  ```csharp
   [AllowAnonymous]
    public class RegisterConfirmationModel : PageModel
    {
        public IActionResult OnGet()
        {  
            return Page();
        }
    }
  ```
  
### Use another app to add users

Provide a mechanism to add users outside the web app. Options to add users include:

* A dedicated admin web app.
* A console app.

The following code outlines one approach to adding users:

* A list of users is read into memory.
* A strong unique password is generated for each user.
* The user is added to the Identity database.
* The user is notified and told to change the password.

[!code-csharp[](scaffold-identity/consoleAddUser/Program.cs?name=snippet)]

The following code outlines adding a user:

[!code-csharp[](scaffold-identity/consoleAddUser/Data/SeedData.cs?name=snippet)]

A similar approach can be followed for production scenarios.

## Prevent publish of static Identity assets

To prevent publishing static Identity assets to the web root, see <xref:security/authentication/identity#prevent-publish-of-static-identity-assets>.

## Additional resources

* [Changes to authentication code to ASP.NET Core 2.1 and later](xref:migration/20_21#changes-to-authentication-code)

::: moniker-end

::: moniker range="< aspnetcore-3.0"

ASP.NET Core 2.1 and later provides [ASP.NET Core Identity](xref:security/authentication/identity) as a [Razor Class Library](xref:razor-pages/ui-class). Applications that include Identity can apply the scaffolder to selectively add the source code contained in the Identity Razor Class Library (RCL). You might want to generate source code so you can modify the code and change the behavior. For example, you could instruct the scaffolder to generate the code used in registration. Generated code takes precedence over the same code in the Identity RCL. To gain full control of the UI and not use the default RCL, see the section [Create full identity UI source](#full).

Applications that do **not** include authentication can apply the scaffolder to add the RCL Identity package. You have the option of selecting Identity code to be generated.

Although the scaffolder generates most of the necessary code, you'll have to update your project to complete the process. This document explains the steps needed to complete an Identity scaffolding update.

When the Identity scaffolder is run, a *ScaffoldingReadme.txt* file is created in the project directory. The *ScaffoldingReadme.txt* file contains general instructions on what's needed to complete the Identity scaffolding update. This document contains more complete instructions than the *ScaffoldingReadme.txt* file.

We recommend using a source control system that shows file differences and allows you to back out of changes. Inspect the changes after running the Identity scaffolder.

> [!NOTE]
> Services are required when using [Two Factor Authentication](xref:security/authentication/identity-enable-qrcodes), [Account confirmation and password recovery](xref:security/authentication/accconfirm), and other security features with Identity. Services or service stubs aren't generated when scaffolding Identity. Services to enable these features must be added manually. For example, see [Require Email Confirmation](xref:security/authentication/accconfirm#require-email-confirmation).

## Scaffold Identity into an empty project

[!INCLUDE[](~/includes/scaffold-identity/id-scaffold-dlg.md)]

Add the following highlighted calls to the `Startup` class:

[!code-csharp[](scaffold-identity/sample/StartupEmpty.cs?name=snippet1&highlight=5,20-23)]

[!INCLUDE[](~/includes/scaffold-identity/hsts.md)]

[!INCLUDE[](~/includes/scaffold-identity/migrations.md)]

## Scaffold Identity into a Razor project without existing authorization

<!--  Updated for 3.0
set projNam=RPnoAuth
set projType=webapp

dotnet new %projType% -o %projNam%
cd %projNam%
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
dotnet add package Microsoft.AspNetCore.Identity.UI
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet restore
dotnet aspnet-codegenerator identity --useDefaultUI
dotnet ef migrations add CreateIdentitySchema
dotnet ef database update
-->

[!INCLUDE[](~/includes/scaffold-identity/id-scaffold-dlg.md)]

Identity is configured in *Areas/Identity/IdentityHostingStartup.cs*. For more information, see [IHostingStartup](xref:fundamentals/configuration/platform-specific-configuration).

<a name="efm"></a>

### Migrations, UseAuthentication, and layout

[!INCLUDE[](~/includes/scaffold-identity/migrations.md)]

<a name="useauthentication"></a>

### Enable authentication

In the `Configure` method of the `Startup` class, call [UseAuthentication](/dotnet/api/microsoft.aspnetcore.builder.authappbuilderextensions.useauthentication?view=aspnetcore-2.0#Microsoft_AspNetCore_Builder_AuthAppBuilderExtensions_UseAuthentication_Microsoft_AspNetCore_Builder_IApplicationBuilder_) after `UseStaticFiles`:

[!code-csharp[](scaffold-identity/sample/StartupRPnoAuth.cs?name=snippet1&highlight=29)]

[!INCLUDE[](~/includes/scaffold-identity/hsts.md)]

### Layout changes

Optional: Add the login partial (`_LoginPartial`) to the layout file:

[!code-html[](scaffold-identity/sample/_Layout.cshtml?highlight=37)]

## Scaffold Identity into a Razor project with authorization

<!--
Use >=2.1: dotnet new webapp -au Individual -o RPauth
Use = 2.0: dotnet new razor -au Individual -o RPauth
uld option: Use Local DB, not SQLite

dotnet new webapp -au Individual -uld -o RPauth
cd RPauth
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet aspnet-codegenerator identity -dc RPauth.Data.ApplicationDbContext --files "Account.Register;Account.Register"
-->

[!INCLUDE[](~/includes/scaffold-identity/id-scaffold-dlg-auth.md)]

Some Identity options are configured in *Areas/Identity/IdentityHostingStartup.cs*. For more information, see [IHostingStartup](xref:fundamentals/configuration/platform-specific-configuration).

## Scaffold Identity into an MVC project without existing authorization

<!--
set projNam=MvcNoAuth
set projType=mvc
set version=2.1.0

dotnet new %projType% -o %projNam%
cd %projNam%
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design -v %version%
dotnet restore
dotnet aspnet-codegenerator identity --useDefaultUI
dotnet ef migrations add CreateIdentitySchema
dotnet ef database update
-->

[!INCLUDE[](~/includes/scaffold-identity/id-scaffold-dlg.md)]

Optional: Add the login partial (`_LoginPartial`) to the *Views/Shared/_Layout.cshtml* file:

[!code-html[](scaffold-identity/sample/_LayoutMvc.cshtml?highlight=37)]

* Move the *Pages/Shared/_LoginPartial.cshtml* file to *Views/Shared/_LoginPartial.cshtml*

Identity is configured in *Areas/Identity/IdentityHostingStartup.cs*. For more information, see IHostingStartup.

[!INCLUDE[](~/includes/scaffold-identity/migrations.md)]

Call [UseAuthentication](/dotnet/api/microsoft.aspnetcore.builder.authappbuilderextensions.useauthentication?view=aspnetcore-2.0#Microsoft_AspNetCore_Builder_AuthAppBuilderExtensions_UseAuthentication_Microsoft_AspNetCore_Builder_IApplicationBuilder_) after `UseStaticFiles`:

[!code-csharp[](scaffold-identity/sample/StartupMvcNoAuth.cs?name=snippet1&highlight=23)]

[!INCLUDE[](~/includes/scaffold-identity/hsts.md)]

## Scaffold Identity into an MVC project with authorization

<!--
dotnet new mvc -au Individual -o MvcAuth
cd MvcAuth
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet restore
dotnet aspnet-codegenerator identity -dc MvcAuth.Data.ApplicationDbContext  --files "Account.Login;Account.Register"
-->

[!INCLUDE[](~/includes/scaffold-identity/id-scaffold-dlg-auth.md)]

Delete the *Pages/Shared* folder and the files in that folder.

<a name="full"></a>

## Create full Identity UI source

To maintain full control of the Identity UI, run the Identity scaffolder and select **Override all files**.

The following highlighted code shows the changes to replace the default Identity UI with Identity in an ASP.NET Core 2.1 web app. You might want to do this to have full control of the Identity UI.

[!code-csharp[](scaffold-identity/sample/StartupFull.cs?name=snippet1&highlight=13-14,17-999)]

The default Identity is replaced in the following code:

[!code-csharp[](scaffold-identity/sample/StartupFull.cs?name=snippet2)]

The following code sets the [LoginPath](/dotnet/api/microsoft.aspnetcore.authentication.cookies.cookieauthenticationoptions.loginpath), [LogoutPath](/dotnet/api/microsoft.aspnetcore.authentication.cookies.cookieauthenticationoptions.logoutpath), and [AccessDeniedPath](/dotnet/api/microsoft.aspnetcore.authentication.cookies.cookieauthenticationoptions.accessdeniedpath):

[!code-csharp[](scaffold-identity/sample/StartupFull.cs?name=snippet3)]

Register an `IEmailSender` implementation, for example:

[!code-csharp[](scaffold-identity/sample/StartupFull.cs?name=snippet4)]

[!code-csharp[](scaffold-identity/sample/StartupFull.cs?name=snippet)]

<!--
uld option: Use Local DB, not SQLite

dotnet new webapp -au Individual -uld -o RPauth
cd RPauth
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet aspnet-codegenerator identity -dc RPauth.Data.ApplicationDbContext --files "Account.Register;Account.Login;Account.RegisterConfirmation"
-->
## Disable register page

To disable user registration:

* Scaffold Identity. Include Account.Register, Account.Login, and Account.RegisterConfirmation. For example:

  ```dotnetcli
   dotnet aspnet-codegenerator identity -dc RPauth.Data.ApplicationDbContext --files "Account.Register;Account.Login;Account.RegisterConfirmation"
  ```

* Update *Areas/Identity/Pages/Account/Register.cshtml.cs* so users can't register from this endpoint:

  [!code-csharp[](scaffold-identity/sample/Register.cshtml.cs?name=snippet)]

* Update *Areas/Identity/Pages/Account/Register.cshtml* to be consistent with the preceding changes:

  [!code-cshtml[](scaffold-identity/sample/Register.cshtml)]

* Comment out or remove the registration link from *Areas/Identity/Pages/Account/Login.cshtml*

```cshtml
@*
<p>
    <a asp-page="./Register" asp-route-returnUrl="@Model.ReturnUrl">Register as a new user</a>
</p>
*@
```

* Update the *Areas/Identity/Pages/Account/RegisterConfirmation* page.

  * Remove the code and links from the cshtml file.
  * Remove the confirmation code from the `PageModel`:

  ```csharp
   [AllowAnonymous]
    public class RegisterConfirmationModel : PageModel
    {
        public IActionResult OnGet()
        {  
            return Page();
        }
    }
  ```
  
### Use another app to add users

Provide a mechanism to add users outside the web app. Options to add users include:

* A dedicated admin web app.
* A console app.

The following code outlines one approach to adding users:

* A list of users is read into memory.
* A strong unique password is generated for each user.
* The user is added to the Identity database.
* The user is notified and told to change the password.

[!code-csharp[](scaffold-identity/consoleAddUser/Program.cs?name=snippet)]

The following code outlines adding a user:

[!code-csharp[](scaffold-identity/consoleAddUser/Data/SeedData.cs?name=snippet)]

A similar approach can be followed for production scenarios.

## Additional resources

* [Changes to authentication code to ASP.NET Core 2.1 and later](xref:migration/20_21#changes-to-authentication-code)

::: moniker-end
