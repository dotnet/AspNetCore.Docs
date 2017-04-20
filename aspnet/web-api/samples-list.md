---
uid: web-api/samples-list
title: "Web API Samples List | Microsoft Docs"
author: rick-anderson
description: ""
ms.author: aspnetcontent
manager: wpickett
ms.date: 09/18/2012
ms.topic: article
ms.assetid: 8cbd9d7f-7027-4390-b098-cb81a63ecd6f
ms.technology: dotnet-webapi
ms.prod: .net-framework
msc.legacyurl: /web-api/samples-list
msc.type: content
---
Web API Samples List
====================
## HttpClient Samples

**Bing Translate Sample** | [VS 2012 source](http://aspnet.codeplex.com/SourceControl/changeset/view/15dfe7e0759f#Samples%2fNet45%2fCS%2fHttpClient%2fBingTranslateSample%2fReadMe.txt)

Shows how to call the [Microsoft Translator service](https://msdn.microsoft.com/en-us/library/ff512419.aspx) using the **HttpClient** class. The Microsoft Translator service API requires an OAuth token, which the application obtains by sending a request to the Azure token server for each request to the translator service. The result from the token server is fed into the request sent to the translation service. Before running this sample, you must obtain an [application key from Azure Marketplace](https://msdn.microsoft.com/en-us/library/hh454950.aspx) and fill in the information in the AccessTokenMessageHandler sample class.

**Google Maps Sample** | [detailed description](https://blogs.msdn.com/b/henrikn/archive/2012/02/17/downloading-a-google-map-to-local-file.aspx) | [VS 2012 source](http://aspnet.codeplex.com/SourceControl/changeset/view/15dfe7e0759f#Samples%2fNet45%2fCS%2fHttpClient%2fGoogleMapsSample%2fReadMe.txt)

Uses **HttpClient** to download a map of Redmond, WA from [Google Maps API](https://developers.google.com/maps/), saves it as a local file, and opens the default image viewer.

**Twitter Client Sample** | [detailed description](https://blogs.msdn.com/b/henrikn/archive/2012/02/16/extending-httpclient-with-oauth-to-access-twitter.aspx) | [VS 2012 source](http://aspnet.codeplex.com/SourceControl/changeset/view/15dfe7e0759f#Samples%2fNet45%2fCS%2fHttpClient%2fTwitterSample%2fReadMe.txt)

Shows how to write a simple Twitter client using **HttpClient**. The sample uses an **HttpMessageHandler** to insert OAuth authentication information into the outgoing **HttpRequestMessage**. The result from Twitter is read using JSON.NET. Before running this sample, you must obtain an [application key from Twitter](https://dev.twitter.com/), and fill in the information in the OAuthMessageHandler sample class.

**World Bank Sample** | [detailed description](https://blogs.msdn.com/b/henrikn/archive/2012/02/16/httpclient-is-here.aspx) | [VS 2010 source](http://aspnet.codeplex.com/SourceControl/changeset/view/15dfe7e0759f#Samples%2fNet4%2fCS%2fHttpClient%2fWorldBankSample%2fReadMe.txt) | [VS 2012 source](http://aspnet.codeplex.com/SourceControl/changeset/view/15dfe7e0759f#Samples%2fNet45%2fCS%2fHttpClient%2fWorldBankSample%2fReadMe.txt)

Shows how to retrieve data from the World Bank data site, using JSON.NET to parse the result.

## Web API Samples

**Getting Started with ASP.NET Web API** | [VS 2012 source](overview/getting-started-with-aspnet-web-api/tutorial-your-first-web-api.md)

Shows how to create a basic web API that supports HTTP GET requests. Contains the source code for the tutorial [Your First ASP.NET Web API](overview/getting-started-with-aspnet-web-api/tutorial-your-first-web-api.md).

**ASP.NET Web API JavaScript Scenarios – Comments** | [VS 2012 source](https://code.msdn.microsoft.com/ASPNET-Web-API-JavaScript-d0d64dd7)

Shows how to use ASP.NET Web API to build web APIs that support browser clients and can be easily called using jQuery.

**Contact Manager** | [VS 2010 source](https://code.msdn.microsoft.com/Contact-Manager-Web-API-0e8e373d)

This sample uses ASP.NET Web API to build a simple contact manager application. The application consists of a contact manager web API that is used by an ASP.NET MVC application and a Windows Phone application to display and manage a list of contacts.

**Batching Sample** | [detailed description](http://trocolate.wordpress.com/2012/07/19/mitigate-issue-260-in-batching-scenario/) | [VS 2012 source](http://aspnet.codeplex.com/SourceControl/changeset/view/15dfe7e0759f#Samples%2fNet45%2fCS%2fWebApi%2fHostedBatchSample%2fReadMe.txt)

Shows how to implement HTTP batching within ASP.NET. The batching consists of putting multiple HTTP requests within a single MIME multipart entity body, which is then sent to the server as an HTTP POST. The requests are processed individually, and the responses are put into another MIME multipart entity body, which is returned to the client.

**Content Controller Sample** | [detailed description](https://blogs.msdn.com/b/henrikn/archive/2012/02/24/async-actions-in-asp-net-web-api.aspx) | [VS 2010 source](http://aspnet.codeplex.com/SourceControl/changeset/view/15dfe7e0759f#Samples%2fNet4%2fCS%2fWebApi%2fContentControllerSample%2fReadMe.txt) | [VS 2012 source](http://aspnet.codeplex.com/SourceControl/changeset/view/15dfe7e0759f#Samples%2fNet45%2fCS%2fWebApi%2fContentControllerSample%2fReadMe.txt)

Shows how to read and write request and response entities asynchronously using streams. The sample controller has two actions: a PUT action that reads the request entity body asynchronously and stores it in a local file, and a GET action that returns the contents of the local file.

**Custom Assembly Resolver Sample** | [VS 2012 source](http://aspnet.codeplex.com/SourceControl/changeset/view/15dfe7e0759f#Samples%2fNet45%2fCS%2fWebApi%2fCustomAssemblyResolverSample%2fReadMe.txt)

Shows how to modify ASP.NET Web API to support discovery of controllers from a dynamically loaded library assembly. The sample implements a custom **IAssembliesResolver** which calls the default implementation and then adds the library assembly to the default results.

**Custom Media Type Formatter Sample** | [detailed description](https://blogs.msdn.com/b/henrikn/archive/2012/04/23/using-cookies-with-asp-net-web-api.aspx) | [VS 2010 source](http://aspnet.codeplex.com/SourceControl/changeset/view/15dfe7e0759f#Samples%2fNet4%2fCS%2fWebApi%2fCustomMediaTypeFormatterSample%2fReadMe.txt)

Shows how to create a custom media type formatter using the **BufferedMediaTypeFormatter** base class. This base class is intended for formatters which primarily use synchronous read and write operations. In addition to showing the media type formatter, the sample shows how to hook it up by registering it as part of the **HttpConfiguration** for your application. Note that it is also possible to use the **MediaTypeFormatter** base class directly, for formatters which primarily use asynchronous read and write operations.

**Custom Parameter Binding Sample** | [detailed description](https://blogs.msdn.com/b/jmstall/archive/2012/05/11/webapi-parameter-binding-under-the-hood.aspx) | [VS 2010 source](http://aspnet.codeplex.com/SourceControl/changeset/view/15dfe7e0759f#Samples%2fNet4%2fCS%2fWebApi%2fCustomParameterBinding%2fReadMe.txt)

Shows how to customize the parameter binding process, which is the process that determines how information from a request is bound to action parameters. In this sample, the Home controller has four actions:

1. BindPrincipal shows how to bind an IPrincipal parameter from a custom generic principal, not from an HTTP GET message;
2. BindCustomComplexTypeFromUriOrBody shows how to bind a complex-type parameter, which could come either from the message body or from the request URI of an HTTP POST message;
3. BindCustomComplexTypeFromUriWithRenamedProperty shows how to bind a complex-type parameter with a renamed property which comes from the request URI of an HTTP POST message;
4. PostMultipleParametersFromBody shows how to bind multiple parameters from the body for a POST message;

**File Upload Sample** | [detailed description](https://blogs.msdn.com/b/henrikn/archive/2012/03/01/file-upload-and-asp-net-web-api.aspx) | [VS 2012 source](http://aspnet.codeplex.com/SourceControl/changeset/view/15dfe7e0759f#Samples%2fNet45%2fCS%2fWebApi%2fFileUploadSample%2fReadMe.txt)

Shows how to upload files to an **ApiController** using MIME Multipart File Upload, and how to set up progress notifications with **HttpClient** using **ProgressNotificationHandler**. The controller reads the contents of an HTML file upload asynchronously and writes one or more body parts to a local file. The response contains information about the uploaded file (or files).

**File Upload to Azure Blob Store Sample** | [detailed description](https://blogs.msdn.com/b/yaohuang1/archive/2012/07/02/asp-net-web-api-and-azure-blob-storage.aspx) | [VS 2012 source](http://aspnet.codeplex.com/SourceControl/changeset/view/61dfed023e50#Samples%2fNet45%2fCS%2fWebApi%2fAzureBlobsFileUploadSample%2fReadMe.txt)

This sample is similar to the File Upload Sample, but instead of saving the uploaded files on local disk, it asynchronously uploads the files to [Azure Blob Store](https://www.windowsazure.com/en-us/develop/net/how-to-guides/blob-storage/) using [Windows Azure SDK for .NET](https://www.windowsazure.com/en-us/develop/net/). It also provides a mechanism for listing the blobs currently present in an [Azure Blob Storage Container](https://www.windowsazure.com/en-us/develop/net/how-to-guides/blob-storage/). You can try out the sample running against **Azure Storage Emulator** that comes with the Azure SDK. If you have an [Azure Storage Account](https://www.windowsazure.com/en-us/develop/net/how-to-guides/blob-storage/), you can run against the real storage service as well.

**Http Message Handler Pipeline Sample** | [detailed description](https://blogs.msdn.com/b/henrikn/archive/2012/08/07/httpclient-httpclienthandler-and-httpwebrequesthandler.aspx) | [VS 2010 source](http://aspnet.codeplex.com/SourceControl/changeset/view/15dfe7e0759f#Samples%2fNet4%2fCS%2fWebApi%2fHttpMessageHandlerPipelineSample%2fReadMe.txt)

Shows how to wire up **HttpMessageHandler** instances on both the client (**HttpClient**) and server (ASP.NET Web API). In the sample, the same handler is used on both the client and server. While it is rare that the exact same handler would run in both places, the object model is the same on client and server side.

**JSON Upload Sample** | [VS 2012 source](http://aspnet.codeplex.com/SourceControl/changeset/view/15dfe7e0759f#Samples%2fNet45%2fCS%2fWebApi%2fJsonUploadSample%2fReadMe.txt)

Shows how to upload and download JSON to and from an **ApiController**. The sample uses a minimal **ApiController** and accesses it using **HttpClient**.

**Mashup Sample** | [detailed description](https://blogs.msdn.com/b/henrikn/archive/2012/03/03/async-mashups-using-asp-net-web-api.aspx) | [VS 2012 source](http://aspnet.codeplex.com/SourceControl/changeset/view/15dfe7e0759f#Samples%2fNet45%2fCS%2fWebApi%2fMashupSample%2fReadMe.txt)

Shows how to access multiple remote sites asynchronously from within an **ApiController** action. Each time the action is hit, the requests are performed asynchronously, so that no threads are blocked.

**Memory Tracing Sample** | [detailed description](https://blogs.msdn.com/b/roncain/archive/2012/04/12/tracing-in-asp-net-web-api.aspx) | [VS 2010 source](http://aspnet.codeplex.com/SourceControl/changeset/view/15dfe7e0759f#Samples%2fNet4%2fCS%2fWebApi%2fMemoryTracingSample%2fReadMe.txt)

This sample project creates a Nuget package that will install a custom in-memory trace writer into ASP.NET Web API applications.

**MongoDB Sample** | [detailed description](https://blogs.msdn.com/b/henrikn/archive/2012/02/19/using-web-api-with-mongodb.aspx) | [VS 2012 source](http://aspnet.codeplex.com/SourceControl/changeset/view/15dfe7e0759f#Samples%2fNet45%2fCS%2fWebApi%2fMongoSample%2fReadMe.txt)

Shows how to use MongoDB as the persistent store for an **ApiController**, using a repository pattern.

**Response Body Processor Sample** | [VS 2012 source](http://aspnet.codeplex.com/SourceControl/changeset/view/15dfe7e0759f#Samples%2fNet45%2fCS%2fWebApi%2fResponseEntityProcessorSample%2fReadMe.txt)

Shows how to copy a response entity (that is, an HTTP response body) to a local file before it is transmitted to the client, and perform additional processing on that file asynchronously. The sample implements an **HttpMessageHandler** that wraps the response entity with one that both writes itself to the output as normal and to a local file.

**Upload XDocument Sample** | [detailed description](https://blogs.msdn.com/b/henrikn/archive/2012/02/17/push-and-pull-streams-using-httpclient.aspx) | [VS 2012 source](http://aspnet.codeplex.com/SourceControl/changeset/view/15dfe7e0759f#Samples%2fNet45%2fCS%2fWebApi%2fUploadXDocumentSample%2fReadMe.txt)

Shows how to upload an XDocument to an **ApiController** using **PushStreamContent** and **HttpClient**.

**Validation Sample** | [VS 2010 source](http://aspnet.codeplex.com/SourceControl/changeset/view/15dfe7e0759f#Samples%2fNet4%2fCS%2fWebApi%2fValidationSample%2fReadMe.txt)

Shows how you can use validation attributes on your models in ASP.NET WebAPI to validate the contents of the HTTP request. Demonstrates how to mark properties as required, how to use both framework-defined and custom validation attributes to annotate your model, and how to return error responses for invalid model states.

**Web Form Sample** | [detailed description](https://blogs.msdn.com/b/henrikn/archive/2012/02/23/using-asp-net-web-api-with-asp-net-web-forms.aspx) | [VS 2010 source](http://aspnet.codeplex.com/SourceControl/changeset/view/15dfe7e0759f#Samples%2fNet4%2fCS%2fWebApi%2fWebFormSample%2fReadMe.txt)

Shows an ApiController added to a Web Forms project.

**[RestBugs Sample](https://github.com/howarddierking/RestBugs)**

RestBugs is a simple bug tracking application that shows how to use ASP.NET Web API and the new HTTP Client library to create a hypermedia-driven system. The sample includes both client and server implementations, using ASP.NET Web API. The server uses a custom Razor formatter to generate resource representations. The sample also provides a node.js server to illustrate the benefits that come from using a hypermedia design to decouple clients and servers.

## Web API Extensions Preview Samples

**OData Queryable Sample** | [detailed description](https://blogs.msdn.com/b/alexj/archive/2012/08/15/odata-support-in-asp-net-web-api.aspx) | [VS 2010 source](http://aspnet.codeplex.com/SourceControl/changeset/view/15dfe7e0759f#Samples%2fNet4%2fCS%2fWebApi%2fODataQueryableSample%2fReadMe.txt)

Shows how to introduce OData queries in ASP.NET Web API using either the `[Queryable]` attribute or by using the **ODataQueryOptions** action parameter which allows the action to manually inspect the query before it is being executed.

The CustomerController shows using [Queryable] attribute and the OrderController shows how to use the ODataQueryOptions parameter. The ResponseController is similar to the CustomerController but instead of the GET action returning `IEnumerable<Customer>` it returns an **HttpResponseMessage**. This allows us to add extra header fields, manipulate the status code, etc. while still using query functionality. The sample illustrates queries using $orderby, $skip, $top, any(), all(), and $filter.

**OData Service Sample** | [detailed description](https://blogs.msdn.com/b/alexj/archive/2012/08/15/odata-support-in-asp-net-web-api.aspx) | [VS 2010 source](http://aspnet.codeplex.com/SourceControl/changeset/view/15dfe7e0759f#Samples%2fNet4%2fCS%2fWebApi%2fODataServiceSample%2fReadMe.txt)

This sample illustrates how to create an OData service consisting of three entities and three Web API controllers. The controllers provide various levels of functionality in terms of the OData functionality they expose:

The SupplierController exposes a subset of functionality including Query, Get by Key and Create, by handling these requests:

- GET /Suppliers
- GET /Suppliers(key)
- GET /Suppliers?$filter=..&amp;$orderby=..&amp;$top=..&amp;$skip=..
- POST /Suppliers

The ProductsController exposes GET, PUT, POST, DELETE, and PATCH by implementing an action for each of these operations directly.

The ProductFamilesController leverages the EntitySetController base class which exposes a useful pattern for implementing a rich OData service.

In addition the OData service exposes a $metadata document which allows the data to the consumed by WCF Data Service clients and other clients that accept the $metadata format.