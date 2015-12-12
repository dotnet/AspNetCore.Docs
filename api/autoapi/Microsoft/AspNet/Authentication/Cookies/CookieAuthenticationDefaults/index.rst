

CookieAuthenticationDefaults Class
==================================



.. contents:: 
   :local:



Summary
-------

Default values related to cookie-based authentication middleware





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationDefaults`








Syntax
------

.. code-block:: csharp

   public class CookieAuthenticationDefaults





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authentication.Cookies/CookieAuthenticationDefaults.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationDefaults

Fields
------

.. dn:class:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationDefaults
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationDefaults.AccessDeniedPath
    
        
    
        The default value used by CookieAuthenticationMiddleware for the
        CookieAuthenticationOptions.AccessDeniedPath
    
        
    
        
        .. code-block:: csharp
    
           public static readonly PathString AccessDeniedPath
    
    .. dn:field:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme
    
        
    
        The default value used for CookieAuthenticationOptions.AuthenticationScheme
    
        
    
        
        .. code-block:: csharp
    
           public const string AuthenticationScheme
    
    .. dn:field:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationDefaults.CookiePrefix
    
        
    
        The prefix used to provide a default CookieAuthenticationOptions.CookieName
    
        
    
        
        .. code-block:: csharp
    
           public static readonly string CookiePrefix
    
    .. dn:field:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationDefaults.LoginPath
    
        
    
        The default value used by CookieAuthenticationMiddleware for the
        CookieAuthenticationOptions.LoginPath
    
        
    
        
        .. code-block:: csharp
    
           public static readonly PathString LoginPath
    
    .. dn:field:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationDefaults.LogoutPath
    
        
    
        The default value used by CookieAuthenticationMiddleware for the
        CookieAuthenticationOptions.LogoutPath
    
        
    
        
        .. code-block:: csharp
    
           public static readonly PathString LogoutPath
    
    .. dn:field:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationDefaults.ReturnUrlParameter
    
        
    
        The default value of the CookieAuthenticationOptions.ReturnUrlParameter
    
        
    
        
        .. code-block:: csharp
    
           public static readonly string ReturnUrlParameter
    

