

ChunkingCookieManager Class
===========================






This handles cookies that are limited by per cookie length. It breaks down long cookies for responses, and reassembles them
from requests.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication.Cookies`
Assemblies
    * Microsoft.AspNetCore.Authentication.Cookies

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authentication.Cookies.ChunkingCookieManager`








Syntax
------

.. code-block:: csharp

    public class ChunkingCookieManager : ICookieManager








.. dn:class:: Microsoft.AspNetCore.Authentication.Cookies.ChunkingCookieManager
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.Cookies.ChunkingCookieManager

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.Cookies.ChunkingCookieManager
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.Cookies.ChunkingCookieManager.ChunkSize
    
        
    
        
        The maximum size of cookie to send back to the client. If a cookie exceeds this size it will be broken down into multiple
        cookies. Set this value to null to disable this behavior. The default is 4090 characters, which is supported by all
        common browsers.
        
        Note that browsers may also have limits on the total size of all cookies per domain, and on the number of cookies per domain.
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.Int32<System.Int32>}
    
        
        .. code-block:: csharp
    
            public int ? ChunkSize
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.Cookies.ChunkingCookieManager.ThrowForPartialCookies
    
        
    
        
        Throw if not all chunks of a cookie are available on a request for re-assembly.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool ThrowForPartialCookies
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authentication.Cookies.ChunkingCookieManager
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authentication.Cookies.ChunkingCookieManager.ChunkingCookieManager(System.Text.Encodings.Web.UrlEncoder)
    
        
    
        
        :type urlEncoder: System.Text.Encodings.Web.UrlEncoder
    
        
        .. code-block:: csharp
    
            public ChunkingCookieManager(UrlEncoder urlEncoder)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authentication.Cookies.ChunkingCookieManager
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Cookies.ChunkingCookieManager.AppendResponseCookie(Microsoft.AspNetCore.Http.HttpContext, System.String, System.String, Microsoft.AspNetCore.Http.CookieOptions)
    
        
    
        
        Appends a new response cookie to the Set-Cookie header. If the cookie is larger than the given size limit
        then it will be broken down into multiple cookies as follows:
        Set-Cookie: CookieName=chunks:3; path=/
        Set-Cookie: CookieNameC1=Segment1; path=/
        Set-Cookie: CookieNameC2=Segment2; path=/
        Set-Cookie: CookieNameC3=Segment3; path=/
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type key: System.String
    
        
        :type value: System.String
    
        
        :type options: Microsoft.AspNetCore.Http.CookieOptions
    
        
        .. code-block:: csharp
    
            public void AppendResponseCookie(HttpContext context, string key, string value, CookieOptions options)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Cookies.ChunkingCookieManager.DeleteCookie(Microsoft.AspNetCore.Http.HttpContext, System.String, Microsoft.AspNetCore.Http.CookieOptions)
    
        
    
        
        Deletes the cookie with the given key by setting an expired state. If a matching chunked cookie exists on
        the request, delete each chunk.
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type key: System.String
    
        
        :type options: Microsoft.AspNetCore.Http.CookieOptions
    
        
        .. code-block:: csharp
    
            public void DeleteCookie(HttpContext context, string key, CookieOptions options)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Cookies.ChunkingCookieManager.GetRequestCookie(Microsoft.AspNetCore.Http.HttpContext, System.String)
    
        
    
        
        Get the reassembled cookie. Non chunked cookies are returned normally.
        Cookies with missing chunks just have their "chunks:XX" header returned.
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type key: System.String
        :rtype: System.String
        :return: The reassembled cookie, if any, or null.
    
        
        .. code-block:: csharp
    
            public string GetRequestCookie(HttpContext context, string key)
    

