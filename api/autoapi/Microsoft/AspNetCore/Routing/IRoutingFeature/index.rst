

IRoutingFeature Interface
=========================






A feature interface for routing functionality.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Routing`
Assemblies
    * Microsoft.AspNetCore.Routing.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IRoutingFeature








.. dn:interface:: Microsoft.AspNetCore.Routing.IRoutingFeature
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Routing.IRoutingFeature

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Routing.IRoutingFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Routing.IRoutingFeature.RouteData
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Routing.RouteData` associated with the current request.
    
        
        :rtype: Microsoft.AspNetCore.Routing.RouteData
    
        
        .. code-block:: csharp
    
            RouteData RouteData
            {
                get;
                set;
            }
    

