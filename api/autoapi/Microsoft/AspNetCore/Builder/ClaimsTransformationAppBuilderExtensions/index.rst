

ClaimsTransformationAppBuilderExtensions Class
==============================================






Extension methods to add claims transformation capabilities to an HTTP application pipeline.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.Authentication

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Builder.ClaimsTransformationAppBuilderExtensions`








Syntax
------

.. code-block:: csharp

    public class ClaimsTransformationAppBuilderExtensions








.. dn:class:: Microsoft.AspNetCore.Builder.ClaimsTransformationAppBuilderExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.ClaimsTransformationAppBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Builder.ClaimsTransformationAppBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Builder.ClaimsTransformationAppBuilderExtensions.UseClaimsTransformation(Microsoft.AspNetCore.Builder.IApplicationBuilder)
    
        
    
        
        Adds the :any:`Microsoft.AspNetCore.Authentication.ClaimsTransformationMiddleware` middleware to the specified :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder`\, which enables claims transformation capabilities.
    
        
    
        
        :param app: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` to add the middleware to.
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseClaimsTransformation(IApplicationBuilder app)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.ClaimsTransformationAppBuilderExtensions.UseClaimsTransformation(Microsoft.AspNetCore.Builder.IApplicationBuilder, Microsoft.AspNetCore.Builder.ClaimsTransformationOptions)
    
        
    
        
        Adds the :any:`Microsoft.AspNetCore.Authentication.ClaimsTransformationMiddleware` middleware to the specified :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder`\, which enables claims transformation capabilities.
    
        
    
        
        :param app: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` to add the middleware to.
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :param options: The :any:`Microsoft.AspNetCore.Builder.ClaimsTransformationOptions` to configure the middleware with.
        
        :type options: Microsoft.AspNetCore.Builder.ClaimsTransformationOptions
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseClaimsTransformation(IApplicationBuilder app, ClaimsTransformationOptions options)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.ClaimsTransformationAppBuilderExtensions.UseClaimsTransformation(Microsoft.AspNetCore.Builder.IApplicationBuilder, System.Func<Microsoft.AspNetCore.Authentication.ClaimsTransformationContext, System.Threading.Tasks.Task<System.Security.Claims.ClaimsPrincipal>>)
    
        
    
        
        Adds the :any:`Microsoft.AspNetCore.Authentication.ClaimsTransformationMiddleware` middleware to the specified :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder`\, which enables claims transformation capabilities.
    
        
    
        
        :param app: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` to add the middleware to.
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :param transform: A function that asynchronously transforms one :any:`System.Security.Claims.ClaimsPrincipal` to another.
        
        :type transform: System.Func<System.Func`2>{Microsoft.AspNetCore.Authentication.ClaimsTransformationContext<Microsoft.AspNetCore.Authentication.ClaimsTransformationContext>, System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Security.Claims.ClaimsPrincipal<System.Security.Claims.ClaimsPrincipal>}}
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseClaimsTransformation(IApplicationBuilder app, Func<ClaimsTransformationContext, Task<ClaimsPrincipal>> transform)
    

