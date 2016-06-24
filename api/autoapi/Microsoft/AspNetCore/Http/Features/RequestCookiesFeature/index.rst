

RequestCookiesFeature Class
===========================





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
* :dn:cls:`Microsoft.AspNetCore.Http.Features.RequestCookiesFeature`








Syntax
------

.. code-block:: csharp

    public class RequestCookiesFeature : IRequestCookiesFeature








.. dn:class:: Microsoft.AspNetCore.Http.Features.RequestCookiesFeature
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.Features.RequestCookiesFeature

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Http.Features.RequestCookiesFeature
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Http.Features.RequestCookiesFeature.RequestCookiesFeature(Microsoft.AspNetCore.Http.Features.IFeatureCollection)
    
        
    
        
        :type features: Microsoft.AspNetCore.Http.Features.IFeatureCollection
    
        
        .. code-block:: csharp
    
            public RequestCookiesFeature(IFeatureCollection features)
    
    .. dn:constructor:: Microsoft.AspNetCore.Http.Features.RequestCookiesFeature.RequestCookiesFeature(Microsoft.AspNetCore.Http.IRequestCookieCollection)
    
        
    
        
        :type cookies: Microsoft.AspNetCore.Http.IRequestCookieCollection
    
        
        .. code-block:: csharp
    
            public RequestCookiesFeature(IRequestCookieCollection cookies)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Http.Features.RequestCookiesFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.RequestCookiesFeature.Cookies
    
        
        :rtype: Microsoft.AspNetCore.Http.IRequestCookieCollection
    
        
        .. code-block:: csharp
    
            public IRequestCookieCollection Cookies { get; set; }
    

