---
title: Google external login setup
author: rick-anderson
ms.author: riande
manager: wpickett
ms.date: 11/2/2016
ms.topic: article
ms.assetid: 8BA389D6-0911-4415-A818-C7B3F5B5CC8D
ms.prod: aspnet-core
uid: security/authentication/google-logins
---
# Configuring Google authentication

<a name=security-authentication-google-logins></a>

This tutorial shows you how to enable your users to login with their Google+ account using a sample ASP.NET Core project created in the [previous section](sociallogins.md). We start by following the [official steps](https://developers.google.com/identity/sign-in/web/devconsole-project) to create a new app in Google API Console.

## Creating the app in Google API Console

* Navigate to [https://console.developers.google.com/projectselector/apis/library](https://console.developers.google.com/projectselector/apis/library) and sign in. If you don't already have a Google account, use the *[Create account](https://accounts.google.com/SignUpWithoutGmail?service=cloudconsole&continue=https%3A%2F%2Fconsole.developers.google.com%2Fprojectselector%2Fapis%2Flibrary&ltmpl=api)* link to create one:

![image](sociallogins/_static/GoogleConsoleLogin.png)

* You will be redirected to API Manager Library page:

![image](sociallogins/_static/GoogleConsoleSwitchboard.png)

* Tap **Create a project** and enter your application name:

![image](sociallogins/_static/GoogleConsoleNewProj.png)

* You will be redirected back to the Library page allowing you to choose features your new app will support. Find *Google+ API* in the list and click on its link to add the API feature:

![image](sociallogins/_static/GoogleConsoleChooseApi.png)

* The page for the newly added API will be displayed. Tap **Enable** to add Google+ login feature to your app:

![image](sociallogins/_static/GoogleConsoleEnableApi.png)

* After enabling the API, tap **Go to Credentials** to configure the secrets:

![image](sociallogins/_static/GoogleConsoleGoCredentials.png)

* Choose:
   * **Google+ API**
   * **Web server (e.g. node.js, Tomcat)**, and
   * **User data**:

![image](sociallogins/_static/GoogleConsoleChooseCred.png)

* Tap **What credentials do I need?** which will take you to the second step of app configuration:

![image](sociallogins/_static/GoogleConsoleCreateClient.png)

* Because we are creating a Google+ project with just one feature (logins), we can enter the same **Name** for the OAuth 2.0 client ID as the one we used for the project.

* Enter your current site URL with *signin-google* appended into the **Authorized redirect URIs** field. For example, https://localhost:44320/**signin-google**.

> [!NOTE]
> You don't need to configure **signin-google** as a route in your app. The ASP.NET Core team's implementation of the OAuth flow will create a temporary socket (called a *backchannel*) that listens at this route just for the duration of the OAuth flow.

* Tap **Create client ID**, which will take you to the third step:

![image](sociallogins/_static/GoogleConsoleAddCred.png)

* Enter your public facing *Email address* and the *Product name* shown for your app when Google+ prompts the user to login.

* Tap **Continue** to proceed to the last step:

![image](sociallogins/_static/GoogleConsoleFinish.png)

* Tap **Download** to save a JSON file with application secrets, and **Done** to complete creation of the new app.

## Storing Google ClientID and ClientSecret

Link sensitive settings like Google *ClientID* and *ClientSecret* to your application configuration by using the [Secret Manager tool](../app-secrets.md) instead of storing them in your configuration file directly, as described in the [previous section](sociallogins.md).

* Open the JSON file downloaded in the last step. Note the *client_id* and *client_secret* values present in the JSON structure.

* Execute the following in your project working directory to store the Google secrets:

  <!-- literal_block {"ids": [], "xml:space": "preserve"} -->

  ````
  dotnet user-secrets set Authentication:Google:ClientID <client_id>
  dotnet user-secrets set Authentication:Google:ClientSecret <client-secret>
     ````

The following code reads the configuration values stored by the [Secret Manager](../app-secrets.md#security-app-secrets):

[!code-csharp[Main](../../common/samples/WebApplication1/Startup.cs?highlight=11&range=20-36)]

## Enable Google middleware

> [!NOTE]
> You will need to use NuGet to install the [Microsoft.AspNetCore.Authentication.Google](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.Google/1.1.0-preview1-final) package if it hasn't already been installed. Alternatively, execute the following in your project directory:
>
> `dotnet install Microsoft.AspNetCore.Authentication.Google`

Add the Google middleware in the `Configure` method in `Startup.cs`:

[!code-csharp[Main](./sociallogins/sample/Startup.cs?highlight=33,34,35,36,37&range=64-115)]

## Login with Google

Run your application and click Login. You will see an option for Google:

![image](sociallogins/_static/DoneGoogle.PNG)

When you click on Google, you will be redirected to Google for authentication:

![image](sociallogins/_static/GoogleLogin.PNG)

Once you enter your Google credentials, then you will be redirected back to the Web site where you can set your email.

You are now logged in using your Google credentials:

![image](sociallogins/_static/Done.PNG)

## Optionally set password

When you register with an external login provider, you do not have a password registered with the app. This alleviates you from creating and remembering a password for the site, but it also makes you dependent on the external login provider. If the external login provider is unavailable, you won't be able to log in to the web site.

To create a password and login using your email that you set during the login process with external providers:

* Tap the **Hello <email alias>** link at the top right corner to navigate to the **Manage** view.

![image](sociallogins/_static/pass1.PNG)

* Tap **Create**

![image](sociallogins/_static/pass2.PNG)

* Set a valid password and you can use this to login with your email

## Next steps

* This article showed how you can authenticate with Google. You can follow a similar approach to authenticate with [Facebook](facebook-logins.md), [Twitter](twitter-logins.md), [Microsoft Account](microsoft-logins.md), [Google](google-logins.md) and other providers.

* Once you publish your Web site to Azure Web App, you should reset the *ClientSecret* in the Google API Console.

* Set the *Authentication:Google:ClientId* and Authentication:Google:ClientSecret as application setting in the Azure Web App portal. The configuration system is setup to read keys from environment variables.