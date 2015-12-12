

ResponseCookies Class
=====================



.. contents:: 
   :local:



Summary
-------

A wrapper for the response Set-Cookie header





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.Internal.ResponseCookies`








Syntax
------

.. code-block:: csharp

   public class ResponseCookies : IResponseCookies





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Http/ResponseCookies.cs>`_





.. dn:class:: Microsoft.AspNet.Http.Internal.ResponseCookies

Constructors
------------

.. dn:class:: Microsoft.AspNet.Http.Internal.ResponseCookies
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Http.Internal.ResponseCookies.ResponseCookies(Microsoft.AspNet.Http.IHeaderDictionary)
    
        
    
        Create a new wrapper
    
        
        
        
        :type headers: Microsoft.AspNet.Http.IHeaderDictionary
    
        
        .. code-block:: csharp
    
           public ResponseCookies(IHeaderDictionary headers)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Http.Internal.ResponseCookies
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.Internal.ResponseCookies.Append(System.String, System.String)
    
        
    
        Add a new cookie and value
    
        
        
        
        :type key: System.String
        
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
           public void Append(string key, string value)
    
    .. dn:method:: Microsoft.AspNet.Http.Internal.ResponseCookies.Append(System.String, System.String, Microsoft.AspNet.Http.CookieOptions)
    
        
    
        Add a new cookie
    
        
        
        
        :type key: System.String
        
        
        :type value: System.String
        
        
        :type options: Microsoft.AspNet.Http.CookieOptions
    
        
        .. code-block:: csharp
    
           public void Append(string key, string value, CookieOptions options)
    
    .. dn:method:: Microsoft.AspNet.Http.Internal.ResponseCookies.Delete(System.String)
    
        
    
        Sets an expired cookie
    
        
        
        
        :type key: System.String
    
        
        .. code-block:: csharp
    
           public void Delete(string key)
    
    .. dn:method:: Microsoft.AspNet.Http.Internal.ResponseCookies.Delete(System.String, Microsoft.AspNet.Http.CookieOptions)
    
        
    
        Sets an expired cookie
    
        
        
        
        :type key: System.String
        
        
        :type options: Microsoft.AspNet.Http.CookieOptions
    
        
        .. code-block:: csharp
    
           public void Delete(string key, CookieOptions options)
    

