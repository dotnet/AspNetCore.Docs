

SendFileMiddleware Class
========================



.. contents:: 
   :local:



Summary
-------

This middleware provides an efficient fallback mechanism for sending static files
when the server does not natively support such a feature.
The caller is responsible for setting all headers in advance.
The caller is responsible for performing the correct impersonation to give access to the file.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.StaticFiles.SendFileMiddleware`








Syntax
------

.. code-block:: csharp

   public class SendFileMiddleware





GitHub
------

`View on GitHub <https://github.com/aspnet/staticfiles/blob/master/src/Microsoft.AspNet.StaticFiles/SendFileMiddleware.cs>`_





.. dn:class:: Microsoft.AspNet.StaticFiles.SendFileMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNet.StaticFiles.SendFileMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.StaticFiles.SendFileMiddleware.SendFileMiddleware(Microsoft.AspNet.Builder.RequestDelegate, Microsoft.Extensions.Logging.ILoggerFactory)
    
        
    
        Creates a new instance of the SendFileMiddleware.
    
        
        
        
        :param next: The next middleware in the pipeline.
        
        :type next: Microsoft.AspNet.Builder.RequestDelegate
        
        
        :param loggerFactory: An  instance used to create loggers.
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
           public SendFileMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.StaticFiles.SendFileMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.StaticFiles.SendFileMiddleware.Invoke(Microsoft.AspNet.Http.HttpContext)
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task Invoke(HttpContext context)
    

