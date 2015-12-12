

IOpenIdConnectEvents Interface
==============================



.. contents:: 
   :local:



Summary
-------

Specifies events which the :any:`Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectMiddleware`\invokes to enable developer control over the authentication process.











Syntax
------

.. code-block:: csharp

   public interface IOpenIdConnectEvents : IRemoteAuthenticationEvents





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication.OpenIdConnect/Events/IOpenIdConnectEvents.cs>`_





.. dn:interface:: Microsoft.AspNet.Authentication.OpenIdConnect.IOpenIdConnectEvents

Methods
-------

.. dn:interface:: Microsoft.AspNet.Authentication.OpenIdConnect.IOpenIdConnectEvents
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authentication.OpenIdConnect.IOpenIdConnectEvents.AuthenticationFailed(Microsoft.AspNet.Authentication.OpenIdConnect.AuthenticationFailedContext)
    
        
    
        Invoked if exceptions are thrown during request processing. The exceptions will be re-thrown after this event unless suppressed.
    
        
        
        
        :type context: Microsoft.AspNet.Authentication.OpenIdConnect.AuthenticationFailedContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task AuthenticationFailed(AuthenticationFailedContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.OpenIdConnect.IOpenIdConnectEvents.AuthenticationValidated(Microsoft.AspNet.Authentication.OpenIdConnect.AuthenticationValidatedContext)
    
        
    
        Invoked after the id token has passed validation and a ClaimsIdentity has been generated.
    
        
        
        
        :type context: Microsoft.AspNet.Authentication.OpenIdConnect.AuthenticationValidatedContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task AuthenticationValidated(AuthenticationValidatedContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.OpenIdConnect.IOpenIdConnectEvents.AuthorizationCodeReceived(Microsoft.AspNet.Authentication.OpenIdConnect.AuthorizationCodeReceivedContext)
    
        
    
        Invoked after security token validation if an authorization code is present in the protocol message.
    
        
        
        
        :type context: Microsoft.AspNet.Authentication.OpenIdConnect.AuthorizationCodeReceivedContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task AuthorizationCodeReceived(AuthorizationCodeReceivedContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.OpenIdConnect.IOpenIdConnectEvents.AuthorizationResponseReceived(Microsoft.AspNet.Authentication.OpenIdConnect.AuthorizationResponseReceivedContext)
    
        
    
        Invoked when an authorization response is received.
    
        
        
        
        :type context: Microsoft.AspNet.Authentication.OpenIdConnect.AuthorizationResponseReceivedContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task AuthorizationResponseReceived(AuthorizationResponseReceivedContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.OpenIdConnect.IOpenIdConnectEvents.MessageReceived(Microsoft.AspNet.Authentication.OpenIdConnect.MessageReceivedContext)
    
        
    
        Invoked when a protocol message is first received.
    
        
        
        
        :type context: Microsoft.AspNet.Authentication.OpenIdConnect.MessageReceivedContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task MessageReceived(MessageReceivedContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.OpenIdConnect.IOpenIdConnectEvents.RedirectToAuthenticationEndpoint(Microsoft.AspNet.Authentication.OpenIdConnect.RedirectContext)
    
        
    
        Invoked before redirecting to the identity provider to authenticate.
    
        
        
        
        :type context: Microsoft.AspNet.Authentication.OpenIdConnect.RedirectContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task RedirectToAuthenticationEndpoint(RedirectContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.OpenIdConnect.IOpenIdConnectEvents.RedirectToEndSessionEndpoint(Microsoft.AspNet.Authentication.OpenIdConnect.RedirectContext)
    
        
    
        Invoked before redirecting to the identity provider to sign out.
    
        
        
        
        :type context: Microsoft.AspNet.Authentication.OpenIdConnect.RedirectContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task RedirectToEndSessionEndpoint(RedirectContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.OpenIdConnect.IOpenIdConnectEvents.TokenResponseReceived(Microsoft.AspNet.Authentication.OpenIdConnect.TokenResponseReceivedContext)
    
        
    
        Invoked after "authorization code" is redeemed for tokens at the token endpoint.
    
        
        
        
        :type context: Microsoft.AspNet.Authentication.OpenIdConnect.TokenResponseReceivedContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task TokenResponseReceived(TokenResponseReceivedContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.OpenIdConnect.IOpenIdConnectEvents.UserInformationReceived(Microsoft.AspNet.Authentication.OpenIdConnect.UserInformationReceivedContext)
    
        
    
        Invoked when user information is retrieved from the UserInfoEndpoint.
    
        
        
        
        :type context: Microsoft.AspNet.Authentication.OpenIdConnect.UserInformationReceivedContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task UserInformationReceived(UserInformationReceivedContext context)
    

