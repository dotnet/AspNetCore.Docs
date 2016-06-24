

ControllerActionDescriptorBuilder Class
=======================================






Creates instances of :any:`Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor` from :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModel`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.ControllerActionDescriptorBuilder`








Syntax
------

.. code-block:: csharp

    public class ControllerActionDescriptorBuilder








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionDescriptorBuilder
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionDescriptorBuilder

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionDescriptorBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionDescriptorBuilder.AddRouteValues(System.Collections.Generic.ISet<System.String>, Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor, Microsoft.AspNetCore.Mvc.ApplicationModels.ControllerModel, Microsoft.AspNetCore.Mvc.ApplicationModels.ActionModel)
    
        
    
        
        :type keys: System.Collections.Generic.ISet<System.Collections.Generic.ISet`1>{System.String<System.String>}
    
        
        :type actionDescriptor: Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor
    
        
        :type controller: Microsoft.AspNetCore.Mvc.ApplicationModels.ControllerModel
    
        
        :type action: Microsoft.AspNetCore.Mvc.ApplicationModels.ActionModel
    
        
        .. code-block:: csharp
    
            public static void AddRouteValues(ISet<string> keys, ControllerActionDescriptor actionDescriptor, ControllerModel controller, ActionModel action)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionDescriptorBuilder.Build(Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModel)
    
        
    
        
        Creates instances of :any:`Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor` from :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModel`\.
    
        
    
        
        :param application: The :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModel`\.
        
        :type application: Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModel
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor<Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor>}
        :return: The list of :any:`Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor`\.
    
        
        .. code-block:: csharp
    
            public static IList<ControllerActionDescriptor> Build(ApplicationModel application)
    

