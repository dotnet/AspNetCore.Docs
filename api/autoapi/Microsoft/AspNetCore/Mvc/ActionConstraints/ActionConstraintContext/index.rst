

ActionConstraintContext Class
=============================






Context for :any:`Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraint` execution.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ActionConstraints`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintContext`








Syntax
------

.. code-block:: csharp

    public class ActionConstraintContext








.. dn:class:: Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintContext.Candidates
    
        
    
        
        The list of :any:`Microsoft.AspNetCore.Mvc.ActionConstraints.ActionSelectorCandidate`\. This includes all actions that are valid for the current
        request, as well as their constraints.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Mvc.ActionConstraints.ActionSelectorCandidate<Microsoft.AspNetCore.Mvc.ActionConstraints.ActionSelectorCandidate>}
    
        
        .. code-block:: csharp
    
            public IReadOnlyList<ActionSelectorCandidate> Candidates
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintContext.CurrentCandidate
    
        
    
        
        The current :any:`Microsoft.AspNetCore.Mvc.ActionConstraints.ActionSelectorCandidate`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ActionConstraints.ActionSelectorCandidate
    
        
        .. code-block:: csharp
    
            public ActionSelectorCandidate CurrentCandidate
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintContext.RouteContext
    
        
    
        
        The :dn:prop:`Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintContext.RouteContext`\.
    
        
        :rtype: Microsoft.AspNetCore.Routing.RouteContext
    
        
        .. code-block:: csharp
    
            public RouteContext RouteContext
            {
                get;
                set;
            }
    

