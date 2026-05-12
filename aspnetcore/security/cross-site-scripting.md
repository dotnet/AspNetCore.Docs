---
title: Prevent Cross-Site Scripting (XSS) in ASP.NET Core
author: tdykstra
description: Learn about Cross-Site Scripting (XSS) and techniques for addressing this vulnerability in an ASP.NET Core app.
ms.author: tdykstra
monikerRange: '>= aspnetcore-3.1'
ms.date: 05/12/2026
uid: security/cross-site-scripting
ai-usage: ai-assisted

# customer intent: As an ASP.NET Core developer, I want to prevent Cross-Site Scripting in my ASP.NET Core app, so I can protect my apps against this vulnerability.
---
# Prevent Cross-Site Scripting (XSS) in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT)

Cross-Site Scripting (XSS) is a security vulnerability that enables a cyberattacker to place client side scripts (usually JavaScript) into web pages. When other users load affected pages, the cyberattacker's scripts run. The cyberattacker can then steal cookies and session tokens, change the contents of the web page through DOM manipulation, or redirect the browser to another page. XSS vulnerabilities generally occur when an application takes user input and outputs it to a page without validating, encoding, or escaping it.

This article applies primarily to ASP.NET Core MVC with views, Razor Pages, and other apps that return HTML that can be vulnerable to XSS. Web APIs that return data in the form of HTML, XML, or JSON can trigger XSS attacks in their client apps if they don't properly sanitize user input. This behavior depends on how much trust the client app places in the API. If an API accepts user-generated content and returns it in an HTML response, the data is open to attack. A cyberattacker can inject malicious scripts into the content that executes when the response is rendered in the user's browser.

To prevent XSS attacks, web APIs should implement input validation and output encoding. Input validation ensures that user input meets expected criteria and doesn't include malicious code. Output encoding ensures that any data returned by the API is properly sanitized so it can't be executed as code by the user's browser. For more information, see [GitHub dotnet/aspnetcore.docs issue #28789](https://github.com/dotnet/AspNetCore.Docs/issues/28789).

## Protect your application against XSS

At a basic level, XSS works by tricking your application into inserting a `<script>` tag into your rendered page, or by inserting an `On*` event into an element.

To avoid introducing XSS into the application, developers should implement the following prevention techniques:

- Never put untrusted data into your HTML input, unless you follow the other techniques listed in this section.

   Untrusted data is any data controllable by a cyberattacker. Examples include HTML form inputs, query strings, HTTP headers, or even data sourced from a database. A cyberattacker might be able to breach your database even if they can't breach your application.

- Before you put untrusted data into an HTML element, ensure the data is HTML encoded.

   HTML encoding takes characters such as the left angle bracket or _less than_ (`<`) and changes them into a safe form like (`&lt;`).

- Before you put untrusted data into an HTML attribute, ensure the data is HTML-attribute encoded.

   This specialized form of HTML encoding handles double quote (`"`), single quote (`'`), ampersand (`&`), and less than (`<`) characters. When dealing with untrusted input, use HTML encoding for general HTML content and HTML attribute encoding for HTML attributes.

- Before you put untrusted data into JavaScript, place the data in an HTML element whose contents you retrieve at runtime.

   If you can't follow this technique, ensure the data is JavaScript encoded. JavaScript encoding converts dangerous characters for JavaScript into a hexadecimal equivalent value. For example, JavaScript encoding changes the less than (`<`) character into the hex value `\u003C`.

- Before you put untrusted data into a URL query string, ensure the data is URL encoded.

## Explore HTML encoding with Razor

The Razor engine used in MVC automatically encodes all output sourced from variables, unless you work to prevent this behavior. It uses HTML attribute encoding rules whenever you use the at symbol `@` directive. Because HTML attribute encoding is a superset of HTML encoding, you don't have to consider whether to use HTML encoding or HTML-attribute encoding. You must ensure that you only use the at symbol `@` in an HTML context, and not when attempting to insert untrusted input directly into JavaScript. [Razor Tag Helpers](xref:../mvc/views/tag-helpers/intro) also encode input you use in tag parameters.

Consider the following Razor view:

```cshtml
@{
    var untrustedInput = "<\"123\">";
}

@untrustedInput
```

This view outputs the contents of the `untrustedInput` variable. The variable includes some characters used in XSS attacks: left angle bracket (less than) (`<`), double quote (`"`), and right angle bracket (greater than) (`>`). Examining the source shows the rendered output encoded as:

```html
&lt;&quot;123&quot;&gt;
```

> [!WARNING]
> ASP.NET Core MVC provides an `HtmlString` class that isn't automatically encoded upon output. This class should never be used in combination with untrusted input because it exposes an XSS vulnerability.

