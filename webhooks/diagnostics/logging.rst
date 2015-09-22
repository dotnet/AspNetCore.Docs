Logging
=======

Microsoft ASP.NET WebHooks uses logging as a way of reporting issues and problems. By 
default logs are written using `System.Diagnostics.Trace <https://msdn.microsoft.com/en-us/library/system.diagnostics.trace>`_ where they can be manged using 
`Trace Listeners <https://msdn.microsoft.com/en-us/library/system.diagnostics.tracelistener.aspx>`_ 
like any other log stream.

When deploying your Web Application as an Azure Web App, the logs are automatically picked up and can be
managed together with any other `System.Diagnostics.Trace`_ logging. For details, please see `Enable diagnostics 
logging for web apps in Azure App Service <https://azure.microsoft.com/en-us/documentation/articles/web-sites-enable-diagnostic-log/>`_

In addition, logs can be obtained straight from inside Visual Studio as described in `Troubleshoot a web app in Azure App Service using 
Visual Studio <https://azure.microsoft.com/en-us/documentation/articles/web-sites-dotnet-troubleshoot-visual-studio/#webserverlogs>`_.

Redirecting Logs
----------------

Instead of writing logs to `System.Diagnostics.Trace`_, it is possible to provide an alternate logging implementation that 
can log directly to a log manager such as `Log4Net <http://logging.apache.org/log4net/>`_ and `NLog <http://nlog-project.org/>`_.
Simply provide an implementation of `ILogger <https://github.com/aspnet/WebHooks/blob/master/src/Microsoft.AspNet.WebHooks.Common/Diagnostics/ILogger.cs>`_ 
and register it with a dependency injection engine of your choice and it will get picked up by Microsoft ASP.NET WebHooks. 
Please see `Dependency Injection in ASP.NET Web API 2 <http://www.asp.net/web-api/overview/advanced/dependency-injection>`_ for details.