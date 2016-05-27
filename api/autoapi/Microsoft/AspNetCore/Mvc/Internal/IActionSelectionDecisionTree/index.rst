

IActionSelectionDecisionTree Interface
======================================






A data structure that retrieves a list of :any:`Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor` matches based on the values
supplied for the current request by :dn:prop:`Microsoft.AspNetCore.Routing.RouteData.Values`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IActionSelectionDecisionTree








.. dn:interface:: Microsoft.AspNetCore.Mvc.Internal.IActionSelectionDecisionTree
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Internal.IActionSelectionDecisionTree

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Internal.IActionSelectionDecisionTree
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.IActionSelectionDecisionTree.Version
    
        
    
        
        Gets the version. The same as the value of
        :dn:prop:`Microsoft.AspNetCore.Mvc.Infrastructure.ActionDescriptorCollection.Version`\.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            int Version
            {
                get;
            }
    

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Internal.IActionSelectionDecisionTree
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.IActionSelectionDecisionTree.Select(System.Collections.Generic.IDictionary<System.String, System.Object>)
    
        
    
        
        Retrieves a set of :any:`Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor` based on the route values supplied by
        <em>routeValues</em>/
    
        
    
        
        :param routeValues: The route values for the current request.
        
        :type routeValues: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor<Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor>}
        :return: A set of :any:`Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor` matching the route values.
    
        
        .. code-block:: csharp
    
            IReadOnlyList<ActionDescriptor> Select(IDictionary<string, object> routeValues)
    

