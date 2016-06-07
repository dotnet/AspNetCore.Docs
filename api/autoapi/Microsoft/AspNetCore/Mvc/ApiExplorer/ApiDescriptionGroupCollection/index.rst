

ApiDescriptionGroupCollection Class
===================================






A cached collection of :any:`Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionGroup`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ApiExplorer`
Assemblies
    * Microsoft.AspNetCore.Mvc.ApiExplorer

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionGroupCollection`








Syntax
------

.. code-block:: csharp

    public class ApiDescriptionGroupCollection








.. dn:class:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionGroupCollection
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionGroupCollection

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionGroupCollection
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionGroupCollection.Items
    
        
    
        
        Returns the list of :any:`System.Collections.Generic.IReadOnlyList\`1`\.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionGroup<Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionGroup>}
    
        
        .. code-block:: csharp
    
            public IReadOnlyList<ApiDescriptionGroup> Items
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionGroupCollection.Version
    
        
    
        
        Returns the unique version of the current items.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Version
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionGroupCollection
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionGroupCollection.ApiDescriptionGroupCollection(System.Collections.Generic.IReadOnlyList<Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionGroup>, System.Int32)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionGroupCollection`\.
    
        
    
        
        :param items: The list of :any:`Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionGroup`\.
        
        :type items: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionGroup<Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionGroup>}
    
        
        :param version: The unique version of discovered groups.
        
        :type version: System.Int32
    
        
        .. code-block:: csharp
    
            public ApiDescriptionGroupCollection(IReadOnlyList<ApiDescriptionGroup> items, int version)
    

