---
title: Two-factor authentication with SMS | Microsoft Docs
author: rick-anderson
description: 
keywords: ASP.NET Core,
ms.author: riande
manager: wpickett
ms.date: 10/14/2016
ms.topic: article
ms.assetid: ff1c22d1-d1f2-4616-84dd-94ba61ec299a
ms.technology: aspnet
ms.prod: aspnet-core
uid: security/authentication/2fa
---
# Two-factor authentication with SMS

>[!WARNING]
> This page documents version 1.0.0-beta8 and has not yet been updated for version 1.0.0

<a name=security-authentication-2fa></a>

By [Rick Anderson](https://twitter.com/RickAndMSFT)

This tutorial will show you how to set up two-factor authentication (2FA) using SMS. Twilio is used, but you can use any other SMS provider. We recommend you complete [Account Confirmation and Password Recovery](accconfirm.md) before starting this tutorial.

## Create a new ASP.NET Core project

Create a new ASP.NET Core web app with individual user accounts.

![image](accconfirm/_static/new-project.png)

After you create the project, follow the instructions in [Account Confirmation and Password Recovery](accconfirm.md) to set up and require SSL.

## Setup up SMS for two-factor authentication with Twilio

* Create a [Twilio](http://www.twilio.com/) account.

* On the **Dashboard** tab of your Twilio account, note the **Account SID** and **Authentication token**. Note: Tap **Show API Credentials** to see the Authentication token.

* On the **Numbers** tab, note the Twilio phone number.

* Install the Twilio NuGet package. From the Package Manager Console (PMC),  enter the following the following command:

   <!-- literal_block {"ids": [], "xml:space": "preserve"} -->

   ````
   Install-Package Twilio
   ````

* Add code in the *Services/MessageServices.cs* file to enable SMS.

[!code-csharp[Main](2fa/sample/WebSMS/src/WebSMS/Services/MessageServices.cs?range=12-39)]

> [!NOTE]
> Twilio does not yet support [.NET Core](https://microsoft.com/net/core). To use Twilio from your application you need to either target the full .NET Framework or you can call the Twilio REST API to send SMS messages.

> [!NOTE]
> You can remove `//` line comment characters from the `System.Diagnostics.Debug.WriteLine(message);` line to test the application when you can't get SMS messages. A better approach to logging is to use the built in [logging](../../fundamentals/logging.md#fundamentals-logging).

### Configure the SMS provider key/value

We'll use the [Options pattern](../../fundamentals/configuration.md#options-config-objects) to access the user account and key settings. For more information, see [configuration](../../fundamentals/configuration.md#fundamentals-configuration).

   * Create a class to fetch the secure SMS key. For this sample, the `AuthMessageSMSSenderOptions` class is created in the *Services/AuthMessageSMSSenderOptions.cs* file.

[!code-csharp[Main](2fa/sample/WebSMS/src/WebSMS/Services/AuthMessageSMSSenderOptions.cs?range=3-8)]

Set `SID`, `AuthToken`, and `SendNumber` with the [secret-manager tool](../app-secrets.md). For example:

````none
C:/WebSMS/src/WebApplication1>dotnet user-secrets set SID abcdefghi
info: Successfully saved SID = abcdefghi to the secret store.
````

### Configure startup to use `AuthMessageSMSSenderOptions`

Add `AuthMessageSMSSenderOptions` to the service container at the end of the `ConfigureServices` method in the *Startup.cs* file:

[!code-csharp[Main](./2fa/sample/WebSMS/src/WebSMS/Startup.cs?highlight=4&range=73-77)]

## Enable two-factor authentication

*  Open the *Views/Manage/Index.cshtml* Razor view file.

*  Uncomment the phone number markup which starts at

    `@*@(Model.PhoneNumber ?? "None")`

*  Uncomment the `Model.TwoFactor` markup which starts at

    `@*@if (Model.TwoFactor)`

* Comment out or remove the `<p>There are no two-factor authentication providers configured.` markup.

    The completed code is shown below:

[!code-html[Main](2fa/sample/WebSMS/src/WebSMS/Views/Manage/Index.cshtml?range=32-77)]

## Log in with two-factor authentication

* Run the app and register a new user

![image](2fa/_static/login2fa1.png)

* Tap on your user name, which activates the `Index` action method in Manage controller. Then tap the phone number **Add** link.

![image](2fa/_static/login2fa2.png)

* Add a phone number that will receive the verification code, and tap **Send verification code**.

![image](2fa/_static/login2fa3.png)

* You will get a text message with the verification code. Enter it and tap **Submit**

![image](2fa/_static/login2fa4.png)

If you don't get a text message, see [Debugging Twilio](#debugging-twilio).

* The Manage view shows your phone number was added successfully.

![image](2fa/_static/login2fa5.png)

* Tap **Enable** to enable two-factor authentication.

![image](2fa/_static/login2fa6.png)

### Test two-factor authentication

* Log off.

* Log in.

* The user account has enabled two-factor authentication, so you have to provide the second factor of authentication . In this tutorial you have enabled phone verification. The built in templates also allow you to set up email as the second factor. You can set up additional second factors for authentication such as QR codes. Tap **Submit**.

![image](2fa/_static/login2fa7.png)

* Enter the code you get in the SMS message.

* Clicking on the **Remember this browser** check box will exempt you from needing to use 2FA to log on when using the same device and browser. Enabling 2FA and clicking on **Remember this browser** will provide you with strong 2FA protection from malicious users trying to access your account, as long as they don't have access to your device. You can do this on any private device you regularly use. By setting  **Remember this browser**, you get the added security of 2FA from devices you don't regularly use, and you get the convenience on not having to go through 2FA on your own devices.

![image](2fa/_static/login2fa8.png)

## Account lockout for protecting against brute force attacks

We recommend you use account lockout with 2FA. Once a user logs in (through a local account or social account), each failed attempt at 2FA is stored, and if the maximum attempts (default is 5) is reached, the user is locked out for five minutes (you can set the lock out time with `DefaultAccountLockoutTimeSpan`). The following configures Account to be locked out for 10 minutes after 10 failed attempts.

[!code-csharp[Main](./2fa/sample/WebSMS/src/WebSMS/Startup.cs?highlight=1,2,3,4,5&range=67-77)]

## Debugging Twilio

If you're able to use the Twilio API, but you don't get an SMS message, try the following:

1.  Log in to the Twilio site and navigate to the **Logs** > **SMS & MMS Logs** page. You can verify that messages were sent and delivered.

2.  Use the following code in a console application to test Twilio:

    ````csharp
    static void Main(string[] args)
    {
      string AccountSid = "";
      string AuthToken = "";
      var twilio = new Twilio.TwilioRestClient(AccountSid, AuthToken);
      string FromPhone = "";
      string toPhone = "";
      var message = twilio.SendMessage(FromPhone, toPhone, "Twilio Test");
      Console.WriteLine(message.Sid);
    }
    ````
    
