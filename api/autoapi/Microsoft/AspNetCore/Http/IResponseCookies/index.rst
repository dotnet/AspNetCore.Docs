

IResponseCookies Interface
==========================






A wrapper for the response Set-Cookie header.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Http`
Assemblies
    * Microsoft.AspNetCore.Http.Features

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IResponseCookies








.. dn:interface:: Microsoft.AspNetCore.Http.IResponseCookies
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Http.IResponseCookies

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Http.IResponseCookies
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.IResponseCookies.Append(System.String, System.String)
    
        
    
        
        Add a new cookie and value.
    
        
    
        
        :param key: Name of the new cookie.
        
        :type key: System.String
    
        
        :param value: Value of the new cookie.
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
            void Append(string key, string value)
    
    .. dn:method:: Microsoft.AspNetCore.Http.IResponseCookies.Append(System.String, System.String, Microsoft.AspNetCore.Http.CookieOptions)
    
        
    
        
        Add a new cookie.
    
        
    
        
        :param key: Name of the new cookie.
        
        :type key: System.String
    
        
        :param value: Value of the new cookie.
        
        :type value: System.String
    
        
        :param options: :any:`Microsoft.AspNetCore.Http.CookieOptions` included in the new cookie setting.
        
        :type options: Microsoft.AspNetCore.Http.CookieOptions
    
        
        .. code-block:: csharp
    
            void Append(string key, string value, CookieOptions options)
    
    .. dn:method:: Microsoft.AspNetCore.Http.IResponseCookies.Delete(System.String)
    
        
    
        
        Sets an expired cookie.
    
        
    
        
        :param key: Name of the cookie to expire.
        
        :type key: System.String
    
        
        .. code-block:: csharp
    
            void Delete(string key)
    
    .. dn:method:: Microsoft.AspNetCore.Http.IResponseCookies.Delete(System.String, Microsoft.AspNetCore.Http.CookieOptions)
    
        
    
        
        Sets an expired cookie.
    
        
    
        
        :param key: Name of the cookie to expire.
        
        :type key: System.String
    
        
        :param options: 
            :any:`Microsoft.AspNetCore.Http.CookieOptions` used to discriminate the particular cookie to expire. The 
            :dn:prop:`Microsoft.AspNetCore.Http.CookieOptions.Domain` and :dn:prop:`Microsoft.AspNetCore.Http.CookieOptions.Path` values are especially important.
        
        :type options: Microsoft.AspNetCore.Http.CookieOptions
    
        
        .. code-block:: csharp
    
            void Delete(string key, CookieOptions options)
    

