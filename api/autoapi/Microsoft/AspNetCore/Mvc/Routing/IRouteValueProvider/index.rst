

IRouteValueProvider Interface
=============================






<p>
A metadata interface which specifies a route value which is required for the action selector to
choose an action. When applied to an action using attribute routing, the route value will be added
to the :dn:prop:`Microsoft.AspNetCore.Routing.RouteData.Values` when the action is selected.
</p>
<p>
When an :any:`Microsoft.AspNetCore.Mvc.Routing.IRouteValueProvider` is used to provide a new route value to an action, all
actions in the application must also have a value associated with that key, or have an implicit value
of <code>null</code>. See remarks for more details.
</p>


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Routing`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IRouteValueProvider








.. dn:interface:: Microsoft.AspNetCore.Mvc.Routing.IRouteValueProvider
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Routing.IRouteValueProvider

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Routing.IRouteValueProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Routing.IRouteValueProvider.RouteKey
    
        
    
        
        The route value key.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string RouteKey { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Routing.IRouteValueProvider.RouteValue
    
        
    
        
        The route value. If <code>null</code> or empty, requires the route value associated with :dn:prop:`Microsoft.AspNetCore.Mvc.Routing.IRouteValueProvider.RouteKey`
        to be missing or <code>null</code>.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string RouteValue { get; }
    

