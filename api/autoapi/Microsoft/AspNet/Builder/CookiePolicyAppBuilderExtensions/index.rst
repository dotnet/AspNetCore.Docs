

CookiePolicyAppBuilderExtensions Class
======================================



.. contents:: 
   :local:



Summary
-------

Extension methods to add cookie policy capabilities to an HTTP application pipeline.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Builder.CookiePolicyAppBuilderExtensions`








Syntax
------

.. code-block:: csharp

   public class CookiePolicyAppBuilderExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.CookiePolicy/CookiePolicyAppBuilderExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Builder.CookiePolicyAppBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Builder.CookiePolicyAppBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Builder.CookiePolicyAppBuilderExtensions.UseCookiePolicy(Microsoft.AspNet.Builder.IApplicationBuilder, Microsoft.AspNet.CookiePolicy.CookiePolicyOptions)
    
        
    
        Adds the :any:`Microsoft.AspNet.CookiePolicy.CookiePolicyMiddleware` middleware to the specified :any:`Microsoft.AspNet.Builder.IApplicationBuilder`\, which enables cookie policy capabilities.
    
        
        
        
        :param app: The  to add the middleware to.
        
        :type app: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :param options: A  that specifies options for the middleware.
        
        :type options: Microsoft.AspNet.CookiePolicy.CookiePolicyOptions
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseCookiePolicy(IApplicationBuilder app, CookiePolicyOptions options)
    
    .. dn:method:: Microsoft.AspNet.Builder.CookiePolicyAppBuilderExtensions.UseCookiePolicy(Microsoft.AspNet.Builder.IApplicationBuilder, System.Action<Microsoft.AspNet.CookiePolicy.CookiePolicyOptions>)
    
        
    
        Adds the :any:`Microsoft.AspNet.CookiePolicy.CookiePolicyMiddleware` middleware to the specified :any:`Microsoft.AspNet.Builder.IApplicationBuilder`\, which enables cookie policy capabilities.
    
        
        
        
        :param app: The  to add the middleware to.
        
        :type app: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :param configureOptions: An action delegate to configure the provided .
        
        :type configureOptions: System.Action{Microsoft.AspNet.CookiePolicy.CookiePolicyOptions}
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseCookiePolicy(IApplicationBuilder app, Action<CookiePolicyOptions> configureOptions)
    

