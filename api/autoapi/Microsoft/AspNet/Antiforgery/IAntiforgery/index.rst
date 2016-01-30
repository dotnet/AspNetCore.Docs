

IAntiforgery Interface
======================



.. contents:: 
   :local:



Summary
-------

Provides access to the antiforgery system, which provides protection against
Cross-site Request Forgery (XSRF, also called CSRF) attacks.











Syntax
------

.. code-block:: csharp

   public interface IAntiforgery





GitHub
------

`View on GitHub <https://github.com/aspnet/antiforgery/blob/master/src/Microsoft.AspNet.Antiforgery/IAntiforgery.cs>`_





.. dn:interface:: Microsoft.AspNet.Antiforgery.IAntiforgery

Methods
-------

.. dn:interface:: Microsoft.AspNet.Antiforgery.IAntiforgery
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Antiforgery.IAntiforgery.GetAndStoreTokens(Microsoft.AspNet.Http.HttpContext)
    
        
    
        Generates an :any:`Microsoft.AspNet.Antiforgery.AntiforgeryTokenSet` for this request and stores the cookie token
        in the response.
    
        
        
        
        :param context: The  associated with the current request.
        
        :type context: Microsoft.AspNet.Http.HttpContext
        :rtype: Microsoft.AspNet.Antiforgery.AntiforgeryTokenSet
        :return: An <see cref="T:Microsoft.AspNet.Antiforgery.AntiforgeryTokenSet" /> with tokens for the response.
    
        
        .. code-block:: csharp
    
           AntiforgeryTokenSet GetAndStoreTokens(HttpContext context)
    
    .. dn:method:: Microsoft.AspNet.Antiforgery.IAntiforgery.GetHtml(Microsoft.AspNet.Http.HttpContext)
    
        
    
        Generates an input field for an antiforgery token.
    
        
        
        
        :param context: The  associated with the current request.
        
        :type context: Microsoft.AspNet.Http.HttpContext
        :rtype: System.String
        :return: A string containing an &lt;input type="hidden"&gt; element. This element should be put inside
            a &lt;form&gt;.
    
        
        .. code-block:: csharp
    
           string GetHtml(HttpContext context)
    
    .. dn:method:: Microsoft.AspNet.Antiforgery.IAntiforgery.GetTokens(Microsoft.AspNet.Http.HttpContext)
    
        
    
        Generates an :any:`Microsoft.AspNet.Antiforgery.AntiforgeryTokenSet` for this request.
    
        
        
        
        :param context: The  associated with the current request.
        
        :type context: Microsoft.AspNet.Http.HttpContext
        :rtype: Microsoft.AspNet.Antiforgery.AntiforgeryTokenSet
    
        
        .. code-block:: csharp
    
           AntiforgeryTokenSet GetTokens(HttpContext context)
    
    .. dn:method:: Microsoft.AspNet.Antiforgery.IAntiforgery.SetCookieTokenAndHeader(Microsoft.AspNet.Http.HttpContext)
    
        
    
        Generates and stores an antiforgery cookie token if one is not available or not valid.
    
        
        
        
        :param context: The  associated with the current request.
        
        :type context: Microsoft.AspNet.Http.HttpContext
    
        
        .. code-block:: csharp
    
           void SetCookieTokenAndHeader(HttpContext context)
    
    .. dn:method:: Microsoft.AspNet.Antiforgery.IAntiforgery.ValidateRequestAsync(Microsoft.AspNet.Http.HttpContext)
    
        
    
        Validates an antiforgery token that was supplied as part of the request.
    
        
        
        
        :param context: The  associated with the current request.
        
        :type context: Microsoft.AspNet.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task ValidateRequestAsync(HttpContext context)
    
    .. dn:method:: Microsoft.AspNet.Antiforgery.IAntiforgery.ValidateTokens(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Antiforgery.AntiforgeryTokenSet)
    
        
    
        Validates an :any:`Microsoft.AspNet.Antiforgery.AntiforgeryTokenSet` for the current request.
    
        
        
        
        :param context: The  associated with the current request.
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :param antiforgeryTokenSet: The  (cookie and form token) for this request.
        
        :type antiforgeryTokenSet: Microsoft.AspNet.Antiforgery.AntiforgeryTokenSet
    
        
        .. code-block:: csharp
    
           void ValidateTokens(HttpContext context, AntiforgeryTokenSet antiforgeryTokenSet)
    

