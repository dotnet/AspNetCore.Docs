

ActionConstraintItem Class
==========================






Represents an :any:`Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraintMetadata` with or without a corresponding
:any:`Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraint`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintItem`








Syntax
------

.. code-block:: csharp

    public class ActionConstraintItem








.. dn:class:: Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintItem
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintItem

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintItem
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintItem.Constraint
    
        
    
        
        The :any:`Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraint` associated with :dn:prop:`Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintItem.Metadata`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraint
    
        
        .. code-block:: csharp
    
            public IActionConstraint Constraint
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintItem.IsReusable
    
        
    
        
        Gets or sets a value indicating whether or not :dn:prop:`Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintItem.Constraint` can be reused across requests.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsReusable
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintItem.Metadata
    
        
    
        
        The :any:`Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraintMetadata` instance.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraintMetadata
    
        
        .. code-block:: csharp
    
            public IActionConstraintMetadata Metadata
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintItem
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintItem.ActionConstraintItem(Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraintMetadata)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintItem`\.
    
        
    
        
        :param metadata: The :any:`Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraintMetadata` instance.
        
        :type metadata: Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraintMetadata
    
        
        .. code-block:: csharp
    
            public ActionConstraintItem(IActionConstraintMetadata metadata)
    

