---
uid: web-api/overview/security/preventing-cross-site-request-forgery-csrf-attacks
title: "Preventing Cross-Site Request Forgery (CSRF) Attacks in ASP.NET Web API | Microsoft Docs"
author: MikeWasson
description: "Describes the cross-site request forgery (CSRF) attack and how to implement anti-CSRF measures in ASP.NET Web API."
ms.author: aspnetcontent
manager: wpickett
ms.date: 12/12/2012
ms.topic: article
ms.assetid: 81d46f14-8f48-4d8c-830d-cc8d594dc11b
ms.technology: dotnet-webapi
ms.prod: .net-framework
msc.legacyurl: /web-api/overview/security/preventing-cross-site-request-forgery-csrf-attacks
msc.type: authoredcontent
---
Preventing Cross-Site Request Forgery (CSRF) Attacks in ASP.NET Web API
====================
by [Mike Wasson](https://github.com/MikeWasson)

Cross-Site Request Forgery (CSRF) is an attack where a malicious site sends a request to a vulnerable site where the user is currently logged in

Here is an example of a CSRF attack:

1. A user logs into www.example.com, using forms authentication.
2. The server authenticates the user. The response from the server includes an authentication cookie.
3. Without logging out, the user visits a malicious web site. This malicious site contains the following HTML form: 

    [!code-html[Main](preventing-cross-site-request-forgery-csrf-attacks/samples/sample1.html)]

    Notice that the form action posts to the vulnerable site, not to the malicious site. This is the "cross-site" part of CSRF.
4. The user clicks the submit button. The browser includes the authentication cookie with the request.
5. The request runs on the server with the user's authentication context, and can do anything that an authenticated user is allowed to do.

Although this example requires the user to click the form button, the malicious page could just as easily run a script that submits the form automatically. Moreover, using SSL does not prevent a CSRF attack, because the malicious site can send an "https://" request.

Typically, CSRF attacks are possible against web sites that use cookies for authentication, because browsers send all relevant cookies to the destination web site. However, CSRF attacks are not limited to exploiting cookies. For example, Basic and Digest authentication are also vulnerable. After a user logs in with Basic or Digest authentication. the browser automatically sends the credentials until the session ends.

## Anti-Forgery Tokens

To help prevent CSRF attacks, ASP.NET MVC uses anti-forgery tokens, also called *request verification tokens*.

1. The client requests an HTML page that contains a form.
2. The server includes two tokens in the response. One token is sent as a cookie. The other is placed in a hidden form field. The tokens are generated randomly so that an adversary cannot guess the values.
3. When the client submits the form, it must send both tokens back to the server. The client sends the cookie token as a cookie, and it sends the form token inside the form data. (A browser client automatically does this when the user submits the form.)
4. If a request does not include both tokens, the server disallows the request.

Here is an example of an HTML form with a hidden form token:

[!code-html[Main](preventing-cross-site-request-forgery-csrf-attacks/samples/sample2.html)]

Anti-forgery tokens work because the malicious page cannot read the user's tokens, due to same-origin policies. ([Same-origin policies](http://www.w3.org/Security/wiki/Same_Origin_Policy) prevent documents hosted on two different sites from accessing each other's content. So in the earlier example, the malicious page can send requests to example.com, but it cannot read the response.)

To prevent CSRF attacks, use anti-forgery tokens with any authentication protocol where the browser silently sends credentials after the user logs in. This includes cookie-based authentication protocols, such as forms authentication, as well as protocols such as Basic and Digest authentication.

You should require anti-forgery tokens for any nonsafe methods (POST, PUT, DELETE). Also, make sure that safe methods (GET, HEAD) do not have any side effects. Moreover, if you enable cross-domain support, such as CORS or JSONP, then even safe methods like GET are potentially vulnerable to CSRF attacks, allowing the attacker to read potentially sensitive data.

## Anti-Forgery Tokens in ASP.NET MVC

To add the anti-forgery tokens to a Razor page, use the **HtmlHelper.AntiForgeryToken** helper method:

[!code-cshtml[Main](preventing-cross-site-request-forgery-csrf-attacks/samples/sample3.cshtml)]

This method adds the hidden form field and also sets the cookie token.

## Anti-CSRF and AJAX

The form token can be a problem for AJAX requests, because an AJAX request might send JSON data, not HTML form data. One solution is to send the tokens in a custom HTTP header. The following code uses Razor syntax to generate the tokens, and then adds the tokens to an AJAX request. The tokens are generated at the server by calling **AntiForgery.GetTokens**.

[!code-html[Main](preventing-cross-site-request-forgery-csrf-attacks/samples/sample4.html)]

When you process the request, extract the tokens from the request header. Then call the **AntiForgery.Validate** method to validate the tokens. The **Validate** method throws an exception if the tokens are not valid.

[!code-csharp[Main](preventing-cross-site-request-forgery-csrf-attacks/samples/sample5.cs)]
