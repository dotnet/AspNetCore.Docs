---
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
---
# [Visual Studio](#tab/visual-studio)

* Press Ctrl+F5 to run without the debugger.

<!-- replace all of this with updated includes  -->

Press Ctrl+F5 to run without the debugger.

Visual Studio displays the following dialog when a project is not yet configured to use SSL:

![This project is configured to use SSL. To avoid SSL warnings in the browser you can choose to trust the self-signed certificate that IIS Express has generated. Would you like to trust the IIS Express SSL certificate?](~/getting-started/_static/trustCertVS22.png)

Select **Yes** if you trust the IIS Express SSL certificate.

The following dialog is displayed:

![Security warning dialog](~/getting-started/_static/cert.png)

Select **Yes** if you agree to trust the development certificate.

[!INCLUDE[trust FF](~/includes/trust-ff.md)]

Visual Studio:

  Visual Studio Code starts [Kestrel](xref:fundamentals/servers/kestrel), launches a browser, and navigates to `http://localhost:5001`. The address bar shows `localhost:port#` and not something like `example.com`. That's because `localhost` is the standard hostname for  local computer. Localhost only serves web requests from the local computer.
 
# [Visual Studio Code](#tab/visual-studio-code)

  [!INCLUDE[](~/includes/trustCertVSC.md)]

* Press **Ctrl-F5** to run without the debugger.

  Visual Studio Code starts [Kestrel](xref:fundamentals/servers/kestrel), launches a browser, and navigates to `http://localhost:5001`. The address bar shows `localhost:port#` and not something like `example.com`. That's because `localhost` is the standard hostname for  local computer. Localhost only serves web requests from the local computer.

  
# [Visual Studio for Mac](#tab/visual-studio-mac)

* Select **Run** > **Start Without Debugging** to launch the app.

  Visual Studio for Mac:

  * Starts [Kestrel](xref:fundamentals/servers/index#kestrel) server.
  * Launches a browser.
  * Navigates to `http://localhost:port`, where *port* is a randomly chosen port number.

  [!INCLUDE[](~/includes/trustCertMac.md)]

* From Visual Studio, press **Opt-Cmd-Return** to run without the debugger. Alternatively, navigate to the menu bar and go to **Run>Start Without Debugging**.

  Visual Studio starts [Kestrel](xref:fundamentals/servers/kestrel), launches a browser, and navigates to `http://localhost:5001`.

<!-- End of VS tabs -->

---
