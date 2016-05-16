.. _security-authentication-social-logins:

Enabling authentication using external providers
================================================

By `Pranav Rastogi`_

This tutorial shows you how to build an ASP.NET Core app that enables users to log in using OAuth 2.0  with credentials from an external authentication provider, such as Facebook, Twitter, LinkedIn, Microsoft, or Google. For simplicity, this tutorial focuses on working with credentials from Facebook and Google. 

Enabling these credentials in your web sites provides a significant advantage because millions of users already have accounts with these external providers. These users may be more inclined to sign up for your site if they do not have to create and remember a new set of credentials.

.. contents:: Sections:
  :local:
  :depth: 1

Create a New ASP.NET Core Project
---------------------------------

To get started, open Visual Studio. Next, create a New Project (from the Start Page, or via File - New - Project).  On the left part of the New Project window, make sure the Visual C# templates are open and "Web" is selected, as shown:

.. image:: sociallogins/_static/new-project.png

Next you should see another dialog, the New ASP.NET Project window:
 
.. image:: sociallogins/_static/select-project.png

Select the ASP.NET Core Web Application template from the set of ASP.NET Core templates. Make sure you have Individual Authentication selected for this template. After selecting, click OK.

At this point, the project is created. It may take a few moments to load, and you may notice Visual Studio's status bar indicates that Visual Studio is downloading some resources as part of this process.  Visual Studio ensures some required files are pulled into the project when a solution is opened (or a new project is created), and other files may be pulled in at compile time.


Running the Application
-----------------------

Run the application and after a quick build step, you should see it open in your web browser.

.. image:: sociallogins/_static/first-run.png


Creating the app in Facebook
----------------------------

For Facebook OAuth2 authentication, you need to copy to your project some settings from an application that you create in Facebook.

- In your browser, navigate to https://developers.facebook.com/apps and log in by entering your Facebook credentials.
- If you aren’t already registered as a Facebook developer, click  Register as a Developer and follow the directions to register.
- On the Apps tab, click Create New App.

.. image:: sociallogins/_static/FBApp01.png

- Select Website from the platform choices.

.. image:: sociallogins/_static/FBApp02.png

- Click **Skip and Create App ID**

.. image:: sociallogins/_static/FBApp03.png

- Set a display name and choose a Category.

.. image:: sociallogins/_static/FBApp04.png

- Select **Settings** from the left menu bar.

.. image:: sociallogins/_static/FBApp05.png

- On the **Basic** settings section of the page select Add Platform to specify that you are adding a website application. 

.. image:: sociallogins/_static/FBApp06.png

- Select Website from the platform choices.

.. image:: sociallogins/_static/FBApp07.png

- Add your Site URL (\http://localhost:port/)

- Make a note of your App ID and your App Secret so that you can add both into your ASP.NET Core app later in this tutorial. Also, Add your Site URL (\https://localhost:44300/) to test your application. 

.. image:: sociallogins/_static/FBApp08.png

Use SecretManager to store Facebook AppId and AppSecret
-----------------------------------------------------------

The project created has code in Startup which reads the configuration values from a secret store. As a best practice, it is not recommended to store the secrets in a configuration file in the application since they can be checked into source control which may be publicly accessible.

Follow these steps to add the Facebook AppId and AppSecret to the Secret Manager:

- Install the :doc:`Secret Manager tool </security/app-secrets>`.
- Set the Facebook AppId by running **user-secret set Authentication:Facebook:AppId <value-from-app-Id-field>**
- Set the Facebook AppSecret by running **user-secret set Authentication:Facebook:AppSecret <value-from-app-secret-field>** In this example the AppId value is 862373430475128, corresponding to the previous image.

The following code reads the configuration values stored by the :ref:`Secret Manager <security-app-secrets>`.

.. literalinclude:: /../common/samples/WebApplication1/src/WebApplication1/Startup.cs
  :linenos:
  :language: c#
  :lines: 22-34
  :emphasize-lines: 9
  :dedent: 12

Enable Facebook middleware
--------------------------

**Note:** You will need to use NuGet to install the Microsoft.AspNet.Authentication.Facebook package if it hasn't already been installed.

Add the Facebook middleware in the Configure method in Startup.

.. code-block:: c#
  :linenos:
  
  app.UseFacebookAuthentication(options =>
  {
    options.AppId = Configuration["Authentication:Facebook:AppId"];
    options.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
  });


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

When you authenticate with External Login providers, then you do not have to set a password locally on the Web site. This is useful since you do not have to create an extra password that you have to remember and maintain. However sometimes you might want to create a password and login using your email that you set during the login process with external providers.
To set the password once you have logged in with an external provider:

- Click the **Hello raspranav@gmail.com** at the top right corner to navigate to the Manage view.

.. image:: sociallogins/_static/pass1.PNG

- Click **Create** next to the Password text.

.. image:: sociallogins/_static/pass2.PNG

- Set a valid password and you can use this to login with your email.

Next steps
----------
- This article showed how you can authenticate with Facebook. You can follow a similar approach to authenticate with Microsoft Account, Twitter, Google and other providers.
- Once you publish your Web site to Azure Web App, you should reset the AppSecret in the Facebook developer portal. 
- Set the Facebook AppId and AppSecret as application setting in the Azure Web App portal. The configuration system is setup to read keys from environment variables.


