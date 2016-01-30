

ClaimsTransformationAppBuilderExtensions Class
==============================================



.. contents:: 
   :local:



Summary
-------

Extension methods to add claims transformation capabilities to an HTTP application pipeline.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Builder.ClaimsTransformationAppBuilderExtensions`








Syntax
------

.. code-block:: csharp

   public class ClaimsTransformationAppBuilderExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication/ClaimsTransformationAppBuilderExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Builder.ClaimsTransformationAppBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Builder.ClaimsTransformationAppBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Builder.ClaimsTransformationAppBuilderExtensions.UseClaimsTransformation(Microsoft.AspNet.Builder.IApplicationBuilder, Microsoft.AspNet.Authentication.ClaimsTransformationOptions)
    
        
    
        Adds the :any:`Microsoft.AspNet.Authentication.ClaimsTransformationMiddleware` middleware to the specified :any:`Microsoft.AspNet.Builder.IApplicationBuilder`\, which enables claims transformation capabilities.
    
        
        
        
        :param app: The  to add the middleware to.
        
        :type app: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :param options: A  that specifies options for the middleware.
        
        :type options: Microsoft.AspNet.Authentication.ClaimsTransformationOptions
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseClaimsTransformation(IApplicationBuilder app, ClaimsTransformationOptions options)
    
    .. dn:method:: Microsoft.AspNet.Builder.ClaimsTransformationAppBuilderExtensions.UseClaimsTransformation(Microsoft.AspNet.Builder.IApplicationBuilder, System.Action<Microsoft.AspNet.Authentication.ClaimsTransformationOptions>)
    
        
    
        Adds the :any:`Microsoft.AspNet.Authentication.ClaimsTransformationMiddleware` middleware to the specified :any:`Microsoft.AspNet.Builder.IApplicationBuilder`\, which enables claims transformation capabilities.
    
        
        
        
        :param app: The  to add the middleware to.
        
        :type app: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :param configureOptions: An action delegate to configure the provided .
        
        :type configureOptions: System.Action{Microsoft.AspNet.Authentication.ClaimsTransformationOptions}
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseClaimsTransformation(IApplicationBuilder app, Action<ClaimsTransformationOptions> configureOptions)
    
    .. dn:method:: Microsoft.AspNet.Builder.ClaimsTransformationAppBuilderExtensions.UseClaimsTransformation(Microsoft.AspNet.Builder.IApplicationBuilder, System.Func<System.Security.Claims.ClaimsPrincipal, System.Threading.Tasks.Task<System.Security.Claims.ClaimsPrincipal>>)
    
        
    
        Adds the :any:`Microsoft.AspNet.Authentication.ClaimsTransformationMiddleware` middleware to the specified :any:`Microsoft.AspNet.Builder.IApplicationBuilder`\, which enables claims transformation capabilities.
    
        
        
        
        :param app: The  to add the middleware to.
        
        :type app: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :param transform: A function that asynchronously transforms one  to another.
        
        :type transform: System.Func{System.Security.Claims.ClaimsPrincipal,System.Threading.Tasks.Task{System.Security.Claims.ClaimsPrincipal}}
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseClaimsTransformation(IApplicationBuilder app, Func<ClaimsPrincipal, Task<ClaimsPrincipal>> transform)
    

