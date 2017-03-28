---
uid: web-api/overview/releases/whats-new-in-aspnet-web-api-22
title: "What's New in ASP.NET Web API 2.2 | Microsoft Docs"
author: microsoft
description: ""
ms.author: aspnetcontent
manager: wpickett
ms.date: 12/25/2014
ms.topic: article
ms.assetid: 99c59ae4-167e-4f66-a6cd-d3f1098c4e4a
ms.technology: dotnet-webapi
ms.prod: .net-framework
msc.legacyurl: /web-api/overview/releases/whats-new-in-aspnet-web-api-22
msc.type: authoredcontent
---
What's New in ASP.NET Web API 2.2
====================
by [Microsoft](https://github.com/microsoft)

This topic describes what's new for ASP.NET Web API 2.2.

- [Download](#download)
- [Documentation](#documentation)
- [New Features in ASP.NET Web API 2.2](#newf)

    - [OData v4](#OData)
    - [Attribute Routing Improvements](#ARI)
    - [Web API Client support for Windows Phone 8.1](#phone)
- [Known Issues and Breaking Changes](#known-issues)
- [Bug Fixes](#bug-fixes)
- [Microsoft.AspNet.OData 5.2.1](#odata521)
- [Microsoft.AspNet.WebAPI 5.2.2](#522RC)
- [Microsoft.AspNet.WebAPI 5.2.3 Beta](#523)

<a id="download"></a>
## Download

The runtime features are released as NuGet packages on the NuGet gallery. All the runtime packages follow the [Semantic Versioning](http://semver.org/) specification. The latest ASP.NET Web API 2.2 package has the following version: "5.2.0". You can install or update these packages through [NuGet](http://www.nuget.org/packages/Microsoft.AspNet.WebApi/). The release also includes corresponding localized packages on NuGet.

You can install or update to the released NuGet packages by using the NuGet Package Manager Console:

[!code-console[Main](whats-new-in-aspnet-web-api-22/samples/sample1.cmd)]

<a id="documentation"></a>
## Documentation

Tutorials and other information about ASP.NET Web API 2.2 are available from the ASP.NET web site ([https://www.asp.net/web-api](../../index.md)).

<a id="newf"></a>
## New Features in ASP.NET Web API 2.2

<a id="OData"></a>
### OData v4

This release adds support for the OData v4 protocol. For more information, see the [Web API OData v4 documentation.](../odata-support-in-aspnet-web-api/odata-v4/create-an-odata-v4-endpoint.md)

Here are some of the key features and changes for OData v4:

- [Support for aliasing properties in OData model](http://aspnet.codeplex.com/SourceControl/latest#Samples/WebApi/OData/v4/ODataModelAliasingSample/)
- [Support for ComplexTypeAttribute, AssociationAttribute, TimesTampAttribute and ConcurrencyCheckAttribute in ODataConventionModelBuilder](http://aspnet.codeplex.com/SourceControl/latest#Samples/WebApi/OData/v4/ODataEtagSample/)
- [Provide ability to supply friendly Title for actions](http://aspnet.codeplex.com/SourceControl/latest#Samples/WebApi/OData/v4/ODataActionsSample/)
- Integrate with ODL UriParser
- Support for [enum](http://aspnet.codeplex.com/SourceControl/latest#Samples/WebApi/OData/v4/ODataEnumTypeSample/ODataEnumTypeSample/), [containment](http://aspnet.codeplex.com/SourceControl/latest#Samples/WebApi/OData/v4/ODataContainmentSample/) and [singleton](http://aspnet.codeplex.com/SourceControl/latest#Samples/WebApi/OData/v4/ODataSingletonSample/)
- Support cast for primitive types
- [Added OData function support](http://aspnet.codeplex.com/SourceControl/latest#Samples/WebApi/OData/v4/ODataFunctionSample/)
- [Support parameter aliases for function calls](http://aspnet.codeplex.com/SourceControl/latest#Samples/WebApi/OData/v4/ODataFunctionSample/)
- [Support camel case naming convention in model](http://aspnet.codeplex.com/SourceControl/latest#Samples/WebApi/OData/v4/ODataCamelCaseSample/)
- Support for cast() in $filter
- Support for open complex type
- Removed EntitySetController and AsyncEntitySetController
- [Changed $link to $ref](http://aspnet.codeplex.com/SourceControl/latest#Samples/WebApi/OData/v4/ODataServiceSample/)
- [Added Attribute routing support](https://aspnet.codeplex.com/SourceControl/latest#Samples/WebApi/OData/v4/ODataAttributeRoutingSample/)
- Uses OData Core Libraries 6.4.0

<a id="ARI"></a>
### Attribute Routing Improvements

Attribute Routing now provides an extensibility point called IDirectRouteProvider, which allows full control over how attribute routes are discovered and configured. An IDirectRouteProvider is responsible for providing a list of actions and controllers along with associated route information to specify exactly what routing configuration is desired for those actions. An IDirectRouteProvider implementation may be specified when calling MapAttributes/MapHttpAttributeRoutes.

Customizing IDirectRouteProvider will be easiest by extending our default implementation, DefaultDirectRouteProvider. This class provides separate overridable virtual methods to change the logic for discovering attributes, creating route entries, and discovering route prefix and area prefix.

Following are some examples on what you could do with this new extensibility point:

1. Support inheritance of Route attributes

    Example:

    Here a request like "/api/values/10" would successfully return "Success:10"

    [!code-csharp[Main](whats-new-in-aspnet-web-api-22/samples/sample2.cs)]
2. Provide a default route name for your attribute routes by following some convention you like. By default, attribute routing doesn't automatically create names for attribute routes.
3. Modify attribute routes' route template at one central place before they end up in the route table.

<a id="phone"></a>
### Web API Client Support for Windows Phone 8.1

You can now use the Web API Client NuGet package to implement your Web API client logic when targeting Windows Phone 8.1 or from within a Universal App.

<a id="known-issues"></a>
## Known Issues and Breaking Changes

This section describes known issues and breaking changes in the ASP.NET Web API 2.2.

### OData v4

#### Model builder

Issue: Overloaded Functions could not be exposed as FunctionImport

If there are 2 overloaded functions and they are also FunctionImport as shown below then requesting ~/GetAllConventionCustomers(CustomerName={customerName}) results in System.InvalidOperationException.

[!code-xml[Main](whats-new-in-aspnet-web-api-22/samples/sample3.xml)]

Workaround: The workaround for this issue is to add both the function overloads as FunctionImports.

#### OData Routing

String literals that include the URL encoded slash (%2F), and backslash(%5C) cause a 404 error when they are used in the OData resource paths.

For example, string literals can be used in the OData resource paths as parameters of functions or key values of entity sets.

/Employees/Total.GetCount(Name='Name%2F')

/Employees('Name%5C')

When services receive such requests the hosts will un-escape those escape sequences before passing them to the Web API runtime. This protects against attacks like the following:  
  
 http://www.contoso.com/..%2F..%2F/Windows/System32/cmd.exe?/c+dir+c:

This causes the Web API OData stack to return a 404 error (Not Found). To prevent this error, your client should use the double escape sequences for slash (%252F) and backslash (%255C). This does not happen for query strings such as /Employees?$filter=Name eq 'Name%2F'

**Note un-escaped slashes ('/') and backslashes ('') are not legal in OData resource path string literals. Slashes should appear only as path separators and backslashes should not appear in the OData resource path at all. (Both are usable in some portions of an OData query string.)**

Workaround: You could override the Parse method of DefaultODataPathHandler to escape the slash and backslash in string literals before actually parsing them. You can find a sample of this approach here.

### OData v3

#### [Queryable]

The [Queryable] attribute is deprecated. New OData v3 applications should use **System.Web.Http.OData.EnableQueryAttribute**.

The **ODataHttpConfigurationExtensions.EnableQuerySupport** extension method now adds an **EnableQueryAttribute** to the global filter collection. If any controllers have the **[Queryable]** attribute, calling `config.EnableQuerySupport()` will cause the **[Queryable]** attribute to fail

The recommended way to resolve this issue is to replace all instances of **QueryableAttribute** with **System.Web.Http.OData.EnableQueryAttribute**.

An alternative workaround is to use the following code in your Web API configuration:

[!code-csharp[Main](whats-new-in-aspnet-web-api-22/samples/sample4.cs)]

### Attribute Routing

Issue: Model binding of complex type which is decorated with FromUri attribute behaves differently when using Attribute Routing.

Following link is tracking the issue and also has details about a workaround.  
[http://aspnetwebstack.codeplex.com/workitem/1944](http://aspnetwebstack.codeplex.com/workitem/1944)

Issue: Scaffolding MVC/Web API into a project with 5.2.0 packages results in 5.1.2 packages for ones that don't already exist in the project

Updating NuGet packages for ASP.NET MVC 5.2 does not update the Visual Studio tools such as ASP.NET scaffolding or the ASP.NET Web Application project template. They use the previous version of the ASP.NET runtime packages (e.g. 5.1.2 in Update 2). As a result, the ASP.NET scaffolding will install the previous version (e.g. 5.1.2 in Update 2) of the required packages, if they are not already available in your projects. However, the ASP.NET scaffolding in Visual Studio 2013 RTM or Update 1 does not overwrite the latest packages in your projects. If you use ASP.NET scaffolding after updating the packages of your projects to Web API 2.2 or ASP.NET MVC 5.2, make sure the versions of Web API and ASP.NET MVC are consistent.

<a id="bug-fixes"></a>
## Bug Fixes and Minor Feature Updates

This release also includes several bug fixes and minor feature updates. You can find the complete list here:

- [5.2 package](https://aspnetwebstack.codeplex.com/workitem/list/advanced?keyword=&status=All&type=All&priority=All&release=v5.2%20RC|v5.2%20RTM&assignedTo=All&component=Web%20API|Web%20API%20OData&sortField=AssignedTo&sortDirection=Ascending&page=0&reasonClosed=Fixed)

<a id="odata521"></a>
## Microsoft.AspNet.OData 5.2.1

The Microsoft.AspNet.OData 5.2.1 package contains NuGet dependency updates but no bug fixes. With this update, there is no longer a strict dependency on Microsoft.OData.Core 6.4.0, but one can upgrade to any version between 6.4.0 and 7.0.0.

<a id="522RC"></a>
## Microsoft.AspNet.WebAPI 5.2.2

In this release we have made a dependency change for `Json.Net 6.0.4`. For more information on what is new in this release of `Json.NET`, see [Json.NET 6.0 Release 4 - JSON Merge, Dependency Injection](http://james.newtonking.com/archive/2014/08/04/json-net-6-0-release-4-json-merge-dependency-injection). This release doesn't have any other new features or bug fixes in Web API. We have subsequently updated all other dependent packages we own to depend on this new version of Web API.

<a id="523"></a>
## Microsoft.AspNet.WebAPI 5.2.3 Beta

You can read about the release [here](https://blogs.msdn.com/b/webdev/archive/2014/12/17/asp-net-mvc-5-2-3-web-pages-5-2-3-and-web-api-5-2-3-beta-releases.aspx). This release contains only bug fixes. You can use [this query](https://aspnetwebstack.codeplex.com/workitem/list/advanced?keyword=&amp;status=Closed&amp;type=All&amp;priority=All&amp;release=v5.2.3%20Beta&amp;assignedTo=All&amp;component=Web%20API&amp;sortField=LastUpdatedDate&amp;sortDirection=Descending&amp;page=0&amp;reasonClosed=Fixed) to see the list of issues fixed in this release.