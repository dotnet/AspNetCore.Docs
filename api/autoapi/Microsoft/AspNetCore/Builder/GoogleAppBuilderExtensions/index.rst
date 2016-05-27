

GoogleAppBuilderExtensions Class
================================






Extension methods to add Google authentication capabilities to an HTTP application pipeline.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.Authentication.Google

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Builder.GoogleAppBuilderExtensions`








Syntax
------

.. code-block:: csharp

    public class GoogleAppBuilderExtensions








.. dn:class:: Microsoft.AspNetCore.Builder.GoogleAppBuilderExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.GoogleAppBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Builder.GoogleAppBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Builder.GoogleAppBuilderExtensions.UseGoogleAuthentication(Microsoft.AspNetCore.Builder.IApplicationBuilder)
    
        
    
        
        Adds the :any:`Microsoft.AspNetCore.Authentication.Google.GoogleMiddleware` middleware to the specified :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder`\, which enables Google authentication capabilities.
    
        
    
        
        :param app: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` to add the middleware to.
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseGoogleAuthentication(IApplicationBuilder app)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.GoogleAppBuilderExtensions.UseGoogleAuthentication(Microsoft.AspNetCore.Builder.IApplicationBuilder, Microsoft.AspNetCore.Builder.GoogleOptions)
    
        
    
        
        Adds the :any:`Microsoft.AspNetCore.Authentication.Google.GoogleMiddleware` middleware to the specified :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder`\, which enables Google authentication capabilities.
    
        
    
        
        :param app: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` to add the middleware to.
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :param options: A :any:`Microsoft.AspNetCore.Builder.GoogleOptions` that specifies options for the middleware.
        
        :type options: Microsoft.AspNetCore.Builder.GoogleOptions
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseGoogleAuthentication(IApplicationBuilder app, GoogleOptions options)
    

