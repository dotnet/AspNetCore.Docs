

OpenIdConnectOptions Class
==========================






Configuration options for :any:`Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectMiddleware`


Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.Authentication.OpenIdConnect

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Builder.AuthenticationOptions`
* :dn:cls:`Microsoft.AspNetCore.Builder.RemoteAuthenticationOptions`
* :dn:cls:`Microsoft.AspNetCore.Builder.OpenIdConnectOptions`








Syntax
------

.. code-block:: csharp

    public class OpenIdConnectOptions : RemoteAuthenticationOptions








.. dn:class:: Microsoft.AspNetCore.Builder.OpenIdConnectOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.OpenIdConnectOptions

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Builder.OpenIdConnectOptions
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Builder.OpenIdConnectOptions.OpenIdConnectOptions()
    
        
    
        
        Initializes a new :any:`Microsoft.AspNetCore.Builder.OpenIdConnectOptions`
    
        
    
        
        .. code-block:: csharp
    
            public OpenIdConnectOptions()
    
    .. dn:constructor:: Microsoft.AspNetCore.Builder.OpenIdConnectOptions.OpenIdConnectOptions(System.String)
    
        
    
        
        Initializes a new :any:`Microsoft.AspNetCore.Builder.OpenIdConnectOptions`
    
        
    
        
        :param authenticationScheme: will be used to when creating the :any:`System.Security.Claims.ClaimsIdentity` for the AuthenticationScheme property.
        
        :type authenticationScheme: System.String
    
        
        .. code-block:: csharp
    
            public OpenIdConnectOptions(string authenticationScheme)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Builder.OpenIdConnectOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Builder.OpenIdConnectOptions.AuthenticationMethod
    
        
    
        
        Gets or sets the method used to redirect the user agent to the identity provider.
    
        
        :rtype: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectRedirectBehavior
    
        
        .. code-block:: csharp
    
            public OpenIdConnectRedirectBehavior AuthenticationMethod { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.OpenIdConnectOptions.Authority
    
        
    
        
        Gets or sets the Authority to use when making OpenIdConnect calls.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Authority { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.OpenIdConnectOptions.ClientId
    
        
    
        
        Gets or sets the 'client_id'.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ClientId { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.OpenIdConnectOptions.ClientSecret
    
        
    
        
        Gets or sets the 'client_secret'.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ClientSecret { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.OpenIdConnectOptions.Configuration
    
        
    
        
        Configuration provided directly by the developer. If provided, then MetadataAddress and the Backchannel properties
        will not be used. This information should not be updated during request processing.
    
        
        :rtype: Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectConfiguration
    
        
        .. code-block:: csharp
    
            public OpenIdConnectConfiguration Configuration { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.OpenIdConnectOptions.ConfigurationManager
    
        
    
        
        Responsible for retrieving, caching, and refreshing the configuration from metadata.
        If not provided, then one will be created using the MetadataAddress and Backchannel properties.
    
        
        :rtype: Microsoft.IdentityModel.Protocols.IConfigurationManager<Microsoft.IdentityModel.Protocols.IConfigurationManager`1>{Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectConfiguration<Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectConfiguration>}
    
        
        .. code-block:: csharp
    
            public IConfigurationManager<OpenIdConnectConfiguration> ConfigurationManager { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.OpenIdConnectOptions.Events
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Authentication.OpenIdConnect.IOpenIdConnectEvents` to notify when processing OpenIdConnect messages.
    
        
        :rtype: Microsoft.AspNetCore.Authentication.OpenIdConnect.IOpenIdConnectEvents
    
        
        .. code-block:: csharp
    
            public IOpenIdConnectEvents Events { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.OpenIdConnectOptions.GetClaimsFromUserInfoEndpoint
    
        
    
        
        Boolean to set whether the middleware should go to user info endpoint to retrieve additional claims or not after creating an identity from id_token received from token endpoint.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool GetClaimsFromUserInfoEndpoint { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.OpenIdConnectOptions.MetadataAddress
    
        
    
        
        Gets or sets the discovery endpoint for obtaining metadata
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string MetadataAddress { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.OpenIdConnectOptions.PostLogoutRedirectUri
    
        
    
        
        Gets or sets the 'post_logout_redirect_uri'
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string PostLogoutRedirectUri { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.OpenIdConnectOptions.ProtocolValidator
    
        
    
        
        Gets or sets the :any:`Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectProtocolValidator` that is used to ensure that the 'id_token' received
        is valid per: http://openid.net/specs/openid-connect-core-1_0.html#IDTokenValidation 
    
        
        :rtype: Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectProtocolValidator
    
        
        .. code-block:: csharp
    
            public OpenIdConnectProtocolValidator ProtocolValidator { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.OpenIdConnectOptions.RefreshOnIssuerKeyNotFound
    
        
    
        
        Gets or sets if a metadata refresh should be attempted after a SecurityTokenSignatureKeyNotFoundException. This allows for automatic
        recovery in the event of a signature key rollover. This is enabled by default.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool RefreshOnIssuerKeyNotFound { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.OpenIdConnectOptions.RemoteSignOutPath
    
        
    
        
        Requests received on this path will cause the middleware to invoke SignOut using the SignInScheme.
    
        
        :rtype: Microsoft.AspNetCore.Http.PathString
    
        
        .. code-block:: csharp
    
            public PathString RemoteSignOutPath { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.OpenIdConnectOptions.RequireHttpsMetadata
    
        
    
        
        Gets or sets if HTTPS is required for the metadata address or authority.
        The default is true. This should be disabled only in development environments.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool RequireHttpsMetadata { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.OpenIdConnectOptions.Resource
    
        
    
        
        Gets or sets the 'resource'.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Resource { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.OpenIdConnectOptions.ResponseMode
    
        
    
        
        Gets or sets the 'response_mode'.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ResponseMode { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.OpenIdConnectOptions.ResponseType
    
        
    
        
        Gets or sets the 'response_type'.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ResponseType { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.OpenIdConnectOptions.Scope
    
        
    
        
        Gets the list of permissions to request.
    
        
        :rtype: System.Collections.Generic.ICollection<System.Collections.Generic.ICollection`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public ICollection<string> Scope { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.OpenIdConnectOptions.SecurityTokenValidator
    
        
    
        
        Gets or sets the :any:`Microsoft.IdentityModel.Tokens.ISecurityTokenValidator` used to validate identity tokens.
    
        
        :rtype: Microsoft.IdentityModel.Tokens.ISecurityTokenValidator
    
        
        .. code-block:: csharp
    
            public ISecurityTokenValidator SecurityTokenValidator { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.OpenIdConnectOptions.SignOutScheme
    
        
    
        
        The Authentication Scheme to use with SignOut on the SignOutPath. SignInScheme will be used if this
        is not set.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string SignOutScheme { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.OpenIdConnectOptions.SkipUnrecognizedRequests
    
        
    
        
        Indicates if requests to the CallbackPath may also be for other components. If enabled the middleware will pass
        requests through that do not contain OpenIdConnect authentication responses. Disabling this and setting the
        CallbackPath to a dedicated endpoint may provide better error handling.
        This is disabled by default.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool SkipUnrecognizedRequests { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.OpenIdConnectOptions.StateDataFormat
    
        
    
        
        Gets or sets the type used to secure data handled by the middleware.
    
        
        :rtype: Microsoft.AspNetCore.Authentication.ISecureDataFormat<Microsoft.AspNetCore.Authentication.ISecureDataFormat`1>{Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties<Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties>}
    
        
        .. code-block:: csharp
    
            public ISecureDataFormat<AuthenticationProperties> StateDataFormat { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.OpenIdConnectOptions.StringDataFormat
    
        
    
        
        Gets or sets the type used to secure strings used by the middleware.
    
        
        :rtype: Microsoft.AspNetCore.Authentication.ISecureDataFormat<Microsoft.AspNetCore.Authentication.ISecureDataFormat`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public ISecureDataFormat<string> StringDataFormat { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.OpenIdConnectOptions.SystemClock
    
        
    
        
        For testing purposes only.
    
        
        :rtype: Microsoft.AspNetCore.Authentication.ISystemClock
    
        
        .. code-block:: csharp
    
            [EditorBrowsable(EditorBrowsableState.Never)]
            public ISystemClock SystemClock { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.OpenIdConnectOptions.TokenValidationParameters
    
        
    
        
        Gets or sets the parameters used to validate identity tokens.
    
        
        :rtype: Microsoft.IdentityModel.Tokens.TokenValidationParameters
    
        
        .. code-block:: csharp
    
            public TokenValidationParameters TokenValidationParameters { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.OpenIdConnectOptions.UseTokenLifetime
    
        
    
        
        Indicates that the authentication session lifetime (e.g. cookies) should match that of the authentication token.
        If the token does not provide lifetime information then normal session lifetimes will be used.
        This is disabled by default.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool UseTokenLifetime { get; set; }
    

