

ActionConstraintContext Class
=============================



.. contents:: 
   :local:



Summary
-------

Context for :any:`Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraint` execution.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ActionConstraints.ActionConstraintContext`








Syntax
------

.. code-block:: csharp

   public class ActionConstraintContext





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Abstractions/ActionConstraints/ActionConstraintContext.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ActionConstraints.ActionConstraintContext

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ActionConstraints.ActionConstraintContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ActionConstraints.ActionConstraintContext.Candidates
    
        
    
        The list of :any:`Microsoft.AspNet.Mvc.ActionConstraints.ActionSelectorCandidate`\. This includes all actions that are valid for the current
        request, as well as their constraints.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Mvc.ActionConstraints.ActionSelectorCandidate}
    
        
        .. code-block:: csharp
    
           public IReadOnlyList<ActionSelectorCandidate> Candidates { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ActionConstraints.ActionConstraintContext.CurrentCandidate
    
        
    
        The current :any:`Microsoft.AspNet.Mvc.ActionConstraints.ActionSelectorCandidate`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ActionConstraints.ActionSelectorCandidate
    
        
        .. code-block:: csharp
    
           public ActionSelectorCandidate CurrentCandidate { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ActionConstraints.ActionConstraintContext.RouteContext
    
        
    
        The :dn:prop:`Microsoft.AspNet.Mvc.ActionConstraints.ActionConstraintContext.RouteContext`\.
    
        
        :rtype: Microsoft.AspNet.Routing.RouteContext
    
        
        .. code-block:: csharp
    
           public RouteContext RouteContext { get; set; }
    

