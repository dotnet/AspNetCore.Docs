

ICookieManager Interface
========================






This is used by the CookieAuthenticationMiddleware to process request and response cookies.
It is abstracted from the normal cookie APIs to allow for complex operations like chunking.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication.Cookies`
Assemblies
    * Microsoft.AspNetCore.Authentication.Cookies

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface ICookieManager








.. dn:interface:: Microsoft.AspNetCore.Authentication.Cookies.ICookieManager
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Authentication.Cookies.ICookieManager

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Authentication.Cookies.ICookieManager
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Cookies.ICookieManager.AppendResponseCookie(Microsoft.AspNetCore.Http.HttpContext, System.String, System.String, Microsoft.AspNetCore.Http.CookieOptions)
    
        
    
        
        Append the given cookie to the response.
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type key: System.String
    
        
        :type value: System.String
    
        
        :type options: Microsoft.AspNetCore.Http.CookieOptions
    
        
        .. code-block:: csharp
    
            void AppendResponseCookie(HttpContext context, string key, string value, CookieOptions options)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Cookies.ICookieManager.DeleteCookie(Microsoft.AspNetCore.Http.HttpContext, System.String, Microsoft.AspNetCore.Http.CookieOptions)
    
        
    
        
        Append a delete cookie to the response.
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type key: System.String
    
        
        :type options: Microsoft.AspNetCore.Http.CookieOptions
    
        
        .. code-block:: csharp
    
            void DeleteCookie(HttpContext context, string key, CookieOptions options)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Cookies.ICookieManager.GetRequestCookie(Microsoft.AspNetCore.Http.HttpContext, System.String)
    
        
    
        
        Retrieve a cookie of the given name from the request.
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type key: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string GetRequestCookie(HttpContext context, string key)
    

