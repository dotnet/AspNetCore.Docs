---
title: Host and deploy ASP.NET Core Blazor WebAssembly with Nginx
author: guardrex
description: Learn how to host and deploy Blazor WebAssembly using Nginx.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc, linux-related-content
ms.date: 03/31/2025
uid: blazor/host-and-deploy/webassembly/nginx
---
# Host and deploy ASP.NET Core Blazor WebAssembly with Nginx

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to host and deploy Blazor WebAssembly using Nginx.

The following `nginx.conf` file is simplified to show how to configure Nginx to send the `index.html` file whenever it can't find a corresponding file on disk.

```
events { }
http {
    server {
        listen 80;

        location / {
            root      /usr/share/nginx/html;
            try_files $uri $uri/ /index.html =404;
        }
    }
}
```

When setting the [NGINX burst rate limit](https://www.nginx.com/blog/rate-limiting-nginx/#bursts) with [`limit_req`](https://nginx.org/docs/http/ngx_http_limit_req_module.html#limit_req) and [`limit_req_zone`](https://nginx.org/docs/http/ngx_http_limit_req_module.html), Blazor WebAssembly apps may require a large `burst`/`rate` parameter values to accommodate the relatively large number of requests made by an app. Initially, set the value to at least 60:

```
http {
    limit_req_zone $binary_remote_addr zone=one:10m rate=60r/s;
    server {
        ...

        location / {
            ...

            limit_req zone=one burst=60 nodelay;
        }
    }
}
```

Increase the value if browser developer tools or a network traffic tool indicates that requests are receiving a *503 - Service Unavailable* status code.

For more information on production Nginx web server configuration, see [Creating NGINX Plus and NGINX Configuration Files](https://docs.nginx.com/nginx/admin-guide/basic-functionality/managing-configuration-files/).
