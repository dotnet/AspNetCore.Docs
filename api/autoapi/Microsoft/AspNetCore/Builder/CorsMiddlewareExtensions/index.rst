

CorsMiddlewareExtensions Class
==============================






The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` extensions for adding CORS middleware support.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.Cors

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Builder.CorsMiddlewareExtensions`








Syntax
------

.. code-block:: csharp

    public class CorsMiddlewareExtensions








.. dn:class:: Microsoft.AspNetCore.Builder.CorsMiddlewareExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.CorsMiddlewareExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Builder.CorsMiddlewareExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Builder.CorsMiddlewareExtensions.UseCors(Microsoft.AspNetCore.Builder.IApplicationBuilder, System.Action<Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder>)
    
        
    
        
        Adds a CORS middleware to your web application pipeline to allow cross domain requests.
    
        
    
        
        :param app: The IApplicationBuilder passed to your Configure method.
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :param configurePolicy: A delegate which can use a policy builder to build a policy.
        
        :type configurePolicy: System.Action<System.Action`1>{Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder<Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder>}
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :return: The original app parameter
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseCors(this IApplicationBuilder app, Action<CorsPolicyBuilder> configurePolicy)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.CorsMiddlewareExtensions.UseCors(Microsoft.AspNetCore.Builder.IApplicationBuilder, System.String)
    
        
    
        
        Adds a CORS middleware to your web application pipeline to allow cross domain requests.
    
        
    
        
        :param app: The IApplicationBuilder passed to your Configure method
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :param policyName: The policy name of a configured policy.
        
        :type policyName: System.String
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :return: The original app parameter
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseCors(this IApplicationBuilder app, string policyName)
    

