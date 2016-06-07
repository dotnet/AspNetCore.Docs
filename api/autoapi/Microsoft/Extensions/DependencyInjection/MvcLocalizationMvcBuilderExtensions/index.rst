

MvcLocalizationMvcBuilderExtensions Class
=========================================






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
* :dn:cls:`Microsoft.Extensions.DependencyInjection.MvcLocalizationMvcBuilderExtensions`








Syntax
------

.. code-block:: csharp

    public class MvcLocalizationMvcBuilderExtensions








.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcLocalizationMvcBuilderExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcLocalizationMvcBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcLocalizationMvcBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcLocalizationMvcBuilderExtensions.AddViewLocalization(Microsoft.Extensions.DependencyInjection.IMvcBuilder)
    
        
    
        
        Adds MVC view localization to the application.
    
        
    
        
        :param builder: The :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IMvcBuilder AddViewLocalization(IMvcBuilder builder)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcLocalizationMvcBuilderExtensions.AddViewLocalization(Microsoft.Extensions.DependencyInjection.IMvcBuilder, Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat)
    
        
    
        
         Adds MVC view localization to the application.
    
        
    
        
        :param builder: The :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcBuilder
    
        
        :param format: The view format for localized views.
        
        :type format: Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IMvcBuilder AddViewLocalization(IMvcBuilder builder, LanguageViewLocationExpanderFormat format)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcLocalizationMvcBuilderExtensions.AddViewLocalization(Microsoft.Extensions.DependencyInjection.IMvcBuilder, Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat, System.Action<Microsoft.Extensions.Localization.LocalizationOptions>)
    
        
    
        
         Adds MVC view localization to the application.
    
        
    
        
        :param builder: The :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcBuilder
    
        
        :param format: The view format for localized views.
        
        :type format: Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat
    
        
        :param setupAction: An action to configure the :any:`Microsoft.Extensions.Localization.LocalizationOptions`\.
        
        :type setupAction: System.Action<System.Action`1>{Microsoft.Extensions.Localization.LocalizationOptions<Microsoft.Extensions.Localization.LocalizationOptions>}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IMvcBuilder AddViewLocalization(IMvcBuilder builder, LanguageViewLocationExpanderFormat format, Action<LocalizationOptions> setupAction)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcLocalizationMvcBuilderExtensions.AddViewLocalization(Microsoft.Extensions.DependencyInjection.IMvcBuilder, System.Action<Microsoft.Extensions.Localization.LocalizationOptions>)
    
        
    
        
         Adds MVC view localization to the application.
    
        
    
        
        :param builder: The :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcBuilder
    
        
        :param setupAction: An action to configure the :any:`Microsoft.Extensions.Localization.LocalizationOptions`\.
        
        :type setupAction: System.Action<System.Action`1>{Microsoft.Extensions.Localization.LocalizationOptions<Microsoft.Extensions.Localization.LocalizationOptions>}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IMvcBuilder AddViewLocalization(IMvcBuilder builder, Action<LocalizationOptions> setupAction)
    

