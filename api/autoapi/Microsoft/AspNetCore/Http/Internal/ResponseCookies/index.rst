

ResponseCookies Class
=====================






A wrapper for the response Set-Cookie header.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Http.Internal`
Assemblies
    * Microsoft.AspNetCore.Http

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Http.Internal.ResponseCookies`








Syntax
------

.. code-block:: csharp

    public class ResponseCookies : IResponseCookies








.. dn:class:: Microsoft.AspNetCore.Http.Internal.ResponseCookies
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.Internal.ResponseCookies

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Http.Internal.ResponseCookies
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Http.Internal.ResponseCookies.ResponseCookies(Microsoft.AspNetCore.Http.IHeaderDictionary, Microsoft.Extensions.ObjectPool.ObjectPool<System.Text.StringBuilder>)
    
        
    
        
        Create a new wrapper.
    
        
    
        
        :param headers: The :any:`Microsoft.AspNetCore.Http.IHeaderDictionary` for the response.
        
        :type headers: Microsoft.AspNetCore.Http.IHeaderDictionary
    
        
        :param builderPool: The :any:`Microsoft.Extensions.ObjectPool.ObjectPool\`1`\, if available.
        
        :type builderPool: Microsoft.Extensions.ObjectPool.ObjectPool<Microsoft.Extensions.ObjectPool.ObjectPool`1>{System.Text.StringBuilder<System.Text.StringBuilder>}
    
        
        .. code-block:: csharp
    
            public ResponseCookies(IHeaderDictionary headers, ObjectPool<StringBuilder> builderPool)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Http.Internal.ResponseCookies
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.Internal.ResponseCookies.Append(System.String, System.String)
    
        
    
        
        :type key: System.String
    
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
            public void Append(string key, string value)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Internal.ResponseCookies.Append(System.String, System.String, Microsoft.AspNetCore.Http.CookieOptions)
    
        
    
        
        :type key: System.String
    
        
        :type value: System.String
    
        
        :type options: Microsoft.AspNetCore.Http.CookieOptions
    
        
        .. code-block:: csharp
    
            public void Append(string key, string value, CookieOptions options)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Internal.ResponseCookies.Delete(System.String)
    
        
    
        
        :type key: System.String
    
        
        .. code-block:: csharp
    
            public void Delete(string key)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Internal.ResponseCookies.Delete(System.String, Microsoft.AspNetCore.Http.CookieOptions)
    
        
    
        
        :type key: System.String
    
        
        :type options: Microsoft.AspNetCore.Http.CookieOptions
    
        
        .. code-block:: csharp
    
            public void Delete(string key, CookieOptions options)
    

