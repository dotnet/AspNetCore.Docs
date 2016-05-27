

IHttpContextFactory Interface
=============================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Http`
Assemblies
    * Microsoft.AspNetCore.Http.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IHttpContextFactory








.. dn:interface:: Microsoft.AspNetCore.Http.IHttpContextFactory
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Http.IHttpContextFactory

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Http.IHttpContextFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.IHttpContextFactory.Create(Microsoft.AspNetCore.Http.Features.IFeatureCollection)
    
        
    
        
        :type featureCollection: Microsoft.AspNetCore.Http.Features.IFeatureCollection
        :rtype: Microsoft.AspNetCore.Http.HttpContext
    
        
        .. code-block:: csharp
    
            HttpContext Create(IFeatureCollection featureCollection)
    
    .. dn:method:: Microsoft.AspNetCore.Http.IHttpContextFactory.Dispose(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
    
        
        .. code-block:: csharp
    
            void Dispose(HttpContext httpContext)
    

