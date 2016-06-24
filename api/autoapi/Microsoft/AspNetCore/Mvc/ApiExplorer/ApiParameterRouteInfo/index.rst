

ApiParameterRouteInfo Class
===========================






A metadata description of routing information for an :any:`Microsoft.AspNetCore.Mvc.ApiExplorer.ApiParameterDescription`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ApiExplorer.ApiParameterRouteInfo`








Syntax
------

.. code-block:: csharp

    public class ApiParameterRouteInfo








.. dn:class:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiParameterRouteInfo
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiParameterRouteInfo

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiParameterRouteInfo
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiParameterRouteInfo.Constraints
    
        
    
        
        Gets or sets the set of :any:`Microsoft.AspNetCore.Routing.IRouteConstraint` objects for the parameter.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Routing.IRouteConstraint<Microsoft.AspNetCore.Routing.IRouteConstraint>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<IRouteConstraint> Constraints { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiParameterRouteInfo.DefaultValue
    
        
    
        
        Gets or sets the default value for the parameter.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public object DefaultValue { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiParameterRouteInfo.IsOptional
    
        
    
        
        Gets a value indicating whether not a parameter is considered optional by routing.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsOptional { get; set; }
    

