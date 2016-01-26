

CorsMiddlewareExtensions Class
==============================



.. contents:: 
   :local:



Summary
-------

The :any:`Microsoft.AspNet.Builder.IApplicationBuilder` extensions for adding CORS middleware support.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Builder.CorsMiddlewareExtensions`








Syntax
------

.. code-block:: csharp

   public class CorsMiddlewareExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/cors/blob/master/src/Microsoft.AspNet.Cors/CorsMiddlewareExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Builder.CorsMiddlewareExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Builder.CorsMiddlewareExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Builder.CorsMiddlewareExtensions.UseCors(Microsoft.AspNet.Builder.IApplicationBuilder, System.Action<Microsoft.AspNet.Cors.Infrastructure.CorsPolicyBuilder>)
    
        
    
        Adds a CORS middleware to your web application pipeline to allow cross domain requests.
    
        
        
        
        :param app: The IApplicationBuilder passed to your Configure method.
        
        :type app: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :param configurePolicy: A delegate which can use a policy builder to build a policy.
        
        :type configurePolicy: System.Action{Microsoft.AspNet.Cors.Infrastructure.CorsPolicyBuilder}
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
        :return: The original app parameter
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseCors(IApplicationBuilder app, Action<CorsPolicyBuilder> configurePolicy)
    
    .. dn:method:: Microsoft.AspNet.Builder.CorsMiddlewareExtensions.UseCors(Microsoft.AspNet.Builder.IApplicationBuilder, System.String)
    
        
    
        Adds a CORS middleware to your web application pipeline to allow cross domain requests.
    
        
        
        
        :param app: The IApplicationBuilder passed to your Configure method
        
        :type app: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :param policyName: The policy name of a configured policy.
        
        :type policyName: System.String
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
        :return: The original app parameter
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseCors(IApplicationBuilder app, string policyName)
    

