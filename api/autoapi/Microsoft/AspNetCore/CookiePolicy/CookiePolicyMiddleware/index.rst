

CookiePolicyMiddleware Class
============================





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
* :dn:cls:`Microsoft.AspNetCore.CookiePolicy.CookiePolicyMiddleware`








Syntax
------

.. code-block:: csharp

    public class CookiePolicyMiddleware








.. dn:class:: Microsoft.AspNetCore.CookiePolicy.CookiePolicyMiddleware
    :hidden:

.. dn:class:: Microsoft.AspNetCore.CookiePolicy.CookiePolicyMiddleware

Properties
----------

.. dn:class:: Microsoft.AspNetCore.CookiePolicy.CookiePolicyMiddleware
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.CookiePolicy.CookiePolicyMiddleware.Options
    
        
        :rtype: Microsoft.AspNetCore.Builder.CookiePolicyOptions
    
        
        .. code-block:: csharp
    
            public CookiePolicyOptions Options
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.CookiePolicy.CookiePolicyMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.CookiePolicy.CookiePolicyMiddleware.CookiePolicyMiddleware(Microsoft.AspNetCore.Http.RequestDelegate, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Builder.CookiePolicyOptions>)
    
        
    
        
        :type next: Microsoft.AspNetCore.Http.RequestDelegate
    
        
        :type options: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Builder.CookiePolicyOptions<Microsoft.AspNetCore.Builder.CookiePolicyOptions>}
    
        
        .. code-block:: csharp
    
            public CookiePolicyMiddleware(RequestDelegate next, IOptions<CookiePolicyOptions> options)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.CookiePolicy.CookiePolicyMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.CookiePolicy.CookiePolicyMiddleware.Invoke(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task Invoke(HttpContext context)
    

