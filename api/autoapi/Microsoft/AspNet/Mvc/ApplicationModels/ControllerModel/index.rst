

ControllerModel Class
=====================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ApplicationModels.ControllerModel`








Syntax
------

.. code-block:: csharp

   public class ControllerModel : ICommonModel, IPropertyModel, IFilterModel, IApiExplorerModel





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ApplicationModels/ControllerModel.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ApplicationModels.ControllerModel

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ApplicationModels.ControllerModel
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ApplicationModels.ControllerModel.ControllerModel(Microsoft.AspNet.Mvc.ApplicationModels.ControllerModel)
    
        
        
        
        :type other: Microsoft.AspNet.Mvc.ApplicationModels.ControllerModel
    
        
        .. code-block:: csharp
    
           public ControllerModel(ControllerModel other)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ApplicationModels.ControllerModel.ControllerModel(System.Reflection.TypeInfo, System.Collections.Generic.IReadOnlyList<System.Object>)
    
        
        
        
        :type controllerType: System.Reflection.TypeInfo
        
        
        :type attributes: System.Collections.Generic.IReadOnlyList{System.Object}
    
        
        .. code-block:: csharp
    
           public ControllerModel(TypeInfo controllerType, IReadOnlyList<object> attributes)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ApplicationModels.ControllerModel
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.ControllerModel.ActionConstraints
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraintMetadata}
    
        
        .. code-block:: csharp
    
           public IList<IActionConstraintMetadata> ActionConstraints { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.ControllerModel.Actions
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.ApplicationModels.ActionModel}
    
        
        .. code-block:: csharp
    
           public IList<ActionModel> Actions { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.ControllerModel.ApiExplorer
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Mvc.ApplicationModels.ApiExplorerModel` for this controller.
    
        
        :rtype: Microsoft.AspNet.Mvc.ApplicationModels.ApiExplorerModel
    
        
        .. code-block:: csharp
    
           public ApiExplorerModel ApiExplorer { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.ControllerModel.Application
    
        
        :rtype: Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModel
    
        
        .. code-block:: csharp
    
           public ApplicationModel Application { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.ControllerModel.AttributeRoutes
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.ApplicationModels.AttributeRouteModel}
    
        
        .. code-block:: csharp
    
           public IList<AttributeRouteModel> AttributeRoutes { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.ControllerModel.Attributes
    
        
        :rtype: System.Collections.Generic.IReadOnlyList{System.Object}
    
        
        .. code-block:: csharp
    
           public IReadOnlyList<object> Attributes { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.ControllerModel.ControllerName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ControllerName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.ControllerModel.ControllerProperties
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.ApplicationModels.PropertyModel}
    
        
        .. code-block:: csharp
    
           public IList<PropertyModel> ControllerProperties { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.ControllerModel.ControllerType
    
        
        :rtype: System.Reflection.TypeInfo
    
        
        .. code-block:: csharp
    
           public TypeInfo ControllerType { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.ControllerModel.Filters
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.Filters.IFilterMetadata}
    
        
        .. code-block:: csharp
    
           public IList<IFilterMetadata> Filters { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.ControllerModel.Microsoft.AspNet.Mvc.ApplicationModels.ICommonModel.MemberInfo
    
        
        :rtype: System.Reflection.MemberInfo
    
        
        .. code-block:: csharp
    
           MemberInfo ICommonModel.MemberInfo { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.ControllerModel.Microsoft.AspNet.Mvc.ApplicationModels.ICommonModel.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string ICommonModel.Name { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.ControllerModel.Properties
    
        
    
        Gets a set of properties associated with the controller.
        These properties will be copied to :dn:prop:`Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor.Properties`\.
    
        
        :rtype: System.Collections.Generic.IDictionary{System.Object,System.Object}
    
        
        .. code-block:: csharp
    
           public IDictionary<object, object> Properties { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.ControllerModel.RouteConstraints
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.Infrastructure.IRouteConstraintProvider}
    
        
        .. code-block:: csharp
    
           public IList<IRouteConstraintProvider> RouteConstraints { get; }
    

