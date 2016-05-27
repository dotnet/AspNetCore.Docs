

DefaultAntiforgeryTokenGenerator Class
======================================





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
* :dn:cls:`Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgeryTokenGenerator`








Syntax
------

.. code-block:: csharp

    public class DefaultAntiforgeryTokenGenerator : IAntiforgeryTokenGenerator








.. dn:class:: Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgeryTokenGenerator
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgeryTokenGenerator

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgeryTokenGenerator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgeryTokenGenerator.DefaultAntiforgeryTokenGenerator(Microsoft.AspNetCore.Antiforgery.Internal.IClaimUidExtractor, Microsoft.AspNetCore.Antiforgery.IAntiforgeryAdditionalDataProvider)
    
        
    
        
        :type claimUidExtractor: Microsoft.AspNetCore.Antiforgery.Internal.IClaimUidExtractor
    
        
        :type additionalDataProvider: Microsoft.AspNetCore.Antiforgery.IAntiforgeryAdditionalDataProvider
    
        
        .. code-block:: csharp
    
            public DefaultAntiforgeryTokenGenerator(IClaimUidExtractor claimUidExtractor, IAntiforgeryAdditionalDataProvider additionalDataProvider)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgeryTokenGenerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgeryTokenGenerator.GenerateCookieToken()
    
        
        :rtype: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryToken
    
        
        .. code-block:: csharp
    
            public AntiforgeryToken GenerateCookieToken()
    
    .. dn:method:: Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgeryTokenGenerator.GenerateRequestToken(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryToken)
    
        
    
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type cookieToken: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryToken
        :rtype: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryToken
    
        
        .. code-block:: csharp
    
            public AntiforgeryToken GenerateRequestToken(HttpContext httpContext, AntiforgeryToken cookieToken)
    
    .. dn:method:: Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgeryTokenGenerator.IsCookieTokenValid(Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryToken)
    
        
    
        
        :type cookieToken: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryToken
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsCookieTokenValid(AntiforgeryToken cookieToken)
    
    .. dn:method:: Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgeryTokenGenerator.TryValidateTokenSet(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryToken, Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryToken, out System.String)
    
        
    
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type cookieToken: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryToken
    
        
        :type requestToken: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryToken
    
        
        :type message: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool TryValidateTokenSet(HttpContext httpContext, AntiforgeryToken cookieToken, AntiforgeryToken requestToken, out string message)
    

