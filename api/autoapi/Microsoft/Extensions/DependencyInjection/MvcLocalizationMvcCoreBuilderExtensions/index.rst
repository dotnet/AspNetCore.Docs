

MvcLocalizationMvcCoreBuilderExtensions Class
=============================================






Extension methods for configuring MVC view localization.


Namespace
    :dn:ns:`Microsoft.Extensions.DependencyInjection`
Assemblies
    * Microsoft.AspNetCore.Mvc.Localization

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.MvcLocalizationMvcCoreBuilderExtensions`








Syntax
------

.. code-block:: csharp

    public class MvcLocalizationMvcCoreBuilderExtensions








.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcLocalizationMvcCoreBuilderExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcLocalizationMvcCoreBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcLocalizationMvcCoreBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcLocalizationMvcCoreBuilderExtensions.AddViewLocalization(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder)
    
        
    
        
        Adds MVC localization to the application.
    
        
    
        
        :param builder: The :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IMvcCoreBuilder AddViewLocalization(IMvcCoreBuilder builder)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcLocalizationMvcCoreBuilderExtensions.AddViewLocalization(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder, Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat)
    
        
    
        
         Adds MVC localization to the application.
    
        
    
        
        :param builder: The :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
    
        
        :param format: The view format for localized views.
        
        :type format: Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IMvcCoreBuilder AddViewLocalization(IMvcCoreBuilder builder, LanguageViewLocationExpanderFormat format)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcLocalizationMvcCoreBuilderExtensions.AddViewLocalization(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder, Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat, System.Action<Microsoft.Extensions.Localization.LocalizationOptions>)
    
        
    
        
         Adds MVC localization to the application.
    
        
    
        
        :param builder: The :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
    
        
        :param format: The view format for localized views.
        
        :type format: Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat
    
        
        :param setupAction: An action to configure the :any:`Microsoft.Extensions.Localization.LocalizationOptions`\.
        
        :type setupAction: System.Action<System.Action`1>{Microsoft.Extensions.Localization.LocalizationOptions<Microsoft.Extensions.Localization.LocalizationOptions>}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IMvcCoreBuilder AddViewLocalization(IMvcCoreBuilder builder, LanguageViewLocationExpanderFormat format, Action<LocalizationOptions> setupAction)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcLocalizationMvcCoreBuilderExtensions.AddViewLocalization(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder, System.Action<Microsoft.Extensions.Localization.LocalizationOptions>)
    
        
    
        
        Adds MVC localization to the application.
    
        
    
        
        :param builder: The :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
    
        
        :param setupAction: An action to configure the :any:`Microsoft.Extensions.Localization.LocalizationOptions`\.
        
        :type setupAction: System.Action<System.Action`1>{Microsoft.Extensions.Localization.LocalizationOptions<Microsoft.Extensions.Localization.LocalizationOptions>}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IMvcCoreBuilder AddViewLocalization(IMvcCoreBuilder builder, Action<LocalizationOptions> setupAction)
    

