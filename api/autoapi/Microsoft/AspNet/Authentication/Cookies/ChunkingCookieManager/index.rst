

ChunkingCookieManager Class
===========================



.. contents:: 
   :local:



Summary
-------

This handles cookies that are limited by per cookie length. It breaks down long cookies for responses, and reassembles them
from requests.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.Cookies.ChunkingCookieManager`








Syntax
------

.. code-block:: csharp

   public class ChunkingCookieManager : ICookieManager





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication.Cookies/ChunkingCookieManager.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.Cookies.ChunkingCookieManager

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.Cookies.ChunkingCookieManager
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.Cookies.ChunkingCookieManager.ChunkingCookieManager(Microsoft.Extensions.WebEncoders.IUrlEncoder)
    
        
        
        
        :type urlEncoder: Microsoft.Extensions.WebEncoders.IUrlEncoder
    
        
        .. code-block:: csharp
    
           public ChunkingCookieManager(IUrlEncoder urlEncoder)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Authentication.Cookies.ChunkingCookieManager
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authentication.Cookies.ChunkingCookieManager.AppendResponseCookie(Microsoft.AspNet.Http.HttpContext, System.String, System.String, Microsoft.AspNet.Http.CookieOptions)
    
        
    
        Appends a new response cookie to the Set-Cookie header. If the cookie is larger than the given size limit
        then it will be broken down into multiple cookies as follows:
        Set-Cookie: CookieName=chunks:3; path=/
        Set-Cookie: CookieNameC1=Segment1; path=/
        Set-Cookie: CookieNameC2=Segment2; path=/
        Set-Cookie: CookieNameC3=Segment3; path=/
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :type key: System.String
        
        
        :type value: System.String
        
        
        :type options: Microsoft.AspNet.Http.CookieOptions
    
        
        .. code-block:: csharp
    
           public void AppendResponseCookie(HttpContext context, string key, string value, CookieOptions options)
    
    .. dn:method:: Microsoft.AspNet.Authentication.Cookies.ChunkingCookieManager.DeleteCookie(Microsoft.AspNet.Http.HttpContext, System.String, Microsoft.AspNet.Http.CookieOptions)
    
        
    
        Deletes the cookie with the given key by setting an expired state. If a matching chunked cookie exists on
        the request, delete each chunk.
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :type key: System.String
        
        
        :type options: Microsoft.AspNet.Http.CookieOptions
    
        
        .. code-block:: csharp
    
           public void DeleteCookie(HttpContext context, string key, CookieOptions options)
    
    .. dn:method:: Microsoft.AspNet.Authentication.Cookies.ChunkingCookieManager.GetRequestCookie(Microsoft.AspNet.Http.HttpContext, System.String)
    
        
    
        Get the reassembled cookie. Non chunked cookies are returned normally.
        Cookies with missing chunks just have their "chunks:XX" header returned.
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :type key: System.String
        :rtype: System.String
        :return: The reassembled cookie, if any, or null.
    
        
        .. code-block:: csharp
    
           public string GetRequestCookie(HttpContext context, string key)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.Cookies.ChunkingCookieManager
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.Cookies.ChunkingCookieManager.ChunkSize
    
        
    
        The maximum size of cookie to send back to the client. If a cookie exceeds this size it will be broken down into multiple
        cookies. Set this value to null to disable this behavior. The default is 4090 characters, which is supported by all
        common browsers.
        
        
        Note that browsers may also have limits on the total size of all cookies per domain, and on the number of cookies per domain.
    
        
        :rtype: System.Nullable{System.Int32}
    
        
        .. code-block:: csharp
    
           public int ? ChunkSize { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.Cookies.ChunkingCookieManager.ThrowForPartialCookies
    
        
    
        Throw if not all chunks of a cookie are available on a request for re-assembly.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool ThrowForPartialCookies { get; set; }
    

