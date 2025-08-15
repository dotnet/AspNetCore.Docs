---
title: Implement passkeys in an existing Blazor Web App
author: guardrex
description: Learn how to implement passkeys authentication in an ASP.NET Core Blazor Web App.
ms.author: wpickett
ms.custom: mvc
ms.date: 8/14/2025
uid: blazor/security/passkeys-migration
---
# Implement passkeys in an existing Blazor Web App

This guide explains how to add [passkey support](xref:blazor/security/passkeys) to an existing Blazor Web App that has ASP.NET Core Identity authentication configured.

The guidance in this article relies upon an app that was created with **Individual Accounts** for the app's **Authentication type** or [scaffolding Identity into an existing app](xref:security/authentication/scaffold-identity#scaffold-identity-into-a-blazor-project).

## Prerequisites

<!-- UPDATE 10.0 - Remove preview link in favor of the download link ...

* [.NET SDK](https://dotnet.microsoft.com/download) (.NET 10 or later)

-->

* An existing Blazor Web App with ASP.NET Core Identity
* [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)

## Step 1: Update to .NET 10

Update the app's project file to target .NET 10:

```xml
<TargetFramework>net10.0</TargetFramework>
```

Update all `Microsoft.AspNetCore.*` and `Microsoft.EntityFrameworkCore.*` packages to their latest .NET 10 versions.

## Step 2: Update Identity schema version

In `Program.cs`, update the Identity configuration to use schema version 3, which includes passkey support:

```csharp
builder.Services.AddIdentityCore<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.Stores.SchemaVersion = IdentitySchemaVersions.Version3;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddSignInManager()
.AddDefaultTokenProviders();
```

# [Visual Studio](#tab/visual-studio)

In Visual Studio **Solution Explorer**, double-click **Connected Services**. In the **Service Dependencies** area, select the ellipsis (`...`) followed by **Add migration** in the **SQL Server Express LocalDB** area.

Give the migration a **Migration name** of `AddPasskeySupport` to describe the migration. Wait for the database context to load in the **DbContext class names** field. Select **Finish** to create the migration. Select the **Close** button when the operation completes.

Select the ellipsis (`...`) again followed by the **Update database** command.

The **Update database with the latest migration** dialog opens. Wait for the **DbContext class names** field to update and for prior migrations to load. Select the **Finish** button. Select the **Close** button when the operation completes.

# [Visual Studio Code](#tab/visual-studio-code)

Use the following command in the **Terminal** (**Terminal** menu > **New Terminal**) to add a migration for the new data annotations:

```dotnetcli
dotnet ef migrations add AddPasskeySupport
```

To apply the migration to the database, execute the following command:

```dotnetcli
dotnet ef database update
```

# [.NET CLI](#tab/net-cli/)

To add a migration for the new data annotations, execute the following command in a command shell opened to the project's root folder:

```dotnetcli
dotnet ef migrations add AddPasskeySupport
```

To apply the migration to the database, execute the following command:

```dotnetcli
dotnet ef database update
```

---

## Step 3: Create passkey model classes

Add the following model classes to the project in the `Components/Account` folder.

Replace the `{NAMESPACE}` placeholder in the following examples with the app's namespace. For example, `Contoso` for `Contoso.Components.Account` in the following examples.

`Components/Account/PasskeyInputModel.cs`:

```csharp
namespace {NAMESPACE}.Components.Account;

public class PasskeyInputModel
{
    public string? CredentialJson { get; set; }
    public string? Error { get; set; }
}
```

`Components/Account/PasskeyOperation.cs`:

```csharp
namespace {NAMESPACE}.Components.Account;

public enum PasskeyOperation
{
    Create = 0,
    Request = 1,
}
```

## Step 4: Create the `PasskeySubmit` component

Add the following `PasskeySubmit` component to handle passkey operations.

`Components/Account/Shared/PasskeySubmit.razor`:

```razor
@using Microsoft.AspNetCore.Antiforgery
@inject IServiceProvider Services

<button type="submit" name="__passkeySubmit" 
    @attributes="AdditionalAttributes">@ChildContent</button>
<passkey-submit
    operation="@Operation"
    name="@Name"
    email-name="@EmailName"
    request-token-name="@tokens?.HeaderName"
    request-token-value="@tokens?.RequestToken">
</passkey-submit>

@code {
    private AntiforgeryTokenSet? tokens;

    [CascadingParameter]
    private HttpContext HttpContext { get; set; } = default!;

    [Parameter]
    [EditorRequired]
    public PasskeyOperation Operation { get; set; }

    [Parameter]
    [EditorRequired]
    public string Name { get; set; } = default!;

    [Parameter]
    public string? EmailName { get; set; }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public IDictionary<string, object>? AdditionalAttributes { get; set; }

    protected override void OnInitialized()
    {
        tokens = Services.GetRequiredService<IAntiforgery>()?.GetTokens(HttpContext);
    }
}
```

## Step 5: Add the JavaScript for passkey operations

Add the following JavaScript file to handle WebAuthn API interactions.

`Components/Account/Shared/PasskeySubmit.razor.js`:

```javascript
const browserSupportsPasskeys =
  typeof navigator.credentials !== 'undefined' &&
  typeof window.PublicKeyCredential !== 'undefined' &&
  typeof window.PublicKeyCredential.parseCreationOptionsFromJSON === 'function' &&
  typeof window.PublicKeyCredential.parseRequestOptionsFromJSON === 'function';

async function fetchWithErrorHandling(url, options = {}) {
  const response = await fetch(url, {
    credentials: 'include',
    ...options
  });
  if (!response.ok) {
    const text = await response.text();
    console.error(text);
    throw new Error(`The server responded with status ${response.status}.`);
  }
  return response;
}

async function createCredential(headers, signal) {
  const optionsResponse = await fetchWithErrorHandling('/Account/PasskeyCreationOptions', {
    method: 'POST',
    headers,
    signal,
  });
  const optionsJson = await optionsResponse.json();
  const options = PublicKeyCredential.parseCreationOptionsFromJSON(optionsJson);
  return await navigator.credentials.create({ publicKey: options, signal });
}

async function requestCredential(email, mediation, headers, signal) {
  const optionsResponse = 
    await fetchWithErrorHandling(`/Account/PasskeyRequestOptions?username=${email}`, {
      method: 'POST',
      headers,
      signal,
    });
  const optionsJson = await optionsResponse.json();
  const options = PublicKeyCredential.parseRequestOptionsFromJSON(optionsJson);
  return await navigator.credentials.get({ publicKey: options, mediation, signal });
}

customElements.define('passkey-submit', class extends HTMLElement {
  static formAssociated = true;

  connectedCallback() {
    this.internals = this.attachInternals();
    this.attrs = {
      operation: this.getAttribute('operation'),
      name: this.getAttribute('name'),
      emailName: this.getAttribute('email-name'),
      requestTokenName: this.getAttribute('request-token-name'),
      requestTokenValue: this.getAttribute('request-token-value'),
    };

    this.internals.form.addEventListener('submit', (event) => {
      if (event.submitter?.name === '__passkeySubmit') {
        event.preventDefault();
        this.obtainAndSubmitCredential();
      }
    });

    this.tryAutofillPasskey();
  }

  disconnectedCallback() {
    this.abortController?.abort();
  }

  async obtainCredential(useConditionalMediation, signal) {
    if (!browserSupportsPasskeys) {
      throw new Error('Some passkey features are missing. Please update your browser.');
    }

    const headers = {
      [this.attrs.requestTokenName]: this.attrs.requestTokenValue,
    };

    if (this.attrs.operation === 'Create') {
      return await createCredential(headers, signal);
    } else if (this.attrs.operation === 'Request') {
      const email = new FormData(this.internals.form).get(this.attrs.emailName);
      const mediation = useConditionalMediation ? 'conditional' : undefined;
      return await requestCredential(email, mediation, headers, signal);
    } else {
      throw new Error(`Unknown passkey operation '${this.attrs.operation}'.`);
    }
  }

  async obtainAndSubmitCredential(useConditionalMediation = false) {
    this.abortController?.abort();
    this.abortController = new AbortController();
    const signal = this.abortController.signal;
    const formData = new FormData();
    try {
      const credential = await this.obtainCredential(useConditionalMediation, signal);
      const credentialJson = JSON.stringify(credential);
      formData.append(`${this.attrs.name}.CredentialJson`, credentialJson);
    } catch (error) {
      if (error.name === 'AbortError') {
        return;
      }
      console.error(error);
      if (useConditionalMediation) {
        return;
      }
      const errorMessage = error.name === 'NotAllowedError'
        ? 'No passkey was provided by the authenticator.'
        : error.message;
      formData.append(`${this.attrs.name}.Error`, errorMessage);
    }
    this.internals.setFormValue(formData);
    this.internals.form.submit();
  }

  async tryAutofillPasskey() {
    if (browserSupportsPasskeys && this.attrs.operation === 'Request' && await PublicKeyCredential.isConditionalMediationAvailable?.()) {
      await this.obtainAndSubmitCredential(true);
    }
  }
});
```

## Step 6: Add passkey endpoints

Update the `IdentityComponentsEndpointRouteBuilderExtensions.cs` file (or create the file if it doesn't exist) to include the passkey-specific endpoints:

```csharp
// Add the following endpoints to the existing 'MapAdditionalIdentityEndpoints' method

accountGroup.MapPost("/PasskeyCreationOptions", async (
    HttpContext context,
    [FromServices] UserManager<ApplicationUser> userManager,
    [FromServices] SignInManager<ApplicationUser> signInManager,
    [FromServices] IAntiforgery antiforgery) =>
{
    await antiforgery.ValidateRequestAsync(context);

    var user = await userManager.GetUserAsync(context.User);
    if (user is null)
    {
        return Results.NotFound($"Unable to load user with ID '{userManager.GetUserId(context.User)}'.");
    }

    var userId = await userManager.GetUserIdAsync(user);
    var userName = await userManager.GetUserNameAsync(user) ?? "User";
    var optionsJson = await signInManager.MakePasskeyCreationOptionsAsync(new()
    {
        Id = userId,
        Name = userName,
        DisplayName = userName
    });

    return TypedResults.Content(optionsJson, contentType: "application/json");
});

accountGroup.MapPost("/PasskeyRequestOptions", async (
    HttpContext context,
    [FromServices] UserManager<ApplicationUser> userManager,
    [FromServices] SignInManager<ApplicationUser> signInManager,
    [FromServices] IAntiforgery antiforgery,
    [FromQuery] string? username) =>
{
    await antiforgery.ValidateRequestAsync(context);

    var user = string.IsNullOrEmpty(username) ? null : await userManager.FindByNameAsync(username);
    var optionsJson = await signInManager.MakePasskeyRequestOptionsAsync(user);

    return TypedResults.Content(optionsJson, contentType: "application/json");
});
```

## Step 7: Update the Login page

Replace the existing `Login` component with the following component. The passkey-specific additions are described by Razor comments (`@* ... *@`) in the file.

Replace the `{NAMESPACE}` placeholder in the following example with the app's namespace. For example, `Contoso` for `Contoso.Data` in the following examples.

`Components/Account/Pages/Login.razor`:

```razor
@page "/Account/Login"

@using System.ComponentModel.DataAnnotations
@using Microsoft.AspNetCore.Authentication
@using Microsoft.AspNetCore.Identity
@using {NAMESPACE}.Data

@inject UserManager<ApplicationUser> UserManager
@inject SignInManager<ApplicationUser> SignInManager
@inject ILogger<Login> Logger
@inject NavigationManager NavigationManager
@inject IdentityRedirectManager RedirectManager

<PageTitle>Log in</PageTitle>

<h1>Log in</h1>
<div class="row">
    <div class="col-lg-6">
        <section>
            <StatusMessage Message="@errorMessage" />
            @* The EditContext is used instead of Model to allow conditional validation *@
            <EditForm EditContext="editContext" method="post" OnSubmit="LoginUser" FormName="login">
                <DataAnnotationsValidator />
                <h2>Use a local account to log in.</h2>
                <hr />
                <ValidationSummary class="text-danger" role="alert" />
                <div class="form-floating mb-3">
                    @* Note the autocomplete="username webauthn" to enable passkey autofill *@
                    <InputText @bind-Value="Input.Email" id="Input.Email" class="form-control" 
                               autocomplete="username webauthn" aria-required="true" placeholder="name@example.com" />
                    <label for="Input.Email" class="form-label">Email</label>
                    <ValidationMessage For="() => Input.Email" class="text-danger" />
                </div>
                <div class="form-floating mb-3">
                    <InputText type="password" @bind-Value="Input.Password" id="Input.Password" class="form-control" 
                               autocomplete="current-password" aria-required="true" placeholder="password" />
                    <label for="Input.Password" class="form-label">Password</label>
                    <ValidationMessage For="() => Input.Password" class="text-danger" />
                </div>
                <div class="checkbox mb-3">
                    <label class="form-label">
                        <InputCheckbox @bind-Value="Input.RememberMe" class="darker-border-checkbox form-check-input" />
                        Remember me
                    </label>
                </div>
                <div>
                    <button type="submit" class="w-100 btn btn-lg btn-primary">Log in</button>
                </div>
                <hr />
                @* Passkey login button *@
                <div class="d-flex flex-column">
                    <span class="text-secondary mx-auto mt-2">OR</span>
                    <PasskeySubmit Operation="PasskeyOperation.Request" Name="Input.Passkey" EmailName="Input.Email" 
                                   class="btn btn-link mx-auto">Log in with a passkey</PasskeySubmit>
                </div>
                <hr />
                <div>
                    <p>
                        <a href="Account/ForgotPassword">Forgot your password?</a>
                    </p>
                    <p>
                        <a href="@(NavigationManager.GetUriWithQueryParameters("Account/Register", new Dictionary<string, object?> { ["ReturnUrl"] = ReturnUrl }))">Register as a new user</a>
                    </p>
                    <p>
                        <a href="Account/ResendEmailConfirmation">Resend email confirmation</a>
                    </p>
                </div>
            </EditForm>
        </section>
    </div>
    <div class="col-lg-4 col-lg-offset-2">
        <section>
            <h3>Use another service to log in.</h3>
            <hr />
            <ExternalLoginPicker />
        </section>
    </div>
</div>

@code {
    private string? errorMessage;
    private EditContext editContext = default!;  // EditContext for conditional validation

    [CascadingParameter]
    private HttpContext HttpContext { get; set; } = default!;

    [SupplyParameterFromForm]
    private InputModel Input { get; set; } = default!;

    [SupplyParameterFromQuery]
    private string? ReturnUrl { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Input ??= new();

        editContext = new EditContext(Input);  // Initialize EditContext

        if (HttpMethods.IsGet(HttpContext.Request.Method))
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
        }
    }

    public async Task LoginUser()
    {
        // Handle passkey errors
        if (!string.IsNullOrEmpty(Input.Passkey?.Error))
        {
            errorMessage = $"Error: {Input.Passkey.Error}";
            return;
        }

        SignInResult result;
        
        // Check if this is a passkey sign-in
        if (!string.IsNullOrEmpty(Input.Passkey?.CredentialJson))
        {
            // When performing passkey sign-in, don't perform form validation.
            result = await SignInManager.PasskeySignInAsync(Input.Passkey.CredentialJson);
        }
        else
        {
            // If doing a password sign-in, validate the form.
            if (!editContext.Validate())
            {
                return;
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, set lockoutOnFailure: true
            result = await SignInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false);
        }

        if (result.Succeeded)
        {
            Logger.LogInformation("User logged in.");
            RedirectManager.RedirectTo(ReturnUrl);
        }
        else if (result.RequiresTwoFactor)
        {
            RedirectManager.RedirectTo(
                "Account/LoginWith2fa",
                new() { ["returnUrl"] = ReturnUrl, ["rememberMe"] = Input.RememberMe });
        }
        else if (result.IsLockedOut)
        {
            Logger.LogWarning("User account locked out.");
            RedirectManager.RedirectTo("Account/Lockout");
        }
        else
        {
            errorMessage = "Error: Invalid login attempt.";
        }
    }

    private sealed class InputModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "";

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        // Passkey input model
        public PasskeyInputModel? Passkey { get; set; }
    }
}
```

## Step 8: Create passkey management pages for adding and renaming passkeys

Add the following `Passkeys` component for managing passkeys.

Replace the `{NAMESPACE}` placeholder in the following examples with the app's namespace. For example, `Contoso` for `Contoso.Data` in the following examples.

`Components/Account/Pages/Manage/Passkeys.razor`:

```razor
@page "/Account/Manage/Passkeys"

@using {NAMESPACE}.Data
@using Microsoft.AspNetCore.Identity
@using System.Buffers.Text

@inject UserManager<ApplicationUser> UserManager
@inject SignInManager<ApplicationUser> SignInManager
@inject IdentityRedirectManager RedirectManager

<PageTitle>Manage your passkeys</PageTitle>

<h3>Manage your passkeys</h3>

<StatusMessage />

@if (currentPasskeys is { Count: > 0 })
{
    <table class="table">
        <tbody>
            @foreach (var passkey in currentPasskeys)
            {
                <tr>
                    <td>@(passkey.Name ?? "Unnamed passkey")</td>
                    <td>
                        @{
                            var credentialId = Base64Url.EncodeToString(passkey.CredentialId);
                        }
                        <form @formname="@($"update-passkey-{credentialId}")" @onsubmit="UpdatePasskey" method="post">
                            <AntiforgeryToken />
                            <div>
                                <input type="hidden" name="CredentialId" value="@credentialId" />
                                <button type="submit" name="Action" value="rename" class="btn btn-primary">Rename</button>
                                <button type="submit" name="Action" value="delete" class="btn btn-danger">Delete</button>
                            </div>
                        </form>
                    </td>
                </tr>
            }
        </tbody>
    </table>
}
else
{
    <p>No passkeys are registered.</p>
}

<form @formname="add-passkey" @onsubmit="AddPasskey" method="post">
    <AntiforgeryToken />
    <PasskeySubmit Operation="PasskeyOperation.Create" Name="Input" class="btn btn-primary">Add a new passkey</PasskeySubmit>
</form>

@code {
    private ApplicationUser? user;
    private IList<UserPasskeyInfo>? currentPasskeys;

    [CascadingParameter]
    private HttpContext HttpContext { get; set; } = default!;

    [SupplyParameterFromForm]
    private string? Action { get; set; }

    [SupplyParameterFromForm]
    private string? CredentialId { get; set; }

    [SupplyParameterFromForm(FormName = "add-passkey")]
    private PasskeyInputModel Input { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        Input ??= new();

        user = await UserManager.GetUserAsync(HttpContext.User);
        if (user is null)
        {
            RedirectManager.RedirectToInvalidUser(UserManager, HttpContext);
            return;
        }
        currentPasskeys = await UserManager.GetPasskeysAsync(user);
    }

    private async Task AddPasskey()
    {
        if (user is null)
        {
            RedirectManager.RedirectToInvalidUser(UserManager, HttpContext);
            return;
        }

        if (!string.IsNullOrEmpty(Input.Error))
        {
            RedirectManager.RedirectToCurrentPageWithStatus($"Error: {Input.Error}", HttpContext);
            return;
        }

        if (string.IsNullOrEmpty(Input.CredentialJson))
        {
            RedirectManager.RedirectToCurrentPageWithStatus("Error: The browser did not provide a passkey.", HttpContext);
            return;
        }

        var attestationResult = await SignInManager.PerformPasskeyAttestationAsync(Input.CredentialJson);
        if (!attestationResult.Succeeded)
        {
            RedirectManager.RedirectToCurrentPageWithStatus($"Error: Could not add the passkey: {attestationResult.Failure.Message}", HttpContext);
            return;
        }

        var addPasskeyResult = await UserManager.AddOrUpdatePasskeyAsync(user, attestationResult.Passkey);
        if (!addPasskeyResult.Succeeded)
        {
            RedirectManager.RedirectToCurrentPageWithStatus("Error: The passkey could not be added to your account.", HttpContext);
            return;
        }

        // Immediately prompt the user to enter a name for the credential
        var credentialIdBase64Url = Base64Url.EncodeToString(attestationResult.Passkey.CredentialId);
        RedirectManager.RedirectTo($"Account/Manage/RenamePasskey/{credentialIdBase64Url}");
    }

    private async Task UpdatePasskey()
    {
        switch (Action)
        {
            case "rename":
                RedirectManager.RedirectTo($"Account/Manage/RenamePasskey/{CredentialId}");
                break;
            case "delete":
                await DeletePasskey();
                break;
            default:
                RedirectManager.RedirectToCurrentPageWithStatus($"Error: Unknown action '{Action}'.", HttpContext);
                break;
        }
    }

    private async Task DeletePasskey()
    {
        if (user is null)
        {
            RedirectManager.RedirectToInvalidUser(UserManager, HttpContext);
            return;
        }

        byte[] credentialId;
        try
        {
            credentialId = Base64Url.DecodeFromChars(CredentialId);
        }
        catch (FormatException)
        {
            RedirectManager.RedirectToCurrentPageWithStatus("Error: The specified passkey ID had an invalid format.", HttpContext);
            return;
        }

        var result = await UserManager.RemovePasskeyAsync(user, credentialId);
        if (!result.Succeeded)
        {
            RedirectManager.RedirectToCurrentPageWithStatus("Error: The passkey could not be deleted.", HttpContext);
            return;
        }

        RedirectManager.RedirectToCurrentPageWithStatus("Passkey deleted successfully.", HttpContext);
    }
}
```

Add the following component for renaming passkeys.



`Components/Account/Pages/Manage/RenamePasskey.razor`:

```razor
@page "/Account/Manage/RenamePasskey/{Id}"

@using {NAMESPACE}.Data
@using System.ComponentModel.DataAnnotations
@using Microsoft.AspNetCore.Identity
@using System.Buffers.Text

@inject UserManager<ApplicationUser> UserManager
@inject IdentityRedirectManager RedirectManager

<EditForm Model="Input" OnValidSubmit="Rename" FormName="rename-passkey" method="post">
    <DataAnnotationsValidator />
    @if (passkey?.Name is { } name)
    {
        <h4>Enter a new name for your "@name" passkey</h4>
    }
    else
    {
        <h4>Enter a name for your passkey</h4>
    }
    <hr />
    <ValidationSummary class="text-danger" role="alert" />
    <div class="form-floating mb-3">
        <InputText @bind-Value="Input.Name" id="Input.Name" class="form-control" aria-required="true" placeholder="My passkey" />
        <label for="Input.Name" class="form-label">Passkey name</label>
        <ValidationMessage For="() => Input.Name" class="text-danger" />
    </div>
    <div>
        <button type="submit" class="w-100 btn btn-lg btn-primary">Continue</button>
    </div>
</EditForm>

@code {
    private ApplicationUser? user;
    private UserPasskeyInfo? passkey;

    [CascadingParameter]
    private HttpContext HttpContext { get; set; } = default!;

    [Parameter]
    public string? Id { get; set; }

    [SupplyParameterFromForm]
    private InputModel Input { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        Input ??= new();

        user = (await UserManager.GetUserAsync(HttpContext.User))!;
        if (user is null)
        {
            RedirectManager.RedirectToInvalidUser(UserManager, HttpContext);
            return;
        }

        byte[] credentialId;
        try
        {
            credentialId = Base64Url.DecodeFromChars(Id);
        }
        catch (FormatException)
        {
            RedirectManager.RedirectToWithStatus("Account/Manage/Passkeys", "Error: The specified passkey ID had an invalid format.", HttpContext);
            return;
        }

        passkey = await UserManager.GetPasskeyAsync(user, credentialId);
        if (passkey is null)
        {
            RedirectManager.RedirectToWithStatus("Account/Manage/Passkeys", "Error: The specified passkey could not be found.", HttpContext);
            return;
        }
    }

    private async Task Rename()
    {
        passkey!.Name = Input.Name;
        var result = await UserManager.AddOrUpdatePasskeyAsync(user!, passkey);
        if (!result.Succeeded)
        {
            RedirectManager.RedirectToWithStatus("Account/Manage/Passkeys", "Error: The passkey could not be updated.", HttpContext);
            return;
        }

        RedirectManager.RedirectToWithStatus("Account/Manage/Passkeys", "Passkey updated successfully.", HttpContext);
    }

    private sealed class InputModel
    {
        [Required]
        public string Name { get; set; } = "";
    }
}
```

## Step 9: Update the manage navigation menu

Add a link to the passkey management page in the app's `ManageNavMenu` component.

In `Components/Account/Shared/ManageNavMenu.razor`:

```diff
+ <li class="nav-item">
+     <NavLink class="nav-link" href="Account/Manage/Passkeys">Passkeys</NavLink>
+ </li>
```

## Step 10: Include the JavaScript file

In the `App` component, add a reference to the `PasskeySubmit` JavaScript file after the Blazor script.

In `Components/App.razor`:

```diff
<script src="_framework/blazor.web.js"></script>
+ <script src="Components/Account/Shared/PasskeySubmit.razor.js" type="module"></script>
```

## Step 11: Test the implementation

* Run the app and navigate to the login page.
* Test logging in with a passkey using the **Log in with a passkey** button.
* Navigate to `Account/Manage/Passkeys` to add, rename, or delete passkeys.
* Test the passkey autofill feature by selecting the email input field when you have saved passkeys.

## Additional resources

* [Web Authentication API (MDN documentation)](https://developer.mozilla.org/docs/Web/API/Web_Authentication_API)
* [Get started with phishing-resistant passwordless authentication deployment in Microsoft Entra ID](/entra/identity/authentication/how-to-plan-prerequisites-phishing-resistant-passwordless-authentication)
* [Passkeys configuration guidance](xref:blazor/security/passkeys#configure-passkey-options)
