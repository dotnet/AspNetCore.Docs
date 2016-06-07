

RemoteAuthenticationOptions Class
=================================






Contains the options used by the :any:`Microsoft.AspNetCore.Authentication.RemoteAuthenticationHandler\`1`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.Authentication

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Builder.AuthenticationOptions`
* :dn:cls:`Microsoft.AspNetCore.Builder.RemoteAuthenticationOptions`








Syntax
------

.. code-block:: csharp

    public class RemoteAuthenticationOptions : AuthenticationOptions








.. dn:class:: Microsoft.AspNetCore.Builder.RemoteAuthenticationOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.RemoteAuthenticationOptions

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Builder.RemoteAuthenticationOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Builder.RemoteAuthenticationOptions.BackchannelHttpHandler
    
        
    
        
        The HttpMessageHandler used to communicate with Twitter.
        This cannot be set at the same time as BackchannelCertificateValidator unless the value 
        can be downcast to a WebRequestHandler.
    
        
        :rtype: System.Net.Http.HttpMessageHandler
    
        
        .. code-block:: csharp
    
            public HttpMessageHandler BackchannelHttpHandler
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.RemoteAuthenticationOptions.BackchannelTimeout
    
        
    
        
        Gets or sets timeout value in milliseconds for back channel communications with the remote provider.
    
        
        :rtype: System.TimeSpan
        :return: 
            The back channel timeout.
    
        
        .. code-block:: csharp
    
            public TimeSpan BackchannelTimeout
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.RemoteAuthenticationOptions.CallbackPath
    
        
    
        
        The request path within the application's base path where the user-agent will be returned.
        The middleware will process this request when it arrives.
    
        
        :rtype: Microsoft.AspNetCore.Http.PathString
    
        
        .. code-block:: csharp
    
            public PathString CallbackPath
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.RemoteAuthenticationOptions.DisplayName
    
        
    
        
        Get or sets the text that the user can display on a sign in user interface.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string DisplayName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.RemoteAuthenticationOptions.RemoteAuthenticationTimeout
    
        
    
        
        Gets or sets the time limit for completing the authentication flow (15 minutes by default).
    
        
        :rtype: System.TimeSpan
    
        
        .. code-block:: csharp
    
            public TimeSpan RemoteAuthenticationTimeout
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.RemoteAuthenticationOptions.SaveTokens
    
        
    
        
        Defines whether access and refresh tokens should be stored in the
        :any:`Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties` after a successful authorization.
        This property is set to <code>false</code> by default to reduce
        the size of the final authentication cookie.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool SaveTokens
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.RemoteAuthenticationOptions.SignInScheme
    
        
    
        
        Gets or sets the authentication scheme corresponding to the middleware
        responsible of persisting user's identity after a successful authentication.
        This value typically corresponds to a cookie middleware registered in the Startup class.
        When omitted, :dn:prop:`Microsoft.AspNetCore.Authentication.SharedAuthenticationOptions.SignInScheme` is used as a fallback value.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string SignInScheme
            {
                get;
                set;
            }
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Builder.RemoteAuthenticationOptions
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Builder.RemoteAuthenticationOptions.Events
    
        
        :rtype: Microsoft.AspNetCore.Authentication.IRemoteAuthenticationEvents
    
        
        .. code-block:: csharp
    
            public IRemoteAuthenticationEvents Events
    

