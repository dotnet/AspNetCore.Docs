

Microsoft.AspNet.Mvc.Routing Namespace
======================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNet/Mvc/Routing/ActionSelectionDecisionTree/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Routing/ActionSelectorDecisionTreeProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Routing/AttributeRoute/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Routing/AttributeRouteInfo/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Routing/AttributeRouteLinkGenerationEntry/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Routing/AttributeRouteMatchingEntry/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Routing/AttributeRoutePrecedence/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Routing/AttributeRouting/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Routing/HttpMethodAttribute/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Routing/IActionSelectionDecisionTree/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Routing/IActionSelectorDecisionTreeProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Routing/InnerAttributeRoute/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Routing/KnownRouteValueConstraint/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Routing/RouteDataActionConstraint/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Routing/RouteKeyHandling/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Routing/RouteValueEqualityComparer/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Routing/UrlActionContext/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Routing/UrlHelper/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Routing/UrlRouteContext/index
   
   











.. dn:namespace:: Microsoft.AspNet.Mvc.Routing


    .. rubric:: Classes


    class :dn:cls:`Microsoft.AspNet.Mvc.Routing.ActionSelectionDecisionTree`
        


    class :dn:cls:`Microsoft.AspNet.Mvc.Routing.ActionSelectorDecisionTreeProvider`
        


    class :dn:cls:`Microsoft.AspNet.Mvc.Routing.AttributeRoute`
        


    class :dn:cls:`Microsoft.AspNet.Mvc.Routing.AttributeRouteInfo`
        Represents the routing information for an action that is attribute routed.


    class :dn:cls:`Microsoft.AspNet.Mvc.Routing.AttributeRouteLinkGenerationEntry`
        Used to build an :any:`Microsoft.AspNet.Mvc.Routing.InnerAttributeRoute`\. Represents an individual URL-generating route that will be
        aggregated into the :any:`Microsoft.AspNet.Mvc.Routing.InnerAttributeRoute`\.


    class :dn:cls:`Microsoft.AspNet.Mvc.Routing.AttributeRouteMatchingEntry`
        Used to build an :any:`Microsoft.AspNet.Mvc.Routing.InnerAttributeRoute`\. Represents an individual URL-matching route that will be
        aggregated into the :any:`Microsoft.AspNet.Mvc.Routing.InnerAttributeRoute`\.


    class :dn:cls:`Microsoft.AspNet.Mvc.Routing.AttributeRoutePrecedence`
        Computes precedence for an attribute route template.


    class :dn:cls:`Microsoft.AspNet.Mvc.Routing.AttributeRouting`
        


    class :dn:cls:`Microsoft.AspNet.Mvc.Routing.HttpMethodAttribute`
        Identifies an action that only supports a given set of HTTP methods.


    class :dn:cls:`Microsoft.AspNet.Mvc.Routing.InnerAttributeRoute`
        An :any:`Microsoft.AspNet.Routing.IRouter` implementation for attribute routing.


    class :dn:cls:`Microsoft.AspNet.Mvc.Routing.KnownRouteValueConstraint`
        


    class :dn:cls:`Microsoft.AspNet.Mvc.Routing.RouteDataActionConstraint`
        Constraints an action to a route key and value.


    class :dn:cls:`Microsoft.AspNet.Mvc.Routing.RouteValueEqualityComparer`
        An :any:`System.Collections.Generic.IEqualityComparer\`1` implementation that compares objects as-if
        they were route value strings.


    class :dn:cls:`Microsoft.AspNet.Mvc.Routing.UrlActionContext`
        Context object to be used for the URLs that :dn:meth:`Microsoft.AspNet.Mvc.IUrlHelper.Action(Microsoft.AspNet.Mvc.Routing.UrlActionContext)` generates.


    class :dn:cls:`Microsoft.AspNet.Mvc.Routing.UrlHelper`
        An implementation of :any:`Microsoft.AspNet.Mvc.IUrlHelper` that contains methods to
        build URLs for ASP.NET MVC within an application.


    class :dn:cls:`Microsoft.AspNet.Mvc.Routing.UrlRouteContext`
        Context object to be used for the URLs that :dn:meth:`Microsoft.AspNet.Mvc.IUrlHelper.RouteUrl(Microsoft.AspNet.Mvc.Routing.UrlRouteContext)` generates.


    .. rubric:: Interfaces


    interface :dn:iface:`Microsoft.AspNet.Mvc.Routing.IActionSelectionDecisionTree`
        A data structure that retrieves a list of :any:`Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor` matches based on the values
        supplied for the current request by :dn:prop:`Microsoft.AspNet.Routing.RouteData.Values`\.


    interface :dn:iface:`Microsoft.AspNet.Mvc.Routing.IActionSelectorDecisionTreeProvider`
        Stores an :any:`Microsoft.AspNet.Mvc.Routing.ActionSelectionDecisionTree` for the current value of 
        :dn:prop:`Microsoft.AspNet.Mvc.Infrastructure.IActionDescriptorsCollectionProvider.ActionDescriptors`\.


    .. rubric:: Enumerations


    enum :dn:enum:`Microsoft.AspNet.Mvc.Routing.RouteKeyHandling`
        


