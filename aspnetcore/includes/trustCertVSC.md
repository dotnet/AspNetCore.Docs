* Trust the HTTPS development certificate by running the following command:

  ```dotnetcli
  dotnet dev-certs https --trust
  ```
  :::moniker range="<=aspnetcore-8.0"

  The preceding command requires .NET 9 SDK or later on Linux. For Linux on .NET 8.0.401 SDK and earlier, see your Linux distribution's documentation for trusting a certificate.

  :::moniker-end

  The preceding command displays the following dialog, provided the certificate was not previously trusted:

  ![Security warning dialog](~/getting-started/_static/cert.png)

* Select **Yes** if you agree to trust the development certificate.

  For more information, see the **Trust the ASP.NET Core HTTPS development certificate** section of the [Enforcing SSL](xref:security/enforcing-ssl) article.

[!INCLUDE[trust FF](~/includes/trust-ff.md)]
