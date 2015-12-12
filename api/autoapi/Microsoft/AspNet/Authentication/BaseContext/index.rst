

BaseContext Class
=================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.BaseContext`








Syntax
------

.. code-block:: csharp

   public abstract class BaseContext





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authentication/Events/BaseContext.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.BaseContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.BaseContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.BaseContext.BaseContext(Microsoft.AspNet.Http.HttpContext)
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
    
        
        .. code-block:: csharp
    
           protected BaseContext(HttpContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.BaseContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.BaseContext.HttpContext
    
        
        :rtype: Microsoft.AspNet.Http.HttpContext
    
        
        .. code-block:: csharp
    
           public HttpContext HttpContext { get; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.BaseContext.Request
    
        
        :rtype: Microsoft.AspNet.Http.HttpRequest
    
        
        .. code-block:: csharp
    
           public HttpRequest Request { get; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.BaseContext.Response
    
        
        :rtype: Microsoft.AspNet.Http.HttpResponse
    
        
        .. code-block:: csharp
    
           public HttpResponse Response { get; }
    

