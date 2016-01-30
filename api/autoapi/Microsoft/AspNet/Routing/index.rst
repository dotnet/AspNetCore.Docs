

Microsoft.AspNet.Routing Namespace
==================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNet/Routing/CompositeRouteConstraint/index
   
   
   
   /autoapi/Microsoft/AspNet/Routing/DefaultInlineConstraintResolver/index
   
   
   
   /autoapi/Microsoft/AspNet/Routing/IInlineConstraintResolver/index
   
   
   
   /autoapi/Microsoft/AspNet/Routing/INamedRouter/index
   
   
   
   /autoapi/Microsoft/AspNet/Routing/IRouteBuilder/index
   
   
   
   /autoapi/Microsoft/AspNet/Routing/IRouteCollection/index
   
   
   
   /autoapi/Microsoft/AspNet/Routing/IRouteConstraint/index
   
   
   
   /autoapi/Microsoft/AspNet/Routing/IRouter/index
   
   
   
   /autoapi/Microsoft/AspNet/Routing/InlineRouteParameterParser/index
   
   
   
   /autoapi/Microsoft/AspNet/Routing/RouteBuilder/index
   
   
   
   /autoapi/Microsoft/AspNet/Routing/RouteCollection/index
   
   
   
   /autoapi/Microsoft/AspNet/Routing/RouteConstraintBuilder/index
   
   
   
   /autoapi/Microsoft/AspNet/Routing/RouteConstraintMatcher/index
   
   
   
   /autoapi/Microsoft/AspNet/Routing/RouteContext/index
   
   
   
   /autoapi/Microsoft/AspNet/Routing/RouteData/index
   
   
   
   /autoapi/Microsoft/AspNet/Routing/RouteDirection/index
   
   
   
   /autoapi/Microsoft/AspNet/Routing/RouteOptions/index
   
   
   
   /autoapi/Microsoft/AspNet/Routing/RouteValueDictionary/index
   
   
   
   /autoapi/Microsoft/AspNet/Routing/VirtualPathContext/index
   
   
   
   /autoapi/Microsoft/AspNet/Routing/VirtualPathData/index
   
   











.. dn:namespace:: Microsoft.AspNet.Routing


    .. rubric:: Classes


    class :dn:cls:`Microsoft.AspNet.Routing.CompositeRouteConstraint`
        Constrains a route by several child constraints.


    class :dn:cls:`Microsoft.AspNet.Routing.DefaultInlineConstraintResolver`
        The default implementation of :any:`Microsoft.AspNet.Routing.IInlineConstraintResolver`\. Resolves constraints by parsing
        a constraint key and constraint arguments, using a map to resolve the constraint type, and calling an
        appropriate constructor for the constraint type.


    class :dn:cls:`Microsoft.AspNet.Routing.InlineRouteParameterParser`
        


    class :dn:cls:`Microsoft.AspNet.Routing.RouteBuilder`
        


    class :dn:cls:`Microsoft.AspNet.Routing.RouteCollection`
        


    class :dn:cls:`Microsoft.AspNet.Routing.RouteConstraintBuilder`
        A builder for produding a mapping of keys to see :any:`Microsoft.AspNet.Routing.IRouteConstraint`\.


    class :dn:cls:`Microsoft.AspNet.Routing.RouteConstraintMatcher`
        


    class :dn:cls:`Microsoft.AspNet.Routing.RouteContext`
        


    class :dn:cls:`Microsoft.AspNet.Routing.RouteData`
        Information about the current routing path.


    class :dn:cls:`Microsoft.AspNet.Routing.RouteOptions`
        


    class :dn:cls:`Microsoft.AspNet.Routing.RouteValueDictionary`
        An :any:`System.Collections.Generic.IDictionary\`2` type for route values.


    class :dn:cls:`Microsoft.AspNet.Routing.VirtualPathContext`
        


    class :dn:cls:`Microsoft.AspNet.Routing.VirtualPathData`
        Represents information about the route and virtual path that are the result of
        generating a URL with the ASP.NET routing middleware.


    .. rubric:: Interfaces


    interface :dn:iface:`Microsoft.AspNet.Routing.IInlineConstraintResolver`
        Defines an abstraction for resolving inline constraints as instances of :any:`Microsoft.AspNet.Routing.IRouteConstraint`\.


    interface :dn:iface:`Microsoft.AspNet.Routing.INamedRouter`
        


    interface :dn:iface:`Microsoft.AspNet.Routing.IRouteBuilder`
        Defines a contract for a route builder in an application. A route builder specifies the routes for an application.


    interface :dn:iface:`Microsoft.AspNet.Routing.IRouteCollection`
        


    interface :dn:iface:`Microsoft.AspNet.Routing.IRouteConstraint`
        Defines the contract that a class must implement in order to check whether a URL parameter value is valid for a constraint.


    interface :dn:iface:`Microsoft.AspNet.Routing.IRouter`
        


    .. rubric:: Enumerations


    enum :dn:enum:`Microsoft.AspNet.Routing.RouteDirection`
        Indicates whether ASP.NET routing is processing a URL from an HTTP request or generating a URL.


