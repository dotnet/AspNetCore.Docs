

GoogleAppBuilderExtensions Class
================================



.. contents:: 
   :local:



Summary
-------

Extension methods to add Google authentication capabilities to an HTTP application pipeline.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Builder.GoogleAppBuilderExtensions`








Syntax
------

.. code-block:: csharp

   public class GoogleAppBuilderExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication.Google/GoogleAppBuilderExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Builder.GoogleAppBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Builder.GoogleAppBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Builder.GoogleAppBuilderExtensions.UseGoogleAuthentication(Microsoft.AspNet.Builder.IApplicationBuilder, Microsoft.AspNet.Authentication.Google.GoogleOptions)
    
        
    
        Adds the :any:`Microsoft.AspNet.Authentication.Google.GoogleMiddleware` middleware to the specified :any:`Microsoft.AspNet.Builder.IApplicationBuilder`\, which enables Google authentication capabilities.
    
        
        
        
        :param app: The  to add the middleware to.
        
        :type app: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :param options: A  that specifies options for the middleware.
        
        :type options: Microsoft.AspNet.Authentication.Google.GoogleOptions
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseGoogleAuthentication(IApplicationBuilder app, GoogleOptions options)
    
    .. dn:method:: Microsoft.AspNet.Builder.GoogleAppBuilderExtensions.UseGoogleAuthentication(Microsoft.AspNet.Builder.IApplicationBuilder, System.Action<Microsoft.AspNet.Authentication.Google.GoogleOptions>)
    
        
    
        Adds the :any:`Microsoft.AspNet.Authentication.Google.GoogleMiddleware` middleware to the specified :any:`Microsoft.AspNet.Builder.IApplicationBuilder`\, which enables Google authentication capabilities.
    
        
        
        
        :param app: The  to add the middleware to.
        
        :type app: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :param configureOptions: An action delegate to configure the provided .
        
        :type configureOptions: System.Action{Microsoft.AspNet.Authentication.Google.GoogleOptions}
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseGoogleAuthentication(IApplicationBuilder app, Action<GoogleOptions> configureOptions)
    

