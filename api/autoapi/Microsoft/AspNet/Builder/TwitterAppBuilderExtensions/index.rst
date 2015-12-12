

TwitterAppBuilderExtensions Class
=================================



.. contents:: 
   :local:



Summary
-------

Extension methods to add Twitter authentication capabilities to an HTTP application pipeline.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Builder.TwitterAppBuilderExtensions`








Syntax
------

.. code-block:: csharp

   public class TwitterAppBuilderExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authentication.Twitter/TwitterAppBuilderExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Builder.TwitterAppBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Builder.TwitterAppBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Builder.TwitterAppBuilderExtensions.UseTwitterAuthentication(Microsoft.AspNet.Builder.IApplicationBuilder, Microsoft.AspNet.Authentication.Twitter.TwitterOptions)
    
        
    
        Adds the :any:`Microsoft.AspNet.Authentication.Twitter.TwitterMiddleware` middleware to the specified :any:`Microsoft.AspNet.Builder.IApplicationBuilder`\, which enables Twitter authentication capabilities.
    
        
        
        
        :param app: The  to add the middleware to.
        
        :type app: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :param options: A  that specifies options for the middleware.
        
        :type options: Microsoft.AspNet.Authentication.Twitter.TwitterOptions
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseTwitterAuthentication(IApplicationBuilder app, TwitterOptions options)
    
    .. dn:method:: Microsoft.AspNet.Builder.TwitterAppBuilderExtensions.UseTwitterAuthentication(Microsoft.AspNet.Builder.IApplicationBuilder, System.Action<Microsoft.AspNet.Authentication.Twitter.TwitterOptions>)
    
        
    
        Adds the :any:`Microsoft.AspNet.Authentication.Twitter.TwitterMiddleware` middleware to the specified :any:`Microsoft.AspNet.Builder.IApplicationBuilder`\, which enables Twitter authentication capabilities.
    
        
        
        
        :param app: The  to add the middleware to.
        
        :type app: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :param configureOptions: An action delegate to configure the provided .
        
        :type configureOptions: System.Action{Microsoft.AspNet.Authentication.Twitter.TwitterOptions}
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseTwitterAuthentication(IApplicationBuilder app, Action<TwitterOptions> configureOptions = null)
    

