---
title: Implement passkeys in an existing ASP.NET Core Razor Pages or MVC app
author: guardrex
description: Learn how to implement passkeys authentication in an ASP.NET Core Razor Pages or MVC app.
ms.author: wpickett
ms.custom: mvc
ms.date: 8/14/2025
uid: security/authentication/passkeys-migration
---
# Implement passkeys in an existing Razor Pages or MVC app

This guide walks through adding passkey support to an existing Razor Pages or MVC app that already has ASP.NET Core Identity authentication configured.

The guidance in this article relies upon an app that was created with **Individual Accounts** for the app's **Authentication type** or [scaffolding Identity into an existing app](xref:security/authentication/scaffold-identity).

## Prerequisites

<!-- UPDATE 10.0 - Remove preview link in favor of the download link ...

* [.NET SDK](https://dotnet.microsoft.com/download) (.NET 10 or later)

-->

* An existing Razor Pages or MVC app with ASP.NET Core Identity
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

Add the following model classes to the project.

`PasskeyInputModel.cs`:

```csharp
public class PasskeyInputModel
{
    public string? CredentialJson { get; set; }
    public string? Error { get; set; }
}
```

`PasskeyOperation.cs`:

```csharp
public enum PasskeyOperation
{
    Create = 0,
    Request = 1,
}
```

## Step 4: Create a UI component to handle passkey operations

*The implementation must be supplied by the developer at this time.*

## Step 5: Add the JavaScript for passkey operations

Add the following JavaScript file to handle WebAuthn API interactions.

`PasskeySubmit.js`:

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

*The implementation must be supplied by the developer at this time.*

## Step 8: Create passkey management pages for adding, deleting, and renaming passkeys

*The implementation must be supplied by the developer at this time.*

## Step 9: Update the manage navigation menu

*The implementation must be supplied by the developer at this time.*

Add a link to the passkey management page in the app's navigation menu.

## Step 10: Include the JavaScript file

*The implementation must be supplied by the developer at this time.*

Add a reference to the `PasskeySubmit` JavaScript file:

```html
<script src="PasskeySubmit.js" type="module"></script>
```

## Step 11: Test the implementation

* Run the app and navigate to the login page.
* Test logging in with a passkey.
* Navigate to passkeys management page to add, rename, or delete passkeys.
* Test the passkey autofill feature by selecting the email input field when you have saved passkeys.

## Additional resources

* [Web Authentication API (MDN documentation)](https://developer.mozilla.org/docs/Web/API/Web_Authentication_API)
* [Get started with phishing-resistant passwordless authentication deployment in Microsoft Entra ID](/entra/identity/authentication/how-to-plan-prerequisites-phishing-resistant-passwordless-authentication)
* [Passkeys configuration guidance](xref:blazor/security/passkeys#configure-passkey-options)
