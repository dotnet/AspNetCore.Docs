

ControllerActionDescriptorBuilder Class
=======================================



.. contents:: 
   :local:



Summary
-------

Creates instances of :any:`Microsoft.AspNet.Mvc.Controllers.ControllerActionDescriptor` from :any:`Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModel`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Controllers.ControllerActionDescriptorBuilder`








Syntax
------

.. code-block:: csharp

   public class ControllerActionDescriptorBuilder





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/Controllers/ControllerActionDescriptorBuilder.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Controllers.ControllerActionDescriptorBuilder

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Controllers.ControllerActionDescriptorBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Controllers.ControllerActionDescriptorBuilder.AddRouteConstraints(System.Collections.Generic.ISet<System.String>, Microsoft.AspNet.Mvc.Controllers.ControllerActionDescriptor, Microsoft.AspNet.Mvc.ApplicationModels.ControllerModel, Microsoft.AspNet.Mvc.ApplicationModels.ActionModel)
    
        
        
        
        :type removalConstraints: System.Collections.Generic.ISet{System.String}
        
        
        :type actionDescriptor: Microsoft.AspNet.Mvc.Controllers.ControllerActionDescriptor
        
        
        :type controller: Microsoft.AspNet.Mvc.ApplicationModels.ControllerModel
        
        
        :type action: Microsoft.AspNet.Mvc.ApplicationModels.ActionModel
    
        
        .. code-block:: csharp
    
           public static void AddRouteConstraints(ISet<string> removalConstraints, ControllerActionDescriptor actionDescriptor, ControllerModel controller, ActionModel action)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controllers.ControllerActionDescriptorBuilder.Build(Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModel)
    
        
    
        Creates instances of :any:`Microsoft.AspNet.Mvc.Controllers.ControllerActionDescriptor` from :any:`Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModel`\.
    
        
        
        
        :param application: The .
        
        :type application: Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModel
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.Controllers.ControllerActionDescriptor}
        :return: The list of <see cref="T:Microsoft.AspNet.Mvc.Controllers.ControllerActionDescriptor" />.
    
        
        .. code-block:: csharp
    
           public static IList<ControllerActionDescriptor> Build(ApplicationModel application)
    

