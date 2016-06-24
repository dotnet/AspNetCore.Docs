

MvcViewFeaturesMvcBuilderExtensions Class
=========================================






Extensions methods for configuring MVC via an :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.


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
* :dn:cls:`Microsoft.Extensions.DependencyInjection.MvcViewFeaturesMvcBuilderExtensions`








Syntax
------

.. code-block:: csharp

    public class MvcViewFeaturesMvcBuilderExtensions








.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcViewFeaturesMvcBuilderExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcViewFeaturesMvcBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcViewFeaturesMvcBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcViewFeaturesMvcBuilderExtensions.AddViewComponentsAsServices(Microsoft.Extensions.DependencyInjection.IMvcBuilder)
    
        
    
        
        Registers discovered view components as services in the :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
    
        
        :param builder: The :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IMvcBuilder AddViewComponentsAsServices(this IMvcBuilder builder)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcViewFeaturesMvcBuilderExtensions.AddViewOptions(Microsoft.Extensions.DependencyInjection.IMvcBuilder, System.Action<Microsoft.AspNetCore.Mvc.MvcViewOptions>)
    
        
    
        
        Adds configuration of :any:`Microsoft.AspNetCore.Mvc.MvcViewOptions` for the application.
    
        
    
        
        :param builder: The :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcBuilder
    
        
        :param setupAction: The :any:`Microsoft.AspNetCore.Mvc.MvcViewOptions` which need to be configured.
        
        :type setupAction: System.Action<System.Action`1>{Microsoft.AspNetCore.Mvc.MvcViewOptions<Microsoft.AspNetCore.Mvc.MvcViewOptions>}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IMvcBuilder AddViewOptions(this IMvcBuilder builder, Action<MvcViewOptions> setupAction)
    

