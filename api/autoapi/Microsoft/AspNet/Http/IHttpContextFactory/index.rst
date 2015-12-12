

IHttpContextFactory Interface
=============================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IHttpContextFactory





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Http.Abstractions/IHttpContextFactory.cs>`_





.. dn:interface:: Microsoft.AspNet.Http.IHttpContextFactory

Methods
-------

.. dn:interface:: Microsoft.AspNet.Http.IHttpContextFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.IHttpContextFactory.Create(Microsoft.AspNet.Http.Features.IFeatureCollection)
    
        
        
        
        :type featureCollection: Microsoft.AspNet.Http.Features.IFeatureCollection
        :rtype: Microsoft.AspNet.Http.HttpContext
    
        
        .. code-block:: csharp
    
           HttpContext Create(IFeatureCollection featureCollection)
    
    .. dn:method:: Microsoft.AspNet.Http.IHttpContextFactory.Dispose(Microsoft.AspNet.Http.HttpContext)
    
        
        
        
        :type httpContext: Microsoft.AspNet.Http.HttpContext
    
        
        .. code-block:: csharp
    
           void Dispose(HttpContext httpContext)
    

