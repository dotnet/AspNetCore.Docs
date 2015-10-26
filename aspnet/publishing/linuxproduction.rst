Publish to a Linux Production Environment
=========================================

By `Sourabh Shirhatti`_

In this guide, we will cover setting up a production-ready ASP.NET
environment on an Ubuntu 14.04 Server. Though we will cover the
specifics of using Ubuntu 14.04, the content will be applicable to other
flavors of Linux.

We will take an existing ASP.NET 5 application and place it behind a
reverse-proxy server. We will then setup the reverse-proxy server to
forward requests to our Kestrel web server.

Additionally we will write a startup script to ensure our web
application runs on startup as a daemon as well as a configure a process
management tool to help restart our web application in the event of a
crash to guarantee high availibility.

Prerequisites
-------------

1. Acess to an Ubuntu 14.04 Server with a standard user account with
   sudo privilege.
2. Public access to port 80 on your server. You may want to use IPTables
   to restrict access to your server.
3. An exisiting ASP.NET 5 application.

Before getting started you require LibUV and DNVM. Follow the instructions on the :doc:`/getting-started/installing-on-linux` page.


Copy over your app
------------------

Run ``dnu publish`` from your dev environment to package your
application into a self-contained directory that can be launched.

Before we proceed, go ahead and copy over your ASP.NET 5 application to
your server using whatever tool (SCP, FTP, etc) integrates into your
workflow. Try and run the app and navigate to http://yourserveraddress:port
in your browser to see if the application runs fine on Linux. I
recommend you have a working app before proceeding.

If you do not have an application, I recommend using the `Yeoman
generators <https://github.com/omnisharp/generator-aspnet>`__ to quickly
scaffold a skeleton app.

Configure a reverse proxy server
--------------------------------

A reverse proxy is a common setup for serving dynamic web applications.
The reverse proxy terminates the HTTP request and forwards it to the
ASP.NET application.

Why use a reverse-proxy server?
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Kestrel is great for serving dynamic content from ASP.NET, however the
web serving parts aren’t as feature rich full-featured servers like IIS,
Apache or Nginx. A reverse proxy-server can allow you to offload work
like serving static content, caching requests, compressing requests, and
SSL termination from the application server. The reverse proxy server
may reside on a dedicated machine or may be deployed alongside an
application server.

For the purposes of this guide, we are going to use a single instance of
Nginx, however based on your requirements you may chose a different
setup.

Install Nginx
~~~~~~~~~~~~~

.. code:: shell

    sudo apt-get install nginx

.. note::

    If you plan to install optional Nginx modules you may be required to
    build Nginx from source.

We are going to ``apt-get`` to install Nginx. The installer also creates
a System V init script that runs Nginx as daemon on system startup.
Since we just installed Nginx for the first time, we can explicitly
start it by running

.. code:: shell

    sudo service nginx start

At this point you should be able to navigate to your browser and see the
default landing page for Nginx.

Configure Nginx
~~~~~~~~~~~~~~~

We will now configure Nginx as a reverse proxy to forward requests to
our ASP.NET application

We will be modifying the ``/etc/nginx/sites-available/default``, so open
it up in your favorite text editor and replace the contents with the
following.

.. code::

    server {
        listen 80;

        location / {
            proxy_pass http://127.0.0.1:5000;
            proxy_http_version 1.1;
            proxy_set_header Upgrade $http_upgrade;
            proxy_set_header Connection 'upgrade';
            proxy_set_header Host $host;
            proxy_cache_bypass $http_upgrade;
        }
    }

This is one of the simplest configuration files for Nginx that forwards
incoming pulbic traffic on your port ``80`` to port number ``5000``
internally

.. note::

    I have used port ``5000`` in this example, but be sure to change
    this to the port your ASP.NET application will listen on.

You might want to look at ``etc/nginx/nginx.conf`` to make other
necessary changes to your nginx environment to configure your nginx
environment. I have included my ``nginx.conf`` file for reference

