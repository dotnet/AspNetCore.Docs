

ApiExplorerModel Class
======================






A model for ApiExplorer properties associated with a controller or action.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ApplicationModels`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ApplicationModels.ApiExplorerModel`








Syntax
------

.. code-block:: csharp

    public class ApiExplorerModel








.. dn:class:: Microsoft.AspNetCore.Mvc.ApplicationModels.ApiExplorerModel
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ApplicationModels.ApiExplorerModel

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ApplicationModels.ApiExplorerModel
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.ApiExplorerModel.GroupName
    
        
    
        
        The value for <code>APIExplorer.ApiDescription.GroupName</code> of
        <code>APIExplorer.ApiDescription</code> objects created for the associated controller or action.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string GroupName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.ApiExplorerModel.IsVisible
    
        
    
        
        If <code>true</code>, <code>APIExplorer.ApiDescription</code> objects will be created for the associated
        controller or action.
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.Boolean<System.Boolean>}
    
        
        .. code-block:: csharp
    
            public bool ? IsVisible
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ApplicationModels.ApiExplorerModel
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ApplicationModels.ApiExplorerModel.ApiExplorerModel()
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.ApiExplorerModel`\.
    
        
    
        
        .. code-block:: csharp
    
            public ApiExplorerModel()
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ApplicationModels.ApiExplorerModel.ApiExplorerModel(Microsoft.AspNetCore.Mvc.ApplicationModels.ApiExplorerModel)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.ApiExplorerModel` with properties copied from <em>other</em>.
    
        
    
        
        :param other: The :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.ApiExplorerModel` to copy.
        
        :type other: Microsoft.AspNetCore.Mvc.ApplicationModels.ApiExplorerModel
    
        
        .. code-block:: csharp
    
            public ApiExplorerModel(ApiExplorerModel other)
    

