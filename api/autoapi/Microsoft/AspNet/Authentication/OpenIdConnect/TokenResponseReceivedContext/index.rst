

TokenResponseReceivedContext Class
==================================



.. contents:: 
   :local:



Summary
-------

This Context can be used to be informed when an 'AuthorizationCode' is redeemed for tokens at the token endpoint.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.BaseContext`
* :dn:cls:`Microsoft.AspNet.Authentication.BaseControlContext`
* :dn:cls:`Microsoft.AspNet.Authentication.OpenIdConnect.BaseOpenIdConnectContext`
* :dn:cls:`Microsoft.AspNet.Authentication.OpenIdConnect.TokenResponseReceivedContext`








Syntax
------

.. code-block:: csharp

   public class TokenResponseReceivedContext : BaseOpenIdConnectContext





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authentication.OpenIdConnect/Events/TokenResponseReceivedContext.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.OpenIdConnect.TokenResponseReceivedContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.OpenIdConnect.TokenResponseReceivedContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.OpenIdConnect.TokenResponseReceivedContext.TokenResponseReceivedContext(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions)
    
        
    
        Creates a :any:`Microsoft.AspNet.Authentication.OpenIdConnect.TokenResponseReceivedContext`
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :type options: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions
    
        
        .. code-block:: csharp
    
           public TokenResponseReceivedContext(HttpContext context, OpenIdConnectOptions options)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.OpenIdConnect.TokenResponseReceivedContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.OpenIdConnect.TokenResponseReceivedContext.TokenEndpointResponse
    
        
    
        Gets or sets the :any:`Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectMessage` that contains the tokens received after redeeming the code at the token endpoint.
    
        
        :rtype: Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectMessage
    
        
        .. code-block:: csharp
    
           public OpenIdConnectMessage TokenEndpointResponse { get; set; }
    

