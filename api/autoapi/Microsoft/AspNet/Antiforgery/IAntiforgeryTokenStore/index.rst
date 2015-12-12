

IAntiforgeryTokenStore Interface
================================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IAntiforgeryTokenStore





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/antiforgery/src/Microsoft.AspNet.Antiforgery/IAntiforgeryTokenStore.cs>`_





.. dn:interface:: Microsoft.AspNet.Antiforgery.IAntiforgeryTokenStore

Methods
-------

.. dn:interface:: Microsoft.AspNet.Antiforgery.IAntiforgeryTokenStore
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Antiforgery.IAntiforgeryTokenStore.GetCookieToken(Microsoft.AspNet.Http.HttpContext)
    
        
        
        
        :type httpContext: Microsoft.AspNet.Http.HttpContext
        :rtype: Microsoft.AspNet.Antiforgery.AntiforgeryToken
    
        
        .. code-block:: csharp
    
           AntiforgeryToken GetCookieToken(HttpContext httpContext)
    
    .. dn:method:: Microsoft.AspNet.Antiforgery.IAntiforgeryTokenStore.GetRequestTokensAsync(Microsoft.AspNet.Http.HttpContext)
    
        
    
        Gets the cookie and form tokens from the request. Will throw an exception if either token is
        not present.
    
        
        
        
        :param httpContext: The  for the current request.
        
        :type httpContext: Microsoft.AspNet.Http.HttpContext
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Antiforgery.AntiforgeryTokenSet}
        :return: The <see cref="T:Microsoft.AspNet.Antiforgery.AntiforgeryTokenSet" />.
    
        
        .. code-block:: csharp
    
           Task<AntiforgeryTokenSet> GetRequestTokensAsync(HttpContext httpContext)
    
    .. dn:method:: Microsoft.AspNet.Antiforgery.IAntiforgeryTokenStore.SaveCookieToken(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Antiforgery.AntiforgeryToken)
    
        
        
        
        :type httpContext: Microsoft.AspNet.Http.HttpContext
        
        
        :type token: Microsoft.AspNet.Antiforgery.AntiforgeryToken
    
        
        .. code-block:: csharp
    
           void SaveCookieToken(HttpContext httpContext, AntiforgeryToken token)
    

