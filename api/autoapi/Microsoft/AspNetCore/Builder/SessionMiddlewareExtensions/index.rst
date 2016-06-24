

SessionMiddlewareExtensions Class
=================================






Extension methods for adding the :any:`Microsoft.AspNetCore.Session.SessionMiddleware` to an application.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.Session

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Builder.SessionMiddlewareExtensions`








Syntax
------

.. code-block:: csharp

    public class SessionMiddlewareExtensions








.. dn:class:: Microsoft.AspNetCore.Builder.SessionMiddlewareExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.SessionMiddlewareExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Builder.SessionMiddlewareExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Builder.SessionMiddlewareExtensions.UseSession(Microsoft.AspNetCore.Builder.IApplicationBuilder)
    
        
    
        
        Adds the :any:`Microsoft.AspNetCore.Session.SessionMiddleware` to automatically enable session state for the application.
    
        
    
        
        :param app: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder`\.
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :return: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseSession(this IApplicationBuilder app)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.SessionMiddlewareExtensions.UseSession(Microsoft.AspNetCore.Builder.IApplicationBuilder, Microsoft.AspNetCore.Builder.SessionOptions)
    
        
    
        
        Adds the :any:`Microsoft.AspNetCore.Session.SessionMiddleware` to automatically enable session state for the application.
    
        
    
        
        :param app: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder`\.
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :param options: The :any:`Microsoft.AspNetCore.Builder.SessionOptions`\.
        
        :type options: Microsoft.AspNetCore.Builder.SessionOptions
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :return: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseSession(this IApplicationBuilder app, SessionOptions options)
    

