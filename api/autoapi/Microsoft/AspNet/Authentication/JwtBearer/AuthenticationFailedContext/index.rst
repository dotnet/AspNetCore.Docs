

AuthenticationFailedContext Class
=================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.BaseContext`
* :dn:cls:`Microsoft.AspNet.Authentication.BaseControlContext`
* :dn:cls:`Microsoft.AspNet.Authentication.JwtBearer.BaseJwtBearerContext`
* :dn:cls:`Microsoft.AspNet.Authentication.JwtBearer.AuthenticationFailedContext`








Syntax
------

.. code-block:: csharp

   public class AuthenticationFailedContext : BaseJwtBearerContext





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication.JwtBearer/Events/AuthenticationFailedContext.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.JwtBearer.AuthenticationFailedContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.JwtBearer.AuthenticationFailedContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.JwtBearer.AuthenticationFailedContext.AuthenticationFailedContext(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Authentication.JwtBearer.JwtBearerOptions)
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :type options: Microsoft.AspNet.Authentication.JwtBearer.JwtBearerOptions
    
        
        .. code-block:: csharp
    
           public AuthenticationFailedContext(HttpContext context, JwtBearerOptions options)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.JwtBearer.AuthenticationFailedContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.JwtBearer.AuthenticationFailedContext.Exception
    
        
        :rtype: System.Exception
    
        
        .. code-block:: csharp
    
           public Exception Exception { get; set; }
    

