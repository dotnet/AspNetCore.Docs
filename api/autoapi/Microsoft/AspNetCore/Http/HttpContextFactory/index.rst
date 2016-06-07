

HttpContextFactory Class
========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Http`
Assemblies
    * Microsoft.AspNetCore.Http

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Http.HttpContextFactory`








Syntax
------

.. code-block:: csharp

    public class HttpContextFactory : IHttpContextFactory








.. dn:class:: Microsoft.AspNetCore.Http.HttpContextFactory
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.HttpContextFactory

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Http.HttpContextFactory
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Http.HttpContextFactory.HttpContextFactory(Microsoft.Extensions.ObjectPool.ObjectPoolProvider, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Http.Features.FormOptions>)
    
        
    
        
        :type poolProvider: Microsoft.Extensions.ObjectPool.ObjectPoolProvider
    
        
        :type formOptions: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Http.Features.FormOptions<Microsoft.AspNetCore.Http.Features.FormOptions>}
    
        
        .. code-block:: csharp
    
            public HttpContextFactory(ObjectPoolProvider poolProvider, IOptions<FormOptions> formOptions)
    
    .. dn:constructor:: Microsoft.AspNetCore.Http.HttpContextFactory.HttpContextFactory(Microsoft.Extensions.ObjectPool.ObjectPoolProvider, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Http.Features.FormOptions>, Microsoft.AspNetCore.Http.IHttpContextAccessor)
    
        
    
        
        :type poolProvider: Microsoft.Extensions.ObjectPool.ObjectPoolProvider
    
        
        :type formOptions: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Http.Features.FormOptions<Microsoft.AspNetCore.Http.Features.FormOptions>}
    
        
        :type httpContextAccessor: Microsoft.AspNetCore.Http.IHttpContextAccessor
    
        
        .. code-block:: csharp
    
            public HttpContextFactory(ObjectPoolProvider poolProvider, IOptions<FormOptions> formOptions, IHttpContextAccessor httpContextAccessor)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Http.HttpContextFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.HttpContextFactory.Create(Microsoft.AspNetCore.Http.Features.IFeatureCollection)
    
        
    
        
        :type featureCollection: Microsoft.AspNetCore.Http.Features.IFeatureCollection
        :rtype: Microsoft.AspNetCore.Http.HttpContext
    
        
        .. code-block:: csharp
    
            public HttpContext Create(IFeatureCollection featureCollection)
    
    .. dn:method:: Microsoft.AspNetCore.Http.HttpContextFactory.Dispose(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
    
        
        .. code-block:: csharp
    
            public void Dispose(HttpContext httpContext)
    

