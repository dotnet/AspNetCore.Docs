

AntiforgeryOptions Class
========================



.. contents:: 
   :local:



Summary
-------

Provides programmatic configuration for the antiforgery token system.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Antiforgery.AntiforgeryOptions`








Syntax
------

.. code-block:: csharp

   public class AntiforgeryOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/antiforgery/blob/master/src/Microsoft.AspNet.Antiforgery/AntiforgeryOptions.cs>`_





.. dn:class:: Microsoft.AspNet.Antiforgery.AntiforgeryOptions

Properties
----------

.. dn:class:: Microsoft.AspNet.Antiforgery.AntiforgeryOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Antiforgery.AntiforgeryOptions.CookieName
    
        
    
        Specifies the name of the cookie that is used by the antiforgery
        system.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string CookieName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Antiforgery.AntiforgeryOptions.FormFieldName
    
        
    
        Specifies the name of the antiforgery token field that is used by the antiforgery system.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string FormFieldName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Antiforgery.AntiforgeryOptions.RequireSsl
    
        
    
        Specifies whether SSL is required for the antiforgery system
        to operate. If this setting is 'true' and a non-SSL request
        comes into the system, all antiforgery APIs will fail.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool RequireSsl { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Antiforgery.AntiforgeryOptions.SuppressXFrameOptionsHeader
    
        
    
        Specifies whether to suppress the generation of X-Frame-Options header
        which is used to prevent ClickJacking. By default, the X-Frame-Options
        header is generated with the value SAMEORIGIN. If this setting is 'true',
        the X-Frame-Options header will not be generated for the response.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool SuppressXFrameOptionsHeader { get; set; }
    

