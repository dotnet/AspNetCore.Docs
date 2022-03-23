# ASP.NET Core URL Rewriting Sample

This sample illustrates usage of ASP.NET Core URL Rewriting Middleware. The app demonstrates
URL redirect and URL rewriting options.

When running the sample, non-file responses return the rewritten or redirected URL when 
one of the rules is applied to a request URL. For the XML and text file examples, 
Static File Middleware serves the file after the request URL is rewritten by the middleware.

## Examples in this sample

* `AddRedirect("redirect-rule/(.*)", "redirected/$1")`
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
* `Add(RedirectXmlFileRequests)`
  - Success status code: 301 (Moved Permanently)
  - Example (redirect): *`/file.xml`* to *`/xmlfiles/file.xml`*
* `Add(RewriteTextFileRequests)`
  - Success status code: 200 (OK)
  - Example (rewrite): **/some_file.txt** to **/file.txt**
* `Add(new RedirectImageRequests(".png", "/png-images")))`<br>`Add(new RedirectImageRequests(".jpg", "/jpg-images")))`
  - Success status code: 301 (Moved Permanently)
  - Example (redirect): *`/image.png`* to *`/png-images/image.png`*
  - Example (redirect): *`/image.jpg`* to *`/jpg-images/image.jpg`*

## Use a PhysicalFileProvider

You can also obtain an `IFileProvider` by creating a `PhysicalFileProvider` to pass into
 the `AddApacheModRewrite()` and `AddIISUrlRewrite()` methods:

```csharp
using Microsoft.Extensions.FileProviders;
PhysicalFileProvider fileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory());
```

## Secure redirection extensions

This sample includes `WebHostBuilder` configuration for the app to use URLs (`https://localhost:5001`,
`https://localhost`) and a test certificate (*testCert.pfx*) to assist in exploring the 
secure redirect methods. If the server already has port 443 assigned or in use, 
the `https://localhost` example doesn't work&mdash;remove the `ListenOptions` for port 443 in
the `CreateWebHostBuilder` method of the `Program.cs` file or unbind port 443 on the server so
that Kestrel can use the port.

| Method                           | Status Code |    Port    |
| -------------------------------- | :---------: | :--------: |
| `.AddRedirectToHttpsPermanent()` |     301     | null (465) |
| `.AddRedirectToHttps()`          |     302     | null (465) |
| `.AddRedirectToHttps(301)`       |     301     | null (465) |
| `.AddRedirectToHttps(301, 5001)` |     301     |    5001    |
