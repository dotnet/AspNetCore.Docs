

ActionModel Class
=================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ApplicationModels.ActionModel`








Syntax
------

.. code-block:: csharp

   public class ActionModel : ICommonModel, IPropertyModel, IFilterModel, IApiExplorerModel





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ApplicationModels/ActionModel.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ApplicationModels.ActionModel

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ApplicationModels.ActionModel
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ApplicationModels.ActionModel.ActionModel(Microsoft.AspNet.Mvc.ApplicationModels.ActionModel)
    
        
        
        
        :type other: Microsoft.AspNet.Mvc.ApplicationModels.ActionModel
    
        
        .. code-block:: csharp
    
           public ActionModel(ActionModel other)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ApplicationModels.ActionModel.ActionModel(System.Reflection.MethodInfo, System.Collections.Generic.IReadOnlyList<System.Object>)
    
        
        
        
        :type actionMethod: System.Reflection.MethodInfo
        
        
        :type attributes: System.Collections.Generic.IReadOnlyList{System.Object}
    
        
        .. code-block:: csharp
    
           public ActionModel(MethodInfo actionMethod, IReadOnlyList<object> attributes)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ApplicationModels.ActionModel
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.ActionModel.ActionConstraints
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraintMetadata}
    
        
        .. code-block:: csharp
    
           public IList<IActionConstraintMetadata> ActionConstraints { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.ActionModel.ActionMethod
    
        
        :rtype: System.Reflection.MethodInfo
    
        
        .. code-block:: csharp
    
           public MethodInfo ActionMethod { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.ActionModel.ActionName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ActionName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.ActionModel.ApiExplorer
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Mvc.ApplicationModels.ApiExplorerModel` for this action.
    
        
        :rtype: Microsoft.AspNet.Mvc.ApplicationModels.ApiExplorerModel
    
        
        .. code-block:: csharp
    
           public ApiExplorerModel ApiExplorer { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.ActionModel.AttributeRouteModel
    
        
        :rtype: Microsoft.AspNet.Mvc.ApplicationModels.AttributeRouteModel
    
        
        .. code-block:: csharp
    
           public AttributeRouteModel AttributeRouteModel { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.ActionModel.Attributes
    
        
        :rtype: System.Collections.Generic.IReadOnlyList{System.Object}
    
        
        .. code-block:: csharp
    
           public IReadOnlyList<object> Attributes { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.ActionModel.Controller
    
        
        :rtype: Microsoft.AspNet.Mvc.ApplicationModels.ControllerModel
    
        
        .. code-block:: csharp
    
           public ControllerModel Controller { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.ActionModel.Filters
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.Filters.IFilterMetadata}
    
        
        .. code-block:: csharp
    
           public IList<IFilterMetadata> Filters { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.ActionModel.HttpMethods
    
        
        :rtype: System.Collections.Generic.IList{System.String}
    
        
        .. code-block:: csharp
    
           public IList<string> HttpMethods { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.ActionModel.Microsoft.AspNet.Mvc.ApplicationModels.ICommonModel.MemberInfo
    
        
        :rtype: System.Reflection.MemberInfo
    
        
        .. code-block:: csharp
    
           MemberInfo ICommonModel.MemberInfo { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.ActionModel.Microsoft.AspNet.Mvc.ApplicationModels.ICommonModel.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string ICommonModel.Name { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.ActionModel.Parameters
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.ApplicationModels.ParameterModel}
    
        
        .. code-block:: csharp
    
           public IList<ParameterModel> Parameters { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.ActionModel.Properties
    
        
    
        Gets a set of properties associated with the action.
        These properties will be copied to :dn:prop:`Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor.Properties`\.
    
        
        :rtype: System.Collections.Generic.IDictionary{System.Object,System.Object}
    
        
        .. code-block:: csharp
    
           public IDictionary<object, object> Properties { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.ActionModel.RouteConstraints
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.Infrastructure.IRouteConstraintProvider}
    
        
        .. code-block:: csharp
    
           public IList<IRouteConstraintProvider> RouteConstraints { get; }
    

