---
title: Threat mitigation guidance for ASP.NET Core Blazor static server-side rendering
author: guardrex
description: Learn how to mitigate security threats in static server-side Blazor.
monikerRange: '>= aspnetcore-8.0'
ms.author: riande
ms.custom: mvc
ms.date: 11/16/2023
uid: blazor/security/server/static-server-side-rendering
---
# Threat mitigation guidance for ASP.NET Core Blazor static server-side rendering

<!-- UPDATE 9.0 Activate after release and INCLUDE is updated

[!INCLUDE[](~/includes/not-latest-version.md)]

-->

This article explains the security considerations that developers should take into account when developing Blazor Web Apps with static server-side rendering.

Blazor combines three different models in one for writing interactive web apps. Traditional server-side rendering, which is a request/response model based on HTTP. Interactive server-side rendering, which is a rendering model based on SignalR. Finally, client-side rendering, which is a rendering model based on WebAssembly.

All of the general security considerations defined for the interactive rendering modes apply to Blazor Web Apps when there are interactive components rendering in one of the supported render modes. The following sections explain the security considerations specific to non-interactive server-side rendering in Blazor Web Apps and the specific aspects that apply when render modes interact with each other.

## General considerations for server-side rendering

The server-side rendering (SSR) model is based on the traditional request/response model of HTTP. As such, there are common areas of concern between SSR and request/response HTTP. General security considerations and specific threats must be successfully mitigated. The framework provides built-in mechanisms for managing some of these threats, but other threats are specific to app code and must be handled by the app. These threats can be categorized as follows:

* Authentication and authorization: The app must ensure that the user is authenticated and authorized to access the app and the resources it exposes. The framework provides built-in mechanisms for authentication and authorization, but the app must ensure that the mechanisms are properly configured and used. The built-in mechanisms for authentication and authorization are covered in the [Blazor documentation's *Server* security node](xref:blazor/security/server/index) and in the [ASP.NET Core documentation's *Security and Identity* node](xref:security/index), so they won't be covered here.

* Input validation and sanitization: All input arriving from a client must be validated and sanitized before use. Otherwise, the app might be exposed to attacks, such as SQL injection, cross-site scripting, cross-site request forgery, open redirection, and other forms of attacks. The input might come from anywhere in the request.

* Session management: Properly managing user sessions is critical to ensure that the app isn't exposed to attacks, such as session fixation, session hijacking, and other attacks. Information stored in the session must be properly protected and encrypted, and the app's code must prevent a malicious user from guessing or manipulating sessions.

* Error handling and logging: The app must ensure that errors are properly handled and logged. Otherwise, the app might be exposed to attacks, such as information disclosure. This can happen when the app returns sensitive information in the response or when the app returns detailed error messages with data that can be used to attack the app.

* Data protection: Sensitive data must be properly protected, which includes app logic when running on WebAssembly, since it can be easily reverse-engineered.

* Denial of service: The app must ensure that it isn't exposed to attacks, such as denial of service. This happens for example, when the app isn't properly protected against brute force attacks or when an action can cause the app to consume too many resources.

## Input validation and sanitization

All input arriving from the client must be considered untrusted unless its information was generated and protected on the server, such as a CSRF token, an authentication cookie, a session identifier, or any other payload that's protected with authenticated encryption.

Input is normally available to the app through a binding process, for example via the [`[SupplyParameterFromQuery]` attribute](xref:Microsoft.AspNetCore.Components.SupplyParameterFromQueryAttribute) or [`[SupplyParameterFromForm]` attribute](xref:Microsoft.AspNetCore.Components.SupplyParameterFromFormAttribute). Before processing this input, the app must make sure that the data is valid. For example, the app must confirm that there were no binding errors when mapping the form data to a component property. Otherwise, the app might process invalid data.

If the input is used to perform a redirect, the app must make sure that the input is valid and that it isn't pointing to a domain considered invalid or to an invalid subpath within the app base path. Otherwise, the app may be exposed to open redirection attacks, where an attacker can craft a link that redirects the user to a malicious site.

If the input is used to perform a database query, app must confirm that the input is valid and that it isn't exposing the app to SQL injection attacks. Otherwise, an attacker might be able to craft a malicious query that can be used to extract information from the database or to modify the database.

Data that might have come from user input also must be sanitized before included in a response. For example, the input might contain HTML or JavaScript that can be used to perform cross-site scripting attacks, which can be used to extract information from the user or to perform actions on behalf of the user.

The framework provides the following mechanisms to help with input validation and sanitization:

* All bound form data is validated for basic correctness. If an input can't be parsed, the binding process reports an error that the app can discover before taking any action with the data. The built-in <xref:Microsoft.AspNetCore.Components.Forms.EditForm> component takes this into account before invoking the <xref:Microsoft.AspNetCore.Components.Forms.EditForm.OnValidSubmit> form callback. Blazor avoids executing the callback if there are one or more binding errors.
* The framework uses an antiforgery token to protect against cross-site request forgery attacks.

