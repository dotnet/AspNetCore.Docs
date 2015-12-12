

MicrosoftAccountAppBuilderExtensions Class
==========================================



.. contents:: 
   :local:



Summary
-------

Extension methods to add Microsoft Account authentication capabilities to an HTTP application pipeline.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Builder.MicrosoftAccountAppBuilderExtensions`








Syntax
------

.. code-block:: csharp

   public class MicrosoftAccountAppBuilderExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication.MicrosoftAccount/MicrosoftAccountAppBuilderExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Builder.MicrosoftAccountAppBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Builder.MicrosoftAccountAppBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Builder.MicrosoftAccountAppBuilderExtensions.UseMicrosoftAccountAuthentication(Microsoft.AspNet.Builder.IApplicationBuilder, Microsoft.AspNet.Authentication.MicrosoftAccount.MicrosoftAccountOptions)
    
        
    
        Adds the :any:`Microsoft.AspNet.Authentication.MicrosoftAccount.MicrosoftAccountMiddleware` middleware to the specified :any:`Microsoft.AspNet.Builder.IApplicationBuilder`\, which enables Microsoft Account authentication capabilities.
    
        
        
        
        :param app: The  to add the middleware to.
        
        :type app: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :param options: A  that specifies options for the middleware.
        
        :type options: Microsoft.AspNet.Authentication.MicrosoftAccount.MicrosoftAccountOptions
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseMicrosoftAccountAuthentication(IApplicationBuilder app, MicrosoftAccountOptions options)
    
    .. dn:method:: Microsoft.AspNet.Builder.MicrosoftAccountAppBuilderExtensions.UseMicrosoftAccountAuthentication(Microsoft.AspNet.Builder.IApplicationBuilder, System.Action<Microsoft.AspNet.Authentication.MicrosoftAccount.MicrosoftAccountOptions>)
    
        
    
        Adds the :any:`Microsoft.AspNet.Authentication.MicrosoftAccount.MicrosoftAccountMiddleware` middleware to the specified :any:`Microsoft.AspNet.Builder.IApplicationBuilder`\, which enables Microsoft Account authentication capabilities.
    
        
        
        
        :param app: The  to add the middleware to.
        
        :type app: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :param configureOptions: An action delegate to configure the provided .
        
        :type configureOptions: System.Action{Microsoft.AspNet.Authentication.MicrosoftAccount.MicrosoftAccountOptions}
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseMicrosoftAccountAuthentication(IApplicationBuilder app, Action<MicrosoftAccountOptions> configureOptions)
    

