---
title: Enable QR code generation for TOTP authenticator apps in ASP.NET Core Blazor WebAssembly with ASP.NET Core Identity
author: guardrex
description: Learn how to configure an ASP.NET Core Blazor WebAssembly app with Identity for QR code generation with TOTP authenticator app.
ms.author: riande
monikerRange: '>= aspnetcore-8.0'
ms.date: 11/20/2024
uid: blazor/security/webassembly/standalone-with-identity/qrcodes-for-authenticator-apps
---
# Enable QR code generation for TOTP authenticator apps in ASP.NET Core Blazor WebAssembly with ASP.NET Core Identity

[!INCLUDE[](~/includes/not-latest-version-without-not-supported-content.md)]

This article explains how to configure an ASP.NET Core Blazor WebAssembly app with Identity for QR code generation with TOTP authenticator app.

> [!NOTE]
> This article only applies standalone Blazor WebAssembly apps with ASP.NET Core Identity. To implement QR code generation for Blazor Web Apps, see <xref:blazor/security/qrcodes-for-authenticator-apps>.

For an introduction to two-factor authentication (2FA) with authenticator apps using a Time-based One-time Password Algorithm (TOTP), see <xref:security/authentication/identity-enable-qrcodes>.

> [!WARNING]
> An ASP.NET Core TOTP code should be kept secret because it can be used to authenticate successfully multiple times before it expires.

## Two-factor/TOTP processing

... EXPLAIN API BASICS HERE ...

## Namespace

The namespaces used by the examples in this article are:

* `Backend` for the backend server web API project ("server project" in this article).
* `BlazorWasmAuth` for the front-end client standalone Blazor WebAssembly app ("client project" in this article).

