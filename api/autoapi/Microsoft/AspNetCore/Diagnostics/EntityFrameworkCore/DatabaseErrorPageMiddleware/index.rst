

DatabaseErrorPageMiddleware Class
=================================






Captures synchronous and asynchronous database related exceptions from the pipeline that may be resolved using Entity Framework
migrations. When these exceptions occur an HTML response with details of possible actions to resolve the issue is generated.


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
* :dn:cls:`Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DatabaseErrorPageMiddleware`








Syntax
------

.. code-block:: csharp

    public class DatabaseErrorPageMiddleware








.. dn:class:: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DatabaseErrorPageMiddleware
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DatabaseErrorPageMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DatabaseErrorPageMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DatabaseErrorPageMiddleware.DatabaseErrorPageMiddleware(Microsoft.AspNetCore.Http.RequestDelegate, System.IServiceProvider, Microsoft.Extensions.Logging.ILoggerFactory, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Builder.DatabaseErrorPageOptions>)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DatabaseErrorPageMiddleware` class
    
        
    
        
        :param next: Delegate to execute the next piece of middleware in the request pipeline.
        
        :type next: Microsoft.AspNetCore.Http.RequestDelegate
    
        
        :param serviceProvider: The :any:`System.IServiceProvider` to resolve services from.
        
        :type serviceProvider: System.IServiceProvider
    
        
        :param loggerFactory: 
            The :any:`Microsoft.Extensions.Logging.ILoggerFactory` for the application. This middleware both produces logging messages and 
            consumes them to detect database related exception.
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        :param options: The options to control what information is displayed on the error page.
        
        :type options: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Builder.DatabaseErrorPageOptions<Microsoft.AspNetCore.Builder.DatabaseErrorPageOptions>}
    
        
        .. code-block:: csharp
    
            public DatabaseErrorPageMiddleware(RequestDelegate next, IServiceProvider serviceProvider, ILoggerFactory loggerFactory, IOptions<DatabaseErrorPageOptions> options)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DatabaseErrorPageMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DatabaseErrorPageMiddleware.Invoke(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        Process an individual request.
    
        
    
        
        :param context: The context for the current request.
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
        :return: A task that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
            public virtual Task Invoke(HttpContext context)
    

