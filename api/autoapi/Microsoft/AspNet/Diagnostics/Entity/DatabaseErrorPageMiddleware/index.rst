

DatabaseErrorPageMiddleware Class
=================================



.. contents:: 
   :local:



Summary
-------

Captures synchronous and asynchronous database related exceptions from the pipeline that may be resolved using Entity Framework
migrations. When these exceptions occur an HTML response with details of possible actions to resolve the issue is generated.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Diagnostics.Entity.DatabaseErrorPageMiddleware`








Syntax
------

.. code-block:: csharp

   public class DatabaseErrorPageMiddleware





GitHub
------

`View on GitHub <https://github.com/aspnet/diagnostics/blob/master/src/Microsoft.AspNet.Diagnostics.Entity/DatabaseErrorPageMiddleware.cs>`_





.. dn:class:: Microsoft.AspNet.Diagnostics.Entity.DatabaseErrorPageMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNet.Diagnostics.Entity.DatabaseErrorPageMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Diagnostics.Entity.DatabaseErrorPageMiddleware.DatabaseErrorPageMiddleware(Microsoft.AspNet.Builder.RequestDelegate, System.IServiceProvider, Microsoft.Extensions.Logging.ILoggerFactory, Microsoft.AspNet.Diagnostics.Entity.DatabaseErrorPageOptions)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Diagnostics.Entity.DatabaseErrorPageMiddleware` class
    
        
        
        
        :param next: Delegate to execute the next piece of middleware in the request pipeline.
        
        :type next: Microsoft.AspNet.Builder.RequestDelegate
        
        
        :param serviceProvider: The  to resolve services from.
        
        :type serviceProvider: System.IServiceProvider
        
        
        :param loggerFactory: The  for the application. This middleware both produces logging messages and
            consumes them to detect database related exception.
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
        
        
        :param options: The options to control what information is displayed on the error page.
        
        :type options: Microsoft.AspNet.Diagnostics.Entity.DatabaseErrorPageOptions
    
        
        .. code-block:: csharp
    
           public DatabaseErrorPageMiddleware(RequestDelegate next, IServiceProvider serviceProvider, ILoggerFactory loggerFactory, DatabaseErrorPageOptions options)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Diagnostics.Entity.DatabaseErrorPageMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Entity.DatabaseErrorPageMiddleware.Invoke(Microsoft.AspNet.Http.HttpContext)
    
        
    
        Process an individual request.
    
        
        
        
        :param context: The context for the current request.
        
        :type context: Microsoft.AspNet.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
        :return: A task that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
           public virtual Task Invoke(HttpContext context)
    

