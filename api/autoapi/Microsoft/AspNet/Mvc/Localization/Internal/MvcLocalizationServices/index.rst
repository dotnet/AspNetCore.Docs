

MvcLocalizationServices Class
=============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Localization.Internal.MvcLocalizationServices`








Syntax
------

.. code-block:: csharp

   public class MvcLocalizationServices





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Localization/Internal/MvcLocalizationServices.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Localization.Internal.MvcLocalizationServices

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Localization.Internal.MvcLocalizationServices
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Localization.Internal.MvcLocalizationServices.AddLocalizationServices(Microsoft.Extensions.DependencyInjection.IServiceCollection, Microsoft.AspNet.Mvc.Razor.LanguageViewLocationExpanderFormat, System.Action<Microsoft.Extensions.Localization.LocalizationOptions>)
    
        
        
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        
        
        :type format: Microsoft.AspNet.Mvc.Razor.LanguageViewLocationExpanderFormat
        
        
        :type setupAction: System.Action{Microsoft.Extensions.Localization.LocalizationOptions}
    
        
        .. code-block:: csharp
    
           public static void AddLocalizationServices(IServiceCollection services, LanguageViewLocationExpanderFormat format, Action<LocalizationOptions> setupAction)
    

