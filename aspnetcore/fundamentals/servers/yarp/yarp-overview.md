---
uid: fundamentals/servers/yarp/overview
title: Overview of YARP
description: Overview of YARP
author: wadepickett
ms.author: wpickett
ms.date: 04/03/2025
ms.topic: concept-article
content_well_notification: AI-contribution
ai-usage: ai-assisted
---
# Overview of YARP

## Introduction to YARP

YARP (Yet Another Reverse Proxy) is a highly customizable reverse proxy library for .NET. It's designed to provide a robust, flexible, scalable, secure, and easy to use proxy framework. YARP helps developers create powerful and efficient reverse proxy solutions tailored to their specific needs.

## What a reverse proxy does

A reverse proxy is a server that sits between client devices and backend servers. It forwards client requests to the appropriate backend server and then returns the server's response to the client. A reverse proxy provides several benefits:

* Routing: Directs requests to different backend servers based on predefined rules, such as URL patterns or request headers. For example, `/images`, `/api`, and `/db` requests can be routed image, api, and database servers.
* Load Balancing: Distributes incoming traffic across multiple backend servers to prevent overloading a specific server. Distribution increases performance and reliability.
* Scalability: By distributing traffic across multiple servers, a reverse proxy helps scale apps to handle more users and higher loads. Backend servers scaled (added or removed) without impacting the client.
* [SSL/TLS Termination](/azure/application-gateway/ssl-overview): Offloads the TLS encryption and decryption processes from backend servers, reducing their workload.
* Connection abstraction, decoupling and control over URL-space: Inbound requests from external clients and outbound responses from the backend are independent. This independence allows for differnt:
  * Versions of HTTP, ie, HTTP/1.1, HTTP/2, HTTP/3. The proxy can upgrade or downgrade HTTP versions.
  * Connection lifetimes, which enables having long-lived connections on the backend while maintaining short client connections.
  * Control Over URL-Space: Incoming URLs can be transformed before forwarding to the backend. This abstracts the external URLs from how they are mapped to internal services. Internal service endpoints can change without affecting external URLs.
* Security: Internal service endpoints can be hidden from external exposure, protecting against some types of cyber attacks such as [DDoS attacks](https://www.microsoft.com/security/business/security-101/what-is-a-ddos-attack?msockid=3e35ed3aa4666d8003aaf830a5006c74).
* Caching: Frequently requested resources can be cached to reduce the load on backend servers and improve response times.
* Versioning: Different versions of an API can be supported using different URL mappings.
* Simplified maintenance: Reverse proxies can handle [SSL/TLS Termination](/azure/application-gateway/ssl-overview) and other tasks, simplifying the configuration and maintenance of backend servers. For example, SSL certificates and security policies can be managed at the reverse proxy level instead of on each individual server.

## How a reverse proxy handles HTTP

A reverse proxy handles HTTP requests and responses in the following manner:

* Receiving requests: The reverse proxy listens on specified ports and endpoints for incoming HTTP requests from clients.
* Terminating Connections: The inbound HTTP connections are terminated at the proxy and new connections are used for outbound requests to destinations.
* Routing requests: Based on predefined routing rules and configurations, the reverse proxy determines which backend server, or cluster of servers, should handle the request.
* Forwarding requests: The reverse proxy forwards the client request to the appropriate backend server, transforming the path and headers as necessary.
* Connection pooling: The outbound connections are pooled to reduce connection overhead and make most use of HTTP 1.1 reuse and parallel requests with HTTP/2 and HTTP/3.
* Processing responses: The backend server processes the request and sends a response back to the reverse proxy.
* Returning responses: The reverse proxy receives the response from the backend server and forwards it back to the client, performing any necessary response transforms.

This process ensures that the client interacts with the reverse proxy rather than directly with the backend servers, providing the benefits of load balancing, security, versioning, and more.

## Why choose YARP over other proxies

YARP offers several unique benefits that make it an attractive choice for developers:

* Customization: YARP is highly customizable, allowing developers to tailor the proxy to their specific needs with minimal effort.
* Integration with .NET: Built on ASP.NET Core, YARP seamlessly integrates with the .NET ecosystem, making it an ideal choice for .NET developers.
* Extensibility: YARP provides a rich set of extensibility points, enabling developers to add custom logic and features as needed, using familiar C# code.
* Scalability: The direct forwarding extensibility option enables YARP to scale to support domain name and backend scaling that are not viable with most reverse proxies.
* Active development: [YARP is actively maintained](https://github.com/dotnet/yarp) and developed by Microsoft, ensuring it stays up-to-date with the latest technologies and best practices.
* Comprehensive maintained documentation: YARP comes with extensive documentation and examples, making it easy to get started and implement advanced features.
* [Open source](https://github.com/dotnet/yarp). YARP and the YARP documentation are open source. [Contributions](https://github.com/dotnet/yarp/blob/main/README.md), reviews, and feedback are welcome.
