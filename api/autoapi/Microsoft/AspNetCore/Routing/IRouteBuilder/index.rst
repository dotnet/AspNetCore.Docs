

IRouteBuilder Interface
=======================






Defines a contract for a route builder in an application. A route builder specifies the routes for
an application.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Routing`
Assemblies
    * Microsoft.AspNetCore.Routing

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IRouteBuilder








.. dn:interface:: Microsoft.AspNetCore.Routing.IRouteBuilder
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Routing.IRouteBuilder

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Routing.IRouteBuilder
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Routing.IRouteBuilder.ApplicationBuilder
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder`\.
    
        
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            IApplicationBuilder ApplicationBuilder
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.IRouteBuilder.DefaultHandler
    
        
    
        
        Gets or sets the default :any:`Microsoft.AspNetCore.Routing.IRouter` that is used as a handler if an :any:`Microsoft.AspNetCore.Routing.IRouter`
        is added to the list of routes but does not specify its own.
    
        
        :rtype: Microsoft.AspNetCore.Routing.IRouter
    
        
        .. code-block:: csharp
    
            IRouter DefaultHandler
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.IRouteBuilder.Routes
    
        
    
        
        Gets the routes configured in the builder.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Routing.IRouter<Microsoft.AspNetCore.Routing.IRouter>}
    
        
        .. code-block:: csharp
    
            IList<IRouter> Routes
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.IRouteBuilder.ServiceProvider
    
        
    
        
        Gets the sets the :any:`System.IServiceProvider` used to resolve services for routes.
    
        
        :rtype: System.IServiceProvider
    
        
        .. code-block:: csharp
    
            IServiceProvider ServiceProvider
            {
                get;
            }
    

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Routing.IRouteBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Routing.IRouteBuilder.Build()
    
        
    
        
        Builds an :any:`Microsoft.AspNetCore.Routing.IRouter` that routes the routes specified in the :dn:prop:`Microsoft.AspNetCore.Routing.IRouteBuilder.Routes` property.
    
        
        :rtype: Microsoft.AspNetCore.Routing.IRouter
    
        
        .. code-block:: csharp
    
            IRouter Build()
    

