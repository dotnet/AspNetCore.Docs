---
title: Enforce a Content Security Policy for ASP.NET Core Blazor
author: guardrex
description: Learn how to use a Content Security Policy (CSP) with ASP.NET Core Blazor apps to help protect against Cross-Site Scripting (XSS) attacks.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.custom: mvc
ms.date: 11/11/2025
uid: blazor/security/content-security-policy
---
# Enforce a Content Security Policy for ASP.NET Core Blazor

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to use a Content Security Policy (CSP) with ASP.NET Core Blazor apps to help protect against certain types of malicious attacks, such as [Cross-Site Scripting (XSS)](xref:security/cross-site-scripting) and [clickjacking](https://developer.mozilla.org/docs/Web/Security/Attacks/Clickjacking) attacks. XSS is a security vulnerability where a cyberattacker places one or more malicious client-side scripts into an app's rendered content. In a clickjacking attack, a user is tricked into interactions with a decoy website that has your app embedded within it.

A CSP helps protect against these types of attacks by informing the browser of valid:

* Sources for loaded content, including scripts, stylesheets, images, and plugins.
* Actions taken by a page, specifying permitted URL targets of forms.
* When your app can be embedded into another website via `<frame>`, `<iframe>`, `<object>`, or `<embed>` tags.

We recommend reading the following MDN resources when implementing a CSP:

* [Content Security Policy (CSP)](https://developer.mozilla.org/docs/Web/HTTP/Guides/CSP)
* [CSP reference guidance](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy)
* [Content Security Policy (CSP) implementation](https://developer.mozilla.org/docs/Web/Security/Practical_implementation_guides/CSP)

To apply a CSP to an app, the developer specifies several CSP content security *directives* in one or more `Content-Security-Policy` headers or `<meta>` tags. For guidance on applying a CSP to an app in C# code at startup, see <xref:blazor/fundamentals/startup#control-headers-in-c-code> and the [*The `frame-ancestors` directive*](#the-frame-ancestors-directive) section later in this article.

Policies are evaluated by the browser while a page is loading. The browser inspects the page's sources and determines if they meet the requirements of the content security directives. When policy directives aren't met for a resource, the browser doesn't load the resource. For example, consider a policy that doesn't allow third-party scripts. When a page contains a `<script>` tag with a third-party origin in the `src` attribute, the browser prevents the script from loading.

CSP is supported in most modern desktop and mobile browsers, including Chrome, Edge, Firefox, Opera, and Safari. CSP is recommended for Blazor apps.

> [!WARNING]
> Implementing a CSP minimizes the risk of certain types of security threats and doesn't guarantee that an app is completely safe from XSS and clickjacking attacks. User agents, typically browsers, may allow users to modify or bypass policy enforcement through user preferences, bookmarklets, browser extensions, third-party additions to the user agent, and other such mechanisms. Also, CSPs are only focused on remediating a subset of attacks, not all attacks that can compromise security, such as SQL injection, Cross-Site Request Forgery (CSRF), security misconfiguration, and denial-of-service (DoS) attacks.

## Policy directives

The following directives and sources are commonly used for Blazor apps. Add additional directives and sources as needed. The following directives are used in the [*Apply the policy*](#apply-the-policy) section of this article, where example security policies for Blazor apps are provided:

:::moniker range=">= aspnetcore-8.0"

* [`base-uri`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/base-uri): Restricts the URLs for a page's `<base>` tag. Specify `self` to indicate that the app's origin, including the scheme and port number, is a valid source.
* [`default-src`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/default-src): Indicates a fallback for source directives that aren't explicitly specified by the policy. Specify `self` to indicate that the app's origin, including the scheme and port number, is a valid source.
* [`img-src`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/img-src): Indicates valid sources for images.
  * Specify `data:` to permit loading images from `data:` URLs.
  * Specify `https:` to permit loading images from HTTPS endpoints.
* [`object-src`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/object-src): Indicates valid sources for the `<object>`, `<embed>`, and `<applet>` tags. Specify `none` to prevent all URL sources.
* [`script-src`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/script-src): Indicates valid sources for scripts.
  * Specify `self` to indicate that the app's origin, including the scheme and port number, is a valid source.
  * In a client-side Blazor app:
    * Specify [`wasm-unsafe-eval`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/script-src#unsafe_webassembly_execution) to permit the client-side Blazor Mono runtime to function.
    * Specify any additional hashes to permit your required *non-framework scripts* to load. For example, specify [`unsafe-hashes`](https://developer.mozilla.org/docs/Web/HTTP/Reference/Headers/Content-Security-Policy/script-src#unsafe_hashes) with a hash of `sha256-qnHnQs7NjQNHHNYv/I9cW+I62HzDJjbnyS/OFzqlix0=` to permit the inline JavaScript for the navigation toggler in the `NavMenu` component.
  * In a server-side Blazor app, specify hashes to permit required scripts to load.
* [`style-src`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/style-src): Indicates valid sources for stylesheets.
  * Specify `self` to indicate that the app's origin, including the scheme and port number, is a valid source.
  * If the app uses inline styles, specify `unsafe-inline` to allow the use of your inline styles.
* [`connect-src`](https://developer.mozilla.org/docs/Web/HTTP/Reference/Headers/Content-Security-Policy/connect-src): Restricts the URLs that can be loaded using script interfaces. The scheme sources `http:`, `ws:` (WebSocket protocol), and `wss:` (WebSocket Secure protocol) are specified.
* [upgrade-insecure-requests](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/upgrade-insecure-requests): Indicates that content URLs from insecure (HTTP) sources should be acquired securely over HTTPS.

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

* [`base-uri`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/base-uri): Restricts the URLs for a page's `<base>` tag. Specify `self` to indicate that the app's origin, including the scheme and port number, is a valid source.
* [`default-src`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/default-src): Indicates a fallback for source directives that aren't explicitly specified by the policy. Specify `self` to indicate that the app's origin, including the scheme and port number, is a valid source.
* [`img-src`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/img-src): Indicates valid sources for images.
  * Specify `data:` to permit loading images from `data:` URLs.
  * Specify `https:` to permit loading images from HTTPS endpoints.
* [`object-src`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/object-src): Indicates valid sources for the `<object>`, `<embed>`, and `<applet>` tags. Specify `none` to prevent all URL sources.
* [`script-src`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/script-src): Indicates valid sources for scripts.
  * Specify `self` to indicate that the app's origin, including the scheme and port number, is a valid source.
  * In a client-side Blazor app:
    * Specify `unsafe-eval` to permit the client-side Blazor Mono runtime to function.
    * Specify any additional hashes to permit your required *non-framework scripts* to load.
  * In a server-side Blazor app, specify hashes to permit required scripts to load.
* [`style-src`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/style-src): Indicates valid sources for stylesheets.
  * Specify `self` to indicate that the app's origin, including the scheme and port number, is a valid source.
  * If the app uses inline styles, specify `unsafe-inline` to allow the use of your inline styles.
* [`connect-src`](https://developer.mozilla.org/docs/Web/HTTP/Reference/Headers/Content-Security-Policy/connect-src): Restricts the URLs that can be loaded using script interfaces. The scheme sources `http:`, `ws:` (WebSocket protocol), and `wss:` (WebSocket Secure protocol) are specified.
* [`upgrade-insecure-requests`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/upgrade-insecure-requests): Indicates that content URLs from insecure (HTTP) sources should be acquired securely over HTTPS.

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

* [`base-uri`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/base-uri): Restricts the URLs for a page's `<base>` tag. Specify `self` to indicate that the app's origin, including the scheme and port number, is a valid source.
* [`default-src`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/default-src): Indicates a fallback for source directives that aren't explicitly specified by the policy. Specify `self` to indicate that the app's origin, including the scheme and port number, is a valid source.
* [`img-src`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/img-src): Indicates valid sources for images.
  * Specify `data:` to permit loading images from `data:` URLs.
  * Specify `https:` to permit loading images from HTTPS endpoints.
* [`object-src`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/object-src): Indicates valid sources for the `<object>`, `<embed>`, and `<applet>` tags. Specify `none` to prevent all URL sources.
* [`script-src`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/script-src): Indicates valid sources for scripts.
  * Specify the `https://stackpath.bootstrapcdn.com/` host source for Bootstrap scripts.
  * Specify `self` to indicate that the app's origin, including the scheme and port number, is a valid source.
  * In a client-side Blazor app:
    * Specify `unsafe-eval` to permit the client-side Blazor Mono runtime to function.
    * Specify any additional hashes to permit your required *non-framework scripts* to load.
  * In a server-side Blazor app, specify hashes to permit required scripts to load.
* [`style-src`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/style-src): Indicates valid sources for stylesheets.
  * Specify the `https://stackpath.bootstrapcdn.com/` host source for Bootstrap stylesheets.
  * Specify `self` to indicate that the app's origin, including the scheme and port number, is a valid source.
  * Specify `unsafe-inline` to allow the use of inline styles.
* [`connect-src`](https://developer.mozilla.org/docs/Web/HTTP/Reference/Headers/Content-Security-Policy/connect-src): Restricts the URLs that can be loaded using script interfaces. The scheme sources `http:`, `ws:` (WebSocket protocol), and `wss:` (WebSocket Secure protocol) are specified.
* [`upgrade-insecure-requests`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/upgrade-insecure-requests): Indicates that content URLs from insecure (HTTP) sources should be acquired securely over HTTPS.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

* [`base-uri`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/base-uri): Restricts the URLs for a page's `<base>` tag. Specify `self` to indicate that the app's origin, including the scheme and port number, is a valid source.
* [`default-src`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/default-src): Indicates a fallback for source directives that aren't explicitly specified by the policy. Specify `self` to indicate that the app's origin, including the scheme and port number, is a valid source.
* [`img-src`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/img-src): Indicates valid sources for images.
  * Specify `data:` to permit loading images from `data:` URLs.
  * Specify `https:` to permit loading images from HTTPS endpoints.
* [`object-src`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/object-src): Indicates valid sources for the `<object>`, `<embed>`, and `<applet>` tags. Specify `none` to prevent all URL sources.
* [`script-src`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/script-src): Indicates valid sources for scripts.
  * Specify the `https://stackpath.bootstrapcdn.com/` host source for Bootstrap scripts.
  * Specify `self` to indicate that the app's origin, including the scheme and port number, is a valid source.
  * In a client-side Blazor app:
    * Specify hashes to permit required scripts to load.
    * Specify `unsafe-eval` to use `eval()` and methods for creating code from strings.
  * In a server-side Blazor app, specify hashes to permit required scripts to load.
* [`style-src`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/style-src): Indicates valid sources for stylesheets.
  * Specify the `https://stackpath.bootstrapcdn.com/` host source for Bootstrap stylesheets.
  * Specify `self` to indicate that the app's origin, including the scheme and port number, is a valid source.
  * Specify `unsafe-inline` to allow the use of inline styles. The inline declaration is required for the UI for reconnecting the client and server after the initial request. In a future release, inline styling might be removed so that `unsafe-inline` is no longer required.
* [`connect-src`](https://developer.mozilla.org/docs/Web/HTTP/Reference/Headers/Content-Security-Policy/connect-src): Restricts the URLs that can be loaded using script interfaces. The scheme sources `http:`, `ws:` (WebSocket protocol), and `wss:` (WebSocket Secure protocol) are specified.
* [`upgrade-insecure-requests`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/upgrade-insecure-requests): Indicates that content URLs from insecure (HTTP) sources should be acquired securely over HTTPS.

:::moniker-end

The preceding directives are supported by all browsers except Microsoft Internet Explorer.

To obtain SHA hashes for additional inline scripts:

* Apply the CSP shown in the *Apply the policy* section.
* Access the browser's developer tools console while running the app locally. The browser calculates and displays hashes for blocked scripts when a CSP header or `meta` tag is present.
* Copy the hashes provided by the browser to the `script-src` sources. Use single quotes around each hash.

For a Content Security Policy Level 2 browser support matrix, see [Can I use: Content Security Policy Level 2](https://www.caniuse.com/#feat=contentsecuritypolicy2).

## Apply the policy

You can apply a CSP via:

* A response header issued by the host (for example, IIS) or issued by the app (see [Control headers in C# code at startup](xref:blazor/fundamentals/startup#control-headers-in-c-code)).
* A `<meta>` tag. *This article only demonstrates the `<meta>` tag approach.*

To use a `<meta>` tag to apply the policy:

* Set the value of the `http-equiv` attribute to `Content-Security-Policy`.
* Place the directives in the `content` attribute value. Separate directives with a semicolon (`;`). An ending semicolon for the last directive of the policy string isn't required per the [Content Security Policy Level 3 specification](https://www.w3.org/TR/CSP3/).
* Place the `<meta>` tag in the [`<head>` content](xref:blazor/project-structure#location-of-head-and-body-content) just inside the opening `<head>` tag. The policy is evaluated and enforced when the CSP markup is parsed, so the policy should appear at the top of `<head>` markup to ensure that it's enforced on all `<script>` and `<link>` tags.

The following sections show example policies. These examples are versioned with this article for each release of Blazor. To use a version appropriate for your release, select the document version with the **Version** dropdown selector on this webpage.

## The `frame-ancestors` directive

The [`frame-ancestors`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/frame-ancestors) directive specifies valid parents that may embed a page with `<frame>`, `<iframe>`, `<object>`, or `<embed>` tags. A `frame-ancestors` directive can't be applied via a `<meta>` tag-based CSP. The directive must be applied by a response header. A CSP response header can be added by a server host, or app C# code can add or update a CSP with a `frame-ancestors` directive.

Blazor Web Apps (.NET 8 or later) automatically include a response header setting the value to `'self'`:

```
Content-Security-Policy: frame-ancestors 'self'
```

To change the default value to the more restrictive `'none'` and prevent all parents from embedding the app, set the <xref:Microsoft.AspNetCore.Components.Server.ServerComponentsEndpointOptions.ContentSecurityFrameAncestorsPolicy%2A> option in the call to <xref:Microsoft.AspNetCore.Builder.ServerRazorComponentsEndpointConventionBuilderExtensions.AddInteractiveServerRenderMode%2A> in the `Program` file. The following only takes effect when WebSocket compression is enabled (<xref:Microsoft.AspNetCore.Components.Server.ServerComponentsEndpointOptions.ConfigureWebSocketAcceptContext> is set, which is the default for Blazor apps).

```csharp
.AddInteractiveServerRenderMode(o => o.ContentSecurityFrameAncestorsPolicy = "'none'")
```

In Blazor Server apps, a default `frame-ancestors` directive isn't added to the response headers collection. You can add a CSP header manually with [middleware](xref:fundamentals/middleware/index) in the request processing pipeline:

```csharp
app.Use(async (context, next) =>
{
    context.Response.Headers.Add("Content-Security-Policy", "frame-ancestors 'none'");
    await next();
});
```

> [!WARNING]
> Avoid setting the `frame-ancestors` directive value to `'null'` when WebSocket compression is enabled (compression is the default) because it makes the app vulnerable to malicious script injection and clickjacking attacks.

For more information, see [CSP: frame-ancestors (MDN documentation)](https://developer.mozilla.org/docs/Web/HTTP/Reference/Headers/Content-Security-Policy/frame-ancestors).

### Server-side Blazor apps

The following example is a starting point for further development. At the top of [`<head>` content](xref:blazor/project-structure#location-of-head-and-body-content), apply the directives described in the [*Policy directives*](#policy-directives) section, along with any other directives that your app specification requires.

:::moniker range=">= aspnetcore-8.0"

For Blazor Web Apps or Blazor Server apps:

```html
<meta http-equiv="Content-Security-Policy" content="
    base-uri 'self';
    default-src 'self';
    img-src data: https:;
    object-src 'none';
    script-src 'self' 'wasm-unsafe-eval' 'unsafe-hashes' 
        'sha256-qnHnQs7NjQNHHNYv/I9cW+I62HzDJjbnyS/OFzqlix0=';
    style-src https:;
    connect-src 'self' http: ws: wss:;
    upgrade-insecure-requests;" />
```

Blazor Web Apps include an inline `onclick` JavaScript event handler in the `NavMenu` component that requires either of the following changes:

* Add a hash to the `script-src` directive with the `unsafe-hashes` keyword:

  ```html
  'unsafe-hashes' 'sha256-qnHnQs7NjQNHHNYv/I9cW+I62HzDJjbnyS/OFzqlix0='
  ```

  For more information, see [CSP: script-src: Unsafe inline script (MDN documentation)](https://developer.mozilla.org/docs/Web/HTTP/Reference/Headers/Content-Security-Policy/script-src#unsafe_inline_script).

* Move the inline JavaScript event handler to a JavaScript file or module that's permitted to load by the policy.

Blazor Web Apps also have an `ImportMap` component in `<head>` content that renders an inline import map `<script>` tag. To modify the policy to permit the import map to load, see the [Resolving CSP violations with Subresource Integrity (SRI) or a cryptographic nonce](#resolving-csp-violations-with-subresource-integrity-sri-or-a-cryptographic-nonce) section.

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

For Blazor Server apps:

```html
<meta http-equiv="Content-Security-Policy" content="
    base-uri 'self';
    default-src 'self';
    img-src data: https:;
    object-src 'none';
    script-src 'self';
    style-src 'self';
    connect-src 'self' http: ws: wss:;
    upgrade-insecure-requests">
```

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

For Blazor Server apps:

```html
<meta http-equiv="Content-Security-Policy" content="
    base-uri 'self';
    default-src 'self';
    img-src data: https:;
    object-src 'none';
    script-src 'self' https://stackpath.bootstrapcdn.com/;
    style-src 'self' 'unsafe-inline' https://stackpath.bootstrapcdn.com/;
    connect-src 'self' http: ws: wss:;
    upgrade-insecure-requests">
```

:::moniker-end

:::moniker range="< aspnetcore-5.0"

For Blazor Server apps:

```html
<meta http-equiv="Content-Security-Policy" content="
    base-uri 'self';
    default-src 'self';
    img-src data: https:;
    object-src 'none';
    script-src 'self' https://stackpath.bootstrapcdn.com/ 
        'sha256-34WLX60Tw3aG6hylk0plKbZZFXCuepeQ6Hu7OqRf8PI=';
    style-src 'unsafe-inline' https://stackpath.bootstrapcdn.com/;
    connect-src 'self' http: ws: wss:;
    upgrade-insecure-requests">
```

> [!NOTE]
> The preceding SHA256 hash is for demonstration purposes. You may need to calculate a new hash for your CSP.

:::moniker-end

Add additional `script-src` and `style-src` hashes as required by the app. During development, use an online tool or browser developer tools to have the hashes calculated for you. For example, the following browser tools console error reports the hash for a required script not covered by the policy:

> Refused to execute inline script because it violates the following Content Security Policy directive: " ... ". Either the 'unsafe-inline' keyword, a hash ('sha256-v8v3RKRPmN4odZ1CWM5gw80QKPCCWMcpNeOmimNL2AA='), or a nonce ('nonce-...') is required to enable inline execution.

The particular script associated with the error is displayed in the console next to the error.

For guidance on applying a CSP to an app in C# code at startup, see <xref:blazor/fundamentals/startup#control-headers-in-c-code>.

### Client-side Blazor apps

The following example is a starting point for further development. In the [`<head>` content](xref:blazor/project-structure#location-of-head-and-body-content), apply the directives described in the *Policy directives* section:

:::moniker range=">= aspnetcore-8.0"

```html
<meta http-equiv="Content-Security-Policy" content="
    base-uri 'self';
    default-src 'self';
    img-src data: https:;
    object-src 'none';
    script-src 'self' 'wasm-unsafe-eval';
    style-src 'self';
    connect-src 'none';
    upgrade-insecure-requests">
```

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

```html
<meta http-equiv="Content-Security-Policy" content="
    base-uri 'self';
    default-src 'self';
    img-src data: https:;
    object-src 'none';
    script-src 'self' 'unsafe-eval';
    style-src 'self';
    connect-src 'none';
    upgrade-insecure-requests">
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

```html
<meta http-equiv="Content-Security-Policy" content="
    base-uri 'self';
    default-src 'self';
    img-src data: https:;
    object-src 'none';
    script-src 'self' 'unsafe-eval' 
        'sha256-v8v3RKRPmN4odZ1CWM5gw80QKPCCWMcpNeOmimNL2AA=';
    style-src 'self';
    connect-src 'none';
    upgrade-insecure-requests">
```

> [!NOTE]
> The `sha256-v8v3RKRPmN4odZ1CWM5gw80QKPCCWMcpNeOmimNL2AA=` hash represents the [inline](https://github.com/dotnet/aspnetcore/blob/57501251222b199597b9ac16888f362a69eb13c1/src/Components/Web.JS/src/Platform/Mono/MonoPlatform.ts#L212) script that's used for client-side Blazor apps. This may be removed in the future.

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

```html
<meta http-equiv="Content-Security-Policy" content="
    base-uri 'self';
    default-src 'self';
    img-src data: https:;
    object-src 'none';
    script-src 'self' 'unsafe-eval' https://stackpath.bootstrapcdn.com/ 
        'sha256-v8v3RKRPmN4odZ1CWM5gw80QKPCCWMcpNeOmimNL2AA=';
    style-src 'self' 'unsafe-inline' https://stackpath.bootstrapcdn.com/;
    upgrade-insecure-requests">
```

:::moniker-end

:::moniker range="< aspnetcore-5.0"

```html
<meta http-equiv="Content-Security-Policy" content="
    base-uri 'self';
    default-src 'self';
    img-src data: https:;
    object-src 'none';
    script-src 'self' 'unsafe-eval' https://stackpath.bootstrapcdn.com/ 
        'sha256-v8ZC9OgMhcnEQ/Me77/R9TlJfzOBqrMTW8e1KuqLaqc=' 
        'sha256-If//FtbPc03afjLezvWHnC3Nbu4fDM04IIzkPaf3pH0=' 
        'sha256-v8v3RKRPmN4odZ1CWM5gw80QKPCCWMcpNeOmimNL2AA=';
    style-src 'self' 'unsafe-inline' https://stackpath.bootstrapcdn.com/;
    upgrade-insecure-requests">
```

:::moniker-end

Add additional `script-src` and `style-src` hashes as required by the app. During development, use an online tool or browser developer tools to have the hashes calculated for you. For example, the following browser tools console error reports the hash for a required script not covered by the policy:

> Refused to execute inline script because it violates the following Content Security Policy directive: " ... ". Either the 'unsafe-inline' keyword, a hash ('sha256-v8v3RKRPmN4odZ1CWM5gw80QKPCCWMcpNeOmimNL2AA='), or a nonce ('nonce-...') is required to enable inline execution.

The particular script associated with the error is displayed in the console next to the error.

## Resolving CSP violations with Subresource Integrity (SRI) or a cryptographic nonce

Two approaches for resolving CSP violations, which are described in the next two sections, are:

* [Subresource Integrity (SRI)](#adopt-subresource-integrity-sri) *Recommended*
* [Cryptographic nonce](#adopt-a-cryptographic-nonce)

### Adopt Subresource Integrity (SRI)

Subresource Integrity (SRI) enables browsers to confirm that fetched resources aren't tampered with in transit. A cryptographic hash provided on the resource must match the hash computed by the browser for the fetched resource and the hash listed in the CSP. Browser compatibility can be assessed at [Can I use? Subresource Integrity](https://caniuse.com/subresource-integrity).

In the following example for a Blazor Server app, an integrity is calculated using a third-party tool and specified for the Blazor script (`blazor.server.js`) and CSP. The Blazor script doesn't dynamically change in this scenario and has a stable SHA hash, so you can hardcode the `integrity` attribute's value.

> [!WARNING]
> Set the [`crossorigin` attribute](https://developer.mozilla.org/docs/Web/HTML/Attributes/crossorigin) on a subresource that's loaded from a different origin without [Cross-Origin Resource Sharing (CORS)](xref:security/cors). If the app's origin is different from where a subresource loads, an `Access-Control-Allow-Origin` header is required that allows the resource to be shared with the requesting origin *or else* the `crossorigin` attribute must be applied to the subresource's tag in the app. Otherwise, the browser adopts the 'fail-open' policy for the subresource, which means the subresource is loaded without checking its integrity.
>
> The `crossorigin` attribute isn't added to the Blazor `<script>` tag in the following example because the Blazor script is loaded from the app's origin.
>
> For more information, see [Cross-Origin Resource Sharing and Subresource Integrity (MDN documentation)](https://developer.mozilla.org/docs/Web/Security/Subresource_Integrity#cross-origin_resource_sharing_and_subresource_integrity).

```razor
<!DOCTYPE html>
<html lang="en">
<head>
    <meta http-equiv="Content-Security-Policy" content="
        base-uri 'self';
        default-src 'self';
        img-src data: https:;
        object-src 'none';
        script-src 'sha256-FyuamsHhg0nWZUnu/f5qrt2DlL1XKt5AX+cgRhtxtfg=';
        style-src https:;
        connect-src 'self' http: ws: wss:;
        upgrade-insecure-requests;" />
    ...
</head>
<body>
    ...
    <script src="_framework/blazor.server.js" 
        integrity="sha256-FyuamsHhg0nWZUnu/f5qrt2DlL1XKt5AX+cgRhtxtfg="></script>
</body>
</html>
```

In the following example for a Blazor Web App (.NET 8 or later), an integrity is calculated for the `ImportMap` component (.NET 9 or later). The `ImportMap` integrity value is computed for each app request because the `ImportMap` component renders unique content each time the page is generated for fingerprinted assets.

The rendered import map from the `ImportMap` component is generated by the app at its origin, so the [`crossorigin` attribute](https://developer.mozilla.org/docs/Web/HTML/Attributes/crossorigin) isn't included in the `ImportMap` tag. For more information, see [MDN CSP Guide: Hashes](https://developer.mozilla.org/docs/Web/HTTP/Guides/CSP#hashes) and [Subresource Integrity (MDN documentation)](https://developer.mozilla.org/docs/Web/Security/Subresource_Integrity).

```razor
@using System.Security.Cryptography
<!DOCTYPE html>
<html lang="en">
<head>
    <meta http-equiv="Content-Security-Policy" content="
        base-uri 'self';
        default-src 'self';
        img-src data: https:;
        object-src 'none';
        script-src 'self' 'wasm-unsafe-eval' 'unsafe-hashes' '@integrity'
            'sha256-qnHnQs7NjQNHHNYv/I9cW+I62HzDJjbnyS/OFzqlix0=';
        style-src https:;
        connect-src 'self' http: ws: wss:;
        upgrade-insecure-requests;" />
    ...
    <ImportMap integrity="@integrity" />
    ...
</head>
...
</html>

@code {
    private string? integrity;

    [CascadingParameter]
    public HttpContext? HttpContext { get; set; }

    protected override void OnInitialized()
    {
        var metadata = HttpContext?.GetEndpoint()?.Metadata
            .GetOrderedMetadata<ImportMapDefinition>();
        var utf8 = new System.Text.UTF8Encoding();
        var metadataBytes = utf8.GetBytes(
            metadata?.FirstOrDefault<ImportMapDefinition>()?.ToString()
                .ReplaceLineEndings("\n") ?? string.Empty);
        integrity = 
            $"sha256-{Convert.ToBase64String(SHA256.HashData(metadataBytes))}";
    }
}
```

Prior to .NET 6, use `.Replace("\r\n", "\n")` instead of calling <xref:System.String.ReplaceLineEndings%2A> in the preceding code.

> [!NOTE]
> If additional attributes must be splatted on the `ImportMap` components's rendered `<script>` element, you can pass a dictionary of all of the attributes to the `ImportMap` component in its <xref:Microsoft.AspNetCore.Components.ImportMap.AdditionalAttributes%2A> property. The `integrity` attribute name-value pair are passed in the dictionary with the rest of the additional passed attributes.

### Adopt a cryptographic nonce

A cryptographic nonce (*number used once*) enables browsers to confirm that fetched resources aren't tampered with in transit. A single-use cryptographic nonce provided in the CSP must match the nonce indicated on the resource. Browser compatibility can be assessed at [Can I use? Nonce](https://caniuse.com/?search=nonce).

In the following example for a Blazor Web App (.NET 8 or later), a nonce is created for the `ImportMap` component (.NET 9 or later) with a unique value each time the app is loaded.

For more information, see [MDN CSP Guide: Nonces](https://developer.mozilla.org/docs/Web/HTTP/Guides/CSP#nonces) and [CSP: script-src: Unsafe inline script (MDN documentation)](https://developer.mozilla.org/docs/Web/HTTP/Reference/Headers/Content-Security-Policy/script-src#unsafe_inline_script).

```razor
@using System.Security.Cryptography
<!DOCTYPE html>
<html lang="en">
<head>
    <meta http-equiv="Content-Security-Policy" content="
        base-uri 'self';
        default-src 'self';
        img-src data: https:;
        object-src 'none';
        script-src 'self' 'wasm-unsafe-eval' 'unsafe-hashes' 'nonce-@nonce' 
            'sha256-qnHnQs7NjQNHHNYv/I9cW+I62HzDJjbnyS/OFzqlix0=';
        style-src https:;
        connect-src 'self' http: ws: wss:;
        upgrade-insecure-requests;" />
    ...
    <ImportMap nonce="@nonce" />
    ...
</head>
...
</html>

@code {
    private string? nonce;

    protected override void OnInitialized()
    {
        using (var rng = RandomNumberGenerator.Create())
        {
            var nonceBytes = new byte[32];
            rng.GetBytes(nonceBytes);
            nonce = Convert.ToBase64String(nonceBytes);
        }
    }
}
```

> [!NOTE]
> If additional attributes must be splatted on the `ImportMap` components's rendered `<script>` element, you can pass a dictionary of all of the attributes to the `ImportMap` component in its <xref:Microsoft.AspNetCore.Components.ImportMap.AdditionalAttributes%2A> property. The nonce name-value pair is passed in the dictionary with the rest of the additional passed attributes.

:::moniker range=">= aspnetcore-8.0"

## Apply a CSP in non-`Development` environments

When a CSP is applied to a Blazor app's `<head>` content, it interferes with local testing in the `Development` environment. For example, [Browser Link](xref:client-side/using-browserlink) and the browser refresh script fail to load. The following examples demonstrate how to apply the CSP's `<meta>` tag in non-`Development` environments.

> [!NOTE]
> The examples in this section don't show the full `<meta>` tag for the CSPs. The complete `<meta>` tags are found in the subsections of the [Apply the policy](#apply-the-policy) section earlier in this article.

Three general approaches are available:

* Apply the CSP via the `App` component, which applies the CSP to all layouts of the app.
* If you need to apply CSPs to different areas of the app, for example a custom CSP for only the admin pages, apply the CSPs on a per-layout basis using the [`<HeadContent>` tag](xref:blazor/components/control-head-content). For complete effectiveness, every app layout file must adopt the approach.
* The hosting service or server can provide a CSP via a [`Content-Security-Policy` header](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy) added an app's outgoing responses. Because this approach varies by hosting service or server, it isn't addressed in the following examples. If you wish to adopt this approach, consult the documentation for your hosting service provider or server.

### Blazor Web App approaches

In the `App` component (`Components/App.razor`), inject <xref:Microsoft.Extensions.Hosting.IHostEnvironment>:

```razor
@inject IHostEnvironment Env
```

In the `App` component's `<head>` content, apply the CSP when not in the `Development` environment:

```razor
@if (!Env.IsDevelopment())
{
    <meta ...>
}
```

Alternatively, apply CSPs on a per-layout basis in the `Components/Layout` folder, as the following example demonstrates. Make sure that every layout specifies a CSP.

```razor
@inject IHostEnvironment Env

@if (!Env.IsDevelopment())
{
    <HeadContent>
        <meta ...>
    </HeadContent>
}
```

### Blazor WebAssembly app approaches

In the `App` component (`App.razor`), inject <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.IWebAssemblyHostEnvironment>:

```razor
@using Microsoft.AspNetCore.Components.WebAssembly.Hosting
@inject IWebAssemblyHostEnvironment Env
```

In the `App` component's `<head>` content, apply the CSP when not in the `Development` environment:

```razor
@if (!Env.IsDevelopment())
{
    <HeadContent>
        <meta ...>
    </HeadContent>
}
```

Alternatively, use the preceding code but apply CSPs on a per-layout basis in the `Layout` folder. Make sure that every layout specifies a CSP.

:::moniker-end

## Meta tag limitations

A `<meta>` tag policy doesn't support the following directives:

* [`frame-ancestors`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/frame-ancestors)
* [`report-to`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/report-to)
* [`report-uri`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/report-uri)
* [`sandbox`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/sandbox)

To support the preceding directives, use a header named `Content-Security-Policy`. The directive string is the header's value.

## Test a policy and receive violation reports

Testing helps confirm that third-party scripts aren't inadvertently blocked when building an initial policy.

To test a policy over a period of time without enforcing the policy directives, set the `<meta>` tag's `http-equiv` attribute or header name of a header-based policy to `Content-Security-Policy-Report-Only`. Failure reports are sent as JSON documents to a specified URL. For more information, see [MDN web docs: Content-Security-Policy-Report-Only](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy-Report-Only).

For reporting on violations while a policy is active, see the following articles:

* [report-to](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/report-to)
* [report-uri](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/report-uri)

Although `report-uri` is no longer recommended for use, both directives should be used until `report-to` is supported by all of the major browsers. Don't exclusively use `report-uri` because support for `report-uri` is subject to being dropped *at any time* from browsers. Remove support for `report-uri` in your policies when `report-to` is fully supported. To track adoption of `report-to`, see [Can I use: report-to](https://caniuse.com/#feat=mdn-http_headers_csp_content-security-policy_report-to).

Test and update an app's policy every release.

## Troubleshoot

* Errors appear in the browser's developer tools console. Browsers provide information about:
  * Elements that don't comply with the policy.
  * How to modify the policy to allow for a blocked item.
* A policy is only completely effective when the client's browser supports all of the included directives. For a current browser support matrix, see [Can I use: Content-Security-Policy](https://caniuse.com/#search=Content-Security-Policy).

## Additional resources

* [Apply a CSP in C# code at startup](xref:blazor/fundamentals/startup#control-headers-in-c-code)
* [MDN web docs: Content Security Policy (CSP)](https://developer.mozilla.org/docs/Web/HTTP/CSP)
* [MDN web docs: Content-Security-Policy response header](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy)
* [Content Security Policy Level 3](https://www.w3.org/TR/CSP3/)
* [Google CSP Evaluator](https://csp-evaluator.withgoogle.com/)
