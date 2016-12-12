---
title: Publish to a Linux Production Environment | Microsoft Docs
description: Describes how to setup nginx as a reverse proxy on Ubuntu 14.04 to forward HTTP traffic to an ASP.NET Core web application running on Kestrel. 
keywords: ASP.NET, .NET, Linux, nginx, Ubuntu, Reverse Proxy
author: rick-anderson
description: 
keywords: ASP.NET Core,
ms.author: riande
manager: wpickett
ms.date: 10/14/2016
ms.topic: article
ms.assetid: 1c33e576-33de-481a-8ad3-896b94fde0e3
ms.technology: aspnet
ms.prod: aspnet-core
uid: publishing/linuxproduction
---
# Publish to a Linux Production Environment

By [Sourabh Shirhatti](https://twitter.com/sshirhatti)

In this guide, we will cover setting up a production-ready ASP.NET environment on an Ubuntu 14.04 Server.

We will take an existing ASP.NET Core application and place it behind a reverse-proxy server. We will then setup the reverse-proxy server to forward requests to our Kestrel web server.

Additionally we will ensure our web application runs on startup as a daemon and configure a process management tool to help restart our web application in the event of a crash to guarantee high availability.

## Prerequisites

1. Access to an Ubuntu 14.04 Server with a standard user account with sudo privilege.

2. An existing ASP.NET Core application.

## Copy over your app

Run `dotnet publish` from your dev environment to package your application into a self-contained directory that can run on your server.

Before we proceed, copy your ASP.NET Core application to your server using whatever tool (SCP, FTP, etc) integrates into your workflow. Try and run the app and navigate to `http://<serveraddress>:<port>` in your browser to see if the application runs fine on Linux. I recommend you have a working app before proceeding.

> [!NOTE]
> You can use [Yeoman](../client-side/yeoman.md) to create a new ASP.NET Core application for a new project.

## Configure a reverse proxy server

A reverse proxy is a common setup for serving dynamic web applications. The reverse proxy terminates the HTTP request and forwards it to the ASP.NET application.

### Why use a reverse-proxy server?

Kestrel is great for serving dynamic content from ASP.NET, however the web serving parts aren’t as feature rich as full-featured servers like IIS, Apache or Nginx. A reverse proxy-server can allow you to offload work like serving static content, caching requests, compressing requests, and SSL termination from the HTTP server. The reverse proxy server may reside on a dedicated machine or may be deployed alongside an HTTP server.

For the purposes of this guide, we are going to use a single instance of Nginx that runs on the same server alongside your HTTP server. However, based on your requirements you may choose a different setup.

When setting up a reverse-proxy server other than IIS, you must call `app.UseIdentity` (in `Configure`) before any other external providers.

Because requests are forwarded by reverse-proxy, use `ForwardedHeaders` middleware (from `Microsoft.AspNetCore.HttpOverrides` package) in order to set the  redirect URI with the `X-Forwarded-For` and `X-Forwarded-Proto` headers instead of `Request.Scheme` and `Request.Host`."

Add `UseForwardedHeaders` to `Configure` before calling `app.UseFacebookAuthentication` or similar:

```csharp
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
```

### Install Nginx

```
sudo apt-get install nginx
```

> [!NOTE]
> If you plan to install optional Nginx modules you may be required to build Nginx from source.

We are going to `apt-get` to install Nginx. The installer also creates a System V init script that runs Nginx as daemon on system startup. Since we just installed Nginx for the first time, we can explicitly start it by running

```bash
sudo service nginx start
```

At this point you should be able to navigate to your browser and see the default landing page for Nginx.

### Configure Nginx

We will now configure Nginx as a reverse proxy to forward requests to our ASP.NET application

We will be modifying the `/etc/nginx/sites-available/default`, so open it up in your favorite text editor and replace the contents with the following.

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

This is one of the simplest configuration files for Nginx that forwards incoming public traffic on your port `80` to a port `5000` that your web application will listen on.

Once you have completed making changes to your nginx configuration you can run `sudo nginx -t` to verify the syntax of your configuration files. If the configuration file test is successful you can ask nginx to pick up the changes by running `sudo nginx -s reload`.

## Monitoring our application

Nginx is now setup to forward requests made to `http://localhost:80` on to the ASP.NET Core application running on Kestrel at `http://127.0.0.1:5000`.  However, Nginx is not set up to manage the Kestrel process. We will use *systemd* and create a service file to start and monitor the underlying web app. *systemd* is an init system that provides many powerful features for starting, stopping and managing processes. 

### Create the service file

Create the service definition file 

```bash
    sudo nano /etc/systemd/system/kestrel-hellomvc.service
```

An example service file for our application.

```text
[Unit]
    Description=Example .NET Web API Application running on Ubuntu

    [Service]
    ExecStart=/usr/bin/dotnet /var/aspnetcore/hellomvc/hellomvc.dll
    Restart=always
    RestartSec=10                                          # Restart service after 10 seconds if dotnet service crashes
    SyslogIdentifier=dotnet-example
    User=www-data
    Environment=ASPNETCORE_ENVIRONMENT=Production 

    [Install]
    WantedBy=multi-user.target
```

> [!NOTE]
> **User** -- If the user *www-data* is not used by your configuration, the user defined here must be created first and given proper ownership for files

Save the file and enable the service.

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

With the reverse proxy configured and Kestrel managed through systemd, the web application is fully configured and can be accessed from a browser on the local machine at `http://localhost`. Inspecting the response headers, the **Server** still shows the ASP.NET Core application being served by Kestrel.

```text
    HTTP/1.1 200 OK
    Date: Tue, 11 Oct 2016 16:22:23 GMT
    Server: Kestrel
    Keep-Alive: timeout=5, max=98
    Connection: Keep-Alive
    Transfer-Encoding: chunked
```

### Viewing logs

Since the web application using Kestrel is managed using systemd, all events and processes are logged to a centralized journal. However, this journal includes all entries for all services and processes managed by systemd. To view the `kestrel-hellomvc.service` specific items, use the following command.

```bash
    sudo journalctl -fu kestrel-hellomvc.service
```

For further filtering, time options such as `--since today`, `--until 1 hour ago` or a combination of these can reduce the amount of entries returned.

```bash
    sudo journalctl -fu kestrel-hellomvc.service --since "2016-10-18" --until "2016-10-18 04:00"
```

## Securing our application

### Enable `AppArmor`

Linux Security Modules (LSM) is a framework that is part of the Linux kernel since Linux 2.6 that supports different implementations of security modules. `AppArmor` is a LSM that implements a Mandatory Access Control system which allows you to confine the program to a limited set of resources. Ensure [AppArmor](https://wiki.ubuntu.com/AppArmor) is enabled and properly configured.

### Configuring our firewall

Close off all external ports that are not in use. Uncomplicated firewall (ufw) provides a frontend for `iptables` by providing a command-line interface for configuring the firewall. Verify that `ufw` is configured to allow traffic on any ports you need.

```bash
sudo apt-get install ufw
sudo ufw enable

sudo ufw allow 80/tcp
sudo ufw allow 443/tcp
```

### Securing Nginx

The default distribution of Nginx doesn't enable SSL. To enable all the security features we require, we will build from source.

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

Edit *src/http/ngx_http_header_filter_module.c*

```c
static char ngx_http_server_string[] = "Server: Your Web Server" CRLF;
static char ngx_http_server_full_string[] = "Server: Your Web Server" CRLF;
```

#### Configure the options and build

The PCRE library is required for regular expressions. Regular expressions are used in the  location  directive for the ngx_http_rewrite_module. The http_ssl_module adds HTTPS protocol support.

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

* Harden your security by employing some of the practices suggested below like choosing a stronger cipher and redirecting all traffic over HTTP to HTTPS.

* Adding an `HTTP Strict-Transport-Security` (HSTS) header ensures all subsequent requests made by the client are over HTTPS only.

* Do not add the Strict-Transport-Security header or chose an appropriate `max-age` if you plan to disable SSL in the future.

Add `/etc/nginx/proxy.conf` configuration file.

[!code-nginx[Main](linuxproduction/proxy.conf)]

Edit `/etc/nginx/nginx.conf` configuration file. The example contains both http and server sections in one configuration file.

[!code-nginx[Main](../publishing/linuxproduction/nginx.conf?highlight=2)]

#### Secure Nginx from clickjacking
Clickjacking is a malicious technique to collect an infected user's clicks. Clickjacking tricks the victim (visitor) into clicking on an infected site. Use X-FRAME-OPTIONS to secure your site.

Edit the nginx.conf file.

```bash
    sudo nano /etc/nginx/nginx.conf
```

Add the the line `add_header X-Frame-Options "SAMEORIGIN";` and save the file, then restart Nginx.

#### MIME-type sniffing

This header prevents Internet Explorer from MIME-sniffing a response away from the declared content-type as the header instructs the browser not to override the response content type. With the nosniff option, if the server says the content is text/html, the browser will render it as text/html.

Edit the nginx.conf file.

```bash
    sudo nano /etc/nginx/nginx.conf
```

Add the the line `add_header X-Content-Type-Options "nosniff"` and save the file, then restart Nginx.
