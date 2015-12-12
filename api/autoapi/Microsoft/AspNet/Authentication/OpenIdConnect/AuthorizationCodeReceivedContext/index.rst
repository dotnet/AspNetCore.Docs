

AuthorizationCodeReceivedContext Class
======================================



.. contents:: 
   :local:



Summary
-------

This Context can be used to be informed when an 'AuthorizationCode' is received over the OpenIdConnect protocol.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.BaseContext`
* :dn:cls:`Microsoft.AspNet.Authentication.BaseControlContext`
* :dn:cls:`Microsoft.AspNet.Authentication.OpenIdConnect.BaseOpenIdConnectContext`
* :dn:cls:`Microsoft.AspNet.Authentication.OpenIdConnect.AuthorizationCodeReceivedContext`








Syntax
------

.. code-block:: csharp

   public class AuthorizationCodeReceivedContext : BaseOpenIdConnectContext





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication.OpenIdConnect/Events/AuthorizationCodeReceivedContext.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.OpenIdConnect.AuthorizationCodeReceivedContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.OpenIdConnect.AuthorizationCodeReceivedContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.OpenIdConnect.AuthorizationCodeReceivedContext.AuthorizationCodeReceivedContext(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions)
    
        
    
        Creates a :any:`Microsoft.AspNet.Authentication.OpenIdConnect.AuthorizationCodeReceivedContext`
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :type options: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions
    
        
        .. code-block:: csharp
    
           public AuthorizationCodeReceivedContext(HttpContext context, OpenIdConnectOptions options)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.OpenIdConnect.AuthorizationCodeReceivedContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.OpenIdConnect.AuthorizationCodeReceivedContext.Code
    
        
    
        Gets or sets the 'code'.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Code { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OpenIdConnect.AuthorizationCodeReceivedContext.JwtSecurityToken
    
        
    
        Gets or sets the :dn:prop:`Microsoft.AspNet.Authentication.OpenIdConnect.AuthorizationCodeReceivedContext.JwtSecurityToken` that was received in the id_token + code OpenIdConnectRequest.
    
        
        :rtype: System.IdentityModel.Tokens.Jwt.JwtSecurityToken
    
        
        .. code-block:: csharp
    
           public JwtSecurityToken JwtSecurityToken { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OpenIdConnect.AuthorizationCodeReceivedContext.RedirectUri
    
        
    
        Gets or sets the 'redirect_uri'.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string RedirectUri { get; set; }
    

