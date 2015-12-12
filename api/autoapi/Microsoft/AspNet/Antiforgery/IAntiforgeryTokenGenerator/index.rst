

IAntiforgeryTokenGenerator Interface
====================================



.. contents:: 
   :local:



Summary
-------

Generates and validates antiforgery tokens.











Syntax
------

.. code-block:: csharp

   public interface IAntiforgeryTokenGenerator





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/antiforgery/src/Microsoft.AspNet.Antiforgery/IAntiforgeryTokenGenerator.cs>`_





.. dn:interface:: Microsoft.AspNet.Antiforgery.IAntiforgeryTokenGenerator

Methods
-------

.. dn:interface:: Microsoft.AspNet.Antiforgery.IAntiforgeryTokenGenerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Antiforgery.IAntiforgeryTokenGenerator.GenerateCookieToken()
    
        
        :rtype: Microsoft.AspNet.Antiforgery.AntiforgeryToken
    
        
        .. code-block:: csharp
    
           AntiforgeryToken GenerateCookieToken()
    
    .. dn:method:: Microsoft.AspNet.Antiforgery.IAntiforgeryTokenGenerator.GenerateFormToken(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Antiforgery.AntiforgeryToken)
    
        
        
        
        :type httpContext: Microsoft.AspNet.Http.HttpContext
        
        
        :type cookieToken: Microsoft.AspNet.Antiforgery.AntiforgeryToken
        :rtype: Microsoft.AspNet.Antiforgery.AntiforgeryToken
    
        
        .. code-block:: csharp
    
           AntiforgeryToken GenerateFormToken(HttpContext httpContext, AntiforgeryToken cookieToken)
    
    .. dn:method:: Microsoft.AspNet.Antiforgery.IAntiforgeryTokenGenerator.IsCookieTokenValid(Microsoft.AspNet.Antiforgery.AntiforgeryToken)
    
        
        
        
        :type cookieToken: Microsoft.AspNet.Antiforgery.AntiforgeryToken
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool IsCookieTokenValid(AntiforgeryToken cookieToken)
    
    .. dn:method:: Microsoft.AspNet.Antiforgery.IAntiforgeryTokenGenerator.ValidateTokens(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Antiforgery.AntiforgeryToken, Microsoft.AspNet.Antiforgery.AntiforgeryToken)
    
        
        
        
        :type httpContext: Microsoft.AspNet.Http.HttpContext
        
        
        :type cookieToken: Microsoft.AspNet.Antiforgery.AntiforgeryToken
        
        
        :type formToken: Microsoft.AspNet.Antiforgery.AntiforgeryToken
    
        
        .. code-block:: csharp
    
           void ValidateTokens(HttpContext httpContext, AntiforgeryToken cookieToken, AntiforgeryToken formToken)
    

