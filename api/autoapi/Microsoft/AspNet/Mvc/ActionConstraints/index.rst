

Microsoft.AspNet.Mvc.ActionConstraints Namespace
================================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNet/Mvc/ActionConstraints/ActionConstraintContext/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ActionConstraints/ActionConstraintItem/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ActionConstraints/ActionConstraintProviderContext/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ActionConstraints/ActionMethodSelectorAttribute/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ActionConstraints/ActionSelectorCandidate/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ActionConstraints/DefaultActionConstraintProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ActionConstraints/HttpMethodConstraint/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ActionConstraints/IActionConstraint/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ActionConstraints/IActionConstraintFactory/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ActionConstraints/IActionConstraintMetadata/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ActionConstraints/IActionConstraintProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ActionConstraints/IConsumesActionConstraint/index
   
   











.. dn:namespace:: Microsoft.AspNet.Mvc.ActionConstraints


    .. rubric:: Classes


    class :dn:cls:`Microsoft.AspNet.Mvc.ActionConstraints.ActionConstraintContext`
        Context for :any:`Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraint` execution.


    class :dn:cls:`Microsoft.AspNet.Mvc.ActionConstraints.ActionConstraintItem`
        Represents an :any:`Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraintMetadata` with or without a corresponding 
        :any:`Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraint`\.


    class :dn:cls:`Microsoft.AspNet.Mvc.ActionConstraints.ActionConstraintProviderContext`
        Context for an action constraint provider.


    class :dn:cls:`Microsoft.AspNet.Mvc.ActionConstraints.ActionMethodSelectorAttribute`
        Base class for attributes which can implement conditional logic to enable or disable an action
        for a given request. See :any:`Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraint`\.


    class :dn:cls:`Microsoft.AspNet.Mvc.ActionConstraints.ActionSelectorCandidate`
        A candidate action for action selection.


    class :dn:cls:`Microsoft.AspNet.Mvc.ActionConstraints.DefaultActionConstraintProvider`
        A default implementation of :any:`Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraintProvider`\.


    class :dn:cls:`Microsoft.AspNet.Mvc.ActionConstraints.HttpMethodConstraint`
        


    .. rubric:: Interfaces


    interface :dn:iface:`Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraint`
        Supports conditional logic to determine whether or not an associated action is valid to be selected
        for the given request.


    interface :dn:iface:`Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraintFactory`
        A factory for :any:`Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraint`\.


    interface :dn:iface:`Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraintMetadata`
        A marker interface that identifies a type as metadata for an :any:`Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraint`\.


    interface :dn:iface:`Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraintProvider`
        


    interface :dn:iface:`Microsoft.AspNet.Mvc.ActionConstraints.IConsumesActionConstraint`
        An :any:`Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraint` constraint that identifies a type which can be used to select an action
        based on incoming request.


