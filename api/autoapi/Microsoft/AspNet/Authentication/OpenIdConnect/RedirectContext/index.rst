

RedirectContext Class
=====================



.. contents:: 
   :local:



Summary
-------

When a user configures the :any:`Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectMiddleware` to be notified prior to redirecting to an IdentityProvider
an instance of :any:`Microsoft.AspNet.Authentication.OpenIdConnect.RedirectContext` is passed to the 'RedirectToAuthenticationEndpoint' or 'RedirectToEndSessionEndpoint' events.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.BaseContext`
* :dn:cls:`Microsoft.AspNet.Authentication.BaseControlContext`
* :dn:cls:`Microsoft.AspNet.Authentication.OpenIdConnect.BaseOpenIdConnectContext`
* :dn:cls:`Microsoft.AspNet.Authentication.OpenIdConnect.RedirectContext`








Syntax
------

.. code-block:: csharp

   public class RedirectContext : BaseOpenIdConnectContext





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authentication.OpenIdConnect/Events/RedirectContext.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.OpenIdConnect.RedirectContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.OpenIdConnect.RedirectContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.OpenIdConnect.RedirectContext.RedirectContext(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions)
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :type options: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions
    
        
        .. code-block:: csharp
    
           public RedirectContext(HttpContext context, OpenIdConnectOptions options)
    

