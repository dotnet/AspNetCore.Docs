

MvcDataAnnotationsMvcBuilderExtensions Class
============================================






Extension methods for configuring MVC data annotations localization.


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
* :dn:cls:`Microsoft.Extensions.DependencyInjection.MvcDataAnnotationsMvcBuilderExtensions`








Syntax
------

.. code-block:: csharp

    public class MvcDataAnnotationsMvcBuilderExtensions








.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcDataAnnotationsMvcBuilderExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcDataAnnotationsMvcBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcDataAnnotationsMvcBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcDataAnnotationsMvcBuilderExtensions.AddDataAnnotationsLocalization(Microsoft.Extensions.DependencyInjection.IMvcBuilder)
    
        
    
        
        Adds MVC data annotations localization to the application.
    
        
    
        
        :param builder: The :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IMvcBuilder AddDataAnnotationsLocalization(IMvcBuilder builder)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcDataAnnotationsMvcBuilderExtensions.AddDataAnnotationsLocalization(Microsoft.Extensions.DependencyInjection.IMvcBuilder, System.Action<Microsoft.AspNetCore.Mvc.DataAnnotations.MvcDataAnnotationsLocalizationOptions>)
    
        
    
        
        Adds MVC data annotations localization to the application.
    
        
    
        
        :param builder: The :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcBuilder
    
        
        :param setupAction: The action to configure :any:`Microsoft.AspNetCore.Mvc.DataAnnotations.MvcDataAnnotationsLocalizationOptions`\.
            
        
        :type setupAction: System.Action<System.Action`1>{Microsoft.AspNetCore.Mvc.DataAnnotations.MvcDataAnnotationsLocalizationOptions<Microsoft.AspNetCore.Mvc.DataAnnotations.MvcDataAnnotationsLocalizationOptions>}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IMvcBuilder AddDataAnnotationsLocalization(IMvcBuilder builder, Action<MvcDataAnnotationsLocalizationOptions> setupAction)
    

