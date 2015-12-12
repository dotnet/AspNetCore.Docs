

DeveloperExceptionPageMiddleware Class
======================================



.. contents:: 
   :local:



Summary
-------

Captures synchronous and asynchronous exceptions from the pipeline and generates HTML error responses.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Diagnostics.DeveloperExceptionPageMiddleware`








Syntax
------

.. code-block:: csharp

   public class DeveloperExceptionPageMiddleware





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/diagnostics/src/Microsoft.AspNet.Diagnostics/DeveloperExceptionPage/DeveloperExceptionPageMiddleware.cs>`_





.. dn:class:: Microsoft.AspNet.Diagnostics.DeveloperExceptionPageMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNet.Diagnostics.DeveloperExceptionPageMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Diagnostics.DeveloperExceptionPageMiddleware.DeveloperExceptionPageMiddleware(Microsoft.AspNet.Builder.RequestDelegate, Microsoft.AspNet.Diagnostics.ErrorPageOptions, Microsoft.Extensions.Logging.ILoggerFactory, Microsoft.Extensions.PlatformAbstractions.IApplicationEnvironment, System.Diagnostics.DiagnosticSource)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Diagnostics.DeveloperExceptionPageMiddleware` class
    
        
        
        
        :type next: Microsoft.AspNet.Builder.RequestDelegate
        
        
        :type options: Microsoft.AspNet.Diagnostics.ErrorPageOptions
        
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
        
        
        :type appEnvironment: Microsoft.Extensions.PlatformAbstractions.IApplicationEnvironment
        
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        .. code-block:: csharp
    
           public DeveloperExceptionPageMiddleware(RequestDelegate next, ErrorPageOptions options, ILoggerFactory loggerFactory, IApplicationEnvironment appEnvironment, DiagnosticSource diagnosticSource)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Diagnostics.DeveloperExceptionPageMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Diagnostics.DeveloperExceptionPageMiddleware.Invoke(Microsoft.AspNet.Http.HttpContext)
    
        
    
        Process an individual request.
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task Invoke(HttpContext context)
    

