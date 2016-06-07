

BaseJwtBearerContext Class
==========================





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








Syntax
------

.. code-block:: csharp

    public class BaseJwtBearerContext : BaseControlContext








.. dn:class:: Microsoft.AspNetCore.Authentication.JwtBearer.BaseJwtBearerContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.JwtBearer.BaseJwtBearerContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.JwtBearer.BaseJwtBearerContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.JwtBearer.BaseJwtBearerContext.Options
    
        
        :rtype: Microsoft.AspNetCore.Builder.JwtBearerOptions
    
        
        .. code-block:: csharp
    
            public JwtBearerOptions Options
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authentication.JwtBearer.BaseJwtBearerContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authentication.JwtBearer.BaseJwtBearerContext.BaseJwtBearerContext(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Builder.JwtBearerOptions)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type options: Microsoft.AspNetCore.Builder.JwtBearerOptions
    
        
        .. code-block:: csharp
    
            public BaseJwtBearerContext(HttpContext context, JwtBearerOptions options)
    

