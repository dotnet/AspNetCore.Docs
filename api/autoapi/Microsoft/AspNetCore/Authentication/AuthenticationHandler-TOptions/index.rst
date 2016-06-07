

AuthenticationHandler<TOptions> Class
=====================================






Base class for the per-request work performed by most authentication middleware.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication`
Assemblies
    * Microsoft.AspNetCore.Authentication

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authentication.AuthenticationHandler\<TOptions>`








Syntax
------

.. code-block:: csharp

    public abstract class AuthenticationHandler<TOptions> : IAuthenticationHandler where TOptions : AuthenticationOptions








.. dn:class:: Microsoft.AspNetCore.Authentication.AuthenticationHandler`1
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.AuthenticationHandler<TOptions>

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.AuthenticationHandler<TOptions>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.AuthenticationHandler<TOptions>.ChallengeCalled
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected bool ChallengeCalled
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.AuthenticationHandler<TOptions>.Context
    
        
        :rtype: Microsoft.AspNetCore.Http.HttpContext
    
        
        .. code-block:: csharp
    
            protected HttpContext Context
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.AuthenticationHandler<TOptions>.CurrentUri
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            protected string CurrentUri
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.AuthenticationHandler<TOptions>.Logger
    
        
        :rtype: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
            protected ILogger Logger
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.AuthenticationHandler<TOptions>.Options
    
        
        :rtype: TOptions
    
        
        .. code-block:: csharp
    
            protected TOptions Options
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.AuthenticationHandler<TOptions>.OriginalPath
    
        
        :rtype: Microsoft.AspNetCore.Http.PathString
    
        
        .. code-block:: csharp
    
            protected PathString OriginalPath
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.AuthenticationHandler<TOptions>.OriginalPathBase
    
        
        :rtype: Microsoft.AspNetCore.Http.PathString
    
        
        .. code-block:: csharp
    
            protected PathString OriginalPathBase
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.AuthenticationHandler<TOptions>.PriorHandler
    
        
        :rtype: Microsoft.AspNetCore.Http.Features.Authentication.IAuthenticationHandler
    
        
        .. code-block:: csharp
    
            public IAuthenticationHandler PriorHandler
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.AuthenticationHandler<TOptions>.Request
    
        
        :rtype: Microsoft.AspNetCore.Http.HttpRequest
    
        
        .. code-block:: csharp
    
            protected HttpRequest Request
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.AuthenticationHandler<TOptions>.Response
    
        
        :rtype: Microsoft.AspNetCore.Http.HttpResponse
    
        
        .. code-block:: csharp
    
            protected HttpResponse Response
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.AuthenticationHandler<TOptions>.SignInAccepted
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected bool SignInAccepted
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.AuthenticationHandler<TOptions>.SignOutAccepted
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected bool SignOutAccepted
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.AuthenticationHandler<TOptions>.UrlEncoder
    
        
        :rtype: System.Text.Encodings.Web.UrlEncoder
    
        
        .. code-block:: csharp
    
            protected UrlEncoder UrlEncoder
            {
                get;
            }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authentication.AuthenticationHandler<TOptions>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authentication.AuthenticationHandler<TOptions>.AuthenticateAsync(Microsoft.AspNetCore.Http.Features.Authentication.AuthenticateContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.Features.Authentication.AuthenticateContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task AuthenticateAsync(AuthenticateContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.AuthenticationHandler<TOptions>.BuildRedirectUri(System.String)
    
        
    
        
        :type targetPath: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            protected string BuildRedirectUri(string targetPath)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.AuthenticationHandler<TOptions>.ChallengeAsync(Microsoft.AspNetCore.Http.Features.Authentication.ChallengeContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.Features.Authentication.ChallengeContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task ChallengeAsync(ChallengeContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.AuthenticationHandler<TOptions>.FinishResponseAsync()
    
        
    
        
        Hook that is called when the response about to be sent
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            protected virtual Task FinishResponseAsync()
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.AuthenticationHandler<TOptions>.GetDescriptions(Microsoft.AspNetCore.Http.Features.Authentication.DescribeSchemesContext)
    
        
    
        
        :type describeContext: Microsoft.AspNetCore.Http.Features.Authentication.DescribeSchemesContext
    
        
        .. code-block:: csharp
    
            public void GetDescriptions(DescribeSchemesContext describeContext)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.AuthenticationHandler<TOptions>.HandleAuthenticateAsync()
    
        
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Authentication.AuthenticateResult<Microsoft.AspNetCore.Authentication.AuthenticateResult>}
    
        
        .. code-block:: csharp
    
            protected abstract Task<AuthenticateResult> HandleAuthenticateAsync()
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.AuthenticationHandler<TOptions>.HandleAuthenticateOnceAsync()
    
        
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Authentication.AuthenticateResult<Microsoft.AspNetCore.Authentication.AuthenticateResult>}
    
        
        .. code-block:: csharp
    
            protected Task<AuthenticateResult> HandleAuthenticateOnceAsync()
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.AuthenticationHandler<TOptions>.HandleForbiddenAsync(Microsoft.AspNetCore.Http.Features.Authentication.ChallengeContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.Features.Authentication.ChallengeContext
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
    
        
        .. code-block:: csharp
    
            protected virtual Task<bool> HandleForbiddenAsync(ChallengeContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.AuthenticationHandler<TOptions>.HandleRequestAsync()
    
        
    
        
        Called once by common code after initialization. If an authentication middleware responds directly to
        specifically known paths it must override this virtual, compare the request path to it's known paths,
        provide any response information as appropriate, and true to stop further processing.
    
        
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: Returning false will cause the common code to call the next middleware in line. Returning true will
            cause the common code to begin the async completion journey without calling the rest of the middleware
            pipeline.
    
        
        .. code-block:: csharp
    
            public virtual Task<bool> HandleRequestAsync()
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.AuthenticationHandler<TOptions>.HandleSignInAsync(Microsoft.AspNetCore.Http.Features.Authentication.SignInContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.Features.Authentication.SignInContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            protected virtual Task HandleSignInAsync(SignInContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.AuthenticationHandler<TOptions>.HandleSignOutAsync(Microsoft.AspNetCore.Http.Features.Authentication.SignOutContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.Features.Authentication.SignOutContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            protected virtual Task HandleSignOutAsync(SignOutContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.AuthenticationHandler<TOptions>.HandleUnauthorizedAsync(Microsoft.AspNetCore.Http.Features.Authentication.ChallengeContext)
    
        
    
        
        Override this method to deal with 401 challenge concerns, if an authentication scheme in question
        deals an authentication interaction as part of it's request flow. (like adding a response header, or
        changing the 401 result to 302 of a login page or external sign-in location.)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.Features.Authentication.ChallengeContext
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: True if no other handlers should be called
    
        
        .. code-block:: csharp
    
            protected virtual Task<bool> HandleUnauthorizedAsync(ChallengeContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.AuthenticationHandler<TOptions>.InitializeAsync(TOptions, Microsoft.AspNetCore.Http.HttpContext, Microsoft.Extensions.Logging.ILogger, System.Text.Encodings.Web.UrlEncoder)
    
        
    
        
        Initialize is called once per request to contextualize this instance with appropriate state.
    
        
    
        
        :param options: The original options passed by the application control behavior
        
        :type options: TOptions
    
        
        :param context: The utility object to observe the current request and response
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :param logger: The logging factory used to create loggers
        
        :type logger: Microsoft.Extensions.Logging.ILogger
    
        
        :param encoder: The :dn:prop:`Microsoft.AspNetCore.Authentication.AuthenticationHandler\`1.UrlEncoder`\.
        
        :type encoder: System.Text.Encodings.Web.UrlEncoder
        :rtype: System.Threading.Tasks.Task
        :return: async completion
    
        
        .. code-block:: csharp
    
            public Task InitializeAsync(TOptions options, HttpContext context, ILogger logger, UrlEncoder encoder)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.AuthenticationHandler<TOptions>.ShouldHandleScheme(System.String, System.Boolean)
    
        
    
        
        :type authenticationScheme: System.String
    
        
        :type handleAutomatic: System.Boolean
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool ShouldHandleScheme(string authenticationScheme, bool handleAutomatic)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.AuthenticationHandler<TOptions>.SignInAsync(Microsoft.AspNetCore.Http.Features.Authentication.SignInContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.Features.Authentication.SignInContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task SignInAsync(SignInContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.AuthenticationHandler<TOptions>.SignOutAsync(Microsoft.AspNetCore.Http.Features.Authentication.SignOutContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.Features.Authentication.SignOutContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task SignOutAsync(SignOutContext context)
    

