

ActionDescriptor Class
======================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Abstractions`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor`








Syntax
------

.. code-block:: csharp

    public class ActionDescriptor








.. dn:class:: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor.ActionConstraints
    
        
    
        
        The set of constraints for this action. Must all be satisfied for the action to be selected.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraintMetadata<Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraintMetadata>}
    
        
        .. code-block:: csharp
    
            public IList<IActionConstraintMetadata> ActionConstraints
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor.AttributeRouteInfo
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Routing.AttributeRouteInfo
    
        
        .. code-block:: csharp
    
            public AttributeRouteInfo AttributeRouteInfo
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor.BoundProperties
    
        
    
        
        The set of properties which are model bound.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.Abstractions.ParameterDescriptor<Microsoft.AspNetCore.Mvc.Abstractions.ParameterDescriptor>}
    
        
        .. code-block:: csharp
    
            public IList<ParameterDescriptor> BoundProperties
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor.DisplayName
    
        
    
        
        A friendly name for this action.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string DisplayName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor.FilterDescriptors
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.Filters.FilterDescriptor<Microsoft.AspNetCore.Mvc.Filters.FilterDescriptor>}
    
        
        .. code-block:: csharp
    
            public IList<FilterDescriptor> FilterDescriptors
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor.Id
    
        
    
        
        Gets an id which uniquely identifies the action.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Id
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string Name
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor.Parameters
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.Abstractions.ParameterDescriptor<Microsoft.AspNetCore.Mvc.Abstractions.ParameterDescriptor>}
    
        
        .. code-block:: csharp
    
            public IList<ParameterDescriptor> Parameters
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor.Properties
    
        
    
        
        Stores arbitrary metadata properties associated with the :any:`Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor`\.
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.Object<System.Object>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public IDictionary<object, object> Properties
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor.RouteConstraints
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.Routing.RouteDataActionConstraint<Microsoft.AspNetCore.Mvc.Routing.RouteDataActionConstraint>}
    
        
        .. code-block:: csharp
    
            public IList<RouteDataActionConstraint> RouteConstraints
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor.RouteValueDefaults
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public IDictionary<string, object> RouteValueDefaults
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor.ActionDescriptor()
    
        
    
        
        .. code-block:: csharp
    
            public ActionDescriptor()
    

