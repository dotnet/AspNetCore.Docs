---
title: Preventing Cross-Site Request Forgery (XSRF/CSRF) Attacks in ASP.NET Core
author: steve-smith
ms.author: riande
description: Preventing Cross-Site Request Forgery (XSRF/CSRF) Attacks in ASP.NET Core
manager: wpickett
ms.date: 7/14/2017
ms.topic: article
ms.technology: aspnet
ms.prod: asp.net-core
uid: security/anti-request-forgery
---

# Preventing Cross-Site Request Forgery (XSRF/CSRF) Attacks in ASP.NET Core

[Steve Smith](https://ardalis.com/), [Fiyaz Hasan](https://twitter.com/FiyazBinHasan), and [Rick Anderson](https://twitter.com/RickAndMSFT)

## What attack does anti-forgery prevent?

Cross-site request forgery (also known as XSRF or CSRF, pronounced *see-surf*) is an attack against web-hosted applications whereby a malicious web site can influence the interaction between a client browser and a web site that trusts that browser. These attacks are made possible because web browsers send some types of authentication tokens automatically with every request to a web site. This form of exploit is also known as a *one-click attack* or as *session riding*, because the attack takes advantage of the user's previously authenticated session.

An example of a CSRF attack:

1. A user logs into `www.example.com`, using forms authentication.
2. The server authenticates the user and issues a response that includes an authentication cookie.
3. The user visits a malicious site.

   The malicious site contains an HTML form similar to the following:

```html
   <h1>You Are a Winner!</h1>
     <form action="http://example.com/api/account" method="post">
       <input type="hidden" name="Transaction" value="withdraw" />
       <input type="hidden" name="Amount" value="1000000" />
     <input type="submit" value="Click Me"/>
   </form>
```

Notice that the form action posts to the vulnerable site, not to the malicious site. This is the “cross-site” part of CSRF.

4. The user clicks the submit button. The browser automatically includes the authentication cookie for the requested domain (the vulnerable site in this case) with the request.
5. The request runs on the server with the user’s authentication context and can do anything that an authenticated user is allowed to do.

This example requires the user to click the form button. The malicious page could:

* Run a script that automatically submits the form.
* Sends a form submission as an AJAX request. 
* Use a hidden form with CSS. 

Using SSL does not prevent a CSRF attack, the malicious site can send an `https://` request. 

Some attacks  target site endpoints that respond to `GET` requests, in which case an image tag can be used to perform the action (this form of attack is common on forum sites that permit images but block JavaScript). Applications that change state with `GET` requests are  vulnerable from malicious attacks.

CSRF attacks are possible against web sites that use cookies for authentication, because browsers send all relevant cookies to the destination web site. However, CSRF attacks are not limited to exploiting cookies. For example, Basic and Digest authentication are also vulnerable. After a user logs in with Basic or Digest authentication, the browser automatically sends the credentials until the session ends.

Note: In this context, *session* refers to the client-side session during which the user is authenticated. It is unrelated to server-side sessions or [session middleware](xref:fundamentals/app-state).

Users can guard against CSRF vulnerabilities by:
* Logging off of web sites when they have finished using them.
* Clearing their browser's cookies periodically.

However, CSRF vulnerabilities are fundamentally a problem with the web app, not the end user.

## How does ASP.NET Core MVC address CSRF?

> [!WARNING]
> ASP.NET Core implements anti-request-forgery using the [ASP.NET Core data protection stack](xref:security/data-protection/introduction). ASP.NET Core data protection must be configured to work in a server farm. See [Configuring data protection](xref:security/data-protection/configuration/overview) for more information.

ASP.NET Core anti-request-forgery  default data protection configuration 

In ASP.NET Core MVC 2.0 the [FormTagHelper](xref:mvc/views/working-with-forms#the-form-tag-helper) injects anti-forgery tokens for HTML form elements. For example, the following markup in a Razor file will automatically generate anti-forgery tokens:

```html
<form method="post">
  <!-- form markup -->
</form>
```

The automatic generation of anti-forgery tokens for HTML form elements happens when:

* The `form` tag contains the `method="post"` attribute AND

  * The action attribute is empty. ( `action=""`) OR
  * The action attribute is not supplied. (`<form method="post">`)

You can disable automatic generation of anti-forgery tokens for HTML form elements by:

* Explicitly disabling `asp-antiforgery`. For example

 ```html
  <form method="post" asp-antiforgery="false">
  </form>
  ```

* Opt the form element out of Tag Helpers by using the Tag Helper [! opt-out symbol](xref:mvc/views/tag-helpers/intro#opt-out).

 ```html
  <!form method="post">
  </!form>
  ```

* Remove the `FormTagHelper` from the view. You can remove the `FormTagHelper` from a view by adding the following directive to the Razor view:

 ```html
  @removeTagHelper Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper, Microsoft.AspNetCore.Mvc.TagHelpers
  ```

> [!NOTE]
> [Razor Pages](xref:mvc/razor-pages/index) are automatically protected from XSRF/CSRF. You don't have to write any additional code. See [XSRF/CSRF and Razor Pages](xref:mvc/razor-pages/index#xsrf) for more information.

The most common approach to defending against CSRF attacks is the synchronizer token pattern (STP). STP is a technique used when the user requests a page with form data. The server sends a token associated with the current user's identity to the client. The client sends back the token to the server for verification. If the server receives a token that doesn't match the authenticated user's identity, the request is rejected. The token is unique and unpredictable. The token can also be used to ensure proper sequencing of a series of requests (ensuring page 1 precedes page 2 which precedes page 3). All the forms in ASP.NET Core MVC templates generate antiforgery tokens. The following two examples of view logic generate antiforgery tokens:

```html
<form asp-controller="Manage" asp-action="ChangePassword" method="post">

</form>

@using (Html.BeginForm("ChangePassword", "Manage"))
{
    
}
```

You can explicitly add an antiforgery token to a ``<form>`` element without using tag helpers with the HTML helper ``@Html.AntiForgeryToken``:


```html
<form action="/" method="post">
    @Html.AntiForgeryToken()
</form>
```

```html
In each of the preceding cases, ASP.NET Core will add a hidden form field similar to the following:

<input name="__RequestVerificationToken" type="hidden" value="CfDJ8NrAkSldwD9CpLRyOtm6FiJB1Jr_F3FQJQDvhlHoLNJJrLA6zaMUmhjMsisu2D2tFkAiYgyWQawJk9vNm36sYP1esHOtamBEPvSk1_x--Sg8Ey2a-d9CV2zHVWIN9MVhvKHOSyKqdZFlYDVd69XYx-rOWPw3ilHGLN6K0Km-1p83jZzF0E4WU5OGg5ns2-m9Yw" />
```

ASP.NET Core includes three [filters](xref:mvc/controllers/filters) for working with antiforgery tokens: ``ValidateAntiForgeryToken``, ``AutoValidateAntiforgeryToken``, and ``IgnoreAntiforgeryToken``.

<a name="vaft"></a>

### ValidateAntiForgeryToken

The ``ValidateAntiForgeryToken`` is an action filter that can be applied to an individual action, a controller, or globally. Requests made to actions that have this filter applied will be blocked unless the request includes a valid antiforgery token.

```c#
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> RemoveLogin(RemoveLoginViewModel account)
{
    ManageMessageId? message = ManageMessageId.Error;
    var user = await GetCurrentUserAsync();
    if (user != null)
    {
        var result = await _userManager.RemoveLoginAsync(user, account.LoginProvider, account.ProviderKey);
        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(user, isPersistent: false);
            message = ManageMessageId.RemoveLoginSuccess;
        }
    }
    return RedirectToAction(nameof(ManageLogins), new { Message = message });
}
```

The ``ValidateAntiForgeryToken`` attribute requires a token for requests to action methods it decorates, including `HTTP GET` requests. If you apply it broadly, you can override it with the ``IgnoreAntiforgeryToken`` attribute.

### AutoValidateAntiforgeryToken

ASP.NET Core apps generally do not generate antiforgery tokens for HTTP safe methods (GET, HEAD, OPTIONS, and TRACE). Instead of broadly applying the ``ValidateAntiForgeryToken`` attribute and then overriding it with ``IgnoreAntiforgeryToken`` attributes, you can use the ``AutoValidateAntiforgeryToken`` attribute. This attribute works identically to the ``ValidateAntiForgeryToken`` attribute, except that it doesn't require tokens for requests made using the following HTTP methods:

* GET
* HEAD
* OPTIONS
* TRACE

We recommend you use ``AutoValidateAntiforgeryToken`` broadly for non-API scenarios. This ensures your POST actions are protected by default. The alternative is to ignore antiforgery tokens by default, unless ``ValidateAntiForgeryToken`` is applied to the individual action method. It's more likely in this scenario for a POST action method to be left unprotected, leaving your app vulnerable to CSRF attacks. Even anonymous POSTS should send the antiforgery token.

Note: APIs don't have an automatic mechanism for sending the non-cookie part of the token; your implementation will likely depend on your client code implementation. Some examples are shown below.


Example (class level):

```c#
[Authorize]
[AutoValidateAntiforgeryToken]
public class ManageController : Controller
{
```

Example (global):

```c#
services.AddMvc(options => 
    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));
```

<a name="iaft"></a>

### IgnoreAntiforgeryToken

The ``IgnoreAntiforgeryToken`` filter is used to eliminate the need for an antiforgery token to be present for a given action (or controller). When applied, this filter will override ``ValidateAntiForgeryToken`` and/or ``AutoValidateAntiforgeryToken`` filters specified at a higher level (globally or on a controller).

```c#
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

## JavaScript, AJAX, and SPAs

In traditional HTML-based applications, antiforgery tokens are passed to the server using hidden form fields. In modern JavaScript-based apps and single page applications (SPAs), many requests are made programmatically. These AJAX requests may use other techniques (such as request headers or cookies) to send the token. If cookies are used to store authentication tokens and to authenticate API requests on the server, then CSRF will be a potential problem. However, if local storage is used to store the token, CSRF vulnerability may be mitigated, since values from local storage are not sent automatically to the server with every new request. Thus, using local storage to store the antiforgery token on the client and sending the token as a request header is a recommended approach.

### AngularJS

AngularJS uses a convention to address CSRF. If the server sends a cookie with the name ``XSRF-TOKEN``, the Angular ``$http`` service will add the value from this cookie to a header when it sends a request to this server. This process is automatic; you don't need to set the header explicitly. The header name is ``X-XSRF-TOKEN``. The server should detect this header and validate its contents.

For ASP.NET Core API work with this convention:

* Configure your app to provide a token in a cookie called ``XSRF-TOKEN``
* Configure the antiforgery service to look for a header named ``X-XSRF-TOKEN``

```c#
services.AddAntiforgery(options => options.HeaderName = "X-XSRF-TOKEN");
```

[View sample](https://github.com/aspnet/Docs/tree/master/aspnetcore/security/anti-request-forgery/sample/AngularSample).

### JavaScript

Using JavaScript with views, you can create the token using a service from within your view. To do so, you inject the `Microsoft.AspNetCore.Antiforgery.IAntiforgery` service into the view and call `GetAndStoreTokens`, as shown:

[!code-csharp[Main](anti-request-forgery/sample/MvcSample/Views/Home/Ajax.cshtml?highlight=4-10,24)]

This approach eliminates the need to deal directly with setting cookies from the server or reading them from the client.

JavaScript can also access tokens provided in cookies, and then use the cookie's contents to create a header with the token's value, as shown below.

```c#
context.Response.Cookies.Append("CSRF-TOKEN", tokens.RequestToken, 
  new Microsoft.AspNetCore.Http.CookieOptions { HttpOnly = false });
```

Then, assuming you construct your script requests to send the token in a header called ``X-CSRF-TOKEN``, configure the antiforgery service to look for the ``X-CSRF-TOKEN`` header:

```c#
services.AddAntiforgery(options => options.HeaderName = "X-CSRF-TOKEN");
```

The following example uses jQuery to make an AJAX request with the appropriate header:

```javascript
var csrfToken = $.cookie("CSRF-TOKEN");

$.ajax({
    url: "/api/password/changepassword",
    contentType: "application/json",
    data: JSON.stringify({ "newPassword": "ReallySecurePassword999$$$" }),
    type: "POST",
    headers: {
        "X-CSRF-TOKEN": csrfToken
    }
});
```

## Configuring Antiforgery

`IAntiforgery` provides the API to configure the antiforgery system. It can be requested in the `Configure` method of the `Startup` class. The following example uses middleware from the app's home page to generate an antiforgery token and send it in the response as a cookie (using the default Angular naming convention described above):


```c#
public void Configure(IApplicationBuilder app, 
    IAntiforgery antiforgery)
{
    app.Use(next => context =>
    {
        string path = context.Request.Path.Value;
        if (
            string.Equals(path, "/", StringComparison.OrdinalIgnoreCase) ||
            string.Equals(path, "/index.html", StringComparison.OrdinalIgnoreCase))
        {
            // We can send the request token as a JavaScript-readable cookie, 
            // and Angular will use it by default.
            var tokens = antiforgery.GetAndStoreTokens(context);
            context.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken, 
                new CookieOptions() { HttpOnly = false });
        }

        return next(context);
    });
    //
}
```

### Options

You can customize [antiforgery options](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.antiforgery.antiforgeryoptions#fields_summary) in `ConfigureServices`:

```c#
services.AddAntiforgery(options => 
{
  options.CookieDomain = "mydomain.com";
  options.CookieName = "X-CSRF-TOKEN-COOKIENAME";
  options.CookiePath = "Path";
  options.FormFieldName = "AntiforgeryFieldname";
  options.HeaderName = "X-CSRF-TOKEN-HEADERNAME";
  options.RequireSsl = false;
  options.SuppressXFrameOptionsHeader = false;
});
```

<!-- QAfix fix table -->

|Option        | Description |
|------------- | ----------- |
|CookieDomain  | The domain of the cookie. Defaults to `null`. |
|CookieName    | The name of the cookie. If not set, the system will generate a unique name beginning with the `DefaultCookiePrefix` (".AspNetCore.Antiforgery."). |
|CookiePath    | The path set on the cookie. |
|FormFieldName | The name of the hidden form field used by the antiforgery system to render antiforgery tokens in views. |
|HeaderName    | The name of the header used by the antiforgery system. If `null`, the system will consider only form data. |
|RequireSsl    | Specifies whether SSL is required by the antiforgery system. Defaults to `false`. If `true`, non-SSL requests will fail. |
|SuppressXFrameOptionsHeader  | Specifies whether to suppress generation of the `X-Frame-Options` header. By default, the header is generated with a value of "SAMEORIGIN". Defaults to `false`. |

See https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.builder.cookieauthenticationoptions for more info.

### Extending Antiforgery

The [IAntiForgeryAdditionalDataProvider](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.antiforgery.iantiforgeryadditionaldataprovider) type allows developers to extend the behavior of the anti-XSRF system by round-tripping additional data in each token. The [GetAdditionalData](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.antiforgery.iantiforgeryadditionaldataprovider#Microsoft_AspNetCore_Antiforgery_IAntiforgeryAdditionalDataProvider_GetAdditionalData_Microsoft_AspNetCore_Http_HttpContext_) method is called each time a field token is generated, and the return value is embedded within the generated token. An implementer could return a timestamp, a nonce, or any other value and then call [ValidateAdditionalData](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.antiforgery.iantiforgeryadditionaldataprovider#Microsoft_AspNetCore_Antiforgery_IAntiforgeryAdditionalDataProvider_ValidateAdditionalData_Microsoft_AspNetCore_Http_HttpContext_System_String_) to validate this data when the token is validated. The client's username is already embedded in the generated tokens, so there is no need to include this information. If a token includes supplemental data but no `IAntiForgeryAdditionalDataProvider` has been configured, the supplemental data is not validated.

## Fundamentals

CSRF attacks rely on the default browser behavior of sending cookies associated with a domain with every request made to that domain. These cookies are stored within the browser. They frequently include session cookies for authenticated users. Cookie-based authentication is a popular form of authentication. Token-based authentication systems have been growing in popularity, especially for SPAs and other "smart client" scenarios.

### Cookie-based authentication

Once a user has authenticated using their username and password, they are issued a token that can be used to identify them and validate that they have been authenticated. The token is stored as a cookie that accompanies every request the client makes. Generating and validating this cookie is done by the cookie authentication middleware. ASP.NET Core provides cookie [middleware](../fundamentals/middleware.md) which serializes a user principal into an encrypted cookie and then, on subsequent requests, validates the cookie, recreates the principal and assigns it to the `User` property on `HttpContext`.

When a cookie is used, The authentication cookie is just a container for the forms authentication ticket. The ticket is passed as the value of the forms authentication cookie with each request and is used by forms authentication, on the server, to identify an authenticated user.

When a user is logged in to a system, a user session is created on the server-side and is stored in a database or some other persistent store. The system generates a session key that points to the actual session in the data store and it is sent as a client side cookie. The web server will check this session key any time a user requests a resource that requires authorization. The system checks whether the associated user session has the privilege to access the requested resource. If so, the request continues. Otherwise, the request returns as not authorized. In this approach, cookies are used to make the application appear to be stateful, since it is able to "remember" that the user has previously authenticated with the server.

### User tokens

Token-based authentication doesn’t store session on the server. Instead, when a user is logged in they are issued a token (not an antiforgery token). This token holds all the data that is required to validate the token. It also contains user information, in the form of [claims](https://docs.microsoft.com/dotnet/framework/security/claims-based-identity-model). When a user wants to access a server resource requiring authentication, the token is sent to the server with an additional authorization header in form of Bearer {token}. This makes the application stateless since in each subsequent request the token is passed in the request for server-side validation. This token is not *encrypted*; rather it is *encoded*. On the server-side the token can be decoded to access the raw information within the token. To send the token in subsequent requests, you can either store it in browser’s local storage or in a cookie. You don’t have to worry about XSRF vulnerability if your token is stored in the local storage, but it is an issue if the token is stored in a cookie.

### Multiple applications are hosted in one domain

Even though `example1.cloudapp.net` and `example2.cloudapp.net` are different hosts, there is an implicit trust relationship between all hosts under the `*.cloudapp.net` domain. This implicit trust relationship allows potentially untrusted hosts to affect each other’s cookies (the same-origin policies that govern AJAX requests do not necessarily apply to HTTP cookies). The ASP.NET Core runtime provides some mitigation in that the username is embedded into the field token, so even if a malicious subdomain is able to overwrite a session token it will be unable to generate a valid field token for the user. However, when hosted in such an environment the built-in anti-XSRF routines still cannot defend against session hijacking or login CSRF attacks. Shared hosting environments are vunerable to session hijacking, login CSRF, and other attacks.


### Additional Resources

* [XSRF](https://www.owasp.org/index.php/Cross-Site_Request_Forgery_(CSRF)) on [Open Web Application Security Project](https://www.owasp.org/index.php/Main_Page) (OWASP).
