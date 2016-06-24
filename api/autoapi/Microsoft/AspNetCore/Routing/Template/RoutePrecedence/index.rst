

RoutePrecedence Class
=====================






Computes precedence for a route template.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Routing.Template`
Assemblies
    * Microsoft.AspNetCore.Routing

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Routing.Template.RoutePrecedence`








Syntax
------

.. code-block:: csharp

    public class RoutePrecedence








.. dn:class:: Microsoft.AspNetCore.Routing.Template.RoutePrecedence
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Routing.Template.RoutePrecedence

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Routing.Template.RoutePrecedence
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Routing.Template.RoutePrecedence.ComputeInbound(Microsoft.AspNetCore.Routing.Template.RouteTemplate)
    
        
    
        
        :type template: Microsoft.AspNetCore.Routing.Template.RouteTemplate
        :rtype: System.Decimal
    
        
        .. code-block:: csharp
    
            public static decimal ComputeInbound(RouteTemplate template)
    
    .. dn:method:: Microsoft.AspNetCore.Routing.Template.RoutePrecedence.ComputeOutbound(Microsoft.AspNetCore.Routing.Template.RouteTemplate)
    
        
    
        
        :type template: Microsoft.AspNetCore.Routing.Template.RouteTemplate
        :rtype: System.Decimal
    
        
        .. code-block:: csharp
    
            public static decimal ComputeOutbound(RouteTemplate template)
    

