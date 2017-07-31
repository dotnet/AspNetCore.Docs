---
title: Preventing Cross-Site Scripting
author: rick-anderson
description: 
keywords: ASP.NET Core,
ms.author: riande
manager: wpickett
ms.date: 10/14/2016
ms.topic: article
ms.assetid: 95790927-2bfe-445e-b1fd-429c2c7030ce
ms.technology: aspnet
ms.prod: asp.net-core
uid: security/cross-site-scripting
---
# Preventing Cross-Site Scripting

<a name=security-cross-site-scripting></a>

Cross-Site Scripting (XSS) is a security vulnerability which enables an attacker to place client side scripts (usually JavaScript) into web pages. When other users load affected pages the attackers scripts will run, enabling the attacker to steal cookies and session tokens, change the contents of the web page through DOM manipulation or redirect the browser to another page. XSS vulnerabilities generally occur when an application takes user input and outputs it in a page without validating, encoding or escaping it.

## Protecting your application against XSS

At a basic level XSS works by tricking your application into inserting a `<script>` tag into your rendered page, or by inserting an `On*` event into an element. Developers should use the following prevention steps to avoid introducing XSS into their application.

1. Never put untrusted data into your HTML input, unless you follow the rest of the steps below. Untrusted data is any data that may be controlled by an attacker, HTML form inputs, query strings, HTTP headers, even data sourced from a database as an attacker may be able to breach your database even if they cannot breach your application.

2. Before putting untrusted data inside an HTML element ensure it is HTML encoded. HTML encoding takes characters such as &lt; and changes them into a safe form like &amp;lt;

3. Before putting untrusted data into an HTML attribute ensure it is HTML attribute encoded. HTML attribute encoding is a superset of HTML encoding and encodes additional characters such as " and '.

4. Before putting untrusted data into JavaScript place the data in an HTML element whose contents you retrieve at runtime. If this is not possible then ensure the data is JavaScript encoded. JavaScript encoding takes dangerous characters for JavaScript and replaces them with their hex, for example &lt; would be encoded as `\u003C`.

5. Before putting untrusted data into a URL query string ensure it is URL encoded.

## HTML Encoding using Razor

The Razor engine used in MVC automatically encodes all output sourced from variables, unless you work really hard to prevent it doing so. It uses HTML Attribute encoding rules whenever you use the *@* directive. As HTML attribute encoding is a superset of HTML encoding this means you don't have to concern yourself with whether you should use HTML encoding or HTML attribute encoding. You must ensure that you only use @ in an HTML context, not when attempting to insert untrusted input directly into JavaScript. Tag helpers will also encode input you use in tag parameters.

Take the following Razor view;

```none
@{
       var untrustedInput = "<\"123\">";
   }

   @untrustedInput
   ```

This view outputs the contents of the *untrustedInput* variable. This variable includes some characters which are used in XSS attacks, namely &lt;, " and &gt;. Examining the source shows the rendered output encoded as:

```html
&lt;&quot;123&quot;&gt;
   ```

>[!WARNING]
> ASP.NET Core MVC provides an `HtmlString` class which is not automatically encoded upon output. This should never be used in combination with untrusted input as this will expose an XSS vulnerability.

## Javascript Encoding using Razor

There may be times you want to insert a value into JavaScript to process in your view. There are two ways to do this. The safest way to insert simple values is to place the value in a data attribute of a tag and retrieve it in your JavaScript. For example:

```none
@{
       var untrustedInput = "<\"123\">";
   }

   <div
       id="injectedData"
       data-untrustedinput="@untrustedInput" />

   <script>
     var injectedData = document.getElementById("injectedData");

     // All clients
     var clientSideUntrustedInputOldStyle =
         injectedData.getAttribute("data-untrustedinput");

     // HTML 5 clients only
     var clientSideUntrustedInputHtml5 =
         injectedData.dataset.untrustedinput;

     document.write(clientSideUntrustedInputOldStyle);
     document.write("<br />")
     document.write(clientSideUntrustedInputHtml5);
   </script>
   ```

This will produce the following HTML

```html
<div
     id="injectedData"
     data-untrustedinput="&lt;&quot;123&quot;&gt;" />

   <script>
     var injectedData = document.getElementById("injectedData");

     var clientSideUntrustedInputOldStyle =
         injectedData.getAttribute("data-untrustedinput");

     var clientSideUntrustedInputHtml5 =
         injectedData.dataset.untrustedinput;

     document.write(clientSideUntrustedInputOldStyle);
     document.write("<br />")
     document.write(clientSideUntrustedInputHtml5);
   </script>
   ```

Which, when it runs, will render the following;

```none
<"123">
   <"123">
   ```

