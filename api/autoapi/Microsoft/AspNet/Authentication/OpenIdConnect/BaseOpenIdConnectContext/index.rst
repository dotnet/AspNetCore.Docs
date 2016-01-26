

BaseOpenIdConnectContext Class
==============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.BaseContext`
* :dn:cls:`Microsoft.AspNet.Authentication.BaseControlContext`
* :dn:cls:`Microsoft.AspNet.Authentication.OpenIdConnect.BaseOpenIdConnectContext`








Syntax
------

.. code-block:: csharp

   public class BaseOpenIdConnectContext : BaseControlContext





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication.OpenIdConnect/Events/BaseOpenIdConnectContext.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.OpenIdConnect.BaseOpenIdConnectContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.OpenIdConnect.BaseOpenIdConnectContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.OpenIdConnect.BaseOpenIdConnectContext.BaseOpenIdConnectContext(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions)
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :type options: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions
    
        
        .. code-block:: csharp
    
           public BaseOpenIdConnectContext(HttpContext context, OpenIdConnectOptions options)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.OpenIdConnect.BaseOpenIdConnectContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.OpenIdConnect.BaseOpenIdConnectContext.Options
    
        
        :rtype: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions
    
        
        .. code-block:: csharp
    
           public OpenIdConnectOptions Options { get; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OpenIdConnect.BaseOpenIdConnectContext.ProtocolMessage
    
        
        :rtype: Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectMessage
    
        
        .. code-block:: csharp
    
           public OpenIdConnectMessage ProtocolMessage { get; set; }
    

