

DeleteCookieContext Class
=========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.CookiePolicy.DeleteCookieContext`








Syntax
------

.. code-block:: csharp

   public class DeleteCookieContext





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.CookiePolicy/DeleteCookieContext.cs>`_





.. dn:class:: Microsoft.AspNet.CookiePolicy.DeleteCookieContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.CookiePolicy.DeleteCookieContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.CookiePolicy.DeleteCookieContext.DeleteCookieContext(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Http.CookieOptions, System.String)
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :type options: Microsoft.AspNet.Http.CookieOptions
        
        
        :type name: System.String
    
        
        .. code-block:: csharp
    
           public DeleteCookieContext(HttpContext context, CookieOptions options, string name)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.CookiePolicy.DeleteCookieContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.CookiePolicy.DeleteCookieContext.Context
    
        
        :rtype: Microsoft.AspNet.Http.HttpContext
    
        
        .. code-block:: csharp
    
           public HttpContext Context { get; }
    
    .. dn:property:: Microsoft.AspNet.CookiePolicy.DeleteCookieContext.CookieName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string CookieName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.CookiePolicy.DeleteCookieContext.CookieOptions
    
        
        :rtype: Microsoft.AspNet.Http.CookieOptions
    
        
        .. code-block:: csharp
    
           public CookieOptions CookieOptions { get; }
    

