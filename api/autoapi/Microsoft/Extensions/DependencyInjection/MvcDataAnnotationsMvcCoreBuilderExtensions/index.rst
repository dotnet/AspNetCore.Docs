

MvcDataAnnotationsMvcCoreBuilderExtensions Class
================================================






Extensions for configuring MVC data annotations using an :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.


Namespace
    :dn:ns:`Microsoft.Extensions.DependencyInjection`
Assemblies
    * Microsoft.AspNetCore.Mvc.DataAnnotations

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.MvcDataAnnotationsMvcCoreBuilderExtensions`








Syntax
------

.. code-block:: csharp

    public class MvcDataAnnotationsMvcCoreBuilderExtensions








.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcDataAnnotationsMvcCoreBuilderExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcDataAnnotationsMvcCoreBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcDataAnnotationsMvcCoreBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcDataAnnotationsMvcCoreBuilderExtensions.AddDataAnnotations(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder)
    
        
    
        
        Registers MVC data annotations.
    
        
    
        
        :param builder: The :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IMvcCoreBuilder AddDataAnnotations(this IMvcCoreBuilder builder)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcDataAnnotationsMvcCoreBuilderExtensions.AddDataAnnotationsLocalization(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder)
    
        
    
        
        Adds MVC data annotations localization to the application.
    
        
    
        
        :param builder: The :any:`Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder`\.
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IMvcCoreBuilder AddDataAnnotationsLocalization(this IMvcCoreBuilder builder)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcDataAnnotationsMvcCoreBuilderExtensions.AddDataAnnotationsLocalization(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder, System.Action<Microsoft.AspNetCore.Mvc.DataAnnotations.MvcDataAnnotationsLocalizationOptions>)
    
        
    
        
        Registers an action to configure :any:`Microsoft.AspNetCore.Mvc.DataAnnotations.MvcDataAnnotationsLocalizationOptions` for MVC data
        annotations localization.
    
        
    
        
        :param builder: The :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
    
        
        :param setupAction: An :any:`System.Action\`1`\.
        
        :type setupAction: System.Action<System.Action`1>{Microsoft.AspNetCore.Mvc.DataAnnotations.MvcDataAnnotationsLocalizationOptions<Microsoft.AspNetCore.Mvc.DataAnnotations.MvcDataAnnotationsLocalizationOptions>}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IMvcCoreBuilder AddDataAnnotationsLocalization(this IMvcCoreBuilder builder, Action<MvcDataAnnotationsLocalizationOptions> setupAction)
    

