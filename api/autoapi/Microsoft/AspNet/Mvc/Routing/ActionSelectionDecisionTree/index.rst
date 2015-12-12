

ActionSelectionDecisionTree Class
=================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Routing.ActionSelectionDecisionTree`








Syntax
------

.. code-block:: csharp

   public class ActionSelectionDecisionTree : IActionSelectionDecisionTree





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Routing/ActionSelectionDecisionTree.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Routing.ActionSelectionDecisionTree

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Routing.ActionSelectionDecisionTree
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Routing.ActionSelectionDecisionTree.ActionSelectionDecisionTree(Microsoft.AspNet.Mvc.Infrastructure.ActionDescriptorsCollection)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.Routing.ActionSelectionDecisionTree`\.
    
        
        
        
        :param actions: The .
        
        :type actions: Microsoft.AspNet.Mvc.Infrastructure.ActionDescriptorsCollection
    
        
        .. code-block:: csharp
    
           public ActionSelectionDecisionTree(ActionDescriptorsCollection actions)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Routing.ActionSelectionDecisionTree
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Routing.ActionSelectionDecisionTree.Select(System.Collections.Generic.IDictionary<System.String, System.Object>)
    
        
        
        
        :type routeValues: System.Collections.Generic.IDictionary{System.String,System.Object}
        :rtype: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor}
    
        
        .. code-block:: csharp
    
           public IReadOnlyList<ActionDescriptor> Select(IDictionary<string, object> routeValues)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Routing.ActionSelectionDecisionTree
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Routing.ActionSelectionDecisionTree.Version
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Version { get; }
    

