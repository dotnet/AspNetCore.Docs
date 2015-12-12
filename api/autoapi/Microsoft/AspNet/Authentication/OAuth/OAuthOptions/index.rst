

OAuthOptions Class
==================



.. contents:: 
   :local:



Summary
-------

Configuration options for OAuthMiddleware\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.AuthenticationOptions`
* :dn:cls:`Microsoft.AspNet.Authentication.RemoteAuthenticationOptions`
* :dn:cls:`Microsoft.AspNet.Authentication.OAuth.OAuthOptions`








Syntax
------

.. code-block:: csharp

   public class OAuthOptions : RemoteAuthenticationOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authentication.OAuth/OAuthOptions.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.OAuth.OAuthOptions

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.OAuth.OAuthOptions
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.OAuth.OAuthOptions.OAuthOptions()
    
        
    
        
        .. code-block:: csharp
    
           public OAuthOptions()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.OAuth.OAuthOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.OAuth.OAuthOptions.AuthorizationEndpoint
    
        
    
        Gets or sets the URI where the client will be redirected to authenticate.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string AuthorizationEndpoint { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OAuth.OAuthOptions.ClientId
    
        
    
        Gets or sets the provider-assigned client id.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ClientId { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OAuth.OAuthOptions.ClientSecret
    
        
    
        Gets or sets the provider-assigned client secret.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ClientSecret { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OAuth.OAuthOptions.Events
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Authentication.OAuth.IOAuthEvents` used to handle authentication events.
    
        
        :rtype: Microsoft.AspNet.Authentication.OAuth.IOAuthEvents
    
        
        .. code-block:: csharp
    
           public IOAuthEvents Events { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OAuth.OAuthOptions.SaveTokensAsClaims
    
        
    
        Defines whether access and refresh tokens should be stored in the 
        ClaimsPrincipal after a successful authentication.
        You can set this property to <c>false</c> to reduce the size of the final
        authentication cookie. Note that social providers set this property to <c>false</c> by default.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool SaveTokensAsClaims { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OAuth.OAuthOptions.Scope
    
        
    
        A list of permissions to request.
    
        
        :rtype: System.Collections.Generic.IList{System.String}
    
        
        .. code-block:: csharp
    
           public IList<string> Scope { get; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OAuth.OAuthOptions.StateDataFormat
    
        
    
        Gets or sets the type used to secure data handled by the middleware.
    
        
        :rtype: Microsoft.AspNet.Authentication.ISecureDataFormat{Microsoft.AspNet.Http.Authentication.AuthenticationProperties}
    
        
        .. code-block:: csharp
    
           public ISecureDataFormat<AuthenticationProperties> StateDataFormat { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OAuth.OAuthOptions.TokenEndpoint
    
        
    
        Gets or sets the URI the middleware will access to exchange the OAuth token.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string TokenEndpoint { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OAuth.OAuthOptions.UserInformationEndpoint
    
        
    
        Gets or sets the URI the middleware will access to obtain the user information.
        This value is not used in the default implementation, it is for use in custom implementations of
        IOAuthAuthenticationEvents.Authenticated or OAuthAuthenticationHandler.CreateTicketAsync.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string UserInformationEndpoint { get; set; }
    

