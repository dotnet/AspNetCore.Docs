

IAntiforgeryTokenStore Interface
================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Antiforgery.Internal`
Assemblies
    * Microsoft.AspNetCore.Antiforgery

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IAntiforgeryTokenStore








.. dn:interface:: Microsoft.AspNetCore.Antiforgery.Internal.IAntiforgeryTokenStore
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Antiforgery.Internal.IAntiforgeryTokenStore

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Antiforgery.Internal.IAntiforgeryTokenStore
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Antiforgery.Internal.IAntiforgeryTokenStore.GetCookieToken(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string GetCookieToken(HttpContext httpContext)
    
    .. dn:method:: Microsoft.AspNetCore.Antiforgery.Internal.IAntiforgeryTokenStore.GetRequestTokensAsync(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        Gets the cookie and request tokens from the request.
    
        
    
        
        :param httpContext: The :any:`Microsoft.AspNetCore.Http.HttpContext` for the current request.
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Antiforgery.AntiforgeryTokenSet<Microsoft.AspNetCore.Antiforgery.AntiforgeryTokenSet>}
        :return: The :any:`Microsoft.AspNetCore.Antiforgery.AntiforgeryTokenSet`\.
    
        
        .. code-block:: csharp
    
            Task<AntiforgeryTokenSet> GetRequestTokensAsync(HttpContext httpContext)
    
    .. dn:method:: Microsoft.AspNetCore.Antiforgery.Internal.IAntiforgeryTokenStore.SaveCookieToken(Microsoft.AspNetCore.Http.HttpContext, System.String)
    
        
    
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type token: System.String
    
        
        .. code-block:: csharp
    
            void SaveCookieToken(HttpContext httpContext, string token)
    

