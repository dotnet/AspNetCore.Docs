

OpenIdConnectEvents Class
=========================






Specifies events which the :any:`Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectMiddleware`\invokes to enable developer control over the authentication process.


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
* :dn:cls:`Microsoft.AspNetCore.Authentication.RemoteAuthenticationEvents`
* :dn:cls:`Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectEvents`








Syntax
------

.. code-block:: csharp

    public class OpenIdConnectEvents : RemoteAuthenticationEvents, IOpenIdConnectEvents, IRemoteAuthenticationEvents








.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectEvents
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectEvents

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectEvents
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectEvents.OnAuthenticationFailed
    
        
    
        
        Invoked if exceptions are thrown during request processing. The exceptions will be re-thrown after this event unless suppressed.
    
        
        :rtype: System.Func<System.Func`2>{Microsoft.AspNetCore.Authentication.OpenIdConnect.AuthenticationFailedContext<Microsoft.AspNetCore.Authentication.OpenIdConnect.AuthenticationFailedContext>, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
    
        
        .. code-block:: csharp
    
            public Func<AuthenticationFailedContext, Task> OnAuthenticationFailed
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectEvents.OnAuthorizationCodeReceived
    
        
    
        
        Invoked after security token validation if an authorization code is present in the protocol message.
    
        
        :rtype: System.Func<System.Func`2>{Microsoft.AspNetCore.Authentication.OpenIdConnect.AuthorizationCodeReceivedContext<Microsoft.AspNetCore.Authentication.OpenIdConnect.AuthorizationCodeReceivedContext>, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
    
        
        .. code-block:: csharp
    
            public Func<AuthorizationCodeReceivedContext, Task> OnAuthorizationCodeReceived
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectEvents.OnMessageReceived
    
        
    
        
        Invoked when a protocol message is first received.
    
        
        :rtype: System.Func<System.Func`2>{Microsoft.AspNetCore.Authentication.OpenIdConnect.MessageReceivedContext<Microsoft.AspNetCore.Authentication.OpenIdConnect.MessageReceivedContext>, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
    
        
        .. code-block:: csharp
    
            public Func<MessageReceivedContext, Task> OnMessageReceived
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectEvents.OnRedirectToIdentityProvider
    
        
    
        
        Invoked before redirecting to the identity provider to authenticate.
    
        
        :rtype: System.Func<System.Func`2>{Microsoft.AspNetCore.Authentication.OpenIdConnect.RedirectContext<Microsoft.AspNetCore.Authentication.OpenIdConnect.RedirectContext>, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
    
        
        .. code-block:: csharp
    
            public Func<RedirectContext, Task> OnRedirectToIdentityProvider
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectEvents.OnRedirectToIdentityProviderForSignOut
    
        
    
        
        Invoked before redirecting to the identity provider to sign out.
    
        
        :rtype: System.Func<System.Func`2>{Microsoft.AspNetCore.Authentication.OpenIdConnect.RedirectContext<Microsoft.AspNetCore.Authentication.OpenIdConnect.RedirectContext>, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
    
        
        .. code-block:: csharp
    
            public Func<RedirectContext, Task> OnRedirectToIdentityProviderForSignOut
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectEvents.OnTokenResponseReceived
    
        
    
        
        Invoked after "authorization code" is redeemed for tokens at the token endpoint.
    
        
        :rtype: System.Func<System.Func`2>{Microsoft.AspNetCore.Authentication.OpenIdConnect.TokenResponseReceivedContext<Microsoft.AspNetCore.Authentication.OpenIdConnect.TokenResponseReceivedContext>, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
    
        
        .. code-block:: csharp
    
            public Func<TokenResponseReceivedContext, Task> OnTokenResponseReceived
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectEvents.OnTokenValidated
    
        
    
        
        Invoked when an IdToken has been validated and produced an AuthenticationTicket.
    
        
        :rtype: System.Func<System.Func`2>{Microsoft.AspNetCore.Authentication.OpenIdConnect.TokenValidatedContext<Microsoft.AspNetCore.Authentication.OpenIdConnect.TokenValidatedContext>, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
    
        
        .. code-block:: csharp
    
            public Func<TokenValidatedContext, Task> OnTokenValidated
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectEvents.OnUserInformationReceived
    
        
    
        
        Invoked when user information is retrieved from the UserInfoEndpoint.
    
        
        :rtype: System.Func<System.Func`2>{Microsoft.AspNetCore.Authentication.OpenIdConnect.UserInformationReceivedContext<Microsoft.AspNetCore.Authentication.OpenIdConnect.UserInformationReceivedContext>, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
    
        
        .. code-block:: csharp
    
            public Func<UserInformationReceivedContext, Task> OnUserInformationReceived
            {
                get;
                set;
            }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectEvents
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectEvents.AuthenticationFailed(Microsoft.AspNetCore.Authentication.OpenIdConnect.AuthenticationFailedContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Authentication.OpenIdConnect.AuthenticationFailedContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task AuthenticationFailed(AuthenticationFailedContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectEvents.AuthorizationCodeReceived(Microsoft.AspNetCore.Authentication.OpenIdConnect.AuthorizationCodeReceivedContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Authentication.OpenIdConnect.AuthorizationCodeReceivedContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task AuthorizationCodeReceived(AuthorizationCodeReceivedContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectEvents.MessageReceived(Microsoft.AspNetCore.Authentication.OpenIdConnect.MessageReceivedContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Authentication.OpenIdConnect.MessageReceivedContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task MessageReceived(MessageReceivedContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectEvents.RedirectToIdentityProvider(Microsoft.AspNetCore.Authentication.OpenIdConnect.RedirectContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Authentication.OpenIdConnect.RedirectContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task RedirectToIdentityProvider(RedirectContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectEvents.RedirectToIdentityProviderForSignOut(Microsoft.AspNetCore.Authentication.OpenIdConnect.RedirectContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Authentication.OpenIdConnect.RedirectContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task RedirectToIdentityProviderForSignOut(RedirectContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectEvents.TokenResponseReceived(Microsoft.AspNetCore.Authentication.OpenIdConnect.TokenResponseReceivedContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Authentication.OpenIdConnect.TokenResponseReceivedContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task TokenResponseReceived(TokenResponseReceivedContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectEvents.TokenValidated(Microsoft.AspNetCore.Authentication.OpenIdConnect.TokenValidatedContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Authentication.OpenIdConnect.TokenValidatedContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task TokenValidated(TokenValidatedContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectEvents.UserInformationReceived(Microsoft.AspNetCore.Authentication.OpenIdConnect.UserInformationReceivedContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Authentication.OpenIdConnect.UserInformationReceivedContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task UserInformationReceived(UserInformationReceivedContext context)
    

