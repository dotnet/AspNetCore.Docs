

MvcViewFeaturesMvcCoreBuilderExtensions Class
=============================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.MvcViewFeaturesMvcCoreBuilderExtensions`








Syntax
------

.. code-block:: csharp

   public class MvcViewFeaturesMvcCoreBuilderExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/DependencyInjection/MvcViewFeaturesMvcCoreBuilderExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcViewFeaturesMvcCoreBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcViewFeaturesMvcCoreBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcViewFeaturesMvcCoreBuilderExtensions.AddViews(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder)
    
        
        
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
    
        
        .. code-block:: csharp
    
           public static IMvcCoreBuilder AddViews(IMvcCoreBuilder builder)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcViewFeaturesMvcCoreBuilderExtensions.AddViews(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder, System.Action<Microsoft.AspNet.Mvc.MvcViewOptions>)
    
        
        
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        
        
        :type setupAction: System.Action{Microsoft.AspNet.Mvc.MvcViewOptions}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
    
        
        .. code-block:: csharp
    
           public static IMvcCoreBuilder AddViews(IMvcCoreBuilder builder, Action<MvcViewOptions> setupAction)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcViewFeaturesMvcCoreBuilderExtensions.ConfigureViews(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder, System.Action<Microsoft.AspNet.Mvc.MvcViewOptions>)
    
        
        
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        
        
        :type setupAction: System.Action{Microsoft.AspNet.Mvc.MvcViewOptions}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
    
        
        .. code-block:: csharp
    
           public static IMvcCoreBuilder ConfigureViews(IMvcCoreBuilder builder, Action<MvcViewOptions> setupAction)
    

