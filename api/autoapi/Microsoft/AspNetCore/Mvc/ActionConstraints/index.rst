

Microsoft.AspNetCore.Mvc.ActionConstraints Namespace
====================================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ActionConstraints/ActionConstraintContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ActionConstraints/ActionConstraintItem/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ActionConstraints/ActionConstraintProviderContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ActionConstraints/ActionMethodSelectorAttribute/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ActionConstraints/ActionSelectorCandidate/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ActionConstraints/IActionConstraint/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ActionConstraints/IActionConstraintFactory/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ActionConstraints/IActionConstraintMetadata/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ActionConstraints/IActionConstraintProvider/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.Mvc.ActionConstraints


    .. rubric:: Classes


    class :dn:cls:`ActionConstraintContext`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintContext

        
        Context for :any:`Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraint` execution.


    class :dn:cls:`ActionConstraintItem`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintItem

        
        Represents an :any:`Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraintMetadata` with or without a corresponding
        :any:`Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraint`\.


    class :dn:cls:`ActionConstraintProviderContext`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintProviderContext

        
        Context for an action constraint provider.


    class :dn:cls:`ActionMethodSelectorAttribute`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ActionConstraints.ActionMethodSelectorAttribute

        
        Base class for attributes which can implement conditional logic to enable or disable an action
        for a given request. See :any:`Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraint`\.


    class :dn:cls:`ActionSelectorCandidate`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ActionConstraints.ActionSelectorCandidate

        
        A candidate action for action selection.


    .. rubric:: Interfaces


    interface :dn:iface:`IActionConstraint`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraint

        
        Supports conditional logic to determine whether or not an associated action is valid to be selected
        for the given request.


    interface :dn:iface:`IActionConstraintFactory`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraintFactory

        
        A factory for :any:`Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraint`\.


    interface :dn:iface:`IActionConstraintMetadata`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraintMetadata

        
        A marker interface that identifies a type as metadata for an :any:`Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraint`\.


    interface :dn:iface:`IActionConstraintProvider`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraintProvider

        


