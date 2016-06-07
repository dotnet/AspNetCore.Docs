

MessageReceivedContext Class
============================





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
* :dn:cls:`Microsoft.AspNetCore.Authentication.JwtBearer.MessageReceivedContext`








Syntax
------

.. code-block:: csharp

    public class MessageReceivedContext : BaseJwtBearerContext








.. dn:class:: Microsoft.AspNetCore.Authentication.JwtBearer.MessageReceivedContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.JwtBearer.MessageReceivedContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.JwtBearer.MessageReceivedContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.JwtBearer.MessageReceivedContext.Token
    
        
    
        
        Bearer Token. This will give application an opportunity to retrieve token from an alternation location.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Token
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authentication.JwtBearer.MessageReceivedContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authentication.JwtBearer.MessageReceivedContext.MessageReceivedContext(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Builder.JwtBearerOptions)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type options: Microsoft.AspNetCore.Builder.JwtBearerOptions
    
        
        .. code-block:: csharp
    
            public MessageReceivedContext(HttpContext context, JwtBearerOptions options)
    

