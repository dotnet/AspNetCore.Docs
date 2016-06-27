

RouteAttribute Class
====================






Specifies an attribute route on a controller.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.RouteAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class RouteAttribute : Attribute, _Attribute, IRouteTemplateProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.RouteAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.RouteAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.RouteAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.RouteAttribute.RouteAttribute(System.String)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.RouteAttribute` with the given route template.
    
        
    
        
        :param template: The route template. May not be null.
        
        :type template: System.String
    
        
        .. code-block:: csharp
    
            public RouteAttribute(string template)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.RouteAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.RouteAttribute.Microsoft.AspNetCore.Mvc.Routing.IRouteTemplateProvider.Order
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.Int32<System.Int32>}
    
        
        .. code-block:: csharp
    
            int ? IRouteTemplateProvider.Order { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.RouteAttribute.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Name { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.RouteAttribute.Order
    
        
    
        
        Gets the route order. The order determines the order of route execution. Routes with a lower order
        value are tried first. If an action defines a route by providing an :any:`Microsoft.AspNetCore.Mvc.Routing.IRouteTemplateProvider`
        with a non <code>null</code> order, that order is used instead of this value. If neither the action nor the
        controller defines an order, a default value of 0 is used.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Order { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.RouteAttribute.Template
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Template { get; }
    

