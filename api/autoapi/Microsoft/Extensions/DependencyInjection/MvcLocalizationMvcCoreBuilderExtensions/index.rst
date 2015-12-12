

MvcLocalizationMvcCoreBuilderExtensions Class
=============================================



.. contents:: 
   :local:



Summary
-------

Extension methods for configuring MVC view localization.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.MvcLocalizationMvcCoreBuilderExtensions`








Syntax
------

.. code-block:: csharp

   public class MvcLocalizationMvcCoreBuilderExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Localization/DependencyInjection/MvcLocalizationMvcCoreBuilderExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcLocalizationMvcCoreBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcLocalizationMvcCoreBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcLocalizationMvcCoreBuilderExtensions.AddViewLocalization(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder)
    
        
    
        Adds MVC localization to the application.
    
        
        
        
        :param builder: The .
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :return: The <see cref="T:Microsoft.Extensions.DependencyInjection.IMvcBuilder" />.
    
        
        .. code-block:: csharp
    
           public static IMvcCoreBuilder AddViewLocalization(IMvcCoreBuilder builder)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcLocalizationMvcCoreBuilderExtensions.AddViewLocalization(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder, Microsoft.AspNet.Mvc.Razor.LanguageViewLocationExpanderFormat)
    
        
    
        Adds MVC localization to the application.
    
        
        
        
        :param builder: The .
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        
        
        :param format: The view format for localized views.
        
        :type format: Microsoft.AspNet.Mvc.Razor.LanguageViewLocationExpanderFormat
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :return: The <see cref="T:Microsoft.Extensions.DependencyInjection.IMvcBuilder" />.
    
        
        .. code-block:: csharp
    
           public static IMvcCoreBuilder AddViewLocalization(IMvcCoreBuilder builder, LanguageViewLocationExpanderFormat format)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcLocalizationMvcCoreBuilderExtensions.AddViewLocalization(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder, Microsoft.AspNet.Mvc.Razor.LanguageViewLocationExpanderFormat, System.Action<Microsoft.Extensions.Localization.LocalizationOptions>)
    
        
    
        Adds MVC localization to the application.
    
        
        
        
        :param builder: The .
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        
        
        :param format: The view format for localized views.
        
        :type format: Microsoft.AspNet.Mvc.Razor.LanguageViewLocationExpanderFormat
        
        
        :param setupAction: An action to configure the .
        
        :type setupAction: System.Action{Microsoft.Extensions.Localization.LocalizationOptions}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :return: The <see cref="T:Microsoft.Extensions.DependencyInjection.IMvcBuilder" />.
    
        
        .. code-block:: csharp
    
           public static IMvcCoreBuilder AddViewLocalization(IMvcCoreBuilder builder, LanguageViewLocationExpanderFormat format, Action<LocalizationOptions> setupAction)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcLocalizationMvcCoreBuilderExtensions.AddViewLocalization(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder, System.Action<Microsoft.Extensions.Localization.LocalizationOptions>)
    
        
    
        Adds MVC localization to the application.
    
        
        
        
        :param builder: The .
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        
        
        :param setupAction: An action to configure the .
        
        :type setupAction: System.Action{Microsoft.Extensions.Localization.LocalizationOptions}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :return: The <see cref="T:Microsoft.Extensions.DependencyInjection.IMvcBuilder" />.
    
        
        .. code-block:: csharp
    
           public static IMvcCoreBuilder AddViewLocalization(IMvcCoreBuilder builder, Action<LocalizationOptions> setupAction)
    

