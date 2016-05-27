Publish to a Linux Production Environment
=========================================

By `Sourabh Shirhatti`_

In this guide, we will cover setting up a production-ready ASP.NET environment on an Ubuntu 14.04 Server.

We will take an existing ASP.NET Core application and place it behind a reverse-proxy server. We will then setup the reverse-proxy server to forward requests to our Kestrel web server.

Additionally we will ensure our web application runs on startup as a daemon and configure a process management tool to help restart our web application in the event of a crash to guarantee high availability.

.. contents:: Sections:
  :local:
  :depth: 1

Prerequisites
-------------

1. Access to an Ubuntu 14.04 Server with a standard user account with
   sudo privilege.
2. An existing ASP.NET Core application.

Copy over your app
------------------

Run ``dotnet publish`` from your dev environment to package your
application into a self-contained directory that can run on your server.

Before we proceed, copy your ASP.NET Core application to your server using whatever tool (SCP, FTP, etc) integrates into your workflow. Try and run the app and navigate to ``http://<serveraddress>:<port>`` in your browser to see if the application runs fine on Linux. I recommend you have a working app before proceeding.

.. note:: You can use :doc:`Yeoman </client-side/yeoman>` to create a new ASP.NET Core application for a new project.

Configure a reverse proxy server
--------------------------------

A reverse proxy is a common setup for serving dynamic web applications. The reverse proxy terminates the HTTP request and forwards it to the ASP.NET application.

Why use a reverse-proxy server?
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Kestrel is great for serving dynamic content from ASP.NET, however the web serving parts aren’t as feature rich as full-featured servers like IIS, Apache or Nginx. A reverse proxy-server can allow you to offload work like serving static content, caching requests, compressing requests, and SSL termination from the HTTP server. The reverse proxy server may reside on a dedicated machine or may be deployed alongside an HTTP server.

For the purposes of this guide, we are going to use a single instance of Nginx that runs on the same server alongside your HTTP server. However, based on your requirements you may choose a different setup.

Install Nginx
~~~~~~~~~~~~~

.. code-block:: bash

    sudo apt-get install nginx

.. note::

    If you plan to install optional Nginx modules you may be required to
    build Nginx from source.

We are going to ``apt-get`` to install Nginx. The installer also creates a System V init script that runs Nginx as daemon on system startup. Since we just installed Nginx for the first time, we can explicitly start it by running

.. code-block:: bash

    sudo service nginx start

At this point you should be able to navigate to your browser and see the default landing page for Nginx.

Configure Nginx
~~~~~~~~~~~~~~~

We will now configure Nginx as a reverse proxy to forward requests to our ASP.NET application

We will be modifying the ``/etc/nginx/sites-available/default``, so open it up in your favorite text editor and replace the contents with the following.

.. code-block:: nginx
   :emphasize-lines: 7

    server {
        listen 80;
        location / {
            proxy_pass http://unix:/var/aspnet/HelloMVC/kestrel.sock;
            proxy_http_version 1.1;
            proxy_set_header Upgrade $http_upgrade;
            proxy_set_header Connection keep-alive;
            proxy_set_header Host $host;
            proxy_cache_bypass $http_upgrade;
        }
    }

This is one of the simplest configuration files for Nginx that forwards incoming public traffic on your port ``80`` to a unix socket that your web application will listen on. You can specify this Unix socket in your *project.json* file.

.. code-block:: none
    :caption: project.json

    "commands": {
        "web": "Microsoft.AspNetCore.Server.Kestrel --server.urls http://unix:/var/aspnet/HelloMVC/kestrel.sock",
    },

You might want to look at ``/etc/nginx/nginx.conf`` to configure your nginx environment.

Once you have completed making changes to your nginx configuration you can run ``sudo nginx -t`` to verify the syntax of your configuration files. If the configuration file test is successful you can ask nginx to pick up the changes by running ``sudo nginx -s reload``.

Monitoring our Web Application
------------------------------

Nginx will forward requests to your Kestrel server, however unlike IIS on Windows, it does not mangage your Kestrel process. In this tutorial, we will use `supervisor <http://supervisord.org/>`_ to start our application on system boot and restart our process in the event of a failure.

Installing supervisor
~~~~~~~~~~~~~~~~~~~~~

.. code-block:: bash

    sudo apt-get install supervisor

.. note::

    ``supervisor`` is a python based tool and you can acquire it through `pip <http://supervisord.org/installing.html#installing-via-pip>`_ or `easy_install <http://supervisord.org/installing.html#internet-installing-with-setuptools>`_ instead.


Configuring supervisor
~~~~~~~~~~~~~~~~~~~~~~

Supervisor works by creating child processes based on data in its configuration file. When a child process dies, supervisor is notified via the ``SIGCHILD`` signal and supervisor can react accordingly and restart your web application.

To have supervisor monitor our application, we will add a file to the ``/etc/supervisor/conf.d/`` directory.

.. code-block:: ini
    :caption: /etc/supervisor/conf.d/hellomvc.conf

    [program:hellomvc]
    command=bash /var/aspnet/HelloMVC/approot/web
    autostart=true
    autorestart=true
    stderr_logfile=/var/log/hellomvc.err.log
    stdout_logfile=/var/log/hellomvc.out.log
    environment=Hosting__Environment=Production
    user=www-data
    stopsignal=INT

Once you are done editing the configuration file, restart the ``supervisord`` process to change the set of programs controlled by supervisord.

.. code-block:: bash

    sudo service supervisor stop
    sudo service supervisor start

Start our web application on startup
------------------------------------

In our case, since we are using supervisor to manage our application, the application will be automatically started by supervisor. Supervisor uses a System V Init script to run as a daemon on system boot and will susbsequently launch your application. If you chose not to use supervisor or an equivalent tool, you will need to write a ``systemd`` or ``upstart`` or ``SysVinit`` script to start your application on startup.

Recovering from an ungraceful shutdown
--------------------------------------

If your web application is terminated with a ``SIGKILL`` signal or the if host experiences a loss of power, ``Kestrel`` will not shut down gracefully and remove the socket file. To prevent subsequents attempts to restart your application from failing due to ``EADDRINUSE address already in use``, you can modify the shell script used to bootstrap your application to remove the socket file if present.

.. code-block:: bash
    :caption: /var/aspnet/HelloMVC/approot/web

    if [ -f "/var/aspnet/HelloMVC/kestrel.sock" ]; then
      rm "/var/aspnet/HelloMVC/kestrel.sock"
    fi


Viewing logs
------------

**Supervisord** logs messages about its own health and its subprocess' state changes to the activity log. The path to the activity log is configured via the ``logfile`` parameter in the configuration file.

.. code-block:: bash

    sudo tail -f /var/log/supervisor/supervisord.log

You can redirect application logs (``STDOUT`` and ``STERR``) in the program section of your configuration file.

.. code-block:: bash

    tail -f /var/log/hellomvc.out.log

