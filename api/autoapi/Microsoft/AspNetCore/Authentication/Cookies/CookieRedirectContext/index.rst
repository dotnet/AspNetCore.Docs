

CookieRedirectContext Class
===========================






Context passed when a Challenge, SignIn, or SignOut causes a redirect in the cookie middleware 


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
* :dn:cls:`Microsoft.AspNetCore.Authentication.BaseContext`
* :dn:cls:`Microsoft.AspNetCore.Authentication.Cookies.BaseCookieContext`
* :dn:cls:`Microsoft.AspNetCore.Authentication.Cookies.CookieRedirectContext`








Syntax
------

.. code-block:: csharp

    public class CookieRedirectContext : BaseCookieContext








.. dn:class:: Microsoft.AspNetCore.Authentication.Cookies.CookieRedirectContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.Cookies.CookieRedirectContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.Cookies.CookieRedirectContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.Cookies.CookieRedirectContext.Properties
    
        
        :rtype: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
            public AuthenticationProperties Properties
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.Cookies.CookieRedirectContext.RedirectUri
    
        
    
        
        Gets or Sets the URI used for the redirect operation.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string RedirectUri
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authentication.Cookies.CookieRedirectContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authentication.Cookies.CookieRedirectContext.CookieRedirectContext(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Builder.CookieAuthenticationOptions, System.String, Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties)
    
        
    
        
        Creates a new context object.
    
        
    
        
        :param context: The HTTP request context
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :param options: The cookie middleware options
        
        :type options: Microsoft.AspNetCore.Builder.CookieAuthenticationOptions
    
        
        :param redirectUri: The initial redirect URI
        
        :type redirectUri: System.String
    
        
        :param properties: The :any:`Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties`\.
        
        :type properties: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
            public CookieRedirectContext(HttpContext context, CookieAuthenticationOptions options, string redirectUri, AuthenticationProperties properties)
    

