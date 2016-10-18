Using Apache Web Server as a reverse-proxy
==========================================

By `Shayne Boyer`_

Apache is a very popular HTTP server and can be configured as a proxy to redirect HTTP traffic similar to nginx. In this guide, we will learn how to set up Apache on CentOS 7 and use it as a reverse-proxy to welcome incoming connections and redirect them to the ASP.NET Core application running on Kestrel. For this purpose, we will use the *mod_proxy* extension and other related Apache modules.

.. contents:: Sections:
  :local:
  :depth: 2

Prerequisites
-------------

1. A server running CentOS 7, with a standard user account with
   sudo privilege.
2. An existing ASP.NET Core application. 

Publish your application
------------------------

Run ``dotnet publish -c Release`` from your development environment to package your
application into a self-contained directory that can run on your server. The published application must then be copied to the server using SCP, FTP, etc. 

.. note:: Under a production deployment scenario, a continuous integration workflow does the work of publishing the application and copying the assets to the server. 

Configure a proxy server
------------------------

A reverse proxy is a common setup for serving dynamic web applications. The reverse proxy terminates the HTTP request and forwards it to the ASP.NET application.

A proxy server is one which forwards client requests to another server instead of fulfilling them itself. A reverse proxy forwards to a fixed destination, typically on behalf of arbitrary clients. In this guide, Apache is being configured as the reverse-proxy running on the same server that Kestrel is serving the ASP.NET Core application. 

These instances could exist on separate physical machines, Docker containers, or a combination of configurations depending on your architectural needs or restrictions.

Install Apache
~~~~~~~~~~~~~~

Installing the Apache web server on CentOS is a single command, but first let's update our ``yum`` package.

.. code-block:: bash

    sudo yum update -y

This ensures that all of the installed packages are updated to their latest version. Install Apache using ``yum``

.. code-block:: bash

    sudo yum -y install httpd mod_ssl

The output should reflect something similar to the following.

... code-block:: bash

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

.. note:: In this example the output reflects httpd.86_64 since the CentOS 7 version is 64 bit. The output may be different for your server. To verify where Apache is installed, run ``whereis httpd`` from the command line. 

Configure Apache for reverse-proxy
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
Configuration files for Apache are located within the ``/etc/httpd/conf.d/`` directory. Any file with the **.conf** extension will be processed in alphabetical order in addition to the module configuration files in ``/etc/httpd/conf.modules.d/``, which contains
configuration files necessary to load modules.

Create a configuration file for your app, for this example we'll call it ``hellomvc.conf``

.. code-block:: text

    <VirtualHost *:80>
        ServerAdmin webmaster@localhost
        ServerName localhost
        ProxyPreserveHost On
        ProxyRequests Off
        ProxyPass / http://127.0.0.1:5000
        ProxyPassReverse / http://127.0.0.1:5000
        ErrorLog /var/log/httpd/hellomvc-error.log
        CustomLog /var/log/httpd/hellomvc-common.log common
    </VirtualHost>

The *VirtualHost* node, of which there can be multiple in a file or on a server in many files, is set to listen on any IP address using port 80. *ProxyRequests* allows or prevents Apache httpd from functioning as a forward proxy server. In a typical reverse proxy or gateway configuration, this option should be set to Off. The next two lines are set to pass all requests received at the root to the machine 127.0.0.1 port 5000 and in reverse. For there to be bi-directional communication, both settings *ProxyPass* and *ProxyPassReverse** are required.

Logging can be configured per VirtualHost using *ErrorLog* and *CustomLog* directives. *ErrorLog* is the location where the server will log errors and *CustomLog* sets the filename and format of log file. In our case this is where common web server information will be logged.


Save the file, and test the configuration.

.. code-block:: bash

    sudo service httpd configtest
    Syntax OK

Restart Apache.

.. code-block:: text

    sudo systemctl stop httpd
    sudo systemctl start httpd
    sudo systemctl enable httpd

