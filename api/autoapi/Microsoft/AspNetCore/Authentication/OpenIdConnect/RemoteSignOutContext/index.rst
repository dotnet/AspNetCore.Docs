

RemoteSignOutContext Class
==========================





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
* :dn:cls:`Microsoft.AspNetCore.Authentication.OpenIdConnect.RemoteSignOutContext`








Syntax
------

.. code-block:: csharp

    public class RemoteSignOutContext : BaseOpenIdConnectContext








.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.RemoteSignOutContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.RemoteSignOutContext

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.RemoteSignOutContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authentication.OpenIdConnect.RemoteSignOutContext.RemoteSignOutContext(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Builder.OpenIdConnectOptions, Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectMessage)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type options: Microsoft.AspNetCore.Builder.OpenIdConnectOptions
    
        
        :type message: Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectMessage
    
        
        .. code-block:: csharp
    
            public RemoteSignOutContext(HttpContext context, OpenIdConnectOptions options, OpenIdConnectMessage message)
    

