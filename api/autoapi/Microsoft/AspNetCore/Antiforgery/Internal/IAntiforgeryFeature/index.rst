

IAntiforgeryFeature Interface
=============================





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

    public interface IAntiforgeryFeature








.. dn:interface:: Microsoft.AspNetCore.Antiforgery.Internal.IAntiforgeryFeature
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Antiforgery.Internal.IAntiforgeryFeature

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Antiforgery.Internal.IAntiforgeryFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Antiforgery.Internal.IAntiforgeryFeature.CookieToken
    
        
        :rtype: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryToken
    
        
        .. code-block:: csharp
    
            AntiforgeryToken CookieToken { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Antiforgery.Internal.IAntiforgeryFeature.HaveDeserializedCookieToken
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            bool HaveDeserializedCookieToken { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Antiforgery.Internal.IAntiforgeryFeature.HaveDeserializedRequestToken
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            bool HaveDeserializedRequestToken { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Antiforgery.Internal.IAntiforgeryFeature.HaveGeneratedNewCookieToken
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            bool HaveGeneratedNewCookieToken { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Antiforgery.Internal.IAntiforgeryFeature.HaveStoredNewCookieToken
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            bool HaveStoredNewCookieToken { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Antiforgery.Internal.IAntiforgeryFeature.NewCookieToken
    
        
        :rtype: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryToken
    
        
        .. code-block:: csharp
    
            AntiforgeryToken NewCookieToken { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Antiforgery.Internal.IAntiforgeryFeature.NewCookieTokenString
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string NewCookieTokenString { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Antiforgery.Internal.IAntiforgeryFeature.NewRequestToken
    
        
        :rtype: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryToken
    
        
        .. code-block:: csharp
    
            AntiforgeryToken NewRequestToken { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Antiforgery.Internal.IAntiforgeryFeature.NewRequestTokenString
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string NewRequestTokenString { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Antiforgery.Internal.IAntiforgeryFeature.RequestToken
    
        
        :rtype: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryToken
    
        
        .. code-block:: csharp
    
            AntiforgeryToken RequestToken { get; set; }
    

