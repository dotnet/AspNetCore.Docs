

IResponseCookies Interface
==========================



.. contents:: 
   :local:



Summary
-------

A wrapper for the response Set-Cookie header











Syntax
------

.. code-block:: csharp

   public interface IResponseCookies





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Http.Abstractions/IResponseCookies.cs>`_





.. dn:interface:: Microsoft.AspNet.Http.IResponseCookies

Methods
-------

.. dn:interface:: Microsoft.AspNet.Http.IResponseCookies
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.IResponseCookies.Append(System.String, System.String)
    
        
    
        Add a new cookie and value
    
        
        
        
        :type key: System.String
        
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
           void Append(string key, string value)
    
    .. dn:method:: Microsoft.AspNet.Http.IResponseCookies.Append(System.String, System.String, Microsoft.AspNet.Http.CookieOptions)
    
        
    
        Add a new cookie
    
        
        
        
        :type key: System.String
        
        
        :type value: System.String
        
        
        :type options: Microsoft.AspNet.Http.CookieOptions
    
        
        .. code-block:: csharp
    
           void Append(string key, string value, CookieOptions options)
    
    .. dn:method:: Microsoft.AspNet.Http.IResponseCookies.Delete(System.String)
    
        
    
        Sets an expired cookie
    
        
        
        
        :type key: System.String
    
        
        .. code-block:: csharp
    
           void Delete(string key)
    
    .. dn:method:: Microsoft.AspNet.Http.IResponseCookies.Delete(System.String, Microsoft.AspNet.Http.CookieOptions)
    
        
    
        Sets an expired cookie
    
        
        
        
        :type key: System.String
        
        
        :type options: Microsoft.AspNet.Http.CookieOptions
    
        
        .. code-block:: csharp
    
           void Delete(string key, CookieOptions options)
    

