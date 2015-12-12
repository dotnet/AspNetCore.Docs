

CookiePolicyMiddleware Class
============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.CookiePolicy.CookiePolicyMiddleware`








Syntax
------

.. code-block:: csharp

   public class CookiePolicyMiddleware





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.CookiePolicy/CookiePolicyMiddleware.cs>`_





.. dn:class:: Microsoft.AspNet.CookiePolicy.CookiePolicyMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNet.CookiePolicy.CookiePolicyMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.CookiePolicy.CookiePolicyMiddleware.CookiePolicyMiddleware(Microsoft.AspNet.Builder.RequestDelegate, Microsoft.AspNet.CookiePolicy.CookiePolicyOptions)
    
        
        
        
        :type next: Microsoft.AspNet.Builder.RequestDelegate
        
        
        :type options: Microsoft.AspNet.CookiePolicy.CookiePolicyOptions
    
        
        .. code-block:: csharp
    
           public CookiePolicyMiddleware(RequestDelegate next, CookiePolicyOptions options)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.CookiePolicy.CookiePolicyMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.CookiePolicy.CookiePolicyMiddleware.Invoke(Microsoft.AspNet.Http.HttpContext)
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task Invoke(HttpContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.CookiePolicy.CookiePolicyMiddleware
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.CookiePolicy.CookiePolicyMiddleware.Options
    
        
        :rtype: Microsoft.AspNet.CookiePolicy.CookiePolicyOptions
    
        
        .. code-block:: csharp
    
           public CookiePolicyOptions Options { get; set; }
    

