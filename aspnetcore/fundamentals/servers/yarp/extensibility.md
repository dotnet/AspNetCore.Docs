---
uid: fundamentals/servers/yarp/extensibility
title: Overview of extensibility
description: Overview of extensibility
author: samsp-msft
ms.author: samsp
ms.date: 2/12/2025
ms.topic: article
content_well_notification: AI-contribution
ai-usage: ai-assisted
---

# Overview of YARP extensibility

There are 2 main styles of extensibility for YARP, depending on the routing behavior desired:

* Middleware Pipeline
* Http Forwarder

## Middleware pipeline

YARP uses the concept of [Routes](xref:fundamentals/servers/yarp/config-files#routes), [Clusters](xref:fundamentals/servers/yarp/config-files#clusters) and Destinations. These can be supplied through [configuration files](xref:fundamentals/servers/yarp/config-files) or [directly through code](xref:fundamentals/servers/yarp/config-providers). Based on the routing rules, YARP picks a cluster and enumerates the possible destinations. It then uses the middleware pipeline to select the destination based on destination health, session affinity, load balancing etc.

![Image](https://github.com/user-attachments/assets/ff17a04f-0c3c-46c7-8ec2-a1ed3dbc948c)

Most of the pre-built pipeline modules can be customized through code. You can also change the pipeline definition to replace modules with your own implementation(s) or add additional modules as needed.

For more information see [Middleware](xref:fundamentals/servers/yarp/middleware).

## Http Forwarder

If the YARP pipeline is too rigid for your needs, or the scale of routing rules and destinations is not suitable for loading into memory, then you can implement your own routing logic and use the HTTP Forwarder to direct requests to your chosen destination. The HttpForwarder component takes the HTTP context and forwards the request to the supplied destination.

![Image](https://github.com/user-attachments/assets/1a060a7e-fa43-49a4-bfad-f95d7d35be63)

The transform component can still be used with the forwarder is needed.

For more information see [Direct forwarding](xref:fundamentals/servers/yarp/direct-forwarding).
