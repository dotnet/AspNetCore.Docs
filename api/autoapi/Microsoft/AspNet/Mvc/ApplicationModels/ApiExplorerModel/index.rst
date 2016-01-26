

ApiExplorerModel Class
======================



.. contents:: 
   :local:



Summary
-------

A model for ApiExplorer properties associated with a controller or action.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ApplicationModels.ApiExplorerModel`








Syntax
------

.. code-block:: csharp

   public class ApiExplorerModel





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ApplicationModels/ApiExplorerModel.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ApplicationModels.ApiExplorerModel

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ApplicationModels.ApiExplorerModel
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ApplicationModels.ApiExplorerModel.ApiExplorerModel()
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ApplicationModels.ApiExplorerModel`\.
    
        
    
        
        .. code-block:: csharp
    
           public ApiExplorerModel()
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ApplicationModels.ApiExplorerModel.ApiExplorerModel(Microsoft.AspNet.Mvc.ApplicationModels.ApiExplorerModel)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ApplicationModels.ApiExplorerModel` with properties copied from ``other``.
    
        
        
        
        :param other: The  to copy.
        
        :type other: Microsoft.AspNet.Mvc.ApplicationModels.ApiExplorerModel
    
        
        .. code-block:: csharp
    
           public ApiExplorerModel(ApiExplorerModel other)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ApplicationModels.ApiExplorerModel
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.ApiExplorerModel.GroupName
    
        
    
        The value for <c>APIExplorer.ApiDescription.GroupName</c> of
        <c>APIExplorer.ApiDescription</c> objects created for the associated controller or action.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string GroupName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.ApiExplorerModel.IsVisible
    
        
    
        If <c>true</c>, <c>APIExplorer.ApiDescription</c> objects will be created for the associated
        controller or action.
    
        
        :rtype: System.Nullable{System.Boolean}
    
        
        .. code-block:: csharp
    
           public bool ? IsVisible { get; set; }
    

