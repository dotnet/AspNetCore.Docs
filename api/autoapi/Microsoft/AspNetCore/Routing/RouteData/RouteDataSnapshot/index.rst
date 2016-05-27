

RouteDataSnapshot Struct
========================






A snapshot of the state of a :any:`Microsoft.AspNetCore.Routing.RouteData` instance.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Routing.RouteData`
Assemblies
    * Microsoft.AspNetCore.Routing.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public struct RouteDataSnapshot








.. dn:structure:: Microsoft.AspNetCore.Routing.RouteData.RouteDataSnapshot
    :hidden:

.. dn:structure:: Microsoft.AspNetCore.Routing.RouteData.RouteDataSnapshot

Constructors
------------

.. dn:structure:: Microsoft.AspNetCore.Routing.RouteData.RouteDataSnapshot
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Routing.RouteData.RouteDataSnapshot.RouteDataSnapshot(Microsoft.AspNetCore.Routing.RouteData, Microsoft.AspNetCore.Routing.RouteValueDictionary, System.Collections.Generic.IList<Microsoft.AspNetCore.Routing.IRouter>, Microsoft.AspNetCore.Routing.RouteValueDictionary)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Routing.RouteData.RouteDataSnapshot` for <em>routeData</em>.
    
        
    
        
        :param routeData: The :any:`Microsoft.AspNetCore.Routing.RouteData`\.
        
        :type routeData: Microsoft.AspNetCore.Routing.RouteData
    
        
        :param dataTokens: The data tokens.
        
        :type dataTokens: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        :param routers: The routers.
        
        :type routers: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Routing.IRouter<Microsoft.AspNetCore.Routing.IRouter>}
    
        
        :param values: The route values.
        
        :type values: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        .. code-block:: csharp
    
            public RouteDataSnapshot(RouteData routeData, RouteValueDictionary dataTokens, IList<IRouter> routers, RouteValueDictionary values)
    

Methods
-------

.. dn:structure:: Microsoft.AspNetCore.Routing.RouteData.RouteDataSnapshot
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Routing.RouteData.RouteDataSnapshot.Restore()
    
        
    
        
        Restores the :any:`Microsoft.AspNetCore.Routing.RouteData` to the captured state.
    
        
    
        
        .. code-block:: csharp
    
            public void Restore()
    

