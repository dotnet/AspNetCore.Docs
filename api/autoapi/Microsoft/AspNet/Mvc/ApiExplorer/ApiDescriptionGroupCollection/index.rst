

ApiDescriptionGroupCollection Class
===================================



.. contents:: 
   :local:



Summary
-------

A cached collection of :any:`Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionGroup`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionGroupCollection`








Syntax
------

.. code-block:: csharp

   public class ApiDescriptionGroupCollection





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ApiExplorer/ApiDescriptionGroupCollection.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionGroupCollection

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionGroupCollection
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionGroupCollection.ApiDescriptionGroupCollection(System.Collections.Generic.IReadOnlyList<Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionGroup>, System.Int32)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionGroupCollection`\.
    
        
        
        
        :param items: The list of .
        
        :type items: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionGroup}
        
        
        :param version: The unique version of discovered groups.
        
        :type version: System.Int32
    
        
        .. code-block:: csharp
    
           public ApiDescriptionGroupCollection(IReadOnlyList<ApiDescriptionGroup> items, int version)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionGroupCollection
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionGroupCollection.Items
    
        
    
        Returns the list of :any:`System.Collections.Generic.IReadOnlyList\`1`\.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionGroup}
    
        
        .. code-block:: csharp
    
           public IReadOnlyList<ApiDescriptionGroup> Items { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionGroupCollection.Version
    
        
    
        Returns the unique version of the current items.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Version { get; }
    

