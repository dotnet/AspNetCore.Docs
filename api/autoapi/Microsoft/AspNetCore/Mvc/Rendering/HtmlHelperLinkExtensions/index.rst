

HtmlHelperLinkExtensions Class
==============================






Link-related extensions for :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Rendering`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperLinkExtensions`








Syntax
------

.. code-block:: csharp

    public class HtmlHelperLinkExtensions








.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperLinkExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperLinkExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperLinkExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperLinkExtensions.ActionLink(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.String)
    
        
    
        
        Returns an anchor (<a>) element that contains a URL path to the specified action.
    
        
    
        
        :param helper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type helper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param linkText: The inner text of the anchor element. Must not be <code>null</code>.
        
        :type linkText: System.String
    
        
        :param actionName: The name of the action.
        
        :type actionName: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the anchor element.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent ActionLink(this IHtmlHelper helper, string linkText, string actionName)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperLinkExtensions.ActionLink(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.String, System.Object)
    
        
    
        
        Returns an anchor (<a>) element that contains a URL path to the specified action.
    
        
    
        
        :param helper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type helper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param linkText: The inner text of the anchor element. Must not be <code>null</code>.
        
        :type linkText: System.String
    
        
        :param actionName: The name of the action.
        
        :type actionName: System.String
    
        
        :param routeValues: 
            An :any:`System.Object` that contains the parameters for a route. The parameters are retrieved through
            reflection by examining the properties of the :any:`System.Object`\. This :any:`System.Object` is typically
            created using :any:`System.Object` initializer syntax. Alternatively, an 
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the route
            parameters.
        
        :type routeValues: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the anchor element.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent ActionLink(this IHtmlHelper helper, string linkText, string actionName, object routeValues)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperLinkExtensions.ActionLink(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.String, System.Object, System.Object)
    
        
    
        
        Returns an anchor (<a>) element that contains a URL path to the specified action.
    
        
    
        
        :param helper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type helper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param linkText: The inner text of the anchor element. Must not be <code>null</code>.
        
        :type linkText: System.String
    
        
        :param actionName: The name of the action.
        
        :type actionName: System.String
    
        
        :param routeValues: 
            An :any:`System.Object` that contains the parameters for a route. The parameters are retrieved through
            reflection by examining the properties of the :any:`System.Object`\. This :any:`System.Object` is typically
            created using :any:`System.Object` initializer syntax. Alternatively, an 
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the route
            parameters.
        
        :type routeValues: System.Object
    
        
        :param htmlAttributes: 
            An :any:`System.Object` that contains the HTML attributes for the element. Alternatively, an 
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the HTML
            attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the anchor element.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent ActionLink(this IHtmlHelper helper, string linkText, string actionName, object routeValues, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperLinkExtensions.ActionLink(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.String, System.String)
    
        
    
        
        Returns an anchor (<a>) element that contains a URL path to the specified action.
    
        
    
        
        :param helper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type helper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param linkText: The inner text of the anchor element. Must not be <code>null</code>.
        
        :type linkText: System.String
    
        
        :param actionName: The name of the action.
        
        :type actionName: System.String
    
        
        :param controllerName: The name of the controller.
        
        :type controllerName: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the anchor element.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent ActionLink(this IHtmlHelper helper, string linkText, string actionName, string controllerName)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperLinkExtensions.ActionLink(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.String, System.String, System.Object)
    
        
    
        
        Returns an anchor (<a>) element that contains a URL path to the specified action.
    
        
    
        
        :param helper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type helper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param linkText: The inner text of the anchor element. Must not be <code>null</code>.
        
        :type linkText: System.String
    
        
        :param actionName: The name of the action.
        
        :type actionName: System.String
    
        
        :param controllerName: The name of the controller.
        
        :type controllerName: System.String
    
        
        :param routeValues: 
            An :any:`System.Object` that contains the parameters for a route. The parameters are retrieved through
            reflection by examining the properties of the :any:`System.Object`\. This :any:`System.Object` is typically
            created using :any:`System.Object` initializer syntax. Alternatively, an 
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the route
            parameters.
        
        :type routeValues: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the anchor element.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent ActionLink(this IHtmlHelper helper, string linkText, string actionName, string controllerName, object routeValues)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperLinkExtensions.ActionLink(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.String, System.String, System.Object, System.Object)
    
        
    
        
        Returns an anchor (<a>) element that contains a URL path to the specified action.
    
        
    
        
        :param helper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type helper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param linkText: The inner text of the anchor element. Must not be <code>null</code>.
        
        :type linkText: System.String
    
        
        :param actionName: The name of the action.
        
        :type actionName: System.String
    
        
        :param controllerName: The name of the controller.
        
        :type controllerName: System.String
    
        
        :param routeValues: 
            An :any:`System.Object` that contains the parameters for a route. The parameters are retrieved through
            reflection by examining the properties of the :any:`System.Object`\. This :any:`System.Object` is typically
            created using :any:`System.Object` initializer syntax. Alternatively, an 
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the route
            parameters.
        
        :type routeValues: System.Object
    
        
        :param htmlAttributes: 
            An :any:`System.Object` that contains the HTML attributes for the element. Alternatively, an 
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the HTML
            attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the anchor element.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent ActionLink(this IHtmlHelper helper, string linkText, string actionName, string controllerName, object routeValues, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperLinkExtensions.RouteLink(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.Object)
    
        
    
        
        Returns an anchor (<a>) element that contains a URL path to the specified route.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param linkText: The inner text of the anchor element. Must not be <code>null</code>.
        
        :type linkText: System.String
    
        
        :param routeValues: 
            An :any:`System.Object` that contains the parameters for a route. The parameters are retrieved through
            reflection by examining the properties of the :any:`System.Object`\. This :any:`System.Object` is typically
            created using :any:`System.Object` initializer syntax. Alternatively, an 
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the route
            parameters.
        
        :type routeValues: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the anchor element.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent RouteLink(this IHtmlHelper htmlHelper, string linkText, object routeValues)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperLinkExtensions.RouteLink(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.Object, System.Object)
    
        
    
        
        Returns an anchor (<a>) element that contains a URL path to the specified route.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param linkText: The inner text of the anchor element. Must not be <code>null</code>.
        
        :type linkText: System.String
    
        
        :param routeValues: 
            An :any:`System.Object` that contains the parameters for a route. The parameters are retrieved through
            reflection by examining the properties of the :any:`System.Object`\. This :any:`System.Object` is typically
            created using :any:`System.Object` initializer syntax. Alternatively, an 
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the route
            parameters.
        
        :type routeValues: System.Object
    
        
        :param htmlAttributes: 
            An :any:`System.Object` that contains the HTML attributes for the element. Alternatively, an 
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the HTML
            attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the anchor element.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent RouteLink(this IHtmlHelper htmlHelper, string linkText, object routeValues, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperLinkExtensions.RouteLink(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.String)
    
        
    
        
        Returns an anchor (<a>) element that contains a URL path to the specified route.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param linkText: The inner text of the anchor element. Must not be <code>null</code>.
        
        :type linkText: System.String
    
        
        :param routeName: The name of the route.
        
        :type routeName: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the anchor element.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent RouteLink(this IHtmlHelper htmlHelper, string linkText, string routeName)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperLinkExtensions.RouteLink(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.String, System.Object)
    
        
    
        
        Returns an anchor (<a>) element that contains a URL path to the specified route.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param linkText: The inner text of the anchor element. Must not be <code>null</code>.
        
        :type linkText: System.String
    
        
        :param routeName: The name of the route.
        
        :type routeName: System.String
    
        
        :param routeValues: 
            An :any:`System.Object` that contains the parameters for a route. The parameters are retrieved through
            reflection by examining the properties of the :any:`System.Object`\. This :any:`System.Object` is typically
            created using :any:`System.Object` initializer syntax. Alternatively, an 
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the route
            parameters.
        
        :type routeValues: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the anchor element.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent RouteLink(this IHtmlHelper htmlHelper, string linkText, string routeName, object routeValues)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperLinkExtensions.RouteLink(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.String, System.Object, System.Object)
    
        
    
        
        Returns an anchor (<a>) element that contains a URL path to the specified route.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param linkText: The inner text of the anchor element. Must not be <code>null</code>.
        
        :type linkText: System.String
    
        
        :param routeName: The name of the route.
        
        :type routeName: System.String
    
        
        :param routeValues: 
            An :any:`System.Object` that contains the parameters for a route. The parameters are retrieved through
            reflection by examining the properties of the :any:`System.Object`\. This :any:`System.Object` is typically
            created using :any:`System.Object` initializer syntax. Alternatively, an 
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the route
            parameters.
        
        :type routeValues: System.Object
    
        
        :param htmlAttributes: 
            An :any:`System.Object` that contains the HTML attributes for the element. Alternatively, an 
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the HTML
            attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the anchor element.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent RouteLink(this IHtmlHelper htmlHelper, string linkText, string routeName, object routeValues, object htmlAttributes)
    

