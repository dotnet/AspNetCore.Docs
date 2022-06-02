# [Visual Studio](#tab/visual-studio)

* Press Ctrl+F5 to run without the debugger.

  [!INCLUDE[](~/includes/trustCertVS.md)]

  Visual Studio starts [IIS Express](/iis/extensions/introduction-to-iis-express/iis-express-overview) and runs the app. The address bar shows `localhost:port#` and not something like `example.com`. That's because `localhost` is the standard hostname for the local computer. Localhost only serves web requests from the local computer. When Visual Studio creates a web project, a random port is used for the web server.
 
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
