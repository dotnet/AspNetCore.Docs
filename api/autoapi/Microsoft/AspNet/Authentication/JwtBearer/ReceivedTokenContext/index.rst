

ReceivedTokenContext Class
==========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.BaseContext`
* :dn:cls:`Microsoft.AspNet.Authentication.BaseControlContext`
* :dn:cls:`Microsoft.AspNet.Authentication.JwtBearer.BaseJwtBearerContext`
* :dn:cls:`Microsoft.AspNet.Authentication.JwtBearer.ReceivedTokenContext`








Syntax
------

.. code-block:: csharp

   public class ReceivedTokenContext : BaseJwtBearerContext





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication.JwtBearer/Events/ReceivedTokenContext.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.JwtBearer.ReceivedTokenContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.JwtBearer.ReceivedTokenContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.JwtBearer.ReceivedTokenContext.ReceivedTokenContext(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Authentication.JwtBearer.JwtBearerOptions)
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :type options: Microsoft.AspNet.Authentication.JwtBearer.JwtBearerOptions
    
        
        .. code-block:: csharp
    
           public ReceivedTokenContext(HttpContext context, JwtBearerOptions options)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.JwtBearer.ReceivedTokenContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.JwtBearer.ReceivedTokenContext.Token
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Token { get; set; }
    

