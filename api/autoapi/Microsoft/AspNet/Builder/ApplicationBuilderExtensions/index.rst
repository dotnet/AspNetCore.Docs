

ApplicationBuilderExtensions Class
==================================



.. contents:: 
   :local:



Summary
-------

Extension methods for adding the :any:`Microsoft.AspNet.Localization.RequestLocalizationMiddleware` to an application.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Builder.ApplicationBuilderExtensions`








Syntax
------

.. code-block:: csharp

   public class ApplicationBuilderExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/localization/blob/master/src/Microsoft.AspNet.Localization/ApplicationBuilderExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Builder.ApplicationBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Builder.ApplicationBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Builder.ApplicationBuilderExtensions.UseRequestLocalization(Microsoft.AspNet.Builder.IApplicationBuilder, Microsoft.AspNet.Localization.RequestCulture)
    
        
    
        Adds the :any:`Microsoft.AspNet.Localization.RequestLocalizationMiddleware` to automatically set culture information for
        requests based on information provided by the client using the default options.
    
        
        
        
        :param app: The .
        
        :type app: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :param defaultRequestCulture: The default  to use if none of the
            requested cultures match supported cultures.
        
        :type defaultRequestCulture: Microsoft.AspNet.Localization.RequestCulture
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
        :return: The <see cref="T:Microsoft.AspNet.Builder.IApplicationBuilder" />.
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseRequestLocalization(IApplicationBuilder app, RequestCulture defaultRequestCulture)
    
    .. dn:method:: Microsoft.AspNet.Builder.ApplicationBuilderExtensions.UseRequestLocalization(Microsoft.AspNet.Builder.IApplicationBuilder, Microsoft.AspNet.Localization.RequestLocalizationOptions, Microsoft.AspNet.Localization.RequestCulture)
    
        
    
        Adds the :any:`Microsoft.AspNet.Localization.RequestLocalizationMiddleware` to automatically set culture information for
        requests based on information provided by the client.
    
        
        
        
        :param app: The .
        
        :type app: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :param options: The options to configure the middleware with.
        
        :type options: Microsoft.AspNet.Localization.RequestLocalizationOptions
        
        
        :param defaultRequestCulture: The default  to use if none of the
            requested cultures match supported cultures.
        
        :type defaultRequestCulture: Microsoft.AspNet.Localization.RequestCulture
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
        :return: The <see cref="T:Microsoft.AspNet.Builder.IApplicationBuilder" />.
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseRequestLocalization(IApplicationBuilder app, RequestLocalizationOptions options, RequestCulture defaultRequestCulture)
    

