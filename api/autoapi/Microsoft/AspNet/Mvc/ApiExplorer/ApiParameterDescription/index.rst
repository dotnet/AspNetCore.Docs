

ApiParameterDescription Class
=============================



.. contents:: 
   :local:



Summary
-------

A metadata description of an input to an API.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ApiExplorer.ApiParameterDescription`








Syntax
------

.. code-block:: csharp

   public class ApiParameterDescription





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ApiExplorer/ApiParameterDescription.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ApiExplorer.ApiParameterDescription

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ApiExplorer.ApiParameterDescription
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ApiExplorer.ApiParameterDescription.ModelMetadata
    
        
    
        Gets or sets the :dn:prop:`Microsoft.AspNet.Mvc.ApiExplorer.ApiParameterDescription.ModelMetadata`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
    
        
        .. code-block:: csharp
    
           public ModelMetadata ModelMetadata { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApiExplorer.ApiParameterDescription.Name
    
        
    
        Gets or sets the name.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Name { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApiExplorer.ApiParameterDescription.RouteInfo
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Mvc.ApiExplorer.ApiParameterRouteInfo`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ApiExplorer.ApiParameterRouteInfo
    
        
        .. code-block:: csharp
    
           public ApiParameterRouteInfo RouteInfo { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApiExplorer.ApiParameterDescription.Source
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Mvc.ModelBinding.BindingSource`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.BindingSource
    
        
        .. code-block:: csharp
    
           public BindingSource Source { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApiExplorer.ApiParameterDescription.Type
    
        
    
        Gets or sets the parameter type.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
           public Type Type { get; set; }
    

