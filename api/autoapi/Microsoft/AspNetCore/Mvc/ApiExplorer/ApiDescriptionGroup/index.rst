

ApiDescriptionGroup Class
=========================






Represents a group of related apis.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionGroup`








Syntax
------

.. code-block:: csharp

    public class ApiDescriptionGroup








.. dn:class:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionGroup
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionGroup

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionGroup
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionGroup.ApiDescriptionGroup(System.String, System.Collections.Generic.IReadOnlyList<Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescription>)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionGroup`\.
    
        
    
        
        :param groupName: The group name.
        
        :type groupName: System.String
    
        
        :param items: A collection of :any:`Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescription` items for this group.
        
        :type items: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescription<Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescription>}
    
        
        .. code-block:: csharp
    
            public ApiDescriptionGroup(string groupName, IReadOnlyList<ApiDescription> items)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionGroup
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionGroup.GroupName
    
        
    
        
        The group name.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string GroupName { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionGroup.Items
    
        
    
        
        A collection of :any:`Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescription` items for this group.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescription<Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescription>}
    
        
        .. code-block:: csharp
    
            public IReadOnlyList<ApiDescription> Items { get; }
    

