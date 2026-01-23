---
uid: fundamentals/servers/yarp/extensibility
title: Overview of extensibility
description: Overview of extensibility
author: tdykstra
ms.author: tdykstra
ms.date: 04/03/2025
ms.topic: concept-article
content_well_notification: AI-contribution
ai-usage: ai-assisted
---
# Overview of YARP extensibility

There are 2 main styles of extensibility for YARP, depending on the routing behavior desired:

* Middleware Pipeline
* Http Forwarder

## Middleware pipeline

YARP uses the concept of [Routes](xref:fundamentals/servers/yarp/config-files#routes), [Clusters](xref:fundamentals/servers/yarp/config-files#clusters) and Destinations. These can be supplied through [configuration files](xref:fundamentals/servers/yarp/config-files) or [directly through code](xref:fundamentals/servers/yarp/config-providers). Based on the routing rules, YARP picks a cluster and enumerates the possible destinations. It then uses the middleware pipeline to select the destination based on destination health, session affinity, load balancing etc.

![Middleware pipeline diagram](~/fundamentals/servers/yarp/media/yarp-pipeline.png)

Most of the prebuilt pipeline can be customized through code:

* [Configuration Providers](xref:fundamentals/servers/yarp/config-providers)
* [Destination Enumeration](xref:fundamentals/servers/yarp/destination-resolvers)
* [Session Affinity](xref:fundamentals/servers/yarp/session-affinity)
* [Load Balancing](xref:fundamentals/servers/yarp/load-balancing)
* [Health Checks](xref:fundamentals/servers/yarp/dests-health-checks)
* [Request Transforms](xref:fundamentals/servers/yarp/transform-extensibility)
* [HttpClient configuration](./http-client-config.md#code-configuration)

You can also change the pipeline definition to replace modules with your own implementation(s) or add additional modules as needed. For more information see [Middleware](xref:fundamentals/servers/yarp/middleware).

## HTTP Forwarder

If the YARP pipeline is too rigid for your use case or the scale of routing rules and destinations isn't suitable for loading into memory, then you can implement your own routing logic and use the HTTP Forwarder to direct requests to your chosen destination. The `HttpForwarder` component takes the HTTP context and forwards the request to the supplied destination.

![HTTP forwarder diagram](~/fundamentals/servers/yarp/media/yarp-forwarder.png)

The transform component can still be used if the forwarder is needed.

For more information see [Direct forwarding](xref:fundamentals/servers/yarp/direct-forwarding).
