

MvcRazorMvcCoreBuilderExtensions Class
======================================



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





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Razor/DependencyInjection/MvcRazorMvcCoreBuilderExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcRazorMvcCoreBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcRazorMvcCoreBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcRazorMvcCoreBuilderExtensions.AddPrecompiledRazorViews(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder, System.Reflection.Assembly[])
    
        
        
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        
        
        :type assemblies: System.Reflection.Assembly[]
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
    
        
        .. code-block:: csharp
    
           public static IMvcCoreBuilder AddPrecompiledRazorViews(IMvcCoreBuilder builder, params Assembly[] assemblies)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcRazorMvcCoreBuilderExtensions.AddRazorViewEngine(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder)
    
        
        
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
    
        
        .. code-block:: csharp
    
           public static IMvcCoreBuilder AddRazorViewEngine(IMvcCoreBuilder builder)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcRazorMvcCoreBuilderExtensions.AddRazorViewEngine(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder, System.Action<Microsoft.AspNet.Mvc.Razor.RazorViewEngineOptions>)
    
        
        
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        
        
        :type setupAction: System.Action{Microsoft.AspNet.Mvc.Razor.RazorViewEngineOptions}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
    
        
        .. code-block:: csharp
    
           public static IMvcCoreBuilder AddRazorViewEngine(IMvcCoreBuilder builder, Action<RazorViewEngineOptions> setupAction)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcRazorMvcCoreBuilderExtensions.InitializeTagHelper<TTagHelper>(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder, System.Action<TTagHelper, Microsoft.AspNet.Mvc.Rendering.ViewContext>)
    
        
    
        Adds an initialization callback for a given ``TTagHelper``.
    
        
        
        
        :param builder: The  instance this method extends.
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        
        
        :param initialize: An action to initialize the .
        
        :type initialize: System.Action{{TTagHelper},Microsoft.AspNet.Mvc.Rendering.ViewContext}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :return: The <see cref="T:Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder" /> instance this method extends.
    
        
        .. code-block:: csharp
    
           public static IMvcCoreBuilder InitializeTagHelper<TTagHelper>(IMvcCoreBuilder builder, Action<TTagHelper, ViewContext> initialize)where TTagHelper : ITagHelper
    

