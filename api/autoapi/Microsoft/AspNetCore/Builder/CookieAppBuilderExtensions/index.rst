

CookieAppBuilderExtensions Class
================================






Extension methods to add cookie authentication capabilities to an HTTP application pipeline.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.Authentication.Cookies

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Builder.CookieAppBuilderExtensions`








Syntax
------

.. code-block:: csharp

    public class CookieAppBuilderExtensions








.. dn:class:: Microsoft.AspNetCore.Builder.CookieAppBuilderExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.CookieAppBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Builder.CookieAppBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Builder.CookieAppBuilderExtensions.UseCookieAuthentication(Microsoft.AspNetCore.Builder.IApplicationBuilder)
    
        
    
        
        Adds the :any:`Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationMiddleware` middleware to the specified :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder`\, which enables cookie authentication capabilities.
    
        
    
        
        :param app: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` to add the middleware to.
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseCookieAuthentication(this IApplicationBuilder app)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.CookieAppBuilderExtensions.UseCookieAuthentication(Microsoft.AspNetCore.Builder.IApplicationBuilder, Microsoft.AspNetCore.Builder.CookieAuthenticationOptions)
    
        
    
        
        Adds the :any:`Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationMiddleware` middleware to the specified :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder`\, which enables cookie authentication capabilities.
    
        
    
        
        :param app: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` to add the middleware to.
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :param options: A :any:`Microsoft.AspNetCore.Builder.CookieAuthenticationOptions` that specifies options for the middleware.
        
        :type options: Microsoft.AspNetCore.Builder.CookieAuthenticationOptions
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseCookieAuthentication(this IApplicationBuilder app, CookieAuthenticationOptions options)
    

