

ExceptionHandlerMiddleware Class
================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Diagnostics.ExceptionHandlerMiddleware`








Syntax
------

.. code-block:: csharp

   public class ExceptionHandlerMiddleware





GitHub
------

`View on GitHub <https://github.com/aspnet/diagnostics/blob/master/src/Microsoft.AspNet.Diagnostics/ExceptionHandler/ExceptionHandlerMiddleware.cs>`_





.. dn:class:: Microsoft.AspNet.Diagnostics.ExceptionHandlerMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNet.Diagnostics.ExceptionHandlerMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Diagnostics.ExceptionHandlerMiddleware.ExceptionHandlerMiddleware(Microsoft.AspNet.Builder.RequestDelegate, Microsoft.Extensions.Logging.ILoggerFactory, Microsoft.AspNet.Diagnostics.ExceptionHandlerOptions, System.Diagnostics.DiagnosticSource)
    
        
        
        
        :type next: Microsoft.AspNet.Builder.RequestDelegate
        
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
        
        
        :type options: Microsoft.AspNet.Diagnostics.ExceptionHandlerOptions
        
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        .. code-block:: csharp
    
           public ExceptionHandlerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory, ExceptionHandlerOptions options, DiagnosticSource diagnosticSource)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Diagnostics.ExceptionHandlerMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Diagnostics.ExceptionHandlerMiddleware.Invoke(Microsoft.AspNet.Http.HttpContext)
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task Invoke(HttpContext context)
    

