

ControllerModel Class
=====================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ApplicationModels`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ApplicationModels.ControllerModel`








Syntax
------

.. code-block:: csharp

    [DebuggerDisplay("Name={ControllerName}, Type={ControllerType.Name}")]
    public class ControllerModel : ICommonModel, IPropertyModel, IFilterModel, IApiExplorerModel








.. dn:class:: Microsoft.AspNetCore.Mvc.ApplicationModels.ControllerModel
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ApplicationModels.ControllerModel

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ApplicationModels.ControllerModel
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ApplicationModels.ControllerModel.ControllerModel(Microsoft.AspNetCore.Mvc.ApplicationModels.ControllerModel)
    
        
    
        
        :type other: Microsoft.AspNetCore.Mvc.ApplicationModels.ControllerModel
    
        
        .. code-block:: csharp
    
            public ControllerModel(ControllerModel other)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ApplicationModels.ControllerModel.ControllerModel(System.Reflection.TypeInfo, System.Collections.Generic.IReadOnlyList<System.Object>)
    
        
    
        
        :type controllerType: System.Reflection.TypeInfo
    
        
        :type attributes: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public ControllerModel(TypeInfo controllerType, IReadOnlyList<object> attributes)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ApplicationModels.ControllerModel
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.ControllerModel.Actions
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.ApplicationModels.ActionModel<Microsoft.AspNetCore.Mvc.ApplicationModels.ActionModel>}
    
        
        .. code-block:: csharp
    
            public IList<ActionModel> Actions { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.ControllerModel.ApiExplorer
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.ApiExplorerModel` for this controller.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ApplicationModels.ApiExplorerModel
    
        
        .. code-block:: csharp
    
            public ApiExplorerModel ApiExplorer { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.ControllerModel.Application
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModel
    
        
        .. code-block:: csharp
    
            public ApplicationModel Application { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.ControllerModel.Attributes
    
        
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public IReadOnlyList<object> Attributes { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.ControllerModel.ControllerName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ControllerName { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.ControllerModel.ControllerProperties
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.ApplicationModels.PropertyModel<Microsoft.AspNetCore.Mvc.ApplicationModels.PropertyModel>}
    
        
        .. code-block:: csharp
    
            public IList<PropertyModel> ControllerProperties { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.ControllerModel.ControllerType
    
        
        :rtype: System.Reflection.TypeInfo
    
        
        .. code-block:: csharp
    
            public TypeInfo ControllerType { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.ControllerModel.Filters
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata<Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata>}
    
        
        .. code-block:: csharp
    
            public IList<IFilterMetadata> Filters { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.ControllerModel.Microsoft.AspNetCore.Mvc.ApplicationModels.ICommonModel.MemberInfo
    
        
        :rtype: System.Reflection.MemberInfo
    
        
        .. code-block:: csharp
    
            MemberInfo ICommonModel.MemberInfo { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.ControllerModel.Microsoft.AspNetCore.Mvc.ApplicationModels.ICommonModel.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string ICommonModel.Name { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.ControllerModel.Properties
    
        
    
        
        Gets a set of properties associated with the controller.
        These properties will be copied to :dn:prop:`Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor.Properties`\.
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.Object<System.Object>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public IDictionary<object, object> Properties { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.ControllerModel.RouteValues
    
        
    
        
        Gets a collection of route values that must be present in the 
        :dn:prop:`Microsoft.AspNetCore.Routing.RouteData.Values` for the corresponding action to be selected.
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IDictionary<string, string> RouteValues { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.ControllerModel.Selectors
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.ApplicationModels.SelectorModel<Microsoft.AspNetCore.Mvc.ApplicationModels.SelectorModel>}
    
        
        .. code-block:: csharp
    
            public IList<SelectorModel> Selectors { get; }
    

