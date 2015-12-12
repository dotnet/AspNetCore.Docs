

ReceivingTokenContext Class
===========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.BaseContext`
* :dn:cls:`Microsoft.AspNet.Authentication.BaseControlContext`
* :dn:cls:`Microsoft.AspNet.Authentication.JwtBearer.BaseJwtBearerContext`
* :dn:cls:`Microsoft.AspNet.Authentication.JwtBearer.ReceivingTokenContext`








Syntax
------

.. code-block:: csharp

   public class ReceivingTokenContext : BaseJwtBearerContext





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication.JwtBearer/Events/ReceivingTokenContext.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.JwtBearer.ReceivingTokenContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.JwtBearer.ReceivingTokenContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.JwtBearer.ReceivingTokenContext.ReceivingTokenContext(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Authentication.JwtBearer.JwtBearerOptions)
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :type options: Microsoft.AspNet.Authentication.JwtBearer.JwtBearerOptions
    
        
        .. code-block:: csharp
    
           public ReceivingTokenContext(HttpContext context, JwtBearerOptions options)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.JwtBearer.ReceivingTokenContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.JwtBearer.ReceivingTokenContext.Token
    
        
    
        Bearer Token. This will give application an opportunity to retrieve token from an alternation location.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Token { get; set; }
    

