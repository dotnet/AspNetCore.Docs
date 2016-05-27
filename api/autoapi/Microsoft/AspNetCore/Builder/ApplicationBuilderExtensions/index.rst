

ApplicationBuilderExtensions Class
==================================






Extension methods for adding the :any:`Microsoft.AspNetCore.Localization.RequestLocalizationMiddleware` to an application.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.Localization

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Builder.ApplicationBuilderExtensions`








Syntax
------

.. code-block:: csharp

    public class ApplicationBuilderExtensions








.. dn:class:: Microsoft.AspNetCore.Builder.ApplicationBuilderExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.ApplicationBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Builder.ApplicationBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Builder.ApplicationBuilderExtensions.UseRequestLocalization(Microsoft.AspNetCore.Builder.IApplicationBuilder)
    
        
    
        
        Adds the :any:`Microsoft.AspNetCore.Localization.RequestLocalizationMiddleware` to automatically set culture information for
        requests based on information provided by the client.
    
        
    
        
        :param app: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder`\.
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :return: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseRequestLocalization(IApplicationBuilder app)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.ApplicationBuilderExtensions.UseRequestLocalization(Microsoft.AspNetCore.Builder.IApplicationBuilder, Microsoft.AspNetCore.Builder.RequestLocalizationOptions)
    
        
    
        
        Adds the :any:`Microsoft.AspNetCore.Localization.RequestLocalizationMiddleware` to automatically set culture information for
        requests based on information provided by the client.
    
        
    
        
        :param app: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder`\.
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :param options: The :any:`Microsoft.AspNetCore.Builder.RequestLocalizationOptions` to configure the middleware with.
        
        :type options: Microsoft.AspNetCore.Builder.RequestLocalizationOptions
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :return: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseRequestLocalization(IApplicationBuilder app, RequestLocalizationOptions options)
    

