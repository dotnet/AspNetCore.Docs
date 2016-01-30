

HttpRequestMessageFeature Class
===============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.WebApiCompatShim.HttpRequestMessageFeature`








Syntax
------

.. code-block:: csharp

   public class HttpRequestMessageFeature : IHttpRequestMessageFeature





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.WebApiCompatShim/HttpRequestMessage/HttpRequestMessageFeature.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.WebApiCompatShim.HttpRequestMessageFeature

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.WebApiCompatShim.HttpRequestMessageFeature
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.WebApiCompatShim.HttpRequestMessageFeature.HttpRequestMessageFeature(Microsoft.AspNet.Http.HttpContext)
    
        
        
        
        :type httpContext: Microsoft.AspNet.Http.HttpContext
    
        
        .. code-block:: csharp
    
           public HttpRequestMessageFeature(HttpContext httpContext)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.WebApiCompatShim.HttpRequestMessageFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.WebApiCompatShim.HttpRequestMessageFeature.HttpRequestMessage
    
        
        :rtype: System.Net.Http.HttpRequestMessage
    
        
        .. code-block:: csharp
    
           public HttpRequestMessage HttpRequestMessage { get; set; }
    

