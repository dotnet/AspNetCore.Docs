ASP.NET Core Module Configuration Reference
=============================================

By `Luke Latham`_, `Rick Anderson`_ and `Sourabh Shirhatti`_

In ASP.NET Core, the web application is hosted by an external process outside of IIS. The ASP.NET Core Module is an IIS 7.5+ module which is responsible for process management of ASP.NET Core http listeners and to proxy requests to processes that it manages. This document provides an overview of how to configure the ASP.NET Core Module for shared hosting of ASP.NET Core.

.. contents:: Sections:
  :local:
  :depth: 2

Installing the ASP.NET Core Module
----------------------------------

Install the `.NET Core Windows Server Hosting <http://go.microsoft.com/fwlink/?LinkId=798480>`__ bundle on the server. The bundle will install the .NET Core Runtime, .NET Core Library, and the ASP.NET Core Module.

Configuring the ASP.NET Core Module
-----------------------------------

The ASP.NET Core Module is configured via a site or application *web.config* file and has its own configuration section within ``system.webServer - aspNetCore``.

Configuration Attributes
^^^^^^^^^^^^^^^^^^^^^^^^^

+---------------------------+----------------------------------------------------+
| Attribute                 |     Description                                    |
+===========================+====================================================+
| processPath               | | Required string attribute.                       |
|                           | |                                                  |
|                           | | Path to the executable or script that will launch|
|                           | | a process listening for HTTP requests.           |
|                           | | Relative paths are supported. If the path        |
|                           | | begins with '.' the path is considered to be     |
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
|                           | | *app_offline.htm* file is detected               |
|                           | |                                                  |
|                           | | The default value is 10.                         |
+---------------------------+----------------------------------------------------+
| startupRetryCount         | | Optional integer attribute.                      |
|                           | |                                                  |
|                           | | The number of times the handler will try to      |
|                           | | launch the process specified in **processPath**. |
|                           | | See **startupTimeLimit** for details.            |
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

Child Elements
^^^^^^^^^^^^^^^

+---------------------------+----------------------------------------------------+
| Attribute                 |     Description                                    |
+===========================+====================================================+
| environmentVariables      | | Configures **environmentVariables** collection   |
|                           | | for the process specified in **processPath**.    |
+---------------------------+----------------------------------------------------+
| recycleOnFileChange       | | Specify a list of files to monitor. If any of    |
|                           | | these files get updated/deleted, the Core Module |
|                           | | will restart the backend process.                |
+---------------------------+----------------------------------------------------+

ASP.NET Core Module *app_offline.htm*
--------------------------------------

If you place a file with the name *app_offline.htm* at the root of a web application directory, the ASP.NET Core Module will attempt to gracefully shut-down the application and stop processing any new incoming requests. If the application is still running after ``shutdownTimeLimit`` number of seconds, the ASP.NET Core Module will kill the running process.

While the *app_offline..htm* file is present, the ASP.NET Core Module will repond to all requests by sending back the contents of the *app_offline.htm* file. Once the *app_offline.htm* file is removed, the next request loads the application, which then responds to requests.


ASP.NET Core Module configuration examples
-------------------------------------------

.. _log-redirection:

Log creation and redirection
^^^^^^^^^^^^^^^^^^^^^^^^^^^^

For logs to be saved, you must create the log directory. The ASP.NET Core Module can redirect ``stdout`` and ``stderr`` logs to disk by setting the ``stdoutLogEnabled`` and ``stdoutLogFile`` attributes of the ``aspNetCore`` element. Logs are not rotated. It is the responsibilty of the hoster to limit the disk space the logs consume.

.. literalinclude:: aspnet-core-module/sample/web.config
  :language: xml
  :lines: 12-15,19


Setting environment variables
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

The ASP.NET Core Module allows you specify environment variables for the process specified in the ``processPath`` setting by specifying them in ``environmentVariables`` child attribute to the ``aspNetCore`` attribute.

.. literalinclude:: aspnet-core-module/sample/web.config
  :language: xml
  :lines: 12-19
