

ResponseCookiesFeature Class
============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.Features.Internal.ResponseCookiesFeature`








Syntax
------

.. code-block:: csharp

   public class ResponseCookiesFeature : IResponseCookiesFeature, IFeatureCache





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Http/Features/ResponseCookiesFeature.cs>`_





.. dn:class:: Microsoft.AspNet.Http.Features.Internal.ResponseCookiesFeature

Constructors
------------

.. dn:class:: Microsoft.AspNet.Http.Features.Internal.ResponseCookiesFeature
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Http.Features.Internal.ResponseCookiesFeature.ResponseCookiesFeature(Microsoft.AspNet.Http.Features.IFeatureCollection)
    
        
        
        
        :type features: Microsoft.AspNet.Http.Features.IFeatureCollection
    
        
        .. code-block:: csharp
    
           public ResponseCookiesFeature(IFeatureCollection features)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Http.Features.Internal.ResponseCookiesFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.Features.Internal.ResponseCookiesFeature.Cookies
    
        
        :rtype: Microsoft.AspNet.Http.IResponseCookies
    
        
        .. code-block:: csharp
    
           public IResponseCookies Cookies { get; }
    

