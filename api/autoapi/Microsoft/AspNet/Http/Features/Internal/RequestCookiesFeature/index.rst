

RequestCookiesFeature Class
===========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.Features.Internal.RequestCookiesFeature`








Syntax
------

.. code-block:: csharp

   public class RequestCookiesFeature : IRequestCookiesFeature, IFeatureCache





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Http/Features/RequestCookiesFeature.cs>`_





.. dn:class:: Microsoft.AspNet.Http.Features.Internal.RequestCookiesFeature

Constructors
------------

.. dn:class:: Microsoft.AspNet.Http.Features.Internal.RequestCookiesFeature
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Http.Features.Internal.RequestCookiesFeature.RequestCookiesFeature(Microsoft.AspNet.Http.Features.IFeatureCollection)
    
        
        
        
        :type features: Microsoft.AspNet.Http.Features.IFeatureCollection
    
        
        .. code-block:: csharp
    
           public RequestCookiesFeature(IFeatureCollection features)
    
    .. dn:constructor:: Microsoft.AspNet.Http.Features.Internal.RequestCookiesFeature.RequestCookiesFeature(Microsoft.AspNet.Http.IReadableStringCollection)
    
        
        
        
        :type cookies: Microsoft.AspNet.Http.IReadableStringCollection
    
        
        .. code-block:: csharp
    
           public RequestCookiesFeature(IReadableStringCollection cookies)
    
    .. dn:constructor:: Microsoft.AspNet.Http.Features.Internal.RequestCookiesFeature.RequestCookiesFeature(System.Collections.Generic.IDictionary<System.String, Microsoft.Extensions.Primitives.StringValues>)
    
        
        
        
        :type cookies: System.Collections.Generic.IDictionary{System.String,Microsoft.Extensions.Primitives.StringValues}
    
        
        .. code-block:: csharp
    
           public RequestCookiesFeature(IDictionary<string, StringValues> cookies)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Http.Features.Internal.RequestCookiesFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.Features.Internal.RequestCookiesFeature.Cookies
    
        
        :rtype: Microsoft.AspNet.Http.IReadableStringCollection
    
        
        .. code-block:: csharp
    
           public IReadableStringCollection Cookies { get; set; }
    

