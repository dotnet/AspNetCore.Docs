

ActionSelectorCandidate Class
=============================






A candidate action for action selection.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ActionConstraints.ActionSelectorCandidate`








Syntax
------

.. code-block:: csharp

    public class ActionSelectorCandidate








.. dn:class:: Microsoft.AspNetCore.Mvc.ActionConstraints.ActionSelectorCandidate
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ActionConstraints.ActionSelectorCandidate

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ActionConstraints.ActionSelectorCandidate
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ActionConstraints.ActionSelectorCandidate.Action
    
        
    
        
        The :any:`Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor` representing a candiate for selection.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor
    
        
        .. code-block:: csharp
    
            public ActionDescriptor Action
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ActionConstraints.ActionSelectorCandidate.Constraints
    
        
    
        
        The list of :any:`Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraint` instances associated with <see name="Action"></see>.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraint<Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraint>}
    
        
        .. code-block:: csharp
    
            public IReadOnlyList<IActionConstraint> Constraints
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ActionConstraints.ActionSelectorCandidate
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ActionConstraints.ActionSelectorCandidate.ActionSelectorCandidate(Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor, System.Collections.Generic.IReadOnlyList<Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraint>)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ActionConstraints.ActionSelectorCandidate`\.
    
        
    
        
        :param action: The :any:`Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor` representing a candidate for selection.
        
        :type action: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor
    
        
        :param constraints: 
            The list of :any:`Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraint` instances associated with <em>action</em>.
        
        :type constraints: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraint<Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraint>}
    
        
        .. code-block:: csharp
    
            public ActionSelectorCandidate(ActionDescriptor action, IReadOnlyList<IActionConstraint> constraints)
    

