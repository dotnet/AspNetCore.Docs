---
title: Account confirmation and password recovery in ASP.NET Core Blazor
author: guardrex
description: Learn how to configure an ASP.NET Core Blazor Web App with email confirmation and password recovery.
ms.author: riande
monikerRange: '>= aspnetcore-8.0'
ms.date: 11/12/2024
uid: blazor/security/account-confirmation-and-password-recovery
---
# Account confirmation and password recovery in ASP.NET Core Blazor

[!INCLUDE[](~/includes/not-latest-version-without-not-supported-content.md)]

This article explains how to configure an ASP.NET Core Blazor Web App with email confirmation and password recovery.

> [!NOTE]
> This article only applies to Blazor Web Apps. To implement email confirmation and password recovery for standalone Blazor WebAssembly apps with ASP.NET Core Identity, see <xref:blazor/security/webassembly/standalone-with-identity/account-confirmation-and-password-recovery>.

## Namespace

The app's namespace used by the example in this article is `BlazorSample`. Update the code examples to use the namespace of your app.

## Select and configure an email provider

In this article, [Mailchimp's Transactional API](https://mailchimp.com/developer/transactional/api/) is used via [Mandrill.net](https://www.nuget.org/packages/Mandrill.net) to send email. We recommend using an email service to send email rather than SMTP. SMTP is difficult to configure and secure properly. Whichever email service you use, access their guidance for .NET apps, create an account, configure an API key for their service, and install any NuGet packages required.

Create a class to hold the secret email provider API key. The example in this article uses a class named `AuthMessageSenderOptions` with an `EmailAuthKey` property to hold the key.

`AuthMessageSenderOptions.cs`:

```csharp
namespace BlazorSample;

public class AuthMessageSenderOptions
{
    public string? EmailAuthKey { get; set; }
}
```

Register the `AuthMessageSenderOptions` configuration instance in the `Program` file:

```csharp
builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration);
```

## Configure a user secret for the provider's security key

If the project has already been initialized for the [Secret Manager tool](xref:security/app-secrets), it will already have an app secrets identifier (`<AppSecretsId>`) in its project file (`.csproj`). In Visual Studio, you can tell if the app secrets ID is present by looking at the **Properties** panel when the project is selected in **Solution Explorer**. If the app hasn't been initialized, execute the following command in a command shell opened to the project's directory. In Visual Studio, you can use the Developer PowerShell command prompt.

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

## Implement `IEmailSender`

The following example is based on Mailchimp's Transactional API using [Mandrill.net](https://www.nuget.org/packages/Mandrill.net). For a different provider, refer to their documentation on how to implement sending an email message.

Add the [Mandrill.net](https://www.nuget.org/packages/Mandrill.net) NuGet package to the project.

Add the following `EmailSender` class to implement <xref:Microsoft.AspNetCore.Identity.IEmailSender%601>. In the following example, `ApplicationUser` is an <xref:Microsoft.AspNetCore.Identity.IdentityUser>. The message HTML markup can be further customized. As long as the `message` passed to `MandrillMessage` starts with the `<` character, the Mandrill.net API assumes that the message body is composed in HTML.

`Components/Account/EmailSender.cs`:

```csharp
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Mandrill;
using Mandrill.Model;
using BlazorSample.Data;

namespace BlazorSample.Components.Account;

public class EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor,
    ILogger<EmailSender> logger) : IEmailSender<ApplicationUser>
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

## Configure app to support email

In the `Program` file, change the email sender implementation to the `EmailSender`:

```diff
- builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();
+ builder.Services.AddSingleton<IEmailSender<ApplicationUser>, EmailSender>();
```

Remove the `IdentityNoOpEmailSender` (`Components/Account/IdentityNoOpEmailSender.cs`) from the app.

In the `RegisterConfirmation` component (`Components/Account/Pages/RegisterConfirmation.razor`), remove the conditional block in the `@code` block that checks if the `EmailSender` is an `IdentityNoOpEmailSender`:

```diff
- else if (EmailSender is IdentityNoOpEmailSender)
- {
-     ...
- }
```

Also in the `RegisterConfirmation` component, remove the Razor markup and code for checking the `emailConfirmationLink` field, leaving just the line instructing the user to check their email ...

```diff
- @if (emailConfirmationLink is not null)
- {
-     ...
- }
- else
- {
     <p>Please check your email to confirm your account.</p>
- }

@code {
-    private string? emailConfirmationLink;

     ...
}
```

## Enable account confirmation after a site has users

Enabling account confirmation on a site with users locks out all the existing users. Existing users are locked out because their accounts aren't confirmed. To work around existing user lockout, use one of the following approaches:

* Update the database to mark all existing users as confirmed.
* Confirm existing users. For example, batch-send emails with confirmation links.

## Email and activity timeout

The default inactivity timeout is 14 days. The following code sets the inactivity timeout to five days with sliding expiration:

```csharp
builder.Services.ConfigureApplicationCookie(options => {
    options.ExpireTimeSpan = TimeSpan.FromDays(5);
    options.SlidingExpiration = true;
});
```

## Change all ASP.NET Core Data Protection token lifespans

The following code changes Data Protection tokens' timeout period to three hours:

```csharp
builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
    options.TokenLifespan = TimeSpan.FromHours(3));
```

The built-in Identity user tokens ([AspNetCore/src/Identity/Extensions.Core/src/TokenOptions.cs](https://github.com/dotnet/aspnetcore/blob/main/src/Identity/Extensions.Core/src/TokenOptions.cs)) have a [one day timeout](https://github.com/dotnet/AspNetCore/blob/main/src/Identity/Core/src/DataProtectionTokenProviderOptions.cs).

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

## Change the email token lifespan

The default token lifespan of the [Identity user tokens](https://github.com/dotnet/AspNetCore/blob/main/src/Identity/Extensions.Core/src/TokenOptions.cs) is [one day](https://github.com/dotnet/AspNetCore/blob/main/src/Identity/Core/src/DataProtectionTokenProviderOptions.cs).

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

To change the email token lifespan, add a custom <xref:Microsoft.AspNetCore.Identity.DataProtectorTokenProvider%601> and <xref:Microsoft.AspNetCore.Identity.DataProtectionTokenProviderOptions>.

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

Configure the services to use the custom token provider in the `Program` file:

```csharp
builder.Services.AddIdentityCore<ApplicationUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = true;
        options.Tokens.ProviderMap.Add("CustomEmailConfirmation",
            new TokenProviderDescriptor(
                typeof(CustomEmailConfirmationTokenProvider<ApplicationUser>)));
        options.Tokens.EmailConfirmationTokenProvider = 
            "CustomEmailConfirmation";
    })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services
    .AddTransient<CustomEmailConfirmationTokenProvider<ApplicationUser>>();
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
