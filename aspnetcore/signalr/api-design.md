---
title: SignalR API Design Considerations
author: anurse
description: 
monikerRange: '>= aspnetcore-2.1'
ms.author: anurse
ms.custom: mvc
ms.date: 11/05/2018
uid: signalr/api-design
---

# SignalR API Design Considerations

By [Andrew Stanton-Nurse](https://twitter.com/anurse)

This article provides guidance for building SignalR-based APIs

## Use custom object parameters to ensure backwards-compatibility

Adding parameters to a SignalR hub method (on either the client or the server) is a *breaking change*, which means older clients/servers will get errors when they try to invoke the method without the appropriate number of parameters. However, adding properties to a custom object parameter is **not** a breaking change. This can be used to design compatible APIs that are resiliant to changes on the client or the server.

For example, consider a server-side API like the following:

[!code-csharp[ParameterBasedOldVersion](api-design/Samples.cs?name=ParameterBasedOldVersion)]

The JavaScript client calls this method using `invoke`, like this:

[!code-typescript[CallWithOneParameter](api-design/Samples.ts?name=CallWithOneParameter)]

If you later add a second parameter to the server method, older clients will not provide this parameter value. For example:

[!code-csharp[ParameterBasedNewVersion](api-design/Samples.cs?name=ParameterBasedNewVersion)]

When the old client tries to invoke this method, it will get an error like this:

```
Microsoft.AspNetCore.SignalR.HubException: Failed to invoke 'GetTotalLength' due to an error on the server.
```

On the server, you will see a log message like this:

```
System.IO.InvalidDataException: Invocation provides 1 argument(s) but target expects 2.
```

The old client only sent one parameter, but the newer server API required two parameters. Using custom objects as parameters gives you more flexibility. Let's redesign the original API to use a custom object:

[!code-csharp[ObjectBasedOldVersion](api-design/Samples.cs?name=ObjectBasedOldVersion)]

Now, the client uses an object to call the method:

[!code-typescript[CallWithObject](api-design/Samples.ts?name=CallWithObject)]

Now, instead of adding a parameter, we can add a property to the `GetTotalLengthRequest` object:

[!code-csharp[ObjectBasedNewVersion](api-design/Samples.cs?name=ObjectBasedNewVersion&highlight=31,36-41)]

When the old client sends us a single parameter, the extra `Param2` property will be left `null` and we can handle that in our code. A new client can send us both parameters.

[!code-typescript[CallWithObjectNew](api-design/Samples.ts?name=CallWithObjectNew)]

The same technique works for methods defined on the client. You can send a custom object from the server side:

[!code-csharp[ClientSideObjectBasedOld](api-design/Samples.cs?name=ClientSideObjectBasedOld)]

On the client side, you access the `Message` property rather than using a parameter:

[!code-typescript[OnWithObjectOld](api-design/Samples.ts?name=OnWithObjectOld)]

If we later decide to add the sender of the message to the payload we send, we can do that by adding a property to the object:

[!code-csharp[ClientSideObjectBasedNew](api-design/Samples.cs?name=ClientSideObjectBasedNew&highlight=60)]

The older clients won't be expecting the `Sender` value, but they'll just ignore it. A new client can accept it by updating to read the new property:

[!code-typescript[OnWithObjectNew](api-design/Samples.ts?name=OnWithObjectNew&highlight=21-24)]

In this case, the new client is also tolerant of connecting to an old client that doesn't provide the `Sender` value, so it checks to see if it exists before accessing it.

## Provide detailed error information using `HubException`

If your hub method throws an exception, SignalR returns a generic error message to the client:

```
Microsoft.AspNetCore.SignalR.HubException: An unexpected error occurred invoking 'MethodName' on the server.
```

Unexpected exceptions often contain sensitive information, such as the name of a database server in an exception triggered when the database connection fails. SignalR doesn't expose these detailed error messages by default as a security measure. The [Security considerations document](xref:signalr/security#exceptions) describes how to configure this.

If you have an exceptional condition you *do* want to propagate to the client, you can use the `HubException` class. If you throw a `HubException` from your hub method, SignalR **will** send the entire message to the client, unmodified.

[!code-csharp[ThrowHubException](api-design/Samples.cs?name=ThrowHubException&highlight=115)]

> [!NOTE]
> SignalR only sends the `Message` value. The stack trace, or other properties on the exception are not available to the client.