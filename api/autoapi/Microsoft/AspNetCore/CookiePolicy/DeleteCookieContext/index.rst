

DeleteCookieContext Class
=========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.CookiePolicy`
Assemblies
    * Microsoft.AspNetCore.CookiePolicy

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.CookiePolicy.DeleteCookieContext`








Syntax
------

.. code-block:: csharp

    public class DeleteCookieContext








.. dn:class:: Microsoft.AspNetCore.CookiePolicy.DeleteCookieContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.CookiePolicy.DeleteCookieContext

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.CookiePolicy.DeleteCookieContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.CookiePolicy.DeleteCookieContext.DeleteCookieContext(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Http.CookieOptions, System.String)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type options: Microsoft.AspNetCore.Http.CookieOptions
    
        
        :type name: System.String
    
        
        .. code-block:: csharp
    
            public DeleteCookieContext(HttpContext context, CookieOptions options, string name)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.CookiePolicy.DeleteCookieContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.CookiePolicy.DeleteCookieContext.Context
    
        
        :rtype: Microsoft.AspNetCore.Http.HttpContext
    
        
        .. code-block:: csharp
    
            public HttpContext Context { get; }
    
    .. dn:property:: Microsoft.AspNetCore.CookiePolicy.DeleteCookieContext.CookieName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string CookieName { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.CookiePolicy.DeleteCookieContext.CookieOptions
    
        
        :rtype: Microsoft.AspNetCore.Http.CookieOptions
    
        
        .. code-block:: csharp
    
            public CookieOptions CookieOptions { get; }
    

