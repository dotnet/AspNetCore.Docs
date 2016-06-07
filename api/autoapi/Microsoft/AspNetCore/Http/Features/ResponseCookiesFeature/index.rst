

ResponseCookiesFeature Class
============================






Default implementation of :any:`Microsoft.AspNetCore.Http.Features.IResponseCookiesFeature`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Http.Features`
Assemblies
    * Microsoft.AspNetCore.Http

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Http.Features.ResponseCookiesFeature`








Syntax
------

.. code-block:: csharp

    public class ResponseCookiesFeature : IResponseCookiesFeature








.. dn:class:: Microsoft.AspNetCore.Http.Features.ResponseCookiesFeature
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.Features.ResponseCookiesFeature

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Http.Features.ResponseCookiesFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.ResponseCookiesFeature.Cookies
    
        
        :rtype: Microsoft.AspNetCore.Http.IResponseCookies
    
        
        .. code-block:: csharp
    
            public IResponseCookies Cookies
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Http.Features.ResponseCookiesFeature
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Http.Features.ResponseCookiesFeature.ResponseCookiesFeature(Microsoft.AspNetCore.Http.Features.IFeatureCollection)
    
        
    
        
        Initializes a new :any:`Microsoft.AspNetCore.Http.Features.ResponseCookiesFeature` instance.
    
        
    
        
        :param features: 
            :any:`Microsoft.AspNetCore.Http.Features.IFeatureCollection` containing all defined features, including this
            :any:`Microsoft.AspNetCore.Http.Features.IResponseCookiesFeature` and the :any:`Microsoft.AspNetCore.Http.Features.IHttpResponseFeature`\.
        
        :type features: Microsoft.AspNetCore.Http.Features.IFeatureCollection
    
        
        .. code-block:: csharp
    
            public ResponseCookiesFeature(IFeatureCollection features)
    
    .. dn:constructor:: Microsoft.AspNetCore.Http.Features.ResponseCookiesFeature.ResponseCookiesFeature(Microsoft.AspNetCore.Http.Features.IFeatureCollection, Microsoft.Extensions.ObjectPool.ObjectPool<System.Text.StringBuilder>)
    
        
    
        
        Initializes a new :any:`Microsoft.AspNetCore.Http.Features.ResponseCookiesFeature` instance.
    
        
    
        
        :param features: 
            :any:`Microsoft.AspNetCore.Http.Features.IFeatureCollection` containing all defined features, including this
            :any:`Microsoft.AspNetCore.Http.Features.IResponseCookiesFeature` and the :any:`Microsoft.AspNetCore.Http.Features.IHttpResponseFeature`\.
        
        :type features: Microsoft.AspNetCore.Http.Features.IFeatureCollection
    
        
        :param builderPool: The :any:`Microsoft.Extensions.ObjectPool.ObjectPool\`1`\, if available.
        
        :type builderPool: Microsoft.Extensions.ObjectPool.ObjectPool<Microsoft.Extensions.ObjectPool.ObjectPool`1>{System.Text.StringBuilder<System.Text.StringBuilder>}
    
        
        .. code-block:: csharp
    
            public ResponseCookiesFeature(IFeatureCollection features, ObjectPool<StringBuilder> builderPool)
    

