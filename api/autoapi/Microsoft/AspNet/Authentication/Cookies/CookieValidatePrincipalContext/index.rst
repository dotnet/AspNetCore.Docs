

CookieValidatePrincipalContext Class
====================================



.. contents:: 
   :local:



Summary
-------

Context object passed to the ICookieAuthenticationProvider method ValidatePrincipal.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.BaseContext`
* :dn:cls:`Microsoft.AspNet.Authentication.Cookies.BaseCookieContext`
* :dn:cls:`Microsoft.AspNet.Authentication.Cookies.CookieValidatePrincipalContext`








Syntax
------

.. code-block:: csharp

   public class CookieValidatePrincipalContext : BaseCookieContext





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authentication.Cookies/Events/CookieValidatePrincipalContext.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.Cookies.CookieValidatePrincipalContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.Cookies.CookieValidatePrincipalContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.Cookies.CookieValidatePrincipalContext.CookieValidatePrincipalContext(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Authentication.AuthenticationTicket, Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions)
    
        
    
        Creates a new instance of the context object.
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :param ticket: Contains the initial values for identity and extra data
        
        :type ticket: Microsoft.AspNet.Authentication.AuthenticationTicket
        
        
        :type options: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions
    
        
        .. code-block:: csharp
    
           public CookieValidatePrincipalContext(HttpContext context, AuthenticationTicket ticket, CookieAuthenticationOptions options)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Authentication.Cookies.CookieValidatePrincipalContext
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authentication.Cookies.CookieValidatePrincipalContext.RejectPrincipal()
    
        
    
        Called to reject the incoming principal. This may be done if the application has determined the
        account is no longer active, and the request should be treated as if it was anonymous.
    
        
    
        
        .. code-block:: csharp
    
           public void RejectPrincipal()
    
    .. dn:method:: Microsoft.AspNet.Authentication.Cookies.CookieValidatePrincipalContext.ReplacePrincipal(System.Security.Claims.ClaimsPrincipal)
    
        
    
        Called to replace the claims principal. The supplied principal will replace the value of the
        Principal property, which determines the identity of the authenticated request.
    
        
        
        
        :type principal: System.Security.Claims.ClaimsPrincipal
    
        
        .. code-block:: csharp
    
           public void ReplacePrincipal(ClaimsPrincipal principal)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.Cookies.CookieValidatePrincipalContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.Cookies.CookieValidatePrincipalContext.Principal
    
        
    
        Contains the claims principal arriving with the request. May be altered to change the
        details of the authenticated user.
    
        
        :rtype: System.Security.Claims.ClaimsPrincipal
    
        
        .. code-block:: csharp
    
           public ClaimsPrincipal Principal { get; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.Cookies.CookieValidatePrincipalContext.Properties
    
        
    
        Contains the extra meta-data arriving with the request ticket. May be altered.
    
        
        :rtype: Microsoft.AspNet.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
           public AuthenticationProperties Properties { get; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.Cookies.CookieValidatePrincipalContext.ShouldRenew
    
        
    
        If true, the cookie will be renewed
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool ShouldRenew { get; set; }
    

