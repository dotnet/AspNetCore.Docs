* Trust the HTTPS development certificate by running the following command:

  ```dotnetcli
  dotnet dev-certs https --trust
  ```

  The preceding command displays the following dialog, provided the certificate was not previously trusted:

  ![Security warning dialog](~/static/cert.png)

* Select **Yes** if you agree to trust the development certificate.

  For more information, see the **Trust the ASP.NET Core HTTPS development certificate** section of the [Enforcing SSL](../security/enforcing-ssl.md) article.

[!INCLUDE[trust FF](~/includes/trust-ff.md)]
