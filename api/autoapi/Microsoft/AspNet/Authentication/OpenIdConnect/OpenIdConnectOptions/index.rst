

OpenIdConnectOptions Class
==========================



.. contents:: 
   :local:



Summary
-------

Configuration options for :any:`Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions`





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.AuthenticationOptions`
* :dn:cls:`Microsoft.AspNet.Authentication.RemoteAuthenticationOptions`
* :dn:cls:`Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions`








Syntax
------

.. code-block:: csharp

   public class OpenIdConnectOptions : RemoteAuthenticationOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authentication.OpenIdConnect/OpenIdConnectOptions.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions.OpenIdConnectOptions()
    
        
    
        Initializes a new :any:`Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions`
    
        
    
        
        .. code-block:: csharp
    
           public OpenIdConnectOptions()
    
    .. dn:constructor:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions.OpenIdConnectOptions(System.String)
    
        
    
        Initializes a new :any:`Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions`
    
        
        
        
        :param authenticationScheme: will be used to when creating the  for the AuthenticationScheme property.
        
        :type authenticationScheme: System.String
    
        
        .. code-block:: csharp
    
           public OpenIdConnectOptions(string authenticationScheme)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions.Audience
    
        
    
        Gets or sets the expected audience for any received JWT token.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Audience { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions.AuthenticationMethod
    
        
    
        Gets or sets the method used to redirect the user agent to the identity provider.
    
        
        :rtype: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectRedirectBehavior
    
        
        .. code-block:: csharp
    
           public OpenIdConnectRedirectBehavior AuthenticationMethod { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions.Authority
    
        
    
        Gets or sets the Authority to use when making OpenIdConnect calls.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Authority { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions.ClientId
    
        
    
        Gets or sets the 'client_id'.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ClientId { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions.ClientSecret
    
        
    
        Gets or sets the 'client_secret'.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ClientSecret { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions.Configuration
    
        
    
        Configuration provided directly by the developer. If provided, then MetadataAddress and the Backchannel properties
        will not be used. This information should not be updated during request processing.
    
        
        :rtype: Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectConfiguration
    
        
        .. code-block:: csharp
    
           public OpenIdConnectConfiguration Configuration { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions.ConfigurationManager
    
        
    
        Responsible for retrieving, caching, and refreshing the configuration from metadata.
        If not provided, then one will be created using the MetadataAddress and Backchannel properties.
    
        
        :rtype: Microsoft.IdentityModel.Protocols.IConfigurationManager{Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectConfiguration}
    
        
        .. code-block:: csharp
    
           public IConfigurationManager<OpenIdConnectConfiguration> ConfigurationManager { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions.Events
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Authentication.OpenIdConnect.IOpenIdConnectEvents` to notify when processing OpenIdConnect messages.
    
        
        :rtype: Microsoft.AspNet.Authentication.OpenIdConnect.IOpenIdConnectEvents
    
        
        .. code-block:: csharp
    
           public IOpenIdConnectEvents Events { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions.GetClaimsFromUserInfoEndpoint
    
        
    
        Boolean to set whether the middleware should go to user info endpoint to retrieve additional claims or not after creating an identity from id_token received from token endpoint.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool GetClaimsFromUserInfoEndpoint { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions.MetadataAddress
    
        
    
        Gets or sets the discovery endpoint for obtaining metadata
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string MetadataAddress { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions.PostLogoutRedirectUri
    
        
    
        Gets or sets the 'post_logout_redirect_uri'
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string PostLogoutRedirectUri { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions.ProtocolValidator
    
        
    
        Gets or sets the :any:`Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectProtocolValidator` that is used to ensure that the 'id_token' received
        is valid per: http://openid.net/specs/openid-connect-core-1_0.html#IDTokenValidation
    
        
        :rtype: Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectProtocolValidator
    
        
        .. code-block:: csharp
    
           public OpenIdConnectProtocolValidator ProtocolValidator { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions.RefreshOnIssuerKeyNotFound
    
        
    
        Gets or sets if a metadata refresh should be attempted after a SecurityTokenSignatureKeyNotFoundException. This allows for automatic
        recovery in the event of a signature key rollover. This is enabled by default.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool RefreshOnIssuerKeyNotFound { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions.RequireHttpsMetadata
    
        
    
        Gets or sets if HTTPS is required for the metadata address or authority.
        The default is true. This should be disabled only in development environments.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool RequireHttpsMetadata { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions.Resource
    
        
    
        Gets or sets the 'resource'.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Resource { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions.ResponseMode
    
        
    
        Gets or sets the 'response_mode'.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ResponseMode { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions.ResponseType
    
        
    
        Gets or sets the 'response_type'.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ResponseType { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions.SaveTokensAsClaims
    
        
    
        Defines whether access and refresh tokens should be stored in the 
        ClaimsPrincipal after a successful authentication.
        You can set this property to <c>false</c> to reduce the size of the final authentication cookie.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool SaveTokensAsClaims { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions.Scope
    
        
    
        Gets the list of permissions to request.
    
        
        :rtype: System.Collections.Generic.IList{System.String}
    
        
        .. code-block:: csharp
    
           public IList<string> Scope { get; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions.SecurityTokenValidator
    
        
    
        Gets or sets the :any:`System.IdentityModel.Tokens.ISecurityTokenValidator` used to validate identity tokens.
    
        
        :rtype: System.IdentityModel.Tokens.ISecurityTokenValidator
    
        
        .. code-block:: csharp
    
           public ISecurityTokenValidator SecurityTokenValidator { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions.StateDataFormat
    
        
    
        Gets or sets the type used to secure data handled by the middleware.
    
        
        :rtype: Microsoft.AspNet.Authentication.ISecureDataFormat{Microsoft.AspNet.Http.Authentication.AuthenticationProperties}
    
        
        .. code-block:: csharp
    
           public ISecureDataFormat<AuthenticationProperties> StateDataFormat { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions.StringDataFormat
    
        
    
        Gets or sets the type used to secure strings used by the middleware.
    
        
        :rtype: Microsoft.AspNet.Authentication.ISecureDataFormat{System.String}
    
        
        .. code-block:: csharp
    
           public ISecureDataFormat<string> StringDataFormat { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions.TokenValidationParameters
    
        
    
        Gets or sets the parameters used to validate identity tokens.
    
        
        :rtype: System.IdentityModel.Tokens.TokenValidationParameters
    
        
        .. code-block:: csharp
    
           public TokenValidationParameters TokenValidationParameters { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions.UseTokenLifetime
    
        
    
        Indicates that the authentication session lifetime (e.g. cookies) should match that of the authentication token.
        If the token does not provide lifetime information then normal session lifetimes will be used.
        This is disabled by default.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool UseTokenLifetime { get; set; }
    

