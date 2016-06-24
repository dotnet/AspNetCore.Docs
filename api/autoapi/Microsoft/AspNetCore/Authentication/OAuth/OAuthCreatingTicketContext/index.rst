

OAuthCreatingTicketContext Class
================================






Contains information about the login session as well as the user :any:`System.Security.Claims.ClaimsIdentity`\.


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
* :dn:cls:`Microsoft.AspNetCore.Authentication.BaseContext`
* :dn:cls:`Microsoft.AspNetCore.Authentication.OAuth.OAuthCreatingTicketContext`








Syntax
------

.. code-block:: csharp

    public class OAuthCreatingTicketContext : BaseContext








.. dn:class:: Microsoft.AspNetCore.Authentication.OAuth.OAuthCreatingTicketContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.OAuth.OAuthCreatingTicketContext

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authentication.OAuth.OAuthCreatingTicketContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authentication.OAuth.OAuthCreatingTicketContext.OAuthCreatingTicketContext(Microsoft.AspNetCore.Authentication.AuthenticationTicket, Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Builder.OAuthOptions, System.Net.Http.HttpClient, Microsoft.AspNetCore.Authentication.OAuth.OAuthTokenResponse)
    
        
    
        
        Initializes a new :any:`Microsoft.AspNetCore.Authentication.OAuth.OAuthCreatingTicketContext`\.
    
        
    
        
        :param ticket: The :any:`Microsoft.AspNetCore.Authentication.AuthenticationTicket`\.
        
        :type ticket: Microsoft.AspNetCore.Authentication.AuthenticationTicket
    
        
        :param context: The HTTP environment.
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :param options: The options used by the authentication middleware.
        
        :type options: Microsoft.AspNetCore.Builder.OAuthOptions
    
        
        :param backchannel: The HTTP client used by the authentication middleware
        
        :type backchannel: System.Net.Http.HttpClient
    
        
        :param tokens: The tokens returned from the token endpoint.
        
        :type tokens: Microsoft.AspNetCore.Authentication.OAuth.OAuthTokenResponse
    
        
        .. code-block:: csharp
    
            public OAuthCreatingTicketContext(AuthenticationTicket ticket, HttpContext context, OAuthOptions options, HttpClient backchannel, OAuthTokenResponse tokens)
    
    .. dn:constructor:: Microsoft.AspNetCore.Authentication.OAuth.OAuthCreatingTicketContext.OAuthCreatingTicketContext(Microsoft.AspNetCore.Authentication.AuthenticationTicket, Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Builder.OAuthOptions, System.Net.Http.HttpClient, Microsoft.AspNetCore.Authentication.OAuth.OAuthTokenResponse, Newtonsoft.Json.Linq.JObject)
    
        
    
        
        Initializes a new :any:`Microsoft.AspNetCore.Authentication.OAuth.OAuthCreatingTicketContext`\.
    
        
    
        
        :param ticket: The :any:`Microsoft.AspNetCore.Authentication.AuthenticationTicket`\.
        
        :type ticket: Microsoft.AspNetCore.Authentication.AuthenticationTicket
    
        
        :param context: The HTTP environment.
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :param options: The options used by the authentication middleware.
        
        :type options: Microsoft.AspNetCore.Builder.OAuthOptions
    
        
        :param backchannel: The HTTP client used by the authentication middleware
        
        :type backchannel: System.Net.Http.HttpClient
    
        
        :param tokens: The tokens returned from the token endpoint.
        
        :type tokens: Microsoft.AspNetCore.Authentication.OAuth.OAuthTokenResponse
    
        
        :param user: The JSON-serialized user.
        
        :type user: Newtonsoft.Json.Linq.JObject
    
        
        .. code-block:: csharp
    
            public OAuthCreatingTicketContext(AuthenticationTicket ticket, HttpContext context, OAuthOptions options, HttpClient backchannel, OAuthTokenResponse tokens, JObject user)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.OAuth.OAuthCreatingTicketContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OAuth.OAuthCreatingTicketContext.AccessToken
    
        
    
        
        Gets the access token provided by the authentication service.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string AccessToken { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OAuth.OAuthCreatingTicketContext.Backchannel
    
        
    
        
        Gets the backchannel used to communicate with the provider.
    
        
        :rtype: System.Net.Http.HttpClient
    
        
        .. code-block:: csharp
    
            public HttpClient Backchannel { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OAuth.OAuthCreatingTicketContext.ExpiresIn
    
        
    
        
        Gets the access token expiration time.
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.TimeSpan<System.TimeSpan>}
    
        
        .. code-block:: csharp
    
            public TimeSpan? ExpiresIn { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OAuth.OAuthCreatingTicketContext.Identity
    
        
    
        
        Gets the main identity exposed by :dn:prop:`Microsoft.AspNetCore.Authentication.OAuth.OAuthCreatingTicketContext.Ticket`\.
        This property returns <code>null</code> when :dn:prop:`Microsoft.AspNetCore.Authentication.OAuth.OAuthCreatingTicketContext.Ticket` is <code>null</code>.
    
        
        :rtype: System.Security.Claims.ClaimsIdentity
    
        
        .. code-block:: csharp
    
            public ClaimsIdentity Identity { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OAuth.OAuthCreatingTicketContext.Options
    
        
        :rtype: Microsoft.AspNetCore.Builder.OAuthOptions
    
        
        .. code-block:: csharp
    
            public OAuthOptions Options { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OAuth.OAuthCreatingTicketContext.RefreshToken
    
        
    
        
        Gets the refresh token provided by the authentication service.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string RefreshToken { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OAuth.OAuthCreatingTicketContext.Ticket
    
        
    
        
        The :any:`Microsoft.AspNetCore.Authentication.AuthenticationTicket` that will be created.
    
        
        :rtype: Microsoft.AspNetCore.Authentication.AuthenticationTicket
    
        
        .. code-block:: csharp
    
            public AuthenticationTicket Ticket { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OAuth.OAuthCreatingTicketContext.TokenResponse
    
        
    
        
        Gets the token response returned by the authentication service.
    
        
        :rtype: Microsoft.AspNetCore.Authentication.OAuth.OAuthTokenResponse
    
        
        .. code-block:: csharp
    
            public OAuthTokenResponse TokenResponse { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OAuth.OAuthCreatingTicketContext.TokenType
    
        
    
        
        Gets the access token type provided by the authentication service.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string TokenType { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OAuth.OAuthCreatingTicketContext.User
    
        
    
        
        Gets the JSON-serialized user or an empty 
        :any:`Newtonsoft.Json.Linq.JObject` if it is not available.
    
        
        :rtype: Newtonsoft.Json.Linq.JObject
    
        
        .. code-block:: csharp
    
            public JObject User { get; }
    

