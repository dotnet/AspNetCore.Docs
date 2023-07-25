---
title: ASP.NET Core Blazor Hybrid security considerations
author: guardrex
description: Learn about security considerations when developing apps in Blazor Hybrid.
monikerRange: '>= aspnetcore-6.0'
ms.author: riande
ms.custom: mvc
ms.date: 11/08/2022
uid: blazor/hybrid/security/security-considerations
---
# ASP.NET Core Blazor Hybrid security considerations

[!INCLUDE[](~/includes/not-latest-version.md)]

<!-- This topic drops loc for "Mac Catalyst" -->

This article describes security considerations for Blazor Hybrid apps.

Blazor Hybrid apps that render web content execute .NET code inside a platform Web View. The .NET code interacts with the web content via an interop channel between the .NET code and the Web View.

![The WebView and .NET code interoperate within the app to render web content.](~/blazor/hybrid/security/index/_static/figure01.png)

The web content rendered into the Web View can come from assets provided by the app from either of the following locations:

* The `wwwroot` folder in the app.
* A source external to the app. For example, a network source, such as the Internet.

A trust boundary exists between the .NET code and the code that runs inside the Web View. .NET code is provided by the app and any trusted third-party packages that you've installed. After the app is built, the .NET code Web View content sources can't change.

In contrast to the .NET code sources of content, content sources from the code that runs inside the Web View can come not only from the app but also from external sources. For example, static assets from an external Content Delivery Network (CDN) might be used or rendered by an app's Web View.

Consider the code inside the Web View as **untrusted** in the same way that code running inside the browser for a web app isn't trusted. The same threats and general security recommendations apply to untrusted resources in Blazor Hybrid apps as for other types of apps.

If possible, avoid loading content from a third-party origin. To mitigate risk, you might be able to serve content directly from the app by downloading the external assets, verifying that they're safe to serve to users, and placing them into the app's `wwwroot` folder for packaging with the rest of the app. When the external content is downloaded for inclusion in the app, we recommend scanning it for viruses and malware before placing it into the `wwwroot` folder of the app.

If your app must reference content from an external origin, we recommend that you use common web security approaches to provide the app with an opportunity to block the content from loading if the content is compromised:

