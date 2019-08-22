# Securing blazor server-side applications
Blazor server-side applications follow a stateful model where the server and the client maintain a long-lived relationship (circuit) that expands one or more physical connections (also potentially long-lived).

When a customer visits a blazor server-side site, the server creates a session (circuit) that lives in the server memory and that handles the interaction with the user, indicating to the browser what content to render and responding to events like button clicks, key presses, etc.

In addition to this, any given circuit is able to invoke JavaScript functions in the user's browser provided they are exposed in the global scope. At the same time the client is also able to invoke .NET functions on the server provided they are marked as such. We refer to the act of invoking .NET methods from the browser and JavaScript functions from the server as JS interop.

Blazor server-side shares many of the concerns applicable to regular web applications. Through this document we will discuss some of the most common threats and will give you guidance on specific mitigations you can take to secure your application.

We will start talking about how blazor server-side uses resources and what you need to know as an application developer to prevent clients from miss using resources. The guidance we are providing here focuses on internet facing applications, there might be more constrained environments where some of the recommendations we give you here don't apply or are not worth it, like inside corporate networks or for intranet LOB applications.

## Resource exhaustion

Resource exhaustion can happen when a client interacts with the server and causes it to consume excessive resources. Those resources can be primarily (CPU, memory and connections).

### CPU exhaustion
CPU exhaustion can happen when we allow a client to force the server to do intensive CPU work. 

For example, lets say we build an application that allows a client to enter a number and have the server print the fibonnacci number for that number.

Assuming that the server has a naive implementation, the client can then input a really big number and have the server perform a lot of work to determine the fibonnacci sequence for that number.

This example, although a bit unreal, ilustrates the point. The client just needs to introduce a big number and the server will spend way more time than the client calculating it.

This is a valid concern for all public facing applications, but while in general applications requests and connections time out, in blazor server-side applications that is not the case.

As an application developer we must evaluate what are we asking the server to do when we answer to an event on the client, and include any appropriate check before we start doing any work.

### Memory exhaustion
Memory exhaustion can happen when we allow a client to force the server to consume a lot of memory.

For example, lets say we build a todo-list application and that we don't limit the number of items that can be added to a list or that we naively render all the items at the same time.

A client can then add items to the list non-stop, forcing the server to render all those items and consuming a lot of memory in the process.

