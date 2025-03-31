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

This article explains how to host and deploy Blazor WebAssembly using Apache.

To deploy a Blazor WebAssembly app to Apache:

:::moniker range=">= aspnetcore-8.0"

1. Create the Apache configuration file. The following example is a simplified configuration file (`blazorapp.config`):

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

1. Create the Apache configuration file. The following example is a simplified configuration file (`blazorapp.config`):

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

1. Place the Apache configuration file into the `/etc/httpd/conf.d/` directory.

1. Place the app's published assets (`/bin/Release/{TARGET FRAMEWORK}/publish/wwwroot`, where the `{TARGET FRAMEWORK}` placeholder is the target framework) into the `/var/www/blazorapp` directory (the location specified to `DocumentRoot` in the configuration file).

1. Restart the Apache service.

For more information, see [`mod_mime`](https://httpd.apache.org/docs/2.4/mod/mod_mime.html) and [`mod_deflate`](https://httpd.apache.org/docs/current/mod/mod_deflate.html).
