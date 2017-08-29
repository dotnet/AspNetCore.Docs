---
title: Host ASP.NET Core on Linux with Nginx
description: Describes how to setup Nginx as a reverse proxy on Ubuntu 16.04 to forward HTTP traffic to an ASP.NET Core web application running on Kestrel. 
keywords: ASP.NET Core,Linux,nginx,Ubuntu,Reverse Proxy
author: rick-anderson
ms.author: riande
manager: wpickett
ms.date: 08/21/2017
ms.topic: article
ms.assetid: 1c33e576-33de-481a-8ad3-896b94fde0e3
ms.technology: aspnet
ms.prod: asp.net-core
uid: publishing/linuxproduction
---
# Set up a hosting environment for ASP.NET Core on Linux with Nginx, and deploy to it

By [Sourabh Shirhatti](https://twitter.com/sshirhatti)

This guide explains setting up a production-ready ASP.NET Core environment on an Ubuntu 16.04 Server.

**Note:** For Ubuntu 14.04, supervisord is recommended as a solution for monitoring the Kestrel process. systemd is not available on Ubuntu 14.04. [See previous version of this document](https://github.com/aspnet/Docs/blob/e9c1419175c4dd7e152df3746ba1df5935aaafd5/aspnetcore/publishing/linuxproduction.md)

This guide:

* Places an existing ASP.NET Core application behind a reverse proxy server
* Sets up the reverse proxy server to forward requests to the Kestrel web server
* Ensures the web application runs on startup as a daemon
* Configures a process management tool to help restart the web application

## Prerequisites

1. Access to an Ubuntu 16.04 Server with a standard user account with sudo privilege
2. An existing ASP.NET Core application

## Copy over your app

Run `dotnet publish` from the dev environment to package an app into a self-contained directory that can run on the server.

Copy the ASP.NET Core app to the server using whatever tool (SCP, FTP, etc.) integrates into your workflow. Test the app, for example:
 - From the command line, run `dotnet yourapp.dll`
 - In a browser, navigate to `http://<serveraddress>:<port>` to verify the app works on Linux. 
 
**Note:** Use [Yeoman](xref:client-side/yeoman) to create a new ASP.NET Core app for a new project.

## Configure a reverse proxy server

A reverse proxy is a common setup for serving dynamic web applications. A reverse proxy terminates the HTTP request and forwards it to the ASP.NET Core application.

### Why use a reverse proxy server?

Kestrel is great for serving dynamic content from ASP.NET Core; however, the web serving parts aren’t as feature rich as servers like IIS, Apache, or Nginx. A reverse proxy server can offload work like serving static content, caching requests, compressing requests, and SSL termination from the HTTP server. A reverse proxy server may reside on a dedicated machine or may be deployed alongside an HTTP server.

For the purposes of this guide, a single instance of Nginx is used. It runs on the same server, alongside the HTTP server. Based on your requirements, you may choose a different setup.

Because requests are forwarded by reverse proxy, use the `ForwardedHeaders` middleware from the `Microsoft.AspNetCore.HttpOverrides` package. This middleware updates `Request.Scheme`, using the `X-Forwarded-Proto` header, so that redirect URIs and other security policies work correctly.

When setting up a reverse proxy server, the authentication middleware needs `UseForwardedHeaders` to run first. This ordering ensures that the authentication middleware can consume the affected values and generate correct redirect URIs.

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

Invoke the `UseForwardedHeaders` method (in the `Configure` method of *Startup.cs*) before calling `UseAuthentication` or similar authentication scheme middleware:

```csharp
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseAuthentication();
```

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

Invoke the `UseForwardedHeaders` method (in the `Configure` method of *Startup.cs*) before calling `UseIdentity` and `UseFacebookAuthentication` or similar authentication scheme middleware:

```csharp
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseIdentity();
app.UseFacebookAuthentication(new FacebookOptions()
{
    AppId = Configuration["Authentication:Facebook:AppId"],
    AppSecret = Configuration["Authentication:Facebook:AppSecret"]
});
```

---

### Install Nginx

```bash
sudo apt-get install nginx
```

> [!NOTE]
> If you plan to install optional Nginx modules, you may be required to build Nginx from source.

Use `apt-get` to install Nginx. The installer creates a System V init script that runs Nginx as daemon on system startup. Since Nginx was installed for the first time, explicitly start it by running:

```bash
sudo service nginx start
```

Verify a browser displays the default landing page for Nginx.

### Configure Nginx

To configure Nginx as a reverse proxy to forward requests to our ASP.NET Core application, modify `/etc/nginx/sites-available/default`. Open it in a text editor, and replace the contents with the following:

```nginx
server {
    listen 80;
    location / {
        proxy_pass http://localhost:5000;
        proxy_http_version 1.1;
        proxy_set_header Upgrade $http_upgrade;
        proxy_set_header Connection keep-alive;
        proxy_set_header Host $host;
        proxy_cache_bypass $http_upgrade;
    }
}
```

This Nginx configuration file forwards incoming public traffic from port `80` to port `5000`.

Once you have completed making changes to your Nginx configuration, you can run `sudo nginx -t` to verify the syntax of your configuration files. If the configuration file test is successful, you can ask Nginx to pick up the changes by running `sudo nginx -s reload`.

## Monitoring our application

Nginx is now setup to forward requests made to `http://yourhost:80` on to the ASP.NET Core application running on Kestrel at `http://127.0.0.1:5000`. However, Nginx is not set up to manage the Kestrel process. You can use *systemd* and create a service file to start and monitor the underlying web app. *systemd* is an init system that provides many powerful features for starting, stopping, and managing processes. 

### Create the service file

Create the service definition file:

```bash
sudo nano /etc/systemd/system/kestrel-hellomvc.service
```

The following is an example service file for our application:

```ini
[Unit]
Description=Example .NET Web API Application running on Ubuntu

[Service]
WorkingDirectory=/var/aspnetcore/hellomvc
ExecStart=/usr/bin/dotnet /var/aspnetcore/hellomvc/hellomvc.dll
Restart=always
RestartSec=10  # Restart service after 10 seconds if dotnet service crashes
SyslogIdentifier=dotnet-example
User=www-data
Environment=ASPNETCORE_ENVIRONMENT=Production 

[Install]
WantedBy=multi-user.target
```

**Note:** If the user *www-data* is not used by your configuration, the user defined here must be created first and given proper ownership for files.

Save the file, and enable the service.

```bash
systemctl enable kestrel-hellomvc.service
```

Start the service and verify that it is running.

```
systemctl start kestrel-hellomvc.service
systemctl status kestrel-hellomvc.service

● kestrel-hellomvc.service - Example .NET Web API Application running on Ubuntu
    Loaded: loaded (/etc/systemd/system/kestrel-hellomvc.service; enabled)
    Active: active (running) since Thu 2016-10-18 04:09:35 NZDT; 35s ago
Main PID: 9021 (dotnet)
    CGroup: /system.slice/kestrel-hellomvc.service
            └─9021 /usr/local/bin/dotnet /var/aspnetcore/hellomvc/hellomvc.dll
```

With the reverse proxy configured and Kestrel managed through systemd, the web application is fully configured and can be accessed from a browser on the local machine at `http://localhost`. It is also accessible from a remote machine, barring any firewall that might be blocking. Inspecting the response headers, the `Server` header shows the ASP.NET Core application being served by Kestrel.

```text
HTTP/1.1 200 OK
Date: Tue, 11 Oct 2016 16:22:23 GMT
Server: Kestrel
Keep-Alive: timeout=5, max=98
Connection: Keep-Alive
Transfer-Encoding: chunked
```

### Viewing logs

Since the web application using Kestrel is managed using `systemd`, all events and processes are logged to a centralized journal. However, this journal includes all entries for all services and processes managed by `systemd`. To view the `kestrel-hellomvc.service`-specific items, use the following command:

```bash
sudo journalctl -fu kestrel-hellomvc.service
```

For further filtering, time options such as `--since today`, `--until 1 hour ago` or a combination of these can reduce the amount of entries returned.

```bash
sudo journalctl -fu kestrel-hellomvc.service --since "2016-10-18" --until "2016-10-18 04:00"
```

## Securing our application

### Enable AppArmor

Linux Security Modules (LSM) is a framework that is part of the Linux kernel since Linux 2.6. LSM supports different implementations of security modules. [AppArmor](https://wiki.ubuntu.com/AppArmor) is a LSM that implements a Mandatory Access Control system which allows confining the program to a limited set of resources. Ensure AppArmor is enabled and properly configured.

### Configuring our firewall

Close off all external ports that are not in use. Uncomplicated firewall (ufw) provides a front end for `iptables` by providing a command line interface for configuring the firewall. Verify that `ufw` is configured to allow traffic on any ports you need.

```bash
sudo apt-get install ufw
sudo ufw enable

sudo ufw allow 80/tcp
sudo ufw allow 443/tcp
```

### Securing Nginx

The default distribution of Nginx doesn't enable SSL. To enable additional security features, build from source.

#### Download the source and install the build dependencies

```bash
# Install the build dependencies
sudo apt-get update
sudo apt-get install build-essential zlib1g-dev libpcre3-dev libssl-dev libxslt1-dev libxml2-dev libgd2-xpm-dev libgeoip-dev libgoogle-perftools-dev libperl-dev

# Download nginx 1.10.0 or latest
wget http://www.nginx.org/download/nginx-1.10.0.tar.gz
tar zxf nginx-1.10.0.tar.gz
```

#### Change the Nginx response name

Edit *src/http/ngx_http_header_filter_module.c*:

```c
static char ngx_http_server_string[] = "Server: Your Web Server" CRLF;
static char ngx_http_server_full_string[] = "Server: Your Web Server" CRLF;
```

#### Configure the options and build

The PCRE library is required for regular expressions. Regular expressions are used in the location directive for the ngx_http_rewrite_module. The http_ssl_module adds HTTPS protocol support.

Consider using a web application firewall like *ModSecurity* to harden your application.

```bash
./configure
--with-pcre=../pcre-8.38
--with-zlib=../zlib-1.2.8
--with-http_ssl_module
--with-stream
--with-mail=dynamic
```

#### Configure SSL

* Configure your server to listen to HTTPS traffic on port `443` by specifying a valid certificate issued by a trusted Certificate Authority (CA).

* Harden your security by employing some of the practices depicted in the following */etc/nginx/nginx.conf* file. Examples include choosing a stronger cipher and redirecting all traffic over HTTP to HTTPS.

* Adding an `HTTP Strict-Transport-Security` (HSTS) header ensures all subsequent requests made by the client are over HTTPS only.

* Do not add the Strict-Transport-Security header or chose an appropriate `max-age` if you plan to disable SSL in the future.

Add the */etc/nginx/proxy.conf* configuration file:

[!code-nginx[Main](linuxproduction/proxy.conf)]

Edit the */etc/nginx/nginx.conf* configuration file. The example contains both `http` and `server` sections in one configuration file.

[!code-nginx[Main](../publishing/linuxproduction/nginx.conf?highlight=2)]

#### Secure Nginx from clickjacking
Clickjacking is a malicious technique to collect an infected user's clicks. Clickjacking tricks the victim (visitor) into clicking on an infected site. Use X-FRAME-OPTIONS to secure your site.

Edit the *nginx.conf* file:

```bash
sudo nano /etc/nginx/nginx.conf
```

Add the line `add_header X-Frame-Options "SAMEORIGIN";` and save the file, then restart Nginx.

#### MIME-type sniffing

This header prevents most browsers from MIME-sniffing a response away from the declared content type, as the header instructs the browser not to override the response content type. With the `nosniff` option, if the server says the content is "text/html", the browser renders it as "text/html".

Edit the *nginx.conf* file:

```bash
sudo nano /etc/nginx/nginx.conf
```

Add the line `add_header X-Content-Type-Options "nosniff";` and save the file, then restart Nginx.
