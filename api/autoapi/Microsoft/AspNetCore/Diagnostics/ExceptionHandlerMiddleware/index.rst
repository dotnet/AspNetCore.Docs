

ExceptionHandlerMiddleware Class
================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Diagnostics`
Assemblies
    * Microsoft.AspNetCore.Diagnostics

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Diagnostics.ExceptionHandlerMiddleware`








Syntax
------

.. code-block:: csharp

    public class ExceptionHandlerMiddleware








.. dn:class:: Microsoft.AspNetCore.Diagnostics.ExceptionHandlerMiddleware
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Diagnostics.ExceptionHandlerMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.ExceptionHandlerMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Diagnostics.ExceptionHandlerMiddleware.ExceptionHandlerMiddleware(Microsoft.AspNetCore.Http.RequestDelegate, Microsoft.Extensions.Logging.ILoggerFactory, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Builder.ExceptionHandlerOptions>, System.Diagnostics.DiagnosticSource)
    
        
    
        
        :type next: Microsoft.AspNetCore.Http.RequestDelegate
    
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        :type options: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Builder.ExceptionHandlerOptions<Microsoft.AspNetCore.Builder.ExceptionHandlerOptions>}
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        .. code-block:: csharp
    
            public ExceptionHandlerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory, IOptions<ExceptionHandlerOptions> options, DiagnosticSource diagnosticSource)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.ExceptionHandlerMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Diagnostics.ExceptionHandlerMiddleware.Invoke(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task Invoke(HttpContext context)
    

