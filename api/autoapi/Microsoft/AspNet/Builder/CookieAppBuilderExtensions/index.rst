

CookieAppBuilderExtensions Class
================================



.. contents:: 
   :local:



Summary
-------

Extension methods to add cookie authentication capabilities to an HTTP application pipeline.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Builder.CookieAppBuilderExtensions`








Syntax
------

.. code-block:: csharp

   public class CookieAppBuilderExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication.Cookies/CookieAppBuilderExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Builder.CookieAppBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Builder.CookieAppBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Builder.CookieAppBuilderExtensions.UseCookieAuthentication(Microsoft.AspNet.Builder.IApplicationBuilder)
    
        
    
        Adds the :any:`Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationMiddleware` middleware to the specified :any:`Microsoft.AspNet.Builder.IApplicationBuilder`\, which enables cookie authentication capabilities.
    
        
        
        
        :param app: The  to add the middleware to.
        
        :type app: Microsoft.AspNet.Builder.IApplicationBuilder
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseCookieAuthentication(IApplicationBuilder app)
    
    .. dn:method:: Microsoft.AspNet.Builder.CookieAppBuilderExtensions.UseCookieAuthentication(Microsoft.AspNet.Builder.IApplicationBuilder, Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions)
    
        
    
        Adds the :any:`Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationMiddleware` middleware to the specified :any:`Microsoft.AspNet.Builder.IApplicationBuilder`\, which enables cookie authentication capabilities.
    
        
        
        
        :param app: The  to add the middleware to.
        
        :type app: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :param options: A  that specifies options for the middleware.
        
        :type options: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseCookieAuthentication(IApplicationBuilder app, CookieAuthenticationOptions options)
    
    .. dn:method:: Microsoft.AspNet.Builder.CookieAppBuilderExtensions.UseCookieAuthentication(Microsoft.AspNet.Builder.IApplicationBuilder, System.Action<Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions>)
    
        
    
        Adds the :any:`Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationMiddleware` middleware to the specified :any:`Microsoft.AspNet.Builder.IApplicationBuilder`\, which enables cookie authentication capabilities.
    
        
        
        
        :param app: The  to add the middleware to.
        
        :type app: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :param configureOptions: An action delegate to configure the provided .
        
        :type configureOptions: System.Action{Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions}
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseCookieAuthentication(IApplicationBuilder app, Action<CookieAuthenticationOptions> configureOptions)
    

