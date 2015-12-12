

ApiParameterRouteInfo Class
===========================



.. contents:: 
   :local:



Summary
-------

A metadata description of routing information for an :any:`Microsoft.AspNet.Mvc.ApiExplorer.ApiParameterDescription`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ApiExplorer.ApiParameterRouteInfo`








Syntax
------

.. code-block:: csharp

   public class ApiParameterRouteInfo





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ApiExplorer/ApiParameterRouteInfo.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ApiExplorer.ApiParameterRouteInfo

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ApiExplorer.ApiParameterRouteInfo
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ApiExplorer.ApiParameterRouteInfo.Constraints
    
        
    
        Gets or sets the set of :any:`Microsoft.AspNet.Routing.IRouteConstraint` objects for the parameter.
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Routing.IRouteConstraint}
    
        
        .. code-block:: csharp
    
           public IEnumerable<IRouteConstraint> Constraints { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApiExplorer.ApiParameterRouteInfo.DefaultValue
    
        
    
        Gets or sets the default value for the parameter.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public object DefaultValue { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApiExplorer.ApiParameterRouteInfo.IsOptional
    
        
    
        Gets a value indicating whether not a parameter is considered optional by routing.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsOptional { get; set; }
    

