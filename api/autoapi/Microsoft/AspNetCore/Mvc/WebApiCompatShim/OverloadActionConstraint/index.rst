

OverloadActionConstraint Class
==============================






An :any:`Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraint` limiting candidate actions to those for which the request satisfies all
non-optional parameters.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.WebApiCompatShim`
Assemblies
    * Microsoft.AspNetCore.Mvc.WebApiCompatShim

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.WebApiCompatShim.OverloadActionConstraint`








Syntax
------

.. code-block:: csharp

    public class OverloadActionConstraint : IActionConstraint, IActionConstraintMetadata








.. dn:class:: Microsoft.AspNetCore.Mvc.WebApiCompatShim.OverloadActionConstraint
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.WebApiCompatShim.OverloadActionConstraint

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.WebApiCompatShim.OverloadActionConstraint
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.WebApiCompatShim.OverloadActionConstraint.Accept(Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintContext
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Accept(ActionConstraintContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.WebApiCompatShim.OverloadActionConstraint
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.WebApiCompatShim.OverloadActionConstraint.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Order { get; }
    

