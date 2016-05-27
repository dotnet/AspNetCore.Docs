

Microsoft.AspNetCore.Mvc.Routing Namespace
==========================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Routing/AttributeRouteInfo/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Routing/HttpMethodAttribute/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Routing/IActionHttpMethodProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Routing/IRouteConstraintProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Routing/IRouteTemplateProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Routing/IUrlHelperFactory/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Routing/KnownRouteValueConstraint/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Routing/RouteConstraintAttribute/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Routing/RouteDataActionConstraint/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Routing/RouteKeyHandling/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Routing/UrlActionContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Routing/UrlHelper/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Routing/UrlHelperFactory/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Routing/UrlRouteContext/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.Mvc.Routing


    .. rubric:: Classes


    class :dn:cls:`AttributeRouteInfo`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Routing.AttributeRouteInfo

        
        Represents the routing information for an action that is attribute routed.


    class :dn:cls:`HttpMethodAttribute`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Routing.HttpMethodAttribute

        
        Identifies an action that only supports a given set of HTTP methods.


    class :dn:cls:`KnownRouteValueConstraint`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Routing.KnownRouteValueConstraint

        


    class :dn:cls:`RouteConstraintAttribute`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Routing.RouteConstraintAttribute

        
        An attribute which specifies a required route value for an action or controller.
        
        When placed on an action, the route data of a request must match the expectations of the route
        constraint in order for the action to be selected. See :dn:prop:`Microsoft.AspNetCore.Mvc.Routing.RouteConstraintAttribute.RouteKeyHandling` for
        the expectations that must be satisfied by the route data.
        
        When placed on a controller, unless overridden by the action, the constraint applies to all
        actions defined by the controller.


    class :dn:cls:`RouteDataActionConstraint`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Routing.RouteDataActionConstraint

        
        Constraints an action to a route key and value.


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


    .. rubric:: Enumerations


    enum :dn:enum:`RouteKeyHandling`
        .. object: type=enum name=Microsoft.AspNetCore.Mvc.Routing.RouteKeyHandling

        


    .. rubric:: Interfaces


    interface :dn:iface:`IActionHttpMethodProvider`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Routing.IActionHttpMethodProvider

        


    interface :dn:iface:`IRouteConstraintProvider`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Routing.IRouteConstraintProvider

        
        An interface for metadata which provides :any:`Microsoft.AspNetCore.Mvc.Routing.RouteDataActionConstraint` values
        for a controller or action.


    interface :dn:iface:`IRouteTemplateProvider`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Routing.IRouteTemplateProvider

        
        Interface for attributes which can supply a route template for attribute routing.


    interface :dn:iface:`IUrlHelperFactory`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Routing.IUrlHelperFactory

        
        A factory for creating :any:`Microsoft.AspNetCore.Mvc.IUrlHelper` instances.


