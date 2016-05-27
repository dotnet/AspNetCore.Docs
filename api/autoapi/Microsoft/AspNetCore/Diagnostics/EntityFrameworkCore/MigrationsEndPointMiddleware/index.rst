

MigrationsEndPointMiddleware Class
==================================






Processes requests to execute migrations operations. The middleware will listen for requests to the path configured in the supplied options.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore`
Assemblies
    * Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.MigrationsEndPointMiddleware`








Syntax
------

.. code-block:: csharp

    public class MigrationsEndPointMiddleware








.. dn:class:: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.MigrationsEndPointMiddleware
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.MigrationsEndPointMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.MigrationsEndPointMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.MigrationsEndPointMiddleware.MigrationsEndPointMiddleware(Microsoft.AspNetCore.Http.RequestDelegate, System.IServiceProvider, Microsoft.Extensions.Logging.ILogger<Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.MigrationsEndPointMiddleware>, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Builder.MigrationsEndPointOptions>)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.MigrationsEndPointMiddleware` class
    
        
    
        
        :param next: Delegate to execute the next piece of middleware in the request pipeline.
        
        :type next: Microsoft.AspNetCore.Http.RequestDelegate
    
        
        :param serviceProvider: The :any:`System.IServiceProvider` to resolve services from.
        
        :type serviceProvider: System.IServiceProvider
    
        
        :param logger: The :any:`Microsoft.Extensions.Logging.Logger\`1` to write messages to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger<Microsoft.Extensions.Logging.ILogger`1>{Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.MigrationsEndPointMiddleware<Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.MigrationsEndPointMiddleware>}
    
        
        :param options: The options to control the behavior of the middleware.
        
        :type options: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Builder.MigrationsEndPointOptions<Microsoft.AspNetCore.Builder.MigrationsEndPointOptions>}
    
        
        .. code-block:: csharp
    
            public MigrationsEndPointMiddleware(RequestDelegate next, IServiceProvider serviceProvider, ILogger<MigrationsEndPointMiddleware> logger, IOptions<MigrationsEndPointOptions> options)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.MigrationsEndPointMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.MigrationsEndPointMiddleware.Invoke(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        Process an individual request.
    
        
    
        
        :param context: The context for the current request.
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
        :return: A task that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
            public virtual Task Invoke(HttpContext context)
    

