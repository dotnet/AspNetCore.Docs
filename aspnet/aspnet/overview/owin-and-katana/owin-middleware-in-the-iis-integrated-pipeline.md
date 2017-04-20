---
uid: aspnet/overview/owin-and-katana/owin-middleware-in-the-iis-integrated-pipeline
title: "OWIN Middleware in the IIS integrated pipeline | Microsoft Docs"
author: Praburaj
description: "This article shows how to run OWIN middleware Components (OMCs) in the IIS integrated pipeline, and how to set the pipeline event an OMC runs on. You should..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 11/07/2013
ms.topic: article
ms.assetid: d031c021-33c2-45a5-bf9f-98f8fa78c2ab
ms.technology: 
ms.prod: .net-framework
msc.legacyurl: /aspnet/overview/owin-and-katana/owin-middleware-in-the-iis-integrated-pipeline
msc.type: authoredcontent
---
OWIN Middleware in the IIS integrated pipeline
====================
by [Praburaj Thiagarajan](https://github.com/Praburaj), [Rick Anderson](https://github.com/Rick-Anderson)

> This article shows how to run OWIN middleware Components (OMCs) in the IIS integrated pipeline, and how to set the pipeline event an OMC runs on. You should review [An Overview of Project Katana](an-overview-of-project-katana.md) and [OWIN Startup Class Detection](owin-startup-class-detection.md) before reading this tutorial. This tutorial was written by Rick Anderson ( [@RickAndMSFT](https://twitter.com/#!/RickAndMSFT) ), Chris Ross, Praburaj Thiagarajan, and Howard Dierking ( [@howard\_dierking](https://twitter.com/howard_dierking) ).


Although [OWIN](an-overview-of-project-katana.md) middleware components (OMCs) are primarily designed to run in a server-agnostic pipeline, it is possible to run an OMC in the IIS integrated pipeline as well well (**classic mode is *not* supported**). An OMC can be made to work in the IIS integrated pipeline by installing the following package from the Package Manager Console (PMC):

[!code-console[Main](owin-middleware-in-the-iis-integrated-pipeline/samples/sample1.cmd)]

This means that all application frameworks, even those that are not yet able to run outside of IIS and System.Web, can benefit from existing OWIN middleware components. 

> [!NOTE]
> All of the `Microsoft.Owin.Security.*` packages shipping with the new Identity System in Visual Studio 2013 (for example: Cookies, Microsoft Account, Google, Facebook, Twitter, [Bearer Token](http://self-issued.info/docs/draft-ietf-oauth-v2-bearer.html), OAuth, Authorization server, JWT, Azure Active directory, and Active directory federation services) are authored as OMCs, and can be used in both self-hosted and IIS-hosted scenarios.

## How OWIN Middleware Executes in the IIS Integrated Pipeline

For OWIN console applications, the application pipeline built using the [startup configuration](owin-startup-class-detection.md) is set by the order the components are added using the `IAppBuilder.Use` method. That is, the OWIN pipeline in the [Katana](an-overview-of-project-katana.md) runtime will process OMCs in the order they were registered using `IAppBuilder.Use`. In the IIS integrated pipeline the request pipeline consists of [HttpModules](https://msdn.microsoft.com/en-us/library/ms178468(v=vs.85).aspx) subscribed to a pre-defined set of the pipeline events such as [BeginRequest](https://msdn.microsoft.com/en-us/library/system.web.httpapplication.beginrequest.aspx), [AuthenticateRequest](https://msdn.microsoft.com/en-us/library/system.web.httpapplication.authenticaterequest.aspx), [AuthorizeRequest](https://msdn.microsoft.com/en-us/library/system.web.httpapplication.authorizerequest.aspx), etc.

If we compare an OMC to that of an [HttpModule](https://msdn.microsoft.com/en-us/library/zec9k340(v=vs.85).aspx) in the ASP.NET world, an OMC must be registered to the correct pre-defined pipeline event. For example, the HttpModule `MyModule` will get invoked when a request comes to the [AuthenticateRequest](https://msdn.microsoft.com/en-us/library/system.web.httpapplication.authenticaterequest.aspx) stage in the pipeline:

[!code-csharp[Main](owin-middleware-in-the-iis-integrated-pipeline/samples/sample2.cs?highlight=10)]

In order for an OMC to participate in this same, event-based execution ordering, the [Katana](an-overview-of-project-katana.md) runtime code scans through the [startup configuration](owin-startup-class-detection.md) and subscribes each of the middleware components to an integrated pipeline event. For example, the following OMC and registration code enables you to see the default event registration of middleware components. (For more detailed instructions on creating an OWIN startup class, see [OWIN Startup Class Detection](owin-startup-class-detection.md).)

1. Create an empty web application project and name it **owin2**.
2. From the Package Manager Console (PMC), run the following command: 

    [!code-console[Main](owin-middleware-in-the-iis-integrated-pipeline/samples/sample3.cmd)]
3. Add an `OWIN Startup Class` and name it `Startup`. Replace the generated code with the following (the changes are highlighted):  

    [!code-csharp[Main](owin-middleware-in-the-iis-integrated-pipeline/samples/sample4.cs?highlight=5-7,15-36)]
4. Hit F5 to run the app.

The Startup configuration sets up a pipeline with three middleware components, the first two displaying diagnostic information and the last one responding to events (and also displaying diagnostic information). The `PrintCurrentIntegratedPipelineStage` method displays the integrated pipeline event this middleware is invoked on and a message. The output windows displays the following:

[!code-console[Main](owin-middleware-in-the-iis-integrated-pipeline/samples/sample5.cmd)]

The Katana runtime mapped each of the OWIN middleware components to [PreExecuteRequestHandler](https://msdn.microsoft.com/en-us/library/system.web.httpapplication.prerequesthandlerexecute.aspx) by default, which corresponds to the IIS pipeline event [PreRequestHandlerExecute](https://msdn.microsoft.com/en-us/library/system.web.httpapplication.prerequesthandlerexecute.aspx).

## Stage Markers

You can mark OMCs to execute at specific stages of the pipeline by using the `IAppBuilder UseStageMarker()` extension method. To run a set of middleware components during a particular stage, insert a stage marker right after the last component is the set during registration. There are rules on which stage of the pipeline you can execute middleware and the order components must run (The rules are explained later in the tutorial). Add the `UseStageMarker` method to the `Configuration` code as shown below:

[!code-csharp[Main](owin-middleware-in-the-iis-integrated-pipeline/samples/sample6.cs?highlight=13,19)]

The `app.UseStageMarker(PipelineStage.Authenticate)` call configures all the previously registered middleware components (in this case, our two diagnostic components) to run on the authentication stage of the pipeline. The last middleware component (which displays diagnostics and responds to requests) will run on the `ResolveCache` stage (the [ResolveRequestCache](https://msdn.microsoft.com/en-us/library/system.web.httpapplication.resolverequestcache.aspx) event).

Hit F5 to run the app.The output window shows the following:

[!code-console[Main](owin-middleware-in-the-iis-integrated-pipeline/samples/sample7.cmd)]

## Stage Marker Rules

Owin middleware components (OMC) can be configured to run at the following OWIN pipeline stage events:

[!code-csharp[Main](owin-middleware-in-the-iis-integrated-pipeline/samples/sample8.cs)]

1. By default, OMCs run at the last event (`PreHandlerExecute`). That's why our first example code displayed "PreExecuteRequestHandler".
2. You can use the a `pp.UseStageMarker` method to register a OMC to run earlier, at any stage of the OWIN pipeline listed in the `PipelineStage` enum.
3. The OWIN pipeline and the IIS pipeline is ordered, therefore calls to `app.UseStageMarker` must be in order. You cannot set the event handler to an event that precedes the last event registered with to `app.UseStageMarker`. For example, *after* calling:

    [!code-console[Main](owin-middleware-in-the-iis-integrated-pipeline/samples/sample9.cmd)]

 calls to `app.UseStageMarker` passing `Authenticate` or `PostAuthenticate` will not be honored, and no exception will be thrown. OMCs run at the latest stage, which by default is `PreHandlerExecute`. The stage markers are used to make them to run earlier. If you specify stage markers out of order, we round to the earlier marker. In other words, adding a stage marker says "Run no later than stage X". OMC's run at the earliest stage marker added after them in the OWIN pipeline.
4. The earliest stage of calls to `app.UseStageMarker` wins. For example, if you switch the order of `app.UseStageMarker` calls from our previous example:

    [!code-csharp[Main](owin-middleware-in-the-iis-integrated-pipeline/samples/sample10.cs?highlight=13,19)]

 The output window will display: 

    [!code-console[Main](owin-middleware-in-the-iis-integrated-pipeline/samples/sample11.cmd)]

 The OMCs all run in the `AuthenticateRequest` stage, because the last OMC registered with the `Authenticate` event, and the `Authenticate` event precedes all other events.