### Configure HTTP.sys extended authentication flags

You can now configure the [`HTTP_AUTH_EX_FLAG_ENABLE_KERBEROS_CREDENTIAL_CACHING`](/windows/win32/api/http/ns-http-http_server_authentication_info) and [`HTTP_AUTH_EX_FLAG_CAPTURE_CREDENTIAL`](/windows/win32/api/http/ns-http-http_server_authentication_info) HTTP.sys flags by using the new `EnableKerberosCredentialCaching` and `CaptureCredentials` properties on the HTTP.sys <xref:Microsoft.AspNetCore.Server.HttpSys.AuthenticationManager> to optimize how Windows authentication is handled. For example:

```csharp
webBuilder.UseHttpSys(options =>
{
    options.Authentication.Schemes = AuthenticationSchemes.Negotiate;
    options.Authentication.EnableKerberosCredentialCaching = true;
    options.Authentication.CaptureCredentials = true;
});
```