## Explore JavaScript encoding with Razor

In some instances, you might want to insert a value into JavaScript to process in your view. There are two ways to accomplish this task. The safest way to insert values is to place the value in a data attribute of a tag and retrieve it in your JavaScript. For example:

```cshtml
@{
    var untrustedInput = "<script>alert(1)</script>";
}

<div id="injectedData"
     data-untrustedinput="@untrustedInput" />

<div id="scriptedWrite" />
<div id="scriptedWrite-html5" />

<script>
    var injectedData = document.getElementById("injectedData");

    // All clients
    var clientSideUntrustedInputOldStyle =
        injectedData.getAttribute("data-untrustedinput");

    // HTML 5 clients only
    var clientSideUntrustedInputHtml5 =
        injectedData.dataset.untrustedinput;

    // Put the injected, untrusted data into the scriptedWrite div tag.
    // Do NOT use document.write() on dynamically generated data as it can lead to XSS.

    document.getElementById("scriptedWrite").innerText += clientSideUntrustedInputOldStyle;

    // Or, you can use createElement() to dynamically create document elements.
    // This instance uses textContent to ensure the data is properly encoded.
    var x = document.createElement("div");
    x.textContent = clientSideUntrustedInputHtml5;
    document.body.appendChild(x);

    // You can also use createTextNode on an element to ensure data is properly encoded.
    var y = document.createElement("div");
    y.appendChild(document.createTextNode(clientSideUntrustedInputHtml5));
    document.body.appendChild(y);

</script>
```

The preceding markup generates the following HTML:

```html
<div id="injectedData"
     data-untrustedinput="&lt;script&gt;alert(1)&lt;/script&gt;" />

<div id="scriptedWrite" />
<div id="scriptedWrite-html5" />

<script>
    var injectedData = document.getElementById("injectedData");

    // All clients
    var clientSideUntrustedInputOldStyle =
        injectedData.getAttribute("data-untrustedinput");

    // HTML 5 clients only
    var clientSideUntrustedInputHtml5 =
        injectedData.dataset.untrustedinput;

    // Put the injected, untrusted data into the scriptedWrite div tag.
    // Do NOT use document.write() on dynamically generated data as it can lead to XSS.

    document.getElementById("scriptedWrite").innerText += clientSideUntrustedInputOldStyle;

    // Or, you can use createElement() to dynamically create document elements.
    // This instance uses textContent to ensure the data is properly encoded.
    var x = document.createElement("div");
    x.textContent = clientSideUntrustedInputHtml5;
    document.body.appendChild(x);

    // You can also use createTextNode on an element to ensure data is properly encoded.
    var y = document.createElement("div");
    y.appendChild(document.createTextNode(clientSideUntrustedInputHtml5));
    document.body.appendChild(y);

</script>
```

The preceding code generates the following output:

```output
<script>alert(1)</script>
<script>alert(1)</script>
<script>alert(1)</script>
```

> [!WARNING]
> Don't concatenate untrusted input in JavaScript for creating DOM elements or use `document.write()` on dynamically generated content.
>
> Instead, use one of the following approaches to prevent code from being exposed to DOM-based XSS:
>
> * Call `createElement()` and assign property values with appropriate methods or properties, such as `node.textContent=` or `node.InnerText=`.
> * Call the `document.CreateTextNode()` method and append it in the appropriate DOM location.
> * Call the `element.SetAttribute()` method.
> * Use the `element[attribute]=` assignment.

## Access encoders in code

You can use HTML, JavaScript, and URL encoders in your code in two ways:

* Inject them via [dependency injection](xref:fundamentals/dependency-injection).
* Use the default encoders contained in the `System.Text.Encodings.Web` namespace.

