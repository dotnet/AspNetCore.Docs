

AppendCookieContext Class
=========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.CookiePolicy.AppendCookieContext`








Syntax
------

.. code-block:: csharp

   public class AppendCookieContext





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.CookiePolicy/AppendCookieContext.cs>`_





.. dn:class:: Microsoft.AspNet.CookiePolicy.AppendCookieContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.CookiePolicy.AppendCookieContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.CookiePolicy.AppendCookieContext.AppendCookieContext(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Http.CookieOptions, System.String, System.String)
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :type options: Microsoft.AspNet.Http.CookieOptions
        
        
        :type name: System.String
        
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
           public AppendCookieContext(HttpContext context, CookieOptions options, string name, string value)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.CookiePolicy.AppendCookieContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.CookiePolicy.AppendCookieContext.Context
    
        
        :rtype: Microsoft.AspNet.Http.HttpContext
    
        
        .. code-block:: csharp
    
           public HttpContext Context { get; }
    
    .. dn:property:: Microsoft.AspNet.CookiePolicy.AppendCookieContext.CookieName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string CookieName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.CookiePolicy.AppendCookieContext.CookieOptions
    
        
        :rtype: Microsoft.AspNet.Http.CookieOptions
    
        
        .. code-block:: csharp
    
           public CookieOptions CookieOptions { get; }
    
    .. dn:property:: Microsoft.AspNet.CookiePolicy.AppendCookieContext.CookieValue
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string CookieValue { get; set; }
    

