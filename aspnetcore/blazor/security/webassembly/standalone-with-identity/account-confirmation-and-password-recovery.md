---
title: Account confirmation and password recovery in ASP.NET Core Blazor WebAssembly with ASP.NET Core Identity
author: guardrex
description: Learn how to configure an ASP.NET Core Blazor WebAssembly app with ASP.NET Core Identity with email confirmation and password recovery.
ms.author: riande
monikerRange: '>= aspnetcore-8.0'
ms.date: 11/21/2024
uid: blazor/security/webassembly/standalone-with-identity/account-confirmation-and-password-recovery
---
# Account confirmation and password recovery in ASP.NET Core Blazor WebAssembly with ASP.NET Core Identity

[!INCLUDE[](~/includes/not-latest-version-without-not-supported-content.md)]

This article explains how to configure an ASP.NET Core Blazor WebAssembly app with ASP.NET Core Identity with email confirmation and password recovery.

> [!NOTE]
> This article only applies standalone Blazor WebAssembly apps with ASP.NET Core Identity. To implement email confirmation and password recovery for Blazor Web Apps, see <xref:blazor/security/account-confirmation-and-password-recovery>.

## Namespaces and article code examples

The namespaces used by the examples in this article are:

* `Backend` for the backend server web API project ("server project" in this article).
* `BlazorWasmAuth` for the front-end client standalone Blazor WebAssembly app ("client project" in this article).

