

MvcLocalizationServices Class
=============================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Localization.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Localization

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Localization.Internal.MvcLocalizationServices`








Syntax
------

.. code-block:: csharp

    public class MvcLocalizationServices








.. dn:class:: Microsoft.AspNetCore.Mvc.Localization.Internal.MvcLocalizationServices
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Localization.Internal.MvcLocalizationServices

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Localization.Internal.MvcLocalizationServices
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Localization.Internal.MvcLocalizationServices.AddLocalizationServices(Microsoft.Extensions.DependencyInjection.IServiceCollection, Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat, System.Action<Microsoft.Extensions.Localization.LocalizationOptions>)
    
        
    
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :type format: Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat
    
        
        :type setupAction: System.Action<System.Action`1>{Microsoft.Extensions.Localization.LocalizationOptions<Microsoft.Extensions.Localization.LocalizationOptions>}
    
        
        .. code-block:: csharp
    
            public static void AddLocalizationServices(IServiceCollection services, LanguageViewLocationExpanderFormat format, Action<LocalizationOptions> setupAction)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Localization.Internal.MvcLocalizationServices.AddMvcLocalizationServices(Microsoft.Extensions.DependencyInjection.IServiceCollection, Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat, System.Action<Microsoft.Extensions.Localization.LocalizationOptions>)
    
        
    
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :type format: Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat
    
        
        :type setupAction: System.Action<System.Action`1>{Microsoft.Extensions.Localization.LocalizationOptions<Microsoft.Extensions.Localization.LocalizationOptions>}
    
        
        .. code-block:: csharp
    
            public static void AddMvcLocalizationServices(IServiceCollection services, LanguageViewLocationExpanderFormat format, Action<LocalizationOptions> setupAction)
    

