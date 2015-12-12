

RequestServicesContainerMiddleware Class
========================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Hosting.Internal.RequestServicesContainerMiddleware`








Syntax
------

.. code-block:: csharp

   public class RequestServicesContainerMiddleware





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/hosting/src/Microsoft.AspNet.Hosting/Internal/RequestServicesContainerMiddleware.cs>`_





.. dn:class:: Microsoft.AspNet.Hosting.Internal.RequestServicesContainerMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNet.Hosting.Internal.RequestServicesContainerMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Hosting.Internal.RequestServicesContainerMiddleware.RequestServicesContainerMiddleware(Microsoft.AspNet.Builder.RequestDelegate, System.IServiceProvider)
    
        
        
        
        :type next: Microsoft.AspNet.Builder.RequestDelegate
        
        
        :type services: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           public RequestServicesContainerMiddleware(RequestDelegate next, IServiceProvider services)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Hosting.Internal.RequestServicesContainerMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Hosting.Internal.RequestServicesContainerMiddleware.Invoke(Microsoft.AspNet.Http.HttpContext)
    
        
        
        
        :type httpContext: Microsoft.AspNet.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task Invoke(HttpContext httpContext)
    

