---
title: Prevent Cross-Site Request Forgery (XSRF/CSRF) attacks in ASP.NET Core
author: rick-anderson
description: Discover how to prevent attacks against web apps where a malicious website can influence the interaction between a client browser and the app.
ms.author: riande
content_well_notification: AI-contribution
monikerRange: '>= aspnetcore-3.1'
ms.custom: mvc
ms.date: 11/16/2023
uid: security/anti-request-forgery
---
# Prevent Cross-Site Request Forgery (XSRF/CSRF) attacks in ASP.NET Core

By [Fiyaz Hasan](https://twitter.com/FiyazBinHasan) and [Rick Anderson](https://twitter.com/RickAndMSFT)

:::moniker range=">= aspnetcore-8.0"

Cross-site request forgery is an attack against web-hosted apps whereby a malicious web app can influence the interaction between a client browser and a web app that trusts that browser. These attacks are possible because web browsers send some types of authentication tokens automatically with every request to a website. This form of exploit is also known as a *one-click attack* or *session riding* because the attack takes advantage of the user's previously authenticated session. Cross-site request forgery is also known as XSRF or CSRF.

An example of a CSRF attack:

1. A user signs into `www.good-banking-site.example.com` using forms authentication. The server authenticates the user and issues a response that includes an authentication cookie. The site is vulnerable to attack because it trusts any request that it receives with a valid authentication cookie.
1. The user visits a malicious site, `www.bad-crook-site.example.com`.

   The malicious site, `www.bad-crook-site.example.com`, contains an HTML form similar to the following example:

   :::code language="html" source="anti-request-forgery/samples_snapshot/vulnerable-form.html":::

   Notice that the form's `action` posts to the vulnerable site, not to the malicious site. This is the "cross-site" part of CSRF.

1. The user selects the submit button. The browser makes the request and automatically includes the authentication cookie for the requested domain, `www.good-banking-site.example.com`.
1. The request runs on the `www.good-banking-site.example.com` server with the user's authentication context and can perform any action that an authenticated user is allowed to perform.

In addition to the scenario where the user selects the button to submit the form, the malicious site could:

* Run a script that automatically submits the form.
* Send the form submission as an AJAX request.
* Hide the form using CSS.

These alternative scenarios don't require any action or input from the user other than initially visiting the malicious site.

Using HTTPS doesn't prevent a CSRF attack. The malicious site can send an `https://www.good-banking-site.com/` request as easily as it can send an insecure request.

Some attacks target endpoints that respond to GET requests, in which case an image tag can be used to perform the action. This form of attack is common on forum sites that permit images but block JavaScript. Apps that change state on GET requests, where variables or resources are altered, are vulnerable to malicious attacks. **GET requests that change state are insecure. A best practice is to never change state on a GET request.**

CSRF attacks are possible against web apps that use cookies for authentication because:

* Browsers store cookies issued by a web app.
* Stored cookies include session cookies for authenticated users.
* Browsers send all of the cookies associated with a domain to the web app every request regardless of how the request to app was generated within the browser.

However, CSRF attacks aren't limited to exploiting cookies. For example, Basic and Digest authentication are also vulnerable. After a user signs in with Basic or Digest authentication, the browser automatically sends the credentials until the session ends.

In this context, *session* refers to the client-side session during which the user is authenticated. It's unrelated to server-side sessions or [ASP.NET Core Session Middleware](xref:fundamentals/app-state).

Users can guard against CSRF vulnerabilities by taking precautions:

* Sign out of web apps when finished using them.
* Clear browser cookies periodically.

However, CSRF vulnerabilities are fundamentally a problem with the web app, not the end user.

## Authentication fundamentals

Cookie-based authentication is a popular form of authentication. Token-based authentication systems are growing in popularity, especially for Single Page Applications (SPAs).

### Cookie-based authentication

When a user authenticates using their username and password they're issued a token containing an authentication ticket. The token can be used for authentication and authorization. The token is stored as a cookie that's sent with every request the client makes. Generating and validating this cookie is performed with the Cookie Authentication Middleware. The [middleware](xref:fundamentals/middleware/index) serializes a user principal into an encrypted cookie. On subsequent requests, the middleware validates the cookie, recreates the principal, and assigns the principal to the <xref:Microsoft.AspNetCore.Http.HttpContext.User%2A?displayProperty=nameWithType> property.

### Token-based authentication

When a user is authenticated, they're issued a token (not an antiforgery token). The token contains user information in the form of [claims](/dotnet/framework/security/claims-based-identity-model) or a reference token that points the app to user state maintained in the app. When a user attempts to access a resource that requires authentication, the token is sent to the app with an extra authorization header in the form of a Bearer token. This approach makes the app stateless. In each subsequent request, the token is passed in the request for server-side validation. This token isn't *encrypted*; it's *encoded*. On the server, the token is decoded to access its information. To send the token on subsequent requests, store the token in the browser's local storage. Placing a token in the browser local storage and retrieving it and using it as a bearer token provides protection against CSRF attacks. However, should the app be vulnerable to script injection via XSS or a compromised external JavaScript file, an attacker could retrieve any value from local storage and send it to themselves. ASP.NET Core encodes all server side output from variables by default, reducing the risk of XSS. If you override this behavior by using [Html.Raw](xref:System.Web.Mvc.HtmlHelper.Raw%2A) or custom code with untrusted input then you may increase the risk of XSS.

Don't be concerned about CSRF vulnerability if the token is stored in the browser's local storage. CSRF is a concern when the token is stored in a cookie. For more information, see the GitHub issue [SPA code sample adds two cookies](https://github.com/dotnet/AspNetCore.Docs/issues/13369).

### Multiple apps hosted at one domain

Shared hosting environments are vulnerable to session hijacking, sign-in CSRF, and other attacks.

Although `example1.contoso.net` and `example2.contoso.net` are different hosts, there's an implicit trust relationship between hosts under the `*.contoso.net` domain. This implicit trust relationship allows potentially untrusted hosts to affect each other's cookies (the same-origin policies that govern AJAX requests don't necessarily apply to HTTP cookies).

Attacks that exploit trusted cookies between apps hosted on the same domain can be prevented by not sharing domains. When each app is hosted on its own domain, there's no implicit cookie trust relationship to exploit.

<a name="anti7"></a>

## Antiforgery in ASP.NET Core

> [!WARNING]
> ASP.NET Core implements antiforgery using [ASP.NET Core Data Protection](xref:security/data-protection/introduction). The data protection stack must be configured to work in a server farm. For more information, see [Configuring data protection](xref:security/data-protection/configuration/overview).

Antiforgery middleware is added to the [Dependency injection](xref:fundamentals/dependency-injection) container when one of the following APIs is called in `Program.cs`:

* <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddMvc%2A>
* <xref:Microsoft.AspNetCore.Builder.RazorPagesEndpointRouteBuilderExtensions.MapRazorPages%2A>
* <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapControllerRoute%2A>
* <xref:Microsoft.Extensions.DependencyInjection.RazorComponentsServiceCollectionExtensions.AddRazorComponents%2A>

For more information, see [Antiforgery with Minimal APIs](#afwma).

The [FormTagHelper](xref:mvc/views/working-with-forms#the-form-tag-helper) injects antiforgery tokens into HTML form elements. The following markup in a Razor file automatically generates antiforgery tokens:

:::code language="cshtml" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Views/Home/Index.cshtml" id="snippet_Form":::

Similarly, <xref:Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.BeginForm%2A?displayProperty=nameWithType> generates antiforgery tokens by default if the form's method isn't GET.

The automatic generation of antiforgery tokens for HTML form elements happens when the `<form>` tag contains the `method="post"` attribute and either of the following are true:

* The action attribute is empty (`action=""`).
* The action attribute isn't supplied (`<form method="post">`).

Automatic generation of antiforgery tokens for HTML form elements can be disabled:

* Explicitly disable antiforgery tokens with the `asp-antiforgery` attribute:

  :::code language="cshtml" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Views/Home/Index.cshtml" id="snippet_FormAntiforgeryFalse":::

* The form element is opted-out of Tag Helpers by using the Tag Helper [! opt-out symbol](xref:mvc/views/tag-helpers/intro#opt-out):

  :::code language="cshtml" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Views/Home/Index.cshtml" id="snippet_FormTagHelperDisabled":::

* Remove the `FormTagHelper` from the view. The `FormTagHelper` can be removed from a view by adding the following directive to the Razor view:

  :::code language="cshtml" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Views/Home/Index.cshtml" id="snippet_FormRemoveTagHelper":::

> [!NOTE]
> [Razor Pages](xref:razor-pages/index) are automatically protected from XSRF/CSRF. For more information, see [XSRF/CSRF and Razor Pages](xref:razor-pages/index#xsrfcsrf-and-razor-pages-1).

The most common approach to defending against CSRF attacks is to use the *Synchronizer Token Pattern* (STP). STP is used when the user requests a page with form data:

1. The server sends a token associated with the current user's identity to the client.
1. The client sends back the token to the server for verification.
1. If the server receives a token that doesn't match the authenticated user's identity, the request is rejected.

The token is unique and unpredictable. The token can also be used to ensure proper sequencing of a series of requests (for example, ensuring the request sequence of: page 1 > page 2 > page 3). All of the forms in ASP.NET Core MVC and Razor Pages templates generate antiforgery tokens. The following pair of view examples generates antiforgery tokens:

:::code language="cshtml" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Views/Home/Index.cshtml" id="snippet_FormControllerExamples":::

Explicitly add an antiforgery token to a `<form>` element without using Tag Helpers with the HTML helper [`@Html.AntiForgeryToken`](xref:Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper.AntiForgeryToken%2A):

:::code language="cshtml" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Views/Home/Index.cshtml" id="snippet_FormExplicit":::

In each of the preceding cases, ASP.NET Core adds a hidden form field similar to the following example:

```html
<input name="__RequestVerificationToken" type="hidden" value="CfDJ8NrAkS ... s2-m9Yw">
```

ASP.NET Core includes three [filters](xref:mvc/controllers/filters) for working with antiforgery tokens:

* [ValidateAntiForgeryToken](xref:Microsoft.AspNetCore.Mvc.ValidateAntiForgeryTokenAttribute)
* [AutoValidateAntiforgeryToken](xref:Microsoft.AspNetCore.Mvc.AutoValidateAntiforgeryTokenAttribute)
* [IgnoreAntiforgeryToken](xref:Microsoft.AspNetCore.Mvc.IgnoreAntiforgeryTokenAttribute)

## Antiforgery with `AddControllers`

Calling <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddControllers%2A> does ***not*** enable antiforgery tokens. <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddControllersWithViews%2A> must be called to have built-in antiforgery token support.

## Multiple browser tabs and the Synchronizer Token Pattern

With the Synchronizer Token Pattern, only the most recently loaded page contains a valid antiforgery token. Using multiple tabs can be problematic. For example, if a user opens multiple tabs:

 * Only the most recently loaded tab contains a valid antiforgery token.
 * Requests made from previously loaded tabs fail with an error: `Antiforgery token validation failed. The antiforgery cookie token and request token do not match`
 
 Consider alternative CSRF protection patterns if this poses an issue.

## Configure antiforgery with `AntiforgeryOptions`

Customize <xref:Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions> in `Program.cs`:

:::code language="csharp" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Program.cs" id="snippet_AddAntiforgeryOptions":::

Set the antiforgery `Cookie` properties using the properties of the <xref:Microsoft.AspNetCore.Http.CookieBuilder> class, as shown in the following table.

| Option | Description |
| --- | --- |
| <xref:Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions.Cookie%2A> | Determines the settings used to create the antiforgery cookies. |
| <xref:Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions.FormFieldName%2A> | The name of the hidden form field used by the antiforgery system to render antiforgery tokens in views. |
| <xref:Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions.HeaderName%2A> | The name of the header used by the antiforgery system. If `null`, the system considers only form data. |
| <xref:Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions.SuppressXFrameOptionsHeader%2A> | Specifies whether to suppress generation of the `X-Frame-Options` header. By default, the header is generated with a value of "SAMEORIGIN". Defaults to `false`. |

For more information, see <xref:Microsoft.AspNetCore.Builder.CookieAuthenticationOptions>.

## Generate antiforgery tokens with `IAntiforgery`

<xref:Microsoft.AspNetCore.Antiforgery.IAntiforgery> provides the API to configure antiforgery features. `IAntiforgery` can be requested in `Program.cs` using <xref:Microsoft.AspNetCore.Builder.WebApplication.Services%2A?displayProperty=nameWithType>. The following example uses middleware from the app's home page to generate an antiforgery token and send it in the response as a cookie:

:::code language="csharp" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Program.cs" id="snippet_Middleware" highlight="5,7-20":::

The preceding example sets a cookie named `XSRF-TOKEN`. The client can read this cookie and provide its value as a header attached to AJAX requests. For example, Angular includes [built-in XSRF protection](https://angular.io/guide/http#security-xsrf-protection) that reads a cookie named `XSRF-TOKEN` by default.

### Require antiforgery validation

The [ValidateAntiForgeryToken](xref:Microsoft.AspNetCore.Mvc.ValidateAntiForgeryTokenAttribute) action filter can be applied to an individual action, a controller, or globally. Requests made to actions that have this filter applied are blocked unless the request includes a valid antiforgery token:

:::code language="csharp" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Controllers/HomeController.cs" id="snippet_ValidateAntiForgeryToken" highlight="2":::

The `ValidateAntiForgeryToken` attribute requires a token for requests to the action methods it marks, including HTTP GET requests. If the `ValidateAntiForgeryToken` attribute is applied across the app's controllers, it can be overridden with the `IgnoreAntiforgeryToken` attribute.

### Automatically validate antiforgery tokens for unsafe HTTP methods only

Instead of broadly applying the `ValidateAntiForgeryToken` attribute and then overriding it with `IgnoreAntiforgeryToken` attributes, the [AutoValidateAntiforgeryToken](xref:Microsoft.AspNetCore.Mvc.AutoValidateAntiforgeryTokenAttribute) attribute can be used. This attribute works identically to the `ValidateAntiForgeryToken` attribute, except that it doesn't require tokens for requests made using the following HTTP methods:

* GET
* HEAD
* OPTIONS
* TRACE

We recommend use of `AutoValidateAntiforgeryToken` broadly for non-API scenarios. This attribute ensures POST actions are protected by default. The alternative is to ignore antiforgery tokens by default, unless `ValidateAntiForgeryToken` is applied to individual action methods. It's more likely in this scenario for a POST action method to be left unprotected by mistake, leaving the app vulnerable to CSRF attacks. All POSTs should send the antiforgery token.

APIs don't have an automatic mechanism for sending the non-cookie part of the token. The implementation probably depends on the client code implementation. Some examples are shown below:

Class-level example:

:::code language="csharp" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Controllers/HomeController.cs" id="snippet_AutoValidateAntiforgeryToken":::

Global example:

:::code language="csharp" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Program.cs" id="snippet_AddControllersWithViewsAutoValidateAntiforgeryTokenAttribute" highlight="3":::

### Override global or controller antiforgery attributes

The [IgnoreAntiforgeryToken](xref:Microsoft.AspNetCore.Mvc.IgnoreAntiforgeryTokenAttribute) filter is used to eliminate the need for an antiforgery token for a given action (or controller). When applied, this filter overrides `ValidateAntiForgeryToken` and `AutoValidateAntiforgeryToken` filters specified at a higher level (globally or on a controller).

:::code language="csharp" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Controllers/HomeController.cs" id="snippet_IgnoreAntiforgeryToken" highlight="1":::

## Refresh tokens after authentication

Tokens should be refreshed after the user is authenticated by redirecting the user to a view or Razor Pages page.

## JavaScript, AJAX, and SPAs

In traditional HTML-based apps, antiforgery tokens are passed to the server using hidden form fields. In modern JavaScript-based apps and SPAs, many requests are made programmatically. These AJAX requests may use other techniques, such as request headers or cookies, to send the token.

If cookies are used to store authentication tokens and to authenticate API requests on the server, CSRF is a potential problem. If local storage is used to store the token, CSRF vulnerability might be mitigated because values from local storage aren't sent automatically to the server with every request. Using local storage to store the antiforgery token on the client and sending the token as a request header is a recommended approach.

### Blazor

For more information, see <xref:blazor/security/index#antiforgery-support>.

### JavaScript

Using JavaScript with views, the token can be created using a service from within the view. Inject the <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgery> service into the view and call <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgery.GetAndStoreTokens%2A>:

:::code language="cshtml" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Views/JavaScript/Index.cshtml" highlight="1,6,9,23-26":::

The preceding example uses JavaScript to read the hidden field value for the AJAX POST header. 

This approach eliminates the need to deal directly with setting cookies from the server or reading them from the client. However, when injecting the <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgery> service isn't possible, use JavaScript to access tokens in cookies:

* Access tokens in an additional request to the server, typically usually `same-origin`.
* Use the cookie's contents to create a header with the token's value. 

Assuming the script sends the token in a request header called `X-XSRF-TOKEN`, configure the antiforgery service to look for the `X-XSRF-TOKEN` header:

:::code language="csharp" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Program.cs" id="snippet_AddAntiforgeryOptionsJavaScript":::

The following example adds a protected endpoint that writes the request token to a JavaScript-readable cookie:

:::code language="csharp" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Program.cs" id="snippet_AddAntiforgeryEndpoint":::

The following example uses JavaScript to make an AJAX request to obtain the token and make another request with the appropriate header:

:::code language="javascript" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Index.js" highlight="1,15":::

<a name="antimin7"></a>

> [!NOTE]
> When the antiforgery token is provided in both the request header and in the form payload, only the token in the header is validated.

<a name="afwma"></a>

### Antiforgery with Minimal APIs

Call [AddAntiforgery](/dotnet/api/microsoft.extensions.dependencyinjection.antiforgeryservicecollectionextensions.addantiforgery) and <xref:Microsoft.AspNetCore.Builder.AntiforgeryApplicationBuilderExtensions.UseAntiforgery(Microsoft.AspNetCore.Builder.IApplicationBuilder)> to register antiforgery services in DI.  Antiforgery tokens are used to mitigate [cross-site request forgery attacks](xref:security/anti-request-forgery).

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/minimal-apis/samples/MyAntiForgery/Program.cs" id="snippet_short" highlight="3,7":::

The antiforgery middleware:

* Does ***not*** short-circuit the execution of the rest of the request pipeline.
* Sets the [IAntiforgeryValidationFeature](https://source.dot.net/#Microsoft.AspNetCore.Http.Features/IAntiforgeryValidationFeature.cs,33a7a0e106f11c6f) in the [HttpContext.Features](xref:Microsoft.AspNetCore.Http.HttpContext.Features) of the current request.

The antiforgery token is only validated if:

* The endpoint contains metadata implementing [IAntiforgeryMetadata](https://source.dot.net/#Microsoft.AspNetCore.Http.Abstractions/Metadata/IAntiforgeryMetadata.cs,5f49d4d07fc58320) where `RequiresValidation=true`.
* The HTTP method associated with the endpoint is a relevant [HTTP method](https://developer.mozilla.org/docs/Web/HTTP/Methods). The relevant methods are all [HTTP methods](https://developer.mozilla.org/docs/Web/HTTP/Methods) except for TRACE, OPTIONS, HEAD, and GET.
* The request is associated with a valid endpoint.

***Note:*** When enabled manually, the antiforgery middleware must run after the authentication and authorization middleware to prevent reading form data when the user is unauthenticated.

By default, minimal APIs that accept form data require antiforgery token validation.

Consider the following `GenerateForm` method:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/minimal-apis/samples/MyAntiForgery/Program.cs" id="snippet_html":::

The preceding code has three arguments, the action, the anti-forgery token, and a `bool` indicating whether the token should be used.

Consider the following sample:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/minimal-apis/samples/MyAntiForgery/Program.cs" id="snippet_all" highlight="6,10":::

In the preceding code, posts to:

* `/todo` require a valid antiforgery token.
* `/todo2` do ***not*** require a valid antiforgery token because [`DisableAntiforgery`](https://source.dot.net/#Microsoft.AspNetCore.Routing/Builder/RoutingEndpointConventionBuilderExtensions.cs,022b9134f828d984) is called.

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/minimal-apis/samples/MyAntiForgery/Program.cs" id="snippet_post":::

A POST to:

* `/todo` from the form generated by the `/` endpoint succeeds because the antiforgery token is valid.
* `/todo` from the form generated by the `/SkipToken` fails because the antiforgery is not included.
* `/todo2` from the form generated by the `/DisableAntiforgery` endpoint succeeds because the antiforgery is not required.

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/minimal-apis/samples/MyAntiForgery/Program.cs" id="snippet_post":::

When a form is submitted without a valid antiforgery token:

* In the development environment, an exception is thrown.
* In the production environment, a message is logged.

## Windows authentication and antiforgery cookies

When using Windows Authentication, application endpoints must be protected against CSRF attacks in the same way as done for cookies. The browser implicitly sends the authentication context to the server and endpoints need to be protected against CSRF attacks.

## Extend antiforgery

The <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgeryAdditionalDataProvider> type allows developers to extend the behavior of the anti-CSRF system by round-tripping additional data in each token. The <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgeryAdditionalDataProvider.GetAdditionalData%2A> method is called each time a field token is generated, and the return value is embedded within the generated token. An implementer could return a timestamp, a nonce, or any other value and then call <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgeryAdditionalDataProvider.ValidateAdditionalData%2A> to validate this data when the token is validated. The client's username is already embedded in the generated tokens, so there's no need to include this information. If a token includes supplemental data but no `IAntiForgeryAdditionalDataProvider` is configured, the supplemental data isn't validated.

## Additional resources

* <xref:host-and-deploy/web-farm>

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

Cross-site request forgery (also known as XSRF or CSRF) is an attack against web-hosted apps whereby a malicious web app can influence the interaction between a client browser and a web app that trusts that browser. These attacks are possible because web browsers send some types of authentication tokens automatically with every request to a website. This form of exploit is also known as a *one-click attack* or *session riding* because the attack takes advantage of the user's previously authenticated session.

An example of a CSRF attack:

1. A user signs into `www.good-banking-site.example.com` using forms authentication. The server authenticates the user and issues a response that includes an authentication cookie. The site is vulnerable to attack because it trusts any request that it receives with a valid authentication cookie.
1. The user visits a malicious site, `www.bad-crook-site.example.com`.

   The malicious site, `www.bad-crook-site.example.com`, contains an HTML form similar to the following example:

   :::code language="html" source="anti-request-forgery/samples_snapshot/vulnerable-form.html":::

   Notice that the form's `action` posts to the vulnerable site, not to the malicious site. This is the "cross-site" part of CSRF.

1. The user selects the submit button. The browser makes the request and automatically includes the authentication cookie for the requested domain, `www.good-banking-site.example.com`.
1. The request runs on the `www.good-banking-site.example.com` server with the user's authentication context and can perform any action that an authenticated user is allowed to perform.

In addition to the scenario where the user selects the button to submit the form, the malicious site could:

* Run a script that automatically submits the form.
* Send the form submission as an AJAX request.
* Hide the form using CSS.

These alternative scenarios don't require any action or input from the user other than initially visiting the malicious site.

Using HTTPS doesn't prevent a CSRF attack. The malicious site can send an `https://www.good-banking-site.com/` request just as easily as it can send an insecure request.

Some attacks target endpoints that respond to GET requests, in which case an image tag can be used to perform the action. This form of attack is common on forum sites that permit images but block JavaScript. Apps that change state on GET requests, where variables or resources are altered, are vulnerable to malicious attacks. **GET requests that change state are insecure. A best practice is to never change state on a GET request.**

CSRF attacks are possible against web apps that use cookies for authentication because:

* Browsers store cookies issued by a web app.
* Stored cookies include session cookies for authenticated users.
* Browsers send all of the cookies associated with a domain to the web app every request regardless of how the request to app was generated within the browser.

However, CSRF attacks aren't limited to exploiting cookies. For example, Basic and Digest authentication are also vulnerable. After a user signs in with Basic or Digest authentication, the browser automatically sends the credentials until the session ends.

In this context, *session* refers to the client-side session during which the user is authenticated. It's unrelated to server-side sessions or [ASP.NET Core Session Middleware](xref:fundamentals/app-state).

Users can guard against CSRF vulnerabilities by taking precautions:

* Sign out of web apps when finished using them.
* Clear browser cookies periodically.

However, CSRF vulnerabilities are fundamentally a problem with the web app, not the end user.

## Authentication fundamentals

Cookie-based authentication is a popular form of authentication. Token-based authentication systems are growing in popularity, especially for Single Page Applications (SPAs).

### Cookie-based authentication

When a user authenticates using their username and password, they're issued a token, containing an authentication ticket that can be used for authentication and authorization. The token is stored as a cookie that's sent with every request the client makes. Generating and validating this cookie is performed by the Cookie Authentication Middleware. The [middleware](xref:fundamentals/middleware/index) serializes a user principal into an encrypted cookie. On subsequent requests, the middleware validates the cookie, recreates the principal, and assigns the principal to the <xref:Microsoft.AspNetCore.Http.HttpContext.User%2A?displayProperty=nameWithType> property.

### Token-based authentication

When a user is authenticated, they're issued a token (not an antiforgery token). The token contains user information in the form of [claims](/dotnet/framework/security/claims-based-identity-model) or a reference token that points the app to user state maintained in the app. When a user attempts to access a resource that requires authentication, the token is sent to the app with an extra authorization header in the form of a Bearer token. This approach makes the app stateless. In each subsequent request, the token is passed in the request for server-side validation. This token isn't *encrypted*; it's *encoded*. On the server, the token is decoded to access its information. To send the token on subsequent requests, store the token in the browser's local storage. Placing a token in the browser local storage and retrieving it and using it as a bearer token provides protection against CSRF attacks. However, should the app be vulnerable to script injection via XSS or a compromised external javascript file, an attacker could retrieve any value from local storage and send it to themselves. ASP.NET Core encodes all server side output from variables by default, reducing the risk of XSS. If you override this behavior by using [Html.Raw](xref:System.Web.Mvc.HtmlHelper.Raw%2A) or custom code with untrusted input then you may increase the risk of XSS.

Don't be concerned about CSRF vulnerability if the token is stored in the browser's local storage. CSRF is a concern when the token is stored in a cookie. For more information, see the GitHub issue [SPA code sample adds two cookies](https://github.com/dotnet/AspNetCore.Docs/issues/13369).

### Multiple apps hosted at one domain

Shared hosting environments are vulnerable to session hijacking, login CSRF, and other attacks.

Although `example1.contoso.net` and `example2.contoso.net` are different hosts, there's an implicit trust relationship between hosts under the `*.contoso.net` domain. This implicit trust relationship allows potentially untrusted hosts to affect each other's cookies (the same-origin policies that govern AJAX requests don't necessarily apply to HTTP cookies).

Attacks that exploit trusted cookies between apps hosted on the same domain can be prevented by not sharing domains. When each app is hosted on its own domain, there's no implicit cookie trust relationship to exploit.

<a name="anti7"></a>

## Antiforgery in ASP.NET Core

> [!WARNING]
> ASP.NET Core implements antiforgery using [ASP.NET Core Data Protection](xref:security/data-protection/introduction). The data protection stack must be configured to work in a server farm. For more information, see [Configuring data protection](xref:security/data-protection/configuration/overview).

Antiforgery middleware is added to the [Dependency injection](xref:fundamentals/dependency-injection) container when one of the following APIs is called in `Program.cs`:

* <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddMvc%2A>
* <xref:Microsoft.AspNetCore.Builder.RazorPagesEndpointRouteBuilderExtensions.MapRazorPages%2A>
* <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapControllerRoute%2A>
* <xref:Microsoft.AspNetCore.Builder.ComponentEndpointRouteBuilderExtensions.MapBlazorHub%2A>

The [FormTagHelper](xref:mvc/views/working-with-forms#the-form-tag-helper) injects antiforgery tokens into HTML form elements. The following markup in a Razor file automatically generates antiforgery tokens:

:::code language="cshtml" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Views/Home/Index.cshtml" id="snippet_Form":::

Similarly, <xref:Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.BeginForm%2A?displayProperty=nameWithType> generates antiforgery tokens by default if the form's method isn't GET.

The automatic generation of antiforgery tokens for HTML form elements happens when the `<form>` tag contains the `method="post"` attribute and either of the following are true:

* The action attribute is empty (`action=""`).
* The action attribute isn't supplied (`<form method="post">`).

Automatic generation of antiforgery tokens for HTML form elements can be disabled:

* Explicitly disable antiforgery tokens with the `asp-antiforgery` attribute:

  :::code language="cshtml" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Views/Home/Index.cshtml" id="snippet_FormAntiforgeryFalse":::

* The form element is opted-out of Tag Helpers by using the Tag Helper [! opt-out symbol](xref:mvc/views/tag-helpers/intro#opt-out):

  :::code language="cshtml" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Views/Home/Index.cshtml" id="snippet_FormTagHelperDisabled":::

* Remove the `FormTagHelper` from the view. The `FormTagHelper` can be removed from a view by adding the following directive to the Razor view:

  :::code language="cshtml" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Views/Home/Index.cshtml" id="snippet_FormRemoveTagHelper":::

> [!NOTE]
> [Razor Pages](xref:razor-pages/index) are automatically protected from XSRF/CSRF. For more information, see [XSRF/CSRF and Razor Pages](xref:razor-pages/index#xsrfcsrf-and-razor-pages-1).

The most common approach to defending against CSRF attacks is to use the *Synchronizer Token Pattern* (STP). STP is used when the user requests a page with form data:

1. The server sends a token associated with the current user's identity to the client.
1. The client sends back the token to the server for verification.
1. If the server receives a token that doesn't match the authenticated user's identity, the request is rejected.

The token is unique and unpredictable. The token can also be used to ensure proper sequencing of a series of requests (for example, ensuring the request sequence of: page 1 > page 2 > page 3). All of the forms in ASP.NET Core MVC and Razor Pages templates generate antiforgery tokens. The following pair of view examples generates antiforgery tokens:

:::code language="cshtml" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Views/Home/Index.cshtml" id="snippet_FormControllerExamples":::

Explicitly add an antiforgery token to a `<form>` element without using Tag Helpers with the HTML helper [`@Html.AntiForgeryToken`](xref:Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper.AntiForgeryToken%2A):

:::code language="cshtml" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Views/Home/Index.cshtml" id="snippet_FormExplicit":::

In each of the preceding cases, ASP.NET Core adds a hidden form field similar to the following example:

```html
<input name="__RequestVerificationToken" type="hidden" value="CfDJ8NrAkS ... s2-m9Yw">
```

ASP.NET Core includes three [filters](xref:mvc/controllers/filters) for working with antiforgery tokens:

* [ValidateAntiForgeryToken](xref:Microsoft.AspNetCore.Mvc.ValidateAntiForgeryTokenAttribute)
* [AutoValidateAntiforgeryToken](xref:Microsoft.AspNetCore.Mvc.AutoValidateAntiforgeryTokenAttribute)
* [IgnoreAntiforgeryToken](xref:Microsoft.AspNetCore.Mvc.IgnoreAntiforgeryTokenAttribute)

## Antiforgery with `AddControllers`

Calling <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddControllers%2A> does ***not*** enable antiforgery tokens. <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddControllersWithViews%2A> must be called to have built-in antiforgery token support.

## Multiple browser tabs and the Synchronizer Token Pattern

With the Synchronizer Token Pattern, only the most recently loaded page contains a valid antiforgery token. Using multiple tabs can be problematic. For example, if a user opens multiple tabs:

 * Only the most recently loaded tab contains a valid antiforgery token.
 * Requests made from previously loaded tabs fail with an error: `Antiforgery token validation failed. The antiforgery cookie token and request token do not match`
 
 Consider alternative CSRF protection patterns if this poses an issue.

## Configure antiforgery with `AntiforgeryOptions`

Customize <xref:Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions> in `Program.cs`:

:::code language="csharp" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Program.cs" id="snippet_AddAntiforgeryOptions":::

Set the antiforgery `Cookie` properties using the properties of the <xref:Microsoft.AspNetCore.Http.CookieBuilder> class, as shown in the following table.

| Option | Description |
| --- | --- |
| <xref:Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions.Cookie%2A> | Determines the settings used to create the antiforgery cookies. |
| <xref:Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions.FormFieldName%2A> | The name of the hidden form field used by the antiforgery system to render antiforgery tokens in views. |
| <xref:Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions.HeaderName%2A> | The name of the header used by the antiforgery system. If `null`, the system considers only form data. |
| <xref:Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions.SuppressXFrameOptionsHeader%2A> | Specifies whether to suppress generation of the `X-Frame-Options` header. By default, the header is generated with a value of "SAMEORIGIN". Defaults to `false`. |

For more information, see <xref:Microsoft.AspNetCore.Builder.CookieAuthenticationOptions>.

## Generate antiforgery tokens with `IAntiforgery`

<xref:Microsoft.AspNetCore.Antiforgery.IAntiforgery> provides the API to configure antiforgery features. `IAntiforgery` can be requested in `Program.cs` using <xref:Microsoft.AspNetCore.Builder.WebApplication.Services%2A?displayProperty=nameWithType>. The following example uses middleware from the app's home page to generate an antiforgery token and send it in the response as a cookie:

:::code language="csharp" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Program.cs" id="snippet_Middleware" highlight="5,7-20":::

The preceding example sets a cookie named `XSRF-TOKEN`. The client can read this cookie and provide its value as a header attached to AJAX requests. For example, Angular includes [built-in XSRF protection](https://angular.io/guide/http#security-xsrf-protection) that reads a cookie named `XSRF-TOKEN` by default.

### Require antiforgery validation

The [ValidateAntiForgeryToken](xref:Microsoft.AspNetCore.Mvc.ValidateAntiForgeryTokenAttribute) action filter can be applied to an individual action, a controller, or globally. Requests made to actions that have this filter applied are blocked unless the request includes a valid antiforgery token:

:::code language="csharp" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Controllers/HomeController.cs" id="snippet_ValidateAntiForgeryToken" highlight="2":::

The `ValidateAntiForgeryToken` attribute requires a token for requests to the action methods it marks, including HTTP GET requests. If the `ValidateAntiForgeryToken` attribute is applied across the app's controllers, it can be overridden with the `IgnoreAntiforgeryToken` attribute.

### Automatically validate antiforgery tokens for unsafe HTTP methods only

Instead of broadly applying the `ValidateAntiForgeryToken` attribute and then overriding it with `IgnoreAntiforgeryToken` attributes, the [AutoValidateAntiforgeryToken](xref:Microsoft.AspNetCore.Mvc.AutoValidateAntiforgeryTokenAttribute) attribute can be used. This attribute works identically to the `ValidateAntiForgeryToken` attribute, except that it doesn't require tokens for requests made using the following HTTP methods:

* GET
* HEAD
* OPTIONS
* TRACE

We recommend use of `AutoValidateAntiforgeryToken` broadly for non-API scenarios. This attribute ensures POST actions are protected by default. The alternative is to ignore antiforgery tokens by default, unless `ValidateAntiForgeryToken` is applied to individual action methods. It's more likely in this scenario for a POST action method to be left unprotected by mistake, leaving the app vulnerable to CSRF attacks. All POSTs should send the antiforgery token.

APIs don't have an automatic mechanism for sending the non-cookie part of the token. The implementation probably depends on the client code implementation. Some examples are shown below:

Class-level example:

:::code language="csharp" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Controllers/HomeController.cs" id="snippet_AutoValidateAntiforgeryToken":::

Global example:

:::code language="csharp" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Program.cs" id="snippet_AddControllersWithViewsAutoValidateAntiforgeryTokenAttribute" highlight="3":::

### Override global or controller antiforgery attributes

The [IgnoreAntiforgeryToken](xref:Microsoft.AspNetCore.Mvc.IgnoreAntiforgeryTokenAttribute) filter is used to eliminate the need for an antiforgery token for a given action (or controller). When applied, this filter overrides `ValidateAntiForgeryToken` and `AutoValidateAntiforgeryToken` filters specified at a higher level (globally or on a controller).

:::code language="csharp" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Controllers/HomeController.cs" id="snippet_IgnoreAntiforgeryToken" highlight="1":::

## Refresh tokens after authentication

Tokens should be refreshed after the user is authenticated by redirecting the user to a view or Razor Pages page.

## JavaScript, AJAX, and SPAs

In traditional HTML-based apps, antiforgery tokens are passed to the server using hidden form fields. In modern JavaScript-based apps and SPAs, many requests are made programmatically. These AJAX requests may use other techniques (such as request headers or cookies) to send the token.

If cookies are used to store authentication tokens and to authenticate API requests on the server, CSRF is a potential problem. If local storage is used to store the token, CSRF vulnerability might be mitigated because values from local storage aren't sent automatically to the server with every request. Using local storage to store the antiforgery token on the client and sending the token as a request header is a recommended approach.

### JavaScript

Using JavaScript with views, the token can be created using a service from within the view. Inject the <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgery> service into the view and call <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgery.GetAndStoreTokens%2A>:

:::code language="cshtml" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Views/JavaScript/Index.cshtml" highlight="1,6,9,23-26":::

The preceding example uses JavaScript to read the hidden field value for the AJAX POST header. 

This approach eliminates the need to deal directly with setting cookies from the server or reading them from the client. However, when injecting the <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgery> service isn't possible, use JavaScript to access tokens in cookies:

* Access tokens in an additional request to the server, typically usually `same-origin`.
* Use the cookie's contents to create a header with the token's value. 

Assuming the script sends the token in a request header called `X-XSRF-TOKEN`, configure the antiforgery service to look for the `X-XSRF-TOKEN` header:

:::code language="csharp" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Program.cs" id="snippet_AddAntiforgeryOptionsJavaScript":::

The following example adds a protected endpoint that writes the request token to a JavaScript-readable cookie:

:::code language="csharp" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Program.cs" id="snippet_AddAntiforgeryEndpoint":::

The following example uses JavaScript to make an AJAX request to obtain the token and make another request with the appropriate header:

:::code language="javascript" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Index.js" highlight="1,15":::

<a name="antimin7"></a>

> [!NOTE]
> When the antiforgery token is provided in both the request header and in the form payload, only the token in the header is validated.

### Antiforgery with Minimal APIs

`Minimal APIs` do not support the usage of the included filters (`ValidateAntiForgeryToken`, `AutoValidateAntiforgeryToken`, `IgnoreAntiforgeryToken`), however, <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgery> provides the required APIs to validate a request.

The following example creates a filter that validates the antiforgery token:

[!code-csharp[](anti-request-forgery/samples/7.x/AntiRequestForgeryMinimalSample/Program.cs?name=snippet_AntiforgeryFilter&highlight=9-10)]

The filter can then be applied to an endpoint:

[!code-csharp[](anti-request-forgery/samples/7.x/AntiRequestForgeryMinimalSample/Program.cs?name=snippet_AntiforgeryEndpoint&highlight=3)]

## Windows authentication and antiforgery cookies

When using Windows Authentication, application endpoints must be protected against CSRF attacks in the same way as done for cookies. The browser implicitly sends the authentication context to the server and endpoints need to be protected against CSRF attacks.

## Extend antiforgery

The <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgeryAdditionalDataProvider> type allows developers to extend the behavior of the anti-CSRF system by round-tripping additional data in each token. The <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgeryAdditionalDataProvider.GetAdditionalData%2A> method is called each time a field token is generated, and the return value is embedded within the generated token. An implementer could return a timestamp, a nonce, or any other value and then call <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgeryAdditionalDataProvider.ValidateAdditionalData%2A> to validate this data when the token is validated. The client's username is already embedded in the generated tokens, so there's no need to include this information. If a token includes supplemental data but no `IAntiForgeryAdditionalDataProvider` is configured, the supplemental data isn't validated.

## Additional resources

* <xref:host-and-deploy/web-farm>

:::moniker-end

:::moniker range="= aspnetcore-6.0"

Cross-site request forgery (also known as XSRF or CSRF) is an attack against web-hosted apps whereby a malicious web app can influence the interaction between a client browser and a web app that trusts that browser. These attacks are possible because web browsers send some types of authentication tokens automatically with every request to a website. This form of exploit is also known as a *one-click attack* or *session riding* because the attack takes advantage of the user's previously authenticated session.

An example of a CSRF attack:

1. A user signs into `www.good-banking-site.example.com` using forms authentication. The server authenticates the user and issues a response that includes an authentication cookie. The site is vulnerable to attack because it trusts any request that it receives with a valid authentication cookie.
1. The user visits a malicious site, `www.bad-crook-site.example.com`.

   The malicious site, `www.bad-crook-site.example.com`, contains an HTML form similar to the following example:

   :::code language="html" source="anti-request-forgery/samples_snapshot/vulnerable-form.html":::

   Notice that the form's `action` posts to the vulnerable site, not to the malicious site. This is the "cross-site" part of CSRF.

1. The user selects the submit button. The browser makes the request and automatically includes the authentication cookie for the requested domain, `www.good-banking-site.example.com`.
1. The request runs on the `www.good-banking-site.example.com` server with the user's authentication context and can perform any action that an authenticated user is allowed to perform.

In addition to the scenario where the user selects the button to submit the form, the malicious site could:

* Run a script that automatically submits the form.
* Send the form submission as an AJAX request.
* Hide the form using CSS.

These alternative scenarios don't require any action or input from the user other than initially visiting the malicious site.

Using HTTPS doesn't prevent a CSRF attack. The malicious site can send an `https://www.good-banking-site.com/` request just as easily as it can send an insecure request.

Some attacks target endpoints that respond to GET requests, in which case an image tag can be used to perform the action. This form of attack is common on forum sites that permit images but block JavaScript. Apps that change state on GET requests, where variables or resources are altered, are vulnerable to malicious attacks. **GET requests that change state are insecure. A best practice is to never change state on a GET request.**

CSRF attacks are possible against web apps that use cookies for authentication because:

* Browsers store cookies issued by a web app.
* Stored cookies include session cookies for authenticated users.
* Browsers send all of the cookies associated with a domain to the web app every request regardless of how the request to app was generated within the browser.

However, CSRF attacks aren't limited to exploiting cookies. For example, Basic and Digest authentication are also vulnerable. After a user signs in with Basic or Digest authentication, the browser automatically sends the credentials until the session ends.

In this context, *session* refers to the client-side session during which the user is authenticated. It's unrelated to server-side sessions or [ASP.NET Core Session Middleware](xref:fundamentals/app-state).

Users can guard against CSRF vulnerabilities by taking precautions:

* Sign out of web apps when finished using them.
* Clear browser cookies periodically.

However, CSRF vulnerabilities are fundamentally a problem with the web app, not the end user.

## Authentication fundamentals

Cookie-based authentication is a popular form of authentication. Token-based authentication systems are growing in popularity, especially for Single Page Applications (SPAs).

### Cookie-based authentication

When a user authenticates using their username and password, they're issued a token, containing an authentication ticket that can be used for authentication and authorization. The token is stored as a cookie that's sent with every request the client makes. Generating and validating this cookie is performed by the Cookie Authentication Middleware. The [middleware](xref:fundamentals/middleware/index) serializes a user principal into an encrypted cookie. On subsequent requests, the middleware validates the cookie, recreates the principal, and assigns the principal to the <xref:Microsoft.AspNetCore.Http.HttpContext.User%2A?displayProperty=nameWithType> property.

### Token-based authentication

When a user is authenticated, they're issued a token (not an antiforgery token). The token contains user information in the form of [claims](/dotnet/framework/security/claims-based-identity-model) or a reference token that points the app to user state maintained in the app. When a user attempts to access a resource that requires authentication, the token is sent to the app with an extra authorization header in the form of a Bearer token. This approach makes the app stateless. In each subsequent request, the token is passed in the request for server-side validation. This token isn't *encrypted*; it's *encoded*. On the server, the token is decoded to access its information. To send the token on subsequent requests, store the token in the browser's local storage. Don't be concerned about CSRF vulnerability if the token is stored in the browser's local storage. CSRF is a concern when the token is stored in a cookie. For more information, see the GitHub issue [SPA code sample adds two cookies](https://github.com/dotnet/AspNetCore.Docs/issues/13369).

### Multiple apps hosted at one domain

Shared hosting environments are vulnerable to session hijacking, login CSRF, and other attacks.

Although `example1.contoso.net` and `example2.contoso.net` are different hosts, there's an implicit trust relationship between hosts under the `*.contoso.net` domain. This implicit trust relationship allows potentially untrusted hosts to affect each other's cookies (the same-origin policies that govern AJAX requests don't necessarily apply to HTTP cookies).

Attacks that exploit trusted cookies between apps hosted on the same domain can be prevented by not sharing domains. When each app is hosted on its own domain, there's no implicit cookie trust relationship to exploit.

## Antiforgery in ASP.NET Core

> [!WARNING]
> ASP.NET Core implements antiforgery using [ASP.NET Core Data Protection](xref:security/data-protection/introduction). The data protection stack must be configured to work in a server farm. For more information, see [Configuring data protection](xref:security/data-protection/configuration/overview).

Antiforgery middleware is added to the [Dependency injection](xref:fundamentals/dependency-injection) container when one of the following APIs is called in `Program.cs`:

* <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddMvc%2A>
* <xref:Microsoft.AspNetCore.Builder.RazorPagesEndpointRouteBuilderExtensions.MapRazorPages%2A>
* <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapControllerRoute%2A>
* <xref:Microsoft.AspNetCore.Builder.ComponentEndpointRouteBuilderExtensions.MapBlazorHub%2A>

The [FormTagHelper](xref:mvc/views/working-with-forms#the-form-tag-helper) injects antiforgery tokens into HTML form elements. The following markup in a Razor file automatically generates antiforgery tokens:

:::code language="cshtml" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Views/Home/Index.cshtml" id="snippet_Form":::

Similarly, <xref:Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.BeginForm%2A?displayProperty=nameWithType> generates antiforgery tokens by default if the form's method isn't GET.

The automatic generation of antiforgery tokens for HTML form elements happens when the `<form>` tag contains the `method="post"` attribute and either of the following are true:

* The action attribute is empty (`action=""`).
* The action attribute isn't supplied (`<form method="post">`).

Automatic generation of antiforgery tokens for HTML form elements can be disabled:

* Explicitly disable antiforgery tokens with the `asp-antiforgery` attribute:

  :::code language="cshtml" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Views/Home/Index.cshtml" id="snippet_FormAntiforgeryFalse":::

* The form element is opted-out of Tag Helpers by using the Tag Helper [! opt-out symbol](xref:mvc/views/tag-helpers/intro#opt-out):

  :::code language="cshtml" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Views/Home/Index.cshtml" id="snippet_FormTagHelperDisabled":::

* Remove the `FormTagHelper` from the view. The `FormTagHelper` can be removed from a view by adding the following directive to the Razor view:

  :::code language="cshtml" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Views/Home/Index.cshtml" id="snippet_FormRemoveTagHelper":::

> [!NOTE]
> [Razor Pages](xref:razor-pages/index) are automatically protected from XSRF/CSRF. For more information, see [XSRF/CSRF and Razor Pages](xref:razor-pages/index#xsrfcsrf-and-razor-pages-1).

The most common approach to defending against CSRF attacks is to use the *Synchronizer Token Pattern* (STP). STP is used when the user requests a page with form data:

1. The server sends a token associated with the current user's identity to the client.
1. The client sends back the token to the server for verification.
1. If the server receives a token that doesn't match the authenticated user's identity, the request is rejected.

The token is unique and unpredictable. The token can also be used to ensure proper sequencing of a series of requests (for example, ensuring the request sequence of: page 1 > page 2 > page 3). All of the forms in ASP.NET Core MVC and Razor Pages templates generate antiforgery tokens. The following pair of view examples generates antiforgery tokens:

:::code language="cshtml" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Views/Home/Index.cshtml" id="snippet_FormControllerExamples":::

Explicitly add an antiforgery token to a `<form>` element without using Tag Helpers with the HTML helper [`@Html.AntiForgeryToken`](xref:Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper.AntiForgeryToken%2A):

:::code language="cshtml" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Views/Home/Index.cshtml" id="snippet_FormExplicit":::

In each of the preceding cases, ASP.NET Core adds a hidden form field similar to the following example:

```html
<input name="__RequestVerificationToken" type="hidden" value="CfDJ8NrAkS ... s2-m9Yw">
```

ASP.NET Core includes three [filters](xref:mvc/controllers/filters) for working with antiforgery tokens:

* [ValidateAntiForgeryToken](xref:Microsoft.AspNetCore.Mvc.ValidateAntiForgeryTokenAttribute)
* [AutoValidateAntiforgeryToken](xref:Microsoft.AspNetCore.Mvc.AutoValidateAntiforgeryTokenAttribute)
* [IgnoreAntiforgeryToken](xref:Microsoft.AspNetCore.Mvc.IgnoreAntiforgeryTokenAttribute)

### Antiforgery with AddControllers

Calling <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddControllers%2A> does ***not*** enable antiforgery tokens. <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddControllersWithViews%2A> must be called to have built-in antiforgery token support.

## Multiple browser tabs and the Synchronizer Token Pattern

With the Synchronizer Token Pattern, only the most recently loaded page contains a valid antiforgery token. Using multiple tabs can be problematic. For example, if a user opens multiple tabs:

 * Only the most recently loaded tab contains a valid antiforgery token.
 * Requests made from previously loaded tabs fail with an error: `Antiforgery token validation failed. The antiforgery cookie token and request token do not match`
 
 Consider alternative CSRF protection patterns if this poses an issue.

## Configure antiforgery with `AntiforgeryOptions`

Customize <xref:Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions> in `Program.cs`:

:::code language="csharp" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Program.cs" id="snippet_AddAntiforgeryOptions":::

Set the antiforgery `Cookie` properties using the properties of the <xref:Microsoft.AspNetCore.Http.CookieBuilder> class, as shown in the following table.

| Option | Description |
| --- | --- |
| <xref:Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions.Cookie%2A> | Determines the settings used to create the antiforgery cookies. |
| <xref:Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions.FormFieldName%2A> | The name of the hidden form field used by the antiforgery system to render antiforgery tokens in views. |
| <xref:Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions.HeaderName%2A> | The name of the header used by the antiforgery system. If `null`, the system considers only form data. |
| <xref:Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions.SuppressXFrameOptionsHeader%2A> | Specifies whether to suppress generation of the `X-Frame-Options` header. By default, the header is generated with a value of "SAMEORIGIN". Defaults to `false`. |

For more information, see <xref:Microsoft.AspNetCore.Builder.CookieAuthenticationOptions>.

## Generate antiforgery tokens with `IAntiforgery`

<xref:Microsoft.AspNetCore.Antiforgery.IAntiforgery> provides the API to configure antiforgery features. `IAntiforgery` can be requested in `Program.cs` using <xref:Microsoft.AspNetCore.Builder.WebApplication.Services%2A?displayProperty=nameWithType>. The following example uses middleware from the app's home page to generate an antiforgery token and send it in the response as a cookie:

:::code language="csharp" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Program.cs" id="snippet_Middleware" highlight="5,7-20":::

The preceding example sets a cookie named `XSRF-TOKEN`. The client can read this cookie and provide its value as a header attached to AJAX requests. For example, Angular includes [built-in XSRF protection](https://angular.io/guide/http#security-xsrf-protection) that reads a cookie named `XSRF-TOKEN` by default.

### Require antiforgery validation

The [ValidateAntiForgeryToken](xref:Microsoft.AspNetCore.Mvc.ValidateAntiForgeryTokenAttribute) action filter can be applied to an individual action, a controller, or globally. Requests made to actions that have this filter applied are blocked unless the request includes a valid antiforgery token:

:::code language="csharp" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Controllers/HomeController.cs" id="snippet_ValidateAntiForgeryToken" highlight="2":::

The `ValidateAntiForgeryToken` attribute requires a token for requests to the action methods it marks, including HTTP GET requests. If the `ValidateAntiForgeryToken` attribute is applied across the app's controllers, it can be overridden with the `IgnoreAntiforgeryToken` attribute.

### Automatically validate antiforgery tokens for unsafe HTTP methods only

Instead of broadly applying the `ValidateAntiForgeryToken` attribute and then overriding it with `IgnoreAntiforgeryToken` attributes, the [AutoValidateAntiforgeryToken](xref:Microsoft.AspNetCore.Mvc.AutoValidateAntiforgeryTokenAttribute) attribute can be used. This attribute works identically to the `ValidateAntiForgeryToken` attribute, except that it doesn't require tokens for requests made using the following HTTP methods:

* GET
* HEAD
* OPTIONS
* TRACE

We recommend use of `AutoValidateAntiforgeryToken` broadly for non-API scenarios. This attribute ensures POST actions are protected by default. The alternative is to ignore antiforgery tokens by default, unless `ValidateAntiForgeryToken` is applied to individual action methods. It's more likely in this scenario for a POST action method to be left unprotected by mistake, leaving the app vulnerable to CSRF attacks. All POSTs should send the antiforgery token.

APIs don't have an automatic mechanism for sending the non-cookie part of the token. The implementation probably depends on the client code implementation. Some examples are shown below:

Class-level example:

:::code language="csharp" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Controllers/HomeController.cs" id="snippet_AutoValidateAntiforgeryToken":::

Global example:

:::code language="csharp" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Program.cs" id="snippet_AddControllersWithViewsAutoValidateAntiforgeryTokenAttribute" highlight="3":::

### Override global or controller antiforgery attributes

The [IgnoreAntiforgeryToken](xref:Microsoft.AspNetCore.Mvc.IgnoreAntiforgeryTokenAttribute) filter is used to eliminate the need for an antiforgery token for a given action (or controller). When applied, this filter overrides `ValidateAntiForgeryToken` and `AutoValidateAntiforgeryToken` filters specified at a higher level (globally or on a controller).

:::code language="csharp" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Controllers/HomeController.cs" id="snippet_IgnoreAntiforgeryToken" highlight="1":::

## Refresh tokens after authentication

Tokens should be refreshed after the user is authenticated by redirecting the user to a view or Razor Pages page.

## JavaScript, AJAX, and SPAs

In traditional HTML-based apps, antiforgery tokens are passed to the server using hidden form fields. In modern JavaScript-based apps and SPAs, many requests are made programmatically. These AJAX requests may use other techniques (such as request headers or cookies) to send the token.

If cookies are used to store authentication tokens and to authenticate API requests on the server, CSRF is a potential problem. If local storage is used to store the token, CSRF vulnerability might be mitigated because values from local storage aren't sent automatically to the server with every request. Using local storage to store the antiforgery token on the client and sending the token as a request header is a recommended approach.

### JavaScript

Using JavaScript with views, the token can be created using a service from within the view. Inject the <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgery> service into the view and call <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgery.GetAndStoreTokens%2A>:

:::code language="cshtml" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Views/JavaScript/Index.cshtml" highlight="1,6,9,23-26":::

The preceding example uses JavaScript to read the hidden field value for the AJAX POST header. 

This approach eliminates the need to deal directly with setting cookies from the server or reading them from the client. However, when injecting the <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgery> service is not possible, JavaScript can also access token in cookies, obtained from an additional request to the server (usually `same-origin`), and use the cookie's contents to create a header with the token's value. 

Assuming the script sends the token in a request header called `X-XSRF-TOKEN`, configure the antiforgery service to look for the `X-XSRF-TOKEN` header:

:::code language="csharp" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Program.cs" id="snippet_AddAntiforgeryOptionsJavaScript":::

The following example adds a protected endpoint that will write the request token to a JavaScript-readable cookie:

:::code language="csharp" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Program.cs" id="snippet_AddAntiforgeryEndpoint":::

The following example uses JavaScript to make an AJAX request to obtain the token and make another request with the appropriate header:

:::code language="javascript" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Index.js" highlight="1,15":::

## Windows authentication and antiforgery cookies

When using Windows Authentication, application endpoints must be protected against CSRF attacks in the same way as done for cookies. The browser implicitly sends the authentication context to the server and so endpoints need to be protected against CSRF attacks.

## Extend antiforgery

The <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgeryAdditionalDataProvider> type allows developers to extend the behavior of the anti-CSRF system by round-tripping additional data in each token. The <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgeryAdditionalDataProvider.GetAdditionalData%2A> method is called each time a field token is generated, and the return value is embedded within the generated token. An implementer could return a timestamp, a nonce, or any other value and then call <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgeryAdditionalDataProvider.ValidateAdditionalData%2A> to validate this data when the token is validated. The client's username is already embedded in the generated tokens, so there's no need to include this information. If a token includes supplemental data but no `IAntiForgeryAdditionalDataProvider` is configured, the supplemental data isn't validated.

## Additional resources

* <xref:host-and-deploy/web-farm>

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Cross-site request forgery (also known as XSRF or CSRF) is an attack against web-hosted apps whereby a malicious web app can influence the interaction between a client browser and a web app that trusts that browser. These attacks are possible because web browsers send some types of authentication tokens automatically with every request to a website. This form of exploit is also known as a *one-click attack* or *session riding* because the attack takes advantage of the user's previously authenticated session.

An example of a CSRF attack:

1. A user signs into `www.good-banking-site.example.com` using forms authentication. The server authenticates the user and issues a response that includes an authentication cookie. The site is vulnerable to attack because it trusts any request that it receives with a valid authentication cookie.
1. The user visits a malicious site, `www.bad-crook-site.example.com`.

   The malicious site, `www.bad-crook-site.example.com`, contains an HTML form similar to the following example:

   :::code language="html" source="anti-request-forgery/samples_snapshot/vulnerable-form.html":::

   Notice that the form's `action` posts to the vulnerable site, not to the malicious site. This is the "cross-site" part of CSRF.

1. The user selects the submit button. The browser makes the request and automatically includes the authentication cookie for the requested domain, `www.good-banking-site.example.com`.
1. The request runs on the `www.good-banking-site.example.com` server with the user's authentication context and can perform any action that an authenticated user is allowed to perform.

In addition to the scenario where the user selects the button to submit the form, the malicious site could:

* Run a script that automatically submits the form.
* Send the form submission as an AJAX request.
* Hide the form using CSS.

These alternative scenarios don't require any action or input from the user other than initially visiting the malicious site.

Using HTTPS doesn't prevent a CSRF attack. The malicious site can send an `https://www.good-banking-site.com/` request just as easily as it can send an insecure request.

Some attacks target endpoints that respond to GET requests, in which case an image tag can be used to perform the action. This form of attack is common on forum sites that permit images but block JavaScript. Apps that change state on GET requests, where variables or resources are altered, are vulnerable to malicious attacks. **GET requests that change state are insecure. A best practice is to never change state on a GET request.**

CSRF attacks are possible against web apps that use cookies for authentication because:

* Browsers store cookies issued by a web app.
* Stored cookies include session cookies for authenticated users.
* Browsers send all of the cookies associated with a domain to the web app every request regardless of how the request to app was generated within the browser.

However, CSRF attacks aren't limited to exploiting cookies. For example, Basic and Digest authentication are also vulnerable. After a user signs in with Basic or Digest authentication, the browser automatically sends the credentials until the session ends.

In this context, *session* refers to the client-side session during which the user is authenticated. It's unrelated to server-side sessions or [ASP.NET Core Session Middleware](xref:fundamentals/app-state).

Users can guard against CSRF vulnerabilities by taking precautions:

* Sign out of web apps when finished using them.
* Clear browser cookies periodically.

However, CSRF vulnerabilities are fundamentally a problem with the web app, not the end user.

## Authentication fundamentals

Cookie-based authentication is a popular form of authentication. Token-based authentication systems are growing in popularity, especially for Single Page Applications (SPAs).

### Cookie-based authentication

When a user authenticates using their username and password, they're issued a token, containing an authentication ticket that can be used for authentication and authorization. The token is stored as a cookie that's sent with every request the client makes. Generating and validating this cookie is performed by the Cookie Authentication Middleware. The [middleware](xref:fundamentals/middleware/index) serializes a user principal into an encrypted cookie. On subsequent requests, the middleware validates the cookie, recreates the principal, and assigns the principal to the <xref:Microsoft.AspNetCore.Http.HttpContext.User%2A?displayProperty=nameWithType> property.

### Token-based authentication

When a user is authenticated, they're issued a token (not an antiforgery token). The token contains user information in the form of [claims](/dotnet/framework/security/claims-based-identity-model) or a reference token that points the app to user state maintained in the app. When a user attempts to access a resource that requires authentication, the token is sent to the app with an extra authorization header in the form of a Bearer token. This approach makes the app stateless. In each subsequent request, the token is passed in the request for server-side validation. This token isn't *encrypted*; it's *encoded*. On the server, the token is decoded to access its information. To send the token on subsequent requests, store the token in the browser's local storage. Don't be concerned about CSRF vulnerability if the token is stored in the browser's local storage. CSRF is a concern when the token is stored in a cookie. For more information, see the GitHub issue [SPA code sample adds two cookies](https://github.com/dotnet/AspNetCore.Docs/issues/13369).

### Multiple apps hosted at one domain

Shared hosting environments are vulnerable to session hijacking, login CSRF, and other attacks.

Although `example1.contoso.net` and `example2.contoso.net` are different hosts, there's an implicit trust relationship between hosts under the `*.contoso.net` domain. This implicit trust relationship allows potentially untrusted hosts to affect each other's cookies (the same-origin policies that govern AJAX requests don't necessarily apply to HTTP cookies).

Attacks that exploit trusted cookies between apps hosted on the same domain can be prevented by not sharing domains. When each app is hosted on its own domain, there's no implicit cookie trust relationship to exploit.

## ASP.NET Core antiforgery configuration

> [!WARNING]
> ASP.NET Core implements antiforgery using [ASP.NET Core Data Protection](xref:security/data-protection/introduction). The data protection stack must be configured to work in a server farm. For more information, see [Configuring data protection](xref:security/data-protection/configuration/overview).

Antiforgery middleware is added to the [Dependency injection](xref:fundamentals/dependency-injection) container when one of the following APIs is called in `Startup.ConfigureServices`:

* <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddMvc%2A>
* <xref:Microsoft.AspNetCore.Builder.RazorPagesEndpointRouteBuilderExtensions.MapRazorPages%2A>
* <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapControllerRoute%2A>
* <xref:Microsoft.AspNetCore.Builder.ComponentEndpointRouteBuilderExtensions.MapBlazorHub%2A>

In ASP.NET Core 2.0 or later, the [FormTagHelper](xref:mvc/views/working-with-forms#the-form-tag-helper) injects antiforgery tokens into HTML form elements. The following markup in a Razor file automatically generates antiforgery tokens:

```cshtml
<form method="post">
    ...
</form>
```

Similarly, <xref:Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.BeginForm%2A?displayProperty=nameWithType> generates antiforgery tokens by default if the form's method isn't GET.

The automatic generation of antiforgery tokens for HTML form elements happens when the `<form>` tag contains the `method="post"` attribute and either of the following are true:

* The action attribute is empty (`action=""`).
* The action attribute isn't supplied (`<form method="post">`).

Automatic generation of antiforgery tokens for HTML form elements can be disabled:

* Explicitly disable antiforgery tokens with the `asp-antiforgery` attribute:

  ```cshtml
  <form method="post" asp-antiforgery="false">
      ...
  </form>
  ```

* The form element is opted-out of Tag Helpers by using the Tag Helper [! opt-out symbol](xref:mvc/views/tag-helpers/intro#opt-out):

  ```cshtml
  <!form method="post">
      ...
  </!form>
  ```

* Remove the `FormTagHelper` from the view. The `FormTagHelper` can be removed from a view by adding the following directive to the Razor view:

  ```cshtml
  @removeTagHelper Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper, Microsoft.AspNetCore.Mvc.TagHelpers
  ```

> [!NOTE]
> [Razor Pages](xref:razor-pages/index) are automatically protected from XSRF/CSRF. For more information, see [XSRF/CSRF and Razor Pages](xref:razor-pages/index#xsrf).

The most common approach to defending against CSRF attacks is to use the *Synchronizer Token Pattern* (STP). STP is used when the user requests a page with form data:

1. The server sends a token associated with the current user's identity to the client.
1. The client sends back the token to the server for verification.
1. If the server receives a token that doesn't match the authenticated user's identity, the request is rejected.

The token is unique and unpredictable. The token can also be used to ensure proper sequencing of a series of requests (for example, ensuring the request sequence of: page 1 > page 2 > page 3). All of the forms in ASP.NET Core MVC and Razor Pages templates generate antiforgery tokens. The following pair of view examples generates antiforgery tokens:

```cshtml
<form asp-controller="Todo" asp-action="Create" method="post">
    ...
</form>

@using (Html.BeginForm("Create", "Todo"))
{
    ...
}
```

Explicitly add an antiforgery token to a `<form>` element without using Tag Helpers with the HTML helper [`@Html.AntiForgeryToken`](xref:Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper.AntiForgeryToken%2A):

```cshtml
<form action="/" method="post">
    @Html.AntiForgeryToken()
</form>
```

In each of the preceding cases, ASP.NET Core adds a hidden form field similar to the following example:

```cshtml
<input name="__RequestVerificationToken" type="hidden" value="CfDJ8NrAkS ... s2-m9Yw">
```

ASP.NET Core includes three [filters](xref:mvc/controllers/filters) for working with antiforgery tokens:

* [ValidateAntiForgeryToken](xref:Microsoft.AspNetCore.Mvc.ValidateAntiForgeryTokenAttribute)
* [AutoValidateAntiforgeryToken](xref:Microsoft.AspNetCore.Mvc.AutoValidateAntiforgeryTokenAttribute)
* [IgnoreAntiforgeryToken](xref:Microsoft.AspNetCore.Mvc.IgnoreAntiforgeryTokenAttribute)

## Antiforgery options

Customize <xref:Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions> in `Startup.ConfigureServices`:

```csharp
services.AddAntiforgery(options => 
{
    options.FormFieldName = "AntiforgeryFieldname";
    options.HeaderName = "X-CSRF-TOKEN-HEADERNAME";
    options.SuppressXFrameOptionsHeader = false;
});
```

Set the antiforgery `Cookie` properties using the properties of the <xref:Microsoft.AspNetCore.Http.CookieBuilder> class, as shown in the following table.

| Option | Description |
| --- | --- |
| <xref:Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions.Cookie%2A> | Determines the settings used to create the antiforgery cookies. |
| <xref:Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions.FormFieldName%2A> | The name of the hidden form field used by the antiforgery system to render antiforgery tokens in views. |
| <xref:Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions.HeaderName%2A> | The name of the header used by the antiforgery system. If `null`, the system considers only form data. |
| <xref:Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions.SuppressXFrameOptionsHeader%2A> | Specifies whether to suppress generation of the `X-Frame-Options` header. By default, the header is generated with a value of "SAMEORIGIN". Defaults to `false`. |

For more information, see <xref:Microsoft.AspNetCore.Builder.CookieAuthenticationOptions>.

## Configure antiforgery features with IAntiforgery

<xref:Microsoft.AspNetCore.Antiforgery.IAntiforgery> provides the API to configure antiforgery features. `IAntiforgery` can be requested in the `Configure` method of the `Startup` class.

In the following example:

* Middleware from the app's home page is used to generate an antiforgery token and send it in the response as a cookie.
* The request token is sent as a JavaScript-readable cookie with the default Angular naming convention described in the [AngularJS](#angularjs) section.

```csharp
public void Configure(IApplicationBuilder app, IAntiforgery antiforgery)
{
    app.Use(next => context =>
    {
        string path = context.Request.Path.Value;

        if (string.Equals(path, "/", StringComparison.OrdinalIgnoreCase) ||
            string.Equals(path, "/index.html", StringComparison.OrdinalIgnoreCase))
        {
            var tokens = antiforgery.GetAndStoreTokens(context);
            context.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken, 
                new CookieOptions() { HttpOnly = false });
        }

        return next(context);
    });
}
```

### Require antiforgery validation

[ValidateAntiForgeryToken](xref:Microsoft.AspNetCore.Mvc.ValidateAntiForgeryTokenAttribute) is an action filter that can be applied to an individual action, a controller, or globally. Requests made to actions that have this filter applied are blocked unless the request includes a valid antiforgery token.

```csharp
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> RemoveLogin(RemoveLoginViewModel account)
{
    ManageMessageId? message = ManageMessageId.Error;
    var user = await GetCurrentUserAsync();

    if (user != null)
    {
        var result = 
            await _userManager.RemoveLoginAsync(
                user, account.LoginProvider, account.ProviderKey);

        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(user, isPersistent: false);
            message = ManageMessageId.RemoveLoginSuccess;
        }
    }

    return RedirectToAction(nameof(ManageLogins), new { Message = message });
}
```

The `ValidateAntiForgeryToken` attribute requires a token for requests to the action methods it marks, including HTTP GET requests. If the `ValidateAntiForgeryToken` attribute is applied across the app's controllers, it can be overridden with the `IgnoreAntiforgeryToken` attribute.

> [!NOTE]
> ASP.NET Core doesn't support adding antiforgery tokens to GET requests automatically.

### Automatically validate antiforgery tokens for unsafe HTTP methods only

ASP.NET Core apps don't generate antiforgery tokens for safe HTTP methods (GET, HEAD, OPTIONS, and TRACE). Instead of broadly applying the `ValidateAntiForgeryToken` attribute and then overriding it with `IgnoreAntiforgeryToken` attributes, the [AutoValidateAntiforgeryToken](xref:Microsoft.AspNetCore.Mvc.AutoValidateAntiforgeryTokenAttribute) attribute can be used. This attribute works identically to the `ValidateAntiForgeryToken` attribute, except that it doesn't require tokens for requests made using the following HTTP methods:

* GET
* HEAD
* OPTIONS
* TRACE

We recommend use of `AutoValidateAntiforgeryToken` broadly for non-API scenarios. This attribute ensures POST actions are protected by default. The alternative is to ignore antiforgery tokens by default, unless `ValidateAntiForgeryToken` is applied to individual action methods. It's more likely in this scenario for a POST action method to be left unprotected by mistake, leaving the app vulnerable to CSRF attacks. All POSTs should send the antiforgery token.

APIs don't have an automatic mechanism for sending the non-cookie part of the token. The implementation probably depends on the client code implementation. Some examples are shown below:

Class-level example:

```csharp
[Authorize]
[AutoValidateAntiforgeryToken]
public class ManageController : Controller
{
```

Global example:

```csharp
services.AddControllersWithViews(options =>
    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));
```

### Override global or controller antiforgery attributes

The [IgnoreAntiforgeryToken](xref:Microsoft.AspNetCore.Mvc.IgnoreAntiforgeryTokenAttribute) filter is used to eliminate the need for an antiforgery token for a given action (or controller). When applied, this filter overrides `ValidateAntiForgeryToken` and `AutoValidateAntiforgeryToken` filters specified at a higher level (globally or on a controller).

```csharp
[Authorize]
[AutoValidateAntiforgeryToken]
public class ManageController : Controller
{
    [HttpPost]
    [IgnoreAntiforgeryToken]
    public async Task<IActionResult> DoSomethingSafe(SomeViewModel model)
    {
        // no antiforgery token required
    }
}
```

## Refresh tokens after authentication

Tokens should be refreshed after the user is authenticated by redirecting the user to a view or Razor Pages page.

## JavaScript, AJAX, and SPAs

In traditional HTML-based apps, antiforgery tokens are passed to the server using hidden form fields. In modern JavaScript-based apps and SPAs, many requests are made programmatically. These AJAX requests may use other techniques (such as request headers or cookies) to send the token.

If cookies are used to store authentication tokens and to authenticate API requests on the server, CSRF is a potential problem. If local storage is used to store the token, CSRF vulnerability might be mitigated because values from local storage aren't sent automatically to the server with every request. Using local storage to store the antiforgery token on the client and sending the token as a request header is a recommended approach.

### JavaScript

Using JavaScript with views, the token can be created using a service from within the view. Inject the <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgery> service into the view and call <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgery.GetAndStoreTokens%2A>:

:::code language="cshtml" source="anti-request-forgery/samples/2.x/MvcSample/Views/Home/Ajax.cshtml" highlight="4-10,12-13,35-36":::

This approach eliminates the need to deal directly with setting cookies from the server or reading them from the client.

The preceding example uses JavaScript to read the hidden field value for the AJAX POST header.

JavaScript can also access tokens in cookies and use the cookie's contents to create a header with the token's value.

```csharp
context.Response.Cookies.Append("CSRF-TOKEN", tokens.RequestToken, 
    new Microsoft.AspNetCore.Http.CookieOptions { HttpOnly = false });
```

Assuming the script requests to send the token in a header called `X-CSRF-TOKEN`, configure the antiforgery service to look for the `X-CSRF-TOKEN` header:

```csharp
services.AddAntiforgery(options => options.HeaderName = "X-CSRF-TOKEN");
```

The following example uses JavaScript to make an AJAX request with the appropriate header:

```javascript
function getCookie(cname) {
    var name = cname + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) === ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) === 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}

var csrfToken = getCookie("CSRF-TOKEN");

var xhttp = new XMLHttpRequest();
xhttp.onreadystatechange = function () {
    if (xhttp.readyState === XMLHttpRequest.DONE) {
        if (xhttp.status === 204) {
            alert('Todo item is created successfully.');
        } else {
            alert('There was an error processing the AJAX request.');
        }
    }
};
xhttp.open('POST', '/api/items', true);
xhttp.setRequestHeader("Content-type", "application/json");
xhttp.setRequestHeader("X-CSRF-TOKEN", csrfToken);
xhttp.send(JSON.stringify({ "name": "Learn C#" }));
```

### AngularJS

AngularJS uses a convention to address CSRF. If the server sends a cookie with the name `XSRF-TOKEN`, the AngularJS `$http` service adds the cookie value to a header when it sends a request to the server. This process is automatic. The client doesn't need to set the header explicitly. The header name is `X-XSRF-TOKEN`. The server should detect this header and validate its contents.

For ASP.NET Core API to work with this convention in your application startup:

* Configure your app to provide a token in a cookie called `XSRF-TOKEN`.
* Configure the antiforgery service to look for a header named `X-XSRF-TOKEN`, which is Angular's default header name for sending the XSRF token.

```csharp
public void Configure(IApplicationBuilder app, IAntiforgery antiforgery)
{
    app.Use(next => context =>
    {
        string path = context.Request.Path.Value;

        if (
            string.Equals(path, "/", StringComparison.OrdinalIgnoreCase) ||
            string.Equals(path, "/index.html", StringComparison.OrdinalIgnoreCase))
        {
            var tokens = antiforgery.GetAndStoreTokens(context);
            context.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken, 
                new CookieOptions() { HttpOnly = false });
        }

        return next(context);
    });
}

public void ConfigureServices(IServiceCollection services)
{
    services.AddAntiforgery(options => options.HeaderName = "X-XSRF-TOKEN");
}
```

> [!NOTE]
> When the antiforgery token is provided in both the request header and in the form payload, only the token in the header is validated.

## Windows authentication and antiforgery cookies

When using Windows Authentication, application endpoints must be protected against CSRF attacks in the same way as done for cookies. The browser implicitly sends the authentication context to the server and so endpoints need to be protected against CSRF attacks.

## Extend antiforgery

The <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgeryAdditionalDataProvider> type allows developers to extend the behavior of the anti-CSRF system by round-tripping additional data in each token. The <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgeryAdditionalDataProvider.GetAdditionalData%2A> method is called each time a field token is generated, and the return value is embedded within the generated token. An implementer could return a timestamp, a nonce, or any other value and then call <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgeryAdditionalDataProvider.ValidateAdditionalData%2A> to validate this data when the token is validated. The client's username is already embedded in the generated tokens, so there's no need to include this information. If a token includes supplemental data but no `IAntiForgeryAdditionalDataProvider` is configured, the supplemental data isn't validated.

## Additional resources

* <xref:host-and-deploy/web-farm>

:::moniker-end
