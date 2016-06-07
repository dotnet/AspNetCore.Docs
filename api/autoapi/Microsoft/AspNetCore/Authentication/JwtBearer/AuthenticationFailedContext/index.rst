

AuthenticationFailedContext Class
=================================





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
* :dn:cls:`Microsoft.AspNetCore.Authentication.JwtBearer.AuthenticationFailedContext`








Syntax
------

.. code-block:: csharp

    public class AuthenticationFailedContext : BaseJwtBearerContext








.. dn:class:: Microsoft.AspNetCore.Authentication.JwtBearer.AuthenticationFailedContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.JwtBearer.AuthenticationFailedContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.JwtBearer.AuthenticationFailedContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.JwtBearer.AuthenticationFailedContext.Exception
    
        
        :rtype: System.Exception
    
        
        .. code-block:: csharp
    
            public Exception Exception
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authentication.JwtBearer.AuthenticationFailedContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authentication.JwtBearer.AuthenticationFailedContext.AuthenticationFailedContext(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Builder.JwtBearerOptions)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type options: Microsoft.AspNetCore.Builder.JwtBearerOptions
    
        
        .. code-block:: csharp
    
            public AuthenticationFailedContext(HttpContext context, JwtBearerOptions options)
    

