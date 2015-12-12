

ActionSelectorCandidate Class
=============================



.. contents:: 
   :local:



Summary
-------

A candidate action for action selection.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ActionConstraints.ActionSelectorCandidate`








Syntax
------

.. code-block:: csharp

   public class ActionSelectorCandidate





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Abstractions/ActionConstraints/ActionSelectorCandidate.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ActionConstraints.ActionSelectorCandidate

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ActionConstraints.ActionSelectorCandidate
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ActionConstraints.ActionSelectorCandidate.ActionSelectorCandidate(Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor, System.Collections.Generic.IReadOnlyList<Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraint>)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ActionConstraints.ActionSelectorCandidate`\.
    
        
        
        
        :param action: The  representing a candidate for selection.
        
        :type action: Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor
        
        
        :param constraints: The list of  instances associated with .
        
        :type constraints: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraint}
    
        
        .. code-block:: csharp
    
           public ActionSelectorCandidate(ActionDescriptor action, IReadOnlyList<IActionConstraint> constraints)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ActionConstraints.ActionSelectorCandidate
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ActionConstraints.ActionSelectorCandidate.Action
    
        
    
        The :any:`Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor` representing a candiate for selection.
    
        
        :rtype: Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor
    
        
        .. code-block:: csharp
    
           public ActionDescriptor Action { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ActionConstraints.ActionSelectorCandidate.Constraints
    
        
    
        The list of :any:`Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraint` instances associated with <see name="Action" />.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraint}
    
        
        .. code-block:: csharp
    
           public IReadOnlyList<IActionConstraint> Constraints { get; }
    

