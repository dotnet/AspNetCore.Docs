

AppendCookieContext Class
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
* :dn:cls:`Microsoft.AspNetCore.CookiePolicy.AppendCookieContext`








Syntax
------

.. code-block:: csharp

    public class AppendCookieContext








.. dn:class:: Microsoft.AspNetCore.CookiePolicy.AppendCookieContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.CookiePolicy.AppendCookieContext

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.CookiePolicy.AppendCookieContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.CookiePolicy.AppendCookieContext.AppendCookieContext(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Http.CookieOptions, System.String, System.String)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type options: Microsoft.AspNetCore.Http.CookieOptions
    
        
        :type name: System.String
    
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
            public AppendCookieContext(HttpContext context, CookieOptions options, string name, string value)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.CookiePolicy.AppendCookieContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.CookiePolicy.AppendCookieContext.Context
    
        
        :rtype: Microsoft.AspNetCore.Http.HttpContext
    
        
        .. code-block:: csharp
    
            public HttpContext Context { get; }
    
    .. dn:property:: Microsoft.AspNetCore.CookiePolicy.AppendCookieContext.CookieName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string CookieName { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.CookiePolicy.AppendCookieContext.CookieOptions
    
        
        :rtype: Microsoft.AspNetCore.Http.CookieOptions
    
        
        .. code-block:: csharp
    
            public CookieOptions CookieOptions { get; }
    
    .. dn:property:: Microsoft.AspNetCore.CookiePolicy.AppendCookieContext.CookieValue
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string CookieValue { get; set; }
    

