

IAntiforgeryTokenGenerator Interface
====================================






Generates and validates antiforgery tokens.


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

    public interface IAntiforgeryTokenGenerator








.. dn:interface:: Microsoft.AspNetCore.Antiforgery.Internal.IAntiforgeryTokenGenerator
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Antiforgery.Internal.IAntiforgeryTokenGenerator

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Antiforgery.Internal.IAntiforgeryTokenGenerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Antiforgery.Internal.IAntiforgeryTokenGenerator.GenerateCookieToken()
    
        
    
        
        Generates a new random cookie token.
    
        
        :rtype: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryToken
        :return: An :any:`Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryToken`\.
    
        
        .. code-block:: csharp
    
            AntiforgeryToken GenerateCookieToken()
    
    .. dn:method:: Microsoft.AspNetCore.Antiforgery.Internal.IAntiforgeryTokenGenerator.GenerateRequestToken(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryToken)
    
        
    
        
        Generates a request token corresponding to <em>cookieToken</em>.
    
        
    
        
        :param httpContext: The :any:`Microsoft.AspNetCore.Http.HttpContext` associated with the current request.
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
    
        
        :param cookieToken: A valid cookie token.
        
        :type cookieToken: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryToken
        :rtype: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryToken
        :return: An :any:`Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryToken`\.
    
        
        .. code-block:: csharp
    
            AntiforgeryToken GenerateRequestToken(HttpContext httpContext, AntiforgeryToken cookieToken)
    
    .. dn:method:: Microsoft.AspNetCore.Antiforgery.Internal.IAntiforgeryTokenGenerator.IsCookieTokenValid(Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryToken)
    
        
    
        
        Attempts to validate a cookie token.
    
        
    
        
        :param cookieToken: A valid cookie token.
        
        :type cookieToken: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryToken
        :rtype: System.Boolean
        :return: <code>true</code> if the cookie token is valid, otherwise <code>false</code>.
    
        
        .. code-block:: csharp
    
            bool IsCookieTokenValid(AntiforgeryToken cookieToken)
    
    .. dn:method:: Microsoft.AspNetCore.Antiforgery.Internal.IAntiforgeryTokenGenerator.TryValidateTokenSet(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryToken, Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryToken, out System.String)
    
        
    
        
        Attempts to validate a cookie and request token set for the given <em>httpContext</em>.
    
        
    
        
        :param httpContext: The :any:`Microsoft.AspNetCore.Http.HttpContext` associated with the current request.
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
    
        
        :param cookieToken: A cookie token.
        
        :type cookieToken: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryToken
    
        
        :param requestToken: A request token.
        
        :type requestToken: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryToken
    
        
        :param message: 
            Will be set to the validation message if the tokens are invalid, otherwise <code>null</code>.
        
        :type message: System.String
        :rtype: System.Boolean
        :return: <code>true</code> if the tokens are valid, otherwise <code>false</code>.
    
        
        .. code-block:: csharp
    
            bool TryValidateTokenSet(HttpContext httpContext, AntiforgeryToken cookieToken, AntiforgeryToken requestToken, out string message)
    

