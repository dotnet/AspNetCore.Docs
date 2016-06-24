

ControllerActionDescriptor Class
================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Controllers`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor`








Syntax
------

.. code-block:: csharp

    [DebuggerDisplay("{DisplayName}")]
    public class ControllerActionDescriptor : ActionDescriptor








.. dn:class:: Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor.ActionName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string ActionName { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor.ControllerName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ControllerName { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor.ControllerTypeInfo
    
        
        :rtype: System.Reflection.TypeInfo
    
        
        .. code-block:: csharp
    
            public TypeInfo ControllerTypeInfo { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor.DisplayName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string DisplayName { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor.MethodInfo
    
        
        :rtype: System.Reflection.MethodInfo
    
        
        .. code-block:: csharp
    
            public MethodInfo MethodInfo { get; set; }
    

