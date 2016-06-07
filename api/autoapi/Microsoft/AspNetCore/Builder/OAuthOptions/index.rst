

OAuthOptions Class
==================






Configuration options for :any:`Microsoft.AspNetCore.Authentication.OAuth.OAuthMiddleware\`1`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.Authentication.OAuth

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Builder.AuthenticationOptions`
* :dn:cls:`Microsoft.AspNetCore.Builder.RemoteAuthenticationOptions`
* :dn:cls:`Microsoft.AspNetCore.Builder.OAuthOptions`








Syntax
------

.. code-block:: csharp

    public class OAuthOptions : RemoteAuthenticationOptions








.. dn:class:: Microsoft.AspNetCore.Builder.OAuthOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.OAuthOptions

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Builder.OAuthOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Builder.OAuthOptions.AuthorizationEndpoint
    
        
    
        
        Gets or sets the URI where the client will be redirected to authenticate.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string AuthorizationEndpoint
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.OAuthOptions.ClientId
    
        
    
        
        Gets or sets the provider-assigned client id.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ClientId
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.OAuthOptions.ClientSecret
    
        
    
        
        Gets or sets the provider-assigned client secret.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ClientSecret
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.OAuthOptions.Events
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Authentication.OAuth.IOAuthEvents` used to handle authentication events.
    
        
        :rtype: Microsoft.AspNetCore.Authentication.OAuth.IOAuthEvents
    
        
        .. code-block:: csharp
    
            public IOAuthEvents Events
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.OAuthOptions.Scope
    
        
    
        
        Gets the list of permissions to request.
    
        
        :rtype: System.Collections.Generic.ICollection<System.Collections.Generic.ICollection`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public ICollection<string> Scope
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.OAuthOptions.StateDataFormat
    
        
    
        
        Gets or sets the type used to secure data handled by the middleware.
    
        
        :rtype: Microsoft.AspNetCore.Authentication.ISecureDataFormat<Microsoft.AspNetCore.Authentication.ISecureDataFormat`1>{Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties<Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties>}
    
        
        .. code-block:: csharp
    
            public ISecureDataFormat<AuthenticationProperties> StateDataFormat
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.OAuthOptions.SystemClock
    
        
    
        
        For testing purposes only.
    
        
        :rtype: Microsoft.AspNetCore.Authentication.ISystemClock
    
        
        .. code-block:: csharp
    
            [EditorBrowsable(EditorBrowsableState.Never)]
            public ISystemClock SystemClock
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.OAuthOptions.TokenEndpoint
    
        
    
        
        Gets or sets the URI the middleware will access to exchange the OAuth token.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string TokenEndpoint
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.OAuthOptions.UserInformationEndpoint
    
        
    
        
        Gets or sets the URI the middleware will access to obtain the user information.
        This value is not used in the default implementation, it is for use in custom implementations of
        IOAuthAuthenticationEvents.Authenticated or OAuthAuthenticationHandler.CreateTicketAsync.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string UserInformationEndpoint
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Builder.OAuthOptions
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Builder.OAuthOptions.OAuthOptions()
    
        
    
        
        .. code-block:: csharp
    
            public OAuthOptions()
    

