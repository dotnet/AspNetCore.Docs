

OpenIdConnectHandler Class
==========================






A per-request authentication handler for the OpenIdConnectAuthenticationMiddleware.


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
* :dn:cls:`Microsoft.AspNetCore.Authentication.AuthenticationHandler{Microsoft.AspNetCore.Builder.OpenIdConnectOptions}`
* :dn:cls:`Microsoft.AspNetCore.Authentication.RemoteAuthenticationHandler{Microsoft.AspNetCore.Builder.OpenIdConnectOptions}`
* :dn:cls:`Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectHandler`








Syntax
------

.. code-block:: csharp

    public class OpenIdConnectHandler : RemoteAuthenticationHandler<OpenIdConnectOptions>, IAuthenticationHandler








.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectHandler
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectHandler

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectHandler
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectHandler.OpenIdConnectHandler(System.Net.Http.HttpClient, System.Text.Encodings.Web.HtmlEncoder)
    
        
    
        
        :type backchannel: System.Net.Http.HttpClient
    
        
        :type htmlEncoder: System.Text.Encodings.Web.HtmlEncoder
    
        
        .. code-block:: csharp
    
            public OpenIdConnectHandler(HttpClient backchannel, HtmlEncoder htmlEncoder)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectHandler
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectHandler.Backchannel
    
        
        :rtype: System.Net.Http.HttpClient
    
        
        .. code-block:: csharp
    
            protected HttpClient Backchannel { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectHandler.HtmlEncoder
    
        
        :rtype: System.Text.Encodings.Web.HtmlEncoder
    
        
        .. code-block:: csharp
    
            protected HtmlEncoder HtmlEncoder { get; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectHandler
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectHandler.GetUserInformationAsync(Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectMessage, System.IdentityModel.Tokens.Jwt.JwtSecurityToken, Microsoft.AspNetCore.Authentication.AuthenticationTicket)
    
        
    
        
        Goes to UserInfo endpoint to retrieve additional claims and add any unique claims to the given identity.
    
        
    
        
        :param message: message that is being processed
        
        :type message: Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectMessage
    
        
        :param jwt: The :any:`System.IdentityModel.Tokens.Jwt.JwtSecurityToken`\.
        
        :type jwt: System.IdentityModel.Tokens.Jwt.JwtSecurityToken
    
        
        :param ticket: authentication ticket with claims principal and identities
        
        :type ticket: Microsoft.AspNetCore.Authentication.AuthenticationTicket
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Authentication.AuthenticateResult<Microsoft.AspNetCore.Authentication.AuthenticateResult>}
        :return: Authentication ticket with identity with additional claims, if any.
    
        
        .. code-block:: csharp
    
            protected virtual Task<AuthenticateResult> GetUserInformationAsync(OpenIdConnectMessage message, JwtSecurityToken jwt, AuthenticationTicket ticket)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectHandler.HandleRemoteAuthenticateAsync()
    
        
    
        
        Invoked to process incoming OpenIdConnect messages.
    
        
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Authentication.AuthenticateResult<Microsoft.AspNetCore.Authentication.AuthenticateResult>}
        :return: An :any:`Microsoft.AspNetCore.Authentication.AuthenticationTicket` if successful.
    
        
        .. code-block:: csharp
    
            protected override Task<AuthenticateResult> HandleRemoteAuthenticateAsync()
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectHandler.HandleRemoteSignOutAsync()
    
        
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
    
        
        .. code-block:: csharp
    
            protected virtual Task<bool> HandleRemoteSignOutAsync()
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectHandler.HandleRequestAsync()
    
        
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
    
        
        .. code-block:: csharp
    
            public override Task<bool> HandleRequestAsync()
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectHandler.HandleSignOutAsync(Microsoft.AspNetCore.Http.Features.Authentication.SignOutContext)
    
        
    
        
        Handles Signout
    
        
    
        
        :type signout: Microsoft.AspNetCore.Http.Features.Authentication.SignOutContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            protected override Task HandleSignOutAsync(SignOutContext signout)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectHandler.HandleUnauthorizedAsync(Microsoft.AspNetCore.Http.Features.Authentication.ChallengeContext)
    
        
    
        
        Responds to a 401 Challenge. Sends an OpenIdConnect message to the 'identity authority' to obtain an identity.
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.Features.Authentication.ChallengeContext
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
    
        
        .. code-block:: csharp
    
            protected override Task<bool> HandleUnauthorizedAsync(ChallengeContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectHandler.RedeemAuthorizationCodeAsync(Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectMessage)
    
        
    
        
        Redeems the authorization code for tokens at the token endpoint
    
        
    
        
        :param tokenEndpointRequest: The request that will be sent to the token endpoint and is available for customization.
        
        :type tokenEndpointRequest: Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectMessage
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectMessage<Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectMessage>}
        :return: OpenIdConnect message that has tokens inside it.
    
        
        .. code-block:: csharp
    
            protected virtual Task<OpenIdConnectMessage> RedeemAuthorizationCodeAsync(OpenIdConnectMessage tokenEndpointRequest)
    

