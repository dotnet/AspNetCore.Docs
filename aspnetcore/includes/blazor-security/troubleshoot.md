## Troubleshoot

### Cookies and site data

Cookies and site data can persist across app updates and interfere with testing and troubleshooting. Clear the following when making app code changes, user account changes with the provider, or provider app configuration changes:

* User sign-in cookies
* App cookies
* Cached and stored site data

One approach to prevent lingering cookies and site data from interfering with testing and troubleshooting is to:

* Configure a browser
  * Use a browser for testing that you can configure to delete all cookie and site data each time the browser is closed.
  * Make sure that the browser is closed manually or by the IDE between any change to the app, test user, or provider configuration.
* Use a custom command to open a browser in incognito or private mode in Visual Studio:
  * Open **Browse With** dialog box from Visual Studio's **Run** button.
  * Select the **Add** button.
  * Provide the path to your browser in the **Program** field.
  * In the **Arguments** field, provide the command-line option that the browser uses to open in incognito or private mode and the URL of the app. For example:
    * Google Chrome: `--incognito --new-window https://localhost:5001`
    * Mozilla Firefox: `-private -url https://localhost:5001`
  * Provide a name in the **Friendly name** field. For example, `Firefox Auth Testing`.
  * Select the **OK** button.
  * To avoid having to select the browser profile for each iteration of testing with an app, set the profile as the default with the **Set as Default** button.
  * Make sure that the browser is closed by the IDE between any change to the app, test user, or provider configuration.

### Run the Server app

When testing and troubleshooting a hosted Blazor app, make sure that you're running the app from the **Server** project. For example in Visual Studio, confirm that the Server project is highlighted in **Solution Explorer** before you start the app with any of the following approaches:

* Select the **Run** button.
* Use **Debug** > **Start Debugging** from the menu.
* Press <kbd>F5</kbd>.

### Inspect the content of a JSON Web Token (JWT)

To decode a JSON Web Token (JWT), use Microsoft's [jwt.ms](https://jwt.ms/) tool. Values in the UI never leave your browser.
