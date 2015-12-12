

WelcomePageMiddleware Class
===========================



.. contents:: 
   :local:



Summary
-------

This middleware provides a default web page for new applications.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Diagnostics.WelcomePageMiddleware`








Syntax
------

.. code-block:: csharp

   public class WelcomePageMiddleware





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/diagnostics/src/Microsoft.AspNet.Diagnostics/WelcomePage/WelcomePageMiddleware.cs>`_





.. dn:class:: Microsoft.AspNet.Diagnostics.WelcomePageMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNet.Diagnostics.WelcomePageMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Diagnostics.WelcomePageMiddleware.WelcomePageMiddleware(Microsoft.AspNet.Builder.RequestDelegate, Microsoft.AspNet.Diagnostics.WelcomePageOptions)
    
        
    
        Creates a default web page for new applications.
    
        
        
        
        :type next: Microsoft.AspNet.Builder.RequestDelegate
        
        
        :type options: Microsoft.AspNet.Diagnostics.WelcomePageOptions
    
        
        .. code-block:: csharp
    
           public WelcomePageMiddleware(RequestDelegate next, WelcomePageOptions options)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Diagnostics.WelcomePageMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Diagnostics.WelcomePageMiddleware.Invoke(Microsoft.AspNet.Http.HttpContext)
    
        
    
        Process an individual request.
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task Invoke(HttpContext context)
    

