

Microsoft.AspNetCore.Routing Namespace
======================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/Routing/DefaultInlineConstraintResolver/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Routing/IInlineConstraintResolver/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Routing/INamedRouter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Routing/IRouteBuilder/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Routing/IRouteCollection/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Routing/IRouteConstraint/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Routing/IRouteHandler/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Routing/IRouter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Routing/IRoutingFeature/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Routing/InlineRouteParameterParser/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Routing/RequestDelegateRouteBuilderExtensions/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Routing/Route/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Routing/RouteBase/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Routing/RouteBuilder/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Routing/RouteCollection/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Routing/RouteConstraintBuilder/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Routing/RouteConstraintMatcher/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Routing/RouteContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Routing/RouteData/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Routing/RouteData/RouteDataSnapshot/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Routing/RouteDirection/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Routing/RouteHandler/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Routing/RouteOptions/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Routing/RouteValueDictionary/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Routing/RouteValueDictionary/Enumerator/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Routing/RouteValueEqualityComparer/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Routing/RoutingHttpContextExtensions/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Routing/VirtualPathContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Routing/VirtualPathData/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.Routing


    .. rubric:: Enumerations


    enum :dn:enum:`RouteDirection`
        .. object: type=enum name=Microsoft.AspNetCore.Routing.RouteDirection

        
        Indicates whether ASP.NET routing is processing a URL from an HTTP request or generating a URL.


    .. rubric:: Classes


    class :dn:cls:`DefaultInlineConstraintResolver`
        .. object: type=class name=Microsoft.AspNetCore.Routing.DefaultInlineConstraintResolver

        
        The default implementation of :any:`Microsoft.AspNetCore.Routing.IInlineConstraintResolver`\. Resolves constraints by parsing
        a constraint key and constraint arguments, using a map to resolve the constraint type, and calling an
        appropriate constructor for the constraint type.


    class :dn:cls:`InlineRouteParameterParser`
        .. object: type=class name=Microsoft.AspNetCore.Routing.InlineRouteParameterParser

        


    class :dn:cls:`RequestDelegateRouteBuilderExtensions`
        .. object: type=class name=Microsoft.AspNetCore.Routing.RequestDelegateRouteBuilderExtensions

        


    class :dn:cls:`Route`
        .. object: type=class name=Microsoft.AspNetCore.Routing.Route

        


    class :dn:cls:`RouteBase`
        .. object: type=class name=Microsoft.AspNetCore.Routing.RouteBase

        


    class :dn:cls:`RouteBuilder`
        .. object: type=class name=Microsoft.AspNetCore.Routing.RouteBuilder

        


    class :dn:cls:`RouteCollection`
        .. object: type=class name=Microsoft.AspNetCore.Routing.RouteCollection

        


    class :dn:cls:`RouteConstraintBuilder`
        .. object: type=class name=Microsoft.AspNetCore.Routing.RouteConstraintBuilder

        
        A builder for produding a mapping of keys to see :any:`Microsoft.AspNetCore.Routing.IRouteConstraint`\.


    class :dn:cls:`RouteConstraintMatcher`
        .. object: type=class name=Microsoft.AspNetCore.Routing.RouteConstraintMatcher

        


    class :dn:cls:`RouteContext`
        .. object: type=class name=Microsoft.AspNetCore.Routing.RouteContext

        
        A context object for :dn:meth:`Microsoft.AspNetCore.Routing.IRouter.RouteAsync(Microsoft.AspNetCore.Routing.RouteContext)`\.


    class :dn:cls:`RouteData`
        .. object: type=class name=Microsoft.AspNetCore.Routing.RouteData

        
        Information about the current routing path.


    class :dn:cls:`RouteHandler`
        .. object: type=class name=Microsoft.AspNetCore.Routing.RouteHandler

        


    class :dn:cls:`RouteOptions`
        .. object: type=class name=Microsoft.AspNetCore.Routing.RouteOptions

        


    class :dn:cls:`RouteValueDictionary`
        .. object: type=class name=Microsoft.AspNetCore.Routing.RouteValueDictionary

        
        An :any:`System.Collections.Generic.IDictionary\`2` type for route values.


    class :dn:cls:`RouteValueEqualityComparer`
        .. object: type=class name=Microsoft.AspNetCore.Routing.RouteValueEqualityComparer

        
        An :any:`System.Collections.Generic.IEqualityComparer\`1` implementation that compares objects as-if
        they were route value strings.


    class :dn:cls:`RoutingHttpContextExtensions`
        .. object: type=class name=Microsoft.AspNetCore.Routing.RoutingHttpContextExtensions

        
        Extension methods for :any:`Microsoft.AspNetCore.Http.HttpContext` related to routing.


    class :dn:cls:`VirtualPathContext`
        .. object: type=class name=Microsoft.AspNetCore.Routing.VirtualPathContext

        
        A context for virtual path generation operations.


    class :dn:cls:`VirtualPathData`
        .. object: type=class name=Microsoft.AspNetCore.Routing.VirtualPathData

        
        Represents information about the route and virtual path that are the result of
        generating a URL with the ASP.NET routing middleware.


    .. rubric:: Structures


    struct :dn:struct:`RouteDataSnapshot`
        .. object: type=struct name=Microsoft.AspNetCore.Routing.RouteData.RouteDataSnapshot

        
        A snapshot of the state of a :any:`Microsoft.AspNetCore.Routing.RouteData` instance.


    struct :dn:struct:`Enumerator`
        .. object: type=struct name=Microsoft.AspNetCore.Routing.RouteValueDictionary.Enumerator

        


    .. rubric:: Interfaces


    interface :dn:iface:`IInlineConstraintResolver`
        .. object: type=interface name=Microsoft.AspNetCore.Routing.IInlineConstraintResolver

        
        Defines an abstraction for resolving inline constraints as instances of :any:`Microsoft.AspNetCore.Routing.IRouteConstraint`\.


    interface :dn:iface:`INamedRouter`
        .. object: type=interface name=Microsoft.AspNetCore.Routing.INamedRouter

        


    interface :dn:iface:`IRouteBuilder`
        .. object: type=interface name=Microsoft.AspNetCore.Routing.IRouteBuilder

        
        Defines a contract for a route builder in an application. A route builder specifies the routes for
        an application.


    interface :dn:iface:`IRouteCollection`
        .. object: type=interface name=Microsoft.AspNetCore.Routing.IRouteCollection

        


    interface :dn:iface:`IRouteConstraint`
        .. object: type=interface name=Microsoft.AspNetCore.Routing.IRouteConstraint

        
        Defines the contract that a class must implement in order to check whether a URL parameter
        value is valid for a constraint.


    interface :dn:iface:`IRouteHandler`
        .. object: type=interface name=Microsoft.AspNetCore.Routing.IRouteHandler

        
        Defines a contract for a handler of a route. 


    interface :dn:iface:`IRouter`
        .. object: type=interface name=Microsoft.AspNetCore.Routing.IRouter

        


    interface :dn:iface:`IRoutingFeature`
        .. object: type=interface name=Microsoft.AspNetCore.Routing.IRoutingFeature

        
        A feature interface for routing functionality.


