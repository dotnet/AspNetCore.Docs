

AuthorizationResponseReceivedContext Class
==========================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.BaseContext`
* :dn:cls:`Microsoft.AspNet.Authentication.BaseControlContext`
* :dn:cls:`Microsoft.AspNet.Authentication.OpenIdConnect.BaseOpenIdConnectContext`
* :dn:cls:`Microsoft.AspNet.Authentication.OpenIdConnect.AuthorizationResponseReceivedContext`








Syntax
------

.. code-block:: csharp

   public class AuthorizationResponseReceivedContext : BaseOpenIdConnectContext





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication.OpenIdConnect/Events/AuthorizationResponseReceivedContext.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.OpenIdConnect.AuthorizationResponseReceivedContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.OpenIdConnect.AuthorizationResponseReceivedContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.OpenIdConnect.AuthorizationResponseReceivedContext.AuthorizationResponseReceivedContext(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions)
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :type options: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions
    
        
        .. code-block:: csharp
    
           public AuthorizationResponseReceivedContext(HttpContext context, OpenIdConnectOptions options)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.OpenIdConnect.AuthorizationResponseReceivedContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.OpenIdConnect.AuthorizationResponseReceivedContext.Properties
    
        
        :rtype: Microsoft.AspNet.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
           public AuthenticationProperties Properties { get; set; }
    

