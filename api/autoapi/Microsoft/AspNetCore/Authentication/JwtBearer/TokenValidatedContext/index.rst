

TokenValidatedContext Class
===========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication.JwtBearer`
Assemblies
    * Microsoft.AspNetCore.Authentication.JwtBearer

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authentication.BaseContext`
* :dn:cls:`Microsoft.AspNetCore.Authentication.BaseControlContext`
* :dn:cls:`Microsoft.AspNetCore.Authentication.JwtBearer.BaseJwtBearerContext`
* :dn:cls:`Microsoft.AspNetCore.Authentication.JwtBearer.TokenValidatedContext`








Syntax
------

.. code-block:: csharp

    public class TokenValidatedContext : BaseJwtBearerContext








.. dn:class:: Microsoft.AspNetCore.Authentication.JwtBearer.TokenValidatedContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.JwtBearer.TokenValidatedContext

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authentication.JwtBearer.TokenValidatedContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authentication.JwtBearer.TokenValidatedContext.TokenValidatedContext(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Builder.JwtBearerOptions)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type options: Microsoft.AspNetCore.Builder.JwtBearerOptions
    
        
        .. code-block:: csharp
    
            public TokenValidatedContext(HttpContext context, JwtBearerOptions options)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.JwtBearer.TokenValidatedContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.JwtBearer.TokenValidatedContext.SecurityToken
    
        
        :rtype: Microsoft.IdentityModel.Tokens.SecurityToken
    
        
        .. code-block:: csharp
    
            public SecurityToken SecurityToken { get; set; }
    

