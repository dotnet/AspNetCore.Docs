

RedirectContext Class
=====================






When a user configures the :any:`Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectMiddleware` to be notified prior to redirecting to an IdentityProvider
an instance of :any:`Microsoft.AspNetCore.Authentication.OpenIdConnect.RedirectContext` is passed to the 'RedirectToAuthenticationEndpoint' or 'RedirectToEndSessionEndpoint' events.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication.OpenIdConnect`
Assemblies
    * Microsoft.AspNetCore.Authentication.OpenIdConnect

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authentication.BaseContext`
* :dn:cls:`Microsoft.AspNetCore.Authentication.BaseControlContext`
* :dn:cls:`Microsoft.AspNetCore.Authentication.OpenIdConnect.BaseOpenIdConnectContext`
* :dn:cls:`Microsoft.AspNetCore.Authentication.OpenIdConnect.RedirectContext`








Syntax
------

.. code-block:: csharp

    public class RedirectContext : BaseOpenIdConnectContext








.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.RedirectContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.RedirectContext

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.RedirectContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authentication.OpenIdConnect.RedirectContext.RedirectContext(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Builder.OpenIdConnectOptions, Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type options: Microsoft.AspNetCore.Builder.OpenIdConnectOptions
    
        
        :type properties: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
            public RedirectContext(HttpContext context, OpenIdConnectOptions options, AuthenticationProperties properties)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.RedirectContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OpenIdConnect.RedirectContext.Properties
    
        
        :rtype: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
            public AuthenticationProperties Properties { get; }
    

