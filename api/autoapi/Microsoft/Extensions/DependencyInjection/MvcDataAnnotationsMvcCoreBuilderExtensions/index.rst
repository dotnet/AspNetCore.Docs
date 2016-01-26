

MvcDataAnnotationsMvcCoreBuilderExtensions Class
================================================



.. contents:: 
   :local:



Summary
-------

Extensions for configuring MVC data annotations using an :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.MvcDataAnnotationsMvcCoreBuilderExtensions`








Syntax
------

.. code-block:: csharp

   public class MvcDataAnnotationsMvcCoreBuilderExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.DataAnnotations/DependencyInjection/MvcDataAnnotationsMvcCoreBuilderExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcDataAnnotationsMvcCoreBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcDataAnnotationsMvcCoreBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcDataAnnotationsMvcCoreBuilderExtensions.AddDataAnnotations(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder)
    
        
    
        Registers MVC data annotations.
    
        
        
        
        :param builder: The .
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :return: The <see cref="T:Microsoft.Extensions.DependencyInjection.IMvcBuilder" />.
    
        
        .. code-block:: csharp
    
           public static IMvcCoreBuilder AddDataAnnotations(IMvcCoreBuilder builder)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcDataAnnotationsMvcCoreBuilderExtensions.AddDataAnnotationsLocalization(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder, System.Action<Microsoft.AspNet.Mvc.ModelBinding.Validation.MvcDataAnnotationsLocalizationOptions>)
    
        
    
        Registers an action to configure :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.MvcDataAnnotationsLocalizationOptions` for MVC data
        annotations localization.
    
        
        
        
        :param builder: The .
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        
        
        :param setupAction: An .
        
        :type setupAction: System.Action{Microsoft.AspNet.Mvc.ModelBinding.Validation.MvcDataAnnotationsLocalizationOptions}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :return: The <see cref="T:Microsoft.Extensions.DependencyInjection.IMvcBuilder" />.
    
        
        .. code-block:: csharp
    
           public static IMvcCoreBuilder AddDataAnnotationsLocalization(IMvcCoreBuilder builder, Action<MvcDataAnnotationsLocalizationOptions> setupAction)
    

