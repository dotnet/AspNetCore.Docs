---
title: Configure certificate authentication in ASP.NET Core
author: blowdart
description: Learn how to configure certificate authentication in ASP.NET Core for IIS and HTTP.sys.
monikerRange: '>= aspnetcore-3.0'
ms.author: barry.dorrans
ms.date: 06/11/2019
uid: security/authentication/certauth
---
# Overview

`Microsoft.AspNetCore.Authentication.Certificate` contains an implementation similar to [Certificate Authentication](https://tools.ietf.org/html/rfc5246#section-7.4.4) for ASP.NET Core. Certificate authentication happens at the TLS level, long before it ever gets to ASP.NET Core. More accurately, this is an authentication handler that validates the certificate and then gives you an event where you can resolve that certificate to a `ClaimsPrincipal`. 

[Configure your host](#configure-your-host-to-require-certificates) for certificate authentication, be it IIS, Kestrel, Azure Web Apps, or whatever else you're using.

## Get started

Acquire an HTTPS certificate, apply it, and [configure your host](#configure-your-host-to-require-certificates) to require certificates.

In your web app, add a reference to the package. Then in the `Startup.Configure` method, call
`app.AddAuthentication(CertificateAuthenticationDefaults.AuthenticationScheme).UseCertificateAuthentication(...);` with your options, providing a delegate for `OnValidateCertificate` to validate the client certificate sent with requests. Turn that information into a `ClaimsPrincipal`, set it on the `context.Principal` property, and call `context.Success()`.

If you change your scheme name in the options for the authentication handler, change the scheme name in `AddAuthentication` to ensure it's used on every request that ends in an endpoint requiring authorization.

If authentication fails, this handler returns a `403 (Forbidden)` response rather a `401 (Unauthorized)`, as you might expect. The reasoning is that the authentication should happen during the initial TLS connection. By the time it reaches the handler, it's too late. There's no way to upgrade the connection from an anonymous connection to one with a certificate.

Also add `app.UseAuthentication();` in the `Startup.Configure` method. Otherwise, nothing will ever get called. For example:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddAuthentication(
        CertificateAuthenticationDefaults.AuthenticationScheme)
            .AddCertificate();
    // All the other service configuration.
}

public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
    app.UseAuthentication();

    // All the other app configuration.
}
```

The preceding example demonstrates the default way to add certificate authentication. The handler constructs a user principal using the common certificate properties.

## Configure certificate validation

The `CertificateAuthenticationOptions` handler has some built-in validations that are the minimum validations you should perform on a certificate. Each of these settings is enabled by default.

### ValidateCertificateChain

This check validates that the issuer for the certificate is trusted by the application host operating system. If you're going to accept self-signed certificates, you must disable this check.

### ValidateCertificateUse

This check validates that the certificate presented by the client has the Client Authentication extended key use (EKU), or no EKUs at all. As the specifications say, if no EKU is specified, then all EKUs are deemed valid.

### ValidateValidityPeriod

This check validates that the certificate is within its validity period. On each request, the handler ensures that a certificate that was valid when it was presented hasn't expired during its current session.

### RevocationFlag

A flag that specifies which certificates in the chain are checked for revocation.

Revocation checks are only performed when the certificate is chained to a root certificate.

### RevocationMode

A flag that specifies how revocation checks are performed.

Specifying an online check can result in a long delay while the certificate authority is contacted.

Revocation checks are only performed when the certificate is chained to a root certificate.

### Can I configure my app to require a certificate only on certain paths?

This isn't possible. Remember the certificate exchange is done that the start of the HTTPS conversation, it's done by the host, not the app. Kestrel, IIS, Azure Web Apps don't have any configuration for this sort of thing.

## Handler events

The handler has two events:

* `OnAuthenticationFailed` &ndash; Called if an exception happens during authentication and allows you to react.
* `OnValidateCertificate` &ndash; Called after the certificate has been validated, passed validation, but before the default principal has been created. This event allows you to perform your own validation. Examples include:
  * Determining if the certificate is known to your services.
  * Constructing your own principal. Consider the following example in `Startup.ConfigureServices`:

```csharp
services.AddAuthentication(
    CertificateAuthenticationDefaults.AuthenticationScheme)
    .AddCertificate(options =>
    {
        options.Events = new CertificateAuthenticationEvents
        {
            OnValidateCertificate = context =>
            {
                var claims = new[]
                {
                    new Claim(
                        ClaimTypes.NameIdentifier, 
                        context.ClientCertificate.Subject,
                        ClaimValueTypes.String, 
                        context.Options.ClaimsIssuer),
                    new Claim(ClaimTypes.Name,
                        context.ClientCertificate.Subject,
                        ClaimValueTypes.String, 
                        context.Options.ClaimsIssuer)
                };

                context.Principal = new ClaimsPrincipal(
                    new ClaimsIdentity(claims, context.Scheme.Name));
                context.Success();

                return Task.CompletedTask;
            }
        };
    });
```

If you find the inbound certificate doesn't meet your extra validation, call `context.Fail("failure reason")` with a failure reason.

For real functionality, you'll probably want to call a service registered in dependency injection that connects to a database or other type of user store. Access your service by using the context passed into your delegate. Consider the following example in `Startup.ConfigureServices`:

```csharp
services.AddAuthentication(
    CertificateAuthenticationDefaults.AuthenticationScheme)
    .AddCertificate(options =>
    {
        options.Events = new CertificateAuthenticationEvents
        {
            OnCertificateValidated = context =>
            {
                var validationService =
                    context.HttpContext.RequestServices
                        .GetService<ICertificateValidationService>();
                
                if (validationService.ValidateCertificate(
                    context.ClientCertificate))
                {
                    var claims = new[]
                    {
                        new Claim(
                            ClaimTypes.NameIdentifier, 
                            context.ClientCertificate.Subject, 
                            ClaimValueTypes.String, 
                            context.Options.ClaimsIssuer),
                        new Claim(
                            ClaimTypes.Name, 
                            context.ClientCertificate.Subject, 
                            ClaimValueTypes.String, 
                            context.Options.ClaimsIssuer)
                    };

                    context.Principal = new ClaimsPrincipal(
                        new ClaimsIdentity(claims, context.Scheme.Name));
                    context.Success();
                }                     

                return Task.CompletedTask;
            }
        };
    });
```

Conceptually, the validation of the certificate is an authorization concern. Adding a check on, for example, an issuer or thumbprint in an authorization policy, rather than inside `OnCertificateValidated`, is perfectly acceptable.

## Configure your host to require certificates

### Kestrel

In *Program.cs*, configure Kestrel as follows:

```csharp
public static IWebHost BuildWebHost(string[] args) =>
    WebHost.CreateDefaultBuilder(args)
        .UseStartup<Startup>()
        .ConfigureKestrel(options =>
        {
            options.ConfigureHttpsDefaults(opt => 
                opt.ClientCertificateMode = 
                    ClientCertificateMode.RequireCertificate);
        })
        .Build();
```

Set the `ClientCertificateValidation` delegate to `CertificateValidator.DisableChannelValidation` to prevent Kestrel from using the default operating system certificate validation routine. The authentication handler performs the validation instead.

### IIS

Complete the following steps In IIS Manager:

1. Select your site from the **Connections** tab.
1. Double-click the **SSL Settings** option in the **Features View** window.
1. Check the **Require SSL** checkbox, and select the **Require** radio button in the **Client certificates** section.

![Client certificate settings in IIS](README-IISConfig.png)

### Azure

See the [Azure documentation](/azure/app-service/app-service-web-configure-tls-mutual-auth) 
to configure Azure Web Apps. In your app's `Startup.Configure` method, add the following code before the call to `app.UseAuthentication();`:

```csharp
app.UseCertificateHeaderForwarding();
```

### Custom web proxies

If you're using a proxy that isn't IIS or Azure's Web Apps Application Request Routing, configure your proxy to forward the certificate it received in an HTTP header. In your app's `Startup.Configure` method, add the following code before the call to `app.UseAuthentication();`:

```csharp
app.UseCertificateForwarding();
```

You'll also need to configure the Certificate Forwarding middleware to specify the header name. In your app's `Startup.ConfigureServices` method, add the following code to configure the header from which the forwarding middleware builds a certificate:

```csharp
services.AddCertificateForwarding(options =>
    options.CertificateHeader = "YOUR_CUSTOM_HEADER_NAME");
```

Finally, if your proxy is doing something weird to pass the header on, rather than base-64 encoding it (as is the case with Nginx), override the converter option to be a `Func` that will perform the optional conversion. Consider the following example in `Startup.ConfigureServices`:

```csharp
services.AddCertificateForwarding(options =>
{
    options.CertificateHeader = "YOUR_CUSTOM_HEADER_NAME";
    options.HeaderConverter = (headerValue) => 
    {
        var clientCertificate = 
           /* some weird conversion logic to create an X509Certificate2 */
        return clientCertificate;
    }
});
```
