

RemoteAuthenticationOptions Class
=================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.AuthenticationOptions`
* :dn:cls:`Microsoft.AspNet.Authentication.RemoteAuthenticationOptions`








Syntax
------

.. code-block:: csharp

   public class RemoteAuthenticationOptions : AuthenticationOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authentication/RemoteAuthenticationOptions.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.RemoteAuthenticationOptions

Fields
------

.. dn:class:: Microsoft.AspNet.Authentication.RemoteAuthenticationOptions
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Authentication.RemoteAuthenticationOptions.Events
    
        
    
        
        .. code-block:: csharp
    
           public IRemoteAuthenticationEvents Events
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.RemoteAuthenticationOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.RemoteAuthenticationOptions.BackchannelHttpHandler
    
        
    
        The HttpMessageHandler used to communicate with Twitter.
        This cannot be set at the same time as BackchannelCertificateValidator unless the value
        can be downcast to a WebRequestHandler.
    
        
        :rtype: System.Net.Http.HttpMessageHandler
    
        
        .. code-block:: csharp
    
           public HttpMessageHandler BackchannelHttpHandler { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.RemoteAuthenticationOptions.BackchannelTimeout
    
        
    
        Gets or sets timeout value in milliseconds for back channel communications with Twitter.
    
        
        :rtype: System.TimeSpan
    
        
        .. code-block:: csharp
    
           public TimeSpan BackchannelTimeout { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.RemoteAuthenticationOptions.CallbackPath
    
        
    
        The request path within the application's base path where the user-agent will be returned.
        The middleware will process this request when it arrives.
    
        
        :rtype: Microsoft.AspNet.Http.PathString
    
        
        .. code-block:: csharp
    
           public PathString CallbackPath { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.RemoteAuthenticationOptions.DisplayName
    
        
    
        Get or sets the text that the user can display on a sign in user interface.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string DisplayName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.RemoteAuthenticationOptions.SignInScheme
    
        
    
        Gets or sets the authentication scheme corresponding to the middleware
        responsible of persisting user's identity after a successful authentication.
        This value typically corresponds to a cookie middleware registered in the Startup class.
        When omitted, :dn:prop:`Microsoft.AspNet.Authentication.SharedAuthenticationOptions.SignInScheme` is used as a fallback value.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string SignInScheme { get; set; }
    

