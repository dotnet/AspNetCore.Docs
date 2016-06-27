

ActionDescriptorCollection Class
================================






A cached collection of :any:`Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Infrastructure`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Infrastructure.ActionDescriptorCollection`








Syntax
------

.. code-block:: csharp

    public class ActionDescriptorCollection








.. dn:class:: Microsoft.AspNetCore.Mvc.Infrastructure.ActionDescriptorCollection
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Infrastructure.ActionDescriptorCollection

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Infrastructure.ActionDescriptorCollection
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Infrastructure.ActionDescriptorCollection.ActionDescriptorCollection(System.Collections.Generic.IReadOnlyList<Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor>, System.Int32)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.Infrastructure.ActionDescriptorCollection`\.
    
        
    
        
        :param items: The result of action discovery
        
        :type items: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor<Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor>}
    
        
        :param version: The unique version of discovered actions.
        
        :type version: System.Int32
    
        
        .. code-block:: csharp
    
            public ActionDescriptorCollection(IReadOnlyList<ActionDescriptor> items, int version)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Infrastructure.ActionDescriptorCollection
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Infrastructure.ActionDescriptorCollection.Items
    
        
    
        
        Returns the cached :any:`System.Collections.Generic.IReadOnlyList\`1`\.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor<Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor>}
    
        
        .. code-block:: csharp
    
            public IReadOnlyList<ActionDescriptor> Items { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Infrastructure.ActionDescriptorCollection.Version
    
        
    
        
        Returns the unique version of the currently cached items.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Version { get; }
    

