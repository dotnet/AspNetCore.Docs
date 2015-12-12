

OpenIdConnectEvents Class
=========================



.. contents:: 
   :local:



Summary
-------

Specifies events which the :any:`Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectMiddleware`\invokes to enable developer control over the authentication process.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.RemoteAuthenticationEvents`
* :dn:cls:`Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectEvents`








Syntax
------

.. code-block:: csharp

   public class OpenIdConnectEvents : RemoteAuthenticationEvents, IOpenIdConnectEvents, IRemoteAuthenticationEvents





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication.OpenIdConnect/Events/OpenIdConnectEvents.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectEvents

Methods
-------

.. dn:class:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectEvents
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectEvents.AuthenticationFailed(Microsoft.AspNet.Authentication.OpenIdConnect.AuthenticationFailedContext)
    
        
        
        
        :type context: Microsoft.AspNet.Authentication.OpenIdConnect.AuthenticationFailedContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task AuthenticationFailed(AuthenticationFailedContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectEvents.AuthenticationValidated(Microsoft.AspNet.Authentication.OpenIdConnect.AuthenticationValidatedContext)
    
        
        
        
        :type context: Microsoft.AspNet.Authentication.OpenIdConnect.AuthenticationValidatedContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task AuthenticationValidated(AuthenticationValidatedContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectEvents.AuthorizationCodeReceived(Microsoft.AspNet.Authentication.OpenIdConnect.AuthorizationCodeReceivedContext)
    
        
        
        
        :type context: Microsoft.AspNet.Authentication.OpenIdConnect.AuthorizationCodeReceivedContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task AuthorizationCodeReceived(AuthorizationCodeReceivedContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectEvents.AuthorizationResponseReceived(Microsoft.AspNet.Authentication.OpenIdConnect.AuthorizationResponseReceivedContext)
    
        
        
        
        :type context: Microsoft.AspNet.Authentication.OpenIdConnect.AuthorizationResponseReceivedContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task AuthorizationResponseReceived(AuthorizationResponseReceivedContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectEvents.MessageReceived(Microsoft.AspNet.Authentication.OpenIdConnect.MessageReceivedContext)
    
        
        
        
        :type context: Microsoft.AspNet.Authentication.OpenIdConnect.MessageReceivedContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task MessageReceived(MessageReceivedContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectEvents.RedirectToAuthenticationEndpoint(Microsoft.AspNet.Authentication.OpenIdConnect.RedirectContext)
    
        
        
        
        :type context: Microsoft.AspNet.Authentication.OpenIdConnect.RedirectContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task RedirectToAuthenticationEndpoint(RedirectContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectEvents.RedirectToEndSessionEndpoint(Microsoft.AspNet.Authentication.OpenIdConnect.RedirectContext)
    
        
        
        
        :type context: Microsoft.AspNet.Authentication.OpenIdConnect.RedirectContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task RedirectToEndSessionEndpoint(RedirectContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectEvents.TokenResponseReceived(Microsoft.AspNet.Authentication.OpenIdConnect.TokenResponseReceivedContext)
    
        
        
        
        :type context: Microsoft.AspNet.Authentication.OpenIdConnect.TokenResponseReceivedContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task TokenResponseReceived(TokenResponseReceivedContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectEvents.UserInformationReceived(Microsoft.AspNet.Authentication.OpenIdConnect.UserInformationReceivedContext)
    
        
        
        
        :type context: Microsoft.AspNet.Authentication.OpenIdConnect.UserInformationReceivedContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task UserInformationReceived(UserInformationReceivedContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectEvents
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectEvents.OnAuthenticationFailed
    
        
    
        Invoked if exceptions are thrown during request processing. The exceptions will be re-thrown after this event unless suppressed.
    
        
        :rtype: System.Func{Microsoft.AspNet.Authentication.OpenIdConnect.AuthenticationFailedContext,System.Threading.Tasks.Task}
    
        
        .. code-block:: csharp
    
           public Func<AuthenticationFailedContext, Task> OnAuthenticationFailed { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectEvents.OnAuthenticationValidated
    
        
    
        Invoked after the id token has passed validation and a ClaimsIdentity has been generated.
    
        
        :rtype: System.Func{Microsoft.AspNet.Authentication.OpenIdConnect.AuthenticationValidatedContext,System.Threading.Tasks.Task}
    
        
        .. code-block:: csharp
    
           public Func<AuthenticationValidatedContext, Task> OnAuthenticationValidated { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectEvents.OnAuthorizationCodeReceived
    
        
    
        Invoked after security token validation if an authorization code is present in the protocol message.
    
        
        :rtype: System.Func{Microsoft.AspNet.Authentication.OpenIdConnect.AuthorizationCodeReceivedContext,System.Threading.Tasks.Task}
    
        
        .. code-block:: csharp
    
           public Func<AuthorizationCodeReceivedContext, Task> OnAuthorizationCodeReceived { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectEvents.OnAuthorizationResponseReceived
    
        
    
        Invoked when an authorization response is received.
    
        
        :rtype: System.Func{Microsoft.AspNet.Authentication.OpenIdConnect.AuthorizationResponseReceivedContext,System.Threading.Tasks.Task}
    
        
        .. code-block:: csharp
    
           public Func<AuthorizationResponseReceivedContext, Task> OnAuthorizationResponseReceived { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectEvents.OnMessageReceived
    
        
    
        Invoked when a protocol message is first received.
    
        
        :rtype: System.Func{Microsoft.AspNet.Authentication.OpenIdConnect.MessageReceivedContext,System.Threading.Tasks.Task}
    
        
        .. code-block:: csharp
    
           public Func<MessageReceivedContext, Task> OnMessageReceived { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectEvents.OnRedirectToAuthenticationEndpoint
    
        
    
        Invoked before redirecting to the identity provider to authenticate.
    
        
        :rtype: System.Func{Microsoft.AspNet.Authentication.OpenIdConnect.RedirectContext,System.Threading.Tasks.Task}
    
        
        .. code-block:: csharp
    
           public Func<RedirectContext, Task> OnRedirectToAuthenticationEndpoint { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectEvents.OnRedirectToEndSessionEndpoint
    
        
    
        Invoked before redirecting to the identity provider to sign out.
    
        
        :rtype: System.Func{Microsoft.AspNet.Authentication.OpenIdConnect.RedirectContext,System.Threading.Tasks.Task}
    
        
        .. code-block:: csharp
    
           public Func<RedirectContext, Task> OnRedirectToEndSessionEndpoint { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectEvents.OnTokenResponseReceived
    
        
    
        Invoked after "authorization code" is redeemed for tokens at the token endpoint.
    
        
        :rtype: System.Func{Microsoft.AspNet.Authentication.OpenIdConnect.TokenResponseReceivedContext,System.Threading.Tasks.Task}
    
        
        .. code-block:: csharp
    
           public Func<TokenResponseReceivedContext, Task> OnTokenResponseReceived { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectEvents.OnUserInformationReceived
    
        
    
        Invoked when user information is retrieved from the UserInfoEndpoint.
    
        
        :rtype: System.Func{Microsoft.AspNet.Authentication.OpenIdConnect.UserInformationReceivedContext,System.Threading.Tasks.Task}
    
        
        .. code-block:: csharp
    
           public Func<UserInformationReceivedContext, Task> OnUserInformationReceived { get; set; }
    

