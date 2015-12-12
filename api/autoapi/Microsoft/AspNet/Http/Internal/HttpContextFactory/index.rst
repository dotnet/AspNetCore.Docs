

HttpContextFactory Class
========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.Internal.HttpContextFactory`








Syntax
------

.. code-block:: csharp

   public class HttpContextFactory : IHttpContextFactory





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Http/HttpContextFactory.cs>`_





.. dn:class:: Microsoft.AspNet.Http.Internal.HttpContextFactory

Constructors
------------

.. dn:class:: Microsoft.AspNet.Http.Internal.HttpContextFactory
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Http.Internal.HttpContextFactory.HttpContextFactory(Microsoft.AspNet.Http.IHttpContextAccessor)
    
        
        
        
        :type httpContextAccessor: Microsoft.AspNet.Http.IHttpContextAccessor
    
        
        .. code-block:: csharp
    
           public HttpContextFactory(IHttpContextAccessor httpContextAccessor)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Http.Internal.HttpContextFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.Internal.HttpContextFactory.Create(Microsoft.AspNet.Http.Features.IFeatureCollection)
    
        
        
        
        :type featureCollection: Microsoft.AspNet.Http.Features.IFeatureCollection
        :rtype: Microsoft.AspNet.Http.HttpContext
    
        
        .. code-block:: csharp
    
           public HttpContext Create(IFeatureCollection featureCollection)
    
    .. dn:method:: Microsoft.AspNet.Http.Internal.HttpContextFactory.Dispose(Microsoft.AspNet.Http.HttpContext)
    
        
        
        
        :type httpContext: Microsoft.AspNet.Http.HttpContext
    
        
        .. code-block:: csharp
    
           public void Dispose(HttpContext httpContext)
    