Monitoring our application
--------------------------

Apache is now setup to forward requests made to ``http://localhost:80`` on to the ASP.NET Core application running on Kestrel at ``http://127.0.0.1:5000``.  However, Apache is not setup to manage the Kestrel process. We will use `supervisor <http://supervisord.org/>`_ to start our application on system boot and restart our process in the event of a failure. 

Installing supervisor
~~~~~~~~~~~~~~~~~~~~~

Install supervisor using ``easy_install``

.. code:: bash

    sudo easy_install supervisor

Create the configuration file using the built command line tool. The tool generates an example supervisor.conf file, replace the contents with the settings that are relative to your application.

.. code:: bash

    echo_supervisord_conf > /etc/supervisord.conf

Once supervisor is configured to run and manage the Kestrel process, see the logs for the application by running the command.

.. code-block:: bash

     /usr/bin/supervisord -c /etc/supervisord.conf

.. note:: If you don’t have root access, or you’d rather not put the supervisord.conf file in /etc/supervisord.conf`, you can place it in the current directory (echo_supervisord_conf > supervisord.conf) and start supervisord with the -c flag in order to specify the configuration file location.   

An example configuration file for for a **hellomvc** application.

.. code-block:: text
    [program:hellomvc]
    command=/usr/bin/dotnet /var/aspnetcore/hellomvc/hellomvc.dll
    directory=/var/aspnetcore/HelloMVC/
    autostart=true
    autorestart=true
    stderr_logfile=/var/log/hellomvc.err.log
    stdout_logfile=/var/log/hellomvc.out.log
    environment=HOME="/var/www/",ASPNETCORE_ENVIRONMENT="Production"
    user=www_user
    stopsignal=INT
    stopasgroup=true
    killasgroup=true
    [supervisord]

For more information on the configuration file format and options see: `http://supervisord.org/<http://supervisord.org/configuration.html>`_.

The output shows the application process has successfully started.

.. code-block:: bash

    2016-10-11 12:21:59,984 CRIT Supervisor running as root (no user in config file)
    2016-10-11 12:21:59,984 WARN Included extra file "/etc/supervisor/conf.d/HelloMVC.conf" during parsing
    2016-10-11 12:22:00,002 INFO RPC interface 'supervisor' initialized
    2016-10-11 12:22:00,002 CRIT Server 'unix_http_server' running without any HTTP authentication checking
    2016-10-11 12:22:00,003 INFO daemonizing the supervisord process
    2016-10-11 12:22:00,003 INFO supervisord started with pid 29315
    2016-10-11 12:22:01,009 INFO spawned: 'HelloMVC' with pid 29322
    2016-10-11 12:22:02,387 INFO success: HelloMVC entered RUNNING state, process has stayed up for > than 10 seconds (startsecs)

With the reverse-proxy configured and Kestrel managed through supervisor, the web application is fully configured and can be accessed from a browser on the local machine at ``http://localhost``. Inspecting the response headers, the **Server** still shows the ASP.NET Core application being served by Kestrel.

.. code-block:: text

    HTTP/1.1 200 OK
    Date: Tue, 11 Oct 2016 16:22:23 GMT
    Server: Kestrel
    Keep-Alive: timeout=5, max=98
    Connection: Keep-Alive
    Transfer-Encoding: chunked

To add or remove headers, edit the ``hellomvc.conf`` file and add the following withing the ``<VirtualHost>`` node.

.. code-block:: text

    Header add ProxyServer "Apache"
    Header remove Server

Viewing logs
~~~~~~~~~~~~
Supervisord logs messages about its own health and its subprocess’ state changes to the activity log. The path to the activity log is configured via the logfile parameter in the configuration file.

.. code-block:: bash

    sudo tail -f /etc/supervisord.log

You can redirect application logs (STDOUT and STERR) in the program section of your configuration file.

.. code-block:: bash

    tail -f /var/log/hellomvc.out.log