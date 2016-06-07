

WelcomePageMiddleware Class
===========================






This middleware provides a default web page for new applications.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Diagnostics`
Assemblies
    * Microsoft.AspNetCore.Diagnostics

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Diagnostics.WelcomePageMiddleware`








Syntax
------

.. code-block:: csharp

    public class WelcomePageMiddleware








.. dn:class:: Microsoft.AspNetCore.Diagnostics.WelcomePageMiddleware
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Diagnostics.WelcomePageMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.WelcomePageMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Diagnostics.WelcomePageMiddleware.WelcomePageMiddleware(Microsoft.AspNetCore.Http.RequestDelegate, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Builder.WelcomePageOptions>)
    
        
    
        
        Creates a default web page for new applications.
    
        
    
        
        :type next: Microsoft.AspNetCore.Http.RequestDelegate
    
        
        :type options: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Builder.WelcomePageOptions<Microsoft.AspNetCore.Builder.WelcomePageOptions>}
    
        
        .. code-block:: csharp
    
            public WelcomePageMiddleware(RequestDelegate next, IOptions<WelcomePageOptions> options)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.WelcomePageMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Diagnostics.WelcomePageMiddleware.Invoke(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        Process an individual request.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Http.HttpContext`\.
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task Invoke(HttpContext context)
    

