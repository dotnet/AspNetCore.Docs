

CookieValidatePrincipalContext Class
====================================






Context object passed to the ICookieAuthenticationProvider method ValidatePrincipal.


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
* :dn:cls:`Microsoft.AspNetCore.Authentication.Cookies.CookieValidatePrincipalContext`








Syntax
------

.. code-block:: csharp

    public class CookieValidatePrincipalContext : BaseCookieContext








.. dn:class:: Microsoft.AspNetCore.Authentication.Cookies.CookieValidatePrincipalContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.Cookies.CookieValidatePrincipalContext

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authentication.Cookies.CookieValidatePrincipalContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authentication.Cookies.CookieValidatePrincipalContext.CookieValidatePrincipalContext(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Authentication.AuthenticationTicket, Microsoft.AspNetCore.Builder.CookieAuthenticationOptions)
    
        
    
        
        Creates a new instance of the context object.
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :param ticket: Contains the initial values for identity and extra data
        
        :type ticket: Microsoft.AspNetCore.Authentication.AuthenticationTicket
    
        
        :type options: Microsoft.AspNetCore.Builder.CookieAuthenticationOptions
    
        
        .. code-block:: csharp
    
            public CookieValidatePrincipalContext(HttpContext context, AuthenticationTicket ticket, CookieAuthenticationOptions options)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.Cookies.CookieValidatePrincipalContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.Cookies.CookieValidatePrincipalContext.Principal
    
        
    
        
        Contains the claims principal arriving with the request. May be altered to change the 
        details of the authenticated user.
    
        
        :rtype: System.Security.Claims.ClaimsPrincipal
    
        
        .. code-block:: csharp
    
            public ClaimsPrincipal Principal { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.Cookies.CookieValidatePrincipalContext.Properties
    
        
    
        
        Contains the extra meta-data arriving with the request ticket. May be altered.
    
        
        :rtype: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
            public AuthenticationProperties Properties { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.Cookies.CookieValidatePrincipalContext.ShouldRenew
    
        
    
        
        If true, the cookie will be renewed
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool ShouldRenew { get; set; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authentication.Cookies.CookieValidatePrincipalContext
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Cookies.CookieValidatePrincipalContext.RejectPrincipal()
    
        
    
        
        Called to reject the incoming principal. This may be done if the application has determined the
        account is no longer active, and the request should be treated as if it was anonymous.
    
        
    
        
        .. code-block:: csharp
    
            public void RejectPrincipal()
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Cookies.CookieValidatePrincipalContext.ReplacePrincipal(System.Security.Claims.ClaimsPrincipal)
    
        
    
        
        Called to replace the claims principal. The supplied principal will replace the value of the 
        Principal property, which determines the identity of the authenticated request.
    
        
    
        
        :param principal: The :any:`System.Security.Claims.ClaimsPrincipal` used as the replacement
        
        :type principal: System.Security.Claims.ClaimsPrincipal
    
        
        .. code-block:: csharp
    
            public void ReplacePrincipal(ClaimsPrincipal principal)
    

