

ViewComponentDescriptorCollection Class
=======================================






A cached collection of :any:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptor`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewComponents`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptorCollection`








Syntax
------

.. code-block:: csharp

    public class ViewComponentDescriptorCollection








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptorCollection
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptorCollection

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptorCollection
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptorCollection.Items
    
        
    
        
        Returns the cached :any:`System.Collections.Generic.IReadOnlyList\`1`\.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptor<Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptor>}
    
        
        .. code-block:: csharp
    
            public IReadOnlyList<ViewComponentDescriptor> Items
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptorCollection.Version
    
        
    
        
        Returns the unique version of the currently cached items.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Version
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptorCollection
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptorCollection.ViewComponentDescriptorCollection(System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptor>, System.Int32)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptorCollection`\.
    
        
    
        
        :param items: The result of view component discovery
        
        :type items: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptor<Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptor>}
    
        
        :param version: The unique version of discovered view components.
        
        :type version: System.Int32
    
        
        .. code-block:: csharp
    
            public ViewComponentDescriptorCollection(IEnumerable<ViewComponentDescriptor> items, int version)
    

