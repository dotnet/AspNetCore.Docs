

RequestServicesContainerMiddleware Class
========================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Hosting.Internal`
Assemblies
    * Microsoft.AspNetCore.Hosting

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Hosting.Internal.RequestServicesContainerMiddleware`








Syntax
------

.. code-block:: csharp

    public class RequestServicesContainerMiddleware








.. dn:class:: Microsoft.AspNetCore.Hosting.Internal.RequestServicesContainerMiddleware
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Hosting.Internal.RequestServicesContainerMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Hosting.Internal.RequestServicesContainerMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Hosting.Internal.RequestServicesContainerMiddleware.RequestServicesContainerMiddleware(Microsoft.AspNetCore.Http.RequestDelegate, Microsoft.Extensions.DependencyInjection.IServiceScopeFactory)
    
        
    
        
        :type next: Microsoft.AspNetCore.Http.RequestDelegate
    
        
        :type scopeFactory: Microsoft.Extensions.DependencyInjection.IServiceScopeFactory
    
        
        .. code-block:: csharp
    
            public RequestServicesContainerMiddleware(RequestDelegate next, IServiceScopeFactory scopeFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Hosting.Internal.RequestServicesContainerMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Hosting.Internal.RequestServicesContainerMiddleware.Invoke(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task Invoke(HttpContext httpContext)
    

