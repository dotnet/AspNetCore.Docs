---
title: Host and deploy ASP.NET Core Blazor WebAssembly with Nginx
author: guardrex
description: Learn how to host and deploy Blazor WebAssembly using Nginx.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.custom: mvc, linux-related-content
ms.date: 03/31/2025
uid: blazor/host-and-deploy/webassembly/nginx
---
# Host and deploy ASP.NET Core Blazor WebAssembly with Nginx

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to host and deploy Blazor WebAssembly using [Nginx](https://nginx.org/).

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

:::moniker range="< aspnetcore-8.0"

## Hosted deployment on Linux (Nginx)

Configure the app with <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions> to forward the `X-Forwarded-For` and `X-Forwarded-Proto` headers by following the guidance in <xref:host-and-deploy/proxy-load-balancer>.

For more information on setting the app's base path, including sub-app path configuration, see <xref:blazor/host-and-deploy/app-base-path>.

Follow the guidance for an [ASP.NET Core SignalR app](xref:signalr/scale#linux-with-nginx) with the following changes:

* Remove the configuration for proxy buffering (`proxy_buffering off;`) because the setting only applies to [Server-Sent Events (SSE)](https://developer.mozilla.org/docs/Web/API/Server-sent_events), which aren't relevant to Blazor app client-server interactions.
* Change the `location` path from `/hubroute` (`location /hubroute { ... }`) to the sub-app path `/{PATH}` (`location /{PATH} { ... }`), where the `{PATH}` placeholder is the sub-app path.

  The following example configures the server for an app that responds to requests at the root path `/`:

  ```
  http {
      server {
          ...
          location / {
              ...
          }
      }
  }
  ```

  The following example configures the sub-app path of `/blazor`:

  ```
  http {
      server {
          ...
          location /blazor {
              ...
          }
      }
  }
  ```

:::moniker-end

## Additional resources

* <xref:host-and-deploy/linux-nginx>
* Nginx documentation:
  * [NGINX as a WebSocket Proxy](https://www.nginx.com/blog/websocket-nginx/)
  * [WebSocket proxying](http://nginx.org/docs/http/websocket.html)
* Developers on non-Microsoft support forums:
  * [Stack Overflow (tag: `blazor`)](https://stackoverflow.com/questions/tagged/blazor)
  * [ASP.NET Core Slack Team](https://join.slack.com/t/aspnetcore/shared_invite/zt-1mv5487zb-EOZxJ1iqb0A0ajowEbxByQ)
  * [Blazor Gitter](https://gitter.im/aspnet/Blazor)
