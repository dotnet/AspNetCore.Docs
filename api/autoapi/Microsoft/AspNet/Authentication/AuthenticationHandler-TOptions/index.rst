

AuthenticationHandler<TOptions> Class
=====================================



.. contents:: 
   :local:



Summary
-------

Base class for the per-request work performed by most authentication middleware.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.AuthenticationHandler\<TOptions>`








Syntax
------

.. code-block:: csharp

   public abstract class AuthenticationHandler<TOptions> : IAuthenticationHandler where TOptions : AuthenticationOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication/AuthenticationHandler.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.AuthenticationHandler<TOptions>

Methods
-------

.. dn:class:: Microsoft.AspNet.Authentication.AuthenticationHandler<TOptions>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authentication.AuthenticationHandler<TOptions>.AuthenticateAsync(Microsoft.AspNet.Http.Features.Authentication.AuthenticateContext)
    
        
        
        
        :type context: Microsoft.AspNet.Http.Features.Authentication.AuthenticateContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task AuthenticateAsync(AuthenticateContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.AuthenticationHandler<TOptions>.BuildRedirectUri(System.String)
    
        
        
        
        :type targetPath: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           protected string BuildRedirectUri(string targetPath)
    
    .. dn:method:: Microsoft.AspNet.Authentication.AuthenticationHandler<TOptions>.ChallengeAsync(Microsoft.AspNet.Http.Features.Authentication.ChallengeContext)
    
        
        
        
        :type context: Microsoft.AspNet.Http.Features.Authentication.ChallengeContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task ChallengeAsync(ChallengeContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.AuthenticationHandler<TOptions>.FinishResponseAsync()
    
        
    
        Hook that is called when the response about to be sent
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           protected virtual Task FinishResponseAsync()
    
    .. dn:method:: Microsoft.AspNet.Authentication.AuthenticationHandler<TOptions>.GetDescriptions(Microsoft.AspNet.Http.Features.Authentication.DescribeSchemesContext)
    
        
        
        
        :type describeContext: Microsoft.AspNet.Http.Features.Authentication.DescribeSchemesContext
    
        
        .. code-block:: csharp
    
           public void GetDescriptions(DescribeSchemesContext describeContext)
    
    .. dn:method:: Microsoft.AspNet.Authentication.AuthenticationHandler<TOptions>.HandleAuthenticateAsync()
    
        
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Authentication.AuthenticateResult}
    
        
        .. code-block:: csharp
    
           protected abstract Task<AuthenticateResult> HandleAuthenticateAsync()
    
    .. dn:method:: Microsoft.AspNet.Authentication.AuthenticationHandler<TOptions>.HandleAuthenticateOnceAsync()
    
        
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Authentication.AuthenticateResult}
    
        
        .. code-block:: csharp
    
           protected Task<AuthenticateResult> HandleAuthenticateOnceAsync()
    
    .. dn:method:: Microsoft.AspNet.Authentication.AuthenticationHandler<TOptions>.HandleForbiddenAsync(Microsoft.AspNet.Http.Features.Authentication.ChallengeContext)
    
        
        
        
        :type context: Microsoft.AspNet.Http.Features.Authentication.ChallengeContext
        :rtype: System.Threading.Tasks.Task{System.Boolean}
    
        
        .. code-block:: csharp
    
           protected virtual Task<bool> HandleForbiddenAsync(ChallengeContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.AuthenticationHandler<TOptions>.HandleRequestAsync()
    
        
    
        Called once by common code after initialization. If an authentication middleware responds directly to
        specifically known paths it must override this virtual, compare the request path to it's known paths,
        provide any response information as appropriate, and true to stop further processing.
    
        
        :rtype: System.Threading.Tasks.Task{System.Boolean}
        :return: Returning false will cause the common code to call the next middleware in line. Returning true will
            cause the common code to begin the async completion journey without calling the rest of the middleware
            pipeline.
    
        
        .. code-block:: csharp
    
           public virtual Task<bool> HandleRequestAsync()
    
    .. dn:method:: Microsoft.AspNet.Authentication.AuthenticationHandler<TOptions>.HandleSignInAsync(Microsoft.AspNet.Http.Features.Authentication.SignInContext)
    
        
        
        
        :type context: Microsoft.AspNet.Http.Features.Authentication.SignInContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           protected virtual Task HandleSignInAsync(SignInContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.AuthenticationHandler<TOptions>.HandleSignOutAsync(Microsoft.AspNet.Http.Features.Authentication.SignOutContext)
    
        
        
        
        :type context: Microsoft.AspNet.Http.Features.Authentication.SignOutContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           protected virtual Task HandleSignOutAsync(SignOutContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.AuthenticationHandler<TOptions>.HandleUnauthorizedAsync(Microsoft.AspNet.Http.Features.Authentication.ChallengeContext)
    
        
    
        Override this method to deal with 401 challenge concerns, if an authentication scheme in question
        deals an authentication interaction as part of it's request flow. (like adding a response header, or
        changing the 401 result to 302 of a login page or external sign-in location.)
    
        
        
        
        :type context: Microsoft.AspNet.Http.Features.Authentication.ChallengeContext
        :rtype: System.Threading.Tasks.Task{System.Boolean}
        :return: True if no other handlers should be called
    
        
        .. code-block:: csharp
    
           protected virtual Task<bool> HandleUnauthorizedAsync(ChallengeContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.AuthenticationHandler<TOptions>.InitializeAsync(TOptions, Microsoft.AspNet.Http.HttpContext, Microsoft.Extensions.Logging.ILogger, Microsoft.Extensions.WebEncoders.IUrlEncoder)
    
        
    
        Initialize is called once per request to contextualize this instance with appropriate state.
    
        
        
        
        :param options: The original options passed by the application control behavior
        
        :type options: {TOptions}
        
        
        :param context: The utility object to observe the current request and response
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :param logger: The logging factory used to create loggers
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :type encoder: Microsoft.Extensions.WebEncoders.IUrlEncoder
        :rtype: System.Threading.Tasks.Task
        :return: async completion
    
        
        .. code-block:: csharp
    
           public Task InitializeAsync(TOptions options, HttpContext context, ILogger logger, IUrlEncoder encoder)
    
    .. dn:method:: Microsoft.AspNet.Authentication.AuthenticationHandler<TOptions>.ShouldHandleScheme(System.String, System.Boolean)
    
        
        
        
        :type authenticationScheme: System.String
        
        
        :type handleAutomatic: System.Boolean
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool ShouldHandleScheme(string authenticationScheme, bool handleAutomatic)
    
    .. dn:method:: Microsoft.AspNet.Authentication.AuthenticationHandler<TOptions>.SignInAsync(Microsoft.AspNet.Http.Features.Authentication.SignInContext)
    
        
        
        
        :type context: Microsoft.AspNet.Http.Features.Authentication.SignInContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task SignInAsync(SignInContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.AuthenticationHandler<TOptions>.SignOutAsync(Microsoft.AspNet.Http.Features.Authentication.SignOutContext)
    
        
        
        
        :type context: Microsoft.AspNet.Http.Features.Authentication.SignOutContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task SignOutAsync(SignOutContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.AuthenticationHandler<TOptions>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.AuthenticationHandler<TOptions>.ChallengeCalled
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           protected bool ChallengeCalled { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.AuthenticationHandler<TOptions>.Context
    
        
        :rtype: Microsoft.AspNet.Http.HttpContext
    
        
        .. code-block:: csharp
    
           protected HttpContext Context { get; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.AuthenticationHandler<TOptions>.CurrentUri
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           protected string CurrentUri { get; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.AuthenticationHandler<TOptions>.Logger
    
        
        :rtype: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
           protected ILogger Logger { get; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.AuthenticationHandler<TOptions>.Options
    
        
        :rtype: {TOptions}
    
        
        .. code-block:: csharp
    
           protected TOptions Options { get; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.AuthenticationHandler<TOptions>.OriginalPath
    
        
        :rtype: Microsoft.AspNet.Http.PathString
    
        
        .. code-block:: csharp
    
           protected PathString OriginalPath { get; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.AuthenticationHandler<TOptions>.OriginalPathBase
    
        
        :rtype: Microsoft.AspNet.Http.PathString
    
        
        .. code-block:: csharp
    
           protected PathString OriginalPathBase { get; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.AuthenticationHandler<TOptions>.PriorHandler
    
        
        :rtype: Microsoft.AspNet.Http.Features.Authentication.IAuthenticationHandler
    
        
        .. code-block:: csharp
    
           public IAuthenticationHandler PriorHandler { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.AuthenticationHandler<TOptions>.Request
    
        
        :rtype: Microsoft.AspNet.Http.HttpRequest
    
        
        .. code-block:: csharp
    
           protected HttpRequest Request { get; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.AuthenticationHandler<TOptions>.Response
    
        
        :rtype: Microsoft.AspNet.Http.HttpResponse
    
        
        .. code-block:: csharp
    
           protected HttpResponse Response { get; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.AuthenticationHandler<TOptions>.SignInAccepted
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           protected bool SignInAccepted { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.AuthenticationHandler<TOptions>.SignOutAccepted
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           protected bool SignOutAccepted { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.AuthenticationHandler<TOptions>.UrlEncoder
    
        
        :rtype: Microsoft.Extensions.WebEncoders.IUrlEncoder
    
        
        .. code-block:: csharp
    
           protected IUrlEncoder UrlEncoder { get; }
    

