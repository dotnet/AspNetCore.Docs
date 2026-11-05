---
title: Overview of extensibility
description: Overview of extensibility
ms.date: 04/03/2025
ms.topic: concept-article
content_well_notification: AI-contribution
ai-usage: ai-assisted
---
# Overview of YARP extensibility

There are 2 main styles of extensibility for YARP, depending on the routing behavior desired:

* Middleware pipeline
* HTTP forwarder

## Middleware pipeline

YARP uses the concept of [Routes](config-files.md#define-configuration-routes), [Clusters](config-files.md#define-configuration-clusters) and Destinations. These can be supplied through [configuration files](config-files.md) or [directly through code](config-providers.md). Based on the routing rules, YARP picks a cluster and enumerates the possible destinations. It then uses the middleware pipeline to select the destination based on destination health, session affinity, load balancing etc.

![Middleware pipeline diagram](~/fundamentals/servers/yarp/media/yarp-pipeline.png)

Most of the prebuilt pipeline can be customized through code:

* [Configuration Providers](config-providers.md)
* [Destination Enumeration](destination-resolvers.md)
* [Session Affinity](session-affinity.md)
* [Load Balancing](load-balancing.md)
* [Health Checks](dests-health-checks.md)
* [Request Transforms](extensibility-transforms.md)
* [HttpClient configuration](./http-client-config.md#code-configuration)

You can also change the pipeline definition to replace modules with your own implementations or add additional modules as needed. For more information see [Middleware](middleware.md).

## HTTP forwarder

If the YARP pipeline is too rigid for your use case or the scale of routing rules and destinations isn't suitable for loading into memory, then you can implement your own routing logic and use the HTTP Forwarder to direct requests to your chosen destination. The `HttpForwarder` component takes the HTTP context and forwards the request to the supplied destination.

![HTTP forwarder diagram](~/fundamentals/servers/yarp/media/yarp-forwarder.png)

The transform component can still be used if the forwarder is needed.

For more information see [Direct forwarding](direct-forwarding.md).
