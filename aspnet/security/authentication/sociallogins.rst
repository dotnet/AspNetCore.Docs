.. _security-authentication-social-logins:

Enabling authentication using Facebook, Google and other external providers
===========================================================================

By `Rick Anderson`_ and `Pranav Rastogi`_ 

This tutorial shows you how to build an ASP.NET Core app that enables users to log in using OAuth 2.0  with credentials from an external authentication provider, such as Facebook, Twitter, LinkedIn, Microsoft, and Google. For simplicity, this tutorial focuses on working with credentials from Facebook and Google. 

Enabling these credentials in your web sites provides a significant advantage because millions of users already have accounts with these external providers. These users may be more inclined to sign up for your site if they do not have to create and remember new credentials.

.. contents:: Sections:
  :local:
  :depth: 1

Create a New ASP.NET Core Project
---------------------------------

.. Note:: The tutorial requires the latest version of Visual Studio 2015 and ASP.NET Core.

- In Visual Studio, create a New Project (from the Start Page, or via **File > New > Project**)

.. image:: sociallogins/_static/new-project.png

- Tap **Web Application** and verify **Authentication** is set to **Individual User Accounts**
 
.. image:: sociallogins/_static/select-project.png

- Enable SSL

    - In solution explorer, right click the project and select **Properties**
    - On the left pane, tap **Debug**
    - Check **Enable SSL**
    - Copy the SSL URL and paste it into the **App URL**
    
.. image:: sociallogins/_static/ssl.png

- Require SSL. Modify the services.AddMvc(); code in ``Startup`` under ``ConfigureServices``:

.. code-block:: c#

   services.AddMvc(options =>
   {
       options.Filters.Add(new RequireHttpsAttribute ());
   });
   
- Test the app

Creating the app in Facebook
----------------------------

Each of the OAuth2 providers require provider specific keys to enable OAuth2.

- Navigate to https://developers.facebook.com/apps and log in.
- If you aren’t already registered as a Facebook developer, click  *Register as a Developer* and follow the directions to register.
- Tap **Add a New App**
- Select **Website** from the platform choices.
- Tap **Skip and Create App ID**

.. image:: sociallogins/_static/FBApp03.png

- Enter a display name,  category, contact email and tap **Create App ID**.

.. image:: sociallogins/_static/FBApp04.png

- Tap **Settings** from the left menu bar.

.. image:: sociallogins/_static/FBApp05.png

- On the **Basic** settings section of the page select Add Platform to specify that you are adding a website app. 

.. image:: sociallogins/_static/FBApp06.png

- Select Website from the platform choices.

.. image:: sociallogins/_static/FBApp07.png

- Add your Site URL (\https://localhost:44320/)

- Make a note of your App ID and your App Secret so that you can add both into your ASP.NET Core app later in this tutorial. Also, Add your Site URL (\https://localhost:44300/) to test your application. 

.. image:: sociallogins/_static/FBApp08.png

Use SecretManager to store Facebook AppId and AppSecret
-----------------------------------------------------------

The project created has code in Startup which reads the configuration values from a secret store. As a best practice, it is not recommended to store the secrets in a configuration file in the application since they can be checked into source control which may be publicly accessible.

Follow these steps to add the Facebook AppId and AppSecret to the Secret Manager:

- Install the :doc:`Secret Manager tool </security/app-secrets>`.
- Set the Facebook AppId::

   dotnet user-secrets set Authentication:Facebook:AppId <app-Id>
- Set the Facebook AppSecret::

   dotnet user-secrets set Authentication:Facebook:AppSecret <app-secret>

The following code reads the configuration values stored by the :ref:`Secret Manager <security-app-secrets>`.

.. literalinclude:: /../common/samples/WebApplication1/src/WebApplication1/Startup.cs
  :language: none
  :lines: 20-36
  :emphasize-lines: 11
  :dedent: 8

Enable Facebook middleware
--------------------------

**Note:** You will need to use NuGet to install the Microsoft.AspNetCore.Authentication.Facebook package if it hasn't already been installed.

Add the Facebook middleware in the ``Configure`` method in ``Startup``:

.. literalinclude:: sociallogins/sample/Startup.cs
  :language: c#
  :lines: 64-104
  :dedent: 8
  :emphasize-lines: 21-25

Login with Facebook
-------------------

Run your application and click Login. You will see an option for Facebook.

.. image:: sociallogins/_static/FBLogin1.PNG

When you click on Facebook, you will be redirected to Facebook for authentication.

.. image:: sociallogins/_static/FBLogin2.PNG

Once you enter your Facebook credentials, then you will be redirected back to the Web site where you can set your email.

You are now logged in using your Facebook credentials.

.. image:: sociallogins/_static/FBLogin3.PNG


Optionally set password
-----------------------

When you register with an external login provider, you do not have a password registered with the app. This alleviates you from creating and remembering a password for the site, but it also makes you dependent on the external login provider. If the external login provider is unavailable, you won't be able to log in to the web site.

To create a password and login using your email that you set during the login process with external providers:

- Tap the **Hello <email alias>** link at the top right corner to navigate to the **Manage** view.

.. image:: sociallogins/_static/pass1.PNG

- Tap **Create**

.. image:: sociallogins/_static/pass2.PNG

- Set a valid password and you can use this to login with your email

Next steps
----------
- This article showed how you can authenticate with Facebook. You can follow a similar approach to authenticate with Microsoft Account, Twitter, Google and other providers.
- Once you publish your Web site to Azure Web App, you should reset the AppSecret in the Facebook developer portal. 
- Set the Facebook AppId and AppSecret as application setting in the Azure Web App portal. The configuration system is setup to read keys from environment variables.


