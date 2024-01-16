---
title: Host ASP.NET Core on Linux with Apache
author: rick-anderson
description: Learn how to set up Apache as a reverse proxy server on CentOS to redirect HTTP traffic to an ASP.NET Core web app running on Kestrel.
monikerRange: '>= aspnetcore-2.1'
ms.author: shboyer
ms.custom: mvc
ms.date: 04/10/2020
uid: host-and-deploy/linux-apache
---
# Host ASP.NET Core on Linux with Apache

By [Shayne Boyer](https://github.com/spboyer)

Using this guide, learn how to set up [Apache](https://httpd.apache.org/) as a reverse proxy server on [CentOS 7](https://www.centos.org/) to redirect HTTP traffic to an ASP.NET Core web app running on [Kestrel](xref:fundamentals/servers/kestrel) server. The [mod_proxy extension](https://httpd.apache.org/docs/2.4/mod/mod_proxy.html) and related modules create the server's reverse proxy.

## Prerequisites

* Server running CentOS 7 with a standard user account with sudo privilege.
* Install the .NET Core runtime on the server.
   1. Visit the [Download .NET Core page](https://dotnet.microsoft.com/download/dotnet-core).
   1. Select the latest non-preview .NET Core version.
   1. Download the latest non-preview runtime in the table under **Run apps - Runtime**.
   1. Select the Linux **Package manager instructions** link and follow the CentOS instructions.
* An existing ASP.NET Core app.

At any point in the future after upgrading the shared framework, restart the ASP.NET Core apps hosted by the server.

## Publish and copy over the app

Configure the app for a [framework-dependent deployment](/dotnet/core/deploying/#framework-dependent-deployments-fdd).

If the app is run locally in the [Development environment](xref:fundamentals/environments#configure-services-and-middleware-by-environment) and isn't configured by the server to make secure HTTPS connections, adopt either of the following approaches:

* Configure the app to handle secure local connections. For more information, see the [HTTPS configuration](#https-configuration) section.

* Configure the app to run at the insecure endpoint:

  * Deactivate HTTPS Redirection Middleware in the Development environment (`Program.cs`):

    ```csharp
    if (!app.Environment.IsDevelopment())
    {
        app.UseHttpsRedirection();
    }
    ```

    For more information, see <xref:fundamentals/environments#configure-services-and-middleware-by-environment>.

  * Remove `https://localhost:5001` (if present) from the `applicationUrl` property in the `Properties/launchSettings.json` file.

For more information on configuration by environment, see <xref:fundamentals/environments>.

Run [dotnet publish](/dotnet/core/tools/dotnet-publish) from the development environment to package an app into a directory (for example, `bin/Release/{TARGET FRAMEWORK MONIKER}/publish`, where the `{TARGET FRAMEWORK MONIKER}` placeholder is the [Target Framework Moniker (TFM)](/dotnet/standard/frameworks)) that can run on the server:

```dotnetcli
dotnet publish --configuration Release
```

The app can also be published as a [self-contained deployment](/dotnet/core/deploying/#self-contained-deployments-scd) if you prefer not to maintain the .NET Core runtime on the server.

Copy the ASP.NET Core app to the server using a tool that integrates into the organization's workflow (for example, SCP, SFTP). It's common to locate web apps under the *var* directory (for example, *var/www/helloapp*).

> [!NOTE]
> Under a production deployment scenario, a continuous integration workflow does the work of publishing the app and copying the assets to the server.

## Configure a proxy server

A reverse proxy is a common setup for serving dynamic web apps. The reverse proxy terminates the HTTP request and forwards it to the ASP.NET app.

A proxy server forwards client requests to another server instead of fulfilling requests itself. A reverse proxy forwards to a fixed destination, typically on behalf of arbitrary clients. In this guide, Apache is configured as the reverse proxy running on the same server that Kestrel is serving the ASP.NET Core app.

Because requests are forwarded by reverse proxy, use the [Forwarded Headers Middleware](xref:host-and-deploy/proxy-load-balancer) from the [Microsoft.AspNetCore.HttpOverrides](https://www.nuget.org/packages/Microsoft.AspNetCore.HttpOverrides/) package. The middleware updates the `Request.Scheme`, using the `X-Forwarded-Proto` header, so that redirect URIs and other security policies work correctly.

Any component that depends on the scheme, such as authentication, link generation, redirects, and geolocation, must be placed after invoking the Forwarded Headers Middleware.

[!INCLUDE[](~/includes/ForwardedHeaders.md)]

Invoke the <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersExtensions.UseForwardedHeaders%2A> method at the top of `Startup.Configure` before calling other middleware. Configure the middleware to forward the `X-Forwarded-For` and `X-Forwarded-Proto` headers.

Add the <xref:Microsoft.AspNetCore.HttpOverrides?displayProperty=fullName> namespace to the top of the file:

```csharp
using Microsoft.AspNetCore.HttpOverrides;
```

In the app processing pipeline:

```csharp
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseAuthentication();
```

If no <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions> are specified to the middleware, the default headers to forward are `None`.

Proxies running on loopback addresses (`127.0.0.0/8, [::1]`), including the standard localhost address (127.0.0.1), are trusted by default. If other trusted proxies or networks within the organization handle requests between the Internet and the web server, add them to the list of <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.KnownProxies%2A> or <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.KnownNetworks%2A> with <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions>. The following example adds a trusted proxy server at IP address 10.0.0.100 to the Forwarded Headers Middleware `KnownProxies` in `Startup.ConfigureServices`:

Add the <xref:System.Net?displayProperty=fullName> namespace to the top of the file:

```csharp
using System.Net;
```

Use the following service registration:

```csharp
services.Configure<ForwardedHeadersOptions>(options =>
{
    options.KnownProxies.Add(IPAddress.Parse("10.0.0.100"));
});
```

For more information, see <xref:host-and-deploy/proxy-load-balancer>.

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

### Configure Apache

Configuration files for Apache are located within the `/etc/httpd/conf.d/` directory. In Apache on Ubuntu, all the virtual host configuration files are stored in `/etc/apache2/sites-available`. Any file with the *.conf* extension is processed in alphabetical order in addition to the module configuration files in `/etc/httpd/conf.modules.d/`, which contains any configuration files necessary to load modules.

Create a configuration file, named *helloapp.conf*, for the app:

```
<VirtualHost *:*>
    RequestHeader set "X-Forwarded-Proto" expr=%{REQUEST_SCHEME}s
</VirtualHost>

<VirtualHost *:80>
    ProxyPreserveHost On
    ProxyPass / http://127.0.0.1:5000/
    ProxyPassReverse / http://127.0.0.1:5000/
    ServerName www.example.com
    ServerAlias *.example.com
    ErrorLog ${APACHE_LOG_DIR}/helloapp-error.log
    CustomLog ${APACHE_LOG_DIR}/helloapp-access.log common
</VirtualHost>
```

Note: Apache versions before 2.4.6 don't require the `RequestHeader set` contain the trailing `s`:

```
<VirtualHost *:*>
    RequestHeader set "X-Forwarded-Proto" expr=%{REQUEST_SCHEME}
</VirtualHost>
```

For more information, see `%{VARNAME}s` in [Apache Module mod_headers](https://httpd.apache.org/docs/2.4/mod/mod_headers.html).
:::moniker range=">= aspnetcore-5.0"

The `VirtualHost` block can appear multiple times, in one or more files on a server. In the preceding configuration file, Apache accepts public traffic on port 80. The domain `www.example.com` is being served, and the `*.example.com` alias resolves to the same website. For more information, see [Name-based virtual host support](https://httpd.apache.org/docs/current/vhosts/name-based.html). Requests are proxied at the root to port 5000 of the server at 127.0.0.1. For bi-directional communication, `ProxyPass` and `ProxyPassReverse` are required. To change Kestrel's IP/port, see [Kestrel: Endpoint configuration](xref:fundamentals/servers/kestrel/endpoints).

:::moniker-end

:::moniker range="< aspnetcore-5.0"

The `VirtualHost` block can appear multiple times, in one or more files on a server. In the preceding configuration file, Apache accepts public traffic on port 80. The domain `www.example.com` is being served, and the `*.example.com` alias resolves to the same website. For more information, see [Name-based virtual host support](https://httpd.apache.org/docs/current/vhosts/name-based.html). Requests are proxied at the root to port 5000 of the server at 127.0.0.1. For bi-directional communication, `ProxyPass` and `ProxyPassReverse` are required. To change Kestrel's IP/port, see [Kestrel: Endpoint configuration](xref:fundamentals/servers/kestrel#endpoint-configuration).

Create a symbolic link to the `/etc/apache2/sites-enabled` directory for Apache to read during startup:

```bash
sudo ln -s /etc/apache2/sites-available/helloapp.conf /etc/apache2/sites-enabled/
```

:::moniker-end

> [!WARNING]
> Failure to specify a proper [ServerName directive](https://httpd.apache.org/docs/current/mod/core.html#servername) in the **VirtualHost** block exposes your app to security vulnerabilities. Subdomain wildcard binding (for example, `*.example.com`) doesn't pose this security risk if you control the entire parent domain (as opposed to `*.com`, which is vulnerable). For more information, see [RFC 9110: HTTP Semantics (Section 7.2: Host and :authority)](https://www.rfc-editor.org/rfc/rfc9110#field.host).

Logging can be configured per `VirtualHost` using `ErrorLog` and `CustomLog` directives. `ErrorLog` is the location where the server logs errors, and `CustomLog` sets the filename and format of log file. In this case, this is where request information is logged. There's one line for each request.

Save the file and test the configuration. If everything passes, the response should be `Syntax [OK]`.

```bash
sudo apachectl configtest
```

Restart Apache:

```bash
sudo systemctl restart httpd
sudo systemctl enable httpd
```

For more information on header directive values, see [Apache Module mod_headers](https://httpd.apache.org/docs/2.4/mod/mod_headers.html).

## Monitor the app

Apache is now set up to forward requests made to `http://localhost:80` to the ASP.NET Core app running on Kestrel at `http://127.0.0.1:5000`. However, Apache isn't set up to manage the Kestrel process. Use *systemd* and create a service file to start and monitor the underlying web app. *systemd* is an init system that provides many powerful features for starting, stopping, and managing processes.

### Create the service file

Create the service definition file:

```bash
sudo nano /etc/systemd/system/kestrel-helloapp.service
```

An example service file for the app:

```
[Unit]
Description=Example .NET Web API App running on CentOS 7

[Service]
WorkingDirectory=/var/www/helloapp
ExecStart=/usr/local/bin/dotnet /var/www/helloapp/helloapp.dll
Restart=always
# Restart service after 10 seconds if the dotnet service crashes:
RestartSec=10
KillSignal=SIGINT
SyslogIdentifier=dotnet-example
User=apache
Environment=ASPNETCORE_ENVIRONMENT=Production 

[Install]
WantedBy=multi-user.target
```

**Note:** Set the `local/bin` folder for your distribution. Some versions of Ubuntu require `ExecStart=/usr/bin/dotnet `

In the preceding example, the user that manages the service is specified by the `User` option. The user (`apache`) must exist and have proper ownership of the app's files.

Use `TimeoutStopSec` to configure the duration of time to wait for the app to shut down after it receives the initial interrupt signal. If the app doesn't shut down in this period, SIGKILL is issued to terminate the app. Provide the value as unitless seconds (for example, `150`), a time span value (for example, `2min 30s`), or `infinity` to disable the timeout. `TimeoutStopSec` defaults to the value of `DefaultTimeoutStopSec` in the manager configuration file (*systemd-system.conf*, *system.conf.d*, *systemd-user.conf*, *user.conf.d*). The default timeout for most distributions is 90 seconds.

```
# The default value is 90 seconds for most distributions.
TimeoutStopSec=90
```

Some values (for example, SQL connection strings) must be escaped for the configuration providers to read the environment variables. Use the following command to generate a properly escaped value for use in the configuration file:

```console
systemd-escape "<value-to-escape>"
```

:::moniker range=">= aspnetcore-3.0"

Colon (`:`) separators aren't supported in environment variable names. Use a double underscore (`__`) in place of a colon. The [Environment Variables configuration provider](xref:fundamentals/configuration/index#evcp) converts double-underscores into colons when environment variables are read into configuration. In the following example, the connection string key `ConnectionStrings:DefaultConnection` is set into the service definition file as `ConnectionStrings__DefaultConnection`:

:::moniker-end

:::moniker range="< aspnetcore-3.0"

Colon (`:`) separators aren't supported in environment variable names. Use a double underscore (`__`) in place of a colon. The [Environment Variables configuration provider](xref:fundamentals/configuration/index#environment-variables) converts double-underscores into colons when environment variables are read into configuration. In the following example, the connection string key `ConnectionStrings:DefaultConnection` is set into the service definition file as `ConnectionStrings__DefaultConnection`:

:::moniker-end

```
Environment=ConnectionStrings__DefaultConnection={Connection String}
```

Save the file and enable the service:

```bash
sudo systemctl enable kestrel-helloapp.service
```

Start the service and verify that it's running:

```bash
sudo systemctl start kestrel-helloapp.service
sudo systemctl status kestrel-helloapp.service

◝ kestrel-helloapp.service - Example .NET Web API App running on CentOS 7
    Loaded: loaded (/etc/systemd/system/kestrel-helloapp.service; enabled)
    Active: active (running) since Thu 2016-10-18 04:09:35 NZDT; 35s ago
Main PID: 9021 (dotnet)
    CGroup: /system.slice/kestrel-helloapp.service
            └─9021 /usr/local/bin/dotnet /var/www/helloapp/helloapp.dll
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

### View logs

Since the web app using Kestrel is managed using *systemd*, events and processes are logged to a centralized journal. However, this journal includes entries for all of the services and processes managed by *systemd*. To view the `kestrel-helloapp.service`-specific items, use the following command:

```bash
sudo journalctl -fu kestrel-helloapp.service
```

For time filtering, specify time options with the command. For example, use `--since today` to filter for the current day or `--until 1 hour ago` to see the previous hour's entries. For more information, see the [man page for journalctl](https://www.unix.com/man-page/centos/1/journalctl/).

```bash
sudo journalctl -fu kestrel-helloapp.service --since "2016-10-18" --until "2016-10-18 04:00"
```

## Data protection

The [ASP.NET Core Data Protection stack](xref:security/data-protection/introduction) is used by several ASP.NET Core [middlewares](xref:fundamentals/middleware/index), including authentication middleware (for example, cookie middleware) and cross-site request forgery (CSRF) protections. Even if Data Protection APIs aren't called by user code, data protection should be configured to create a persistent cryptographic [key store](xref:security/data-protection/implementation/key-management). If data protection isn't configured, the keys are held in memory and discarded when the app restarts.

If the key ring is stored in memory when the app restarts:

* All cookie-based authentication tokens are invalidated.
* Users are required to sign in again on their next request.
* Any data protected with the key ring can no longer be decrypted. This may include [CSRF tokens](xref:security/anti-request-forgery#aspnet-core-antiforgery-configuration) and [ASP.NET Core MVC TempData cookies](xref:fundamentals/app-state#tempdata).

To configure data protection to persist and encrypt the key ring, see:

* <xref:security/data-protection/implementation/key-storage-providers>
* <xref:security/data-protection/implementation/key-encryption-at-rest>

## Secure the app

### Configure firewall

*Firewalld* is a dynamic daemon to manage the firewall with support for network zones. Ports and packet filtering can still be managed by iptables. *Firewalld* should be installed by default. `yum` can be used to install the package or verify it's installed.

```bash
sudo yum install firewalld -y
```

Use `firewalld` to open only the ports needed for the app. In this case, ports 80 and 443 are used. The following commands permanently set ports 80 and 443 to open:

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

### HTTPS configuration

**Configure the app for secure (HTTPS) local connections**

The [dotnet run](/dotnet/core/tools/dotnet-run) command uses the app's `Properties/launchSettings.json` file, which configures the app to listen on the URLs provided by the `applicationUrl` property (for example, `https://localhost:5001;http://localhost:5000`).

Configure the app to use a certificate in development for the `dotnet run` command or development environment (F5 or Ctrl+F5 in Visual Studio Code) using one of the following approaches:

:::moniker range=">= aspnetcore-5.0"

* [Replace the default certificate from configuration](xref:fundamentals/servers/kestrel/endpoints#configuration) (*Recommended*)
* [KestrelServerOptions.ConfigureHttpsDefaults](xref:fundamentals/servers/kestrel/endpoints#configurehttpsdefaultsactionhttpsconnectionadapteroptions)

:::moniker-end

:::moniker range="< aspnetcore-5.0"

* [Replace the default certificate from configuration](xref:fundamentals/servers/kestrel#configuration) (*Recommended*)
* [KestrelServerOptions.ConfigureHttpsDefaults](xref:fundamentals/servers/kestrel#configurehttpsdefaultsactionhttpsconnectionadapteroptions)

:::moniker-end

**Configure the reverse proxy for secure (HTTPS) client connections**

> [!WARNING]
> The security configuration in this section is a general configuration to be used as a starting point for further customization. We're unable to provide support for third-party tooling, servers, and operating systems. *Use the configuration in this section at your own risk.* For more information, access the following resources:
>
* [Apache SSL/TLS Encryption](https://httpd.apache.org/docs/trunk/ssl/) (Apache documentation)
* [mozilla.org SSL Configuration Generator](https://ssl-config.mozilla.org/#server=apache)

To configure Apache for HTTPS, the *mod_ssl* module is used. When the *httpd* module was installed, the *mod_ssl* module was also installed. If it wasn't installed, use `yum` to add it to the configuration.

```bash
sudo yum install mod_ssl
```

To enforce HTTPS, install the `mod_rewrite` module to enable URL rewriting:

```bash
sudo yum install mod_rewrite
```

Modify the *helloapp.conf* file to enable secure communication on port 443.

The following example doesn't configure the server to redirect insecure requests. We recommend using HTTPS Redirection Middleware. For more information, see <xref:security/enforcing-ssl>.

> [!NOTE]
> For development environments where the server configuration handles secure redirection instead of HTTPS Redirection Middleware, we recommend using temporary redirects (302) rather than permanent redirects (301). Link caching can cause unstable behavior in development environments.

Adding a `Strict-Transport-Security` (HSTS) header ensures all subsequent requests made by the client are over HTTPS. For guidance on setting the `Strict-Transport-Security` header, see <xref:security/enforcing-ssl#http-strict-transport-security-protocol-hsts>.

```
<VirtualHost *:*>
    RequestHeader set "X-Forwarded-Proto" expr=%{REQUEST_SCHEME}
</VirtualHost>

<VirtualHost *:443>
    Protocols             h2 http/1.1
    ProxyPreserveHost     On
    ProxyPass             / http://127.0.0.1:5000/
    ProxyPassReverse      / http://127.0.0.1:5000/
    ErrorLog              /var/log/httpd/helloapp-error.log
    CustomLog             /var/log/httpd/helloapp-access.log common
    SSLEngine             on
    SSLProtocol           all -SSLv3 -TLSv1 -TLSv1.1
    SSLHonorCipherOrder   off
    SSLCompression        off
    SSLSessionTickets     on
    SSLUseStapling        off
    SSLCertificateFile    /etc/pki/tls/certs/localhost.crt
    SSLCertificateKeyFile /etc/pki/tls/private/localhost.key
    SSLCipherSuite        ECDHE-ECDSA-AES128-GCM-SHA256:ECDHE-RSA-AES128-GCM-SHA256:ECDHE-ECDSA-AES256-GCM-SHA384:ECDHE-RSA-AES256-GCM-SHA384:ECDHE-ECDSA-CHACHA20-POLY1305:ECDHE-RSA-CHACHA20-POLY1305:DHE-RSA-AES128-GCM-SHA256:DHE-RSA-AES256-GCM-SHA384
</VirtualHost>
```

> [!NOTE]
> This example is using a locally-generated certificate. **SSLCertificateFile** should be the primary certificate file for the domain name. **SSLCertificateKeyFile** should be the key file generated when CSR is created. **SSLCertificateChainFile** should be the intermediate certificate file (if any) that was supplied by the certificate authority.
>
> Apache HTTP Server version 2.4.43 or newer is required in order to operate a TLS 1.3 web server with OpenSSL 1.1.1.

> [!NOTE]
> The preceding example disables Online Certificate Status Protocol (OCSP) Stapling. For more information and guidance on enabling OCSP, see [OCSP Stapling (Apache documentation)](https://httpd.apache.org/docs/trunk/ssl/ssl_howto.html#ocspstapling).

Save the file and test the configuration:

```bash
sudo service httpd configtest
```

Restart Apache:

```bash
sudo systemctl restart httpd
```

## Additional Apache suggestions

### Restart apps with shared framework updates

After upgrading the shared framework on the server, restart the ASP.NET Core apps hosted by the server.

### Additional headers

To secure against malicious attacks, there are a few headers that should either be modified or added. Ensure that the `mod_headers` module is installed:

```bash
sudo yum install mod_headers
```

#### Secure Apache from clickjacking attacks

[Clickjacking](https://blog.qualys.com/securitylabs/2015/10/20/clickjacking-a-common-implementation-mistake-that-can-put-your-websites-in-danger), also known as a *UI redress attack*, is a malicious attack where a website visitor is tricked into clicking a link or button on a different page than they're currently visiting. Use `X-FRAME-OPTIONS` to secure the site.

To mitigate clickjacking attacks:

1. Edit the *httpd.conf* file:

   ```bash
   sudo nano /etc/httpd/conf/httpd.conf
   ```

   Add the line `Header append X-FRAME-OPTIONS "SAMEORIGIN"`.
1. Save the file.
1. Restart Apache.

#### MIME-type sniffing

The `X-Content-Type-Options` header prevents Internet Explorer from *MIME-sniffing* (determining a file's `Content-Type` from the file's content). If the server sets the `Content-Type` header to `text/html` with the `nosniff` option set, Internet Explorer renders the content as `text/html` regardless of the file's content.

Edit the *httpd.conf* file:

```bash
sudo nano /etc/httpd/conf/httpd.conf
```

Add the line `Header set X-Content-Type-Options "nosniff"`. Save the file. Restart Apache.

### Load Balancing

This example shows how to setup and configure Apache on CentOS 7 and Kestrel on the same instance machine. To not have a single point of failure; using *mod_proxy_balancer* and modifying the **VirtualHost** would allow for managing multiple instances of the web apps behind the Apache proxy server.

```bash
sudo yum install mod_proxy_balancer
```

In the configuration file shown below, an additional instance of the `helloapp` is set up to run on port 5001. The *Proxy* section is set with a balancer configuration with two members to load balance *byrequests*.

```
<VirtualHost *:*>
    RequestHeader set "X-Forwarded-Proto" expr=%{REQUEST_SCHEME}
</VirtualHost>

<VirtualHost *:80>
    RewriteEngine On
    RewriteCond %{HTTPS} !=on
    RewriteRule ^/?(.*) https://%{SERVER_NAME}/$1 [R,L]
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
    ErrorLog /var/log/httpd/helloapp-error.log
    CustomLog /var/log/httpd/helloapp-access.log common
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

### Long request header fields

Proxy server default settings typically limit request header fields to 8,190 bytes. An app may require fields longer than the default (for example, apps that use [Microsoft Entra ID](https://azure.microsoft.com/services/active-directory/)). If longer fields are required, the proxy server's [LimitRequestFieldSize](https://httpd.apache.org/docs/2.4/mod/core.html#LimitRequestFieldSize) directive requires adjustment. The value to apply depends on the scenario. For more information, see your server's documentation.

> [!WARNING]
> Don't increase the default value of `LimitRequestFieldSize` unless necessary. Increasing the value increases the risk of buffer overrun (overflow) and Denial of Service (DoS) attacks by malicious users.

## Additional resources

* [Prerequisites for .NET Core on Linux](/dotnet/core/linux-prerequisites)
* <xref:test/troubleshoot>
* <xref:host-and-deploy/proxy-load-balancer>
