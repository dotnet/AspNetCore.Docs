---
title: Host ASP.NET Core on Linux with Apache
description: Learn how to set up Apache as a reverse proxy server on CentOS to redirect HTTP traffic to an ASP.NET Core web application running on Kestrel.
keywords: ASP.NET Core, Apache, CentOS, Reverse Proxy, Linux, mod_proxy, httpd, hosting
author: spboyer
ms.author: spboyer
manager: wpickett
ms.date: 10/19/2016
ms.topic: article
ms.assetid: fa9b0cb7-afb3-4361-9e7e-33afffeaca0c
ms.technology: aspnet
ms.prod: asp.net-core
uid: publishing/apache-proxy
---
# Set up a hosting environment for ASP.NET Core on Linux with Apache, and deploy to it

By [Shayne Boyer](https://github.com/spboyer)

Apache is a very popular HTTP server and can be configured as a proxy to redirect HTTP traffic similar to nginx. In this guide, we will learn how to set up Apache on CentOS 7 and use it as a reverse proxy to welcome incoming connections and redirect them to the ASP.NET Core application running on Kestrel. For this purpose, we will use the *mod_proxy* extension and other related Apache modules.

## Prerequisites

1. A server running CentOS 7, with a standard user account with
   sudo privilege.
2. An existing ASP.NET Core application. 

## Publish your application

Run `dotnet publish -c Release` from your development environment to package your
application into a self-contained directory that can run on your server. The published application must then be copied to the server using SCP, FTP or other file transfer method. 

> [!NOTE]
> Under a production deployment scenario, a continuous integration workflow does the work of publishing the application and copying the assets to the server. 

## Configure a proxy server

A reverse proxy is a common setup for serving dynamic web applications. The reverse proxy terminates the HTTP request and forwards it to the ASP.NET application.

A proxy server is one which forwards client requests to another server instead of fulfilling them itself. A reverse proxy forwards to a fixed destination, typically on behalf of arbitrary clients. In this guide, Apache is being configured as the reverse proxy running on the same server that Kestrel is serving the ASP.NET Core application. 

Each piece of the application can exist on separate physical machines, Docker containers, or a combination of configurations depending on your architectural needs or restrictions.

### Install Apache

Installing the Apache web server on CentOS is a single command, but first let's update our packages.

```bash
    sudo yum update -y
```

This ensures that all of the installed packages are updated to their latest version. Install Apache using `yum`

```bash
    sudo yum -y install httpd mod_ssl
```

The output should reflect something similar to the following.

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
> In this example the output reflects httpd.86_64 since the CentOS 7 version is 64 bit. The output may be different for your server. To verify where Apache is installed, run `whereis httpd` from a command prompt. 

### Configure Apache for reverse proxy

Configuration files for Apache are located within the `/etc/httpd/conf.d/` directory. Any file with the **.conf** extension will be processed in alphabetical order in addition to the module configuration files in `/etc/httpd/conf.modules.d/`, which contains any configuration files necessary to load modules.

Create a configuration file for your app, for this example we'll call it `hellomvc.conf`

```text
    <VirtualHost *:80>
        ProxyPreserveHost On
        ProxyPass / http://127.0.0.1:5000/
        ProxyPassReverse / http://127.0.0.1:5000/
        ErrorLog /var/log/httpd/hellomvc-error.log
        CustomLog /var/log/httpd/hellomvc-access.log common
    </VirtualHost>
```

The *VirtualHost* node, of which there can be multiple in a file or on a server in many files, is set to listen on any IP address using port 80. The next two lines are set to pass all requests received at the root to the machine 127.0.0.1 port 5000 and in reverse. For there to be bi-directional communication, both settings *ProxyPass* and *ProxyPassReverse* are required.

Logging can be configured per VirtualHost using *ErrorLog* and *CustomLog* directives. *ErrorLog* is the location where the server will log errors and *CustomLog* sets the filename and format of log file. In our case this is where request information will be logged. There will be one line for each request.

Save the file, and test the configuration. If everything passes, the response should be `Syntax [OK]`.

```bash
    sudo service httpd configtest
```

Restart Apache.

```text
    sudo systemctl restart httpd
    sudo systemctl enable httpd
```

## Monitoring our application

Apache is now setup to forward requests made to `http://localhost:80` on to the ASP.NET Core application running on Kestrel at `http://127.0.0.1:5000`.  However, Apache is not set up to manage the Kestrel process. We will use *systemd* and create a service file to start and monitor the underlying web app. *systemd* is an init system that provides many powerful features for starting, stopping and managing processes. 


### Create the service file

Create the service definition file 

```bash
    sudo nano /etc/systemd/system/kestrel-hellomvc.service
```

An example service file for our application.

```text
[Unit]
    Description=Example .NET Web API Application running on CentOS 7

    [Service]
    WorkingDirectory=/var/aspnetcore/hellomvc
    ExecStart=/usr/local/bin/dotnet /var/aspnetcore/hellomvc/hellomvc.dll
    Restart=always
    RestartSec=10                                          # Restart service after 10 seconds if dotnet service crashes
    SyslogIdentifier=dotnet-example
    User=apache
    Environment=ASPNETCORE_ENVIRONMENT=Production 

    [Install]
    WantedBy=multi-user.target
```

> [!NOTE]
> **User** -- If the user *apache* is not used by your configuration, the user defined here must be created first and given proper ownership for files

Save the file and enable the service.

```bash
    systemctl enable kestrel-hellomvc.service
```

Start the service and verify that it is running.

```
    systemctl start kestrel-hellomvc.service
    systemctl status kestrel-hellomvc.service

    ● kestrel-hellomvc.service - Example .NET Web API Application running on CentOS 7
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

### Configure firewall

*Firewalld* is a dynamic daemon to manage firewall with support for network zones, although you can still use iptables to manage ports and packet filtering. Firewalld should be installed by default, `yum` can be used to install the package or verify.

```bash
    sudo yum install firewalld -y
```

Using `firewalld` you can open only the ports needed for the application. In this case, port 80 and 443 are used. The following commands permanently sets these to open.

```bash
    sudo firewall-cmd --add-port=80/tcp --permanent
    sudo firewall-cmd --add-port=443/tcp --permanent
```

Reload the firewall settings, and check the available services and ports in the default zone. Options are available by inspecting `firewall-cmd -h`

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

To configure Apache for SSL, the mod_ssl module is used.  This was installed initially when we installed the `httpd` module. If it was missed or not installed, use yum to add it to your configuration.

```bash
    sudo yum install mod_ssl
```
To enforce SSL, install `mod_rewrite`

```bash
    sudo yum install mod_rewrite
```

The `hellomvc.conf` file that was created for this example needs to be modified to enable the rewrite as well as adding the new **VirtualHost** section for HTTPS.

```text
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
> This example is using a locally generated certificate. **SSLCertificateFile** should be your primary certificate file for your domain name. **SSLCertificateKeyFile** should be the key file generated when you created the CSR. **SSLCertificateChainFile** should be the intermediate certificate file (if any) that was supplied by your certificate authority

Save the file, and test the configuration.

```bash
    sudo service httpd configtest
```

Restart Apache.

```bash
    sudo systemctl restart httpd
```

## Additional Apache suggestions

### Additional Headers 
In order to secure against malicious attacks there are a few headers that should either be modified or added. Ensure that the `mod_headers` module is installed.

```bash
    sudo yum install mod_headers
```

#### Secure Apache from clickjacking
Clickjacking is a malicious technique to collect an infected user's clicks. Clickjacking tricks the victim (visitor) into clicking on an infected site. Use X-FRAME-OPTIONS to secure your site.

Edit the httpd.conf file.

```bash
    sudo nano /etc/httpd/conf/httpd.conf
```

Add the line `Header append X-FRAME-OPTIONS "SAMEORIGIN"` and save the file, then restart Apache.

#### MIME-type sniffing

This header prevents Internet Explorer from MIME-sniffing a response away from the declared content-type as the header instructs the browser not to override the response content type. With the nosniff option, if the server says the content is text/html, the browser will render it as text/html.

Edit the httpd.conf file.

```bash
    sudo nano /etc/httpd/conf/httpd.conf
```

Add the line `Header set X-Content-Type-Options "nosniff"` and save the file, then restart Apache.

### Load Balancing 

This example shows how to setup and configure Apache on CentOS 7 and Kestrel on the same instance machine.  However, in order to not have a single point of failure; using *mod_proxy_balancer* and modifying the VirtualHost would allow for managing mutliple instances of the web applications behind the Apache proxy server.

```bash
    sudo yum install mod_proxy_balancer
```

In the configuration file, an additional instance of the `hellomvc` app has been setup to run on port 5001 and the *Proxy* section has been set with a balancer configuration with two members to load balance *byrequests*.

```text
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
Using `mod_ratelimit`, which is included in the `htttpd` module you can limit the amount of bandwidth of clients. 

```bash
    sudo nano /etc/httpd/conf.d/ratelimit.conf
```
The example file limits bandwidth as 600 KB/sec under the root location.

```text
    <IfModule mod_ratelimit.c>
        <Location />
            SetOutputFilter RATE_LIMIT
            SetEnv rate-limit 600
        </Location>
    </IfModule>
```
