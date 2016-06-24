

ApplicationModelConventionExtensions Class
==========================================






Contains the extension methods for :dn:prop:`Microsoft.AspNetCore.Mvc.MvcOptions.Conventions`\.


Namespace
    :dn:ns:`Microsoft.Extensions.DependencyInjection`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.ApplicationModelConventionExtensions`








Syntax
------

.. code-block:: csharp

    public class ApplicationModelConventionExtensions








.. dn:class:: Microsoft.Extensions.DependencyInjection.ApplicationModelConventionExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.ApplicationModelConventionExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.ApplicationModelConventionExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ApplicationModelConventionExtensions.Add(System.Collections.Generic.IList<Microsoft.AspNetCore.Mvc.ApplicationModels.IApplicationModelConvention>, Microsoft.AspNetCore.Mvc.ApplicationModels.IActionModelConvention)
    
        
    
        
        Adds a :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.IActionModelConvention` to all the actions in the application.
    
        
    
        
        :param conventions: The list of :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.IApplicationModelConvention`
            in :any:`Microsoft.AspNetCore.Mvc.MvcOptions`\.
        
        :type conventions: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.ApplicationModels.IApplicationModelConvention<Microsoft.AspNetCore.Mvc.ApplicationModels.IApplicationModelConvention>}
    
        
        :param actionModelConvention: The :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.IActionModelConvention` which needs to be
            added.
        
        :type actionModelConvention: Microsoft.AspNetCore.Mvc.ApplicationModels.IActionModelConvention
    
        
        .. code-block:: csharp
    
            public static void Add(this IList<IApplicationModelConvention> conventions, IActionModelConvention actionModelConvention)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ApplicationModelConventionExtensions.Add(System.Collections.Generic.IList<Microsoft.AspNetCore.Mvc.ApplicationModels.IApplicationModelConvention>, Microsoft.AspNetCore.Mvc.ApplicationModels.IControllerModelConvention)
    
        
    
        
        Adds a :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.IControllerModelConvention` to all the controllers in the application.
    
        
    
        
        :param conventions: The list of :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.IApplicationModelConvention`
            in :any:`Microsoft.AspNetCore.Mvc.MvcOptions`\.
        
        :type conventions: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.ApplicationModels.IApplicationModelConvention<Microsoft.AspNetCore.Mvc.ApplicationModels.IApplicationModelConvention>}
    
        
        :param controllerModelConvention: The :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.IControllerModelConvention` which needs to be
            added.
        
        :type controllerModelConvention: Microsoft.AspNetCore.Mvc.ApplicationModels.IControllerModelConvention
    
        
        .. code-block:: csharp
    
            public static void Add(this IList<IApplicationModelConvention> conventions, IControllerModelConvention controllerModelConvention)
    

