

FacebookAppBuilderExtensions Class
==================================






Extension methods to add Facebook authentication capabilities to an HTTP application pipeline.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.Authentication.Facebook

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Builder.FacebookAppBuilderExtensions`








Syntax
------

.. code-block:: csharp

    public class FacebookAppBuilderExtensions








.. dn:class:: Microsoft.AspNetCore.Builder.FacebookAppBuilderExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.FacebookAppBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Builder.FacebookAppBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Builder.FacebookAppBuilderExtensions.UseFacebookAuthentication(Microsoft.AspNetCore.Builder.IApplicationBuilder)
    
        
    
        
        Adds the :any:`Microsoft.AspNetCore.Authentication.Facebook.FacebookMiddleware` middleware to the specified :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder`\, which enables Facebook authentication capabilities.
    
        
    
        
        :param app: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` to add the middleware to.
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseFacebookAuthentication(this IApplicationBuilder app)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.FacebookAppBuilderExtensions.UseFacebookAuthentication(Microsoft.AspNetCore.Builder.IApplicationBuilder, Microsoft.AspNetCore.Builder.FacebookOptions)
    
        
    
        
        Adds the :any:`Microsoft.AspNetCore.Authentication.Facebook.FacebookMiddleware` middleware to the specified :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder`\, which enables Facebook authentication capabilities.
    
        
    
        
        :param app: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` to add the middleware to.
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :param options: A :any:`Microsoft.AspNetCore.Builder.FacebookOptions` that specifies options for the middleware.
        
        :type options: Microsoft.AspNetCore.Builder.FacebookOptions
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseFacebookAuthentication(this IApplicationBuilder app, FacebookOptions options)
    

