---
title: Enforce a Content Security Policy for ASP.NET Core Blazor
author: guardrex
description: Learn how to use a Content Security Policy (CSP) with ASP.NET Core Blazor apps to help protect against Cross-Site Scripting (XSS) attacks.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 02/23/2023
uid: blazor/security/content-security-policy
---
# Enforce a Content Security Policy for ASP.NET Core Blazor

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to use a [Content Security Policy (CSP)](https://developer.mozilla.org/docs/Web/HTTP/CSP) with ASP.NET Core Blazor apps to help protect against [Cross-Site Scripting (XSS)](xref:security/cross-site-scripting) attacks.

[!INCLUDE[](~/blazor/includes/location-client-and-server-net31-or-later.md)]

[Cross-Site Scripting (XSS)](xref:security/cross-site-scripting) is a security vulnerability where an attacker places one or more malicious client-side scripts into an app's rendered content. A CSP helps protect against XSS attacks by informing the browser of valid:

* Sources for loaded content, including scripts, stylesheets, images, and plugins.
* Actions taken by a page, specifying permitted URL targets of forms.

To apply a CSP to an app, the developer specifies several CSP content security *directives* in one or more `Content-Security-Policy` headers or `<meta>` tags. For guidance on applying a CSP to an app in C# code at startup, see <xref:blazor/fundamentals/startup#control-headers-in-c-code>.

Policies are evaluated by the browser while a page is loading. The browser inspects the page's sources and determines if they meet the requirements of the content security directives. When policy directives aren't met for a resource, the browser doesn't load the resource. For example, consider a policy that doesn't allow third-party scripts. When a page contains a `<script>` tag with a third-party origin in the `src` attribute, the browser prevents the script from loading.

CSP is supported in most modern desktop and mobile browsers, including Chrome, Edge, Firefox, Opera, and Safari. CSP is recommended for Blazor apps.

## Policy directives

Minimally, specify the following directives and sources for Blazor apps. Add additional directives and sources as needed. The following directives are used in the *Apply the policy* section of this article, where example security policies for Blazor apps are provided:

:::moniker range=">= aspnetcore-8.0"

* [base-uri](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/base-uri): Restricts the URLs for a page's `<base>` tag. Specify `self` to indicate that the app's origin, including the scheme and port number, is a valid source.
* [default-src](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/default-src): Indicates a fallback for source directives that aren't explicitly specified by the policy. Specify `self` to indicate that the app's origin, including the scheme and port number, is a valid source.
* [img-src](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/img-src): Indicates valid sources for images.
  * Specify `data:` to permit loading images from `data:` URLs.
  * Specify `https:` to permit loading images from HTTPS endpoints.
* [object-src](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/object-src): Indicates valid sources for the `<object>`, `<embed>`, and `<applet>` tags. Specify `none` to prevent all URL sources.
* [script-src](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/script-src): Indicates valid sources for scripts.
  * Specify `self` to indicate that the app's origin, including the scheme and port number, is a valid source.
  * In a client-side Blazor app:
    * Specify [`wasm-unsafe-eval`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/script-src#unsafe_webassembly_execution) to permit the client-side Blazor Mono runtime to function.
    * Specify any additional hashes to permit your required *non-framework scripts* to load.
  * In a server-side Blazor app, specify hashes to permit required scripts to load.
* [style-src](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/style-src): Indicates valid sources for stylesheets.
  * Specify `self` to indicate that the app's origin, including the scheme and port number, is a valid source.
  * If the app uses inline styles, specify `unsafe-inline` to allow the use of your inline styles.
* [upgrade-insecure-requests](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/upgrade-insecure-requests): Indicates that content URLs from insecure (HTTP) sources should be acquired securely over HTTPS.

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

* [base-uri](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/base-uri): Restricts the URLs for a page's `<base>` tag. Specify `self` to indicate that the app's origin, including the scheme and port number, is a valid source.
* [default-src](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/default-src): Indicates a fallback for source directives that aren't explicitly specified by the policy. Specify `self` to indicate that the app's origin, including the scheme and port number, is a valid source.
* [img-src](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/img-src): Indicates valid sources for images.
  * Specify `data:` to permit loading images from `data:` URLs.
  * Specify `https:` to permit loading images from HTTPS endpoints.
* [object-src](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/object-src): Indicates valid sources for the `<object>`, `<embed>`, and `<applet>` tags. Specify `none` to prevent all URL sources.
* [script-src](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/script-src): Indicates valid sources for scripts.
  * Specify `self` to indicate that the app's origin, including the scheme and port number, is a valid source.
  * In a client-side Blazor app:
    * Specify `unsafe-eval` to permit the client-side Blazor Mono runtime to function.
    * Specify any additional hashes to permit your required *non-framework scripts* to load.
  * In a server-side Blazor app, specify hashes to permit required scripts to load.
* [style-src](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/style-src): Indicates valid sources for stylesheets.
  * Specify `self` to indicate that the app's origin, including the scheme and port number, is a valid source.
  * If the app uses inline styles, specify `unsafe-inline` to allow the use of your inline styles.
* [upgrade-insecure-requests](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/upgrade-insecure-requests): Indicates that content URLs from insecure (HTTP) sources should be acquired securely over HTTPS.

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

* [base-uri](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/base-uri): Restricts the URLs for a page's `<base>` tag. Specify `self` to indicate that the app's origin, including the scheme and port number, is a valid source.
* [default-src](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/default-src): Indicates a fallback for source directives that aren't explicitly specified by the policy. Specify `self` to indicate that the app's origin, including the scheme and port number, is a valid source.
* [img-src](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/img-src): Indicates valid sources for images.
  * Specify `data:` to permit loading images from `data:` URLs.
  * Specify `https:` to permit loading images from HTTPS endpoints.
* [object-src](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/object-src): Indicates valid sources for the `<object>`, `<embed>`, and `<applet>` tags. Specify `none` to prevent all URL sources.
* [script-src](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/script-src): Indicates valid sources for scripts.
  * Specify the `https://stackpath.bootstrapcdn.com/` host source for Bootstrap scripts.
  * Specify `self` to indicate that the app's origin, including the scheme and port number, is a valid source.
  * In a client-side Blazor app:
    * Specify `unsafe-eval` to permit the client-side Blazor Mono runtime to function.
    * Specify any additional hashes to permit your required *non-framework scripts* to load.
  * In a server-side Blazor app, specify hashes to permit required scripts to load.
* [style-src](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/style-src): Indicates valid sources for stylesheets.
  * Specify the `https://stackpath.bootstrapcdn.com/` host source for Bootstrap stylesheets.
  * Specify `self` to indicate that the app's origin, including the scheme and port number, is a valid source.
  * Specify `unsafe-inline` to allow the use of inline styles.
* [upgrade-insecure-requests](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/upgrade-insecure-requests): Indicates that content URLs from insecure (HTTP) sources should be acquired securely over HTTPS.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

* [base-uri](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/base-uri): Restricts the URLs for a page's `<base>` tag. Specify `self` to indicate that the app's origin, including the scheme and port number, is a valid source.
* [default-src](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/default-src): Indicates a fallback for source directives that aren't explicitly specified by the policy. Specify `self` to indicate that the app's origin, including the scheme and port number, is a valid source.
* [img-src](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/img-src): Indicates valid sources for images.
  * Specify `data:` to permit loading images from `data:` URLs.
  * Specify `https:` to permit loading images from HTTPS endpoints.
* [object-src](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/object-src): Indicates valid sources for the `<object>`, `<embed>`, and `<applet>` tags. Specify `none` to prevent all URL sources.
* [script-src](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/script-src): Indicates valid sources for scripts.
  * Specify the `https://stackpath.bootstrapcdn.com/` host source for Bootstrap scripts.
  * Specify `self` to indicate that the app's origin, including the scheme and port number, is a valid source.
  * In a client-side Blazor app:
    * Specify hashes to permit required scripts to load.
    * Specify `unsafe-eval` to use `eval()` and methods for creating code from strings.
  * In a server-side Blazor app, specify hashes to permit required scripts to load.
* [style-src](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/style-src): Indicates valid sources for stylesheets.
  * Specify the `https://stackpath.bootstrapcdn.com/` host source for Bootstrap stylesheets.
  * Specify `self` to indicate that the app's origin, including the scheme and port number, is a valid source.
  * Specify `unsafe-inline` to allow the use of inline styles. The inline declaration is required for the UI for reconnecting the client and server after the initial request. In a future release, inline styling might be removed so that `unsafe-inline` is no longer required.
* [upgrade-insecure-requests](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/upgrade-insecure-requests): Indicates that content URLs from insecure (HTTP) sources should be acquired securely over HTTPS.

:::moniker-end

The preceding directives are supported by all browsers except Microsoft Internet Explorer.

To obtain SHA hashes for additional inline scripts:

* Apply the CSP shown in the *Apply the policy* section.
* Access the browser's developer tools console while running the app locally. The browser calculates and displays hashes for blocked scripts when a CSP header or `meta` tag is present.
* Copy the hashes provided by the browser to the `script-src` sources. Use single quotes around each hash.

For a Content Security Policy Level 2 browser support matrix, see [Can I use: Content Security Policy Level 2](https://www.caniuse.com/#feat=contentsecuritypolicy2).

## Apply the policy

Use a `<meta>` tag to apply the policy:

* Set the value of the `http-equiv` attribute to `Content-Security-Policy`.
* Place the directives in the `content` attribute value. Separate directives with a semicolon (`;`).
* Always place the `meta` tag in the [`<head>` content](xref:blazor/project-structure#location-of-head-and-body-content).

The following sections show example policies. These examples are versioned with this article for each release of Blazor. To use a version appropriate for your release, select the document version with the **Version** dropdown selector on this webpage.

### Client-side Blazor apps

In the [`<head>` content](xref:blazor/project-structure#location-of-head-and-body-content), apply the directives described in the *Policy directives* section:

:::moniker range=">= aspnetcore-8.0"

```html
<meta http-equiv="Content-Security-Policy" 
      content="base-uri 'self';
               default-src 'self';
               img-src data: https:;
               object-src 'none';
               script-src 'self'
                          'wasm-unsafe-eval';
               style-src 'self';
               upgrade-insecure-requests;">
```

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

```html
<meta http-equiv="Content-Security-Policy" 
      content="base-uri 'self';
               default-src 'self';
               img-src data: https:;
               object-src 'none';
               script-src 'self' 
                          'unsafe-eval';
               style-src 'self';
               upgrade-insecure-requests;">
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

```html
<meta http-equiv="Content-Security-Policy" 
      content="base-uri 'self';
               default-src 'self';
               img-src data: https:;
               object-src 'none';
               script-src 'self' 
                          'sha256-v8v3RKRPmN4odZ1CWM5gw80QKPCCWMcpNeOmimNL2AA=' 
                          'unsafe-eval';
               style-src 'self';
               upgrade-insecure-requests;">
```

> [!NOTE]
> The `sha256-v8v3RKRPmN4odZ1CWM5gw80QKPCCWMcpNeOmimNL2AA=` hash represents the [inline](https://github.com/dotnet/aspnetcore/blob/57501251222b199597b9ac16888f362a69eb13c1/src/Components/Web.JS/src/Platform/Mono/MonoPlatform.ts#L212) script that's used for client-side Blazor apps. This may be removed in the future.

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

```html
<meta http-equiv="Content-Security-Policy" 
      content="base-uri 'self';
               default-src 'self';
               img-src data: https:;
               object-src 'none';
               script-src https://stackpath.bootstrapcdn.com/ 
                          'self' 
                          'sha256-v8v3RKRPmN4odZ1CWM5gw80QKPCCWMcpNeOmimNL2AA=' 
                          'unsafe-eval';
               style-src https://stackpath.bootstrapcdn.com/
                         'self'
                         'unsafe-inline';
               upgrade-insecure-requests;">
```

:::moniker-end

:::moniker range="< aspnetcore-5.0"

```html
<meta http-equiv="Content-Security-Policy" 
      content="base-uri 'self';
               default-src 'self';
               img-src data: https:;
               object-src 'none';
               script-src https://stackpath.bootstrapcdn.com/ 
                          'self' 
                          'sha256-v8ZC9OgMhcnEQ/Me77/R9TlJfzOBqrMTW8e1KuqLaqc=' 
                          'sha256-If//FtbPc03afjLezvWHnC3Nbu4fDM04IIzkPaf3pH0=' 
                          'sha256-v8v3RKRPmN4odZ1CWM5gw80QKPCCWMcpNeOmimNL2AA=' 
                          'unsafe-eval';
               style-src https://stackpath.bootstrapcdn.com/
                         'self'
                         'unsafe-inline';
               upgrade-insecure-requests;">
```

:::moniker-end

Add additional `script-src` and `style-src` hashes as required by the app. During development, use an online tool or browser developer tools to have the hashes calculated for you. For example, the following browser tools console error reports the hash for a required script not covered by the policy:

> Refused to execute inline script because it violates the following Content Security Policy directive: " ... ". Either the 'unsafe-inline' keyword, a hash ('sha256-v8v3RKRPmN4odZ1CWM5gw80QKPCCWMcpNeOmimNL2AA='), or a nonce ('nonce-...') is required to enable inline execution.

The particular script associated with the error is displayed in the console next to the error.

### Server-side Blazor apps

In the [`<head>` content](xref:blazor/project-structure#location-of-head-and-body-content), apply the directives described in the *Policy directives* section:

:::moniker range=">= aspnetcore-6.0"

```html
<meta http-equiv="Content-Security-Policy" 
      content="base-uri 'self';
               default-src 'self';
               img-src data: https:;
               object-src 'none';
               script-src 'self';
               style-src 'self';
               upgrade-insecure-requests;">
```

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

```html
<meta http-equiv="Content-Security-Policy" 
      content="base-uri 'self';
               default-src 'self';
               img-src data: https:;
               object-src 'none';
               script-src https://stackpath.bootstrapcdn.com/ 
                          'self';
               style-src https://stackpath.bootstrapcdn.com/
                         'self' 
                         'unsafe-inline';
               upgrade-insecure-requests;">
```

:::moniker-end

:::moniker range="< aspnetcore-5.0"

```html
<meta http-equiv="Content-Security-Policy" 
      content="base-uri 'self';
               default-src 'self';
               img-src data: https:;
               object-src 'none';
               script-src https://stackpath.bootstrapcdn.com/ 
                          'self' 
                          'sha256-34WLX60Tw3aG6hylk0plKbZZFXCuepeQ6Hu7OqRf8PI=';
               style-src https://stackpath.bootstrapcdn.com/
                         'self' 
                         'unsafe-inline';
               upgrade-insecure-requests;">
```

:::moniker-end

Add additional `script-src` and `style-src` hashes as required by the app. During development, use an online tool or browser developer tools to have the hashes calculated for you. For example, the following browser tools console error reports the hash for a required script not covered by the policy:

> Refused to execute inline script because it violates the following Content Security Policy directive: " ... ". Either the 'unsafe-inline' keyword, a hash ('sha256-v8v3RKRPmN4odZ1CWM5gw80QKPCCWMcpNeOmimNL2AA='), or a nonce ('nonce-...') is required to enable inline execution.

The particular script associated with the error is displayed in the console next to the error.

## Meta tag limitations

A `<meta>` tag policy doesn't support the following directives:

* [frame-ancestors](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/frame-ancestors)
* [report-to](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/report-to)
* [report-uri](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/report-uri)
* [sandbox](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy/sandbox)

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
* [MDN web docs: Content-Security-Policy](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy)
* [Content Security Policy Level 2](https://www.w3.org/TR/CSP2/)
* [Google CSP Evaluator](https://csp-evaluator.withgoogle.com/)
