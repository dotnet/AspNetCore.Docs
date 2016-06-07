

AuthorizationCodeReceivedContext Class
======================================






This Context can be used to be informed when an 'AuthorizationCode' is received over the OpenIdConnect protocol.


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
* :dn:cls:`Microsoft.AspNetCore.Authentication.OpenIdConnect.AuthorizationCodeReceivedContext`








Syntax
------

.. code-block:: csharp

    public class AuthorizationCodeReceivedContext : BaseOpenIdConnectContext








.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.AuthorizationCodeReceivedContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.AuthorizationCodeReceivedContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.AuthorizationCodeReceivedContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OpenIdConnect.AuthorizationCodeReceivedContext.Backchannel
    
        
    
        
        The configured communication channel to the identity provider for use when making custom requests to the token endpoint.
    
        
        :rtype: System.Net.Http.HttpClient
    
        
        .. code-block:: csharp
    
            public HttpClient Backchannel
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OpenIdConnect.AuthorizationCodeReceivedContext.HandledCodeRedemption
    
        
    
        
        Indicates if the developer choose to handle (or skip) the code redemption. If true then the middleware will not attempt
        to redeem the code. See HandleCodeRedemption and TokenEndpointResponse.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool HandledCodeRedemption
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OpenIdConnect.AuthorizationCodeReceivedContext.JwtSecurityToken
    
        
    
        
        Gets or sets the :dn:prop:`Microsoft.AspNetCore.Authentication.OpenIdConnect.AuthorizationCodeReceivedContext.JwtSecurityToken` that was received in the authentication response, if any.
    
        
        :rtype: System.IdentityModel.Tokens.Jwt.JwtSecurityToken
    
        
        .. code-block:: csharp
    
            public JwtSecurityToken JwtSecurityToken
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OpenIdConnect.AuthorizationCodeReceivedContext.Properties
    
        
        :rtype: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
            public AuthenticationProperties Properties
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OpenIdConnect.AuthorizationCodeReceivedContext.TokenEndpointRequest
    
        
    
        
        The request that will be sent to the token endpoint and is available for customization.
    
        
        :rtype: Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectMessage
    
        
        .. code-block:: csharp
    
            public OpenIdConnectMessage TokenEndpointRequest
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OpenIdConnect.AuthorizationCodeReceivedContext.TokenEndpointResponse
    
        
    
        
        If the developer chooses to redeem the code themselves then they can provide the resulting tokens here. This is the
        same as calling HandleCodeRedemption. If set then the middleware will not attempt to redeem the code. An IdToken
        is required if one had not been previously received in the authorization response. An access token is optional
        if the middleware is to contact the user-info endpoint.
    
        
        :rtype: Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectMessage
    
        
        .. code-block:: csharp
    
            public OpenIdConnectMessage TokenEndpointResponse
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.AuthorizationCodeReceivedContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authentication.OpenIdConnect.AuthorizationCodeReceivedContext.AuthorizationCodeReceivedContext(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Builder.OpenIdConnectOptions)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Authentication.OpenIdConnect.AuthorizationCodeReceivedContext`
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type options: Microsoft.AspNetCore.Builder.OpenIdConnectOptions
    
        
        .. code-block:: csharp
    
            public AuthorizationCodeReceivedContext(HttpContext context, OpenIdConnectOptions options)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.AuthorizationCodeReceivedContext
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authentication.OpenIdConnect.AuthorizationCodeReceivedContext.HandleCodeRedemption()
    
        
    
        
        Tells the middleware to skip the code redemption process. The developer may have redeemed the code themselves, or
        decided that the redemption was not required. If tokens were retrieved that are needed for further processing then
        call one of the overloads that allows providing tokens. An IdToken is required if one had not been previously received
        in the authorization response. An access token can optionally be provided for the middleware to contact the
        user-info endpoint. Calling this is the same as setting TokenEndpointResponse.
    
        
    
        
        .. code-block:: csharp
    
            public void HandleCodeRedemption()
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.OpenIdConnect.AuthorizationCodeReceivedContext.HandleCodeRedemption(Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectMessage)
    
        
    
        
        Tells the middleware to skip the code redemption process. The developer may have redeemed the code themselves, or
        decided that the redemption was not required. If tokens were retrieved that are needed for further processing then
        call one of the overloads that allows providing tokens. An IdToken is required if one had not been previously received
        in the authorization response. An access token can optionally be provided for the middleware to contact the
        user-info endpoint. Calling this is the same as setting TokenEndpointResponse.
    
        
    
        
        :type tokenEndpointResponse: Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectMessage
    
        
        .. code-block:: csharp
    
            public void HandleCodeRedemption(OpenIdConnectMessage tokenEndpointResponse)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.OpenIdConnect.AuthorizationCodeReceivedContext.HandleCodeRedemption(System.String, System.String)
    
        
    
        
        Tells the middleware to skip the code redemption process. The developer may have redeemed the code themselves, or
        decided that the redemption was not required. If tokens were retrieved that are needed for further processing then
        call one of the overloads that allows providing tokens. An IdToken is required if one had not been previously received
        in the authorization response. An access token can optionally be provided for the middleware to contact the
        user-info endpoint. Calling this is the same as setting TokenEndpointResponse.
    
        
    
        
        :type accessToken: System.String
    
        
        :type idToken: System.String
    
        
        .. code-block:: csharp
    
            public void HandleCodeRedemption(string accessToken, string idToken)
    

