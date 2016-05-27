

DefaultAntiforgery Class
========================






Provides access to the antiforgery system, which provides protection against
Cross-site Request Forgery (XSRF, also called CSRF) attacks.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Antiforgery.Internal`
Assemblies
    * Microsoft.AspNetCore.Antiforgery

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgery`








Syntax
------

.. code-block:: csharp

    public class DefaultAntiforgery : IAntiforgery








.. dn:class:: Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgery
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgery

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgery
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgery.DefaultAntiforgery(Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions>, Microsoft.AspNetCore.Antiforgery.Internal.IAntiforgeryTokenGenerator, Microsoft.AspNetCore.Antiforgery.Internal.IAntiforgeryTokenSerializer, Microsoft.AspNetCore.Antiforgery.Internal.IAntiforgeryTokenStore, Microsoft.Extensions.Logging.ILoggerFactory)
    
        
    
        
        :type antiforgeryOptionsAccessor: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions<Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions>}
    
        
        :type tokenGenerator: Microsoft.AspNetCore.Antiforgery.Internal.IAntiforgeryTokenGenerator
    
        
        :type tokenSerializer: Microsoft.AspNetCore.Antiforgery.Internal.IAntiforgeryTokenSerializer
    
        
        :type tokenStore: Microsoft.AspNetCore.Antiforgery.Internal.IAntiforgeryTokenStore
    
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
            public DefaultAntiforgery(IOptions<AntiforgeryOptions> antiforgeryOptionsAccessor, IAntiforgeryTokenGenerator tokenGenerator, IAntiforgeryTokenSerializer tokenSerializer, IAntiforgeryTokenStore tokenStore, ILoggerFactory loggerFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgery
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgery.GetAndStoreTokens(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
        :rtype: Microsoft.AspNetCore.Antiforgery.AntiforgeryTokenSet
    
        
        .. code-block:: csharp
    
            public AntiforgeryTokenSet GetAndStoreTokens(HttpContext httpContext)
    
    .. dn:method:: Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgery.GetTokens(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
        :rtype: Microsoft.AspNetCore.Antiforgery.AntiforgeryTokenSet
    
        
        .. code-block:: csharp
    
            public AntiforgeryTokenSet GetTokens(HttpContext httpContext)
    
    .. dn:method:: Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgery.IsRequestValidAsync(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
    
        
        .. code-block:: csharp
    
            public Task<bool> IsRequestValidAsync(HttpContext httpContext)
    
    .. dn:method:: Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgery.SetCookieTokenAndHeader(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
    
        
        .. code-block:: csharp
    
            public void SetCookieTokenAndHeader(HttpContext httpContext)
    
    .. dn:method:: Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgery.ValidateRequestAsync(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task ValidateRequestAsync(HttpContext httpContext)
    

