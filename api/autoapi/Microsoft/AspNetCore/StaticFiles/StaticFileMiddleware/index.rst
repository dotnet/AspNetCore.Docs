

StaticFileMiddleware Class
==========================






Enables serving static files for a given request path


Namespace
    :dn:ns:`Microsoft.AspNetCore.StaticFiles`
Assemblies
    * Microsoft.AspNetCore.StaticFiles

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.StaticFiles.StaticFileMiddleware`








Syntax
------

.. code-block:: csharp

    public class StaticFileMiddleware








.. dn:class:: Microsoft.AspNetCore.StaticFiles.StaticFileMiddleware
    :hidden:

.. dn:class:: Microsoft.AspNetCore.StaticFiles.StaticFileMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.StaticFiles.StaticFileMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.StaticFiles.StaticFileMiddleware.StaticFileMiddleware(Microsoft.AspNetCore.Http.RequestDelegate, Microsoft.AspNetCore.Hosting.IHostingEnvironment, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Builder.StaticFileOptions>, Microsoft.Extensions.Logging.ILoggerFactory)
    
        
    
        
        Creates a new instance of the StaticFileMiddleware.
    
        
    
        
        :param next: The next middleware in the pipeline.
        
        :type next: Microsoft.AspNetCore.Http.RequestDelegate
    
        
        :param hostingEnv: The :any:`Microsoft.AspNetCore.Hosting.IHostingEnvironment` used by this middleware.
        
        :type hostingEnv: Microsoft.AspNetCore.Hosting.IHostingEnvironment
    
        
        :param options: The configuration options.
        
        :type options: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Builder.StaticFileOptions<Microsoft.AspNetCore.Builder.StaticFileOptions>}
    
        
        :param loggerFactory: An :any:`Microsoft.Extensions.Logging.ILoggerFactory` instance used to create loggers.
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
            public StaticFileMiddleware(RequestDelegate next, IHostingEnvironment hostingEnv, IOptions<StaticFileOptions> options, ILoggerFactory loggerFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.StaticFiles.StaticFileMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.StaticFiles.StaticFileMiddleware.Invoke(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        Processes a request to determine if it matches a known file, and if so, serves it.
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task Invoke(HttpContext context)
    

