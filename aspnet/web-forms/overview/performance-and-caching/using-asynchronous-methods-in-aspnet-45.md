---
uid: web-forms/overview/performance-and-caching/using-asynchronous-methods-in-aspnet-45
title: "Using Asynchronous Methods in ASP.NET 4.5 | Microsoft Docs"
author: Rick-Anderson
description: "This tutorial will teach you the basics of building an asynchronous ASP.NET Web Forms application using Visual Studio Express 2012 for Web, which is a free..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 06/06/2012
ms.topic: article
ms.assetid: a585c9a2-7c8e-478b-9706-90f3739c50d1
ms.technology: dotnet-webforms
ms.prod: .net-framework
msc.legacyurl: /web-forms/overview/performance-and-caching/using-asynchronous-methods-in-aspnet-45
msc.type: authoredcontent
---
Using Asynchronous Methods in ASP.NET 4.5
====================
by [Rick Anderson](https://github.com/Rick-Anderson)

> This tutorial will teach you the basics of building an asynchronous ASP.NET Web Forms application using [Visual Studio Express 2012 for Web](https://www.microsoft.com/visualstudio/11/en-us), which is a free version of Microsoft Visual Studio. You can also use [Visual Studio 2012](https://www.microsoft.com/visualstudio/11/en-us). The following sections are included in this tutorial.
> 
> - [How Requests Are Processed by the Thread Pool](#HowRequestsProcessedByTP)
> - [Choosing Synchronous or Asynchronous Methods](#ChoosingSyncVasync)
> - [The Sample Application](#SampleApp)
> - [The Gizmos Synchronous Page](#GizmosSynch)
> - [Creating an Asynchronous Gizmos Page](#CreatingAsynchGizmos)
> - [Performing Multiple Operations in Parallel](#Parallel)
> - [Using a Cancellation Token](#CancelToken)
> - [Server Configuration for High Concurrency/High Latency Web Service Calls](#ServerConfig)
> 
> A complete sample is provided for this tutorial at  
>  [https://github.com/RickAndMSFT/Async-ASP.NET/](https://github.com/RickAndMSFT/Async-ASP.NET/) on the [GitHub](https://github.com/) site.


ASP.NET 4.5 Web Pages in combination [.NET 4.5](https://msdn.microsoft.com/en-us/library/w0x726c2(VS.110).aspx) enables you to register asynchronous methods that return an object of type [Task](https://msdn.microsoft.com/en-us/library/system.threading.tasks.task.aspx). The .NET Framework 4 introduced an asynchronous programming concept referred to as a [Task](https://msdn.microsoft.com/en-us/library/system.threading.tasks.task.aspx) and ASP.NET 4.5 supports [Task](https://msdn.microsoft.com/en-us/library/system.threading.tasks.task.aspx). Tasks are represented by the **Task** type and related types in the [System.Threading.Tasks](https://msdn.microsoft.com/en-us/library/system.threading.tasks.aspx) namespace. The .NET Framework 4.5 builds on this asynchronous support with the [await](https://msdn.microsoft.com/en-us/library/hh156528(VS.110).aspx) and [async](https://msdn.microsoft.com/en-us/library/hh156513(VS.110).aspx) keywords that make working with [Task](https://msdn.microsoft.com/en-us/library/system.threading.tasks.task.aspx) objects much less complex than previous asynchronous approaches. The [await](https://msdn.microsoft.com/en-us/library/hh156528(VS.110).aspx) keyword is syntactical shorthand for indicating that a piece of code should asynchronously wait on some other piece of code. The [async](https://msdn.microsoft.com/en-us/library/hh156513(VS.110).aspx) keyword represents a hint that you can use to mark methods as task-based asynchronous methods. The combination of **await**, **async**, and the **Task** object makes it much easier for you to write asynchronous code in .NET 4.5. The new model for asynchronous methods is called the *Task-based Asynchronous Pattern* (**TAP**). This tutorial assumes you have some familiarity with asynchronous programing using [await](https://msdn.microsoft.com/en-us/library/hh156528(VS.110).aspx) and [async](https://msdn.microsoft.com/en-us/library/hh156513(VS.110).aspx) keywords and the [Task](https://msdn.microsoft.com/en-us/library/system.threading.tasks.task.aspx) namespace.

For more information on the using [await](https://msdn.microsoft.com/en-us/library/hh156528(VS.110).aspx) and [async](https://msdn.microsoft.com/en-us/library/hh156513(VS.110).aspx) keywords and the [Task](https://msdn.microsoft.com/en-us/library/system.threading.tasks.task.aspx) namespace, see the following references.

- [Whitepaper: Asynchrony in .NET](https://go.microsoft.com/fwlink/?LinkId=204844)
- [Async/Await FAQ](https://blogs.msdn.com/b/pfxteam/archive/2012/04/12/10293335.aspx)
- [Visual Studio Asynchronous Programming](https://msdn.microsoft.com/en-us/vstudio/gg316360)

## <a id="HowRequestsProcessedByTP"></a>  How Requests Are Processed by the Thread Pool

On the web server, the .NET Framework maintains a pool of threads that are used to service ASP.NET requests. When a request arrives, a thread from the pool is dispatched to process that request. If the request is processed synchronously, the thread that processes the request is busy while the request is being processed, and that thread cannot service another request.   
  
This might not be a problem, because the thread pool can be made large enough to accommodate many busy threads. However, the number of threads in the thread pool is limited (the default maximum for .NET 4.5 is 5,000). In large applications with high concurrency of long-running requests, all available threads might be busy. This condition is known as thread starvation. When this condition is reached, the web server queues requests. If the request queue becomes full, the web server rejects requests with an HTTP 503 status (Server Too Busy). The CLR thread pool has limitations on new thread injections. If concurrency is bursty (that is, your web site can suddenly get a large number of requests) and all available request threads are busy because of backend calls with high latency, the limited thread injection rate can make your application respond very poorly. Additionally, each new thread added to the thread pool has overhead (such as 1 MB of stack memory). A web application using synchronous methods to service high latency calls where the thread pool grows to the .NET 4.5 default maximum of 5, 000 threads would consume approximately 5 GB more memory than an application able the service the same requests using asynchronous methods and only 50 threads. When you're doing asynchronous work, you're not always using a thread. For example, when you make an asynchronous web service request, ASP.NET will not be using any threads between the **async** method call and the **await**. Using the thread pool to service requests with high latency can lead to a large memory footprint and poor utilization of the server hardware.

## Processing Asynchronous Requests

In web applications that see a large number of concurrent requests at start-up or has a bursty load (where concurrency increases suddenly), making web service calls asynchronous will increase the responsiveness of your application. An asynchronous request takes the same amount of time to process as a synchronous request. For example, if a request makes a web service call that requires two seconds to complete, the request takes two seconds whether it is performed synchronously or asynchronously. However, during an asynchronous call, a thread is not blocked from responding to other requests while it waits for the first request to complete. Therefore, asynchronous requests prevent request queuing and thread pool growth when there are many concurrent requests that invoke long-running operations.

## <a id="ChoosingSyncVasync"></a>  Choosing Synchronous or Asynchronous Methods

This section lists guidelines for when to use synchronous or asynchronous Methods. These are just guidelines; examine each application individually to determine whether asynchronous methods help with performance.

In general, use synchronous methods for the following conditions:

- The operations are simple or short-running.
- Simplicity is more important than efficiency.
- The operations are primarily CPU operations instead of operations that involve extensive disk or network overhead. Using asynchronous methods on CPU-bound operations provides no benefits and results in more overhead.

 In general, use asynchronous methods for the following conditions:

- You're calling services that can be consumed through asynchronous methods, and you're using .NET 4.5 or higher.
- The operations are network-bound or I/O-bound instead of CPU-bound.
- Parallelism is more important than simplicity of code.
- You want to provide a mechanism that lets users cancel a long-running request.
- When the benefit of switching threads out weights the cost of the context switch. In general, you should make a method asynchronous if the synchronous method blocks the ASP.NET request thread while doing no work. By making the call asynchronous, the ASP.NET request thread is not blocked doing no work while it waits for the web service request to complete.
- Testing shows that the blocking operations are a bottleneck in site performance and that IIS can service more requests by using asynchronous methods for these blocking calls.

 The downloadable sample shows how to use asynchronous methods effectively. The sample provided was designed to provide a simple demonstration of asynchronous programming in ASP.NET 4.5. The sample is not intended to be a reference architecture for asynchronous programming in ASP.NET. The sample program calls [ASP.NET Web API](../../../web-api/index.md) methods which in turn call [Task.Delay](https://msdn.microsoft.com/en-us/library/hh139096(VS.110).aspx) to simulate long-running web service calls. Most production applications will not show such obvious benefits to using asynchronous Methods.   
  
Few applications require all methods to be asynchronous. Often, converting a few synchronous methods to asynchronous methods provides the best efficiency increase for the amount of work required.

## <a id="SampleApp"></a>  The Sample Application

You can download the sample application from [https://github.com/RickAndMSFT/Async-ASP.NET](https://github.com/RickAndMSFT/Async-ASP.NET) on the [GitHub](https://github.com/) site. The repository consists of three projects:

- *WebAppAsync*: The ASP.NET Web Forms project that consumes the Web API **WebAPIpwg** service. Most of the code for this tutorial is from the this project.
- *WebAPIpgw*: The ASP.NET MVC 4 Web API project that implements the `Products, Gizmos and Widgets` controllers. It provides the data for the *WebAppAsync* project and the *Mvc4Async* project.
- *Mvc4Async*: The ASP.NET MVC 4 project that contains the code used in another tutorial. It makes Web API calls to the **WebAPIpwg** service.

## <a id="GizmosSynch"></a>  The Gizmos Synchronous Page

 The following code shows the `Page_Load` synchronous method that is used to display a list of gizmos. (For this article, a gizmo is a fictional mechanical device.) 

[!code-csharp[Main](using-asynchronous-methods-in-aspnet-45/samples/sample1.cs)]

The following code shows the `GetGizmos` method of the gizmo service.

[!code-csharp[Main](using-asynchronous-methods-in-aspnet-45/samples/sample2.cs)]

The `GizmoService GetGizmos` method passes a URI to an ASP.NET Web API HTTP service which returns a list of gizmos data. The *WebAPIpgw* project contains the implementation of the Web API `gizmos, widget` and `product` controllers.  
The following image shows the gizmos page from the sample project.

![Gizmos](using-asynchronous-methods-in-aspnet-45/_static/image1.png)

## <a id="CreatingAsynchGizmos"></a>  Creating an Asynchronous Gizmos Page

The sample uses the new [async](https://msdn.microsoft.com/en-us/library/hh156513(VS.110).aspx) and [await](https://msdn.microsoft.com/en-us/library/hh156528(VS.110).aspx) keywords (available in .NET 4.5 and Visual Studio 2012) to let the compiler be responsible for maintaining the complicated transformations necessary for asynchronous programming. The compiler lets you write code using the C#'s synchronous control flow constructs and the compiler automatically applies the transformations necessary to use callbacks in order to avoid blocking threads.

ASP.NET asynchronous pages must include the [Page](https://msdn.microsoft.com/en-us/library/ydy4x04a.aspx) directive with the `Async` attribute set to "true". The following code shows the [Page](https://msdn.microsoft.com/en-us/library/ydy4x04a.aspx) directive with the `Async` attribute set to "true" for the *GizmosAsync.aspx* page.

[!code-aspx[Main](using-asynchronous-methods-in-aspnet-45/samples/sample3.aspx?highlight=1)]

The following code shows the `Gizmos` synchronous `Page_Load` method and the `GizmosAsync` asynchronous page. If your browser supports the [HTML 5 &lt;mark&gt; element](http://www.w3.org/wiki/HTML/Elements/mark), you'll see the changes in `GizmosAsync` in yellow highlight.

[!code-csharp[Main](using-asynchronous-methods-in-aspnet-45/samples/sample4.cs)]

The asynchronous version:

[!code-csharp[Main](using-asynchronous-methods-in-aspnet-45/samples/sample5.cs?highlight=3,6-7,9,11)]

 The following changes were applied to allow the `GizmosAsync` page be asynchronous.

- The [Page](https://msdn.microsoft.com/en-us/library/ydy4x04a.aspx) directive must have the `Async` attribute set to "true".
- The `RegisterAsyncTask` method is used to register an asynchronous task containing the code which runs asynchronously.
- The new `GetGizmosSvcAsync` method is marked with the [async](https://msdn.microsoft.com/en-us/library/hh156513(VS.110).aspx) keyword, which tells the compiler to generate callbacks for parts of the body and to automatically create a `Task` that is returned.
- &quot;Async&quot; was appended to the asynchronous method name. Appending "Async" is not required but is the convention when writing asynchronous methods.
- The return type of the new new `GetGizmosSvcAsync` method is `Task`. The return type of `Task` represents ongoing work and provides callers of the method with a handle through which to wait for the asynchronous operation's completion.
- The [await](https://msdn.microsoft.com/en-us/library/hh156528(VS.110).aspx) keyword was applied to the web service call.
- The asynchronous web service API was called (`GetGizmosAsync`).

Inside of the `GetGizmosSvcAsync` method body another asynchronous method, `GetGizmosAsync` is called. `GetGizmosAsync` immediately returns a `Task<List<Gizmo>>` that will eventually complete when the data is available. Because you don't want to do anything else until you have the gizmo data, the code awaits the task (using the **await** keyword). You can use the **await** keyword only in methods annotated with the **async** keyword.

The **await** keyword does not block the thread until the task is complete. It signs up the rest of the method as a callback on the task, and immediately returns. When the awaited task eventually completes, it will invoke that callback and thus resume the execution of the method right where it left off. For more information on using the [await](https://msdn.microsoft.com/en-us/library/hh156528(VS.110).aspx) and [async](https://msdn.microsoft.com/en-us/library/hh156513(VS.110).aspx) keywords and the [Task](https://msdn.microsoft.com/en-us/library/system.threading.tasks.task.aspx) namespace, see the [async references](#asyncRefs) section.

The following code shows the `GetGizmos` and `GetGizmosAsync` methods.

[!code-csharp[Main](using-asynchronous-methods-in-aspnet-45/samples/sample6.cs)]

[!code-csharp[Main](using-asynchronous-methods-in-aspnet-45/samples/sample7.cs?highlight=1,4-8)]

 The asynchronous changes are similar to those made to the **GizmosAsync** above. 

- The method signature was annotated with the [async](https://msdn.microsoft.com/en-us/library/hh156513(VS.110).aspx) keyword, the return type was changed to `Task<List<Gizmo>>`, and *Async* was appended to the method name.
- The asynchronous [HttpClient](https://msdn.microsoft.com/en-us/library/system.net.http.httpclient(VS.110).aspx) class is used instead of the synchronous [WebClient](https://msdn.microsoft.com/en-us/library/system.net.webclient.aspx) class.
- The [await](https://msdn.microsoft.com/en-us/library/hh156528(VS.110).aspx) keyword was applied to the [HttpClient](https://msdn.microsoft.com/en-us/library/system.net.http.httpclient(VS.110).aspx)[GetAsync](https://msdn.microsoft.com/en-us/library/hh158944(VS.110).aspx) asynchronous method.

The following image shows the asynchronous gizmo view.

![async](using-asynchronous-methods-in-aspnet-45/_static/image2.png)

The browsers presentation of the gizmos data is identical to the view created by the synchronous call. The only difference is the asynchronous version may be more performant under heavy loads.

## RegisterAsyncTask Notes

Methods hooked up with `RegisterAsyncTask` will run immediately after [PreRender](https://msdn.microsoft.com/en-us/library/ms178472.aspx). You can also use async void page events directly, as shown in the following code:

[!code-csharp[Main](using-asynchronous-methods-in-aspnet-45/samples/sample8.cs)]

The downside to async void events is that developers no longer has full control over when events execute. For example, if both an .aspx and a .Master define `Page_Load` events and one or both of them are asynchronous, the order of execution can't be guaranteed. The same indeterminiate order for non event handlers (such as `async void Button_Click` ) applies. For most developers this should be acceptable, but those who require full control over the order of execution should only use APIs like `RegisterAsyncTask` that consume methods which return a Task object.

## <a id="Parallel"></a>  Performing Multiple Operations in Parallel

Asynchronous Methods have a significant advantage over synchronous methods when an action must perform several independent operations. In the sample provided, the synchronous page *PWG.aspx*(for Products, Widgets and Gizmos) displays the results of three web service calls to get a list of products, widgets, and gizmos. The [ASP.NET Web API](../../../web-api/index.md) project that provides these services uses [Task.Delay](https://msdn.microsoft.com/en-us/library/hh139096(VS.110).aspx) to simulate latency or slow network calls. When the delay is set to 500 milliseconds, the asynchronous *PWGasync.aspx* page takes a little over 500 milliseconds to complete while the synchronous `PWG` version takes over 1,500 milliseconds. The synchronous *PWG.aspx* page is shown in the following code.

[!code-csharp[Main](using-asynchronous-methods-in-aspnet-45/samples/sample9.cs)]

The asynchronous `PWGasync` code behind is shown below.

[!code-csharp[Main](using-asynchronous-methods-in-aspnet-45/samples/sample10.cs?highlight=5,11,21)]

The following image shows the view returned from the asynchronous *PWGasync.aspx* page.

![](using-asynchronous-methods-in-aspnet-45/_static/image3.png)

## <a id="CancelToken"></a>  Using a Cancellation Token

Asynchronous Methods returning `Task`are cancelable, that is they take a [CancellationToken](https://msdn.microsoft.com/en-us/library/system.threading.cancellationtoken(VS.110).aspx) parameter when one is provided with the `AsyncTimeout` attribute of the [Page](https://msdn.microsoft.com/en-us/library/ydy4x04a.aspx) directive. The following code shows the *GizmosCancelAsync.aspx* page with a timeout of on second.

[!code-aspx[Main](using-asynchronous-methods-in-aspnet-45/samples/sample11.aspx?highlight=1)]

The following code shows the *GizmosCancelAsync.aspx.cs* file.

[!code-csharp[Main](using-asynchronous-methods-in-aspnet-45/samples/sample12.cs?highlight=6,9)]

In the sample application provided, selecting the *GizmosCancelAsync* link calls the *GizmosCancelAsync.aspx* page and demonstrates the cancelation (by timing out) of the asynchronous call. Because the delay time is within a random range, you might need to refresh the page a couple times to get the time out error message.

## <a id="ServerConfig"></a>  Server Configuration for High Concurrency/High Latency Web Service Calls

To realize the benefits of an asynchronous web application, you might need to make some changes to the default server configuration. Keep the following in mind when configuring and stress testing your asynchronous web application.

- Windows 7, Windows Vista, Window 8, and all Windows client operating systems have a maximum of 10 concurrent requests. You'll need a Windows Server operating system to see the benefits of asynchronous methods under high load.
- Register .NET 4.5 with IIS from an elevated command prompt using the following command:  
 %windir%\Microsoft.NET\Framework64 \v4.0.30319\aspnet\_regiis -i  
 See    [ASP.NET IIS Registration Tool (Aspnet\_regiis.exe)](https://msdn.microsoft.com/en-us/library/k6h9cz8h.aspx)
- You might need to increase the [HTTP.sys](https://www.iis.net/learn/get-started/introduction-to-iis/introduction-to-iis-architecture) queue limit from the default value of 1,000 to 5,000. If the setting is too low, you may see [HTTP.sys](https://www.iis.net/learn/get-started/introduction-to-iis/introduction-to-iis-architecture) reject requests with a HTTP 503 status. To change the HTTP.sys queue limit:

    - Open IIS manager and navigate to the Application Pools pane.
    - Right click on the target application pool and select **Advanced Settings**.  
        ![advanced](using-asynchronous-methods-in-aspnet-45/_static/image4.png)
    - In the **Advanced Settings** dialog box, change *Queue Length* from 1,000 to 5,000.  
        ![Queue length](using-asynchronous-methods-in-aspnet-45/_static/image5.png)  
  
 Note in the images above, the .NET framework is listed as v4.0, even though the application pool is using .NET 4.5. To understand this discrepancy, see the following:

        - [.NET Versioning and Multi-Targeting - .NET 4.5 is an in-place upgrade to .NET 4.0](http://www.hanselman.com/blog/NETVersioningAndMultiTargetingNET45IsAnInplaceUpgradeToNET40.aspx)
        - [How to set an IIS Application or AppPool to use ASP.NET 3.5 rather than 2.0](http://www.hanselman.com/blog/HowToSetAnIISApplicationOrAppPoolToUseASPNET35RatherThan20.aspx)
        - [.NET Framework Versions and Dependencies](https://msdn.microsoft.com/en-us/library/bb822049(VS.110).aspx)
- If your application is using web services or System.NET to communicate with a backend over HTTP you may need to increase the [connectionManagement/maxconnection](https://msdn.microsoft.com/en-us/library/fb6y0fyc(VS.110).aspx) element. For ASP.NET applications, this is limited by the autoConfig feature to 12 times the number of CPUs. That means that on a quad-proc, you can have at most 12 \* 4 = 48 concurrent connections to an IP end point. Because this is tied to [autoConfig](https://msdn.microsoft.com/en-us/library/7w2sway1(VS.110).aspx), the easiest way to increase `maxconnection` in an ASP.NET application is to set [System.Net.ServicePointManager.DefaultConnectionLimit](https://msdn.microsoft.com/en-us/library/system.net.servicepointmanager.defaultconnectionlimit(VS.110).aspx) programmatically in the from `Application_Start` method in the *global.asax* file. See the sample download for an example.
- In .NET 4.5, the default of 5000 for [MaxConcurrentRequestsPerCPU](https://blogs.msdn.com/tmarq/archive/2007/07/21/asp-net-thread-usage-on-iis-7-0-and-6-0.aspx) should be fine.

## Contributors

- [Levi Broderick](http://stackoverflow.com/users/59641/levi)
- [Tom Dykstra](http://www.bing.com/search?q=site%3Aasp.net+%22Tom+Dykstra%22+-forums.asp.net&amp;qs=n&amp;form=QBRE&amp;pq=site%3Aasp.net+%22tom+dykstra%22+-forums.asp.net&amp;sc=8-42&amp;sp=-1&amp;sk=)
- [Brad Wilson](http://bradwilson.typepad.com/)
- [HongMei Ge](https://blogs.msdn.com/b/hongmeig/)