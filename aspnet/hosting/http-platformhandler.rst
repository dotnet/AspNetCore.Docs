.. _http-platformhandler:

HTTP Platform Handler
=====================

By `Sourabh Shirhatti`

In ASP.NET 5, the web application is hosted by an external process outside of IIS. The HTTP Platform Handler is an IIS 7.5+ module which is responsible for process management of http listeners and to proxy requests to processes that it manages. This document provides an overview of how to configure the HTTP Platform Handler module for shared hosting of ASP.NET 5.

Installing the HTTP Platform Handler
------------------------------------

To get started with hosting with ASP.NET 5 applications you will need to install the HTTP Platform Handler version 1.2 or higher on an IIS 7.5 or higher server. Download links are below

* `64 bit HTTP PlatformHandler (x64) <http://go.microsoft.com/fwlink/?LinkID=690721>`_ 
* `32 bit HTTP PlatformHandler (x86) <http://go.microsoft.com/fwlink/?LinkId=690722>`_ 


Configuring the HTTP Platform Handler
-------------------------------------

The HTTP Platform Handler is configured via a site or application's *web.config* file and has its own configuration section within ``system.webServer - httpPlatform``. The `HTTP Platform Handler configuration reference whitepaper <http://www.iis.net/learn/extensions/httpplatformhandler/httpplatformhandler-configuration-reference>`_ describes in detail how to modify Configuration Attributes for the HTTP PlatformHandler module.

.. note::
    You may need to unlock the handlers section of *web.config*. Follow the instructions :ref:`here <unlock-handlers>`.

.. _log-redirection:

Log Redirection
---------------

The HTTP Platform Handler module can redirect ``stdout`` and ``stderr`` logs to disk by setting the ``stdoutLogEnabled``  and ``stdoutLogFile`` properties of the ``httpPlatform`` attribute. However, the HTTP Platform Handler module does not rotate logs and it is the responsibilty of the hoster to limit the disk space the logs consume.

.. literalinclude:: http-platformhandler/sample/web.config
  :language: xml
  :lines: 12-16,20


Setting Environment Variables
-----------------------------

The HTTP Platform Handler module allows you specify environment variables for the process specified in the ``processPath`` setting by specifying them in ``environmentVariables`` child attribute to the ``httpPlatform`` attribute. The example below illustrates how you would use it.

.. literalinclude:: http-platformhandler/sample/web.config
  :language: xml
  :lines: 12-20

.. note::
    There is a `known issue <https://github.com/aspnet/dnx/issues/3062>`_ known issue with ``dnu publish`` where it removes all child attributes of the ``httpPlatform`` attribute.
