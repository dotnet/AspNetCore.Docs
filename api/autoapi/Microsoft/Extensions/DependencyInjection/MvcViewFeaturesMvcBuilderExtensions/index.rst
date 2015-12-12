

MvcViewFeaturesMvcBuilderExtensions Class
=========================================



.. contents:: 
   :local:



Summary
-------

Extensions methods for configuring MVC via an :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.MvcViewFeaturesMvcBuilderExtensions`








Syntax
------

.. code-block:: csharp

   public class MvcViewFeaturesMvcBuilderExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ViewFeatures/DependencyInjection/MvcViewFeaturesMvcBuilderExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcViewFeaturesMvcBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcViewFeaturesMvcBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcViewFeaturesMvcBuilderExtensions.AddViewOptions(Microsoft.Extensions.DependencyInjection.IMvcBuilder, System.Action<Microsoft.AspNet.Mvc.MvcViewOptions>)
    
        
    
        Adds configuration of :any:`Microsoft.AspNet.Mvc.MvcViewOptions` for the application.
    
        
        
        
        :param builder: The .
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        
        
        :param setupAction: The  which need to be configured.
        
        :type setupAction: System.Action{Microsoft.AspNet.Mvc.MvcViewOptions}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcBuilder
    
        
        .. code-block:: csharp
    
           public static IMvcBuilder AddViewOptions(IMvcBuilder builder, Action<MvcViewOptions> setupAction)
    

