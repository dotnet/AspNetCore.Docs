

MvcRazorMvcCoreBuilderExtensions Class
======================================





Namespace
    :dn:ns:`Microsoft.Extensions.DependencyInjection`
Assemblies
    * Microsoft.AspNetCore.Mvc.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.MvcRazorMvcCoreBuilderExtensions`








Syntax
------

.. code-block:: csharp

    public class MvcRazorMvcCoreBuilderExtensions








.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcRazorMvcCoreBuilderExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcRazorMvcCoreBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcRazorMvcCoreBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcRazorMvcCoreBuilderExtensions.AddRazorViewEngine(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder)
    
        
    
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
    
        
        .. code-block:: csharp
    
            public static IMvcCoreBuilder AddRazorViewEngine(IMvcCoreBuilder builder)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcRazorMvcCoreBuilderExtensions.AddRazorViewEngine(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder, System.Action<Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions>)
    
        
    
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
    
        
        :type setupAction: System.Action<System.Action`1>{Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions<Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions>}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
    
        
        .. code-block:: csharp
    
            public static IMvcCoreBuilder AddRazorViewEngine(IMvcCoreBuilder builder, Action<RazorViewEngineOptions> setupAction)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcRazorMvcCoreBuilderExtensions.AddTagHelpersAsServices(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder)
    
        
    
        
        Registers discovered tag helpers as services and changes the existing :any:`Microsoft.AspNetCore.Mvc.Razor.ITagHelperActivator`
        for an :any:`Microsoft.AspNetCore.Mvc.Razor.Internal.ServiceBasedTagHelperActivator`\.
    
        
    
        
        :param builder: The :any:`Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder` instance this method extends.
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder` instance this method extends.
    
        
        .. code-block:: csharp
    
            public static IMvcCoreBuilder AddTagHelpersAsServices(IMvcCoreBuilder builder)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcRazorMvcCoreBuilderExtensions.InitializeTagHelper<TTagHelper>(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder, System.Action<TTagHelper, Microsoft.AspNetCore.Mvc.Rendering.ViewContext>)
    
        
    
        
        Adds an initialization callback for a given <em>TTagHelper</em>.
    
        
    
        
        :param builder: The :any:`Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder` instance this method extends.
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
    
        
        :param initialize: An action to initialize the <em>TTagHelper</em>.
        
        :type initialize: System.Action<System.Action`2>{TTagHelper, Microsoft.AspNetCore.Mvc.Rendering.ViewContext<Microsoft.AspNetCore.Mvc.Rendering.ViewContext>}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder` instance this method extends.
    
        
        .. code-block:: csharp
    
            public static IMvcCoreBuilder InitializeTagHelper<TTagHelper>(IMvcCoreBuilder builder, Action<TTagHelper, ViewContext> initialize)where TTagHelper : ITagHelper
    

