# ASP.NET Core URL Rewriting Sample (ASP.NET Core 1.x)

This sample illustrates usage of ASP.NET Core 1.x URL Rewriting Middleware. The application demonstrates URL redirect and URL rewriting options. For the ASP.NET Core 2.x sample, see [ASP.NET Core URL Rewriting Sample (ASP.NET Core 2.x)](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/url-rewriting/samples/2.x).

When running the sample, a response will be served that shows the rewritten or redirected URL when one of the rules is applied to a request URL.

## Examples in this sample

* `AddRedirect("redirect-rule/(.*)", "$1")`
  - Success status code: 302 (Found)
  - Example (redirect): **/redirect-rule/{capture_group}** to **/redirected/{capture_group}**
* `AddRewrite(@"^rewrite-rule/(\d+)/(\d+)", "rewritten?var1=$1&var2=$2", skipRemainingRules: true)`
  - Success status code: 200 (OK)
  - Example (rewrite): **/rewrite-rule/{capture_group_1}/{capture_group_2}** to **/rewritten?var1={capture_group_1}&var2={capture_group_2}**
* `AddApacheModRewrite(env.ContentRootFileProvider, "ApacheModRewrite.txt")`
  - Success status code: 302 (Found)
  - Example (redirect): **/apache-mod-rules-redirect/{capture_group}** to **/redirected?id={capture_group}**
* `AddIISUrlRewrite(env.ContentRootFileProvider, "IISUrlRewrite.xml")`
  - Success status code: 200 (OK)
  - Example (rewrite): **/iis-rules-rewrite/{capture_group}** to **/rewritten?id={capture_group}**
* `Add(RedirectXMLRequests)`
  - Success status code: 301 (Moved Permanently)
  - Example (redirect): **/file.xml** to **/xmlfiles/file.xml**
* `Add(new RedirectPNGRequests(".png", "/png-images")))`<br>`Add(new RedirectPNGRequests(".jpg", "/jpg-images")))`
  - Success status code: 301 (Moved Permanently)
  - Example (redirect): **/image.png** to **/png-images/image.png**
  - Example (redirect): **/image.jpg** to **/jpg-images/image.jpg**

## Using a `PhysicalFileProvider`
You can also obtain an `IFileProvider` by creating a `PhysicalFileProvider` to pass into the `AddApacheModRewrite()` and `AddIISUrlRewrite()` methods:
```csharp
using Microsoft.Extensions.FileProviders;
PhysicalFileProvider fileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory());
```
## Secure redirection extensions
This sample includes `WebHostBuilder` configuration for the app to use URLs (**https://localhost:5001**, **https://localhost**) and a test certificate (**testCert.pfx**) to assist you in exploring these redirect methods. Add any of them to the `RewriteOptions()` in **Startup.cs** to study their behavior.

Method | Status Code | Port
--- | :---: | :---:
`.AddRedirectToHttpsPermanent()` | 301 | null (465)
`.AddRedirectToHttps()` | 302 | null (465)
`.AddRedirectToHttps(301)` | 301 | null (465)
`.AddRedirectToHttps(301, 5001)` | 301 | 5001
