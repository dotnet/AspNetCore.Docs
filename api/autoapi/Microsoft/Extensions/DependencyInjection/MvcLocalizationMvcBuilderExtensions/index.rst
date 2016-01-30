

MvcLocalizationMvcBuilderExtensions Class
=========================================



.. contents:: 
   :local:



Summary
-------

Extension methods for configuring MVC view localization.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.MvcLocalizationMvcBuilderExtensions`








Syntax
------

.. code-block:: csharp

   public class MvcLocalizationMvcBuilderExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Localization/DependencyInjection/MvcLocalizationMvcBuilderExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcLocalizationMvcBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcLocalizationMvcBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcLocalizationMvcBuilderExtensions.AddViewLocalization(Microsoft.Extensions.DependencyInjection.IMvcBuilder)
    
        
    
        Adds MVC view localization to the application.
    
        
        
        
        :param builder: The .
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        :return: The <see cref="T:Microsoft.Extensions.DependencyInjection.IMvcBuilder" />.
    
        
        .. code-block:: csharp
    
           public static IMvcBuilder AddViewLocalization(IMvcBuilder builder)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcLocalizationMvcBuilderExtensions.AddViewLocalization(Microsoft.Extensions.DependencyInjection.IMvcBuilder, Microsoft.AspNet.Mvc.Razor.LanguageViewLocationExpanderFormat)
    
        
    
        Adds MVC view localization to the application.
    
        
        
        
        :param builder: The .
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        
        
        :param format: The view format for localized views.
        
        :type format: Microsoft.AspNet.Mvc.Razor.LanguageViewLocationExpanderFormat
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        :return: The <see cref="T:Microsoft.Extensions.DependencyInjection.IMvcBuilder" />.
    
        
        .. code-block:: csharp
    
           public static IMvcBuilder AddViewLocalization(IMvcBuilder builder, LanguageViewLocationExpanderFormat format)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcLocalizationMvcBuilderExtensions.AddViewLocalization(Microsoft.Extensions.DependencyInjection.IMvcBuilder, Microsoft.AspNet.Mvc.Razor.LanguageViewLocationExpanderFormat, System.Action<Microsoft.Extensions.Localization.LocalizationOptions>)
    
        
    
        Adds MVC view localization to the application.
    
        
        
        
        :param builder: The .
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        
        
        :param format: The view format for localized views.
        
        :type format: Microsoft.AspNet.Mvc.Razor.LanguageViewLocationExpanderFormat
        
        
        :param setupAction: An action to configure the .
        
        :type setupAction: System.Action{Microsoft.Extensions.Localization.LocalizationOptions}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        :return: The <see cref="T:Microsoft.Extensions.DependencyInjection.IMvcBuilder" />.
    
        
        .. code-block:: csharp
    
           public static IMvcBuilder AddViewLocalization(IMvcBuilder builder, LanguageViewLocationExpanderFormat format, Action<LocalizationOptions> setupAction)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcLocalizationMvcBuilderExtensions.AddViewLocalization(Microsoft.Extensions.DependencyInjection.IMvcBuilder, System.Action<Microsoft.Extensions.Localization.LocalizationOptions>)
    
        
    
        Adds MVC view localization to the application.
    
        
        
        
        :param builder: The .
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        
        
        :param setupAction: An action to configure the .
        
        :type setupAction: System.Action{Microsoft.Extensions.Localization.LocalizationOptions}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        :return: The <see cref="T:Microsoft.Extensions.DependencyInjection.IMvcBuilder" />.
    
        
        .. code-block:: csharp
    
           public static IMvcBuilder AddViewLocalization(IMvcBuilder builder, Action<LocalizationOptions> setupAction)
    

