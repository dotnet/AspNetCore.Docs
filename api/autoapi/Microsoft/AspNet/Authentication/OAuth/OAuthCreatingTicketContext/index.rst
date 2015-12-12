

OAuthCreatingTicketContext Class
================================



.. contents:: 
   :local:



Summary
-------

Contains information about the login session as well as the user :any:`System.Security.Claims.ClaimsIdentity`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.BaseContext`
* :dn:cls:`Microsoft.AspNet.Authentication.OAuth.OAuthCreatingTicketContext`








Syntax
------

.. code-block:: csharp

   public class OAuthCreatingTicketContext : BaseContext





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication.OAuth/Events/OAuthCreatingTicketContext.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.OAuth.OAuthCreatingTicketContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.OAuth.OAuthCreatingTicketContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.OAuth.OAuthCreatingTicketContext.OAuthCreatingTicketContext(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Authentication.OAuth.OAuthOptions, System.Net.Http.HttpClient, Microsoft.AspNet.Authentication.OAuth.OAuthTokenResponse)
    
        
    
        Initializes a new :any:`Microsoft.AspNet.Authentication.OAuth.OAuthCreatingTicketContext`\.
    
        
        
        
        :param context: The HTTP environment.
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :param options: The options used by the authentication middleware.
        
        :type options: Microsoft.AspNet.Authentication.OAuth.OAuthOptions
        
        
        :param backchannel: The HTTP client used by the authentication middleware
        
        :type backchannel: System.Net.Http.HttpClient
        
        
        :param tokens: The tokens returned from the token endpoint.
        
        :type tokens: Microsoft.AspNet.Authentication.OAuth.OAuthTokenResponse
    
        
        .. code-block:: csharp
    
           public OAuthCreatingTicketContext(HttpContext context, OAuthOptions options, HttpClient backchannel, OAuthTokenResponse tokens)
    
    .. dn:constructor:: Microsoft.AspNet.Authentication.OAuth.OAuthCreatingTicketContext.OAuthCreatingTicketContext(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Authentication.OAuth.OAuthOptions, System.Net.Http.HttpClient, Microsoft.AspNet.Authentication.OAuth.OAuthTokenResponse, Newtonsoft.Json.Linq.JObject)
    
        
    
        Initializes a new :any:`Microsoft.AspNet.Authentication.OAuth.OAuthCreatingTicketContext`\.
    
        
        
        
        :param context: The HTTP environment.
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :param options: The options used by the authentication middleware.
        
        :type options: Microsoft.AspNet.Authentication.OAuth.OAuthOptions
        
        
        :param backchannel: The HTTP client used by the authentication middleware
        
        :type backchannel: System.Net.Http.HttpClient
        
        
        :param tokens: The tokens returned from the token endpoint.
        
        :type tokens: Microsoft.AspNet.Authentication.OAuth.OAuthTokenResponse
        
        
        :param user: The JSON-serialized user.
        
        :type user: Newtonsoft.Json.Linq.JObject
    
        
        .. code-block:: csharp
    
           public OAuthCreatingTicketContext(HttpContext context, OAuthOptions options, HttpClient backchannel, OAuthTokenResponse tokens, JObject user)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.OAuth.OAuthCreatingTicketContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.OAuth.OAuthCreatingTicketContext.AccessToken
    
        
    
        Gets the access token provided by the authentication service.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string AccessToken { get; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OAuth.OAuthCreatingTicketContext.Backchannel
    
        
    
        Gets the backchannel used to communicate with the provider.
    
        
        :rtype: System.Net.Http.HttpClient
    
        
        .. code-block:: csharp
    
           public HttpClient Backchannel { get; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OAuth.OAuthCreatingTicketContext.ExpiresIn
    
        
    
        Gets the access token expiration time.
    
        
        :rtype: System.Nullable{System.TimeSpan}
    
        
        .. code-block:: csharp
    
           public TimeSpan? ExpiresIn { get; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OAuth.OAuthCreatingTicketContext.Identity
    
        
    
        Gets the main identity exposed by :dn:prop:`Microsoft.AspNet.Authentication.OAuth.OAuthCreatingTicketContext.Principal`\.
        This property returns <c>null</c> when :dn:prop:`Microsoft.AspNet.Authentication.OAuth.OAuthCreatingTicketContext.Principal` is <c>null</c>.
    
        
        :rtype: System.Security.Claims.ClaimsIdentity
    
        
        .. code-block:: csharp
    
           public ClaimsIdentity Identity { get; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OAuth.OAuthCreatingTicketContext.Options
    
        
        :rtype: Microsoft.AspNet.Authentication.OAuth.OAuthOptions
    
        
        .. code-block:: csharp
    
           public OAuthOptions Options { get; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OAuth.OAuthCreatingTicketContext.Principal
    
        
    
        Gets the :any:`System.Security.Claims.ClaimsPrincipal` representing the user.
    
        
        :rtype: System.Security.Claims.ClaimsPrincipal
    
        
        .. code-block:: csharp
    
           public ClaimsPrincipal Principal { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OAuth.OAuthCreatingTicketContext.Properties
    
        
    
        Gets or sets a property bag for common authentication properties.
    
        
        :rtype: Microsoft.AspNet.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
           public AuthenticationProperties Properties { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OAuth.OAuthCreatingTicketContext.RefreshToken
    
        
    
        Gets the refresh token provided by the authentication service.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string RefreshToken { get; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OAuth.OAuthCreatingTicketContext.TokenResponse
    
        
    
        Gets the token response returned by the authentication service.
    
        
        :rtype: Microsoft.AspNet.Authentication.OAuth.OAuthTokenResponse
    
        
        .. code-block:: csharp
    
           public OAuthTokenResponse TokenResponse { get; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OAuth.OAuthCreatingTicketContext.TokenType
    
        
    
        Gets the access token type provided by the authentication service.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string TokenType { get; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OAuth.OAuthCreatingTicketContext.User
    
        
    
        Gets the JSON-serialized user or an empty 
        :any:`Newtonsoft.Json.Linq.JObject` if it is not available.
    
        
        :rtype: Newtonsoft.Json.Linq.JObject
    
        
        .. code-block:: csharp
    
           public JObject User { get; }
    

