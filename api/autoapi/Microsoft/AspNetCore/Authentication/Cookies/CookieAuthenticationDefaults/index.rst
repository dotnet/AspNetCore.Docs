

CookieAuthenticationDefaults Class
==================================






Default values related to cookie-based authentication middleware


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
* :dn:cls:`Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults`








Syntax
------

.. code-block:: csharp

    public class CookieAuthenticationDefaults








.. dn:class:: Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults

Fields
------

.. dn:class:: Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AccessDeniedPath
    
        
    
        
        The default value used by CookieAuthenticationMiddleware for the
        CookieAuthenticationOptions.AccessDeniedPath
    
        
        :rtype: Microsoft.AspNetCore.Http.PathString
    
        
        .. code-block:: csharp
    
            public static readonly PathString AccessDeniedPath
    
    .. dn:field:: Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme
    
        
    
        
        The default value used for CookieAuthenticationOptions.AuthenticationScheme
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public const string AuthenticationScheme = "Cookies"
    
    .. dn:field:: Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.CookiePrefix
    
        
    
        
        The prefix used to provide a default CookieAuthenticationOptions.CookieName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static readonly string CookiePrefix
    
    .. dn:field:: Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.LoginPath
    
        
    
        
        The default value used by CookieAuthenticationMiddleware for the
        CookieAuthenticationOptions.LoginPath
    
        
        :rtype: Microsoft.AspNetCore.Http.PathString
    
        
        .. code-block:: csharp
    
            public static readonly PathString LoginPath
    
    .. dn:field:: Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.LogoutPath
    
        
    
        
        The default value used by CookieAuthenticationMiddleware for the
        CookieAuthenticationOptions.LogoutPath
    
        
        :rtype: Microsoft.AspNetCore.Http.PathString
    
        
        .. code-block:: csharp
    
            public static readonly PathString LogoutPath
    
    .. dn:field:: Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.ReturnUrlParameter
    
        
    
        
        The default value of the CookieAuthenticationOptions.ReturnUrlParameter
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static readonly string ReturnUrlParameter
    

