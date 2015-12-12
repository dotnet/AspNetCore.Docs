

ElmServiceCollectionExtensions Class
====================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.ElmServiceCollectionExtensions`








Syntax
------

.. code-block:: csharp

   public class ElmServiceCollectionExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/diagnostics/src/Microsoft.AspNet.Diagnostics.Elm/ElmServiceCollectionExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.DependencyInjection.ElmServiceCollectionExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.ElmServiceCollectionExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ElmServiceCollectionExtensions.AddElm(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        Registers an :any:`Microsoft.AspNet.Diagnostics.Elm.ElmStore` and configures default :any:`Microsoft.AspNet.Diagnostics.Elm.ElmOptions`\.
    
        
        
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
           public static IServiceCollection AddElm(IServiceCollection services)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ElmServiceCollectionExtensions.ConfigureElm(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Action<Microsoft.AspNet.Diagnostics.Elm.ElmOptions>)
    
        
    
        Configures a set of :any:`Microsoft.AspNet.Diagnostics.Elm.ElmOptions` for the application.
    
        
        
        
        :param services: The services available in the application.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        
        
        :param configureOptions: The  which need to be configured.
        
        :type configureOptions: System.Action{Microsoft.AspNet.Diagnostics.Elm.ElmOptions}
    
        
        .. code-block:: csharp
    
           public static void ConfigureElm(IServiceCollection services, Action<ElmOptions> configureOptions)
    

