

TwitterAppBuilderExtensions Class
=================================






Extension methods to add Twitter authentication capabilities to an HTTP application pipeline.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.Authentication.Twitter

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Builder.TwitterAppBuilderExtensions`








Syntax
------

.. code-block:: csharp

    public class TwitterAppBuilderExtensions








.. dn:class:: Microsoft.AspNetCore.Builder.TwitterAppBuilderExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.TwitterAppBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Builder.TwitterAppBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Builder.TwitterAppBuilderExtensions.UseTwitterAuthentication(Microsoft.AspNetCore.Builder.IApplicationBuilder)
    
        
    
        
        Adds the :any:`Microsoft.AspNetCore.Authentication.Twitter.TwitterMiddleware` middleware to the specified :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder`\, which enables Twitter authentication capabilities.
    
        
    
        
        :param app: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` to add the middleware to.
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseTwitterAuthentication(IApplicationBuilder app)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.TwitterAppBuilderExtensions.UseTwitterAuthentication(Microsoft.AspNetCore.Builder.IApplicationBuilder, Microsoft.AspNetCore.Builder.TwitterOptions)
    
        
    
        
        Adds the :any:`Microsoft.AspNetCore.Authentication.Twitter.TwitterMiddleware` middleware to the specified :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder`\, which enables Twitter authentication capabilities.
    
        
    
        
        :param app: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` to add the middleware to.
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :param options: An action delegate to configure the provided :any:`Microsoft.AspNetCore.Builder.TwitterOptions`\.
        
        :type options: Microsoft.AspNetCore.Builder.TwitterOptions
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseTwitterAuthentication(IApplicationBuilder app, TwitterOptions options)
    

