

MvcViewFeaturesMvcCoreBuilderExtensions Class
=============================================





Namespace
    :dn:ns:`Microsoft.Extensions.DependencyInjection`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

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








.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcViewFeaturesMvcCoreBuilderExtensions
    :hidden:

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
    
            public static IMvcCoreBuilder AddViews(this IMvcCoreBuilder builder)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcViewFeaturesMvcCoreBuilderExtensions.AddViews(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder, System.Action<Microsoft.AspNetCore.Mvc.MvcViewOptions>)
    
        
    
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
    
        
        :type setupAction: System.Action<System.Action`1>{Microsoft.AspNetCore.Mvc.MvcViewOptions<Microsoft.AspNetCore.Mvc.MvcViewOptions>}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
    
        
        .. code-block:: csharp
    
            public static IMvcCoreBuilder AddViews(this IMvcCoreBuilder builder, Action<MvcViewOptions> setupAction)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcViewFeaturesMvcCoreBuilderExtensions.ConfigureViews(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder, System.Action<Microsoft.AspNetCore.Mvc.MvcViewOptions>)
    
        
    
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
    
        
        :type setupAction: System.Action<System.Action`1>{Microsoft.AspNetCore.Mvc.MvcViewOptions<Microsoft.AspNetCore.Mvc.MvcViewOptions>}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
    
        
        .. code-block:: csharp
    
            public static IMvcCoreBuilder ConfigureViews(this IMvcCoreBuilder builder, Action<MvcViewOptions> setupAction)
    

