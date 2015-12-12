

HeaderDictionaryTypeExtensions Class
====================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.HeaderDictionaryTypeExtensions`








Syntax
------

.. code-block:: csharp

   public class HeaderDictionaryTypeExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.Http.Extensions/HeaderDictionaryTypeExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Http.HeaderDictionaryTypeExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Http.HeaderDictionaryTypeExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.HeaderDictionaryTypeExtensions.GetTypedHeaders(Microsoft.AspNet.Http.HttpRequest)
    
        
        
        
        :type request: Microsoft.AspNet.Http.HttpRequest
        :rtype: Microsoft.AspNet.Http.Headers.RequestHeaders
    
        
        .. code-block:: csharp
    
           public static RequestHeaders GetTypedHeaders(HttpRequest request)
    
    .. dn:method:: Microsoft.AspNet.Http.HeaderDictionaryTypeExtensions.GetTypedHeaders(Microsoft.AspNet.Http.HttpResponse)
    
        
        
        
        :type response: Microsoft.AspNet.Http.HttpResponse
        :rtype: Microsoft.AspNet.Http.Headers.ResponseHeaders
    
        
        .. code-block:: csharp
    
           public static ResponseHeaders GetTypedHeaders(HttpResponse response)
    