These namespaces correspond to the projects in the `BlazorWebAssemblyStandaloneWithIdentity` sample solution in the [`dotnet/blazor-samples` GitHub repository](https://github.com/dotnet/blazor-samples). For more information, see <xref:blazor/security/webassembly/standalone-with-identity/index#sample-apps>.

If you aren't using the `BlazorWebAssemblyStandaloneWithIdentity` sample solution, change the namespaces in the code examples to use the namespaces of your projects.

## Select and configure an email provider for the server project

In this article, [Mailchimp's Transactional API](https://mailchimp.com/developer/transactional/api/) is used via [Mandrill.net](https://www.nuget.org/packages/Mandrill.net) to send email. We recommend using an email service to send email rather than SMTP. SMTP is difficult to configure and secure properly. Whichever email service you use, access their guidance for .NET apps, create an account, configure an API key for their service, and install any NuGet packages required.

In the server project, create a class to hold the secret email provider API key. The example in this article uses a class named `AuthMessageSenderOptions` with an `EmailAuthKey` property to hold the key.

`AuthMessageSenderOptions.cs`:

```csharp
namespace Backend;

public class AuthMessageSenderOptions
{
    public string? EmailAuthKey { get; set; }
}
```

Register the `AuthMessageSenderOptions` configuration instance in the server project's `Program` file:

```csharp
builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration);
```

## Configure a user secret for the provider's security key

If the server project has already been initialized for the [Secret Manager tool](xref:security/app-secrets), it will already have a app secrets identifier (`<AppSecretsId>`) in its project file (`.csproj`). In Visual Studio, you can tell if the app secrets ID is present by looking at the **Properties** panel when the project is selected in **Solution Explorer**. If the app hasn't been initialized, execute the following command in a command shell opened to the server project's directory. In Visual Studio, you can use the Developer PowerShell command prompt (use the `cd` command to change the directory to the server project after you open the command shell).

```dotnetcli
dotnet user-secrets init
```

Set the API key with the Secret Manager tool. In the following example, the key name is `EmailAuthKey` to match `AuthMessageSenderOptions.EmailAuthKey`, and the key is represented by the `{KEY}` placeholder. Execute the following command with the API key:

```dotnetcli
dotnet user-secrets set "EmailAuthKey" "{KEY}"
```

If using Visual Studio, you can confirm the secret is set by right-clicking the server project in **Solution Explorer** and selecting **Manage User Secrets**.

For more information, see <xref:security/app-secrets>.

[!INCLUDE[](~/blazor/security/includes/secure-authentication-flows.md)]

## Implement `IEmailSender` in the server project

The following example is based on Mailchimp's Transactional API using [Mandrill.net](https://www.nuget.org/packages/Mandrill.net). For a different provider, refer to their documentation on how to implement sending an email message.

Add the [Mandrill.net](https://www.nuget.org/packages/Mandrill.net) NuGet package to the server project.

Add the following `EmailSender` class to implement <xref:Microsoft.AspNetCore.Identity.IEmailSender%601>. In the following example, `AppUser` is an <xref:Microsoft.AspNetCore.Identity.IdentityUser>. The message HTML markup can be further customized. As long as the `message` passed to `MandrillMessage` starts with the `<` character, the Mandrill.net API assumes that the message body is composed in HTML.

`EmailSender.cs`:

```csharp
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Mandrill;
using Mandrill.Model;

namespace Backend;

public class EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor,
    ILogger<EmailSender> logger) : IEmailSender<AppUser>
{
    private readonly ILogger logger = logger;

    public AuthMessageSenderOptions Options { get; } = optionsAccessor.Value;

    public Task SendConfirmationLinkAsync(AppUser user, string email,
        string confirmationLink) => SendEmailAsync(email, "Confirm your email",
        "<html lang=\"en\"><head></head><body>Please confirm your account by " +
        $"<a href='{confirmationLink}'>clicking here</a>.</body></html>");

    public Task SendPasswordResetLinkAsync(AppUser user, string email,
        string resetLink) => SendEmailAsync(email, "Reset your password",
        "<html lang=\"en\"><head></head><body>Please reset your password by " +
        $"<a href='{resetLink}'>clicking here</a>.</body></html>");

    public Task SendPasswordResetCodeAsync(AppUser user, string email,
        string resetCode) => SendEmailAsync(email, "Reset your password",
        "<html lang=\"en\"><head></head><body>Please reset your password " +
        $"using the following code:<br>{resetCode}</body></html>");

    public async Task SendEmailAsync(string toEmail, string subject, string message)
    {
        if (string.IsNullOrEmpty(Options.EmailAuthKey))
        {
            throw new Exception("Null EmailAuthKey");
        }

        await Execute(Options.EmailAuthKey, subject, message, toEmail);
    }

    public async Task Execute(string apiKey, string subject, string message, 
        string toEmail)
    {
        var api = new MandrillApi(apiKey);
        var mandrillMessage = new MandrillMessage("sarah@contoso.com", toEmail, 
            subject, message);
        await api.Messages.SendAsync(mandrillMessage);

        logger.LogInformation("Email to {EmailAddress} sent!", toEmail);
    }
}
```

> [!NOTE]
> Body content for messages might require special encoding for the email service provider. If links in the message body can't be followed in the email message, consult the service provider's documentation to troubleshoot the problem.

Add the following <xref:Microsoft.AspNetCore.Identity.IEmailSender%601> service registration to the server project's `Program` file:

```csharp
builder.Services.AddTransient<IEmailSender<AppUser>, EmailSender>();
```

## Configure the server project to require email confirmation

In the server project's `Program` file, require a confirmed email address to sign in to the app.

Locate the line that calls <xref:Microsoft.Extensions.DependencyInjection.IdentityServiceCollectionExtensions.AddIdentityCore%2A> and set the <xref:Microsoft.AspNetCore.Identity.SignInOptions.RequireConfirmedEmail> property to `true`:

```diff
- builder.Services.AddIdentityCore<AppUser>()
+ builder.Services.AddIdentityCore<AppUser>(o => o.SignIn.RequireConfirmedEmail = true)
```

## Update the client project's account registration response

In the client project's `Register` component (`Components/Identity/Register.razor`), change the message to users on a successful account registration to instruct them to confirm their account. The following example includes a link to trigger Identity on the server to resend the confirmation email.

```diff
- You successfully registered and can <a href="login">login</a> to the app.
+ You successfully registered. You must now confirm your account by clicking 
+ the link in the email that was sent to you. After confirming your account, 
+ you can <a href="login">login</a> to the app. 
+ <a href="resendConfirmationEmail">Resend confirmation email</a>
```

## Update seed data code to confirm seeded accounts

In the server project's seed data class (`SeedData.cs`), change the code in the `InitializeAsync` method to confirm the seeded accounts, which avoids requiring email address confirmation for each test run of the solution with one of the accounts:

```diff
- if (appUser is not null && user.RoleList is not null)
- {
-     await userManager.AddToRolesAsync(appUser, user.RoleList);
- }
+ if (appUser is not null)
+ {
+     if (user.RoleList is not null)
+     {
+         await userManager.AddToRolesAsync(appUser, user.RoleList);
+     }
+ 
+     var token = await userManager.GenerateEmailConfirmationTokenAsync(appUser);
+     await userManager.ConfirmEmailAsync(appUser, token);
+ }
```

## Enable account confirmation after a site has users

Enabling account confirmation on a site with users locks out all the existing users. Existing users are locked out because their accounts aren't confirmed. Use one of the following approaches, which are beyond the scope of this article:

* Update the database to mark all existing users as confirmed.
* Batch-send emails with confirmation links to all existing users, which requires each user to confirm their own account.

## Password recovery

Password recovery requires the server app to adopt an email provider in order to send password reset codes to users. Therefore, follow the guidance earlier in this article to adopt an email provider:

* [Select and configure an email provider for the server project](#select-and-configure-an-email-provider-for-the-server-project)
* [Configure a user secret for the provider's security key](#configure-a-user-secret-for-the-providers-security-key)
* [Implement `IEmailSender` in the server project](#implement-iemailsender-in-the-server-project)

Password recovery is a two-step process:

1. A POST request is made to the `/forgotPassword` endpoint provided by <xref:Microsoft.AspNetCore.Routing.IdentityApiEndpointRouteBuilderExtensions.MapIdentityApi%2A> in the server project. A message in the UI instructs the user to check their email for a reset code.
1. A POST request is made to the `/resetPassword` endpoint of the server project with the user's email address, password reset code, and new password.

The preceding steps are demonstrated by the following implementation guidance for the [sample solution](xref:blazor/security/webassembly/standalone-with-identity/index#sample-apps).

In the client project, add the following method signatures to the `IAccountManagement` class (`Identity/IAccountManagement.cs`):

```csharp
public Task<bool> ForgotPasswordAsync(string email);

public Task<FormResult> ResetPasswordAsync(string email, string resetCode, 
    string newPassword);
```

In the client project, add implementations for the preceding methods in the `CookieAuthenticationStateProvider` class (`Identity/CookieAuthenticationStateProvider.cs`):

```csharp
public async Task<bool> ForgotPasswordAsync(string email)
{
    try
    {
        var result = await httpClient.PostAsJsonAsync(
            "forgotPassword", new
            {
                email
            });

        if (result.IsSuccessStatusCode)
        {
            return true;
        }
    }
    catch { }

    return false;
}

public async Task<FormResult> ResetPasswordAsync(string email, string resetCode, 
    string newPassword)
{
    string[] defaultDetail = [ "An unknown error prevented password reset." ];

    try
    {
        var result = await httpClient.PostAsJsonAsync(
            "resetPassword", new
            {
                email,
                resetCode,
                newPassword
            });

        if (result.IsSuccessStatusCode)
        {
            return new FormResult { Succeeded = true };
        }

        var details = await result.Content.ReadAsStringAsync();
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

        return new FormResult
        {
            Succeeded = false,
            ErrorList = problemDetails == null ? defaultDetail : [.. errors]
        };
    }
    catch { }

    return new FormResult
    {
        Succeeded = false,
        ErrorList = defaultDetail
    };
}
```

In the client project, add the following `ForgotPassword` component.

`Components/Identity/ForgotPassword.razor`:

```razor
@page "/forgot-password"
@using System.ComponentModel.DataAnnotations
@using BlazorWasmAuth.Identity
@inject IAccountManagement Acct

<PageTitle>Forgot your password?</PageTitle>

<h1>Forgot your password?</h1>
<p>Provide your email address and select the <b>Reset password</b> button.</p>
<hr />
<div class="row">
    <div class="col-md-4">
        @if (!passwordResetCodeSent)
        {
            <EditForm Model="Input" FormName="forgot-password" 
                      OnValidSubmit="OnValidSubmitStep1Async" method="post">
                <DataAnnotationsValidator />
                <ValidationSummary class="text-danger" role="alert" />

                <div class="form-floating mb-3">
                    <InputText @bind-Value="Input.Email" 
                        id="Input.Email" class="form-control" 
                        autocomplete="username" aria-required="true" 
                        placeholder="name@example.com" />
                    <label for="Input.Email" class="form-label">
                        Email
                    </label>
                    <ValidationMessage For="() => Input.Email" 
                        class="text-danger" />
                </div>
                <button type="submit" class="w-100 btn btn-lg btn-primary">
                    Request reset code
                </button>
            </EditForm>
        }
        else
        {
            if (passwordResetSuccess)
            {
                if (errors)
                {
                    foreach (var error in errorList)
                    {
                        <div class="alert alert-danger">@error</div>
                    }
                }
                else
                {
                    <div>
                        Your password was reset. You may <a href="login">login</a> 
                        to the app with your new password.
                    </div>
                }
            }
            else
            {
                <div>
                    A password reset code has been sent to your email address. 
                    Obtain the code from the email for this form.
                </div>
                <EditForm Model="Reset" FormName="reset-password" 
                    OnValidSubmit="OnValidSubmitStep2Async" method="post">
                    <DataAnnotationsValidator />
                    <ValidationSummary class="text-danger" role="alert" />

                    <div class="form-floating mb-3">
                        <InputText @bind-Value="Reset.ResetCode" 
                            id="Reset.ResetCode" class="form-control" 
                            autocomplete="username" aria-required="true" />
                        <label for="Reset.ResetCode" class="form-label">
                            Reset code
                        </label>
                        <ValidationMessage For="() => Reset.ResetCode" 
                            class="text-danger" />
                    </div>
                    <div class="form-floating mb-3">
                        <InputText type="password" @bind-Value="Reset.NewPassword" 
                            id="Reset.NewPassword" class="form-control" 
                            autocomplete="new-password" aria-required="true" 
                            placeholder="password" />
                        <label for="Reset.NewPassword" class="form-label">
                            New Password
                        </label>
                        <ValidationMessage For="() => Reset.NewPassword" 
                            class="text-danger" />
                    </div>
                    <div class="form-floating mb-3">
                        <InputText type="password" 
                            @bind-Value="Reset.ConfirmPassword" 
                            id="Reset.ConfirmPassword" class="form-control" 
                            autocomplete="new-password" aria-required="true" 
                            placeholder="password" />
                        <label for="Reset.ConfirmPassword" class="form-label">
                            Confirm Password
                        </label>
                        <ValidationMessage For="() => Reset.ConfirmPassword" 
                            class="text-danger" />
                    </div>
                    <button type="submit" class="w-100 btn btn-lg btn-primary">
                        Reset password
                    </button>
                </EditForm>
            }
        }
    </div>
</div>

@code {
    private bool passwordResetCodeSent, passwordResetSuccess, errors;
    private string[] errorList = [];

    [SupplyParameterFromForm(FormName = "forgot-password")]
    private InputModel Input { get; set; } = new();

    [SupplyParameterFromForm(FormName = "reset-password")]
    private ResetModel Reset { get; set; } = new();

    private async Task OnValidSubmitStep1Async()
    {
        passwordResetCodeSent = await Acct.ForgotPasswordAsync(Input.Email);
    }

    private async Task OnValidSubmitStep2Async()
    {
        var result = await Acct.ResetPasswordAsync(Input.Email, Reset.ResetCode, 
            Reset.NewPassword);

        if (result.Succeeded)
        {
            passwordResetSuccess = true;

        }
        else
        {
            errors = true;
            errorList = result.ErrorList;
        }
    }

    private sealed class InputModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;
    }

    private sealed class ResetModel
    {
        [Required]
        [Base64String]
        public string ResetCode { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at " +
            "max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string NewPassword { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation " +
            "password don't match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
```

In the `Login` component (`Components/Identity/Login.razor`) of the client project immediately before the closing `</NotAuthorized>` tag, add a forgot password link to reach the `ForgotPassword` component:

```html
<div>
    <a href="forgot-password">Forgot password</a>
</div>
```

## Email and activity timeout

The default inactivity timeout is 14 days. In the server project, the following code sets the inactivity timeout to five days with sliding expiration:

```csharp
builder.Services.ConfigureApplicationCookie(options => {
    options.ExpireTimeSpan = TimeSpan.FromDays(5);
    options.SlidingExpiration = true;
});
```

## Change all ASP.NET Core Data Protection token lifespans

In the server project, the following code changes Data Protection tokens' timeout period to three hours:

```csharp
builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
    options.TokenLifespan = TimeSpan.FromHours(3));
```

The built-in Identity user tokens ([AspNetCore/src/Identity/Extensions.Core/src/TokenOptions.cs](https://github.com/dotnet/aspnetcore/blob/main/src/Identity/Extensions.Core/src/TokenOptions.cs)) have a [one day timeout](https://github.com/dotnet/AspNetCore/blob/main/src/Identity/Core/src/DataProtectionTokenProviderOptions.cs).

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

## Change the email token lifespan

The default token lifespan of the [Identity user tokens](https://github.com/dotnet/AspNetCore/blob/main/src/Identity/Extensions.Core/src/TokenOptions.cs) is [one day](https://github.com/dotnet/AspNetCore/blob/main/src/Identity/Core/src/DataProtectionTokenProviderOptions.cs).

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

To change the email token lifespan, add a custom <xref:Microsoft.AspNetCore.Identity.DataProtectorTokenProvider%601> and <xref:Microsoft.AspNetCore.Identity.DataProtectionTokenProviderOptions> to the server project.

`CustomTokenProvider.cs`:

```csharp
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace BlazorSample;

public class CustomEmailConfirmationTokenProvider<TUser>
    : DataProtectorTokenProvider<TUser> where TUser : class
{
    public CustomEmailConfirmationTokenProvider(
        IDataProtectionProvider dataProtectionProvider,
        IOptions<EmailConfirmationTokenProviderOptions> options,
        ILogger<DataProtectorTokenProvider<TUser>> logger)
        : base(dataProtectionProvider, options, logger)
    {
    }
}

public class EmailConfirmationTokenProviderOptions 
    : DataProtectionTokenProviderOptions
{
    public EmailConfirmationTokenProviderOptions()
    {
        Name = "EmailDataProtectorTokenProvider";
        TokenLifespan = TimeSpan.FromHours(4);
    }
}

public class CustomPasswordResetTokenProvider<TUser> 
    : DataProtectorTokenProvider<TUser> where TUser : class
{
    public CustomPasswordResetTokenProvider(
        IDataProtectionProvider dataProtectionProvider,
        IOptions<PasswordResetTokenProviderOptions> options,
        ILogger<DataProtectorTokenProvider<TUser>> logger)
        : base(dataProtectionProvider, options, logger)
    {
    }
}

public class PasswordResetTokenProviderOptions : 
    DataProtectionTokenProviderOptions
{
    public PasswordResetTokenProviderOptions()
    {
        Name = "PasswordResetDataProtectorTokenProvider";
        TokenLifespan = TimeSpan.FromHours(3);
    }
}
```

Configure the services to use the custom token provider in the server project's `Program` file:

```csharp
builder.Services.AddIdentityCore<AppUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = true;
        options.Tokens.ProviderMap.Add("CustomEmailConfirmation",
            new TokenProviderDescriptor(
                typeof(CustomEmailConfirmationTokenProvider<AppUser>)));
        options.Tokens.EmailConfirmationTokenProvider = 
            "CustomEmailConfirmation";
    })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services
    .AddTransient<CustomEmailConfirmationTokenProvider<AppUser>>();
```

## Troubleshoot

If you can't get email working:

* Set a breakpoint in `EmailSender.Execute` to verify `SendEmailAsync` is called.
* Create a console app to send email using code similar to `EmailSender.Execute` to debug the problem.
* Review the account email history pages at the email provider's website.
* Check your spam folder for messages.
* Try another email alias on a different email provider, such as Microsoft, Yahoo, or Gmail.
* Try sending to different email accounts.

## Additional resources

* [Mandrill.net (GitHub repository)](https://github.com/feinoujc/Mandrill.net)
* [Mailchimp developer: Transactional API](https://mailchimp.com/developer/transactional/docs/fundamentals/)
