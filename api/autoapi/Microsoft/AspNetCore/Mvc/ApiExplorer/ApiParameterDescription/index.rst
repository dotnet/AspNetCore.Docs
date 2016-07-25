

ApiParameterDescription Class
=============================






A metadata description of an input to an API.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ApiExplorer.ApiParameterDescription`








Syntax
------

.. code-block:: csharp

    public class ApiParameterDescription








.. dn:class:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiParameterDescription
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiParameterDescription

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiParameterDescription
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiParameterDescription.ModelMetadata
    
        
    
        
        Gets or sets the :dn:prop:`Microsoft.AspNetCore.Mvc.ApiExplorer.ApiParameterDescription.ModelMetadata`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    
        
        .. code-block:: csharp
    
            public ModelMetadata ModelMetadata { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiParameterDescription.Name
    
        
    
        
        Gets or sets the name.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Name { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiParameterDescription.RouteInfo
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.ApiExplorer.ApiParameterRouteInfo`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiParameterRouteInfo
    
        
        .. code-block:: csharp
    
            public ApiParameterRouteInfo RouteInfo { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiParameterDescription.Source
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource
    
        
        .. code-block:: csharp
    
            public BindingSource Source { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiParameterDescription.Type
    
        
    
        
        Gets or sets the parameter type.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
            public Type Type { get; set; }
    

