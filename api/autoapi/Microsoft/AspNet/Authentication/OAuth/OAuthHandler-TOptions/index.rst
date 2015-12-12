

OAuthHandler<TOptions> Class
============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.AuthenticationHandler{{TOptions}}`
* :dn:cls:`Microsoft.AspNet.Authentication.RemoteAuthenticationHandler{{TOptions}}`
* :dn:cls:`Microsoft.AspNet.Authentication.OAuth.OAuthHandler\<TOptions>`








Syntax
------

.. code-block:: csharp

   public class OAuthHandler<TOptions> : RemoteAuthenticationHandler<TOptions>, IAuthenticationHandler where TOptions : OAuthOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication.OAuth/OAuthHandler.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.OAuth.OAuthHandler<TOptions>

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.OAuth.OAuthHandler<TOptions>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.OAuth.OAuthHandler<TOptions>.OAuthHandler(System.Net.Http.HttpClient)
    
        
        
        
        :type backchannel: System.Net.Http.HttpClient
    
        
        .. code-block:: csharp
    
           public OAuthHandler(HttpClient backchannel)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Authentication.OAuth.OAuthHandler<TOptions>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authentication.OAuth.OAuthHandler<TOptions>.BuildChallengeUrl(Microsoft.AspNet.Http.Authentication.AuthenticationProperties, System.String)
    
        
        
        
        :type properties: Microsoft.AspNet.Http.Authentication.AuthenticationProperties
        
        
        :type redirectUri: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           protected virtual string BuildChallengeUrl(AuthenticationProperties properties, string redirectUri)
    
    .. dn:method:: Microsoft.AspNet.Authentication.OAuth.OAuthHandler<TOptions>.CreateTicketAsync(System.Security.Claims.ClaimsIdentity, Microsoft.AspNet.Http.Authentication.AuthenticationProperties, Microsoft.AspNet.Authentication.OAuth.OAuthTokenResponse)
    
        
        
        
        :type identity: System.Security.Claims.ClaimsIdentity
        
        
        :type properties: Microsoft.AspNet.Http.Authentication.AuthenticationProperties
        
        
        :type tokens: Microsoft.AspNet.Authentication.OAuth.OAuthTokenResponse
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Authentication.AuthenticationTicket}
    
        
        .. code-block:: csharp
    
           protected virtual Task<AuthenticationTicket> CreateTicketAsync(ClaimsIdentity identity, AuthenticationProperties properties, OAuthTokenResponse tokens)
    
    .. dn:method:: Microsoft.AspNet.Authentication.OAuth.OAuthHandler<TOptions>.ExchangeCodeAsync(System.String, System.String)
    
        
        
        
        :type code: System.String
        
        
        :type redirectUri: System.String
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Authentication.OAuth.OAuthTokenResponse}
    
        
        .. code-block:: csharp
    
           protected virtual Task<OAuthTokenResponse> ExchangeCodeAsync(string code, string redirectUri)
    
    .. dn:method:: Microsoft.AspNet.Authentication.OAuth.OAuthHandler<TOptions>.FormatScope()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           protected virtual string FormatScope()
    
    .. dn:method:: Microsoft.AspNet.Authentication.OAuth.OAuthHandler<TOptions>.GenerateCorrelationId(Microsoft.AspNet.Http.Authentication.AuthenticationProperties)
    
        
        
        
        :type properties: Microsoft.AspNet.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
           protected void GenerateCorrelationId(AuthenticationProperties properties)
    
    .. dn:method:: Microsoft.AspNet.Authentication.OAuth.OAuthHandler<TOptions>.HandleRemoteAuthenticateAsync()
    
        
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Authentication.AuthenticateResult}
    
        
        .. code-block:: csharp
    
           protected override Task<AuthenticateResult> HandleRemoteAuthenticateAsync()
    
    .. dn:method:: Microsoft.AspNet.Authentication.OAuth.OAuthHandler<TOptions>.HandleUnauthorizedAsync(Microsoft.AspNet.Http.Features.Authentication.ChallengeContext)
    
        
        
        
        :type context: Microsoft.AspNet.Http.Features.Authentication.ChallengeContext
        :rtype: System.Threading.Tasks.Task{System.Boolean}
    
        
        .. code-block:: csharp
    
           protected override Task<bool> HandleUnauthorizedAsync(ChallengeContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.OAuth.OAuthHandler<TOptions>.ValidateCorrelationId(Microsoft.AspNet.Http.Authentication.AuthenticationProperties)
    
        
        
        
        :type properties: Microsoft.AspNet.Http.Authentication.AuthenticationProperties
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           protected bool ValidateCorrelationId(AuthenticationProperties properties)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.OAuth.OAuthHandler<TOptions>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.OAuth.OAuthHandler<TOptions>.Backchannel
    
        
        :rtype: System.Net.Http.HttpClient
    
        
        .. code-block:: csharp
    
           protected HttpClient Backchannel { get; }
    

