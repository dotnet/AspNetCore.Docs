

MvcJsonMvcBuilderExtensions Class
=================================



.. contents:: 
   :local:



Summary
-------

Extensions methods for configuring MVC via an :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.MvcJsonMvcBuilderExtensions`








Syntax
------

.. code-block:: csharp

   public class MvcJsonMvcBuilderExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Formatters.Json/DependencyInjection/MvcJsonMvcBuilderExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcJsonMvcBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcJsonMvcBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcJsonMvcBuilderExtensions.AddJsonOptions(Microsoft.Extensions.DependencyInjection.IMvcBuilder, System.Action<Microsoft.AspNet.Mvc.MvcJsonOptions>)
    
        
    
        Adds configuration of :any:`Microsoft.AspNet.Mvc.MvcJsonOptions` for the application.
    
        
        
        
        :param builder: The .
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        
        
        :param setupAction: The  which need to be configured.
        
        :type setupAction: System.Action{Microsoft.AspNet.Mvc.MvcJsonOptions}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcBuilder
    
        
        .. code-block:: csharp
    
           public static IMvcBuilder AddJsonOptions(IMvcBuilder builder, Action<MvcJsonOptions> setupAction)
    

