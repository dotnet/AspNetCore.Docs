

ICookieManager Interface
========================



.. contents:: 
   :local:



Summary
-------

This is used by the CookieAuthenticationMiddleware to process request and response cookies.
It is abstracted from the normal cookie APIs to allow for complex operations like chunking.











Syntax
------

.. code-block:: csharp

   public interface ICookieManager





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication.Cookies/ICookieManager.cs>`_





.. dn:interface:: Microsoft.AspNet.Authentication.Cookies.ICookieManager

Methods
-------

.. dn:interface:: Microsoft.AspNet.Authentication.Cookies.ICookieManager
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authentication.Cookies.ICookieManager.AppendResponseCookie(Microsoft.AspNet.Http.HttpContext, System.String, System.String, Microsoft.AspNet.Http.CookieOptions)
    
        
    
        Append the given cookie to the response.
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :type key: System.String
        
        
        :type value: System.String
        
        
        :type options: Microsoft.AspNet.Http.CookieOptions
    
        
        .. code-block:: csharp
    
           void AppendResponseCookie(HttpContext context, string key, string value, CookieOptions options)
    
    .. dn:method:: Microsoft.AspNet.Authentication.Cookies.ICookieManager.DeleteCookie(Microsoft.AspNet.Http.HttpContext, System.String, Microsoft.AspNet.Http.CookieOptions)
    
        
    
        Append a delete cookie to the response.
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :type key: System.String
        
        
        :type options: Microsoft.AspNet.Http.CookieOptions
    
        
        .. code-block:: csharp
    
           void DeleteCookie(HttpContext context, string key, CookieOptions options)
    
    .. dn:method:: Microsoft.AspNet.Authentication.Cookies.ICookieManager.GetRequestCookie(Microsoft.AspNet.Http.HttpContext, System.String)
    
        
    
        Retrieve a cookie of the given name from the request.
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :type key: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string GetRequestCookie(HttpContext context, string key)
    

