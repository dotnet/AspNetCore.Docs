

IOpenIdConnectEvents Interface
==============================






Specifies events which the :any:`Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectMiddleware`\invokes to enable developer control over the authentication process.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication.OpenIdConnect`
Assemblies
    * Microsoft.AspNetCore.Authentication.OpenIdConnect

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IOpenIdConnectEvents : IRemoteAuthenticationEvents








.. dn:interface:: Microsoft.AspNetCore.Authentication.OpenIdConnect.IOpenIdConnectEvents
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Authentication.OpenIdConnect.IOpenIdConnectEvents

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Authentication.OpenIdConnect.IOpenIdConnectEvents
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authentication.OpenIdConnect.IOpenIdConnectEvents.AuthenticationFailed(Microsoft.AspNetCore.Authentication.OpenIdConnect.AuthenticationFailedContext)
    
        
    
        
        Invoked if exceptions are thrown during request processing. The exceptions will be re-thrown after this event unless suppressed.
    
        
    
        
        :type context: Microsoft.AspNetCore.Authentication.OpenIdConnect.AuthenticationFailedContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            Task AuthenticationFailed(AuthenticationFailedContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.OpenIdConnect.IOpenIdConnectEvents.AuthorizationCodeReceived(Microsoft.AspNetCore.Authentication.OpenIdConnect.AuthorizationCodeReceivedContext)
    
        
    
        
        Invoked after security token validation if an authorization code is present in the protocol message.
    
        
    
        
        :type context: Microsoft.AspNetCore.Authentication.OpenIdConnect.AuthorizationCodeReceivedContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            Task AuthorizationCodeReceived(AuthorizationCodeReceivedContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.OpenIdConnect.IOpenIdConnectEvents.MessageReceived(Microsoft.AspNetCore.Authentication.OpenIdConnect.MessageReceivedContext)
    
        
    
        
        Invoked when a protocol message is first received.
    
        
    
        
        :type context: Microsoft.AspNetCore.Authentication.OpenIdConnect.MessageReceivedContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            Task MessageReceived(MessageReceivedContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.OpenIdConnect.IOpenIdConnectEvents.RedirectToIdentityProvider(Microsoft.AspNetCore.Authentication.OpenIdConnect.RedirectContext)
    
        
    
        
        Invoked before redirecting to the identity provider to authenticate.
    
        
    
        
        :type context: Microsoft.AspNetCore.Authentication.OpenIdConnect.RedirectContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            Task RedirectToIdentityProvider(RedirectContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.OpenIdConnect.IOpenIdConnectEvents.RedirectToIdentityProviderForSignOut(Microsoft.AspNetCore.Authentication.OpenIdConnect.RedirectContext)
    
        
    
        
        Invoked before redirecting to the identity provider to sign out.
    
        
    
        
        :type context: Microsoft.AspNetCore.Authentication.OpenIdConnect.RedirectContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            Task RedirectToIdentityProviderForSignOut(RedirectContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.OpenIdConnect.IOpenIdConnectEvents.TokenResponseReceived(Microsoft.AspNetCore.Authentication.OpenIdConnect.TokenResponseReceivedContext)
    
        
    
        
        Invoked after "authorization code" is redeemed for tokens at the token endpoint.
    
        
    
        
        :type context: Microsoft.AspNetCore.Authentication.OpenIdConnect.TokenResponseReceivedContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            Task TokenResponseReceived(TokenResponseReceivedContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.OpenIdConnect.IOpenIdConnectEvents.TokenValidated(Microsoft.AspNetCore.Authentication.OpenIdConnect.TokenValidatedContext)
    
        
    
        
        Invoked when an IdToken has been validated and produced an AuthenticationTicket.
    
        
    
        
        :type context: Microsoft.AspNetCore.Authentication.OpenIdConnect.TokenValidatedContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            Task TokenValidated(TokenValidatedContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.OpenIdConnect.IOpenIdConnectEvents.UserInformationReceived(Microsoft.AspNetCore.Authentication.OpenIdConnect.UserInformationReceivedContext)
    
        
    
        
        Invoked when user information is retrieved from the UserInfoEndpoint.
    
        
    
        
        :type context: Microsoft.AspNetCore.Authentication.OpenIdConnect.UserInformationReceivedContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            Task UserInformationReceived(UserInformationReceivedContext context)
    