When you use the default encoders, any customizations applied to character ranges (so they're treated as safe) don't take effect. The default encoders use the safest encoding rules possible.

To use the configurable encoders via dependency injection, your constructors should take an `HtmlEncoder`, `JavaScriptEncoder`, and `UrlEncoder` parameter, as appropriate.

For example:

```csharp
public class HomeController : Controller
{
    HtmlEncoder _htmlEncoder;
    JavaScriptEncoder _javaScriptEncoder;
    UrlEncoder _urlEncoder;

    public HomeController(HtmlEncoder htmlEncoder,
                          JavaScriptEncoder javascriptEncoder,
                          UrlEncoder urlEncoder)
    {
        _htmlEncoder = htmlEncoder;
        _javaScriptEncoder = javascriptEncoder;
        _urlEncoder = urlEncoder;
    }
}
```

## Encode URL parameters

If you want to build a URL query string with untrusted input as a value, use the `UrlEncoder` parameter to encode the value:

```csharp
var example = "\"Quoted Value with spaces and &\"";
var encodedValue = _urlEncoder.Encode(example);
```

After encoding, the `encodedValue` variable contains the string `%22Quoted%20Value%20with%20spaces%20and%20%26%22`. Spaces, quotes, punctuation, and other unsafe characters are percent encoded to their hexadecimal value. For example, a space character is converted to `%20`.

> [!WARNING]
> Don't use untrusted input as part of a URL path. Always pass untrusted input as a query string value.

## Customize the encoders

By default, encoders use a safe list limited to the Basic Latin Unicode range. All characters outside of the indicated range are encoded as their character code equivalents. This behavior also affects rendering by Razor Tag Helpers and HTML Helpers because they use the encoders to output your strings.

The purpose for this behavior is to protect against unknown or future browser bugs. Previous browser bugs tripped up parsing based on the processing of non-English characters. If your web site makes heavy use of non-Latin characters, such as Chinese, Cyrillic, or others, this behavior is probably not suited for your configuration.

:::moniker range=">= aspnetcore-6.0"

You can customize the encoder safe lists to include Unicode ranges appropriate to the app during startup. Make the customizations in the _Program.cs_ file.

For example, you can use the default configuration with a Razor HTML Helper similar to the following HTML:

```html
<p>This link text is in Chinese: @Html.ActionLink("汉语/漢語", "Index")</p>
```

The preceding markup is rendered with Chinese text encoded:

```html
<p>This link text is in Chinese: <a href="/">&#x6C49;&#x8BED;/&#x6F22;&#x8A9E;</a></p>
```

To widen the range of characters treated as safe by the encoder, insert the following line into the _Program.cs_ file:

```csharp
builder.Services.AddSingleton<HtmlEncoder>(
     HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.BasicLatin,
                                               UnicodeRanges.CjkUnifiedIdeographs }));
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

You can customize the encoder safe lists to include Unicode ranges appropriate to your application during startup, in `ConfigureServices()`.

For example, using the default configuration you might use a Razor HtmlHelper like so;

```html
<p>This link text is in Chinese: @Html.ActionLink("汉语/漢語", "Index")</p>
```

When you view the source of the web page you'll see it has been rendered as follows, with the Chinese text encoded;

```html
<p>This link text is in Chinese: <a href="/">&#x6C49;&#x8BED;/&#x6F22;&#x8A9E;</a></p>
```

To widen the characters treated as safe by the encoder you would insert the following line into the `ConfigureServices()` method in `startup.cs`;

```csharp
services.AddSingleton<HtmlEncoder>(
     HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.BasicLatin,
                                               UnicodeRanges.CjkUnifiedIdeographs }));
```

:::moniker-end

This example widens the safe list to include the Unicode Range [CJK Unified Ideographs](https://wikipedia.org/wiki/CJK_Unified_Ideographs). The following output shows the rendered view for the wider range of safe characters:

```html
<p>This link text is in Chinese: <a href="/">汉语/漢語</a></p>
```

Safe list ranges are specified as Unicode code charts, not languages. The [Unicode standard](https://unicode.org/) has a list of [code charts](https://www.unicode.org/charts/index.html) you can use to find the chart that contains your characters. Each encoder (HTML, JavaScript, URL) must be configured separately.

> [!NOTE]
> Customization of the safe list only affects encoders sourced via dependency injection.
> If you directly access an encoder via `System.Text.Encodings.Web.*Encoder.Default`, only the default safe list is used, Basic Latin.

## Determine when and where to encode

In general, the accepted practice is that encoding takes place at the point of output and encoded values should never be stored in a database.

Encoding at the point of output allows you to change the use of data/ For example, change from HTML to a query string value. This approach enables you to easily search your data without having to encode values before searching. It also allows you to take advantage of any changes or bug fixes made to encoders.

## Use validation as an XSS prevention technique

Validation can be a useful tool in limiting XSS attacks. For example, a numeric string containing only the characters 0-9 doesn't trigger an XSS attack.

Validation is more complicated when HTML is accepted in user input. Parsing HTML input can be difficult, and sometimes, impossible. Markdown, coupled with a parser that strips embedded HTML, is a safer option for accepting rich input.

Never rely on validation alone. Always encode untrusted input before output, no matter what validation or sanitization is performed.

## Related content

- <xref:fundamentals/dependency-injection>
- [Unicode 17.0 Character Code Charts](https://www.unicode.org/charts/index.html)
- [Razor Tag Helpers](xref:../mvc/views/tag-helpers/intro)
