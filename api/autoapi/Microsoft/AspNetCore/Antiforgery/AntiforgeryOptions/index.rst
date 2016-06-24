

AntiforgeryOptions Class
========================






Provides programmatic configuration for the antiforgery token system.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Antiforgery`
Assemblies
    * Microsoft.AspNetCore.Antiforgery

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions`








Syntax
------

.. code-block:: csharp

    public class AntiforgeryOptions








.. dn:class:: Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions.CookieName
    
        
    
        
        Specifies the name of the cookie that is used by the antiforgery system.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string CookieName { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions.FormFieldName
    
        
    
        
        Specifies the name of the antiforgery token field that is used by the antiforgery system.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string FormFieldName { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions.HeaderName
    
        
    
        
        Specifies the name of the header value that is used by the antiforgery system. If <code>null</code> then
        antiforgery validation will only consider form data.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string HeaderName { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions.RequireSsl
    
        
    
        
        Specifies whether SSL is required for the antiforgery system
        to operate. If this setting is 'true' and a non-SSL request
        comes into the system, all antiforgery APIs will fail.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool RequireSsl { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions.SuppressXFrameOptionsHeader
    
        
    
        
        Specifies whether to suppress the generation of X-Frame-Options header
        which is used to prevent ClickJacking. By default, the X-Frame-Options
        header is generated with the value SAMEORIGIN. If this setting is 'true',
        the X-Frame-Options header will not be generated for the response.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool SuppressXFrameOptionsHeader { get; set; }
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions.DefaultCookiePrefix
    
        
    
        
        The default cookie prefix, which is ".AspNetCore.Antiforgery.".
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static readonly string DefaultCookiePrefix
    

