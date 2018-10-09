---
title: Account confirmation and password recovery in ASP.NET Core
author: rick-anderson
description: Learn how to build an ASP.NET Core app with email confirmation and password reset.
ms.author: riande
ms.date: 7/11/2018
uid: security/authentication/accconfirm
---

::: moniker range="<= aspnetcore-2.0"

See [this PDF file](https://github.com/aspnet/Docs/tree/master/aspnetcore/security/authorization/secure-data/asp.net_repo_pdf_1-16-18.pdf) for the ASP.NET Core 1.1 and 2.1 version.

::: moniker-end

::: moniker range=">= aspnetcore-2.1"

# Account confirmation and password recovery in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT) and [Joe Audette](https://twitter.com/joeaudette)

This tutorial shows how to build an ASP.NET Core app with email confirmation and password reset. This tutorial is **not** a beginning topic. You should be familiar with:

* [ASP.NET Core](xref:tutorials/razor-pages/razor-pages-start)
* [Authentication](xref:security/authentication/index)
* [Entity Framework Core](xref:data/ef-mvc/intro)

<!-- see C:/Dropbox/wrk/Code/SendGridConsole/Program.cs -->

## Prerequisites

[!INCLUDE [](~/includes/2.1-SDK.md)]

## Create a web  app and scaffold Identity

# [Visual Studio](#tab/visual-studio) 

* In Visual Studio, create a new **Web Application** project named **WebPWrecover**.
* Select **ASP.NET Core 2.1**.
* Keep the default **Authentication** set to **No Authentication**. Authentication is added in the next step.

In the next step:

* Set the layout page to *~/Pages/Shared/_Layout.cshtml*
* Select *Account/Register*
* Create a new **Data context class**

# [.NET Core CLI](#tab/netcore-cli)

```console
dotnet new webapp -o WebPWrecover
cd WebPWrecover
dotnet tool install -g dotnet-aspnet-codegenerator
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet restore
dotnet aspnet-codegenerator identity -fi Account.Register -dc WebPWrecover.Models.WebPWrecoverContext
dotnet ef migrations add CreateIdentitySchema
dotnet ef database drop -f
dotnet ef database update
dotnet build
```

Run `dotnet aspnet-codegenerator identity --help` to get help on the scaffolding tool.

------

Follow the instructions in [Enable authentication](xref:security/authentication/scaffold-identity#useauthentication):

* Add `app.UseAuthentication();` to `Startup.Configure`
* Add `<partial name="_LoginPartial" />` to the layout file.

## Test new user registration

Run the app, select the **Register** link, and register a user. At this point, the only validation on the email is with the [[EmailAddress]](/dotnet/api/system.componentmodel.dataannotations.emailaddressattribute) attribute. After submitting the registration, you are logged into the app. Later in the tutorial, the code is updated so new users can't log in until their email is validated.

[!INCLUDE[](~/includes/view-identity-db.md)]

Note the table's `EmailConfirmed` field is `False`.

You might want to use this email again in the next step when the app sends a confirmation email. Right-click on the row and select **Delete**. Deleting the email alias makes it easier in the following steps.

<a name="prevent-login-at-registration"></a>
## Require email confirmation

It's a best practice to confirm the email of a new user registration. Email confirmation helps to verify they're not impersonating someone else (that is, they haven't registered with someone else's email). Suppose you had a discussion forum, and you wanted to prevent "yli@example.com" from registering as "nolivetto@contoso.com". Without email confirmation, "nolivetto@contoso.com" could receive unwanted email from your app. Suppose the user accidentally registered as "ylo@example.com" and hadn't noticed the misspelling of "yli". They wouldn't be able to use password recovery because the app doesn't have their correct email. Email confirmation provides limited protection from bots. Email confirmation doesn't provide protection from malicious users with many email accounts.

You generally want to prevent new users from posting any data to your web site before they have a confirmed email.

Update *Areas/Identity/IdentityHostingStartup.cs*  to require a confirmed email:

[!code-csharp[](accconfirm/sample/WebPWrecover21/Areas/Identity/IdentityHostingStartup.cs?name=snippet1&highlight=10-13)]

`config.SignIn.RequireConfirmedEmail = true;` prevents registered users from logging in until their email is confirmed.

### Configure email provider

In this tutorial, [SendGrid](https://sendgrid.com) is used to send email. You need a SendGrid account and key to send email. You can use other email providers. ASP.NET Core 2.x includes `System.Net.Mail`, which allows you to send email from your app. We recommend you use SendGrid or another email service to send email. SMTP is difficult to secure and set up correctly.

Create a class to fetch the secure email key. For this sample, create *Services/AuthMessageSenderOptions.cs*:

[!code-csharp[](accconfirm/sample/WebPWrecover21/Services/AuthMessageSenderOptions.cs?name=snippet1)]

#### Configure SendGrid user secrets

Add a unique `<UserSecretsId>` value to the `<PropertyGroup>` element of the project file:

[!code-xml[](accconfirm/sample/WebPWrecover21/WebPWrecover.csproj?highlight=5)]

Set the `SendGridUser` and `SendGridKey` with the [secret-manager tool](xref:security/app-secrets). For example:

```console
C:/WebAppl>dotnet user-secrets set SendGridUser RickAndMSFT
info: Successfully saved SendGridUser = RickAndMSFT to the secret store.
```

On Windows, Secret Manager stores keys/value pairs in a *secrets.json* file in the `%APPDATA%/Microsoft/UserSecrets/<WebAppName-userSecretsId>` directory.

The contents of the *secrets.json* file aren't encrypted. The *secrets.json* file is shown below (the `SendGridKey` value has been removed.)

 ```json
  {
    "SendGridUser": "RickAndMSFT",
    "SendGridKey": "<key removed>"
  }
  ```
 
For more information, see the [Options pattern](xref:fundamentals/configuration/options) and [configuration](xref:fundamentals/configuration/index).

### Install SendGrid

This tutorial shows how to add email notifications through [SendGrid](https://sendgrid.com/), but you can send email using SMTP and other mechanisms.

Install the `SendGrid` NuGet package:

# [Visual Studio](#tab/visual-studio) 

From the Package Manager Console, enter the following command:

``` PMC
Install-Package SendGrid
```

# [.NET Core CLI](#tab/netcore-cli)

From the console, enter the following command:

```cli
dotnet add package SendGrid
```

------

See [Get Started with SendGrid for Free](https://sendgrid.com/free/) to register for a free SendGrid account.
### Implement IEmailSender

To Implement `IEmailSender`, create *Services/EmailSender.cs* with code similar to the following:

[!code-csharp[](accconfirm/sample/WebPWrecover21/Services/EmailSender.cs)]

### Configure startup to support email

Add the following code to the `ConfigureServices` method in the *Startup.cs* file:

* Add `EmailSender` as a singleton service.
* Register the `AuthMessageSenderOptions` configuration instance.

[!code-csharp[](accconfirm/sample/WebPWrecover21/Startup.cs?name=snippet2&highlight=12-99)]

## Enable account confirmation and password recovery

The template has the code for account confirmation and password recovery. Find the `OnPostAsync` method in *Areas/Identity/Pages/Account/Register.cshtml.cs*.

Prevent newly registered users from being automatically logged on by commenting out the following line:

```csharp
await _signInManager.SignInAsync(user, isPersistent: false);
```

The complete method is shown with the changed line highlighted:

[!code-csharp[](accconfirm/sample/WebPWrecover21/Areas/Identity/Pages/Account/Register.cshtml.cs?highlight=22&name=snippet_Register)]

## Register, confirm email, and reset password

Run the web app, and test the account confirmation and password recovery flow.

* Run the app and register a new user

  ![Web application Account Register view](accconfirm/_static/loginaccconfirm1.png)

* Check your email for the account confirmation link. See [Debug email](#debug) if you don't get the email.
* Click the link to confirm your email.
* Log in with your email and password.
* Log off.

### View the manage page

Select your user name in the browser:
![browser window with user name](accconfirm/_static/un.png)

You might need to expand the navbar to see user name.

![navbar](accconfirm/_static/x.png)

The manage page is displayed with the **Profile** tab selected. The **Email** shows a check box indicating the email has been confirmed.

### Test password reset

* If you're logged in, select **Logout**.
* Select the **Log in** link and select the **Forgot your password?** link.
* Enter the email you used to register the account.
* An email with a link to reset your password is sent. Check your email and click the link to reset your password. After your password has been successfully reset, you can log in with your email and new password.

<a name="debug"></a>

### Debug email

If you can't get email working:

* Set a breakpoint in `EmailSender.Execute` to verify `SendGridClient.SendEmailAsync` is called.
* Create a [console app to send email](https://sendgrid.com/docs/Integrate/Code_Examples/v2_Mail/csharp.html) using similar code to `EmailSender.Execute`.
* Review the [Email Activity](https://sendgrid.com/docs/User_Guide/email_activity.html) page.
* Check your spam folder.
* Try another email alias on a different email provider (Microsoft, Yahoo, Gmail, etc.)
* Try sending to different email accounts.

**A security best practice** is to **not** use production secrets in test and development. If you publish the app to Azure, you can set the SendGrid secrets as application settings in the Azure Web App portal. The configuration system is set up to read keys from environment variables.

## Combine social and local login accounts

To complete this section, you must first enable an external authentication provider. See [Facebook, Google, and external provider authentication](xref:security/authentication/social/index).

You can combine local and social accounts by clicking on your email link. In the following sequence, "RickAndMSFT@gmail.com" is first created as a local login; however, you can create the account as a social login first, then add a local login.

![Web application: RickAndMSFT@gmail.com user authenticated](accconfirm/_static/rick.png)

Click on the **Manage** link. Note the 0 external (social logins) associated with this account.

![Manage view](accconfirm/_static/manage.png)

Click the link to another login service and accept the app requests. In the following image, Facebook is the external authentication provider:

![Manage your external logins view listing Facebook](accconfirm/_static/fb.png)

The two accounts have been combined. You are able to log on with either account. You might want your users to add local accounts in case their social login authentication service is down, or more likely they've lost access to their social account.

## Enable account confirmation after a site has users

Enabling account confirmation on a site with users locks out all the existing users. Existing users are locked out because their accounts aren't confirmed. To work around existing user lockout, use one of the following approaches:

* Update the database to mark all existing users as being confirmed.
* Confirm exiting users. For example, batch-send emails with confirmation links.

::: moniker-end
