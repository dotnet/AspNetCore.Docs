

DeveloperExceptionPageMiddleware Class
======================================






Captures synchronous and asynchronous exceptions from the pipeline and generates HTML error responses.


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
* :dn:cls:`Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware`








Syntax
------

.. code-block:: csharp

    public class DeveloperExceptionPageMiddleware








.. dn:class:: Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware.DeveloperExceptionPageMiddleware(Microsoft.AspNetCore.Http.RequestDelegate, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Builder.DeveloperExceptionPageOptions>, Microsoft.Extensions.Logging.ILoggerFactory, Microsoft.AspNetCore.Hosting.IHostingEnvironment, System.Diagnostics.DiagnosticSource)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware` class
    
        
    
        
        :type next: Microsoft.AspNetCore.Http.RequestDelegate
    
        
        :type options: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Builder.DeveloperExceptionPageOptions<Microsoft.AspNetCore.Builder.DeveloperExceptionPageOptions>}
    
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        :type hostingEnvironment: Microsoft.AspNetCore.Hosting.IHostingEnvironment
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        .. code-block:: csharp
    
            public DeveloperExceptionPageMiddleware(RequestDelegate next, IOptions<DeveloperExceptionPageOptions> options, ILoggerFactory loggerFactory, IHostingEnvironment hostingEnvironment, DiagnosticSource diagnosticSource)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware.Invoke(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        Process an individual request.
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task Invoke(HttpContext context)
    

