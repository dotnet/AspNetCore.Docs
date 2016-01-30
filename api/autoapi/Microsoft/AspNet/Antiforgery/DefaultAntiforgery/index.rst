

DefaultAntiforgery Class
========================



.. contents:: 
   :local:



Summary
-------

Provides access to the antiforgery system, which provides protection against
Cross-site Request Forgery (XSRF, also called CSRF) attacks.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Antiforgery.DefaultAntiforgery`








Syntax
------

.. code-block:: csharp

   public class DefaultAntiforgery : IAntiforgery





GitHub
------

`View on GitHub <https://github.com/aspnet/antiforgery/blob/master/src/Microsoft.AspNet.Antiforgery/DefaultAntiforgery.cs>`_





.. dn:class:: Microsoft.AspNet.Antiforgery.DefaultAntiforgery

Constructors
------------

.. dn:class:: Microsoft.AspNet.Antiforgery.DefaultAntiforgery
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Antiforgery.DefaultAntiforgery.DefaultAntiforgery(Microsoft.Extensions.OptionsModel.IOptions<Microsoft.AspNet.Antiforgery.AntiforgeryOptions>, Microsoft.AspNet.Antiforgery.IAntiforgeryTokenGenerator, Microsoft.AspNet.Antiforgery.IAntiforgeryTokenSerializer, Microsoft.AspNet.Antiforgery.IAntiforgeryTokenStore, Microsoft.Extensions.WebEncoders.IHtmlEncoder)
    
        
        
        
        :type antiforgeryOptionsAccessor: Microsoft.Extensions.OptionsModel.IOptions{Microsoft.AspNet.Antiforgery.AntiforgeryOptions}
        
        
        :type tokenGenerator: Microsoft.AspNet.Antiforgery.IAntiforgeryTokenGenerator
        
        
        :type tokenSerializer: Microsoft.AspNet.Antiforgery.IAntiforgeryTokenSerializer
        
        
        :type tokenStore: Microsoft.AspNet.Antiforgery.IAntiforgeryTokenStore
        
        
        :type htmlEncoder: Microsoft.Extensions.WebEncoders.IHtmlEncoder
    
        
        .. code-block:: csharp
    
           public DefaultAntiforgery(IOptions<AntiforgeryOptions> antiforgeryOptionsAccessor, IAntiforgeryTokenGenerator tokenGenerator, IAntiforgeryTokenSerializer tokenSerializer, IAntiforgeryTokenStore tokenStore, IHtmlEncoder htmlEncoder)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Antiforgery.DefaultAntiforgery
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Antiforgery.DefaultAntiforgery.GetAndStoreTokens(Microsoft.AspNet.Http.HttpContext)
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        :rtype: Microsoft.AspNet.Antiforgery.AntiforgeryTokenSet
    
        
        .. code-block:: csharp
    
           public AntiforgeryTokenSet GetAndStoreTokens(HttpContext context)
    
    .. dn:method:: Microsoft.AspNet.Antiforgery.DefaultAntiforgery.GetHtml(Microsoft.AspNet.Http.HttpContext)
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string GetHtml(HttpContext context)
    
    .. dn:method:: Microsoft.AspNet.Antiforgery.DefaultAntiforgery.GetTokens(Microsoft.AspNet.Http.HttpContext)
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        :rtype: Microsoft.AspNet.Antiforgery.AntiforgeryTokenSet
    
        
        .. code-block:: csharp
    
           public AntiforgeryTokenSet GetTokens(HttpContext context)
    
    .. dn:method:: Microsoft.AspNet.Antiforgery.DefaultAntiforgery.SetCookieTokenAndHeader(Microsoft.AspNet.Http.HttpContext)
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
    
        
        .. code-block:: csharp
    
           public void SetCookieTokenAndHeader(HttpContext context)
    
    .. dn:method:: Microsoft.AspNet.Antiforgery.DefaultAntiforgery.ValidateRequestAsync(Microsoft.AspNet.Http.HttpContext)
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task ValidateRequestAsync(HttpContext context)
    
    .. dn:method:: Microsoft.AspNet.Antiforgery.DefaultAntiforgery.ValidateTokens(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Antiforgery.AntiforgeryTokenSet)
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :type antiforgeryTokenSet: Microsoft.AspNet.Antiforgery.AntiforgeryTokenSet
    
        
        .. code-block:: csharp
    
           public void ValidateTokens(HttpContext context, AntiforgeryTokenSet antiforgeryTokenSet)
    

