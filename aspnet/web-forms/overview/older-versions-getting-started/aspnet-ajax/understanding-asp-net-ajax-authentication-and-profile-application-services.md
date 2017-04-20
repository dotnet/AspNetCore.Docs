---
uid: web-forms/overview/older-versions-getting-started/aspnet-ajax/understanding-asp-net-ajax-authentication-and-profile-application-services
title: "Understanding ASP.NET AJAX Authentication and Profile Application Services | Microsoft Docs"
author: scottcate
description: "The Authentication service allows users to provide credentials in order to receive an authentication cookie, and is the gateway service to allow custom user..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 03/14/2008
ms.topic: article
ms.assetid: 6ab4efb6-aab6-45ac-ad2c-bdec5848ef9e
ms.technology: dotnet-webforms
ms.prod: .net-framework
msc.legacyurl: /web-forms/overview/older-versions-getting-started/aspnet-ajax/understanding-asp-net-ajax-authentication-and-profile-application-services
msc.type: authoredcontent
---
Understanding ASP.NET AJAX Authentication and Profile Application Services
====================
by [Scott Cate](https://github.com/scottcate)

[Download PDF](http://download.microsoft.com/download/C/1/9/C19A3451-1D14-477C-B703-54EF22E197EE/AJAX_tutorial03_MSAjax_ASP.NET_Services_cs.pdf)

> The Authentication service allows users to provide credentials in order to receive an authentication cookie, and is the gateway service to allow custom user profiles provided by ASP.NET. Use of the ASP.NET AJAX authentication service is compatible with standard ASP.NET Forms authentication, so applications currently using Forms authentication (such as with the Login control) will not be broken by upgrading to the AJAX authentication service.


## Introduction

As part of the .NET Framework 3.5, Microsoft is delivering a sizable environment upgrade; not only is a new development environment available, but the new Language-Integrated Query (LINQ) features and other language enhancements are forthcoming. In addition, some familiar features of other toolsets, notably the ASP.NET AJAX Extensions, are being included as first-class members of the .NET Framework Base Class Library. These extensions enable many new rich client features, including partial rendering of pages without requiring a full page refresh, the ability to access Web Services via client script (including the ASP.NET profiling API), and an extensive client-side API designed to mirror many of the control schemes seen in the ASP.NET server-side control set.

This whitepaper looks at the implementation and use of the ASP.NET Profiling and Forms Authentication services as they are exposed by the Microsoft ASP.NET AJAX ExtensionsThe AJAX Extensions make Forms authentication incredibly easy to support, as it (as well as the Profiling Service) is exposed through a Web Service proxy script. The AJAX Extensions also support custom authentication through the AuthenticationServiceManager class.

This whitepaper is based on the Beta 2 release of the Visual Studio 2008 and the .NET Framework 3.5. This whitepaper also assumes that you will be working with Visual Studio 2008 Beta 2, not Visual Web Developer Express, and will provide walkthroughs according to the user interface of Visual Studio. Some code samples may utilize project templates unavailable in Visual Web Developer Express.

## *Profiles and Authentication*

The Microsoft ASP.NET Profiles and Authentication services are provided by the ASP.NET Forms Authentication system, and are standard components of ASP.NET. The ASP.NET AJAX Extensions provide script access to these services via script proxies, through a fairly straightforward model under the Sys.Services namespace of the client AJAX library.

The Authentication service allows users to provide credentials in order to receive an authentication cookie, and is the gateway service to allow custom user profiles provided by ASP.NET. Use of the ASP.NET AJAX authentication service is compatible with standard ASP.NET Forms authentication, so applications currently using Forms authentication (such as with the Login control) will not be broken by upgrading to the AJAX authentication service.

The Profile service allows the automatic integration and storage of user data based on membership as provided by the Authentication service. The stored data is specified by the web.config file, and the various profiling service providers handle the data management. As with the Authentication service, the AJAX Profile service is compatible with the standard ASP.NET profile service, so that pages currently incorporating features of the ASP.NET Profile service should not be broken by including AJAX support.

Incorporating the ASP.NET Authentication and Profiling services themselves into an application is outside of the scope of this whitepaper. For more information on the topic, see the MSDN Library reference article Managing Users by Using Membership at [https://msdn.microsoft.com/en-us/library/tw292whz.aspx](https://msdn.microsoft.com/en-us/library/tw292whz.aspx). ASP.NET also includes a utility to automatically set up Membership with a SQL Server, which is the default authentication service provider for ASP.NET Membership. For more information, see the article ASP.NET SQL Server Registration Tool (Aspnet\_regsql.exe) at [https://msdn.microsoft.com/en-us/library/ms229862(vs.80).aspx](https://msdn.microsoft.com/en-us/library/ms229862(vs.80).aspx).

## *Using the ASP.NET AJAX Authentication Service*

The ASP.NET AJAX Authentication service must be enabled in the web.config file:

[!code-xml[Main](understanding-asp-net-ajax-authentication-and-profile-application-services/samples/sample1.xml)]

The Authentication service requires ASP.NET Forms authentication to be enabled and requires cookies to be enabled on the client browser (a script cannot enable a cookieless session since cookieless sessions require URL parameters).

Once the AJAX authentication service is enabled and configured, client script can immediately take advantage of the Sys.Services.AuthenticationService object. Primarily, client script will want to take advantage of the `login` method and `isLoggedIn` property. Several properties exist to provide defaults for the login method, which can accept a large number of parameters.

*Sys.Services.AuthenticationService members*

*login method:*

The login() method begins a request to authenticate the user's credentials. This method is asynchronous and does not block execution.

*Parameters:*

| **Parameter Name** | **Meaning** |
| --- | --- |
| userName | Required. The username to authenticate. |
| password | Optional (defaults to null). The user's password. |
| isPersistent | Optional (defaults to false). Whether the user's authentication cookie should persist across sessions. If false, the user will log out when the browser is closed or the session expires. |
| redirectUrl | Optional (defaults to null).The URL to redirect the browser to upon successful authentication. If this parameter is null or an empty string, no redirection occurs. |
| customInfo | Optional (defaults to null). This parameter is currently unused and is reserved for future use. |
| loginCompletedCallback | Optional (defaults to null).The function to call when the login has successfully completed. If specified, this parameter overrides the defaultLoginCompleted property. |
| failedCallback | Optional (defaults to null).The function to call when the login has failed. If specified, this parameter overrides the defaultFailedCallback property. |
| userContext | Optional (defaults to null). Custom user context data that should be passed to the callback functions. |

*Return Value:*

This function does not include a return value. However, a number of behaviors are included upon completion of a call to this function:

- The current page will either be refreshed or be changed if the `redirectUrl` parameter was neither null nor an empty string.
- However, if the parameter was null or an empty string, the `loginCompletedCallback` parameter, or `defaultLoginCompletedCallback` property is called.
- If the call to the web service fails, the `failedCallback` parameter of `defaultFailedCallback` property is called.

*logout method:*

The logout() method removes the credentials cookie and logs out the current user from the web application.

*Parameters:*

| **Parameter Name** | **Meaning** |
| --- | --- |
| redirectUrl | Optional (defaults to null).The URL to redirect the browser to upon successful authentication. If this parameter is null or an empty string, no redirection occurs. |
| logoutCompletedCallback | Optional (defaults to null).The function to call when the logout has successfully completed. If specified, this parameter overrides the defaultLogoutCompleted property. |
| failedCallback | Optional (defaults to null).The function to call when the login has failed. If specified, this parameter overrides the defaultFailedCallback property. |
| userContext | Optional (defaults to null). Custom user context data that should be passed to the callback functions. |

*Return Value:*

This function does not include a return value. However, a number of behaviors are included upon completion of a call to this function:

- The current page will either be refreshed or be changed if the `redirectUrl` parameter was neither null nor an empty string.
- However, if the parameter was null or an empty string, the `logoutCompletedCallback` parameter, or `defaultLogoutCompletedCallback` property is called.
- If the call to the web service fails, the `failedCallback` parameter of `defaultFailedCallback` property is called.

*defaultFailedCallback property (get, set):*

This property specifies a function that should be called if a failure to communicate with the web service occurs. It should receive a delegate (or function reference).

The function reference specified by this property should have the following signature:

[!code-javascript[Main](understanding-asp-net-ajax-authentication-and-profile-application-services/samples/sample2.js)]

*Parameters:*

| **Parameter Name** | **Meaning** |
| --- | --- |
| error | Specifies the error information. |
| userContext | Specifies the user context information provided when the login or logout function was called. |
| methodName | The name of the calling method. |

*defaultLoginCompletedCallback property (get, set):*

This property specifies a function that should be called when the login web service call has completed. It should receive a delegate (or function reference).

The function reference specified by this property should have the following signature:

[!code-javascript[Main](understanding-asp-net-ajax-authentication-and-profile-application-services/samples/sample3.js)]

*Parameters:*

| **Parameter Name** | **Meaning** |
| --- | --- |
| validCredentials | Specifies whether the user provided valid credentials. `true` if the user successfully logged in; otherwise `false`. |
| userContext | Specifies the user context information provided when the login function was called. |
| methodName | The name of the calling method. |

*defaultLogoutCompletedCallback property (get, set):*

This property specifies a function that should be called when the logout web service call has completed. It should receive a delegate (or function reference).

The function reference specified by this property should have the following signature:

[!code-javascript[Main](understanding-asp-net-ajax-authentication-and-profile-application-services/samples/sample4.js)]

*Parameters:*

| **Parameter Name** | **Meaning** |
| --- | --- |
| result | This parameter will always be `null`; it is reserved for future use. |
| userContext | Specifies the user context information provided when the login function was called. |
| methodName | The name of the calling method. |

*isLoggedIn property (get):*

This property gets the current authentication state of the user; it is set by the ScriptManager object during a page request.

This property returns `true` if the user is currently logged in; otherwise, it returns `false`.

*path property (get, set):*

This property programmatically determines the location of the authentication web service. It can be used to override the default authentication provider, as well as one set declaratively in the Path property of the ScriptManager control's AuthenticationService child node (for more information, see the Using a Custom Authentication Service Provider topic below).

Note that the location of the default authentication service does not change. However, ASP.NET AJAX allows you to specify the location of a web service that provides the same class interface as the ASP.NET AJAX authentication service proxy.

Note also that this property should not be set to a value that directs the script request off of the current site. Because the current application would not receive the authentication credentials, it would be useless; also, the technology underlying AJAX should not post cross-site requests, and may generate a security exception in the client browser.

This property is a `String` object representing the path to the authentication web service.

*timeout property (get, set):*

This property determines the length of time to wait for the authentication service before assuming the login request has failed. If the timeout expires while waiting for a call to complete, the request-failed callback will be called, and the call will not complete.

This property is a `Number` object representing the number of milliseconds to wait for results from the authentication service.

*Code Sample: Logging into the Authentication Service*

The following markup is an example ASP.NET page with a simple script call to the login and logout methods of the AuthenticationService class.

[!code-aspx[Main](understanding-asp-net-ajax-authentication-and-profile-application-services/samples/sample5.aspx)]

## Accessing ASP.NET Profiling Data via AJAX

The ASP.NET profiling service is also exposed through the ASP.NET AJAX Extensions. Since the ASP.NET profiling service provides a rich, granular API by which to store and retrieve user data, this can be an excellent productivity tool.

The profile service must be enabled in web.config; it is not by default. To do so, ensure that the `profileService` child element has enabled= true specified in web.config, and that you have specified which properties can be read or written as follows:

[!code-xml[Main](understanding-asp-net-ajax-authentication-and-profile-application-services/samples/sample6.xml)]

The profile service must also be configured. Although configuration of the profiling service is outside of the scope of this whitepaper, it is worthwhile to note that groups as defined in profile configuration settings will be accessible as sub-properties of the group name. For example, with the following profile section specified:

[!code-xml[Main](understanding-asp-net-ajax-authentication-and-profile-application-services/samples/sample7.xml)]

Client script would be able to access Name, Address.Line1, Address.Line2, Address.City, Address.State, Address.Zip, and BackgroundColor as properties of the properties field of the ProfileService class.

Once the AJAX Profiling Service is configured, it will be immediately available in pages; however, it will have to be loaded once before use.

*Sys.Services.ProfileService members*

*properties field:*

The properties field exposes all configured profile data as child properties that can be referenced by the dot-operator-name convention. Properties that are children of property groups are referred to as GroupName.PropertyName. In the example profile configuration presented above, to get the state of the user, you could use the following identifier:

[!code-csharp[Main](understanding-asp-net-ajax-authentication-and-profile-application-services/samples/sample8.cs)]

*load method:*

Loads a selected list or all properties from the server.

*Parameters:*

| **Parameter Name** | **Meaning** |
| --- | --- |
| propertyNames | Optional (defaults to null). The properties to be loaded from the server. |
| loadCompletedCallback | Optional (defaults to null). The function to call when loading has completed. |
| failedCallback | Optional (defaults to null). The function to call if an error occurs. |
| userContext | Optional (defaults to null). Context information to be passed to the callback function. |

The load function does not have a return value. If the call completed successfully, it will call either the `loadCompletedCallback` parameter or `defaultLoadCompletedCallback` property. If the call failed, or the timeout expired, either the `failedCallback` parameter or `defaultFailedCallback` property will be called.

If the `propertyNames` parameter is not supplied, all read-configured properties are retrieved from the server.

*save method:*

The save() method saves the specified property list (or all properties) to the user's ASP.NET profile.

*Parameters:*

| **Parameter Name** | **Meaning** |
| --- | --- |
| propertyNames | Optional (defaults to null). The properties to be saved to the server. |
| saveCompletedCallback | Optional (defaults to null). The function to call when saving has completed. |
| failedCallback | Optional (defaults to null). The function to call if an error occurs. |
| userContext | Optional (defaults to null). Context information to be passed to the callback function. |

The save function does not have a return value. If the call completes successfully, it will call either the `saveCompletedCallback` parameter or `defaultSaveCompletedCallback` property. If the call failed, or the timeout expired, either the `failedCallback` or `defaultFailedCallback` property will be called.

If the `propertyNames` parameter is null, all profile properties will be sent to the server, and the server will decide which properties can be saved and which cannot.

*defaultFailedCallback property (get, set):*

This property specifies a function that should be called if a failure to communicate with the web service occurs. It should receive a delegate (or function reference).

The function reference specified by this property should have the following signature:

[!code-javascript[Main](understanding-asp-net-ajax-authentication-and-profile-application-services/samples/sample9.js)]

*Parameters:*

| **Parameter Name** | **Meaning** |
| --- | --- |
| Error | Specifies the error information. |
| userContext | Specifies the user context information provided when the load or save function was called. |
| methodName | The name of the calling method. |

*defaultSaveCompleted property (get, set):*

This property specifies a function that should be called upon the completion of saving the user's profile data. It should receive a delegate (or function reference).

The function reference specified by this property should have the following signature:

[!code-javascript[Main](understanding-asp-net-ajax-authentication-and-profile-application-services/samples/sample10.js)]

*Parameters:*

| **Parameter Name** | **Meaning** |
| --- | --- |
| numPropsSaved | Specifies the number of properties that were saved. |
| userContext | Specifies the user context information provided when the load or save function was called. |
| methodName | The name of the calling method. |

*defaultLoadCompleted property (get, set):*

This property specifies a function that should be called upon the completion of loading of the user's profile data. It should receive a delegate (or function reference).

The function reference specified by this property should have the following signature:

[!code-javascript[Main](understanding-asp-net-ajax-authentication-and-profile-application-services/samples/sample11.js)]

*Parameters:*

| **Parameter Name** | **Meaning** |
| --- | --- |
| numPropsLoaded | Specifies the number of properties loaded. |
| userContext | Specifies the user context information provided when the load or save function was called. |
| methodName | The name of the calling method. |

*path property (get, set):*

This property programmatically determines the location of the profile web service. It can be used to override the default profile service provider, as well as one set declaratively in the Path property of the ScriptManager control's ProfileService child node.

Note that the location of the default profile service does not change. However, ASP.NET AJAX allows you to specify the location of a web service that provides the same class interface as the ASP.NET AJAX authentication service proxy.

Note also that this property should not be set to a value that directs the script request off of the current site. The technology underlying AJAX should not post cross-site requests, and may generate a security exception in the client browser.

This property is a `String` object representing the path to the profile web service.

*timeout property (get, set):*

This property determines the length of time to wait for the profile service before assuming the load or save request has failed. If the timeout expires while waiting for a call to complete, the request-failed callback will be called, and the call will not complete.

This property is a `Number` object representing the number of milliseconds to wait for results from the profile service.

*Code sample: Loading profile data at page load*

The following code will check to see whether a user is authenticated, and if so, will load the user's preferred background color as the page's.

[!code-javascript[Main](understanding-asp-net-ajax-authentication-and-profile-application-services/samples/sample12.js)]

## *Using a Custom Authentication Service Provider*

The ASP.NET AJAX Extensions allow you to create a custom script authentication service provider by exposing your functionality through a custom web service. In order to be used, your web service must expose two methods, `Login` and `Logout`; and these methods must be specified with the same method signatures as the default ASP.NET AJAX Authentication web service.

Once you have created the custom web service, you will need to specify the path to it, either declaratively on your page, programmatically in code, or via the client script.

*To set the path declaratively:*

To set the path declaratively, include the AuthenticationService child of the ScriptManager object on your ASP.NET page:

[!code-aspx[Main](understanding-asp-net-ajax-authentication-and-profile-application-services/samples/sample13.aspx)]

*To set the path in code:*

To set the path programmatically, specify the path via the instance of your script manager:

[!code-csharp[Main](understanding-asp-net-ajax-authentication-and-profile-application-services/samples/sample14.cs)]

*To set the path in script:*

To set the path programmatically in script, utilize the `path` property of the AuthenticationService class:

[!code-javascript[Main](understanding-asp-net-ajax-authentication-and-profile-application-services/samples/sample15.js)]

*Sample Web Service for Custom Authentication*

[!code-aspx[Main](understanding-asp-net-ajax-authentication-and-profile-application-services/samples/sample16.aspx)]

## Summary

ASP.NET services - specifically the profiling, membership, and authentication services - are easily exposed to JavaScript on the client browser. This allows developers to integrate their client-side code with the authentication mechanism seamlessly, without depending on controls such as UpdatePanels to do the heavy lifting. Profile data can be protected from the client as well, by utilizing web configuration settings; no data is available by default, and developers must opt-in to profile properties.

Furthermore, by creating simplified web service implementations with equivalent method signatures, developers can create custom script providers for these intrinsic ASP.NET services. Support for these techniques simplifies the development of rich client applications, while providing developers with a wide range of flexibility to meet specific needs.

## *Bio*

Scott Cate has been working with Microsoft Web technologies since 1997 and is the President of myKB.com ([www.myKB.com](http://www.myKB.com)) where he specializes in writing ASP.NET based applications focused on Knowledge Base Software solutions. Scott can be contacted via email at [scott.cate@myKB.com](mailto:scott.cate@myKB.com) or his blog at [ScottCate.com](http://ScottCate.com)

>[!div class="step-by-step"]
[Previous](understanding-asp-net-ajax-updatepanel-triggers.md)
[Next](understanding-asp-net-ajax-localization.md)