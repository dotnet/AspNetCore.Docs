

IISMiddleware Class
===================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.IISIntegration`
Assemblies
    * Microsoft.AspNetCore.Server.IISIntegration

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Server.IISIntegration.IISMiddleware`








Syntax
------

.. code-block:: csharp

    public class IISMiddleware








.. dn:class:: Microsoft.AspNetCore.Server.IISIntegration.IISMiddleware
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.IISIntegration.IISMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.IISIntegration.IISMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.IISIntegration.IISMiddleware.IISMiddleware(Microsoft.AspNetCore.Http.RequestDelegate, Microsoft.Extensions.Logging.ILoggerFactory, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Builder.IISOptions>, System.String)
    
        
    
        
        :type next: Microsoft.AspNetCore.Http.RequestDelegate
    
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        :type options: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Builder.IISOptions<Microsoft.AspNetCore.Builder.IISOptions>}
    
        
        :type pairingToken: System.String
    
        
        .. code-block:: csharp
    
            public IISMiddleware(RequestDelegate next, ILoggerFactory loggerFactory, IOptions<IISOptions> options, string pairingToken)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.IISIntegration.IISMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.IISIntegration.IISMiddleware.Invoke(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task Invoke(HttpContext httpContext)
    

