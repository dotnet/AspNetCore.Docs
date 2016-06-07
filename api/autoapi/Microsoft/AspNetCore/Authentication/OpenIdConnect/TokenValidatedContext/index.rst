

TokenValidatedContext Class
===========================





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
* :dn:cls:`Microsoft.AspNetCore.Authentication.OpenIdConnect.TokenValidatedContext`








Syntax
------

.. code-block:: csharp

    public class TokenValidatedContext : BaseOpenIdConnectContext








.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.TokenValidatedContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.TokenValidatedContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.TokenValidatedContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OpenIdConnect.TokenValidatedContext.Nonce
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Nonce
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OpenIdConnect.TokenValidatedContext.Properties
    
        
        :rtype: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
            public AuthenticationProperties Properties
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OpenIdConnect.TokenValidatedContext.SecurityToken
    
        
        :rtype: System.IdentityModel.Tokens.Jwt.JwtSecurityToken
    
        
        .. code-block:: csharp
    
            public JwtSecurityToken SecurityToken
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OpenIdConnect.TokenValidatedContext.TokenEndpointResponse
    
        
        :rtype: Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectMessage
    
        
        .. code-block:: csharp
    
            public OpenIdConnectMessage TokenEndpointResponse
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.TokenValidatedContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authentication.OpenIdConnect.TokenValidatedContext.TokenValidatedContext(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Builder.OpenIdConnectOptions)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Authentication.OpenIdConnect.TokenValidatedContext`
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type options: Microsoft.AspNetCore.Builder.OpenIdConnectOptions
    
        
        .. code-block:: csharp
    
            public TokenValidatedContext(HttpContext context, OpenIdConnectOptions options)
    

