---
title: Host ASP.NET Core on Linux with Apache
description: Learn how to set up Apache as a reverse proxy server on CentOS to redirect HTTP traffic to an ASP.NET Core web app running on Kestrel.
author: spboyer
manager: wpickett
ms.author: spboyer
ms.custom: mvc
ms.date: 10/19/2016
ms.prod: asp.net-core
ms.technology: aspnet
ms.topic: article
uid: host-and-deploy/linux-apache
---
# Host ASP.NET Core on Linux with Apache

By [Shayne Boyer](https://github.com/spboyer)

Using this guide, learn how to set up [Apache](https://httpd.apache.org/) as a reverse proxy server on [CentOS 7](https://www.centos.org/) to redirect HTTP traffic to an ASP.NET Core web app running on [Kestrel](xref:fundamentals/servers/kestrel). The [mod_proxy extension](http://httpd.apache.org/docs/2.4/mod/mod_proxy.html) and related modules create the server's reverse proxy.

## Prerequisites

1. Server running CentOS 7 with a standard user account with sudo privilege
2. ASP.NET Core app

## Publish the app

Publish the app as a [self-contained deployment](/dotnet/core/deploying/#self-contained-deployments-scd) in Release configuration for the CentOS 7 runtime (`centos.7-x64`). Copy the contents of the *bin/Release/netcoreapp2.0/centos.7-x64/publish* folder to the server using SCP, FTP, or other file transfer method.

> [!NOTE]
> Under a production deployment scenario, a continuous integration workflow does the work of publishing the app and copying the assets to the server. 

## Configure a proxy server

A reverse proxy is a common setup for serving dynamic web apps. The reverse proxy terminates the HTTP request and forwards it to the ASP.NET app.

A proxy server is one which forwards client requests to another server instead of fulfilling requests itself. A reverse proxy forwards to a fixed destination, typically on behalf of arbitrary clients. In this guide, Apache is configured as the reverse proxy running on the same server that Kestrel is serving the ASP.NET Core app.

Because requests are forwarded by reverse proxy, use the Forwarded Headers Middleware from the [Microsoft.AspNetCore.HttpOverrides](https://www.nuget.org/packages/Microsoft.AspNetCore.HttpOverrides/) package. The middleware updates the `Request.Scheme`, using the `X-Forwarded-Proto` header, so that redirect URIs and other security policies work correctly.

When using any type of authentication middleware, the Forwarded Headers Middleware must run first. This ordering ensures that the authentication middleware can consume the header values and generate correct redirect URIs.

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

Invoke the [UseForwardedHeaders](/dotnet/api/microsoft.aspnetcore.builder.forwardedheadersextensions.useforwardedheaders) method in `Startup.Configure` before calling [UseAuthentication](/dotnet/api/microsoft.aspnetcore.builder.authappbuilderextensions.useauthentication) or similar authentication scheme middleware:

```csharp
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseAuthentication();
```

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

Invoke the [UseForwardedHeaders](/dotnet/api/microsoft.aspnetcore.builder.forwardedheadersextensions.useforwardedheaders) method in `Startup.Configure` before calling [UseIdentity](/dotnet/api/microsoft.aspnetcore.builder.builderextensions.useidentity) and [UseFacebookAuthentication](/dotnet/api/microsoft.aspnetcore.builder.facebookappbuilderextensions.usefacebookauthentication) or similar authentication scheme middleware:

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

If no [ForwardedHeadersOptions](/dotnet/api/microsoft.aspnetcore.builder.forwardedheadersoptions) are specified to the middleware, the default headers to forward are `None`.

### Install Apache

Update CentOS packages to their latest stable versions:

```bash
sudo yum update -y
```

Install the Apache web server on CentOS with a single `yum` command:

```bash
sudo yum -y install httpd mod_ssl
```

Sample output after running the command:

```bash
Downloading packages:
httpd-2.4.6-40.el7.centos.4.x86_64.rpm               | 2.7 MB  00:00:01
Running transaction check
Running transaction test
Transaction test succeeded
Running transaction
Installing : httpd-2.4.6-40.el7.centos.4.x86_64      1/1 
Verifying  : httpd-2.4.6-40.el7.centos.4.x86_64      1/1 

Installed:
httpd.x86_64 0:2.4.6-40.el7.centos.4

Complete!
```

> [!NOTE]
> In this example, the output reflects httpd.86_64 since the CentOS 7 version is 64 bit. To verify where Apache is installed, run `whereis httpd` from a command prompt. 

### Configure Apache for reverse proxy

Configuration files for Apache are located within the `/etc/httpd/conf.d/` directory. Any file with the *.conf* extension is processed in alphabetical order in addition to the module configuration files in `/etc/httpd/conf.modules.d/`, which contains any configuration files necessary to load modules.

Create a configuration file for the app named `hellomvc.conf`:

```
<VirtualHost *:80>
    ProxyPreserveHost On
    ProxyPass / http://127.0.0.1:5000/
    ProxyPassReverse / http://127.0.0.1:5000/
    ErrorLog /var/log/httpd/hellomvc-error.log
    CustomLog /var/log/httpd/hellomvc-access.log common
</VirtualHost>
```

The **VirtualHost** node can appear multiple times in one or more files on a server. **VirtualHost** is set to listen on any IP address using port 80. The next two lines are set to proxy requests at the root to the server at 127.0.0.1 on port 5000. For bi-directional communication, *ProxyPass* and *ProxyPassReverse* are required.

Logging can be configured per **VirtualHost** using **ErrorLog** and **CustomLog** directives. **ErrorLog** is the location where the server logs errors, and **CustomLog** sets the filename and format of log file. In this case, this is where request information is logged. There's one line for each request.

Save the file and test the configuration. If everything passes, the response should be `Syntax [OK]`.

```bash
sudo service httpd configtest
```

Restart Apache:

```bash
sudo systemctl restart httpd
sudo systemctl enable httpd
```

## Monitoring the app

Apache is now setup to forward requests made to `http://localhost:80` to the ASP.NET Core app running on Kestrel at `http://127.0.0.1:5000`.  However, Apache isn't set up to manage the Kestrel process. Use *systemd* and create a service file to start and monitor the underlying web app. *systemd* is an init system that provides many powerful features for starting, stopping, and managing processes. 


### Create the service file

Create the service definition file:

```bash
sudo nano /etc/systemd/system/kestrel-hellomvc.service
```

An example service file for the app:

```
[Unit]
Description=Example .NET Web API App running on CentOS 7

[Service]
WorkingDirectory=/var/aspnetcore/hellomvc
ExecStart=/usr/local/bin/dotnet /var/aspnetcore/hellomvc/hellomvc.dll
Restart=always
# Restart service after 10 seconds if dotnet service crashes
RestartSec=10
SyslogIdentifier=dotnet-example
User=apache
Environment=ASPNETCORE_ENVIRONMENT=Production 

[Install]
WantedBy=multi-user.target
```

> [!NOTE]
> **User** &mdash; If the user *apache* isn't used by the configuration, the user must be created first and given proper ownership for files.

Save the file and enable the service:

```bash
systemctl enable kestrel-hellomvc.service
```

Start the service and verify that it's running:

```bash
systemctl start kestrel-hellomvc.service
systemctl status kestrel-hellomvc.service

● kestrel-hellomvc.service - Example .NET Web API App running on CentOS 7
    Loaded: loaded (/etc/systemd/system/kestrel-hellomvc.service; enabled)
    Active: active (running) since Thu 2016-10-18 04:09:35 NZDT; 35s ago
Main PID: 9021 (dotnet)
    CGroup: /system.slice/kestrel-hellomvc.service
            └─9021 /usr/local/bin/dotnet /var/aspnetcore/hellomvc/hellomvc.dll
```

With the reverse proxy configured and Kestrel managed through *systemd*, the web app is fully configured and can be accessed from a browser on the local machine at `http://localhost`. Inspecting the response headers, the **Server** header indicates that the ASP.NET Core app is served by Kestrel:

```
HTTP/1.1 200 OK
Date: Tue, 11 Oct 2016 16:22:23 GMT
Server: Kestrel
Keep-Alive: timeout=5, max=98
Connection: Keep-Alive
Transfer-Encoding: chunked
```

### Viewing logs

Since the web app using Kestrel is managed using *systemd*, events and processes are logged to a centralized journal. However, this journal includes entries for all of the services and processes managed by *systemd*. To view the `kestrel-hellomvc.service`-specific items, use the following command:

```bash
sudo journalctl -fu kestrel-hellomvc.service
```

For time filtering, specify time options with the command. For example, use `--since today` to filter for the current day or `--until 1 hour ago` to see the previous hour's entries. For more information, see the [man page for journalctl](https://www.unix.com/man-page/centos/1/journalctl/).

```bash
sudo journalctl -fu kestrel-hellomvc.service --since "2016-10-18" --until "2016-10-18 04:00"
```

## Securing the app

### Configure firewall

*Firewalld* is a dynamic daemon to manage the firewall with support for network zones. Ports and packet filtering can still be managed by iptables. *Firewalld* should be installed by default. `yum` can be used to install the package or verify it's installed.

```bash
sudo yum install firewalld -y
```

Use `firewalld` to open only the ports needed for the app. In this case, port 80 and 443 are used. The following commands permanently set ports 80 and 443 to open:

```bash
sudo firewall-cmd --add-port=80/tcp --permanent
sudo firewall-cmd --add-port=443/tcp --permanent
```

Reload the firewall settings. Check the available services and ports in the default zone. Options are available by inspecting `firewall-cmd -h`.

```bash 
sudo firewall-cmd --reload
sudo firewall-cmd --list-all
```

```bash
public (default, active)
interfaces: eth0
sources: 
services: dhcpv6-client
ports: 443/tcp 80/tcp
masquerade: no
forward-ports: 
icmp-blocks: 
rich rules: 
```

### SSL configuration

To configure Apache for SSL, the *mod_ssl* module is used. When the *httpd* module was installed, the *mod_ssl* module was also installed. If it wasn't installed, use `yum` to add it to the configuration.

```bash
sudo yum install mod_ssl
```
To enforce SSL, install the `mod_rewrite` module to enable URL rewriting:

```bash
sudo yum install mod_rewrite
```

Modify the *hellomvc.conf* file to enable URL rewriting and secure communication on port 443:

```
<VirtualHost *:80>
    RewriteEngine On
    RewriteCond %{HTTPS} !=on
    RewriteRule ^/?(.*) https://%{SERVER_NAME}/ [R,L]
</VirtualHost>

<VirtualHost *:443>
    ProxyPreserveHost On
    ProxyPass / http://127.0.0.1:5000/
    ProxyPassReverse / http://127.0.0.1:5000/
    ErrorLog /var/log/httpd/hellomvc-error.log
    CustomLog /var/log/httpd/hellomvc-access.log common
    SSLEngine on
    SSLProtocol all -SSLv2
    SSLCipherSuite ALL:!ADH:!EXPORT:!SSLv2:!RC4+RSA:+HIGH:+MEDIUM:!LOW:!RC4
    SSLCertificateFile /etc/pki/tls/certs/localhost.crt
    SSLCertificateKeyFile /etc/pki/tls/private/localhost.key
</VirtualHost>
```

> [!NOTE]
> This example is using a locally-generated certificate. **SSLCertificateFile** should be the primary certificate file for the domain name. **SSLCertificateKeyFile** should be the key file generated when CSR is created. **SSLCertificateChainFile** should be the intermediate certificate file (if any) that was supplied by the certificate authority.

Save the file and test the configuration:

```bash
sudo service httpd configtest
```

Restart Apache:

```bash
sudo systemctl restart httpd
```

## Additional Apache suggestions

### Additional headers

In order to secure against malicious attacks, there are a few headers that should either be modified or added. Ensure that the `mod_headers` module is installed:

```bash
sudo yum install mod_headers
```

#### Secure Apache from clickjacking attacks

[Clickjacking](https://blog.qualys.com/securitylabs/2015/10/20/clickjacking-a-common-implementation-mistake-that-can-put-your-websites-in-danger), also known as a *UI redress attack*, is a malicious attack where a website visitor is tricked into clicking a link or button on a different page than they're currently visiting. Use `X-FRAME-OPTIONS` to secure the site.

Edit the *httpd.conf* file:

```bash
sudo nano /etc/httpd/conf/httpd.conf
```

Add the line `Header append X-FRAME-OPTIONS "SAMEORIGIN"`. Save the file. Restart Apache.

#### MIME-type sniffing

The `X-Content-Type-Options` header prevents Internet Explorer from *MIME-sniffing* (determing a file's `Content-Type` from the file's content). If the server sets the `Content-Type` header to `text/html` with the `nosniff` option set, Internet Explorer renders the content as `text/html` regardless of the file's content.

Edit the *httpd.conf* file:

```bash
sudo nano /etc/httpd/conf/httpd.conf
```

Add the line `Header set X-Content-Type-Options "nosniff"`. Save the file. Restart Apache.

### Load Balancing 

This example shows how to setup and configure Apache on CentOS 7 and Kestrel on the same instance machine. In order to not have a single point of failure; using *mod_proxy_balancer* and modifying the **VirtualHost** would allow for managing mutliple instances of the web apps behind the Apache proxy server.

```bash
sudo yum install mod_proxy_balancer
```

In the configuration file shown below, an additional instance of the `hellomvc` app is setup to run on port 5001. The *Proxy* section is set with a balancer configuration with two members to load balance *byrequests*.

```
<VirtualHost *:80>
    RewriteEngine On
    RewriteCond %{HTTPS} !=on
    RewriteRule ^/?(.*) https://%{SERVER_NAME}/ [R,L]
</VirtualHost>

<VirtualHost *:443>
    ProxyPass / balancer://mycluster/ 

    ProxyPassReverse / http://127.0.0.1:5000/
    ProxyPassReverse / http://127.0.0.1:5001/

    <Proxy balancer://mycluster>
        BalancerMember http://127.0.0.1:5000
        BalancerMember http://127.0.0.1:5001 
        ProxySet lbmethod=byrequests
    </Proxy>

    <Location />
        SetHandler balancer
    </Location>
    ErrorLog /var/log/httpd/hellomvc-error.log
    CustomLog /var/log/httpd/hellomvc-access.log common
    SSLEngine on
    SSLProtocol all -SSLv2
    SSLCipherSuite ALL:!ADH:!EXPORT:!SSLv2:!RC4+RSA:+HIGH:+MEDIUM:!LOW:!RC4
    SSLCertificateFile /etc/pki/tls/certs/localhost.crt
    SSLCertificateKeyFile /etc/pki/tls/private/localhost.key
</VirtualHost>
```

### Rate Limits
Using *mod_ratelimit*, which is included in the *httpd* module, the bandwidth of clients can be limited:

```bash
sudo nano /etc/httpd/conf.d/ratelimit.conf
```
The example file limits bandwidth as 600 KB/sec under the root location:

```
<IfModule mod_ratelimit.c>
    <Location />
        SetOutputFilter RATE_LIMIT
        SetEnv rate-limit 600
    </Location>
</IfModule>
```
