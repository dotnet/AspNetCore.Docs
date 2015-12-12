

OpenIdConnectHandler Class
==========================



.. contents:: 
   :local:



Summary
-------

A per-request authentication handler for the OpenIdConnectAuthenticationMiddleware.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.AuthenticationHandler{Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions}`
* :dn:cls:`Microsoft.AspNet.Authentication.RemoteAuthenticationHandler{Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions}`
* :dn:cls:`Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectHandler`








Syntax
------

.. code-block:: csharp

   public class OpenIdConnectHandler : RemoteAuthenticationHandler<OpenIdConnectOptions>, IAuthenticationHandler





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication.OpenIdConnect/OpenIdConnectHandler.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectHandler

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectHandler
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectHandler.OpenIdConnectHandler(System.Net.Http.HttpClient, Microsoft.Extensions.WebEncoders.IHtmlEncoder)
    
        
        
        
        :type backchannel: System.Net.Http.HttpClient
        
        
        :type htmlEncoder: Microsoft.Extensions.WebEncoders.IHtmlEncoder
    
        
        .. code-block:: csharp
    
           public OpenIdConnectHandler(HttpClient backchannel, IHtmlEncoder htmlEncoder)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectHandler
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectHandler.GetUserInformationAsync(Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectMessage, System.IdentityModel.Tokens.Jwt.JwtSecurityToken, Microsoft.AspNet.Authentication.AuthenticationTicket)
    
        
    
        Goes to UserInfo endpoint to retrieve additional claims and add any unique claims to the given identity.
    
        
        
        
        :param message: message that is being processed
        
        :type message: Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectMessage
        
        
        :type jwt: System.IdentityModel.Tokens.Jwt.JwtSecurityToken
        
        
        :param ticket: authentication ticket with claims principal and identities
        
        :type ticket: Microsoft.AspNet.Authentication.AuthenticationTicket
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Authentication.AuthenticationTicket}
        :return: Authentication ticket with identity with additional claims, if any.
    
        
        .. code-block:: csharp
    
           protected virtual Task<AuthenticationTicket> GetUserInformationAsync(OpenIdConnectMessage message, JwtSecurityToken jwt, AuthenticationTicket ticket)
    
    .. dn:method:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectHandler.HandleRemoteAuthenticateAsync()
    
        
    
        Invoked to process incoming OpenIdConnect messages.
    
        
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Authentication.AuthenticateResult}
        :return: An <see cref="T:Microsoft.AspNet.Authentication.AuthenticationTicket" /> if successful.
    
        
        .. code-block:: csharp
    
           protected override Task<AuthenticateResult> HandleRemoteAuthenticateAsync()
    
    .. dn:method:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectHandler.HandleSignOutAsync(Microsoft.AspNet.Http.Features.Authentication.SignOutContext)
    
        
    
        Handles Signout
    
        
        
        
        :type signout: Microsoft.AspNet.Http.Features.Authentication.SignOutContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           protected override Task HandleSignOutAsync(SignOutContext signout)
    
    .. dn:method:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectHandler.HandleUnauthorizedAsync(Microsoft.AspNet.Http.Features.Authentication.ChallengeContext)
    
        
    
        Responds to a 401 Challenge. Sends an OpenIdConnect message to the 'identity authority' to obtain an identity.
    
        
        
        
        :type context: Microsoft.AspNet.Http.Features.Authentication.ChallengeContext
        :rtype: System.Threading.Tasks.Task{System.Boolean}
    
        
        .. code-block:: csharp
    
           protected override Task<bool> HandleUnauthorizedAsync(ChallengeContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectHandler.RedeemAuthorizationCodeAsync(System.String, System.String)
    
        
    
        Redeems the authorization code for tokens at the token endpoint
    
        
        
        
        :param authorizationCode: The authorization code to redeem.
        
        :type authorizationCode: System.String
        
        
        :param redirectUri: Uri that was passed in the request sent for the authorization code.
        
        :type redirectUri: System.String
        :rtype: System.Threading.Tasks.Task{Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectMessage}
        :return: OpenIdConnect message that has tokens inside it.
    
        
        .. code-block:: csharp
    
           protected virtual Task<OpenIdConnectMessage> RedeemAuthorizationCodeAsync(string authorizationCode, string redirectUri)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectHandler
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectHandler.Backchannel
    
        
        :rtype: System.Net.Http.HttpClient
    
        
        .. code-block:: csharp
    
           protected HttpClient Backchannel { get; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectHandler.HtmlEncoder
    
        
        :rtype: Microsoft.Extensions.WebEncoders.IHtmlEncoder
    
        
        .. code-block:: csharp
    
           protected IHtmlEncoder HtmlEncoder { get; }
    