These namespaces correspond to the projects in the `BlazorWebAssemblyStandaloneWithIdentity` sample solution in the [`dotnet/blazor-samples` GitHub repository](https://github.com/dotnet/blazor-samples). For more information, see <xref:blazor/security/webassembly/standalone-with-identity/index#sample-apps>.

If you aren't using the `BlazorWebAssemblyStandaloneWithIdentity` sample solution, change the namespaces in the code examples to use the namespaces of your projects.

**All of the changes to the app covered by this article outside of the *Configure account confirmation and password recovery* section take place in the `BlazorWasmAuth` project.**

## Configure account confirmation and password recovery

Follow the guidance in <xref:blazor/security/webassembly/standalone-with-identity/account-confirmation-and-password-recovery> to establish account confirmation and password recovery features:

* [Select and configure an email provider for the server project](xref:blazor/security/webassembly/standalone-with-identity/account-confirmation-and-password-recovery#select-and-configure-an-email-provider-for-the-server-project)
* [Configure a user secret for the provider's security key](xref:blazor/security/webassembly/standalone-with-identity/account-confirmation-and-password-recovery#configure-a-user-secret-for-the-providers-security-key)
* [Implement `IEmailSender` in the server project](xref:blazor/security/webassembly/standalone-with-identity/account-confirmation-and-password-recovery#implement-iemailsender-in-the-server-project)

Two-factor authentication doesn't strictly require account confirmation and password recovery features, so you aren't required to adopt the remaining guidance in the cross-linked article.

## Adding QR codes to the app

These instructions use [Shim Sangmin](https://hogangnono.com)'s [qrcode.js: Cross-browser QRCode generator for JavaScript](https://davidshimjs.github.io/qrcodejs/) ([`davidshimjs/qrcodejs` GitHub repository](https://github.com/davidshimjs/qrcodejs)).

Download the [`qrcode.min.js`](https://davidshimjs.github.io/qrcodejs/) library to the `wwwroot` folder of the `BlazorWasmAuth` project. The library has no dependencies.

## Set the TOTP organization name

Set the site name in the app settings file of the `BlazorWasmAuth` project. Use a meaningful site name that users can identify easily in their authenticator app. Developers usually set a site name that matches the company's name. Examples: Yahoo, Amazon, Etsy, Microsoft, Zoho. We recommend limiting the site name length to 30 characters or less to allow the site name to display on narrow mobile device screens.

In the following example, the the company name is `Weyland-Yutani Corporation` (&copy;1986 20th Century Studios [*Aliens*](https://www.20thcenturystudios.com/movies/aliens)).

Added to `wwwroot/appsettings.json` of the `BlazorWasmAuth` project:

```json
"TotpOrganizationName": "Weyland-Yutani Corporation"
```

The file after the configuration key-value are added:

```json
{
  "BackendUrl": "https://localhost:7211",
  "FrontendUrl": "https://localhost:7171",
  "TotpOrganizationName": "Weyland-Yutani Corporation"
}
```

## `TwoFactorResult` model

Add the following `TwoFactorResult` class to the `Models` folder.

`Identity/Models/TwoFactorResult.cs`:

```csharp
namespace BlazorWasmAuth.Identity.Models
{
    /// <summary>
    /// Response for login and registration.
    /// </summary>
    public class TwoFactorResult
    {
        /// <summary>
        /// Gets or sets a value indicating the shared key.
        /// </summary>
        public string SharedKey { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating the number of remaining recovery codes.
        /// </summary>
        public int RecoveryCodesLeft { get; set; } = 0;

        /// <summary>
        /// Gets or sets a value indicating the recovery codes.
        /// </summary>
        public string[] RecoveryCodes { get; set; } = [];

        /// <summary>
        /// Gets or sets a value indicating if two-factor authentication is enabled.
        /// </summary>
        public bool IsTwoFactorEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating if the machine is remembered.
        /// </summary>
        public bool IsMachineRemembered { get; set; }

        /// <summary>
        /// On failure, the problem details are parsed and returned in this array.
        /// </summary>
        public string[] ErrorList { get; set; } = [];
    }
}
```

## `IAccountManagement` interface

Add the following class signatures to the `IAccountManagment` interface.

`Identity/IAccountManagement.cs` (paste the following code at the bottom of the interface):

```csharp
/// <summary>
/// Login service with two-factor authentication.
/// </summary>
/// <param name="email">User's email.</param>
/// <param name="password">User's password.</param>
/// <param name="twoFactorCode">User's 2FA code.</param>
/// <returns>The result of the request serialized to <see cref="FormResult"/>.</returns>
public Task<FormResult> LoginTwoFactorCodeAsync(
    string email, 
    string password, 
    string twoFactorCode);

/// <summary>
/// Initial POST request to the two-factor authentication endpoint.
/// </summary>
/// <param name="enable">A flag indicating 2FA status.</param>
/// <param name="twoFactorCode">The two-factor authentication code supplied by the user's 2FA app.</param>
/// <param name="resetSharedKey">A flag indicating if the shared key should be reset.</param>
/// <param name="resetRecoveryCodes">A flag indicating if the recovery codes should be reset.</param>
/// <param name="forgetMachine">A flag indicating if the machine should be forgotten.</param>
/// <returns>The result serialized to a <see cref="TwoFactorResult"/>.</returns>
public Task<TwoFactorResult> TwoFactorRequest(
    bool enable = false, 
    string twoFactorCode = "", 
    bool resetSharedKey = false, 
    bool resetRecoveryCodes = false, 
    bool forgetMachine = false);

/// <summary>
/// Login service with two-factor recovery authentication.
/// </summary>
/// <param name="email">User's email.</param>
/// <param name="password">User's password.</param>
/// <param name="twoFactorRecoveryCode">User's 2FA recovery code.</param>
/// <returns>The result of the request serialized to <see cref="FormResult"/>.</returns>
public Task<FormResult> LoginTwoFactorRecoveryCodeAsync(
    string email, 
    string password, 
    string twoFactorRecoveryCode);
```

## `CookieAuthenticationStateProvider`

Replace the `LoginAsync` method with the following code in `Identity/CookieAuthenticationStateProvider.cs`:

```csharp
public async Task<FormResult> LoginAsync(string email, string password)
{
    try
    {
        // login with cookies
        var result = await httpClient.PostAsJsonAsync(
            "login?useCookies=true", new
            {
                email,
                password
            });

        // success?
        if (result.IsSuccessStatusCode)
        {
            // need to refresh auth state
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());

            // success!
            return new FormResult { Succeeded = true };
        }
        else if (result.StatusCode == HttpStatusCode.Unauthorized)
        {
            var responseJson = await result.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<HttpResponseContent>(
                responseJson, jsonSerializerOptions);

            if (response?.Detail == "RequiresTwoFactor")
            {
                return new FormResult
                {
                    Succeeded = false,
                    ErrorList = ["RequiresTwoFactor"]
                };
            }
        }
    }
    catch { }

    // unknown error
    return new FormResult
    {
        Succeeded = false,
        ErrorList = [ "Invalid email and/or password." ]
    };
}
```

Add the following methods and class to `Identity/CookieAuthenticationStateProvider.cs` (paste the following code at the bottom of the class file):

```csharp
/// <summary>
/// User login with two-factor authentication.
/// </summary>
/// <param name="email">The user's email address.</param>
/// <param name="password">The user's password.</param>
/// <param name="twoFactorCode">The user's password.</param>
/// <returns>
///     The result of the login request serialized to a <see cref="FormResult"/>.
/// </returns>
public async Task<FormResult> LoginTwoFactorCodeAsync(
    string email, string password, string twoFactorCode)
{
    try
    {
        // login with cookies
        var result = await httpClient.PostAsJsonAsync(
            "login?useCookies=true", new
            {
                email,
                password,
                twoFactorCode
            });

        // success?
        if (result.IsSuccessStatusCode)
        {
            // need to refresh auth state
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());

            // success!
            return new FormResult { Succeeded = true };
        }
    }
    catch { }

    // unknown error
    return new FormResult
    {
        Succeeded = false,
        ErrorList = [ "Invalid email, password, or two-factor code."]
    };
}

/// <summary>
/// Initial POST request to the two-factor authentication endpoint.
/// </summary>
/// <param name="enable">A flag indicating 2FA status.</param>
/// <param name="twoFactorCode">
///     The two-factor authentication code supplied by the user's 2FA app.
/// </param>
/// <param name="resetSharedKey">
///     A flag indicating if the shared key should be reset.
/// </param>
/// <param name="resetRecoveryCodes">
///    A flag indicating if the recovery codes should be reset.
/// </param>
/// <param name="forgetMachine">
///     A flag indicating if the machine should be forgotten.
/// </param>
/// <returns>The result serialized to a <see cref="TwoFactorResult"/>.</returns>
public async Task<TwoFactorResult> TwoFactorRequest(
    bool enable,
    string twoFactorCode,
    bool resetSharedKey,
    bool resetRecoveryCodes,
    bool forgetMachine)
{
    string[] defaultDetail = 
        [ "An unknown error prevented two-factor authentication." ];

    try
    {
        HttpResponseMessage response;

        if (resetSharedKey)
        {
            response = await httpClient.PostAsJsonAsync("manage/2fa", 
                new { enable, resetSharedKey });
        }
        else if (forgetMachine)
        {
            response = await httpClient.PostAsJsonAsync("manage/2fa", 
                new { enable, forgetMachine });
        }
        else if (!string.IsNullOrEmpty(twoFactorCode))
        {
            response = await httpClient.PostAsJsonAsync("manage/2fa", 
                new { enable, twoFactorCode });
        }
        else
        {
            response = await httpClient.PostAsJsonAsync("manage/2fa", 
                new { });
        }

        // successful?
        if (response.IsSuccessStatusCode)
        {
            return await response.Content
                .ReadFromJsonAsync<TwoFactorResult>() ??
                new()
                { 
                    ErrorList = 
                        [ "There was an error processing the request." ]
                };
        }

        // body should contain details about why it failed
        var details = await response.Content.ReadAsStringAsync();
        var problemDetails = JsonDocument.Parse(details);
        var errors = new List<string>();
        var errorList = problemDetails.RootElement.GetProperty("errors");

        foreach (var errorEntry in errorList.EnumerateObject())
        {
            if (errorEntry.Value.ValueKind == JsonValueKind.String)
            {
                errors.Add(errorEntry.Value.GetString()!);
            }
            else if (errorEntry.Value.ValueKind == JsonValueKind.Array)
            {
                errors.AddRange(
                    errorEntry.Value.EnumerateArray().Select(
                        e => e.GetString() ?? string.Empty)
                    .Where(e => !string.IsNullOrEmpty(e)));
            }
        }

        // return the error list
        return new TwoFactorResult
        {
            ErrorList = problemDetails == null ? defaultDetail : [.. errors]
        };
    }
    catch { }

    // unknown error
    return new TwoFactorResult
    {
        ErrorList = [ "There was an error processing the request." ]
    };
}

/// <summary>
/// User login with two-factor authentication.
/// </summary>
/// <param name="email">The user's email address.</param>
/// <param name="password">The user's password.</param>
/// <param name="twoFactorCode">The user's password.</param>
/// <returns>The result of the login request serialized to a <see cref="FormResult"/>.</returns>
public async Task<FormResult> LoginTwoFactorRecoveryCodeAsync(string email, 
    string password, string twoFactorRecoveryCode)
{
    try
    {
        // login with cookies
        var result = await httpClient.PostAsJsonAsync(
            "login?useCookies=true", new
            {
                email,
                password,
                twoFactorRecoveryCode
            });

        // success?
        if (result.IsSuccessStatusCode)
        {
            // need to refresh auth state
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());

            // success!
            return new FormResult { Succeeded = true };
        }
    }
    catch { }

    // unknown error
    return new FormResult
    {
        Succeeded = false,
        ErrorList = [ "Invalid email, password, or two-factor code." ]
    };
}

private class HttpResponseContent
{
    public string? Type { get; set; }
    public string? Title { get; set; }
    public int Status {  get; set; }
    public string? Detail {  get; set; }
}
```

## Replace `Login` component

Replace the `Login` component with the following code.

`Components/Identity/Login.razor`:

```razor
@page "/login"
@using System.ComponentModel.DataAnnotations
@using BlazorWasmAuth.Identity
@using BlazorWasmAuth.Identity.Models
@inject IAccountManagement Acct
@inject ILogger<Login> Logger
@inject NavigationManager Navigation

<PageTitle>Login</PageTitle>

<h1>Login</h1>

<AuthorizeView>
    <Authorized>
        <div class="alert alert-success">
            You're logged in as @context.User.Identity?.Name.
        </div>
    </Authorized>
    <NotAuthorized>
        @foreach (var error in formResult.ErrorList)
        {
            <div class="alert alert-danger">@error</div>
        }
        <div class="row">
            <div class="col">
                <section>
                    <EditForm Model="Input" 
                              method="post" 
                              OnValidSubmit="LoginUser" 
                              FormName="login" 
                              Context="editform_context">
                        <DataAnnotationsValidator />
                        <h2>Use a local account to log in.</h2>
                        <hr />
                        <div style="display:@(requiresTwoFactor ? "none" : "block")">
                            <div class="form-floating mb-3">
                                <InputText 
                                    @bind-Value="Input.Email" 
                                    id="Input.Email" 
                                    class="form-control" 
                                    autocomplete="username" 
                                    aria-required="true" 
                                    placeholder="name@example.com" />
                                <label for="Input.Email" class="form-label">
                                    Email
                                </label>
                                <ValidationMessage 
                                    For="() => Input.Email" 
                                    class="text-danger" />
                            </div>
                            <div class="form-floating mb-3">
                                <InputText 
                                    type="password" 
                                    @bind-Value="Input.Password" 
                                    id="Input.Password" 
                                    class="form-control" 
                                    autocomplete="current-password" 
                                    aria-required="true" 
                                    placeholder="password" />
                                <label for="Input.Password" class="form-label">
                                    Password
                                </label>
                                <ValidationMessage 
                                    For="() => Input.Password" 
                                    class="text-danger" />
                            </div>
                        </div>
                        <div style="display:@(requiresTwoFactor ? "block" : "none")">
                            <div class="form-floating mb-3">
                                <InputText @bind-Value="Input.TwoFactorCode" 
                                    id="Input.TwoFactorCode" class="form-control" 
                                    autocomplete="off" 
                                    placeholder="123456 or 12345-67890" />
                                <label for="Input.TwoFactorCode" class="form-label">
                                    2FA Authenticator code (6 digits) or Recovery 
                                    Code (#####-#####, dash required)
                                </label>
                                <ValidationMessage 
                                    For="() => Input.TwoFactorCode" 
                                    class="text-danger" />
                            </div>
                        </div>
                        <div>
                            <button type="submit" class="w-100 btn btn-lg btn-primary">
                                Log in
                            </button>
                        </div>
                        <div>
                            <p>
                                <a href="forgot-password">Forgot password</a>
                            </p>
                            <p>
                                <a href="register">Register as a new user</a>
                            </p>
                        </div>
                    </EditForm>
                </section>
            </div>
        </div>
    </NotAuthorized>
</AuthorizeView>

@code {
    private FormResult formResult = new();
    private bool requiresTwoFactor;

    [SupplyParameterFromForm]
    private InputModel Input { get; set; } = new();

    [SupplyParameterFromQuery]
    private string? ReturnUrl { get; set; }

    public async Task LoginUser()
    {
        if (requiresTwoFactor)
        {
            if (!string.IsNullOrEmpty(Input.TwoFactorCode))
            {
                if (Input.TwoFactorCode.Length == 6)
                {
                    formResult = await Acct.LoginTwoFactorCodeAsync(
                        Input.Email, Input.Password, Input.TwoFactorCode);
                }
                else
                {
                    formResult = await Acct.LoginTwoFactorRecoveryCodeAsync(
                        Input.Email, Input.Password, Input.TwoFactorCode);
                }
            }
        }
        else
        {
            formResult = await Acct.LoginAsync(Input.Email, Input.Password);
            requiresTwoFactor = formResult.ErrorList.Contains("RequiresTwoFactor");
            Input.TwoFactorCode = string.Empty;
            formResult.ErrorList = [];
        }

        if (formResult.Succeeded && !string.IsNullOrEmpty(ReturnUrl))
        {
            Navigation.NavigateTo(ReturnUrl);
        }
    }

    private sealed class InputModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^([0-9]{6})|([A-Z0-9]{5}[-]{1}[A-Z0-9]{5})$", 
            ErrorMessage = "Must be a six-digit authenticator code (######) or " +
            "eleven-character alphanumeric recovery code (#####-#####, dash " +
            "required)")]
        [Display(Name = "Two-factor code")]
        public string TwoFactorCode { get; set; } = "123456";
    }
}
```

## Show recovery codes component

Add the following `ShowRecoveryCode` component to the app.

`Components/Identity/ShowRecoveryCodes.razor`:

```razor
<h3>Recovery codes</h3>

<div class="alert alert-warning" role="alert">
    <p>
        <strong>Put these codes in a safe place.</strong>
    </p>
    <p>
        If you lose your device and don't have an unused 
        recovery code, you can't access your account.
    </p>
</div>
<div class="row">
    <div class="col-md-12">
        @foreach (var recoveryCode in RecoveryCodes)
        {
            <div>
                <code class="recovery-code">@recoveryCode</code>
            </div>
        }
    </div>
</div>

@code {
    [Parameter]
    public string[] RecoveryCodes { get; set; } = [];
}
```

## Manage 2FA page

Add the following `Manage2fa` component.

`Components/Identity/Manage2fa.razor`:

```razor
@page "/manage-2fa"
@using System.ComponentModel.DataAnnotations
@using System.Globalization
@using System.Text
@using System.Text.Encodings.Web
@using BlazorWasmAuth.Identity
@using BlazorWasmAuth.Identity.Models
@attribute [Authorize]
@implements IAsyncDisposable
@inject IAccountManagement Acct
@inject IAuthorizationService AuthorizationService
@inject IConfiguration Config
@inject IJSRuntime JS
@inject ILogger<Manage2fa> Logger

<PageTitle>Manage 2FA</PageTitle>

<h1>Manage Two-factor Authentication</h1>
<hr />
<div class="row">
    <div class="col">
        @if (twoFactorResult is not null)
        {
            if (twoFactorResult.ErrorList.Length > 0)
            {
                @foreach (var error in twoFactorResult.ErrorList)
                {
                    <div class="alert alert-danger">@error</div>
                }
            }
            else
            {
                @if (twoFactorResult.IsTwoFactorEnabled)
                {
                    <div class="alert alert-success" role="alert">
                        Two-factor authentication is enabled for your account.
                    </div>

                    <button @onclick="Disable2FA" class="btn btn-lg btn-primary">
                        Disable 2FA
                    </button>

                    @if (recoveryCodes is null)
                    {
                        <button @onclick="NewCodes" class="btn btn-lg btn-primary">
                            Generate New Recovery Codes
                        </button>
                    }
                    else
                    {
                        <ShowRecoveryCodes 
                            RecoveryCodes="twoFactorResult.RecoveryCodes.ToArray()" />
                    }
                }
                else
                {
                    <h3>Configure authenticator app</h3>
                    <div>
                        <p>To use an authenticator app:</p>
                        <ol class="list">
                            <li>
                                <p>
                                    Download a two-factor authenticator app, such 
                                    as either of the following:
                                    <ul>
                                        <li>
                                            Microsoft Authenticator for
                                            <a href="https://go.microsoft.com/fwlink/?Linkid=825072">
                                                Android
                                            </a> and
                                            <a href="https://go.microsoft.com/fwlink/?Linkid=825073">
                                                iOS
                                            </a>
                                        </li>
                                        <li>
                                            Google Authenticator for
                                            <a href="https://play.google.com/store/apps/details?id=com.google.android.apps.authenticator2">
                                                Android
                                            </a> and
                                            <a href="https://itunes.apple.com/us/app/google-authenticator/id388497605?mt=8">
                                                iOS
                                            </a>
                                        </li>
                                    </ul>
                                </p>
                            </li>
                            <li>
                                <p>
                                    Scan the QR Code or enter this key 
                                    <kbd>@twoFactorResult.SharedKey</kbd> into your 
                                    two factor authenticator app. Spaces and casing 
                                    don't matter.
                                </p>
                                <div id="qrCode"></div>
                            </li>
                            <li>
                                <p>
                                    Once you have scanned the QR code or input the 
                                    key above, your two factor authentication app 
                                    will provide you with a unique code. Enter the 
                                    code in the confirmation box below.
                                </p>
                                <div class="row">
                                    <div class="col-xl-6">
                                        <EditForm Model="Input" 
                                                  FormName="send-code" 
                                                  OnValidSubmit="OnValidSubmitAsync" 
                                                  method="post">
                                            <DataAnnotationsValidator />
                                            <div class="form-floating mb-3">
                                                <InputText 
                                                    @bind-Value="Input.Code" 
                                                    id="Input.Code" 
                                                    class="form-control" 
                                                    autocomplete="off" 
                                                    placeholder="Enter the code" />
                                                <label for="Input.Code" class="control-label form-label">
                                                    Verification Code
                                                </label>
                                                <ValidationMessage 
                                                    For="() => Input.Code" 
                                                    class="text-danger" />
                                            </div>
                                            <button type="submit" class="w-100 btn btn-lg btn-primary">
                                                Verify
                                            </button>
                                        </EditForm>
                                    </div>
                                </div>
                            </li>
                        </ol>
                    </div>
                }
            }
        }
    </div>
</div>

@code {
    private IEnumerable<string>? recoveryCodes;
    private IJSObjectReference? module;
    private TwoFactorResult twoFactorResult = new();

    [SupplyParameterFromForm]
    private InputModel Input { get; set; } = new();

    [CascadingParameter]
    private Task<AuthenticationState>? authenticationState { get; set; }

    protected override async Task OnInitializedAsync()
    {
        twoFactorResult = await Acct.TwoFactorRequest();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            module = await JS.InvokeAsync<IJSObjectReference>("import",
                "./Components/Identity/Manage2fa.razor.js");

            //twoFactorResult = await Acct.TwoFactorRequest();

            if (authenticationState is not null)
            {
                var authState = await authenticationState;
                var email = authState?.User?.Identity?.Name!;

                var uri = string.Format(
                    CultureInfo.InvariantCulture,
                    "otpauth://totp/{0}:{1}?secret={2}&issuer={0}&digits=6",
                    UrlEncoder.Default.Encode(Config["TotpOrganizationName"]!),
                    email,
                    twoFactorResult.SharedKey);

                await module.InvokeVoidAsync("setQrCode", uri);
            }
        }
    }

    private async Task Disable2FA()
    {
        twoFactorResult = await Acct.TwoFactorRequest(resetSharedKey: true);
    }

    private async Task NewCodes()
    {
        twoFactorResult = await Acct.TwoFactorRequest(resetRecoveryCodes: true);
        recoveryCodes = twoFactorResult.RecoveryCodes;
    }

    private async Task OnValidSubmitAsync()
    {
        twoFactorResult = await Acct.TwoFactorRequest(enable: true, 
            twoFactorCode: Input.Code);
        recoveryCodes = twoFactorResult.RecoveryCodes;
    }

    private sealed class InputModel
    {
        [Required]
        [RegularExpression(@"^([0-9]{6})$", 
            ErrorMessage = "Must be a six-digit authenticator code (######)")]
        [DataType(DataType.Text)]
        [Display(Name = "Verification Code")]
        public string Code { get; set; } = string.Empty;
    }

    async ValueTask IAsyncDisposable.DisposeAsync()
    {
        if (module is not null)
        {
            await module.DisposeAsync();
        }
    }
}
```

Add the following [collocated JavaScript file](xref:blazor/js-interop/javascript-location#load-a-script-from-an-external-javascript-file-js-collocated-with-a-component).

`Components/Identity/Manage2fa.razor.js`:

```javascript
export function setQrCode(uri) {
  new QRCode(document.getElementById('qrCode'), uri);
}
```

## Link to the the Manage 2FA page

In the `<Authorized>` content of the `<AuthorizeView>` in `Components/Layout/NavMenu.razor`, add a link to the **Manage 2FA** page:

```razor
<AuthorizeView>
    <Authorized>

        ...

        <div class="nav-item px-3">
            <NavLink class="nav-link" href="manage-2fa">
                <span class="bi bi-key" aria-hidden="true"></span> Manage 2FA
            </NavLink>
        </div>

        ...

    </Authorized>
</AuthorizeView>
```

## Additional resources

* [Mandrill.net (GitHub repository)](https://github.com/feinoujc/Mandrill.net)
* [Mailchimp developer: Transactional API](https://mailchimp.com/developer/transactional/docs/fundamentals/)