.. code::

    user www-data;
    worker_processes 4;
    pid /run/nginx.pid;

    events {
            worker_connections 768;
            # multi_accept on;
    }

    http {

            ##
            # Basic Settings
            ##

            sendfile on;
            tcp_nopush on;
            tcp_nodelay off;
            keepalive_timeout 65;
            types_hash_max_size 2048;
            # server_tokens off;

            # server_names_hash_bucket_size 64;
            # server_name_in_redirect off;

            include /etc/nginx/mime.types;
            default_type application/octet-stream;

            ##
            # Logging Settings
            ##

            access_log /var/log/nginx/access.log;
            error_log /var/log/nginx/error.log;

            ##
            # Gzip Settings
            ##

            gzip on;
            gzip_disable "msie6";

            gzip_vary on;
            gzip_proxied any;
            gzip_comp_level 6;
            gzip_buffers 16 8k;
            gzip_http_version 1.0;
            gzip_types text/plain text/css application/json application/x-javascript text/xml application/xml application/xml+rss text/javascript;

            include /etc/nginx/conf.d/*.conf;
            include /etc/nginx/sites-enabled/*;
    }

Once you have completed making changes to your nginx configuration you
can run ``sudo nginx -t`` to verify the syntax of your configuration
files. If you see any no errors you can ask nginx to pick up the changes
by running ``sudo nginx -s reload``

Create an user to run your application
--------------------------------------

For security reasons it is commonplace to run your application as an
unprivileged user on Linux. Let us go ahead and create a unpriviliged
user to run our ASP.NET web application

.. code:: shell

    sudo su
    adduser --system --no-create-home --group aspnet
    exit

Install a DNX globally
----------------------

.. code:: shell

    dnvm install 1.0.0-beta7 -g -r coreclr

Start our web application on startup
------------------------------------

We will create an Upstart script to launch our application on startup.
This will vary based on whether you are using System V Init, Upstart or
Systemd as your startup system.

Create a new startup script by running
``sudo touch /etc/init/aspnet5webserver.conf``. Using your preferred
text editor update the file contents to match what is shown below.

.. code::

    start on runlevel [2345]
    stop on runlevel [016]

    script
        exec start-stop-daemon --start --make-pidfile --pidfile /var/run/aspnet5webserver.pid --chuid aspnet --exec /usr/local/lib/dnx/runtimes/dnx-coreclr-linux-x64.1.0.0-beta7/bin/dnx /path/to/packaged/app kestrel --signal INT
    end script

    pre-start script
        echo "[`date`] (sys) Starting" >> /var/log/aspnet5webserver.sys.log
    end script

    post-stop script
        rm /var/run/aspnet5webserver.pid
        echo "[`date`] (sys) Stopped" >> /var/log/aspnet5webserver.sys.log
    end script

.. note::

    In the above script replace ``/path/to/packaged/app`` with the path where your application resides on disk.

Viewing your logs
~~~~~~~~~~~~~~~~~

Upstart will redirect your ``stdout`` and ``stderr`` to
``/var/log/upstart/aspnet5webserver.log`` and can be easily viewed from
there.

Monitoring our process
----------------------

Now we have our application set to start on system reboots, however we
still need to monitor our application for unresponsiveness and crashes.
In this guide I will be using Monit to periodically check if the our web
server is still running and restart it in the event of a crash.

Installing Monit
~~~~~~~~~~~~~~~~

::

    sudo apt-get install monit

Configuring Monit
~~~~~~~~~~~~~~~~~

You can add the following files to your ``/etc/monit/conf.d/``
directory. You may also want to change additional settings like how
frequently Monit runs in ``/etc/monit/monitrc``.

nginx.conf
^^^^^^^^^^

.. code::

    check process nginx with pidfile /var/run/nginx.pid
        start program = "/etc/init.d/nginx start"
        stop program = "/etc/init.d/nginx stop"

aspnet5webserver.conf
^^^^^^^^^^^^^^^^^^^^^

.. code::

    check process aspnet5webserver with pidfile /var/run/aspnet5webserver.pid
        start program = "/sbin/start aspnet5webserver"
        stop program = "/sbin/stop aspnet5webserver"
        if failed port 5000 protocol HTTP
            request /
            with timeout 10 seconds
            then restart

Once you have edited these files, you can run ``sudo monit -t`` to
verify that your control file syntax is correct. If there are no errors
you can ``service monit reload`` to update monit with your new
configuration.
