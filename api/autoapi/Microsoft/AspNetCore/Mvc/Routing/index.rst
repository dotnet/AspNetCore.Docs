

Microsoft.AspNetCore.Mvc.Routing Namespace
==========================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Routing/AttributeRouteInfo/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Routing/HttpMethodAttribute/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Routing/IActionHttpMethodProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Routing/IRouteTemplateProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Routing/IRouteValueProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Routing/IUrlHelperFactory/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Routing/KnownRouteValueConstraint/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Routing/RouteValueAttribute/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Routing/UrlActionContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Routing/UrlHelper/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Routing/UrlHelperFactory/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Routing/UrlRouteContext/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.Mvc.Routing


    .. rubric:: Interfaces


    interface :dn:iface:`IActionHttpMethodProvider`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Routing.IActionHttpMethodProvider

        


    interface :dn:iface:`IRouteTemplateProvider`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Routing.IRouteTemplateProvider

        
        Interface for attributes which can supply a route template for attribute routing.


    interface :dn:iface:`IRouteValueProvider`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Routing.IRouteValueProvider

        
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


    interface :dn:iface:`IUrlHelperFactory`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Routing.IUrlHelperFactory

        
        A factory for creating :any:`Microsoft.AspNetCore.Mvc.IUrlHelper` instances.


    .. rubric:: Classes


    class :dn:cls:`AttributeRouteInfo`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Routing.AttributeRouteInfo

        
        Represents the routing information for an action that is attribute routed.


    class :dn:cls:`HttpMethodAttribute`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Routing.HttpMethodAttribute

        
        Identifies an action that only supports a given set of HTTP methods.


    class :dn:cls:`KnownRouteValueConstraint`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Routing.KnownRouteValueConstraint

        


    class :dn:cls:`RouteValueAttribute`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Routing.RouteValueAttribute

        
        <p>
        An attribute which specifies a required route value for an action or controller.
        </p>
        <p>
        When placed on an action, the route data of a request must match the expectations of the route
        constraint in order for the action to be selected. See :any:`Microsoft.AspNetCore.Mvc.Routing.IRouteValueProvider` for
        the expectations that must be satisfied by the route data.
        </p>
        <p>
        When placed on a controller, unless overridden by the action, the constraint applies to all
        actions defined by the controller.
        </p>


    class :dn:cls:`UrlActionContext`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Routing.UrlActionContext

        
        Context object to be used for the URLs that :dn:meth:`Microsoft.AspNetCore.Mvc.IUrlHelper.Action(Microsoft.AspNetCore.Mvc.Routing.UrlActionContext)` generates.


    class :dn:cls:`UrlHelper`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Routing.UrlHelper

        
        An implementation of :any:`Microsoft.AspNetCore.Mvc.IUrlHelper` that contains methods to
        build URLs for ASP.NET MVC within an application.


    class :dn:cls:`UrlHelperFactory`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Routing.UrlHelperFactory

        
        A default implementation of :any:`Microsoft.AspNetCore.Mvc.Routing.IUrlHelperFactory`\.


    class :dn:cls:`UrlRouteContext`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Routing.UrlRouteContext

        
        Context object to be used for the URLs that :dn:meth:`Microsoft.AspNetCore.Mvc.IUrlHelper.RouteUrl(Microsoft.AspNetCore.Mvc.Routing.UrlRouteContext)` generates.


