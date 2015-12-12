

ApiDescriptionGroup Class
=========================



.. contents:: 
   :local:



Summary
-------

Represents a group of related apis.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionGroup`








Syntax
------

.. code-block:: csharp

   public class ApiDescriptionGroup





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ApiExplorer/ApiDescriptionGroup.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionGroup

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionGroup
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionGroup.ApiDescriptionGroup(System.String, System.Collections.Generic.IReadOnlyList<Microsoft.AspNet.Mvc.ApiExplorer.ApiDescription>)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionGroup`\.
    
        
        
        
        :param groupName: The group name.
        
        :type groupName: System.String
        
        
        :param items: A collection of  items for this group.
        
        :type items: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Mvc.ApiExplorer.ApiDescription}
    
        
        .. code-block:: csharp
    
           public ApiDescriptionGroup(string groupName, IReadOnlyList<ApiDescription> items)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionGroup
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionGroup.GroupName
    
        
    
        The group name.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string GroupName { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionGroup.Items
    
        
    
        A collection of :any:`Microsoft.AspNet.Mvc.ApiExplorer.ApiDescription` items for this group.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Mvc.ApiExplorer.ApiDescription}
    
        
        .. code-block:: csharp
    
           public IReadOnlyList<ApiDescription> Items { get; }
    

