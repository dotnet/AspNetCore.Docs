* Trust the HTTPS development certificate by running the following command:

  ```dotnetcli
  dotnet dev-certs https --trust
  ```
  :::moniker range="<=aspnetcore-8.0"

  The preceding command requires .NET 8.0.401 SDK or higher on Linux. For Linux on .NET 8.0.400 SDK and earlier, see your Linux distribution's documentation for trusting a certificate.<!--todo What is the correct 8.0 patch version that has the new functionality? -->

  :::moniker-end

  The preceding command displays the following dialog, provided the certificate was not previously trusted:

  ![Security warning dialog](~/getting-started/_static/cert.png)

* Select **Yes** if you agree to trust the development certificate.

  For more information, see the **Trust the ASP.NET Core HTTPS development certificate** section of the [Enforcing SSL](xref:security/enforcing-ssl) article.

<!--todo Should this be omitted when 9.0 is selected?-->  
[!INCLUDE[trust FF](~/includes/trust-ff.md)]
