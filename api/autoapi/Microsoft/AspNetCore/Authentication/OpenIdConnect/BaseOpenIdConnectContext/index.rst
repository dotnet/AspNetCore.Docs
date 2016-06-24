

BaseOpenIdConnectContext Class
==============================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication.OpenIdConnect`
Assemblies
    * Microsoft.AspNetCore.Authentication.OpenIdConnect

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authentication.BaseContext`
* :dn:cls:`Microsoft.AspNetCore.Authentication.BaseControlContext`
* :dn:cls:`Microsoft.AspNetCore.Authentication.OpenIdConnect.BaseOpenIdConnectContext`








Syntax
------

.. code-block:: csharp

    public class BaseOpenIdConnectContext : BaseControlContext








.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.BaseOpenIdConnectContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.BaseOpenIdConnectContext

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.BaseOpenIdConnectContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authentication.OpenIdConnect.BaseOpenIdConnectContext.BaseOpenIdConnectContext(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Builder.OpenIdConnectOptions)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type options: Microsoft.AspNetCore.Builder.OpenIdConnectOptions
    
        
        .. code-block:: csharp
    
            public BaseOpenIdConnectContext(HttpContext context, OpenIdConnectOptions options)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.BaseOpenIdConnectContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OpenIdConnect.BaseOpenIdConnectContext.Options
    
        
        :rtype: Microsoft.AspNetCore.Builder.OpenIdConnectOptions
    
        
        .. code-block:: csharp
    
            public OpenIdConnectOptions Options { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OpenIdConnect.BaseOpenIdConnectContext.ProtocolMessage
    
        
        :rtype: Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectMessage
    
        
        .. code-block:: csharp
    
            public OpenIdConnectMessage ProtocolMessage { get; set; }
    

