

OAuthHandler<TOptions> Class
============================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication.OAuth`
Assemblies
    * Microsoft.AspNetCore.Authentication.OAuth

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authentication.AuthenticationHandler{{TOptions}}`
* :dn:cls:`Microsoft.AspNetCore.Authentication.RemoteAuthenticationHandler{{TOptions}}`
* :dn:cls:`Microsoft.AspNetCore.Authentication.OAuth.OAuthHandler\<TOptions>`








Syntax
------

.. code-block:: csharp

    public class OAuthHandler<TOptions> : RemoteAuthenticationHandler<TOptions>, IAuthenticationHandler where TOptions : OAuthOptions








.. dn:class:: Microsoft.AspNetCore.Authentication.OAuth.OAuthHandler`1
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.OAuth.OAuthHandler<TOptions>

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authentication.OAuth.OAuthHandler<TOptions>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authentication.OAuth.OAuthHandler<TOptions>.OAuthHandler(System.Net.Http.HttpClient)
    
        
    
        
        :type backchannel: System.Net.Http.HttpClient
    
        
        .. code-block:: csharp
    
            public OAuthHandler(HttpClient backchannel)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.OAuth.OAuthHandler<TOptions>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OAuth.OAuthHandler<TOptions>.Backchannel
    
        
        :rtype: System.Net.Http.HttpClient
    
        
        .. code-block:: csharp
    
            protected HttpClient Backchannel { get; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authentication.OAuth.OAuthHandler<TOptions>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authentication.OAuth.OAuthHandler<TOptions>.BuildChallengeUrl(Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties, System.String)
    
        
    
        
        :type properties: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        :type redirectUri: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            protected virtual string BuildChallengeUrl(AuthenticationProperties properties, string redirectUri)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.OAuth.OAuthHandler<TOptions>.CreateTicketAsync(System.Security.Claims.ClaimsIdentity, Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties, Microsoft.AspNetCore.Authentication.OAuth.OAuthTokenResponse)
    
        
    
        
        :type identity: System.Security.Claims.ClaimsIdentity
    
        
        :type properties: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        :type tokens: Microsoft.AspNetCore.Authentication.OAuth.OAuthTokenResponse
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Authentication.AuthenticationTicket<Microsoft.AspNetCore.Authentication.AuthenticationTicket>}
    
        
        .. code-block:: csharp
    
            protected virtual Task<AuthenticationTicket> CreateTicketAsync(ClaimsIdentity identity, AuthenticationProperties properties, OAuthTokenResponse tokens)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.OAuth.OAuthHandler<TOptions>.ExchangeCodeAsync(System.String, System.String)
    
        
    
        
        :type code: System.String
    
        
        :type redirectUri: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Authentication.OAuth.OAuthTokenResponse<Microsoft.AspNetCore.Authentication.OAuth.OAuthTokenResponse>}
    
        
        .. code-block:: csharp
    
            protected virtual Task<OAuthTokenResponse> ExchangeCodeAsync(string code, string redirectUri)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.OAuth.OAuthHandler<TOptions>.FormatScope()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            protected virtual string FormatScope()
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.OAuth.OAuthHandler<TOptions>.HandleRemoteAuthenticateAsync()
    
        
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Authentication.AuthenticateResult<Microsoft.AspNetCore.Authentication.AuthenticateResult>}
    
        
        .. code-block:: csharp
    
            protected override Task<AuthenticateResult> HandleRemoteAuthenticateAsync()
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.OAuth.OAuthHandler<TOptions>.HandleUnauthorizedAsync(Microsoft.AspNetCore.Http.Features.Authentication.ChallengeContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.Features.Authentication.ChallengeContext
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
    
        
        .. code-block:: csharp
    
            protected override Task<bool> HandleUnauthorizedAsync(ChallengeContext context)
    

