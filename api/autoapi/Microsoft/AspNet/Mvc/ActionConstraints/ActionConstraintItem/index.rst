

ActionConstraintItem Class
==========================



.. contents:: 
   :local:



Summary
-------

Represents an :any:`Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraintMetadata` with or without a corresponding 
:any:`Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraint`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ActionConstraints.ActionConstraintItem`








Syntax
------

.. code-block:: csharp

   public class ActionConstraintItem





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Abstractions/ActionConstraints/ActionConstraintItem.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ActionConstraints.ActionConstraintItem

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ActionConstraints.ActionConstraintItem
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ActionConstraints.ActionConstraintItem.ActionConstraintItem(Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraintMetadata)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ActionConstraints.ActionConstraintItem`\.
    
        
        
        
        :param metadata: The  instance.
        
        :type metadata: Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraintMetadata
    
        
        .. code-block:: csharp
    
           public ActionConstraintItem(IActionConstraintMetadata metadata)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ActionConstraints.ActionConstraintItem
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ActionConstraints.ActionConstraintItem.Constraint
    
        
    
        The :any:`Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraint` associated with :dn:prop:`Microsoft.AspNet.Mvc.ActionConstraints.ActionConstraintItem.Metadata`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraint
    
        
        .. code-block:: csharp
    
           public IActionConstraint Constraint { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ActionConstraints.ActionConstraintItem.Metadata
    
        
    
        The :any:`Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraintMetadata` instance.
    
        
        :rtype: Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraintMetadata
    
        
        .. code-block:: csharp
    
           public IActionConstraintMetadata Metadata { get; }
    

