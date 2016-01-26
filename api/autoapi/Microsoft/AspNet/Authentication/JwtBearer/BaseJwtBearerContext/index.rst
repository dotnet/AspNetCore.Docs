

BaseJwtBearerContext Class
==========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.BaseContext`
* :dn:cls:`Microsoft.AspNet.Authentication.BaseControlContext`
* :dn:cls:`Microsoft.AspNet.Authentication.JwtBearer.BaseJwtBearerContext`








Syntax
------

.. code-block:: csharp

   public class BaseJwtBearerContext : BaseControlContext





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication.JwtBearer/Events/BaseJwtBearerContext.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.JwtBearer.BaseJwtBearerContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.JwtBearer.BaseJwtBearerContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.JwtBearer.BaseJwtBearerContext.BaseJwtBearerContext(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Authentication.JwtBearer.JwtBearerOptions)
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :type options: Microsoft.AspNet.Authentication.JwtBearer.JwtBearerOptions
    
        
        .. code-block:: csharp
    
           public BaseJwtBearerContext(HttpContext context, JwtBearerOptions options)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.JwtBearer.BaseJwtBearerContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.JwtBearer.BaseJwtBearerContext.Options
    
        
        :rtype: Microsoft.AspNet.Authentication.JwtBearer.JwtBearerOptions
    
        
        .. code-block:: csharp
    
           public JwtBearerOptions Options { get; }
    

