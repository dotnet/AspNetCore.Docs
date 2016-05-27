

AreaAttribute Class
===================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Routing.RouteConstraintAttribute`
* :dn:cls:`Microsoft.AspNetCore.Mvc.AreaAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class AreaAttribute : RouteConstraintAttribute, _Attribute, IRouteConstraintProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.AreaAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.AreaAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.AreaAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.AreaAttribute.AreaAttribute(System.String)
    
        
    
        
        :type areaName: System.String
    
        
        .. code-block:: csharp
    
            public AreaAttribute(string areaName)
    