You can also call the JavaScript encoder directly,

```none
@using System.Text.Encodings.Web;
   @inject JavaScriptEncoder encoder;

   @{
       var untrustedInput = "<\"123\">";
   }

   <script>
       document.write("@encoder.Encode(untrustedInput)");
   </script>
   ```

This will render in the browser as follows;

```html
<script>
       document.write("\u003C\u0022123\u0022\u003E");
   </script>
   ```

>[!WARNING]
> Do not concatenate untrusted input in JavaScript to create DOM elements. You should use `createElement()` and assign property values appropriately such as `node.TextContent=`, or use `element.SetAttribute()`/`element[attribute]=` otherwise you expose yourself to DOM-based XSS.

## Accessing encoders in code

The HTML, JavaScript and URL encoders are available to your code in two ways, you can inject them via [dependency injection](../fundamentals/dependency-injection.md#fundamentals-dependency-injection) or you can use the default encoders contained in the `System.Text.Encodings.Web` namespace. If you use the default encoders then any  you applied to character ranges to be treated as safe will not take effect - the default encoders use the safest encoding rules possible.

To use the configurable encoders via DI your constructors should take an *HtmlEncoder*, *JavaScriptEncoder* and *UrlEncoder* parameter as appropriate. For example;

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

## Encoding URL Parameters

If you want to build a URL query string with untrusted input as a value use the `UrlEncoder` to encode the value. For example,

```csharp
var example = "\"Quoted Value with spaces and &\"";
   var encodedValue = _urlEncoder.Encode(example);
   ```

After encoding the encodedValue variable will contain `%22Quoted%20Value%20with%20spaces%20and%20%26%22`. Spaces, quotes, punctuation and other unsafe characters will be percent encoded to their hexadecimal value, for example a space character will become %20.

>[!WARNING]
> Do not use untrusted input as part of a URL path. Always pass untrusted input as a query string value.

<a name=security-cross-site-scripting-customization></a>

## Customizing the Encoders

By default encoders use a safe list limited to the Basic Latin Unicode range and encode all characters outside of that range as their character code equivalents. This behavior also affects Razor TagHelper and HtmlHelper rendering as it will use the encoders to output your strings.

The reasoning behind this is to protect against unknown or future browser bugs (previous browser bugs have tripped up parsing based on the processing of non-English characters). If your web site makes heavy use of non-Latin characters, such as Chinese, Cyrillic or others this is probably not the behavior you want.

You can customize the encoder safe lists to include Unicode ranges appropriate to your application during startup, in `ConfigureServices()`.

For example, using the default configuration you might use a Razor HtmlHelper like so;

```html
<p>This link text is in Chinese: @Html.ActionLink("汉语/漢語", "Index")</p>
   ```

When you view the source of the web page you will see it has been rendered as follows, with the Chinese text encoded;

```html
<p>This link text is in Chinese: <a href="/">&#x6C49;&#x8BED;/&#x6F22;&#x8A9E;</a></p>
   ```

To widen the characters treated as safe by the encoder you would insert the following line into the `ConfigureServices()` method in `startup.cs`;

```csharp
services.AddSingleton<HtmlEncoder>(
     HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.BasicLatin,
                                               UnicodeRanges.CjkUnifiedIdeographs }));
   ```

This example widens the safe list to include the Unicode Range CjkUnifiedIdeographs. The rendered output would now become

```html
<p>This link text is in Chinese: <a href="/">汉语/漢語</a></p>
   ```

Safe list ranges are specified as Unicode code charts, not languages. The [Unicode standard](http://unicode.org/) has a list of [code charts](http://www.unicode.org/charts/index.html) you can use to find the chart containing your characters. Each encoder, Html, JavaScript and Url, must be configured separately.

> [!NOTE]
> Customization of the safe list only affects encoders sourced via DI. If you directly access an encoder via `System.Text.Encodings.Web.*Encoder.Default` then the default, Basic Latin only safelist will be used.

## Where should encoding take place?

The general accepted practice is that encoding takes place at the point of output and encoded values should never be stored in a database. Encoding at the point of output allows you to change the use of data, for example, from HTML to a query string value. It also enables you to easily search your data without having to encode values before searching and allows you to take advantage of any changes or bug fixes made to encoders.

## Validation as an XSS prevention technique

Validation can be a useful tool in limiting XSS attacks. For example, a simple numeric string containing only the characters 0-9 will not trigger an XSS attack. Validation becomes more complicated should you wish to accept HTML in user input - parsing HTML input is difficult, if not impossible. MarkDown and other text formats would be a safer option for rich input. You should never rely on validation alone. Always encode untrusted input before output, no matter what validation you have performed.
