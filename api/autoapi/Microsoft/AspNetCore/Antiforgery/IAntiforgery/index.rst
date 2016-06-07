

IAntiforgery Interface
======================






Provides access to the antiforgery system, which provides protection against
Cross-site Request Forgery (XSRF, also called CSRF) attacks.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Antiforgery`
Assemblies
    * Microsoft.AspNetCore.Antiforgery

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IAntiforgery








.. dn:interface:: Microsoft.AspNetCore.Antiforgery.IAntiforgery
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Antiforgery.IAntiforgery

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Antiforgery.IAntiforgery
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Antiforgery.IAntiforgery.GetAndStoreTokens(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        Generates an :any:`Microsoft.AspNetCore.Antiforgery.AntiforgeryTokenSet` for this request and stores the cookie token
        in the response.
    
        
    
        
        :param httpContext: The :any:`Microsoft.AspNetCore.Http.HttpContext` associated with the current request.
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
        :rtype: Microsoft.AspNetCore.Antiforgery.AntiforgeryTokenSet
        :return: An :any:`Microsoft.AspNetCore.Antiforgery.AntiforgeryTokenSet` with tokens for the response.
    
        
        .. code-block:: csharp
    
            AntiforgeryTokenSet GetAndStoreTokens(HttpContext httpContext)
    
    .. dn:method:: Microsoft.AspNetCore.Antiforgery.IAntiforgery.GetTokens(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        Generates an :any:`Microsoft.AspNetCore.Antiforgery.AntiforgeryTokenSet` for this request.
    
        
    
        
        :param httpContext: The :any:`Microsoft.AspNetCore.Http.HttpContext` associated with the current request.
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
        :rtype: Microsoft.AspNetCore.Antiforgery.AntiforgeryTokenSet
    
        
        .. code-block:: csharp
    
            AntiforgeryTokenSet GetTokens(HttpContext httpContext)
    
    .. dn:method:: Microsoft.AspNetCore.Antiforgery.IAntiforgery.IsRequestValidAsync(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        Asynchronously returns a value indicating whether the request passes antiforgery validation. If the
        request uses a safe HTTP method (GET, HEAD, OPTIONS, TRACE), the antiforgery token is not validated.
    
        
    
        
        :param httpContext: The :any:`Microsoft.AspNetCore.Http.HttpContext` associated with the current request.
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: 
            A :any:`System.Threading.Tasks.Task\`1` that, when completed, returns <code>true</code> if the is requst uses a safe HTTP
            method or contains a value antiforgery token, otherwise returns <code>false</code>.
    
        
        .. code-block:: csharp
    
            Task<bool> IsRequestValidAsync(HttpContext httpContext)
    
    .. dn:method:: Microsoft.AspNetCore.Antiforgery.IAntiforgery.SetCookieTokenAndHeader(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        Generates and stores an antiforgery cookie token if one is not available or not valid.
    
        
    
        
        :param httpContext: The :any:`Microsoft.AspNetCore.Http.HttpContext` associated with the current request.
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
    
        
        .. code-block:: csharp
    
            void SetCookieTokenAndHeader(HttpContext httpContext)
    
    .. dn:method:: Microsoft.AspNetCore.Antiforgery.IAntiforgery.ValidateRequestAsync(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        Validates an antiforgery token that was supplied as part of the request.
    
        
    
        
        :param httpContext: The :any:`Microsoft.AspNetCore.Http.HttpContext` associated with the current request.
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            Task ValidateRequestAsync(HttpContext httpContext)
    

