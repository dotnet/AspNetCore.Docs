---
uid: fundamentals/servers/yarp/overview
title: Overview of YARP
description: Overview of YARP
author: samsp-msft
ms.author: samsp
ms.date: 2/18/2025
ms.topic: article
content_well_notification: AI-contribution
ai-usage: ai-assisted
---


# Overview of YARP

## Introduction to YARP

YARP (Yet Another Reverse Proxy) is a highly customizable reverse proxy library for .NET. It is designed to be flexible and easy to use, allowing developers to create powerful and efficient reverse proxy solutions tailored to their specific needs. YARP leverages the power of ASP.NET Core to provide a robust and scalable proxy framework.

## What a reverse proxy does

A reverse proxy is a server that sits between client devices and backend servers. It forwards client requests to the appropriate backend server and then returns the server's response to the client. This setup provides several benefits:

- Routing: Directs requests to different backend servers based on predefined rules, such as URL patterns or request headers.
- Load Balancing: Distributes incoming traffic across multiple backend servers to ensure no single server is overwhelmed, improving performance and reliability.
- SSL Termination: Offloads the SSL encryption/decryption process from backend servers, reducing their workload.
- Connection Abstraction: The inbound requests from external clients and outbound requests to the backend are independent so can use different versions of HTTP and have independent connection lifetimes.
- Control over URL-space: The incoming URLs can be transformed before sending to the backend so you abstract between the URLs seen externally and how those are mapped to services
- Security: Acts as a barrier between clients and backend servers, hiding the internal server structure and protecting against certain types of cyber attacks.
- Caching: Stores copies of frequently requested resources to reduce the load on backend servers and improve response times.

## Why use a reverse proxy

Using a reverse proxy offers several advantages:

- Scalability: By distributing traffic across multiple servers, a reverse proxy helps scale applications to handle more users and higher loads.
- Improved Performance: Caching and load balancing features can significantly enhance the performance and responsiveness of applications.
- Enhanced Security: A reverse proxy can provide an additional layer of security by hiding backend servers and mitigating certain types of attacks.
- Simplified Maintenance: Reverse proxies can handle SSL termination and other tasks, simplifying the configuration and maintenance of backend servers.

## How a reverse proxy handles HTTP

A reverse proxy handles HTTP requests and responses in the following manner:

- Receiving Requests: The reverse proxy listens for incoming HTTP requests from clients on specified endpoints.
- Terminating Connections: The inbound http connections terminate at the proxy and new connections are used for outbound requests to destinations.
- Routing Requests: Based on the routing rules, the reverse proxy determines which backend server (or cluster of servers) should handle the request. 
- Forwarding Requests: The reverse proxy forwards the client request to the appropriate backend server
- Connection Pooling: The outbound connections are pooled to reduce connection overhead and make most use of HTTP 1.1 pipelining and parallel requests with HTTP2 & HTTP3
- Processing Responses: The backend server processes the request and sends a response back to the reverse proxy.
- Returning Responses: The reverse proxy receives the response from the backend server and forwards it back to the client.

This process ensures that the client interacts with the reverse proxy rather than directly with the backend servers, providing the benefits of load balancing, security, and more.

## Why choose YARP over other proxies

YARP offers several unique benefits that make it an attractive choice for developers:

- Customization: YARP is highly customizable, allowing developers to tailor the proxy to their specific needs with minimal effort.
- Integration with .NET: Built on ASP.NET Core, YARP seamlessly integrates with the .NET ecosystem, making it an ideal choice for .NET developers.
- Extensibility: YARP provides a rich set of extensibility points, enabling developers to add custom logic and features as needed.
- Active Development: YARP is actively maintained and developed by Microsoft, ensuring it stays up-to-date with the latest technologies and best practices.
- Comprehensive Documentation: YARP comes with extensive documentation and examples, making it easy to get started and implement advanced features.

By choosing YARP, developers can leverage a powerful, flexible, and well-supported reverse proxy solution that integrates seamlessly with their .NET applications.
