

ControllersAsServices Class
===========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Internal.ControllersAsServices`








Syntax
------

.. code-block:: csharp

   public class ControllersAsServices





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Internal/ControllersAsServices.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Internal.ControllersAsServices

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Internal.ControllersAsServices
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Internal.ControllersAsServices.AddControllersAsServices(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Collections.Generic.IEnumerable<System.Reflection.Assembly>)
    
        
        
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        
        
        :type assemblies: System.Collections.Generic.IEnumerable{System.Reflection.Assembly}
    
        
        .. code-block:: csharp
    
           public static void AddControllersAsServices(IServiceCollection services, IEnumerable<Assembly> assemblies)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Internal.ControllersAsServices.AddControllersAsServices(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Collections.Generic.IEnumerable<System.Type>)
    
        
        
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        
        
        :type types: System.Collections.Generic.IEnumerable{System.Type}
    
        
        .. code-block:: csharp
    
           public static void AddControllersAsServices(IServiceCollection services, IEnumerable<Type> types)
    

