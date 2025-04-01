---
title: Host and deploy ASP.NET Core Blazor WebAssembly with Apache
author: guardrex
description: Learn how to host and deploy Blazor WebAssembly using Apache.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc, linux-related-content
ms.date: 03/31/2025
uid: blazor/host-and-deploy/webassembly/apache
---
# Host and deploy ASP.NET Core Blazor WebAssembly with Apache

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to host and deploy Blazor WebAssembly using [Apache](https://www.apache.org/).

To deploy a Blazor WebAssembly app to Apache:

:::moniker range=">= aspnetcore-8.0"

Create the Apache configuration file. The following example is a simplified configuration file (`blazorapp.config`):

```
<VirtualHost *:80>
    ServerName www.example.com
    ServerAlias *.example.com

    DocumentRoot "/var/www/blazorapp"
    ErrorDocument 404 /index.html

    AddType application/wasm .wasm

    <Directory "/var/www/blazorapp">
        Options -Indexes
        AllowOverride None
    </Directory>

    <IfModule mod_deflate.c>
        AddOutputFilterByType DEFLATE text/css
        AddOutputFilterByType DEFLATE application/javascript
        AddOutputFilterByType DEFLATE text/html
        AddOutputFilterByType DEFLATE application/octet-stream
        AddOutputFilterByType DEFLATE application/wasm
        <IfModule mod_setenvif.c>
            BrowserMatch ^Mozilla/4 gzip-only-text/html
            BrowserMatch ^Mozilla/4.0[678] no-gzip
            BrowserMatch bMSIE !no-gzip !gzip-only-text/html
        </IfModule>
    </IfModule>

    ErrorLog /var/log/httpd/blazorapp-error.log
    CustomLog /var/log/httpd/blazorapp-access.log common
</VirtualHost>
```

:::moniker-end

:::moniker range="< aspnetcore-8.0"

Create the Apache configuration file. The following example is a simplified configuration file (`blazorapp.config`):

```
<VirtualHost *:80>
    ServerName www.example.com
    ServerAlias *.example.com

    DocumentRoot "/var/www/blazorapp"
    ErrorDocument 404 /index.html

    AddType application/wasm .wasm
    AddType application/octet-stream .dll

    <Directory "/var/www/blazorapp">
        Options -Indexes
        AllowOverride None
    </Directory>

    <IfModule mod_deflate.c>
        AddOutputFilterByType DEFLATE text/css
        AddOutputFilterByType DEFLATE application/javascript
        AddOutputFilterByType DEFLATE text/html
        AddOutputFilterByType DEFLATE application/octet-stream
        AddOutputFilterByType DEFLATE application/wasm
        <IfModule mod_setenvif.c>
            BrowserMatch ^Mozilla/4 gzip-only-text/html
            BrowserMatch ^Mozilla/4.0[678] no-gzip
            BrowserMatch bMSIE !no-gzip !gzip-only-text/html
        </IfModule>
    </IfModule>

    ErrorLog /var/log/httpd/blazorapp-error.log
    CustomLog /var/log/httpd/blazorapp-access.log common
</VirtualHost>
```

:::moniker-end

Place the Apache configuration file into the `/etc/httpd/conf.d/` directory.

Place the app's published assets (`/bin/Release/{TARGET FRAMEWORK}/publish/wwwroot`, where the `{TARGET FRAMEWORK}` placeholder is the target framework) into the `/var/www/blazorapp` directory (the location specified to `DocumentRoot` in the configuration file).

Restart the Apache service.

For more information, see [`mod_mime`](https://httpd.apache.org/docs/2.4/mod/mod_mime.html) and [`mod_deflate`](https://httpd.apache.org/docs/current/mod/mod_deflate.html).

:::moniker range="< aspnetcore-8.0"

## Hosted deployment on Linux (Apache)

Configure the app with <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions> to forward the `X-Forwarded-For` and `X-Forwarded-Proto` headers by following the guidance in <xref:host-and-deploy/proxy-load-balancer>.

For more information on setting the app's base path, including sub-app path configuration, see <xref:blazor/host-and-deploy/app-base-path>.

The following example hosts the app at a root URL (no sub-app path):

```
<VirtualHost *:*>
    RequestHeader set "X-Forwarded-Proto" expr=%{REQUEST_SCHEME}
</VirtualHost>

<VirtualHost *:80>
    ProxyPreserveHost On
    ProxyPass         / http://localhost:5000/
    ProxyPassReverse  / http://localhost:5000/
    ProxyPassMatch    ^/_blazor/(.*) http://localhost:5000/_blazor/$1
    ProxyPass         /_blazor ws://localhost:5000/_blazor
    ServerName        www.example.com
    ServerAlias       *.example.com
    ErrorLog          ${APACHE_LOG_DIR}helloapp-error.log
    CustomLog         ${APACHE_LOG_DIR}helloapp-access.log common
</VirtualHost>
```

To configure the server to host the app at a sub-app path, the `{PATH}` placeholder in the following entires is the sub-app path:

```
<VirtualHost *:*>
    RequestHeader set "X-Forwarded-Proto" expr=%{REQUEST_SCHEME}
</VirtualHost>

<VirtualHost *:80>
    ProxyPreserveHost On
    ProxyPass         / http://localhost:5000/{PATH}
    ProxyPassReverse  / http://localhost:5000/{PATH}
    ProxyPassMatch    ^/_blazor/(.*) http://localhost:5000/{PATH}/_blazor/$1
    ProxyPass         /_blazor ws://localhost:5000/{PATH}/_blazor
    ServerName        www.example.com
    ServerAlias       *.example.com
    ErrorLog          ${APACHE_LOG_DIR}helloapp-error.log
    CustomLog         ${APACHE_LOG_DIR}helloapp-access.log common
</VirtualHost>
```

For an app that responds to requests at `/blazor`:

```
<VirtualHost *:*>
    RequestHeader set "X-Forwarded-Proto" expr=%{REQUEST_SCHEME}
</VirtualHost>

<VirtualHost *:80>
    ProxyPreserveHost On
    ProxyPass         / http://localhost:5000/blazor
    ProxyPassReverse  / http://localhost:5000/blazor
    ProxyPassMatch    ^/_blazor/(.*) http://localhost:5000/blazor/_blazor/$1
    ProxyPass         /_blazor ws://localhost:5000/blazor/_blazor
    ServerName        www.example.com
    ServerAlias       *.example.com
    ErrorLog          ${APACHE_LOG_DIR}helloapp-error.log
    CustomLog         ${APACHE_LOG_DIR}helloapp-access.log common
</VirtualHost>
```

:::moniker-end

## Additional resources

* [Apache documentation](https://httpd.apache.org/docs/current/mod/mod_proxy.html)
* Developers on non-Microsoft support forums:
  * [Stack Overflow (tag: `blazor`)](https://stackoverflow.com/questions/tagged/blazor)
  * [ASP.NET Core Slack Team](https://join.slack.com/t/aspnetcore/shared_invite/zt-1mv5487zb-EOZxJ1iqb0A0ajowEbxByQ)
  * [Blazor Gitter](https://gitter.im/aspnet/Blazor)
