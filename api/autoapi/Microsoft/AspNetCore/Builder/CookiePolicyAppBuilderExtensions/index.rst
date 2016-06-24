

CookiePolicyAppBuilderExtensions Class
======================================






Extension methods to add cookie policy capabilities to an HTTP application pipeline.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.CookiePolicy

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Builder.CookiePolicyAppBuilderExtensions`








Syntax
------

.. code-block:: csharp

    public class CookiePolicyAppBuilderExtensions








.. dn:class:: Microsoft.AspNetCore.Builder.CookiePolicyAppBuilderExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.CookiePolicyAppBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Builder.CookiePolicyAppBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Builder.CookiePolicyAppBuilderExtensions.UseCookiePolicy(Microsoft.AspNetCore.Builder.IApplicationBuilder)
    
        
    
        
        Adds the :any:`Microsoft.AspNetCore.CookiePolicy.CookiePolicyMiddleware` middleware to the specified :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder`\, which enables cookie policy capabilities.
    
        
    
        
        :param app: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` to add the middleware to.
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseCookiePolicy(this IApplicationBuilder app)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.CookiePolicyAppBuilderExtensions.UseCookiePolicy(Microsoft.AspNetCore.Builder.IApplicationBuilder, Microsoft.AspNetCore.Builder.CookiePolicyOptions)
    
        
    
        
        Adds the :any:`Microsoft.AspNetCore.CookiePolicy.CookiePolicyMiddleware` middleware to the specified :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder`\, which enables cookie policy capabilities.
    
        
    
        
        :param app: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` to add the middleware to.
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :param options: A :any:`Microsoft.AspNetCore.Builder.CookiePolicyOptions` that specifies options for the middleware.
        
        :type options: Microsoft.AspNetCore.Builder.CookiePolicyOptions
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseCookiePolicy(this IApplicationBuilder app, CookiePolicyOptions options)
    

