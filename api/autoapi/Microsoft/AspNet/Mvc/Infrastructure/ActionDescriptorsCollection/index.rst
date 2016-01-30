

ActionDescriptorsCollection Class
=================================



.. contents:: 
   :local:



Summary
-------

A cached collection of :any:`Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Infrastructure.ActionDescriptorsCollection`








Syntax
------

.. code-block:: csharp

   public class ActionDescriptorsCollection





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/Infrastructure/ActionDescriptorsCollection.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Infrastructure.ActionDescriptorsCollection

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Infrastructure.ActionDescriptorsCollection
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Infrastructure.ActionDescriptorsCollection.ActionDescriptorsCollection(System.Collections.Generic.IReadOnlyList<Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor>, System.Int32)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.Infrastructure.ActionDescriptorsCollection`\.
    
        
        
        
        :param items: The result of action discovery
        
        :type items: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor}
        
        
        :param version: The unique version of discovered actions.
        
        :type version: System.Int32
    
        
        .. code-block:: csharp
    
           public ActionDescriptorsCollection(IReadOnlyList<ActionDescriptor> items, int version)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Infrastructure.ActionDescriptorsCollection
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Infrastructure.ActionDescriptorsCollection.Items
    
        
    
        Returns the cached :any:`System.Collections.Generic.IReadOnlyList\`1`\.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor}
    
        
        .. code-block:: csharp
    
           public IReadOnlyList<ActionDescriptor> Items { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Infrastructure.ActionDescriptorsCollection.Version
    
        
    
        Returns the unique version of the currently cached items.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Version { get; }
    

