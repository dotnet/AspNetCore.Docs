ASP.NET Core Module Configuration Reference
=============================================

By `Luke Latham`_, `Rick Anderson`_ and `Sourabh Shirhatti`_

In ASP.NET Core, the web application is hosted by an external process outside of IIS. The ASP.NET Core Module is an IIS 7.5+ module, which is responsible for process management of ASP.NET Core http listeners and to proxy requests to processes that it manages. This document provides an overview of how to configure the ASP.NET Core Module for shared hosting of ASP.NET Core.

.. contents:: Sections:
  :local:
  :depth: 2

Installing the ASP.NET Core Module
----------------------------------

Install the `.NET Core Windows Server Hosting <https://go.microsoft.com/fwlink/?LinkId=817246>`__ bundle on the server. The bundle will install the .NET Core Runtime, .NET Core Library, and the ASP.NET Core Module.

Configuring the ASP.NET Core Module
-----------------------------------

The ASP.NET Core Module is configured via a site or application *web.config* file and has its own configuration section within ``system.webServer - aspNetCore``.

Configuration Attributes
^^^^^^^^^^^^^^^^^^^^^^^^

+---------------------------+----------------------------------------------------+
| Attribute                 |     Description                                    |
+===========================+====================================================+
| processPath               | | Required string attribute.                       |
|                           | |                                                  |
|                           | | Path to the executable or script that will launch|
|                           | | a process listening for HTTP requests.           |
|                           | | Relative paths are supported. If the path        |
|                           | | begins with '.', the path is considered to be    |
|                           | | relative to the site root.                       |
|                           | |                                                  |
|                           | | There is no default value.                       |
+---------------------------+----------------------------------------------------+
| arguments                 | | Optional string attribute.                       |
|                           | |                                                  |
|                           | | Arguments to the executable or script            |
|                           | | specified in **processPath**.                    |
|                           | |                                                  |
|                           | | The default value is an empty string.            |
+---------------------------+----------------------------------------------------+
| startupTimeLimit          | | Optional integer attribute.                      |
|                           | |                                                  |
|                           | | Duration in seconds for which the                |
|                           | | the handler will wait for the executable or      |
|                           | | script to start a process listening on           |
|                           | | the port. If this time limit is exceeded,        |
|                           | | the handler will kill the process and attempt to |
|                           | | launch it again **startupRetryCount** times.     |
|                           | |                                                  |
|                           | | The default value is 120.                        |
+---------------------------+----------------------------------------------------+
| shutdownTimeLimit         | | Optional integer attribute.                      |
|                           | |                                                  |
|                           | | Duration in seconds for which the                |
|                           | | the handler will wait for the executable or      |
|                           | | script to gracefully shutdown when the           |
|                           | | *app_offline.htm* file is detected.              |
|                           | |                                                  |
|                           | | The default value is 10.                         |
+---------------------------+----------------------------------------------------+
| rapidFailsPerMinute       | | Optional integer attribute.                      |
|                           | |                                                  |
|                           | | Specifies the number of times the process        |
|                           | | specified in **processPath** is allowed to crash |
|                           | | per minute. If this limit is exceeded,           |
|                           | | the handler will stop launching the              |
|                           | | process for the remainder of the minute.         |
|                           | |                                                  |
|                           | | The default value is 10.                         |
+---------------------------+----------------------------------------------------+
| requestTimeout            | | Optional timespan attribute.                     |
|                           | |                                                  |
|                           | | Specifies the duration for which the             |
|                           | | ASP.NET Core Module will wait for a response     |
|                           | | from the process listening on                    |
|                           | | %ASPNETCORE_PORT%.                               |
|                           | |                                                  |
|                           | | The default value is "00:02:00".                 |
+---------------------------+----------------------------------------------------+
| stdoutLogEnabled          | | Optional Boolean attribute.                      |
|                           | |                                                  |
|                           | | If true, **stdout** and **stderr** for the       |
|                           | | process specified in **processPath** will be     |
|                           | | redirected to the file specified in              |
|                           | | **stdoutLogFile**.                               |
|                           | |                                                  |
|                           | | The default value is false.                      |
+---------------------------+----------------------------------------------------+
| stdoutLogFile             | | Optional string attribute.                       |
|                           | |                                                  |
|                           | | Specifies the relative or absolute file path for |
|                           | | which **stdout** and **stderr** from the process |
|                           | | specified in **processPath** will be logged.     |
|                           | | Relative paths are relative to the root of the   |
|                           | | site. Any path starting with '.' will be         |
|                           | | relative to the site root and all other paths    |
|                           | | will be treated as absolute paths.               |
|                           | |                                                  |
|                           | | The default value is ``aspnetcore-stdout``.      |
+---------------------------+----------------------------------------------------+
| forwardWindowsAuthToken   | | True or False.                                   |
|                           | |                                                  |
|                           | | If  true, the token will be forwarded to the     |
|                           | | child process listening on %ASPNETCORE_PORT% as a|
|                           | | header 'MS-ASPNETCORE-WINAUTHTOKEN' per request. |
|                           | | It is the responsibility of that process to call |
|                           | | CloseHandle on this token per request.           |
|                           | |                                                  |
|                           | | The default value is false.                      |
+---------------------------+----------------------------------------------------+
| disableStartUpErrorPage   | | True or False.                                   |
|                           | |                                                  |
|                           | | If true, the **502.5 - Process Failure** page    |
|                           | | will be supressed and the 502 status code page   |
|                           | | configured in your *web.config* will take        |
|                           | | precedence.                                      |
|                           | |                                                  |
|                           | | The default value is false.                      |
+---------------------------+----------------------------------------------------+



