

ViewComponentDescriptorCollection Class
=======================================



.. contents:: 
   :local:



Summary
-------

A cached collection of :any:`Microsoft.AspNet.Mvc.ViewComponents.ViewComponentDescriptor`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewComponents.ViewComponentDescriptorCollection`








Syntax
------

.. code-block:: csharp

   public class ViewComponentDescriptorCollection





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewComponents/ViewComponentDescriptorCollection.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentDescriptorCollection

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentDescriptorCollection
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentDescriptorCollection.ViewComponentDescriptorCollection(System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.ViewComponents.ViewComponentDescriptor>, System.Int32)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.ViewComponents.ViewComponentDescriptorCollection`\.
    
        
        
        
        :param items: The result of view component discovery
        
        :type items: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.ViewComponents.ViewComponentDescriptor}
        
        
        :param version: The unique version of discovered view components.
        
        :type version: System.Int32
    
        
        .. code-block:: csharp
    
           public ViewComponentDescriptorCollection(IEnumerable<ViewComponentDescriptor> items, int version)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentDescriptorCollection
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentDescriptorCollection.Items
    
        
    
        Returns the cached :any:`System.Collections.Generic.IReadOnlyList\`1`\.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Mvc.ViewComponents.ViewComponentDescriptor}
    
        
        .. code-block:: csharp
    
           public IReadOnlyList<ViewComponentDescriptor> Items { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentDescriptorCollection.Version
    
        
    
        Returns the unique version of the currently cached items.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Version { get; }
    

