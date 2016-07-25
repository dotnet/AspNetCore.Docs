

MicrosoftAccountAppBuilderExtensions Class
==========================================






Extension methods to add Microsoft Account authentication capabilities to an HTTP application pipeline.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.Authentication.MicrosoftAccount

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Builder.MicrosoftAccountAppBuilderExtensions`








Syntax
------

.. code-block:: csharp

    public class MicrosoftAccountAppBuilderExtensions








.. dn:class:: Microsoft.AspNetCore.Builder.MicrosoftAccountAppBuilderExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.MicrosoftAccountAppBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Builder.MicrosoftAccountAppBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Builder.MicrosoftAccountAppBuilderExtensions.UseMicrosoftAccountAuthentication(Microsoft.AspNetCore.Builder.IApplicationBuilder)
    
        
    
        
        Adds the :any:`Microsoft.AspNetCore.Authentication.MicrosoftAccount.MicrosoftAccountMiddleware` middleware to the specified :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder`\, which enables Microsoft Account authentication capabilities.
    
        
    
        
        :param app: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` to add the middleware to.
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseMicrosoftAccountAuthentication(this IApplicationBuilder app)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.MicrosoftAccountAppBuilderExtensions.UseMicrosoftAccountAuthentication(Microsoft.AspNetCore.Builder.IApplicationBuilder, Microsoft.AspNetCore.Builder.MicrosoftAccountOptions)
    
        
    
        
        Adds the :any:`Microsoft.AspNetCore.Authentication.MicrosoftAccount.MicrosoftAccountMiddleware` middleware to the specified :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder`\, which enables Microsoft Account authentication capabilities.
    
        
    
        
        :param app: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` to add the middleware to.
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :param options: A :any:`Microsoft.AspNetCore.Builder.MicrosoftAccountOptions` that specifies options for the middleware.
        
        :type options: Microsoft.AspNetCore.Builder.MicrosoftAccountOptions
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseMicrosoftAccountAuthentication(this IApplicationBuilder app, MicrosoftAccountOptions options)
    

