* Trust the HTTPS development certificate by running the following command:

  ```dotnetcli
  dotnet dev-certs https --trust
  ```
  
  The preceding command doesn't work on Linux. See your Linux distribution's documentation for trusting a certificate.

  The preceding command displays the following dialog, provided the certificate was not previously trusted:

  ![Security warning dialog](~/getting-started/_static/cert.png)

* Select **Yes** if you agree to trust the development certificate.

  See [Trust the ASP.NET Core HTTPS development certificate](xref:security/enforcing-ssl#trust-the-aspnet-core-https-development-certificate-on-windows-and-macos) for more information.
  
[!INCLUDE[trust FF](~/includes/trust-ff.md)]