* Serve content securely with TLS/HTTPS.
* Institute a [Content Security Policy (CSP)](https://developer.mozilla.org/docs/Web/HTTP/CSP).
* Perform [subresource integrity](https://developer.mozilla.org/docs/Web/Security/Subresource_Integrity) checks.

Even if all of the resources are packed into the app and don't load from any external origin, remain cautious about problems in the resources' code that run inside the Web View, as the resources might have vulnerabilities that could allow [cross-site scripting (XSS)](xref:blazor/security/server/threat-mitigation#cross-site-scripting-xss) attacks.

In general, the Blazor framework protects against XSS by dealing with HTML in safe ways. However, some programming patterns allow Razor components to inject raw HTML into rendered output, such as rendering content from an untrusted source. For example, rendering HTML content directly from a database should be avoided. Additionally, JavaScript libraries used by the app might manipulate HTML in unsafe ways to inadvertently or deliberately render unsafe output.

For these reasons, it's best to apply the same protections against XSS that are normally applied to web apps. Prevent loading scripts from unknown sources and don't implement potentially unsafe JavaScript features, such as [`eval`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/eval) and other unsafe JavaScript primitives. Establishing a CSP is recommended to reduce these security risks.

If the code inside the Web View is compromised, the code gains access to all of the content inside the Web View and might interact with the host via the interop channel. For that reason, any content coming from the Web View (events, JS interop) must be treated as **untrusted** and validated in the same way as for other sensitive contexts, such as in a compromised Blazor Server app that can lead to malicious attacks on the host system.

Don't store sensitive information, such as credentials, security tokens, or sensitive user data, in the context of the Web View, as it makes the information available to an attacker if the Web View is compromised. There are safer alternatives, such as handling the sensitive information directly within the native portion of the app.

## External content rendered in an `iframe`

When using an [`iframe`](https://developer.mozilla.org/docs/Web/HTML/Element/iframe) to display external content within a Blazor Hybrid page, we recommend that users leverage [sandboxing features](https://developer.mozilla.org/docs/Web/HTML/Element/iframe) to ensure that the content is isolated from the parent page containing the app. In the following Razor component example, the [`sandbox` attribute](https://developer.mozilla.org/docs/Web/HTML/Element/iframe) is present for the `<iframe>` tag to apply sandboxing features to the `admin.html` page:

```razor
<iframe sandbox src="https://contoso.com/admin.html" />
```

> [!WARNING]
> The [`sandbox` attribute](https://developer.mozilla.org/docs/Web/HTML/Element/iframe) is ***not*** supported in early browser versions. For more information, see [Can I use: `sandbox`](https://caniuse.com/?search=sandbox).

## Links to external URLs

By default, links to URLs outside of the app are opened in an appropriate external app, not loaded within the Web View. We do ***not*** recommend overriding the default behavior.

## Keep the Web View current in deployed apps

By default, the <xref:Microsoft.AspNetCore.Components.WebView.Maui.BlazorWebView> control uses the currently-installed, platform-specific native Web View. Since the native Web View is periodically updated with support for new APIs and fixes for security issues, it may be necessary to ensure that an app is using a Web View version that meets the app's requirements.

Use one of the following approaches to keep the Web View current in deployed apps:

* **On all platforms**: Check the Web View version and prompt the user to take any necessary steps to update it.
* **Only on Windows**: Package a fixed-version Web View within the app, using it in place of the system's shared Web View.

### Android

The Android Web View is distributed and updated via the [Google Play Store](https://play.google.com/store/apps/details?id=com.google.android.webview). Check the Web View version by reading the [`User-Agent`](https://developer.mozilla.org/docs/Web/HTTP/Headers/User-Agent) string. Read the Web View's [`navigator.userAgent`](https://developer.mozilla.org/docs/Web/API/Navigator/userAgent) property using [JavaScript interop](xref:blazor/js-interop/index) and optionally cache the value using a singleton service if the user agent string is required outside of a Razor component context.

When using the Android Emulator:

* Use an emulated device with **Google Play Services** preinstalled. Emulated devices without Google Play Services preinstalled are ***not*** supported.
* Install Google Chrome from the Google Play Store. If Google Chrome is already installed, [update Chrome from the Google Play Store](https://support.google.com/chrome/answer/95414?hl=en&co=GENIE.Platform%3DAndroid). If an emulated device doesn't have the latest version of Chrome installed, it might not have the latest version of the Android Web View installed.

### iOS/:::no-loc text="Mac Catalyst":::

iOS and :::no-loc text="Mac Catalyst"::: both use [`WKWebView`](https://developer.apple.com/documentation/webkit/wkwebview), a Safari-based control, which is updated by the operating system. Similar to the [Android](#android) case, determine the Web View version by reading the Web View's [`User-Agent`](https://developer.mozilla.org/docs/Web/HTTP/Headers/User-Agent) string.

### Windows (.NET MAUI, WPF, Windows Forms)

On Windows, the Chromium-based [Microsoft Edge `WebView2`](/microsoft-edge/webview2/) is required to run Blazor web apps.

By default, the newest installed version of `WebView2`, known as the *:::no-loc text="Evergreen distribution":::*, is used. If you wish to ship a specific version of `WebView2` with the app, use the *:::no-loc text="Fixed Version distribution":::*.

For more information on checking the currently-installed `WebView2` version and the distribution modes, see the [`WebView2` distribution documentation](/microsoft-edge/webview2/concepts/distribution).

## Additional resources

* <xref:blazor/hybrid/security/index>
* <xref:blazor/security/index>