Child Elements
^^^^^^^^^^^^^^^

+---------------------------+----------------------------------------------------+
| Attribute                 |     Description                                    |
+===========================+====================================================+
| environmentVariables      | | Configures **environmentVariables** collection   |
|                           | | for the process specified in **processPath**.    |
+---------------------------+----------------------------------------------------+
| recycleOnFileChange       | | Specify a list of files to monitor. If any of    |
|                           | | these files are updated/deleted, the ASP.NET     |
|                           | | Core Module will restart the backend process.    |
+---------------------------+----------------------------------------------------+

ASP.NET Core Module *app_offline.htm*
-------------------------------------

If you place a file with the name *app_offline.htm* at the root of a web application directory, the ASP.NET Core Module will attempt to gracefully shut-down the application and stop processing any new incoming requests. If the application is still running after ``shutdownTimeLimit`` number of seconds, the ASP.NET Core Module will kill the running process.

While the *app_offline.htm* file is present, the ASP.NET Core Module will respond to all requests by sending back the contents of the *app_offline.htm* file. Once the *app_offline.htm* file is removed, the next request loads the application, which then responds to requests.

ASP.NET Core Module Start-up Error Page
---------------------------------------

.. image:: aspnet-core-module/_static/ANCM-502_5.png

If the ASP.NET Core Module fails to launch the backend process or the backend process starts but fails to listen on the configured port, you will see an HTTP 502.5 status code page. To supress this page and revert to the default IIS 502 status code page, use the ``disableStartUpErrorPage`` attribute. Look at the `HTTP Errors attribute <https://www.iis.net/configreference/system.webserver/httperrors>`__ to override this page with a custom error page.

ASP.NET Core Module configuration examples
-------------------------------------------

.. _log-redirection:

Log creation and redirection
^^^^^^^^^^^^^^^^^^^^^^^^^^^^

To save logs, you must create the *logs* directory. The ASP.NET Core Module can redirect ``stdout`` and ``stderr`` logs to disk by setting the ``stdoutLogEnabled`` and ``stdoutLogFile`` attributes of the ``aspNetCore`` element. Logs are not rotated (unless process recycling/restart occurs). It is the responsibilty of the hoster to limit the disk space the logs consume.

.. literalinclude:: aspnet-core-module/sample/web.config
  :language: xml
  :lines: 12-15,19


Setting environment variables
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

The ASP.NET Core Module allows you specify environment variables for the process specified in the ``processPath`` setting by specifying them in ``environmentVariables`` child attribute to the ``aspNetCore`` attribute.

.. literalinclude:: aspnet-core-module/sample/web.config
  :language: xml
  :lines: 12-19

ASP.NET Core Module with IIS Shared Configuration
-------------------------------------------------

The ASP.NET Core Module installer, which is included in the .NET Core Windows Server Hosting bundle installer, runs with the privileges of the **SYSTEM** account. Because the local system account does not have modify permission for the share path which is used by the IIS Shared Configuration, the installer will hit an access denied error when attempting to configure the module settings in *applicationhost.config* on the share.

The unsupported workaround is to disable the IIS Shared Configuration, run the installer, export the updated *applicationhost.config* file to the share, and re-enable the IIS Shared Configuration.
