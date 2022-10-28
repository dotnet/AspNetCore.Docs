---
title: Reliable gRPC services with deadlines and cancellation
author: jamesnk
description: Learn how to create reliable gRPC services with deadlines and cancellation in .NET.
monikerRange: '>= aspnetcore-3.0'
ms.author: jamesnk
ms.date: 09/07/2020
uid: grpc/deadlines-cancellation
---
# Reliable gRPC services with deadlines and cancellation

By [James Newton-King](https://twitter.com/jamesnk)

Deadlines and cancellation are features used by gRPC clients to abort in-progress calls. This article discusses why deadlines and cancellation are important, and how to use them in .NET gRPC apps.

## Deadlines

A deadline allows a gRPC client to specify how long it will wait for a call to complete. When a deadline is exceeded, the call is canceled. Setting a deadline is important because it provides an upper limit on how long a call can run for. It stops misbehaving services from running forever and exhausting server resources. Deadlines are a useful tool for building reliable apps and should be configured.

Deadline configuration:

* A deadline is configured using `CallOptions.Deadline` when a call is made.
* There is no default deadline value. gRPC calls aren't time limited unless a deadline is specified.
* A deadline is the UTC time of when the deadline is exceeded. For example, `DateTime.UtcNow.AddSeconds(5)` is a deadline of 5 seconds from now.
* If a past or current time is used then the call immediately exceeds the deadline.
* The deadline is sent with the gRPC call to the service and is independently tracked by both the client and the service. It is possible that a gRPC call completes on one machine, but by the time the response has returned to the client the deadline has been exceeded.

If a deadline is exceeded, the client and service have different behavior:

* The client immediately aborts the underlying HTTP request and throws a `DeadlineExceeded` error. The client app can choose to catch the error and display a timeout message to the user.
* On the server, the executing HTTP request is aborted and [ServerCallContext.CancellationToken](xref:System.Threading.CancellationToken) is raised. Although the HTTP request is aborted, the gRPC call continues to run on the server until the method completes. It's important that the cancellation token is passed to async methods so they are cancelled along with the call. For example, passing a cancellation token to async database queries and HTTP requests. Passing a cancellation token allows the canceled call to complete quickly on the server and free up resources for other calls.

Configure `CallOptions.Deadline` to set a deadline for a gRPC call:

[!code-csharp[](~/grpc/deadlines-cancellation/deadline-client.cs?highlight=7,12)]

Using `ServerCallContext.CancellationToken` in a gRPC service:

[!code-csharp[](~/grpc/deadlines-cancellation/deadline-server.cs?highlight=5)]

### Deadlines and retries

When a gRPC call is configured with [retry fault handling](xref:grpc/retries) and a deadline, the deadline tracks time across all retries for a gRPC call. If the deadline is exceeded, a gRPC call immediately aborts the underlying HTTP request, skips any remaining retries, and throws a `DeadlineExceeded` error.

### Propagating deadlines

When a gRPC call is made from an executing gRPC service, the deadline should be propagated. For example:

1. Client app calls `FrontendService.GetUser` with a deadline.
2. `FrontendService` calls `UserService.GetUser`. The deadline specified by the client should be specified with the new gRPC call.
3. `UserService.GetUser` receives the deadline. It correctly times-out if the client app's deadline is exceeded.

The call context provides the deadline with `ServerCallContext.Deadline`:

[!code-csharp[](~/grpc/deadlines-cancellation/deadline-propagate.cs?highlight=7)]

Manually propagating deadlines can be cumbersome. The deadline needs to be passed to every call, and it's easy to accidentally miss. An automatic solution is available with gRPC client factory. Specifying `EnableCallContextPropagation`:

* Automatically propagates the deadline and cancellation token to child calls.
* Doesn't propagate the deadline if the child call specifies a smaller deadline. For example, a propagated deadline of 10 seconds isn't used if a child call specifies a new deadline of 5 seconds using `CallOptions.Deadline`. When multiple deadlines are available, the smallest deadline is used.
* Is an excellent way of ensuring that complex, nested gRPC scenarios always propagate the deadline and cancellation.

[!code-csharp[](~/grpc/deadlines-cancellation/clientfactory-propagate.cs?highlight=6)]

For more information, see <xref:grpc/clientfactory#deadline-and-cancellation-propagation>.

## Cancellation

Cancellation allows a gRPC client to cancel long running calls that are no longer needed. For example, a gRPC call that streams realtime updates is started when the user visits a page on a website. The stream should be canceled when the user navigates away from the page.

A gRPC call can be canceled in the client by passing a cancellation token with [CallOptions.CancellationToken](xref:System.Threading.CancellationToken) or calling `Dispose` on the call.

[!code-csharp[](~/grpc/deadlines-cancellation/cancellation-client.cs?highlight=19)]

gRPC services that can be cancelled should:
* Pass `ServerCallContext.CancellationToken` to async methods. Canceling async methods allows the call on the server to complete quickly.
* Propagate the cancellation token to child calls. Propagating the cancellation token ensures that child calls are canceled with their parent. [gRPC client factory](xref:grpc/clientfactory) and `EnableCallContextPropagation()` automatically propagates the cancellation token.

## Additional resources

* <xref:grpc/client>
* <xref:grpc/clientfactory>
