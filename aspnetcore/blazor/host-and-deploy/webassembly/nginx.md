---
title: Host and deploy ASP.NET Core Blazor WebAssembly with Nginx
ai-usage: ai-assisted
author: guardrex
description: Learn how to host and deploy Blazor WebAssembly using Nginx.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.custom: mvc, linux-related-content
ms.date: 01/21/2026
uid: blazor/host-and-deploy/webassembly/nginx
---
# Host and deploy ASP.NET Core Blazor WebAssembly with Nginx

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to host and deploy Blazor WebAssembly using [Nginx](https://nginx.org/).

This article assumes that you want to serve a Blazor WebAssembly app as static files. It also assumes that you already have the app source code and can publish it. You might want to deploy it either directly on a host or in a Docker container image that includes Nginx and the published app files. This article helps you publish the app, copy the published output to Nginx's web root in the container image, configure Nginx for client-side routing, and apply common production settings.

The article starts with a minimal `nginx.conf` configuration and then calls out additional options that might be useful for production deployments. After that it provides an example Dockerfile that copies this `nginx.conf` and the published app assets into a Docker image.

## Minimal `nginx.conf` for client-side routing

The following `nginx.conf` file is a minimal Nginx configuration example showing how to configure Nginx to send the `index.html` file whenever it can't find a corresponding file on disk. It also directs Nginx to serve correct MIME types by defining a `types` block (alternatively, include a [`mime.types`](https://github.com/nginx/nginx/blob/7fa941a55e211ebd57f512fbfb24d59dbb97940d/conf/mime.types) file).

```nginx
events { }
http {
    types {
        text/html                    html;
        text/css                     css;
        application/javascript       js mjs;
        application/json             json;
        application/manifest+json    webmanifest;

        application/wasm             wasm;

        application/octet-stream     dll pdb webcil;
    }

    server {
        listen 80;

        location / {
            root /usr/share/nginx/html;
            try_files $uri $uri/ /index.html =404;
        }
    }
}
```

## Full `nginx.conf` example

The following `nginx.conf` example builds on the minimal configuration. It includes optional settings for caching, compression, rate limiting, and security headers. Review the comments and remove or adjust settings based on your app's requirements.

```nginx
events { }
http {
    # Security hardening: Don't reveal the Nginx version in responses.
    server_tokens off;

    # Optional: Rate limiting to prevent a single client from sending too many requests.
    # Blazor WebAssembly apps can generate many requests during startup.
    limit_req_zone $binary_remote_addr zone=one:10m rate=60r/s;

    # Optional: Cache-Control policy by URI.
    # - index.html and service-worker.js: avoid caching so app updates are picked up.
    # - /_framework/*: fingerprinted assets can be cached long-term.
    map $uri $cache_control {
        default             "max-age=3600";
        /index.html         "no-cache";
        /service-worker.js  "no-cache";

        # Uncomment if the Blazor WASM app targets .NET 8/9, remove for .NET 10
        # /_framework/blazor.boot.json        "no-cache";
        # /_framework/blazor.webassembly.js   "max-age=3600";
        # /_framework/dotnet.js               "max-age=3600";

        ~^/_framework/      "public, max-age=31536000, immutable";
        ~\.woff2?$          "public, max-age=31536000, immutable";
    }

    # MIME types for Blazor WebAssembly assets.
    types {
        text/html                           html htm;
        text/css                            css;
        application/javascript              js mjs;
        application/json                    json;
        application/manifest+json           webmanifest;
        application/wasm                    wasm;
        text/plain                          txt;
        text/xml                            xml;
        application/octet-stream            bin dll exe pdb blat dat webcil;

        # Images
        image/png                           png;
        image/jpeg                          jpg jpeg;
        image/gif                           gif;
        image/webp                          webp;
        image/avif                          avif;
        image/svg+xml                       svg;
        image/x-icon                        ico;

        # Fonts
        font/woff                           woff;
        font/woff2                          woff2;

        # Fallback for other MIME types
        application/octet-stream            *;
    }

    server {
        listen 80;

        location / {
            # Root path for static site content.
            root      /usr/share/nginx/html;

            # SPA/Blazor routing:
            # - Serve a file if it exists.
            # - Otherwise fall back to index.html.
            try_files $uri $uri/ /index.html =404;

            # Optional: Use the rate limit zone defined above.
            limit_req zone=one burst=60 nodelay;

            # Optional: Serve precompressed *.gz files (when present) instead of compressing on the fly.
            gzip_static on;

            # Optional: Caching policy based on "map $uri $cache_control" above.
            add_header Cache-Control $cache_control always;

            # Optional: Mitigate MIME sniffing.
            add_header X-Content-Type-Options "nosniff" always;
        }
    }
}
```

If browser developer tools or a network traffic tool indicates that requests are receiving a *503 - Service Unavailable* status code, increase the `rate` and `burst` values.

For more information on production Nginx web server configuration, see [Creating NGINX Plus and NGINX Configuration Files](https://docs.nginx.com/nginx/admin-guide/basic-functionality/managing-configuration-files/).

## Docker deployment

The following Dockerfile publishes a Blazor WebAssembly app and serves the app's static web assets from an Nginx image.

The example assumes that:

* The app's project file is named `YourProject.csproj` and located at the Docker build context root.
* An `nginx.conf` file is available at the Docker build context root.

For example, `Dockerfile`, `nginx.conf` and `YourProject.csproj` are all located in the same directory where the rest of Blazor code is also located. In this case `docker build` is launched in this working directory.

```dockerfile
# Build stage
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:10.0-noble AS build
WORKDIR /source

RUN apt update \
    && apt install -y python3 \
    && dotnet workload install wasm-tools

COPY . .
RUN dotnet publish YourProject.csproj --output /app

# Runtime stage
FROM nginx:latest
COPY --from=build /app/wwwroot/ /usr/share/nginx/html/
COPY nginx.conf /etc/nginx/nginx.conf
```

Build and run the image:

```bash
docker build -t blazor-wasm-nginx .
docker run --rm -p {PORT}:80 blazor-wasm-nginx
```

For more information, refer to [Nginx Docker guide](https://hub.docker.com/_/nginx).

:::moniker range="< aspnetcore-8.0"

## Hosted deployment on Linux (Nginx)

Configure the app with <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions> to forward the `X-Forwarded-For` and `X-Forwarded-Proto` headers by following the guidance in <xref:host-and-deploy/proxy-load-balancer>.

For more information on setting the app's base path, including sub-app path configuration, see <xref:blazor/host-and-deploy/app-base-path>.

Follow the guidance for an [ASP.NET Core SignalR app](xref:signalr/scale#linux-with-nginx) with the following changes:

* Remove the configuration for proxy buffering (`proxy_buffering off;`) because the setting only applies to [Server-Sent Events (SSE)](https://developer.mozilla.org/docs/Web/API/Server-sent_events), which aren't relevant to Blazor app client-server interactions.
* Change the `location` path from `/hubroute` (`location /hubroute { ... }`) to the sub-app path `/{PATH}` (`location /{PATH} { ... }`), where the `{PATH}` placeholder is the sub-app path.

  The following example configures the server for an app that responds to requests at the root path `/`:

  ```nginx
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

  ```nginx
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
