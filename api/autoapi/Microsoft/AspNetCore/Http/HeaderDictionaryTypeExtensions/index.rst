

HeaderDictionaryTypeExtensions Class
====================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Http`
Assemblies
    * Microsoft.AspNetCore.Http.Extensions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Http.HeaderDictionaryTypeExtensions`








Syntax
------

.. code-block:: csharp

    public class HeaderDictionaryTypeExtensions








.. dn:class:: Microsoft.AspNetCore.Http.HeaderDictionaryTypeExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.HeaderDictionaryTypeExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Http.HeaderDictionaryTypeExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.HeaderDictionaryTypeExtensions.AppendList<T>(Microsoft.AspNetCore.Http.IHeaderDictionary, System.String, System.Collections.Generic.IList<T>)
    
        
    
        
        :type Headers: Microsoft.AspNetCore.Http.IHeaderDictionary
    
        
        :type name: System.String
    
        
        :type values: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{T}
    
        
        .. code-block:: csharp
    
            public static void AppendList<T>(IHeaderDictionary Headers, string name, IList<T> values)
    
    .. dn:method:: Microsoft.AspNetCore.Http.HeaderDictionaryTypeExtensions.GetTypedHeaders(Microsoft.AspNetCore.Http.HttpRequest)
    
        
    
        
        :type request: Microsoft.AspNetCore.Http.HttpRequest
        :rtype: Microsoft.AspNetCore.Http.Headers.RequestHeaders
    
        
        .. code-block:: csharp
    
            public static RequestHeaders GetTypedHeaders(HttpRequest request)
    
    .. dn:method:: Microsoft.AspNetCore.Http.HeaderDictionaryTypeExtensions.GetTypedHeaders(Microsoft.AspNetCore.Http.HttpResponse)
    
        
    
        
        :type response: Microsoft.AspNetCore.Http.HttpResponse
        :rtype: Microsoft.AspNetCore.Http.Headers.ResponseHeaders
    
        
        .. code-block:: csharp
    
            public static ResponseHeaders GetTypedHeaders(HttpResponse response)
    

