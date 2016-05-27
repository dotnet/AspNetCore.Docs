

DefaultAntiforgeryTokenStore Class
==================================





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
* :dn:cls:`Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgeryTokenStore`








Syntax
------

.. code-block:: csharp

    public class DefaultAntiforgeryTokenStore : IAntiforgeryTokenStore








.. dn:class:: Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgeryTokenStore
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgeryTokenStore

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgeryTokenStore
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgeryTokenStore.DefaultAntiforgeryTokenStore(Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions>)
    
        
    
        
        :type optionsAccessor: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions<Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions>}
    
        
        .. code-block:: csharp
    
            public DefaultAntiforgeryTokenStore(IOptions<AntiforgeryOptions> optionsAccessor)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgeryTokenStore
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgeryTokenStore.GetCookieToken(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string GetCookieToken(HttpContext httpContext)
    
    .. dn:method:: Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgeryTokenStore.GetRequestTokensAsync(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Antiforgery.AntiforgeryTokenSet<Microsoft.AspNetCore.Antiforgery.AntiforgeryTokenSet>}
    
        
        .. code-block:: csharp
    
            public Task<AntiforgeryTokenSet> GetRequestTokensAsync(HttpContext httpContext)
    
    .. dn:method:: Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgeryTokenStore.SaveCookieToken(Microsoft.AspNetCore.Http.HttpContext, System.String)
    
        
    
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type token: System.String
    
        
        .. code-block:: csharp
    
            public void SaveCookieToken(HttpContext httpContext, string token)
    