As a developer, there are several aspects of this problem that we must be aware of:
  * When we hold data in a component like in our `TodoList` component, if we store the todo items in a `List<ToDoItem>` property or field, that list is using the server memory so if we allow that list to grow unbounded we run the risk of running out of memory. This causes not only the current session to end (crash) but all the sessions in that server instance at the time as the application receives an OutOfMemory exception.
    * We recommend that you use some data structure with limits that you can configure to prevent this situation.
  * When we force the UI to render all the todo items, the server is forced to hold on to additional memory for things that might not be visible in the screen at the time. (This assumes you don't render all the items and have some sort of paging)
    * We recommend that you only render the components/data that needs to be visible to the user and avoid holding on to any other data in memory, specially if this data can grow based on user input like our `TodoList`. In this particular case you could achieve this by implementing some sort of _virtual-list_ that only exposes a window to the subset of elements at the current position/page for the component to render and keeps the rest either in secondary storage (ideal) or in memory (less ideal).

While Blazor server-side applications offer a very similar programming model to other UI frameworks for stateful applications like WPF, Windows forms or Blazor client-side, the main thing to remember is that in all those cases the memory consumed by the application belongs to the client and only affects that individual client, while in the server case the memory consumed by the application belongs to the server and is shared with all the clients running on that server instance.

This is true for all server-side applications, but most applications are stateless and the memory gets released at the end of the request.

As a general recomendation, you should pay the same attention to the memory consumed by a given client as in any other server-side app, paying special attention to the fact that the memory consumed by a blazor server-side application lives for a much longer time than a simple request.

### Connections
Connection exhaustion can happen when a client opens too many concurrent connections to the server preventing new connections from other clients from getting established.

Blazor clients establish a single connection per session and keep it open for as long as the browser window is opened, this however doesn't prevent other clients from opening multiple conections to the server. This is not specific to blazor applications but given the long-lived nature of connections in blazor applications and the stateful nature of the applications, this can have a bigger impact in terms of availability.

This is not new to blazor server-side applications, other server-side applications have this concern too. We recommend two ways of dealing with this.
* Limit the amount of established connections from a given client as you would do in any other application through the use of a proxy server. Azure offers several options for this like Azure Front Door.
* Proxy websocket connections to your application through the use of a proxy like Azure SignalR Service that multiplexes the connections from clients to your application. This gives your application way more connections that what a single client can establish, preventing a client from exhausting the connections to the server.

**For more in depth details about blazor server-side resource ussage we recommend you check the docummentation on reliability and scalability to get a better idea about expected resource consumption.**

## Interactions with the browser (client)

A client interacts with the server through JavaScript interop event dispatching and render completion. In the case of JS inteorp this communication goes both ways, from JavaScript to .NET and viceversa. Browser events are dispatched from client to server in an asynchronous fashion and the server responds asynchronously by producing new renders if necessary.

### Invoking JavaScript functions from .NET
Calls from .NET to the JavaScript need to watch for a few things:
* All invocations have a configurable timeout after which they'll simply fail, returning a OperationCancelledException to the caller.
  * There is a default timeout for the calls of around 1 minute.
  * A cancellation token can be provided to control the cancellation on a per call basis.
    * We recommend that you rely on the default call timeout where possible and that you time-bound any call to the client if you provide your own cancellation token.
* The result of a JavaScript call can't be trusted.
  * Our clients will simply search for the function to invoke, invoke it and produce either the result or an error. A malicious client, could however try to return an error to cause an issue in the application or an unexpected result to try induce some unintended behavior in the server.
    * We recommend that you wrap any JS interop call within a try-catch block to account for any error that might happen during the invocation.
    * We recommend that you validate any data comming out from a JS interop invocation before taking any action. This includes error messages.

### Exposing .NET methods to the browser.
Calls from JavaScript to .NET are not to be trusted. When you expose a .NET function to JavaScript you need to consider how that function might be invoked.
* We recommend that you treat any .NET method exposed to JavaScript as you would a public endpoint in your app.
  * Validate the input.
    * Ensure tha the values are whithin the expected ranges.
    * Ensure that the user has permission to perform the action he is requesting.      
  * Make sure you don't allocate an excessive amount of resources as part of the invocation (CPU, Memory, etc).
  * Take into account that static and instance methods can be exposed to JavaScript clients and that you should take special considerations to avoid sharing state between sessions.
    * For instance methods exposed through the use of DotNetReference objects, if originally created through DI should be registered as scoped objects (this applies to any DI service your blazor server-side app uses).
    * For static methods you should avoid having any sort of state that can't be scoped to the client.
  * Avoid using user input for JS interop calls or validate the input if you have to to avoid XSS attacks. Consider also using CSP to disable 'eval' and other unsafe JS primitives.
* We recommend that you avoid implementing your own dispatching of .NET invocations on top of our implementation. While its doable to implement a more general .NET method dispatching infrastructure on top of the one provided by the framework, we strongly discourage that you do so, as exposing .NET methods to the browser should be an explicit action that needs the same careful thought as exposing any other API member.

### Consuming events
Events are another entry point to your application, so the same rules as any other endpoint apply for consuming events. In particular, a bad behaving client can send whatever fake data they want as the payload for the event.

For example, a change event for a select could send a value that is not within the options, or a textbox could send any text data to the server bypassing any client side validation.

We recommend that you validate the input for any event that your app handles. The forms components that we provide as part of the framework already perform those validations, but if you are writing your own components you need to validate the inputs as appropriate.

In blazor server-side events are asynchronous by nature, so multiple events can be dispatched to the server before the application has time to react by producing a new render. This has some security implications we need to be aware of.

Limiting client actions on the application needs to be done inside event handlers and not depend on the current rendered view state. 

For example, imagine a counter where we want to only allow users to click the counter 3 times. If the logic for our counter is similar to this
```
<p>@count<p>
@if(count < 3)
{
  <button @onclick="IncrementCount" value="Increment count" />
}

@code 
{
  int count = 0;
  void IncrementCount() => count++;
}
```
a client can dispatch one or more increment events before we produce a new render and result in the count being incremented over 3. The right way to achieve something like this is as follows.
```
<p>Count @count<p>
@if(count < 3)
{
  <button @onclick="IncrementCount" value="Increment count" />
}

@code 
{
  int count = 0;
  void IncrementCount() => count < 3 ? count++ : count;
}
```

By adding the `count < 3` check inside the handler we force the decission to be taken based on the current app state, and not the state of the UI which might be out of date.

# Other security recommendations
In general, all the recommendations for securing ASP.NET Core applications apply to blazor server-side applications.

In this section we will go through some of the common application threats, explain what blazor server-side does to address it and what recommended application specific actions can be taken to further protect your application.

## Logging and sensitive data
Blazor server-side applications interact heavily with the client through events and JS interop. All these interactions are recorded on the server logs via the use of `Microsoft.AspNetCore.Extensions.Logging.ILogger`. Blazor avoids logging sensitive information, like actual events or JS interop inputs/outputs.

When an error occurs on the server we notify the client and tear down the session. By default the client receives a generic error message that can be read when opening the developer tools.

This error does not include any callstack and doesn't provide any details of what the cause of the error was. The server logs contain such information and for development purposes it can be made available to the client by turning on detailed errors.

This can be done either on `CircuitOptions.DetailedErrors` or by setting the `DetailedErrors` configuration key, for example through the `ASPNETCORE_DETAILEDERRORS=true` environment variable.

## Protecting information in transit
Blazor server-side uses SignalR under the hood to comunicate between the client and the server. That means that blazor server-side will normally use whatever transport SignalR negotiates (typically websockets).

Blazor server-side doesn't take any extra step to ensure the integrity and confidentiality of the data sent between the server and the client.

For that reason, the recommendation is to use HTTPS for communications if your app is not in a trusted environment.

## Cross-site scripting (XSS)
This threat allows an unauthorized party to execute arbitrary logic in the context of the browser. A compromised application would potentially run arbitrary code on the client (user's browser) and such vulnerability could be used to potentially perform a number of actions against the server. Such actions include:
* Dispatching fake/invalid events to the server.
* Dispatching fail/invalid render completions.
* Avoid dispatching render completions.
* Dispatching interop calls from JS to .NET.
* Modifying the response of interop calls from .NET to JS.
* Avoid dispatching .NET to JS interop results.

Blazor server-side takes some steps towards protecting against some of these threats but ultimately your application needs to be aware of these and take appropriate actions:
* Don't trust data on event handlers before validating it first.
* Take appropriate action upon receiving what your application considers to be invalid data.
  * Ignore the data and return, if you can't be sure the input was illegitimate. This will allow the app to continue working.
  * Throw an exception, if you determine that the input is illegitimate and couldn't have been produced by legitimate clients. This will tear down the circuit and end the session.
* Don't trust the error message comming from render batch completions included in the logs. This error came from the client and can't be generally trusted as the client might have been compromised.
* Don't trust the input from interop calls. This input comes in two flavors.
  * JS to .NET interop invocations.
  * .NET to JS interop results.
* The application is responsible for validating that the contents of the arguments/result are valid even if they were correctly deserialized.

Blazor server-side takes specific steps to mitigate some of these threats.
* It will stop producing new UI updates if the client is not acknowledging render batches. (This can be configured in `CircuitOptions.MaxBufferedUnacknowledgedRenderBatches`)
* It will timeout any .NET to JS call after 1 minute without receiving a response from the client.
* It performs some basic validation in all input comming from the browser from JS interop.
  * Ensure that the dotnet references are valid and of the type expected by the .NET method.
  * Ensure that the data is not malformed.
  * Ensure the right number of arguments for the method is present on the payload.
  * Ensure that the arguments/result can be deserialized correctly before invoking the method.
* It performs some basic validation in all input comming from the browser from dispatched events.
  * It validates that the event has a valid type.
  * It validates that the data for the event can be deserialized.
  * It validates that there is an event handler associated with that event.

For a XSS vulnerability to be possible, the application must allow some user input to be included as part of the rendered page. Blazor server-side components go through a compile-time step where the contents of the page are transformed into what we call a RenderTree (a virtual DOM like structure) and the diffs between previous and current renders are sent to the client for rendering, or in the case of prerendering serialized into HTML.
* At this step blazor server-side takes care of HTML encoding all content that wasn't defined as static markup at compile-time.
* Script tags aren't allowed to be included as components and a compile time error is generated when one such tag is included in a razor page.
  * Script tags will not behave the way one would expect on the page. Once added they execute the contents of the script and those side-effects don't disappear even if you remove the script tag.
* Component authors can author components in C# without using Razor. For these cases, the component author is responsible for encoding all potentiall user input from the component.
* It is also recommended that you avoid including script tags as part of your component render tree for the reasons stated above.

As part of protecting against XSS attacks we recommend looking into application specific mitigations like content security policy (CSP). See https://developer.mozilla.org/en-US/docs/Web/HTTP/CSP for more details.

## Cross-origin protection
Cross-origin attacks involve a client from a different origin performing some action against your server. This action is typically a form POST (CSRF), but opening a websocket is also possible. Blazor server-side applications offer the same guarantees that any other SignalR application using the hub protocol offers.
* A browser from a different origin can't connect to the blazor-server side application and start a new session (circuit) with the default application configuration.
  * This is due to CORS being disabled by default and SignalR forcing a preflight request against the server as part of the hub protocol handshake.
* If you enable CORS in your application then you might need to take extra steps to protect your application depending on your CORS configuration.
  * If you enable CORS globally you can disable it specifically for the blazor server-side hub by adding the `DisableCorsAttribute` metadata to the endpoint metadata after calling `hub.MapBlazorHub()`.

## Click-jacking
Click-jacking involves rendering a site as an iframe inside a site from a different origin in order to trick the user into performing actions on the site under attack.

If you want to protect your application from being rendered inside an iframe we recommend using CSP and the `X-Frame-Options` header. See https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-Frame-Options for more details

## Open redirections
When a blazor server-side application session starts the server performs some validation against the urls sent as part of starting the session.

When a user clicks a link on the client, the url for the link is sent to the server which decides what to do with it, for example perform a client-side navigation or indicate the browser to go to the new location.

Components can also trigger navigation requests programatically through the user of NavigationManager. In such cases, the application might perform a client-side navigation or indicate the browser to go to the new location.

For that reason components must avoid using user input as part of the navigation call arguments and validate such arguments to ensure that the target is allowed by the application.

Otherwise a malicious user could force the browser to go to an attacker controller site by tricking the application into using some user input as part of the invocation to Navigate.

This advice also applies when rendering links as part of the application. Always use relative links if possible and validate that absolute links destinations are valid before including them in the page.

## Denial of service attacks (DoS)
Denial of service attacks involve a client causing the server to exhaust one or more of its resources making the application unavailable. We've described the most common resources a blazor server-side application uses at the beginning of this document so in this section we will tackle specific mitigations and guidance to protect your application against this type of attacks.

### Server-side limits
* Blazor server-side applications have some specific limits and rely on some other ASP.NET Core and SignalR limits to protect against DoS.
* The blazor server-side application specific limits are the following:
  * Maximum amount of disconnected circuits that a given server holds in memory at a time. Its value can be configured in `CircuitOptions.DisconnectedCircuitMaxRetained`.
  * Maximum amount of time a disconnected circuit is hold in memory before being torn down. Its value can be configured in `CircuitOptions.DisconnectedCircuitRetentionPeriod`
  * Maximum amount of unacknowledged render batches the server keeps in memory per circuit at a given time to support robust reconnection. It can be configured in `CircuitOptions.MaxBufferedUnacknowledgedRenderBatches` and after reaching this limit the server stops producing new render batches until one or more batches have been ack by the client.
* Blazor server-side applications rely on the following SignalR and ASP.NET Core limits:
  * Message size for an individual message. This is covered by the max message size in SignalR which defaults to 32Kb.

### Additional protection
By default there's no limit on the number of connections per client/user to a blazor server-side application. If your application requires such limit there are several approaches that can be taken.
* Require authentication to connect to the application. This will naturally limit the ability of unauthorized users to connect to the application provided they can't provision a user for the system.
* Limit the number of connections per user. This could be done at the application level through endpoint routing extensibility, by requiring authentication to connect to the app and keeping track of the active sessions per client/user and rejecting new sessions upon hitting a limit.
* Limiting the number of connections per client/user can also be achieved by using a proxy/gateway in front of your application like Azure CloudFront.
* In the last two cases, care needs to be taken to prevent denying access to legitimate users, if for example the limit is established based on the client ip.

## Authentication and authorization
* For specific guidance on authentication and authorization check the docs at https://docs.microsoft.com/en-us/aspnet/core/security/blazor/?view=aspnetcore-3.0

## Security check-list for blazor server-side applications
What follows is a **basic and non exhaustive** list of checks and recommendations to follow as part of considering the security aspects of your blazor server-side application.
* Validate arguments from events.
* Validate results from JS interop calls.
* Validate inputs from JS interop calls.
* Avoid using or validate beforehand user input for .NET to JS interop calls.
* Prevent the client from allocating an unbound amount of memory.
  * Data within the component.
  * DotNetObject references returned to the client.
* Avoid using user input as part of calls to NavigationManager.Navigate and validate it against a set of allowed origins first if unavoidable.
* Do not make authorization decissions based on the state of the UI but only from state from the component.
* Consider using CSP to protect agaisnt XSS attacks.
* Consider using CSP and X-Frame-Options to protect against click-jacking.
* Ensure CORS settings are acceptable when enabling CORS or explicitly disable it for Blazor.
* Avoid using script tags in components.
* Test to ensure that the server side-limits for the blazor application provide an acceptable user experience.
