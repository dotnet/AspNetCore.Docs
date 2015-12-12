

FacebookAppBuilderExtensions Class
==================================



.. contents:: 
   :local:



Summary
-------

Extension methods to add Facebook authentication capabilities to an HTTP application pipeline.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Builder.FacebookAppBuilderExtensions`








Syntax
------

.. code-block:: csharp

   public class FacebookAppBuilderExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication.Facebook/FacebookAppBuilderExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Builder.FacebookAppBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Builder.FacebookAppBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Builder.FacebookAppBuilderExtensions.UseFacebookAuthentication(Microsoft.AspNet.Builder.IApplicationBuilder, Microsoft.AspNet.Authentication.Facebook.FacebookOptions)
    
        
    
        Adds the :any:`Microsoft.AspNet.Authentication.Facebook.FacebookMiddleware` middleware to the specified :any:`Microsoft.AspNet.Builder.IApplicationBuilder`\, which enables Facebook authentication capabilities.
    
        
        
        
        :param app: The  to add the middleware to.
        
        :type app: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :param options: A  that specifies options for the middleware.
        
        :type options: Microsoft.AspNet.Authentication.Facebook.FacebookOptions
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseFacebookAuthentication(IApplicationBuilder app, FacebookOptions options)
    
    .. dn:method:: Microsoft.AspNet.Builder.FacebookAppBuilderExtensions.UseFacebookAuthentication(Microsoft.AspNet.Builder.IApplicationBuilder, System.Action<Microsoft.AspNet.Authentication.Facebook.FacebookOptions>)
    
        
    
        Adds the :any:`Microsoft.AspNet.Authentication.Facebook.FacebookMiddleware` middleware to the specified :any:`Microsoft.AspNet.Builder.IApplicationBuilder`\, which enables Facebook authentication capabilities.
    
        
        
        
        :param app: The  to add the middleware to.
        
        :type app: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :param configureOptions: An action delegate to configure the provided .
        
        :type configureOptions: System.Action{Microsoft.AspNet.Authentication.Facebook.FacebookOptions}
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseFacebookAuthentication(IApplicationBuilder app, Action<FacebookOptions> configureOptions)
    

