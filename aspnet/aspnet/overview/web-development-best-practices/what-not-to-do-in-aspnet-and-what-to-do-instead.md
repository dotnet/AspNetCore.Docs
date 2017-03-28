---
uid: aspnet/overview/web-development-best-practices/what-not-to-do-in-aspnet-and-what-to-do-instead
title: "What not to do in ASP.NET, and what to do instead | Microsoft Docs"
author: tfitzmac
description: "This topic describes several common mistakes people make within ASP.NET web projects. It provides recommendations for what you should do to avoid these commo..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 05/08/2014
ms.topic: article
ms.assetid: c39b9965-545c-4b04-8f55-21be7f28a9e5
ms.technology: 
ms.prod: .net-framework
msc.legacyurl: /aspnet/overview/web-development-best-practices/what-not-to-do-in-aspnet-and-what-to-do-instead
msc.type: authoredcontent
---
What not to do in ASP.NET, and what to do instead
====================
by [Tom FitzMacken](https://github.com/tfitzmac)

> This topic describes several common mistakes people make within ASP.NET web projects. It provides recommendations for what you should do to avoid these common mistakes. It is based on a [presentation](http://vimeo.com/68390507) by **Damian Edwards** at Norwegian Developers Conference.


## Disclaimer

This topic is not intended as a complete guide to ensure your application is secure and efficient. You still need to follow best practices for security and performance that are not outlined in this topic. It only suggests how to avoid common mistakes related to .NET classes and processes.

## Overview

This topic contains the following sections:

- [Standards Compliance](#standards)

    - [Control Adapters](#adapters)
    - [Style Properties on Controls](#styleprop)
    - [Page and Control Callbacks](#callback)
    - [Browser Capability Detection](#browsercap)
- [Security](#security)

    - [Request Validation](#validation)
    - [Cookieless Forms Authentication and Session](#cookieless)
    - [EnableViewStateMac](#viewstatemac)
    - [Medium Trust](#medium)
    - [&lt;appSettings&gt;](#appsettings)
    - [UrlPathEncode](#urlpathencode)
- [Reliability and Performance](#performance)

    - [PreSendRequestHeaders and PreSendRequestContext](#presend)
    - [Asynchronous Page Events with Web Forms](#asyncevents)
    - [Fire-and-Forget Work](#fire)
    - [Request Entity Body](#requestentity)
    - [Response.Redirect and Response.End](#redirect)
    - [EnableViewState and ViewStateMode](#viewstatemode)
    - [SqlMembershipProvider](#sqlprovider)
    - [Long Running Requests (>110 seconds)](#long)

<a id="standards"></a>

## Standards Compliance

<a id="adapters"></a>

### Control Adapters

Recommendation: Stop using control adapters for adaptive rendering, and instead use CSS media queries and standards-compliant HTML.

Controls Adapters were introduced in .NET 2.0 to render presentation code that was customized for different devices and environments. Now, this adaptive rendering can be accomplished with CSS and HTML. You should stop using Control Adapters and convert any existing adapters to CSS and HTML.

For more information, see [Media Queries](http://www.w3.org/TR/css3-mediaqueries/) and [How To: Add Mobile Pages to Your ASP.NET Web Forms / MVC Application](../../../whitepapers/add-mobile-pages-to-your-aspnet-web-forms-mvc-application.md).

<a id="styleprop"></a>

### Style Properties on Controls

Recommendation: Stop setting style values in the control markup, and instead set formatting values in CSS stylesheets.

Web server controls contain dozens of properties which can be used to set in-line style properties. For example, the ForeColor property sets the color of the text for a control. You can accomplish this same effect more efficiently through CSS stylesheets. Stylesheets enable you to centralize style values and avoid setting these values throughout your application.

The following example shows a CSS class the sets text to red.

[!code-css[Main](what-not-to-do-in-aspnet-and-what-to-do-instead/samples/sample1.css)]

The next example shows how to dynamically apply the CSS class.

[!code-csharp[Main](what-not-to-do-in-aspnet-and-what-to-do-instead/samples/sample2.cs)]

<a id="callback"></a>

### Page and Control Callbacks

Recommendation: Stop using page and control callbacks, and instead use any of the following: AJAX, UpdatePanel, MVC action methods, Web API, or SignalR.

In earlier versions of ASP.NET, Page and Control callback methods enabled you to update part of the web page without refreshing an entire page. You can now accomplish partial-page updates through [AJAX](../../../ajax/index.md), [UpdatePanel](https://msdn.microsoft.com/en-US/library/bb386454.aspx), [MVC](../../../mvc/index.md), [Web API](../../../web-api/index.md) or [SignalR](../../../signalr/index.md). You should stop using callback methods because they can cause issues with friendly URLs and routing. By default, controls do not enable callback methods, but if you enabled this feature in a control, you should disable it.

<a id="browsercap"></a>

### Browser Capability Detection

Recommendation: Stop using static browser capability detection, and instead use dynamic feature detection.

In earlier versions of ASP.NET, the supported features for each browser were stored in an XML file. Detecting feature support through a static lookup is not the best approach. Now, you can dynamically detect a browser's supported features by using a feature detection framework, such as [Modernizr](http://modernizr.com/). Feature detection determines support by attempting to use a method or property and then checking to see if the browser produced the desired result. By default, Modernizr is included in the Web application templates.

<a id="security"></a>

## Security

<a id="validation"></a>

### Request Validation

Recommendation: Validate user input, and encode output from users.

Request validation is a feature of ASP.NET that inspects each request and stops the request if a perceived threat is found. Do not depend on request validation for securing your application against cross-site scripting attacks. Instead, validate all input from users and encode the output. In some limited cases, you can use regular expressions to validate the input, but in more complicated cases you should validate user input by using .NET classes that determine if the value matches allowed values.

The following example shows how to use a static method in the Uri class to determine whether the Uri provided by a user is valid.

[!code-csharp[Main](what-not-to-do-in-aspnet-and-what-to-do-instead/samples/sample3.cs)]

However, to sufficiently verify the Uri, you should also check to make sure it specifies `http` or `https`. The following example uses instance methods to verify that the Uri is valid.

[!code-csharp[Main](what-not-to-do-in-aspnet-and-what-to-do-instead/samples/sample4.cs)]

Before rendering user input as HTML or including user input in a SQL query, encode the values to ensure malicious code is not included.

You can HTML encode the value in markup with the &lt;%: %&gt; syntax, as shown below.

[!code-aspx[Main](what-not-to-do-in-aspnet-and-what-to-do-instead/samples/sample5.aspx?highlight=1)]

Or, in Razor syntax, you can HTML encode with @, as shown below.

[!code-cshtml[Main](what-not-to-do-in-aspnet-and-what-to-do-instead/samples/sample6.cshtml?highlight=1)]

The next example shows how to HTML encode a value in code-behind.

[!code-csharp[Main](what-not-to-do-in-aspnet-and-what-to-do-instead/samples/sample7.cs)]

To safely encode a value for SQL commands, use command parameters such as the [SqlParameter](https://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlparameter.aspx). <a id="cookieless"></a>

### Cookieless Forms Authentication and Session

Recommendation: Require cookies.

Passing authentication information in the query string is not secure. Therefore, require cookies when your application includes authentication. If your cookie stores sensitive information, consider requiring SSL for the cookie.

The following example shows how to specify in the Web.config file that Forms Authentication requires a cookie that is transmitted over SSL.

[!code-xml[Main](what-not-to-do-in-aspnet-and-what-to-do-instead/samples/sample8.xml)]

<a id="viewstatemac"></a>

### EnableViewStateMac

Recommendation: Never set to false.

By default, EnbableViewStateMac is set to true. Even if your application is not using view state, do not set EnableViewStateMac to false. Setting this value to false will make your application vulnerable to cross-site scripting.

Starting with ASP.NET 4.5.2, the runtime enforces **EnableViewStateMac=true**. Even if you set it to false, the runtime ignores this value and proceeds with the value set to true. For more information, see [ASP.NET 4.5.2 and EnableViewStateMac](https://blogs.msdn.com/b/webdev/archive/2014/05/07/asp-net-4-5-2-and-enableviewstatemac.aspx).

The following example shows how to set EnableViewStateMac to true. You do not need to actually set this value to true because it is true by default. However, if you have set it to false on any page in your application, you must immediately correct this value.

[!code-aspx[Main](what-not-to-do-in-aspnet-and-what-to-do-instead/samples/sample9.aspx)]

<a id="medium"></a>

### Medium Trust

Recommendation: Do not depend on Medium Trust (or any other trust level) as a security boundary.

Partial trust does not adequately protect your application and should not be used. Instead, use Full Trust, and isolate untrusted applications in separate application pools. Also, run each application pool under a unique identity. For more information, see [ASP.NET Partial Trust does not guarantee application isolation](https://support.microsoft.com/kb/2698981).

<a id="appsettings"></a>

### &lt;appSettings&gt;

Recommendation: Do not disable security settings in &lt;appSettings&gt; element.

The appSettings element contains many values which are required for security updates. You should not change or disable these values. If you must disable these values when deploying an update, immediately re-enable after completing deployment.

For details, see [ASP.NET appSettings Element](https://msdn.microsoft.com/en-us/library/hh975440.aspx).

<a id="urlpathencode"></a>

### UrlPathEncode

Recommendation: Use [UrlEncode](https://msdn.microsoft.com/en-us/library/zttxte6w.aspx) instead.

The UrlPathEncode method was added to the .NET Framework to resolve a very specific browser compatibility problem. It does not adequately encode a URL, and does not protect your application from cross-site scripting. You should never use it in your application. Instead, use [UrlEncode](https://msdn.microsoft.com/en-us/library/zttxte6w.aspx).

The following example shows how to pass an encoded URL as a query string parameter for a hyperlink control.

[!code-csharp[Main](what-not-to-do-in-aspnet-and-what-to-do-instead/samples/sample10.cs)]

<a id="performance"></a>

## Reliability and Performance

<a id="presend"></a>

### PreSendRequestHeaders and PreSendRequestContext

Recommendation: Do not use these events with managed modules. Instead, write a native IIS module to perform the required task. See [Creating Native-Code HTTP Modules](https://msdn.microsoft.com/en-us/library/ms693629.aspx).

You can use the [PreSendRequestHeaders](https://msdn.microsoft.com/en-us/library/system.web.httpapplication.presendrequestheaders.aspx) and [PreSendRequestContext](https://msdn.microsoft.com/en-us/library/system.web.httpapplication.presendrequestcontent.aspx) events with native IIS modules, but do not use them with managed modules that implement IHttpModule. Setting these properties can cause issues with asynchronous requests.

<a id="asyncevents"></a>

### Asynchronous Page Events with Web Forms

Recommendation: In Web Forms, avoid writing async void methods for Page lifecycle events, and instead use [Page.RegisterAsyncTask](https://msdn.microsoft.com/en-us/library/system.web.ui.page.registerasynctask.aspx) for asynchronous code.

When you mark a page event with **async** and **void**, you cannot determine when the asynchronous code has finished. Instead, use Page.RegisterAsyncTask to run the asynchronous code in a way that enables you to track its completion.

The following example shows a button click handler that contains asynchronous code. This example includes reading a string value asynchronously, which is provided only as a simplified example of an asynchronous task and not as a recommended practice.

[!code-csharp[Main](what-not-to-do-in-aspnet-and-what-to-do-instead/samples/sample11.cs)]

If you are using asynchronous Tasks, set the Http runtime target framework to 4.5 in the Web.config file. Setting the target framework to 4.5 turns on the new synchronization context that was added in .NET 4.5. This value is set by default in new projects in Visual Studio 2012, but is not be set if you are working with an existing project.

[!code-xml[Main](what-not-to-do-in-aspnet-and-what-to-do-instead/samples/sample12.xml)]

<a id="fire"></a>

### Fire-and-Forget Work

Recommendation: When handling a request within ASP.NET, avoid launching fire-and-forget work (such calling the ThreadPool.QueueUserWorkItem method or creating a timer that repeatedly calls a delegate).

If your application has fire-and-forget work that runs within ASP.NET, your application can get out of sync. At any time, the app domain can be destroyed which means your ongoing process may no longer match the current state of the application.

You should move this type of work outside of ASP.NET. You can use a Web Jobs, Windows Service or a Worker role in Azure to perform ongoing work, and run that code from another process.

If you must perform this work within ASP.NET, you can add the Nuget package called [WebBackgrounder](http://www.nuget.org/packages/webbackgrounder) to run the code.

<a id="requestentity"></a>

### Request Entity Body

Recommendation: Avoid reading Request.Form or Request.InputStream before the handler's execute event.

The earliest you should read from Request.Form or Request.InputStream is during the handler's execute event. In MVC, the Controller is the handler and the execute event is when the action method runs. In Web Forms, the Page is the handler and the execute event is when the Page.Init event fires. If you read the request entity body earlier than the execute event, you interfere with the processing of the request.

If you need to read the request entity body before the execute event, use either [Request.GetBufferlessInputStream](https://msdn.microsoft.com/en-us/library/ff406798.aspx) or [Request.GetBufferedInputStream](https://msdn.microsoft.com/en-us/library/system.web.httprequest.getbufferedinputstream.aspx). When you use GetBufferlessInputStream, you get the raw stream from the request, and assume responsibility for processing the entire request. After calling GetBufferlessInputStream, Request.Form and Request.InputStream are not available because they have not been populated by ASP.NET. When you use GetBufferedInputStream, you get a copy of the stream from the request. Request.Form and Request.InputStream are still available later in the request because ASP.NET populates the other copy.

<a id="redirect"></a>

### Response.Redirect and Response.End

Recommendation: Be aware of differences in how thread is handled after calling [Response.Redirect(String)](https://msdn.microsoft.com/en-us/library/t9dwyts4.aspx).

The [Response.Redirect(String)](https://msdn.microsoft.com/en-us/library/t9dwyts4.aspx) method calls the Response.End method. In a synchronous process, calling Request.Redirect causes the current thread to immediately abort. However, in an asynchronous process, calling Response.Redirect does not abort the current thread, so code execution continues for the request. In an asynchronous process, you must return the Task from the method to stop the code execution.

In an MVC project, you should not call Response.Redirect. Instead, return a RedirectResult.

<a id="viewstatemode"></a>

### EnableViewState and ViewStateMode

Recommendation: Use ViewStateMode, instead of EnableViewState, to provide granular control over which controls use view state.

When you set EnableViewState to false in the Page directive, view state is disabled for all controls within the page and cannot be enabled. If you want to enable view state for only certain controls in your page, set ViewStateMode to Disabled for the Page.

[!code-aspx[Main](what-not-to-do-in-aspnet-and-what-to-do-instead/samples/sample13.aspx)]

Then, set ViewStateMode to Enabled on only the controls that actually need view state.

[!code-aspx[Main](what-not-to-do-in-aspnet-and-what-to-do-instead/samples/sample14.aspx)]

By enabling view state for only the controls that need it, you can shrink the size of the view state for your web pages.

<a id="sqlprovider"></a>

### SqlMembershipProvider

Recommendation: Use Universal Providers.

In the current project templates, SqlMembershipProvider has been replaced by [ASP.NET Universal Providers](http://www.nuget.org/packages/Microsoft.AspNet.Providers), which is available as a NuGet package. If you are using SqlMembershipProvider in a project that was built with an earlier version of the templates, you should switch to Universal Providers. The Universal Providers work with all databases that are supported by Entity Framework.

For more information, see [Introducing ASP.NET Universal Providers](http://www.hanselman.com/blog/IntroducingSystemWebProvidersASPNETUniversalProvidersForSessionMembershipRolesAndUserProfileOnSQLCompactAndSQLAzure.aspx).

<a id="long"></a>

### Long-running Requests (>110 seconds)

Recommendation: Use [WebSockets](https://msdn.microsoft.com/en-us/library/system.net.websockets.websocket.aspx) or [SignalR](../../../signalr/index.md) for connected clients, and use asynchronous I/O operations.

Long-running requests can cause unpredictable results and poor performance in your web application. The default timeout setting for a request is 110 seconds. If you are using session state with a long-running request, ASP.NET will release the lock on the Session object after 110 seconds. However, your application might be in the middle of an operation on the Session object when the lock is released, and the operation might not complete successfully. If a second request from the user is blocked while the first request is running, the second request might access the Session object in an inconsistent state.

If your application includes blocking (or synchronous) I/O operations, the application will be unresponsive.

To improve performance, use the asynchronous I/O operations in the .NET Framework. Also, use WebSockets or SignalR for connecting clients to the server. These features are designed to efficiently handle long-running requests.
