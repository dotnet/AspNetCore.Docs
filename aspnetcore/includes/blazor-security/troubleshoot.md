## Troubleshoot

### Cookies and site data

Cookies and site data can persist across app updates and interfere with testing and troubleshooting. Clear the following when making app code changes, user account changes with the provider, or provider app configuration changes:

* User sign-in cookies
* App cookies
* Cached and stored site data

One approach to prevent lingering cookies and site data from interfering with testing and troubleshooting is to:

* Use a browser for testing that you can configure to delete all cookie and site data each time the browser is closed.
* Close the browser between any change to the app, test user, or provider configuration.

### Run the Server app

When testing and troubleshooting a hosted Blazor app, make sure that you're running the app from the **Server** project. For example in Visual Studio, confirm that the Server project is highlighted in **Solution Explorer** before you start the app with any of the following approaches:

* Select the **Run** button.
* Use **Debug** > **Start Debugging** from the menu.
* Press <kbd>F5</kbd>.
