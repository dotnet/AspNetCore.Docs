

JwtBearerOptions Class
======================






Options class provides information needed to control Bearer Authentication middleware behavior


Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.Authentication.JwtBearer

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Builder.AuthenticationOptions`
* :dn:cls:`Microsoft.AspNetCore.Builder.JwtBearerOptions`








Syntax
------

.. code-block:: csharp

    public class JwtBearerOptions : AuthenticationOptions








.. dn:class:: Microsoft.AspNetCore.Builder.JwtBearerOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.JwtBearerOptions

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Builder.JwtBearerOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Builder.JwtBearerOptions.Audience
    
        
    
        
        Gets or sets the audience for any received OpenIdConnect token.
    
        
        :rtype: System.String
        :return: 
            The expected audience for any received OpenIdConnect token.
    
        
        .. code-block:: csharp
    
            public string Audience
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.JwtBearerOptions.Authority
    
        
    
        
        Gets or sets the Authority to use when making OpenIdConnect calls.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Authority
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.JwtBearerOptions.BackchannelHttpHandler
    
        
    
        
        The HttpMessageHandler used to retrieve metadata.
        This cannot be set at the same time as BackchannelCertificateValidator unless the value
        is a WebRequestHandler.
    
        
        :rtype: System.Net.Http.HttpMessageHandler
    
        
        .. code-block:: csharp
    
            public HttpMessageHandler BackchannelHttpHandler
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.JwtBearerOptions.BackchannelTimeout
    
        
    
        
        Gets or sets the timeout when using the backchannel to make an http call.
    
        
        :rtype: System.TimeSpan
    
        
        .. code-block:: csharp
    
            public TimeSpan BackchannelTimeout
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.JwtBearerOptions.Challenge
    
        
    
        
        Gets or sets the challenge to put in the "WWW-Authenticate" header.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Challenge
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.JwtBearerOptions.Configuration
    
        
    
        
        Configuration provided directly by the developer. If provided, then MetadataAddress and the Backchannel properties
        will not be used. This information should not be updated during request processing.
    
        
        :rtype: Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectConfiguration
    
        
        .. code-block:: csharp
    
            public OpenIdConnectConfiguration Configuration
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.JwtBearerOptions.ConfigurationManager
    
        
    
        
        Responsible for retrieving, caching, and refreshing the configuration from metadata.
        If not provided, then one will be created using the MetadataAddress and Backchannel properties.
    
        
        :rtype: Microsoft.IdentityModel.Protocols.IConfigurationManager<Microsoft.IdentityModel.Protocols.IConfigurationManager`1>{Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectConfiguration<Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectConfiguration>}
    
        
        .. code-block:: csharp
    
            public IConfigurationManager<OpenIdConnectConfiguration> ConfigurationManager
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.JwtBearerOptions.Events
    
        
    
        
        The object provided by the application to process events raised by the bearer authentication middleware.
        The application may implement the interface fully, or it may create an instance of JwtBearerAuthenticationEvents
        and assign delegates only to the events it wants to process.
    
        
        :rtype: Microsoft.AspNetCore.Authentication.JwtBearer.IJwtBearerEvents
    
        
        .. code-block:: csharp
    
            public IJwtBearerEvents Events
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.JwtBearerOptions.MetadataAddress
    
        
    
        
        Gets or sets the discovery endpoint for obtaining metadata
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string MetadataAddress
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.JwtBearerOptions.RefreshOnIssuerKeyNotFound
    
        
    
        
        Gets or sets if a metadata refresh should be attempted after a SecurityTokenSignatureKeyNotFoundException. This allows for automatic
        recovery in the event of a signature key rollover. This is enabled by default.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool RefreshOnIssuerKeyNotFound
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.JwtBearerOptions.RequireHttpsMetadata
    
        
    
        
        Gets or sets if HTTPS is required for the metadata address or authority.
        The default is true. This should be disabled only in development environments.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool RequireHttpsMetadata
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.JwtBearerOptions.SaveToken
    
        
    
        
        Defines whether the bearer token should be stored in the
        :any:`Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties` after a successful authorization.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool SaveToken
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.JwtBearerOptions.SecurityTokenValidators
    
        
    
        
        Gets the ordered list of :any:`Microsoft.IdentityModel.Tokens.ISecurityTokenValidator` used to validate access tokens.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.IdentityModel.Tokens.ISecurityTokenValidator<Microsoft.IdentityModel.Tokens.ISecurityTokenValidator>}
    
        
        .. code-block:: csharp
    
            public IList<ISecurityTokenValidator> SecurityTokenValidators
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.JwtBearerOptions.SystemClock
    
        
    
        
        For testing purposes only.
    
        
        :rtype: Microsoft.AspNetCore.Authentication.ISystemClock
    
        
        .. code-block:: csharp
    
            [EditorBrowsable(EditorBrowsableState.Never)]
            public ISystemClock SystemClock
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.JwtBearerOptions.TokenValidationParameters
    
        
    
        
        Gets or sets the parameters used to validate identity tokens.
    
        
        :rtype: Microsoft.IdentityModel.Tokens.TokenValidationParameters
    
        
        .. code-block:: csharp
    
            public TokenValidationParameters TokenValidationParameters
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Builder.JwtBearerOptions
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Builder.JwtBearerOptions.JwtBearerOptions()
    
        
    
        
        Creates an instance of bearer authentication options with default values.
    
        
    
        
        .. code-block:: csharp
    
            public JwtBearerOptions()
    

