

MigrationsEndPointMiddleware Class
==================================



.. contents:: 
   :local:



Summary
-------

Processes requests to execute migrations operations. The middleware will listen for requests to the path configured in the supplied options.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Diagnostics.Entity.MigrationsEndPointMiddleware`








Syntax
------

.. code-block:: csharp

   public class MigrationsEndPointMiddleware





GitHub
------

`View on GitHub <https://github.com/aspnet/diagnostics/blob/master/src/Microsoft.AspNet.Diagnostics.Entity/MigrationsEndPointMiddleware.cs>`_





.. dn:class:: Microsoft.AspNet.Diagnostics.Entity.MigrationsEndPointMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNet.Diagnostics.Entity.MigrationsEndPointMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Diagnostics.Entity.MigrationsEndPointMiddleware.MigrationsEndPointMiddleware(Microsoft.AspNet.Builder.RequestDelegate, System.IServiceProvider, Microsoft.Extensions.Logging.ILogger<Microsoft.AspNet.Diagnostics.Entity.MigrationsEndPointMiddleware>, Microsoft.AspNet.Diagnostics.Entity.MigrationsEndPointOptions)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Diagnostics.Entity.MigrationsEndPointMiddleware` class
    
        
        
        
        :param next: Delegate to execute the next piece of middleware in the request pipeline.
        
        :type next: Microsoft.AspNet.Builder.RequestDelegate
        
        
        :param serviceProvider: The  to resolve services from.
        
        :type serviceProvider: System.IServiceProvider
        
        
        :param logger: The  to write messages to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger{Microsoft.AspNet.Diagnostics.Entity.MigrationsEndPointMiddleware}
        
        
        :param options: The options to control the behavior of the middleware.
        
        :type options: Microsoft.AspNet.Diagnostics.Entity.MigrationsEndPointOptions
    
        
        .. code-block:: csharp
    
           public MigrationsEndPointMiddleware(RequestDelegate next, IServiceProvider serviceProvider, ILogger<MigrationsEndPointMiddleware> logger, MigrationsEndPointOptions options)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Diagnostics.Entity.MigrationsEndPointMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Entity.MigrationsEndPointMiddleware.Invoke(Microsoft.AspNet.Http.HttpContext)
    
        
    
        Process an individual request.
    
        
        
        
        :param context: The context for the current request.
        
        :type context: Microsoft.AspNet.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
        :return: A task that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
           public virtual Task Invoke(HttpContext context)
    

