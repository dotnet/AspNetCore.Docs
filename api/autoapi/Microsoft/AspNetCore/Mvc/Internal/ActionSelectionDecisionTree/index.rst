

ActionSelectionDecisionTree Class
=================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.ActionSelectionDecisionTree`








Syntax
------

.. code-block:: csharp

    public class ActionSelectionDecisionTree : IActionSelectionDecisionTree








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ActionSelectionDecisionTree
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ActionSelectionDecisionTree

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ActionSelectionDecisionTree
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.ActionSelectionDecisionTree.ActionSelectionDecisionTree(Microsoft.AspNetCore.Mvc.Infrastructure.ActionDescriptorCollection)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.Internal.ActionSelectionDecisionTree`\.
    
        
    
        
        :param actions: The :any:`Microsoft.AspNetCore.Mvc.Infrastructure.ActionDescriptorCollection`\.
        
        :type actions: Microsoft.AspNetCore.Mvc.Infrastructure.ActionDescriptorCollection
    
        
        .. code-block:: csharp
    
            public ActionSelectionDecisionTree(ActionDescriptorCollection actions)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ActionSelectionDecisionTree
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.ActionSelectionDecisionTree.Select(System.Collections.Generic.IDictionary<System.String, System.Object>)
    
        
    
        
        :type routeValues: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor<Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor>}
    
        
        .. code-block:: csharp
    
            public IReadOnlyList<ActionDescriptor> Select(IDictionary<string, object> routeValues)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ActionSelectionDecisionTree
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.ActionSelectionDecisionTree.Version
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Version { get; }
    

