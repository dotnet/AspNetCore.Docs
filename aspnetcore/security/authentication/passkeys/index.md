---
title: Enable Web Authentication API (WebAuthn) passkeys
author: guardrex
description: Discover how to enable Web Authentication API (WebAuthn) passkeys in ASP.NET Core apps.
ms.author: wpickett
monikerRange: '>= aspnetcore-10.0'
ms.custom: mvc
ms.date: 09/10/2025
uid: security/authentication/passkeys/index
---
# Enable Web Authentication API (WebAuthn) passkeys

<!-- UPDATE 11.0 - Activate the not-latest-version file.

[!INCLUDE[](~/includes/not-latest-version.md)]
[!INCLUDE[](~/includes/not-latest-version-without-not-supported-content.md)]

-->

<!-- UPDATE 10.0 - API doc cross-links throughout article -->

Passkeys provide a modern, phishing-resistant authentication method based on the [Web Authentication API (WebAuthn)](https://developer.mozilla.org/docs/Web/API/Web_Authentication_API) and [FIDO2](https://www.microsoft.com/security/business/security-101/what-is-fido2) standards. They are a secure alternative to passwords, using public key cryptography and device-based authentication. This article explains how to configure an ASP.NET Core app to use passkeys to authenticate users.

For guidance specific to new and existing Blazor Web Apps, see <xref:security/authentication/passkeys/blazor> after reading this article.

## What are passkeys?

Passkeys are a replacement for passwords that use cryptographic key pairs. The private key is stored securely on the user's device, such as in a hardware security module, platform authenticator (examples: Windows Hello, Touch ID, Face ID), or a password manager, while the public key is stored by the web app. During authentication, the user proves possession of the private key without it ever leaving their device.

Key benefits of passkeys include:

* **Phishing resistance**: Passkeys are bound to specific websites and can't be used on fake sites.
* **No shared secrets**: The server only stores public keys, eliminating the risk of password database breaches.
* **User convenience**: Simple biometric or PIN verification replaces complex password requirements.
* **Cross-device synchronization**: Many passkey providers sync credentials across a user's devices.

For more information, see [Web Authentication API (MDN documentation)](https://developer.mozilla.org/docs/Web/API/Web_Authentication_API).

## Passkeys in ASP.NET Core Identity

ASP.NET Core Identity includes built-in support for passkey registration and authentication:

* Seamless integration with Identity infrastructure.
* User authentication support for the most common WebAuthn scenarios.
* Built into the Blazor Web App project template, so only developer configuration is required.

> [!IMPORTANT]
> The passkey implementation in ASP.NET Core Identity is deliberately scoped to authentication scenarios. It isn't intended as a general-purpose WebAuthn library. Developers requiring full WebAuthn functionality should consider community libraries that provide comprehensive protocol support.

## Supported scenarios

The ASP.NET Core Identity passkey implementation supports the following primary scenarios:

* **Adding passkeys to existing accounts**: Users with password-based accounts can register passkeys as an additional authentication method.
* **Passwordless account creation**: Users can create accounts without a password by registering a passkey on account creation.
* **Passwordless sign-in**: Users can authenticate using only their passkey without entering a password.

## Limitations

The current implementation has the following limitations:

* **Scoped to ASP.NET Core Identity**: The APIs are designed specifically for Identity authentication scenarios.
* **No default attestation validation**: The implementation doesn't validate attestation statements by default.
* **Template support**: Only the Blazor Web App template includes passkey support.
* **No built-in 2FA support**: Passkeys are treated as a primary authentication factor, not as a second factor.

## Core concepts

Two fundamental processes underpin passkey operations: attestation and assertion.

### Attestation (registration)

*Attestation* is the process of creating and registering a new passkey. During attestation, the server generates a unique challenge that the authenticator must include in the returned credential. The authenticator creates a new key pair and returns the public key along with attestation data proving the key's origin. The server then verifies this attestation and stores the public key for future authentication attempts.

### Assertion (authentication)

*Assertion* is the process of authenticating with an existing passkey. The server generates a unique challenge, which the authenticator signs using the private key. The authenticator returns this signed assertion to the server, which verifies the signature using the previously stored public key. If the signature is valid, the user is authenticated.

## Prerequisites

<!-- UPDATE 10.0 - Remove preview link in favor of the download link ...

* [.NET SDK](https://dotnet.microsoft.com/download) (.NET 10 or later)

-->

* [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
* A modern web browser that supports WebAuthn.
* A device with a platform authenticator, such as Windows Hello or Apple secure enclave, or a security key.

## Security considerations

When implementing passkeys in ASP.NET Core Identity, ensure the app meets the security requirements described in this section.

### Host header validation

The implementation infers the Relying Party ID from the host header when `ServerDomain` isn't explicitly configured. The hosting environment must validate host headers to prevent credential-scoping attacks, which involve using compromised or stolen user credentials (usernames, passwords, tokens) to gain unauthorized access.

**Mitigation**: Either explicitly configure `ServerDomain` in `IdentityPasskeyOptions` or ensure that the hosting environment (Kestrel, IIS, reverse proxy) validates host headers. For configuration details, see your hosting platform's documentation.

### Subdomain security

ASP.NET Core's passkeys implementation handles subdomain security through the `ServerDomain` configuration option. When `ServerDomain` isn't explicitly specified, the implementation uses the host header to determine the domain. This means that ***the page on which the passkey was registered controls the domain*** for that credential.

For example:

* If a passkey is registered on `app.contoso.com`, it also works on `*.app.contoso.com`.
* If registered on `contoso.com`, it also works on `*.contoso.com`.
* The browser enforces that passkeys can only be used on the domain (and subdomains) where they were registered.

**Requirement**: Apps requiring strict domain control should explicitly set `ServerDomain` rather than relying on the host header. Don't serve untrusted content on any subdomain within the `ServerDomain` scope. If you can't guarantee this, implement [custom origin validation](https://www.w3.org/TR/webauthn-3/#sctn-validating-origin) to restrict passkey usage to specific origins.

### HTTPS requirement

All passkey operations require HTTPS. The implementation stores authentication data in encrypted and signed cookies that could be intercepted over unencrypted connections.

**Requirement**: Always use HTTPS in production. Configure [HTTP Strict Transport Security Protocol (HSTS)](xref:security/enforcing-ssl#http-strict-transport-security-protocol-hsts) to prevent protocol downgrade attacks.

### Account recovery

Account recovery is primarily a concern for apps that allow passkeys as the only authentication mechanism. The default Blazor Web App project template already requires users to set up a backup authentication method (password or external provider) when creating an account, so account recovery is handled through these existing mechanisms.

**Recommendations**:

For applications implementing passkey-only authentication, consider:

* Recovery codes generated during account creation.
* Email-based recovery flows.
* Mandatory registration of multiple passkeys.
* Monitoring the `IsBackedUp` flag on `UserPasskeyInfo` to prompt users to add additional credentials.

### Administrative controls

When an authenticator model is discovered to have security vulnerabilities, you may need to revoke affected credentials. The implementation stores the complete attestation object with each credential, including the Authenticator Attestation GUID (AAGUID), which is a 128-bit identifier indicating the key type.

**Implementation**: Extract AAGUIDs from stored attestation objects, compare against known-compromised models, and revoke affected credentials. AAGUID reliability depends on whether your app validates attestation statements. To hook in custom attestation statement validation logic, see [Custom attestation statement validation](#custom-attestation-statement-validation). Third-party libraries are available for attestation validation, such as the [Passkeys - FIDO2 .NET Library (WebAuthn) (`passwordless-lib/fido2-net-lib` GitHub repository)](https://github.com/passwordless-lib/fido2-net-lib)&dagger;.

> [!WARNING]
> &dagger;Third-party libraries, including `passwordless-lib/fido2-net-lib`, aren't owned or maintained by Microsoft and aren't covered by any Microsoft Support Agreement or license. Use caution when adopting a third-party library, especially for security features. Confirm that the library follows official specifications and adopts security best practices. Keep the library's version current to obtain the latest bug fixes.

### Resource limits

To prevent database exhaustion attacks, apps should enforce limits on passkey registration, such as:

* Maximum number of passkeys per user account.
* Maximum length for passkey display names.

The Blazor Web App template enforces these limits by default at the application level. For examples, see the following Razor components in the Blazor Web App project template:

* [`Components/Account/Pages/Manage/Passkeys.razor`](https://github.com/dotnet/aspnetcore/blob/main/src/ProjectTemplates/Web.ProjectTemplates/content/BlazorWeb-CSharp/BlazorWebCSharp.1/Components/Account/Pages/Manage/Passkeys.razor)
* [`Components/Account/Pages/Manage/RenamePasskey.razor`](https://github.com/dotnet/aspnetcore/blob/main/src/ProjectTemplates/Web.ProjectTemplates/content/BlazorWeb-CSharp/BlazorWebCSharp.1/Components/Account/Pages/Manage/RenamePasskey.razor)

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

## Configure passkey options

ASP.NET Core Identity provides various options to configure passkey behavior through the `IdentityPasskeyOptions` class, which include:

* `AuthenticatorTimeout`: Gets or sets the time that the browser should wait for the authenticator to provide a passkey as a <xref:System.TimeSpan>. This option applies to both creating a new passkey and requesting an existing passkey. This option is treated as a hint to the browser, and the browser may ignore the option. The default value is 5 minutes.
* `ChallengeSize`: Gets or sets the size of the challenge in bytes sent to the client during attestation and assertion. This option applies to both creating a new passkey and requesting an existing passkey. The default value is 32 bytes.
* `ServerDomain`: Gets or sets the effective Relying Party ID (domain) of the server. This should be unique and will be used as the identity for the server. This option applies to both creating a new passkey and requesting an existing passkey. If `null`, which is the default value, the server's origin is used. For more information, see [Relying Party Identifier RP ID](https://www.w3.org/TR/webauthn-3/#rp-id).

Example configuration:

```csharp
builder.Services.Configure<IdentityPasskeyOptions>(options =>
{
    options.ServerDomain = "contoso.com";
    options.AuthenticatorTimeout = TimeSpan.FromMinutes(3);
    options.ChallengeSize = 64;
});
```

<!-- UPDATE 10.0 - Swap for the following ref source content.

For a complete list of configuration options, see <xref:Microsoft.AspNetCore.Identity.IdentityPasskeyOptions%2A>.

-->

For a complete list of configuration options during the .NET 10 preview release period, see the [`IdentityPasskeyOptions` reference source (`dotnet/aspnetcore` GitHub repository)](https://github.com/dotnet/aspnetcore/blob/main/src/Identity/Core/src/IdentityPasskeyOptions.cs).

> [!NOTE]
> Documentation links to .NET reference source usually load the repository's default branch, which represents the current development for the next preview release of .NET. To select a tag for a specific release, use the **Switch branches or tags** dropdown list. For more information, see [How to select a version tag of ASP.NET Core source code (`dotnet/AspNetCore.Docs` #26205)](https://github.com/dotnet/AspNetCore.Docs/discussions/26205).

> [!NOTE]
> The browser defaults mentioned in the API documentation were valid as of August, 2025. See the [W3C WebAuthn specification](https://www.w3.org/TR/webauthn-3/) for the most up-to-date defaults.

## Custom attestation statement validation

By default, ASP.NET Core Identity doesn't validate attestation statements. This is suitable for most consumer authentication scenarios. If your app requires verification of authenticator properties or if you want to disallow specific authenticators from being used, for example, in enterprise environments that require a higher level of security, you can implement custom attestation validation:

```csharp
builder.Services.Configure<IdentityPasskeyOptions>(options =>
{
    options.VerifyAttestationStatement = async (context) =>
    {
        // Custom attestation validation logic
        // Return 'true' if the attestation is valid
        // Return 'false' if the attestation is invalid
        return true;
    };
});
```

> [!WARNING]
> Attestation validation is complex and requires maintaining trust stores for authenticator certificates. Only implement custom validation if your app requires verification of specific authenticator properties.

## Custom origin validation

The default origin validation allows requests from subdomains and disallows cross-origin iframes. To customize this behavior:

```csharp
builder.Services.Configure<IdentityPasskeyOptions>(options =>
{
    options.ValidateOrigin = async (context) =>
    {
        // Custom origin validation logic
        //   Access the origin via 'context.Origin'
        //   Access the HTTP context via 'context.HttpContext'
        // Return 'true' if the origin is valid
        // Return 'false' if the origin is invalid
        return true;
    };
});
```

## Registration flow

This section walks through each step of the passkey registration process, explaining how ASP.NET Core Identity facilitates the creation and storage of passkey credentials.

```mermaid
sequenceDiagram
    participant Authenticator
    participant User
    participant Browser
    participant Server

    User->>Browser: Click "Add passkey"
    Browser->>Server: Request creation options
    Server->>Browser: Return creation options
    Browser->>Authenticator: Request new credential
    Authenticator->>User: Verify identity (biometric/PIN)
    User->>Authenticator: Approve
    Authenticator->>Browser: Return credential
    Browser->>Server: Submit credential
    Server->>Server: Verify and store
    Server->>Browser: Registration complete
    Browser->>User: Success message
```

### Step 1: Initiating registration

The registration process begins when a user decides to add a passkey to their account. This typically happens through a button or link in the app's user interface. When selected, this element triggers JavaScript code to orchestrate the registration flow.

The client-side implementation varies significantly between apps. In the Blazor Web App template, you can find a complete example in `PasskeySubmit.razor.js`, which shows how a custom web component handles the registration initiation and manages the subsequent WebAuthn API calls.

### Step 2: Requesting creation options

After registration is initiated, the browser must obtain creation options from the server. These options tell the browser what kind of credential to create and include important security parameters, such as the challenge that must be signed.

From the browser's perspective, this step involves making an HTTP request to the server:

```javascript
async function createCredential(headers, signal) {
  // Step 2: Request creation options from the server
  const optionsResponse = 
    await fetchWithErrorHandling('/Account/PasskeyCreationOptions', 
    {
      method: 'POST',
      headers,
      signal,
    });
  const optionsJson = await optionsResponse.json();
  const options = PublicKeyCredential.parseCreationOptionsFromJSON(optionsJson);
  return await navigator.credentials.create({ publicKey: options, signal });
}
```

The application should define an endpoint that generates these options:

```csharp
app.MapPost("/Account/PasskeyCreationOptions", async (
    HttpContext context,
    UserManager<ApplicationUser> userManager,
    SignInManager<ApplicationUser> signInManager) =>
{
    var user = await userManager.GetUserAsync(context.User);

    if (user is null)
    {
        return Results.NotFound();
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
```

The `MakePasskeyCreationOptionsAsync` method is central to this process. The method accepts a `PasskeyUserEntity` that describes the user for whom the passkey is being created. This entity contains the user's ID, username (typically an email address), and a human-readable display name. The method returns a JSON string that conforms to the WebAuthn `PublicKeyCredentialCreationOptions` schema, which the browser uses in the next step. Behind the scenes, this method also stores temporary state in an authentication cookie to ensure that the response from the browser corresponds to these specific options.

### Step 3: Server generates options

When `MakePasskeyCreationOptionsAsync` executes, it uses the app's `IdentityPasskeyOptions` configuration to determine the specific parameters for credential creation. These options control various aspects of the passkey creation process.

You can customize these options during application startup. For example:

```csharp
builder.Services.Configure<IdentityPasskeyOptions>(options =>
{
    options.ServerDomain = "contoso.com";
    options.AuthenticatorTimeout = TimeSpan.FromMinutes(3);
    options.UserVerificationRequirement = "required";
    options.ResidentKeyRequirement = "preferred";
});
```

The `UserVerificationRequirement` option determines whether the authenticator must verify the user's identity (through biometric or PIN methods), while `ResidentKeyRequirement` indicates whether the credential should be discoverable, allowing authentication without first providing a username. For more information during the .NET 10 preview release period, see the [`IdentityPasskeyOptions` reference source (`dotnet/aspnetcore` GitHub repository)](https://github.com/dotnet/aspnetcore/blob/main/src/Identity/Core/src/IdentityPasskeyOptions.cs).

<!-- UPDATE 10.0 - Be sure to swap the last line out for the API doc cross-link 

For more information, see <xref:Microsoft.AspNetCore.Identity.IdentityPasskeyOptions%2A>.
-->

### Step 4: Client requests credential

With the creation options available, the client-side JavaScript passes the options to the WebAuthn API to create a new credential:

```javascript
async function createCredential(headers, signal) {
  // Step 4: Parse the options and request a new credential from the authenticator
  const optionsResponse = 
    await fetchWithErrorHandling('/Account/PasskeyCreationOptions', 
    {
      method: 'POST',
      headers,
      signal,
    });
  const optionsJson = await optionsResponse.json();
  const options = PublicKeyCredential.parseCreationOptionsFromJSON(optionsJson);
  return await navigator.credentials.create({ publicKey: options, signal });
}
```

The `parseCreationOptionsFromJSON` function converts the JSON response into the format expected by the WebAuthn API, and `navigator.credentials.create()` initiates the credential creation process with the authenticator.

### Step 5: Authenticator interaction

At this point, the browser communicates with the authenticator to create the credential. The authenticator prompts the user for verification, which might involve scanning a fingerprint, entering a PIN, or using facial recognition. This interaction is handled entirely by the browser and the authenticator, requiring no app code. The user experience varies depending on the type of authenticator and the platform's capabilities.

### Step 6: Credential submission

After the authenticator creates the credential, the browser must send the credential back to the server for verification and storage. The credential must be serialized to JSON before submission:

```javascript
async function createCredential(headers, signal) {
  // Step 6: The credential is returned from navigator.credentials.create()
  // and is serialized to JSON for submission to the server
  const optionsResponse = 
    await fetchWithErrorHandling('/Account/PasskeyCreationOptions', 
    {
      method: 'POST',
      headers,
      signal,
    });
  const optionsJson = await optionsResponse.json();
  const options = PublicKeyCredential.parseCreationOptionsFromJSON(optionsJson);
  return await navigator.credentials.create({ publicKey: options, signal });
}
```

In the Blazor Web App template, the returned credential is automatically serialized and submitted through a form, but the exact submission mechanism varies by application.

### Step 7: Server verification and storage

When the server receives the credential, it must verify its validity and store the public key for future authentication. This is where ASP.NET Core Identity's passkey APIs become crucial.

The `PerformPasskeyAttestationAsync` method validates the attestation response from the client. This comprehensive validation process:

* Verifies that the credential type matches expectations.
* Validates the client data JSON including origin and challenge.
* Checks authenticator data flags for user presence and verification
* Extracts and validates the public key.

If all checks pass, the method returns a `PasskeyAttestationResult` containing the verified passkey information.

After the attestation is verified, the app uses `AddOrUpdatePasskeyAsync` to store the passkey in the database:

```csharp
var attestationResult = 
    await signInManager.PerformPasskeyAttestationAsync(credentialJson);

if (!attestationResult.Succeeded)
{
    return Results.BadRequest($"Error: {attestationResult.Failure.Message}");
}

var addResult = 
    await userManager.AddOrUpdatePasskeyAsync(user, attestationResult.Passkey);

if (!addResult.Succeeded)
{
    return Results.BadRequest("Failed to store passkey");
}
```

The stored `UserPasskeyInfo` contains all of the necessary information for future authentication, including the credential ID, public key, signature counter for replay protection, and flags indicating whether the passkey is backed up or eligible for backup.

### Step 8: Post-registration tasks

After successfully registering a passkey, apps often perform additional tasks to improve the user experience. A common pattern is to prompt users to provide a friendly name for their passkey, making it easier to identify among multiple credentials. The `UserPasskeyInfo.Name` property stores this user-friendly name, which can be updated using the same `AddOrUpdatePasskeyAsync` method:

```csharp
passkey.Name = "My iPhone";
await userManager.AddOrUpdatePasskeyAsync(user, passkey);
```

## Authentication flow

This section explains how users authenticate with their passkeys, from initiating the sign-in process to establishing an authenticated session.

```mermaid
sequenceDiagram
    participant Authenticator
    participant User
    participant Browser
    participant Server

    User->>Browser: Click "Sign in with passkey"
    Browser->>Server: Request authentication options
    Server->>Browser: Return authentication options
    Browser->>Authenticator: Request assertion
    Authenticator->>User: Verify identity
    User->>Authenticator: Approve
    Authenticator->>Browser: Return signed assertion
    Browser->>Server: Submit assertion
    Server->>Server: Verify signature
    Server->>Browser: Authentication complete
    Browser->>User: Redirect to app
```

### Step 1: Initiating authentication

Users typically initiate passkey authentication through a dedicated button or link on the login page. Some apps also support conditional UI, where passkeys appear as autofill suggestions in the username field. The initiation method triggers JavaScript code that manages the authentication flow, similar to the registration process.

### Step 2: Requesting authentication options

The browser requests authentication options from the server to begin the authentication process. These options include a list of acceptable credentials and a new challenge to be signed:

```javascript
async function requestCredential(email, mediation, headers, signal) {
  // Step 2: Request authentication options from the server
  const optionsResponse = 
    await fetchWithErrorHandling(`/Account/PasskeyRequestOptions?username=${email}`, 
    {
      method: 'POST',
      headers,
      signal,
    });
  const optionsJson = await optionsResponse.json();
  const options = PublicKeyCredential.parseRequestOptionsFromJSON(optionsJson);
  return await navigator.credentials.get({ publicKey: options, mediation, signal });
}
```

The `MakePasskeyRequestOptionsAsync` method generates these options. When you provide a specific user, it includes only that user's credentials in the allow list. When called without a user, it generates options suitable for conditional UI or username-less authentication:

```csharp
app.MapPost("/Account/PasskeyRequestOptions", async (
    SignInManager<ApplicationUser> signInManager,
    string? username) =>
{
    var user = string.IsNullOrEmpty(username) 
        ? null 
        : await userManager.FindByNameAsync(username);

    var optionsJson = await signInManager.MakePasskeyRequestOptionsAsync(user);

    return TypedResults.Content(optionsJson, contentType: "application/json");
});
```

### Step 3: Server generates options

The server generates authentication options using the same `IdentityPasskeyOptions` configuration used during registration. The `ServerDomain` must match the domain where the passkey was originally registered, or authentication fails. The `UserVerificationRequirement` determines whether the authenticator must verify the user's identity during authentication.

### Step 4: Client requests assertion

The client-side JavaScript passes the authentication options to the WebAuthn API to request an assertion from the authenticator:

```javascript
async function requestCredential(email, mediation, headers, signal) {
  // Step 4: Parse the options and request an assertion from the authenticator
  const optionsResponse = 
    await fetchWithErrorHandling(`/Account/PasskeyRequestOptions?username=${email}`, 
    {
      method: 'POST',
      headers,
      signal,
    });
  const optionsJson = await optionsResponse.json();
  const options = PublicKeyCredential.parseRequestOptionsFromJSON(optionsJson);
  return await navigator.credentials.get({ publicKey: options, mediation, signal });
}
```

The `navigator.credentials.get()` call initiates the authentication process with the authenticator, which prompts the user for verification.

### Step 5: Authenticator verification

The authenticator verifies the user's identity and signs the challenge with the private key. This process is handled entirely by the browser and authenticator, similar to the verification step during registration. The user experience depends on the authenticator type and may involve biometric verification or PIN entry.

### Step 6: Assertion submission

After the authenticator creates the signed assertion, the browser serializes it to JSON and submits it to the server:

```javascript
async function requestCredential(email, mediation, headers, signal) {
  // Step 6: The assertion is returned from navigator.credentials.get()
  // and is serialized to JSON for submission to the server
  const optionsResponse = 
    await fetchWithErrorHandling(`/Account/PasskeyRequestOptions?username=${email}`, 
    {
      method: 'POST',
      headers,
      signal,
    });
  const optionsJson = await optionsResponse.json();
  const options = PublicKeyCredential.parseRequestOptionsFromJSON(optionsJson);
  return await navigator.credentials.get({ publicKey: options, mediation, signal });
}
```

The submission mechanism varies by app but typically involves either a form submission or an API call.

### Step 7: Server verification

The server verifies the assertion to authenticate the user. ASP.NET Core Identity provides the `PasskeySignInAsync` method, which performs the complete authentication flow in a single call:

```csharp
var result = await signInManager.PasskeySignInAsync(credentialJson);

if (result.Succeeded)
{
    return Results.Ok("Authentication successful");
}

return Results.Unauthorized();
```

The `PasskeySignInAsync` method internally calls `PerformPasskeyAssertionAsync` to:

* Validate the assertion signature using the stored public key.
* Verify that the challenge matches the one originally sent.
* Check authenticator flags for user presence and verification.
* Update the signature counter to prevent replay attacks.

If all checks pass, the method signs in the user and returns a `SignInResult` indicating success.

For scenarios requiring more control, you can use `PerformPasskeyAssertionAsync` directly to validate the assertion without immediately signing in the user:

* `PerformPasskeyAssertionAsync` returns a `PasskeyAssertionResult<TUser>` containing the authenticated user and updated passkey information.
* Because the passkey's sign-in count and authenticator flags may have changed since the last assertion and the updated passkey isn't automatically stored when calling `PerformPasskeyAssertionAsync`, call `userManager.AddOrUpdatePasskeyAsync` with the returned `PasskeyAssertionResult<TUser>`.

### Step 8: Session establishment

Upon successful authentication, ASP.NET Core Identity establishes an authenticated session for the user. The `PasskeySignInAsync` method handles this automatically, creating the necessary authentication cookies and claims. The app then redirects the user to protected resources or display personalized content.

## Mitigate `PublicKeyCredential.toJSON` error (`TypeError: Illegal invocation`)

The [`PublicKeyCredential.toJSON` method](https://developer.mozilla.org/docs/Web/API/PublicKeyCredential/toJSON) returns a JSON representation of a [`PublicKeyCredential`](https://developer.mozilla.org/docs/Web/API/PublicKeyCredential). The method is invoked by the password manager when the app attempts to serialize a `PublicKeyCredential` by calling [`JSON.stringify`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/JSON/stringify) while registering or authenticating a user.

Some password managers don't implement the `PublicKeyCredential.toJSON` method correctly, which is required for `JSON.stringify` to work when serializing passkey credentials. When registering or authenticating a user with an app based on the Blazor Web App project template, the following error is thrown by some password managers when attempting to add a passkey:

> :::no-loc text="Error: Could not add a passkey: Illegal invocation":::

Until your selected password manager is updated to implement the `PublicKeyCredential.toJSON` method correctly, make the following changes to the app. The following code manually JSON serializes the `PublicKeyCredential`.

In the `Components/Account/Shared/PasskeySubmit.razor.js` file, locate the `passkey-submit` custom element definition code block:

```javascript
customElements.define('passkey-submit', class extends HTMLElement {
  ...
});
```

Add the following `convertToBase64` function to the code block:

```javascript
convertToBase64(o) {
  if (!o) {
    return undefined;
  }

  // Normalize Array to Uint8Array
  if (Array.isArray(o)) {
    o = Uint8Array.from(o);
  }

  // Normalize ArrayBuffer to Uint8Array
  if (o instanceof ArrayBuffer) {
    o = new Uint8Array(o);
  }

  // Convert Uint8Array to base64
  if (o instanceof Uint8Array) {
    let str = '';
    for (let i = 0; i < o.byteLength; i++) {
      str += String.fromCharCode(o[i]);
    }
    o = window.btoa(str);
  }

  if (typeof o !== 'string') {
    throw new Error("Could not convert to base64 string");
  }

  // Convert base64 to base64url
  o = o.replace(/\+/g, "-").replace(/\//g, "_").replace(/=*$/g, "");

  return o;
}
```

In the `obtainAndSubmitCredential` function of the code block, locate the line that calls `JSON.stringify` with the user's credential and remove the line:

```diff
- const credentialJson = JSON.stringify(credential);
```

Replace the preceding line with the following code:

```javascript
const credentialJson = JSON.stringify({
  authenticatorAttachment: credential.authenticatorAttachment,
  clientExtensionResults: credential.getClientExtensionResults(),
  id: credential.id,
  rawId: this.convertToBase64(credential.rawId),
  response: {
    attestationObject: this.convertToBase64(credential.response.attestationObject),
    authenticatorData: this.convertToBase64(credential.response.authenticatorData ?? 
      credential.response.getAuthenticatorData?.() ?? undefined),
    clientDataJSON: this.convertToBase64(credential.response.clientDataJSON),
    publicKey: this.convertToBase64(credential.response.getPublicKey?.() ?? undefined),
    publicKeyAlgorithm: credential.response.getPublicKeyAlgorithm?.() ?? undefined,
    transports: credential.response.getTransports?.() ?? undefined,
    signature: this.convertToBase64(credential.response.signature),
    userHandle: this.convertToBase64(credential.response.userHandle),
  },
  type: credential.type,
});
```

The preceding workaround is only required until the password manager is updated to implement the `PublicKeyCredential.toJSON` method correctly. We recommend tracking your password manager's release notes and reverting the preceding changes after the password manager is updated.

## Additional resources

* [Web Authentication API (MDN documentation)](https://developer.mozilla.org/docs/Web/API/Web_Authentication_API)
* [Get started with phishing-resistant passwordless authentication deployment in Microsoft Entra ID](/entra/identity/authentication/how-to-plan-prerequisites-phishing-resistant-passwordless-authentication)
