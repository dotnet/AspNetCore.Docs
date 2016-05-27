

TokenResponseReceivedContext Class
==================================






This Context can be used to be informed when an 'AuthorizationCode' is redeemed for tokens at the token endpoint.


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
* :dn:cls:`Microsoft.AspNetCore.Authentication.OpenIdConnect.TokenResponseReceivedContext`








Syntax
------

.. code-block:: csharp

    public class TokenResponseReceivedContext : BaseOpenIdConnectContext








.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.TokenResponseReceivedContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.TokenResponseReceivedContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.TokenResponseReceivedContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OpenIdConnect.TokenResponseReceivedContext.Properties
    
        
        :rtype: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
            public AuthenticationProperties Properties
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OpenIdConnect.TokenResponseReceivedContext.TokenEndpointResponse
    
        
    
        
        Gets or sets the :any:`Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectMessage` that contains the tokens received after redeeming the code at the token endpoint.
    
        
        :rtype: Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectMessage
    
        
        .. code-block:: csharp
    
            public OpenIdConnectMessage TokenEndpointResponse
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.TokenResponseReceivedContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authentication.OpenIdConnect.TokenResponseReceivedContext.TokenResponseReceivedContext(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Builder.OpenIdConnectOptions, Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Authentication.OpenIdConnect.TokenResponseReceivedContext`
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type options: Microsoft.AspNetCore.Builder.OpenIdConnectOptions
    
        
        :type properties: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
            public TokenResponseReceivedContext(HttpContext context, OpenIdConnectOptions options, AuthenticationProperties properties)
    

