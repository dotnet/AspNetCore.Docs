

ControllerActionDescriptor Class
================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor`
* :dn:cls:`Microsoft.AspNet.Mvc.Controllers.ControllerActionDescriptor`








Syntax
------

.. code-block:: csharp

   public class ControllerActionDescriptor : ActionDescriptor





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Controllers/ControllerActionDescriptor.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Controllers.ControllerActionDescriptor

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Controllers.ControllerActionDescriptor
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Controllers.ControllerActionDescriptor.ControllerName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ControllerName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Controllers.ControllerActionDescriptor.ControllerTypeInfo
    
        
        :rtype: System.Reflection.TypeInfo
    
        
        .. code-block:: csharp
    
           public TypeInfo ControllerTypeInfo { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Controllers.ControllerActionDescriptor.DisplayName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string DisplayName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Controllers.ControllerActionDescriptor.MethodInfo
    
        
        :rtype: System.Reflection.MethodInfo
    
        
        .. code-block:: csharp
    
           public MethodInfo MethodInfo { get; set; }
    

