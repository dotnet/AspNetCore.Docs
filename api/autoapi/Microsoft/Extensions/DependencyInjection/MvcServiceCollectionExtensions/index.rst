

MvcServiceCollectionExtensions Class
====================================



.. contents:: 
   :local:



Summary
-------

Extension methods for setting up MVC services in an :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions`








Syntax
------

.. code-block:: csharp

   public class MvcServiceCollectionExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc/MvcServiceCollectionExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddMvc(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        Adds MVC services to the specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
        
        
        :param services: The  to add services to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
           public static IMvcBuilder AddMvc(IServiceCollection services)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddMvc(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Action<Microsoft.AspNet.Mvc.MvcOptions>)
    
        
    
        Adds MVC services to the specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
        
        
        :param services: The  to add services to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        
        
        :param setupAction: An action delegate to configure the provided .
        
        :type setupAction: System.Action{Microsoft.AspNet.Mvc.MvcOptions}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
           public static IMvcBuilder AddMvc(IServiceCollection services, Action<MvcOptions> setupAction)
    

