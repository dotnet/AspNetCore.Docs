

ActionModel Class
=================





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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ApplicationModels.ActionModel`








Syntax
------

.. code-block:: csharp

    [DebuggerDisplay("{Controller.ControllerType.Name}.{ActionMethod.Name}")]
    public class ActionModel : ICommonModel, IPropertyModel, IFilterModel, IApiExplorerModel








.. dn:class:: Microsoft.AspNetCore.Mvc.ApplicationModels.ActionModel
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ApplicationModels.ActionModel

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ApplicationModels.ActionModel
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ApplicationModels.ActionModel.ActionModel(Microsoft.AspNetCore.Mvc.ApplicationModels.ActionModel)
    
        
    
        
        :type other: Microsoft.AspNetCore.Mvc.ApplicationModels.ActionModel
    
        
        .. code-block:: csharp
    
            public ActionModel(ActionModel other)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ApplicationModels.ActionModel.ActionModel(System.Reflection.MethodInfo, System.Collections.Generic.IReadOnlyList<System.Object>)
    
        
    
        
        :type actionMethod: System.Reflection.MethodInfo
    
        
        :type attributes: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public ActionModel(MethodInfo actionMethod, IReadOnlyList<object> attributes)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ApplicationModels.ActionModel
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.ActionModel.ActionMethod
    
        
        :rtype: System.Reflection.MethodInfo
    
        
        .. code-block:: csharp
    
            public MethodInfo ActionMethod { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.ActionModel.ActionName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ActionName { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.ActionModel.ApiExplorer
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.ApiExplorerModel` for this action.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ApplicationModels.ApiExplorerModel
    
        
        .. code-block:: csharp
    
            public ApiExplorerModel ApiExplorer { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.ActionModel.Attributes
    
        
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public IReadOnlyList<object> Attributes { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.ActionModel.Controller
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ApplicationModels.ControllerModel
    
        
        .. code-block:: csharp
    
            public ControllerModel Controller { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.ActionModel.Filters
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata<Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata>}
    
        
        .. code-block:: csharp
    
            public IList<IFilterMetadata> Filters { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.ActionModel.Microsoft.AspNetCore.Mvc.ApplicationModels.ICommonModel.MemberInfo
    
        
        :rtype: System.Reflection.MemberInfo
    
        
        .. code-block:: csharp
    
            MemberInfo ICommonModel.MemberInfo { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.ActionModel.Microsoft.AspNetCore.Mvc.ApplicationModels.ICommonModel.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string ICommonModel.Name { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.ActionModel.Parameters
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.ApplicationModels.ParameterModel<Microsoft.AspNetCore.Mvc.ApplicationModels.ParameterModel>}
    
        
        .. code-block:: csharp
    
            public IList<ParameterModel> Parameters { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.ActionModel.Properties
    
        
    
        
        Gets a set of properties associated with the action.
        These properties will be copied to :dn:prop:`Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor.Properties`\.
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.Object<System.Object>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public IDictionary<object, object> Properties { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.ActionModel.RouteValues
    
        
    
        
        Gets a collection of route values that must be present in the 
        :dn:prop:`Microsoft.AspNetCore.Routing.RouteData.Values` for the corresponding action to be selected.
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IDictionary<string, string> RouteValues { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.ActionModel.Selectors
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.ApplicationModels.SelectorModel<Microsoft.AspNetCore.Mvc.ApplicationModels.SelectorModel>}
    
        
        .. code-block:: csharp
    
            public IList<SelectorModel> Selectors { get; }
    

