

DefaultAntiforgeryTokenGenerator Class
======================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Antiforgery.DefaultAntiforgeryTokenGenerator`








Syntax
------

.. code-block:: csharp

   public class DefaultAntiforgeryTokenGenerator : IAntiforgeryTokenGenerator





GitHub
------

`View on GitHub <https://github.com/aspnet/antiforgery/blob/master/src/Microsoft.AspNet.Antiforgery/DefaultAntiforgeryTokenGenerator.cs>`_





.. dn:class:: Microsoft.AspNet.Antiforgery.DefaultAntiforgeryTokenGenerator

Constructors
------------

.. dn:class:: Microsoft.AspNet.Antiforgery.DefaultAntiforgeryTokenGenerator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Antiforgery.DefaultAntiforgeryTokenGenerator.DefaultAntiforgeryTokenGenerator(Microsoft.AspNet.Antiforgery.IClaimUidExtractor, Microsoft.AspNet.Antiforgery.IAntiforgeryAdditionalDataProvider)
    
        
        
        
        :type claimUidExtractor: Microsoft.AspNet.Antiforgery.IClaimUidExtractor
        
        
        :type additionalDataProvider: Microsoft.AspNet.Antiforgery.IAntiforgeryAdditionalDataProvider
    
        
        .. code-block:: csharp
    
           public DefaultAntiforgeryTokenGenerator(IClaimUidExtractor claimUidExtractor, IAntiforgeryAdditionalDataProvider additionalDataProvider)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Antiforgery.DefaultAntiforgeryTokenGenerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Antiforgery.DefaultAntiforgeryTokenGenerator.GenerateCookieToken()
    
        
        :rtype: Microsoft.AspNet.Antiforgery.AntiforgeryToken
    
        
        .. code-block:: csharp
    
           public AntiforgeryToken GenerateCookieToken()
    
    .. dn:method:: Microsoft.AspNet.Antiforgery.DefaultAntiforgeryTokenGenerator.GenerateFormToken(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Antiforgery.AntiforgeryToken)
    
        
        
        
        :type httpContext: Microsoft.AspNet.Http.HttpContext
        
        
        :type cookieToken: Microsoft.AspNet.Antiforgery.AntiforgeryToken
        :rtype: Microsoft.AspNet.Antiforgery.AntiforgeryToken
    
        
        .. code-block:: csharp
    
           public AntiforgeryToken GenerateFormToken(HttpContext httpContext, AntiforgeryToken cookieToken)
    
    .. dn:method:: Microsoft.AspNet.Antiforgery.DefaultAntiforgeryTokenGenerator.IsCookieTokenValid(Microsoft.AspNet.Antiforgery.AntiforgeryToken)
    
        
        
        
        :type cookieToken: Microsoft.AspNet.Antiforgery.AntiforgeryToken
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsCookieTokenValid(AntiforgeryToken cookieToken)
    
    .. dn:method:: Microsoft.AspNet.Antiforgery.DefaultAntiforgeryTokenGenerator.ValidateTokens(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Antiforgery.AntiforgeryToken, Microsoft.AspNet.Antiforgery.AntiforgeryToken)
    
        
        
        
        :type httpContext: Microsoft.AspNet.Http.HttpContext
        
        
        :type sessionToken: Microsoft.AspNet.Antiforgery.AntiforgeryToken
        
        
        :type fieldToken: Microsoft.AspNet.Antiforgery.AntiforgeryToken
    
        
        .. code-block:: csharp
    
           public void ValidateTokens(HttpContext httpContext, AntiforgeryToken sessionToken, AntiforgeryToken fieldToken)
    

