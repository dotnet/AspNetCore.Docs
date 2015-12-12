

IActionSelectionDecisionTree Interface
======================================



.. contents:: 
   :local:



Summary
-------

A data structure that retrieves a list of :any:`Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor` matches based on the values
supplied for the current request by :dn:prop:`Microsoft.AspNet.Routing.RouteData.Values`\.











Syntax
------

.. code-block:: csharp

   public interface IActionSelectionDecisionTree





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Routing/IActionSelectionDecisionTree.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Routing.IActionSelectionDecisionTree

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Routing.IActionSelectionDecisionTree
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Routing.IActionSelectionDecisionTree.Select(System.Collections.Generic.IDictionary<System.String, System.Object>)
    
        
    
        Retrieves a set of :any:`Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor` based on the route values supplied by
        ``routeValues``/
    
        
        
        
        :param routeValues: The route values for the current request.
        
        :type routeValues: System.Collections.Generic.IDictionary{System.String,System.Object}
        :rtype: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor}
        :return: A set of <see cref="T:Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor" /> matching the route values.
    
        
        .. code-block:: csharp
    
           IReadOnlyList<ActionDescriptor> Select(IDictionary<string, object> routeValues)
    

Properties
----------

.. dn:interface:: Microsoft.AspNet.Mvc.Routing.IActionSelectionDecisionTree
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Routing.IActionSelectionDecisionTree.Version
    
        
    
        Gets the version. The same as the value of 
        :dn:prop:`Microsoft.AspNet.Mvc.Infrastructure.ActionDescriptorsCollection.Version`\.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int Version { get; }
    

