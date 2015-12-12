

DefaultAntiforgeryTokenStore Class
==================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Antiforgery.DefaultAntiforgeryTokenStore`








Syntax
------

.. code-block:: csharp

   public class DefaultAntiforgeryTokenStore : IAntiforgeryTokenStore





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/antiforgery/src/Microsoft.AspNet.Antiforgery/DefaultAntiforgeryTokenStore.cs>`_





.. dn:class:: Microsoft.AspNet.Antiforgery.DefaultAntiforgeryTokenStore

Constructors
------------

.. dn:class:: Microsoft.AspNet.Antiforgery.DefaultAntiforgeryTokenStore
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Antiforgery.DefaultAntiforgeryTokenStore.DefaultAntiforgeryTokenStore(Microsoft.Extensions.OptionsModel.IOptions<Microsoft.AspNet.Antiforgery.AntiforgeryOptions>, Microsoft.AspNet.Antiforgery.IAntiforgeryTokenSerializer)
    
        
        
        
        :type optionsAccessor: Microsoft.Extensions.OptionsModel.IOptions{Microsoft.AspNet.Antiforgery.AntiforgeryOptions}
        
        
        :type tokenSerializer: Microsoft.AspNet.Antiforgery.IAntiforgeryTokenSerializer
    
        
        .. code-block:: csharp
    
           public DefaultAntiforgeryTokenStore(IOptions<AntiforgeryOptions> optionsAccessor, IAntiforgeryTokenSerializer tokenSerializer)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Antiforgery.DefaultAntiforgeryTokenStore
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Antiforgery.DefaultAntiforgeryTokenStore.GetCookieToken(Microsoft.AspNet.Http.HttpContext)
    
        
        
        
        :type httpContext: Microsoft.AspNet.Http.HttpContext
        :rtype: Microsoft.AspNet.Antiforgery.AntiforgeryToken
    
        
        .. code-block:: csharp
    
           public AntiforgeryToken GetCookieToken(HttpContext httpContext)
    
    .. dn:method:: Microsoft.AspNet.Antiforgery.DefaultAntiforgeryTokenStore.GetRequestTokensAsync(Microsoft.AspNet.Http.HttpContext)
    
        
        
        
        :type httpContext: Microsoft.AspNet.Http.HttpContext
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Antiforgery.AntiforgeryTokenSet}
    
        
        .. code-block:: csharp
    
           public Task<AntiforgeryTokenSet> GetRequestTokensAsync(HttpContext httpContext)
    
    .. dn:method:: Microsoft.AspNet.Antiforgery.DefaultAntiforgeryTokenStore.SaveCookieToken(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Antiforgery.AntiforgeryToken)
    
        
        
        
        :type httpContext: Microsoft.AspNet.Http.HttpContext
        
        
        :type token: Microsoft.AspNet.Antiforgery.AntiforgeryToken
    
        
        .. code-block:: csharp
    
           public void SaveCookieToken(HttpContext httpContext, AntiforgeryToken token)
    

