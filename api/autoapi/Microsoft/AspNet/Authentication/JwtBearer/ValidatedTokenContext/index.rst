

ValidatedTokenContext Class
===========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.BaseContext`
* :dn:cls:`Microsoft.AspNet.Authentication.BaseControlContext`
* :dn:cls:`Microsoft.AspNet.Authentication.JwtBearer.BaseJwtBearerContext`
* :dn:cls:`Microsoft.AspNet.Authentication.JwtBearer.ValidatedTokenContext`








Syntax
------

.. code-block:: csharp

   public class ValidatedTokenContext : BaseJwtBearerContext





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authentication.JwtBearer/Events/TokenValidatedContext.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.JwtBearer.ValidatedTokenContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.JwtBearer.ValidatedTokenContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.JwtBearer.ValidatedTokenContext.ValidatedTokenContext(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Authentication.JwtBearer.JwtBearerOptions)
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :type options: Microsoft.AspNet.Authentication.JwtBearer.JwtBearerOptions
    
        
        .. code-block:: csharp
    
           public ValidatedTokenContext(HttpContext context, JwtBearerOptions options)
    

