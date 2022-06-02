# [Visual Studio](#tab/visual-studio)

* Press Ctrl+F5 to run without the debugger.

  [!INCLUDE[](~/includes/trustCertVS.md)]

  Visual Studio:

  * Starts [Kestrel](xref:fundamentals/servers/index#kestrel) server.
  * Launches a browser.
  * Navigates to `http://localhost:port`, such as `http://localhost:7042`.
    * *port*: A randomly assigned port number for the app.
    * `localhost`: The standard hostname for the local computer. Localhost only serves web requests from the local computer.

# [Visual Studio Code](#tab/visual-studio-code)

  [!INCLUDE[](~/includes/trustCertVSC.md)]

* Press **Ctrl-F5** to run without the debugger.

  Visual Studio Code:

  * Starts [Kestrel](xref:fundamentals/servers/index#kestrel) server.
  * Launches a browser.
  * Navigates to `http://localhost:port`, such as `http://localhost:7042`.
    * *port*: A randomly assigned port number for the app.
    * `localhost`: The standard hostname for the local computer. Localhost only serves web requests from the local computer.
  
# [Visual Studio for Mac](#tab/visual-studio-mac)

* Select **Debug** > **Start Without Debugging** to launch the app.

  Visual Studio for Mac:

  * Starts [Kestrel](xref:fundamentals/servers/index#kestrel) server.
  * Launches a browser.
  * Navigates to `http://localhost:port`, such as `http://localhost:7042`.
    * *port*: A randomly assigned port number for the app.
    * `localhost`: The standard hostname for the local computer. Localhost only serves web requests from the local computer.

  [!INCLUDE[](~/includes/trustCertMac6.md)]

* From Visual Studio, press **Opt-Cmd-Return** to run without the debugger. Alternatively, navigate to the menu bar and go to **Run>Start Without Debugging**.

  Visual Studio starts [Kestrel](xref:fundamentals/servers/kestrel), launches a browser, and navigates to a randomly assigned port such as `http://localhost:7042`.

<!-- End of VS tabs -->

---
