

ActionDescriptor Class
======================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor`








Syntax
------

.. code-block:: csharp

   public class ActionDescriptor





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Abstractions/Abstractions/ActionDescriptor.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor.ActionDescriptor()
    
        
    
        
        .. code-block:: csharp
    
           public ActionDescriptor()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor.ActionConstraints
    
        
    
        The set of constraints for this action. Must all be satisfied for the action to be selected.
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraintMetadata}
    
        
        .. code-block:: csharp
    
           public IList<IActionConstraintMetadata> ActionConstraints { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor.AttributeRouteInfo
    
        
        :rtype: Microsoft.AspNet.Mvc.Routing.AttributeRouteInfo
    
        
        .. code-block:: csharp
    
           public AttributeRouteInfo AttributeRouteInfo { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor.BoundProperties
    
        
    
        The set of properties which are model bound.
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.Abstractions.ParameterDescriptor}
    
        
        .. code-block:: csharp
    
           public IList<ParameterDescriptor> BoundProperties { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor.DisplayName
    
        
    
        A friendly name for this action.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public virtual string DisplayName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor.FilterDescriptors
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.Filters.FilterDescriptor}
    
        
        .. code-block:: csharp
    
           public IList<FilterDescriptor> FilterDescriptors { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor.Id
    
        
    
        Gets an id which uniquely identifies the action.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Id { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public virtual string Name { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor.Parameters
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.Abstractions.ParameterDescriptor}
    
        
        .. code-block:: csharp
    
           public IList<ParameterDescriptor> Parameters { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor.Properties
    
        
    
        Stores arbitrary metadata properties associated with the :any:`Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor`\.
    
        
        :rtype: System.Collections.Generic.IDictionary{System.Object,System.Object}
    
        
        .. code-block:: csharp
    
           public IDictionary<object, object> Properties { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor.RouteConstraints
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.Routing.RouteDataActionConstraint}
    
        
        .. code-block:: csharp
    
           public IList<RouteDataActionConstraint> RouteConstraints { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor.RouteValueDefaults
    
        
        :rtype: System.Collections.Generic.IDictionary{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           public IDictionary<string, object> RouteValueDefaults { get; }
    