All input and permissions must be validated on the server at the time of performing a given action to ensure that the data is valid and accurate at that time and that the user is allowed to perform the action. This approach is consistent with the [security guidance provided for interactive server-side rendering](xref:blazor/security/server/interactive-server-side-rendering).

## Session management

Session management is handled by the framework. The framework uses a session cookie to identify the user session. The session cookie is protected using the ASP.NET Core Data Protection APIs. The session cookie isn't accessible to JavaScript code running on the browser and it can't be easily guessed or manipulated by a user.

With regard to other session data, such as data stored within services, the session data should be stored within scoped services, as scoped services are unique per a given user session, as opposed to singleton services which are shared across all user sessions in a given process instance.

When it comes to SSR, there's not much difference between scoped and transient services in most cases, as the lifetime of the service is limited to a single request. There's a difference in two scenarios:

* If the service is injected in more than one location or at different times during the request.
* If the service might be used in an interactive server context, where it survives multiple renders and its fundamental that the service is scoped to the user session.

## Error handling and logging

The framework provides built-in logging for the app at the framework level. The framework logs important events, such as when the antiforgery token for a form fails to validate, when a root component starts to render, and when an action is dispatched. The app is responsible for logging any other events that might be important to record.

The framework provides built-in error handling for the app at the framework level. The framework handles errors that happen during the rendering of a component and either uses the error boundary mechanism to display a friendly error message or allows the error to bubble up to the exception handling middleware, which is configured to render the error page.

Errors that occur during streaming rendering after the response has started to be sent to the client are displayed in the final response as a generic error message. Details about the cause of the error are only included during development.

## Data protection

The framework offers mechanisms for protecting sensitive information for a given user session and ensures that the built-in components use these mechanisms to protect sensitive information, such as protecting user identity when using cookie authentication. Outside of scenarios handled by the framework, developer code is responsible for protecting other app-specific information. The most common way of doing this is via the ASP.NET Core Data Protection APIs or any other form of encryption. As a general rule, the app is responsible for:

* Making sure that a user can't inspect or modify the private information of another user.
* Making sure that a user can't modify user data of another user, such as an internal identifier.

With regard to data protection, you must clearly understand where the code is executing. For the static server-side rendering (static SSR) and interactive server-side rendering (interactive SSR), code is stored on the server and never reaches the client. For the Interactive WebAssembly render mode, the app code *always reaches the client*, which means that any sensitive information stored in the app code is available to anyone with access to the app. Obfuscation and other similar technique to "protect" the code isn't effective. Once the code reaches the client, it can be reverse-engineered to extract the sensitive information.

## Denial of service

At the server level, the framework provides limits on request/response parameters, such as the maximum size of the request and the header size. In regard to app code, Blazor's form mapping system defines limits similar to those defined by MVC's model binding system:

* Limit on the maximum number of errors.
* Limit on the maximum recursion depth for the binder.
* Limit on the maximum number of elements bound in a collection.

In addition, there are limits defined for the form, such as the maximum form key size and value size and the maximum number of entries.

In general, the app must evaluate when there's a chance that a request triggers an asymmetric amount of work by the server. Examples of this include when the user sends a request parameterized by N and the server performs an operation in response that is N times as expensive, where N is a parameter that a user controls and can grow indefinitely. Normally, the app must either impose a limit on the maximum N that it's willing to process or ensure that any operation is either less, equal, or more expensive than the request by a constant factor.

This aspect has more to do with the difference in growth between the work the client performs and the work the server performs than with a specific 1→N comparison. For example, a client might submit a work item (inserting elements into a list) that takes N units of time to perform, but the server needs N^2^ to process (because it might be doing something very naive). It's the difference between N and N^2^ that matters.

As such, there's a limit on how much work the server must be willing to do, which is specific to the app. This aspect applies to server-side workloads, since the resources are on the server, but doesn't necessarily apply to WebAssembly workloads on the client in most cases.

The other important aspect is that this isn't only reserved to CPU time. It also applies to any resources, such as memory, network, and space on disk.

For WebAssembly workloads, there's usually little concern over the amount of work the client performs, since the client is normally limited by the resources available on the client. However, there are some scenarios where the client might be impacted, if for example, an app displays data from other users and one user is capable of adding data to the system that forces the clients that display the data to perform an amount of work that isn't proportional to the amount of data added by the user.

## Recommended (non-exhaustive) check list

* Ensure that the user is authenticated and authorized to access the app and the resources it exposes.
* Validate and sanitize all input coming from a client before using it.
* Properly manage user sessions to ensure that state isn't mistakenly shared across users.
* Handle and log errors properly to avoid exposing sensitive information.
* Log important events in the app to identify potential issues and audit actions performed by users.
* Protect sensitive information using the ASP.NET Core Data Protection APIs or one of the available components (<xref:Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage>, <xref:Microsoft.AspNetCore.Components.PersistentComponentState>).
* Ensure that the app understands the resources that can be consumed by a given request and has limits in place to avoid denial of service attacks.
