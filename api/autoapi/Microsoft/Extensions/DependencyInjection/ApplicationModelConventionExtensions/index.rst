

ApplicationModelConventionExtensions Class
==========================================



.. contents:: 
   :local:



Summary
-------

Contains the extension methods for :dn:prop:`Microsoft.AspNet.Mvc.MvcOptions.Conventions`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.ApplicationModelConventionExtensions`








Syntax
------

.. code-block:: csharp

   public class ApplicationModelConventionExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/DependencyInjection/ApplicationModelConventionExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.DependencyInjection.ApplicationModelConventionExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.ApplicationModelConventionExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ApplicationModelConventionExtensions.Add(System.Collections.Generic.IList<Microsoft.AspNet.Mvc.ApplicationModels.IApplicationModelConvention>, Microsoft.AspNet.Mvc.ApplicationModels.IActionModelConvention)
    
        
    
        Adds a :any:`Microsoft.AspNet.Mvc.ApplicationModels.IActionModelConvention` to all the actions in the application.
    
        
        
        
        :param conventions: The list of
            in .
        
        :type conventions: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.ApplicationModels.IApplicationModelConvention}
        
        
        :param actionModelConvention: The  which needs to be
            added.
        
        :type actionModelConvention: Microsoft.AspNet.Mvc.ApplicationModels.IActionModelConvention
    
        
        .. code-block:: csharp
    
           public static void Add(IList<IApplicationModelConvention> conventions, IActionModelConvention actionModelConvention)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ApplicationModelConventionExtensions.Add(System.Collections.Generic.IList<Microsoft.AspNet.Mvc.ApplicationModels.IApplicationModelConvention>, Microsoft.AspNet.Mvc.ApplicationModels.IControllerModelConvention)
    
        
    
        Adds a :any:`Microsoft.AspNet.Mvc.ApplicationModels.IControllerModelConvention` to all the controllers in the application.
    
        
        
        
        :param conventions: The list of
            in .
        
        :type conventions: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.ApplicationModels.IApplicationModelConvention}
        
        
        :param controllerModelConvention: The  which needs to be
            added.
        
        :type controllerModelConvention: Microsoft.AspNet.Mvc.ApplicationModels.IControllerModelConvention
    
        
        .. code-block:: csharp
    
           public static void Add(IList<IApplicationModelConvention> conventions, IControllerModelConvention controllerModelConvention)
    

