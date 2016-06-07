

JwtBearerChallengeContext Class
===============================





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
* :dn:cls:`Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerChallengeContext`








Syntax
------

.. code-block:: csharp

    public class JwtBearerChallengeContext : BaseJwtBearerContext








.. dn:class:: Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerChallengeContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerChallengeContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerChallengeContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerChallengeContext.Properties
    
        
        :rtype: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
            public AuthenticationProperties Properties
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerChallengeContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerChallengeContext.JwtBearerChallengeContext(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Builder.JwtBearerOptions, Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type options: Microsoft.AspNetCore.Builder.JwtBearerOptions
    
        
        :type properties: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
            public JwtBearerChallengeContext(HttpContext context, JwtBearerOptions options, AuthenticationProperties properties)
    

