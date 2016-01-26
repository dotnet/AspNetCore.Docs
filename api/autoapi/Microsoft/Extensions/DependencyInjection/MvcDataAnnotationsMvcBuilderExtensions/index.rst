

MvcDataAnnotationsMvcBuilderExtensions Class
============================================



.. contents:: 
   :local:



Summary
-------

Extension methods for configuring MVC data annotations localization.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.MvcDataAnnotationsMvcBuilderExtensions`








Syntax
------

.. code-block:: csharp

   public class MvcDataAnnotationsMvcBuilderExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.DataAnnotations/DependencyInjection/MvcDataAnnotationsMvcBuilderExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcDataAnnotationsMvcBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcDataAnnotationsMvcBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcDataAnnotationsMvcBuilderExtensions.AddDataAnnotationsLocalization(Microsoft.Extensions.DependencyInjection.IMvcBuilder)
    
        
    
        Adds MVC data annotations localization to the application.
    
        
        
        
        :param builder: The .
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        :return: The <see cref="T:Microsoft.Extensions.DependencyInjection.IMvcBuilder" />.
    
        
        .. code-block:: csharp
    
           public static IMvcBuilder AddDataAnnotationsLocalization(IMvcBuilder builder)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcDataAnnotationsMvcBuilderExtensions.AddDataAnnotationsLocalization(Microsoft.Extensions.DependencyInjection.IMvcBuilder, System.Action<Microsoft.AspNet.Mvc.ModelBinding.Validation.MvcDataAnnotationsLocalizationOptions>)
    
        
    
        Adds MVC data annotations localization to the application.
    
        
        
        
        :param builder: The .
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        
        
        :param setupAction: The action to configure .
        
        :type setupAction: System.Action{Microsoft.AspNet.Mvc.ModelBinding.Validation.MvcDataAnnotationsLocalizationOptions}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        :return: The <see cref="T:Microsoft.Extensions.DependencyInjection.IMvcBuilder" />.
    
        
        .. code-block:: csharp
    
           public static IMvcBuilder AddDataAnnotationsLocalization(IMvcBuilder builder, Action<MvcDataAnnotationsLocalizationOptions> setupAction)
    

