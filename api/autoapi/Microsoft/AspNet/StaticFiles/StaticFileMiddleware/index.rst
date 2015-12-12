

StaticFileMiddleware Class
==========================



.. contents:: 
   :local:



Summary
-------

Enables serving static files for a given request path





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.StaticFiles.StaticFileMiddleware`








Syntax
------

.. code-block:: csharp

   public class StaticFileMiddleware





GitHub
------

`View on GitHub <https://github.com/aspnet/staticfiles/blob/master/src/Microsoft.AspNet.StaticFiles/StaticFileMiddleware.cs>`_





.. dn:class:: Microsoft.AspNet.StaticFiles.StaticFileMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNet.StaticFiles.StaticFileMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.StaticFiles.StaticFileMiddleware.StaticFileMiddleware(Microsoft.AspNet.Builder.RequestDelegate, Microsoft.AspNet.Hosting.IHostingEnvironment, Microsoft.AspNet.StaticFiles.StaticFileOptions, Microsoft.Extensions.Logging.ILoggerFactory)
    
        
    
        Creates a new instance of the StaticFileMiddleware.
    
        
        
        
        :param next: The next middleware in the pipeline.
        
        :type next: Microsoft.AspNet.Builder.RequestDelegate
        
        
        :type hostingEnv: Microsoft.AspNet.Hosting.IHostingEnvironment
        
        
        :param options: The configuration options.
        
        :type options: Microsoft.AspNet.StaticFiles.StaticFileOptions
        
        
        :param loggerFactory: An  instance used to create loggers.
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
           public StaticFileMiddleware(RequestDelegate next, IHostingEnvironment hostingEnv, StaticFileOptions options, ILoggerFactory loggerFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.StaticFiles.StaticFileMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.StaticFiles.StaticFileMiddleware.Invoke(Microsoft.AspNet.Http.HttpContext)
    
        
    
        Processes a request to determine if it matches a known file, and if so, serves it.
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task Invoke(HttpContext context)
    

