

CookieAuthenticationOptions Class
=================================



.. contents:: 
   :local:



Summary
-------

Contains the options used by the CookiesAuthenticationMiddleware





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.AuthenticationOptions`
* :dn:cls:`Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions`








Syntax
------

.. code-block:: csharp

   public class CookieAuthenticationOptions : AuthenticationOptions, IOptions<CookieAuthenticationOptions>





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authentication.Cookies/CookieAuthenticationOptions.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions.CookieAuthenticationOptions()
    
        
    
        Create an instance of the options initialized with the default values
    
        
    
        
        .. code-block:: csharp
    
           public CookieAuthenticationOptions()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions.AccessDeniedPath
    
        
    
        The AccessDeniedPath property informs the middleware that it should change an outgoing 403 Forbidden status
        code into a 302 redirection onto the given path.
    
        
        :rtype: Microsoft.AspNet.Http.PathString
    
        
        .. code-block:: csharp
    
           public PathString AccessDeniedPath { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions.CookieDomain
    
        
    
        Determines the domain used to create the cookie. Is not provided by default.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string CookieDomain { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions.CookieHttpOnly
    
        
    
        Determines if the browser should allow the cookie to be accessed by client-side javascript. The
        default is true, which means the cookie will only be passed to http requests and is not made available
        to script on the page.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool CookieHttpOnly { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions.CookieManager
    
        
    
        The component used to get cookies from the request or set them on the response.
        
        
        ChunkingCookieManager will be used by default.
    
        
        :rtype: Microsoft.AspNet.Authentication.Cookies.ICookieManager
    
        
        .. code-block:: csharp
    
           public ICookieManager CookieManager { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions.CookieName
    
        
    
        Determines the cookie name used to persist the identity. The default value is ".AspNet.Cookies".
        This value should be changed if you change the name of the AuthenticationScheme, especially if your
        system uses the cookie authentication middleware multiple times.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string CookieName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions.CookiePath
    
        
    
        Determines the path used to create the cookie. The default value is "/" for highest browser compatability.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string CookiePath { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions.CookieSecure
    
        
    
        Determines if the cookie should only be transmitted on HTTPS request. The default is to limit the cookie
        to HTTPS requests if the page which is doing the SignIn is also HTTPS. If you have an HTTPS sign in page
        and portions of your site are HTTP you may need to change this value.
    
        
        :rtype: Microsoft.AspNet.Authentication.Cookies.CookieSecureOption
    
        
        .. code-block:: csharp
    
           public CookieSecureOption CookieSecure { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions.DataProtectionProvider
    
        
    
        If set this will be used by the CookieAuthenticationMiddleware for data protection.
    
        
        :rtype: Microsoft.AspNet.DataProtection.IDataProtectionProvider
    
        
        .. code-block:: csharp
    
           public IDataProtectionProvider DataProtectionProvider { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions.Events
    
        
    
        The Provider may be assigned to an instance of an object created by the application at startup time. The middleware
        calls methods on the provider which give the application control at certain points where processing is occurring.
        If it is not provided a default instance is supplied which does nothing when the methods are called.
    
        
        :rtype: Microsoft.AspNet.Authentication.Cookies.ICookieAuthenticationEvents
    
        
        .. code-block:: csharp
    
           public ICookieAuthenticationEvents Events { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions.ExpireTimeSpan
    
        
    
        Controls how much time the cookie will remain valid from the point it is created. The expiration
        information is in the protected cookie ticket. Because of that an expired cookie will be ignored
        even if it is passed to the server after the browser should have purged it
    
        
        :rtype: System.TimeSpan
    
        
        .. code-block:: csharp
    
           public TimeSpan ExpireTimeSpan { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions.LoginPath
    
        
    
        The LoginPath property informs the middleware that it should change an outgoing 401 Unauthorized status
        code into a 302 redirection onto the given login path. The current url which generated the 401 is added
        to the LoginPath as a query string parameter named by the ReturnUrlParameter. Once a request to the
        LoginPath grants a new SignIn identity, the ReturnUrlParameter value is used to redirect the browser back
        to the url which caused the original unauthorized status code.
    
        
        :rtype: Microsoft.AspNet.Http.PathString
    
        
        .. code-block:: csharp
    
           public PathString LoginPath { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions.LogoutPath
    
        
    
        If the LogoutPath is provided the middleware then a request to that path will redirect based on the ReturnUrlParameter.
    
        
        :rtype: Microsoft.AspNet.Http.PathString
    
        
        .. code-block:: csharp
    
           public PathString LogoutPath { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions.Microsoft.Extensions.OptionsModel.IOptions<Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions>.Value
    
        
        :rtype: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions
    
        
        .. code-block:: csharp
    
           CookieAuthenticationOptions IOptions<CookieAuthenticationOptions>.Value { get; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions.ReturnUrlParameter
    
        
    
        The ReturnUrlParameter determines the name of the query string parameter which is appended by the middleware
        when a 401 Unauthorized status code is changed to a 302 redirect onto the login path. This is also the query
        string parameter looked for when a request arrives on the login path or logout path, in order to return to the
        original url after the action is performed.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ReturnUrlParameter { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions.SessionStore
    
        
    
        An optional container in which to store the identity across requests. When used, only a session identifier is sent
        to the client. This can be used to mitigate potential problems with very large identities.
    
        
        :rtype: Microsoft.AspNet.Authentication.Cookies.ITicketStore
    
        
        .. code-block:: csharp
    
           public ITicketStore SessionStore { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions.SlidingExpiration
    
        
    
        The SlidingExpiration is set to true to instruct the middleware to re-issue a new cookie with a new
        expiration time any time it processes a request which is more than halfway through the expiration window.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool SlidingExpiration { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions.SystemClock
    
        
    
        For testing purposes only.
    
        
        :rtype: Microsoft.AspNet.Authentication.ISystemClock
    
        
        .. code-block:: csharp
    
           public ISystemClock SystemClock { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions.TicketDataFormat
    
        
    
        The TicketDataFormat is used to protect and unprotect the identity and other properties which are stored in the
        cookie value. If it is not provided a default data handler is created using the data protection service contained
        in the IApplicationBuilder.Properties. The default data protection service is based on machine key when running on ASP.NET,
        and on DPAPI when running in a different process.
    
        
        :rtype: Microsoft.AspNet.Authentication.ISecureDataFormat{Microsoft.AspNet.Authentication.AuthenticationTicket}
    
        
        .. code-block:: csharp
    
           public ISecureDataFormat<AuthenticationTicket> TicketDataFormat { get; set; }
    

