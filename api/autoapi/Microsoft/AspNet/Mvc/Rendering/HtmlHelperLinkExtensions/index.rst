

HtmlHelperLinkExtensions Class
==============================



.. contents:: 
   :local:



Summary
-------

Link-related extensions for :any:`Microsoft.AspNet.Mvc.Rendering.IHtmlHelper`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Rendering.HtmlHelperLinkExtensions`








Syntax
------

.. code-block:: csharp

   public class HtmlHelperLinkExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/Rendering/HtmlHelperLinkExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperLinkExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperLinkExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperLinkExtensions.ActionLink(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.String)
    
        
    
        Returns an anchor (&lt;a&gt;) element that contains a URL path to the specified action.
    
        
        
        
        :param helper: The  instance this method extends.
        
        :type helper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param linkText: The inner text of the anchor element. Must not be null.
        
        :type linkText: System.String
        
        
        :param actionName: The name of the action.
        
        :type actionName: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the anchor element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent ActionLink(IHtmlHelper helper, string linkText, string actionName)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperLinkExtensions.ActionLink(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.String, System.Object)
    
        
    
        Returns an anchor (&lt;a&gt;) element that contains a URL path to the specified action.
    
        
        
        
        :param helper: The  instance this method extends.
        
        :type helper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param linkText: The inner text of the anchor element. Must not be null.
        
        :type linkText: System.String
        
        
        :param actionName: The name of the action.
        
        :type actionName: System.String
        
        
        :param routeValues: An  that contains the parameters for a route. The parameters are retrieved through
            reflection by examining the properties of the . This  is typically
            created using  initializer syntax. Alternatively, an
            instance containing the route
            parameters.
        
        :type routeValues: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the anchor element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent ActionLink(IHtmlHelper helper, string linkText, string actionName, object routeValues)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperLinkExtensions.ActionLink(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.String, System.Object, System.Object)
    
        
    
        Returns an anchor (&lt;a&gt;) element that contains a URL path to the specified action.
    
        
        
        
        :param helper: The  instance this method extends.
        
        :type helper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param linkText: The inner text of the anchor element. Must not be null.
        
        :type linkText: System.String
        
        
        :param actionName: The name of the action.
        
        :type actionName: System.String
        
        
        :param routeValues: An  that contains the parameters for a route. The parameters are retrieved through
            reflection by examining the properties of the . This  is typically
            created using  initializer syntax. Alternatively, an
            instance containing the route
            parameters.
        
        :type routeValues: System.Object
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the element. Alternatively, an
            instance containing the HTML
            attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the anchor element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent ActionLink(IHtmlHelper helper, string linkText, string actionName, object routeValues, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperLinkExtensions.ActionLink(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.String, System.String)
    
        
    
        Returns an anchor (&lt;a&gt;) element that contains a URL path to the specified action.
    
        
        
        
        :param helper: The  instance this method extends.
        
        :type helper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param linkText: The inner text of the anchor element. Must not be null.
        
        :type linkText: System.String
        
        
        :param actionName: The name of the action.
        
        :type actionName: System.String
        
        
        :param controllerName: The name of the controller.
        
        :type controllerName: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the anchor element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent ActionLink(IHtmlHelper helper, string linkText, string actionName, string controllerName)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperLinkExtensions.ActionLink(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.String, System.String, System.Object)
    
        
    
        Returns an anchor (&lt;a&gt;) element that contains a URL path to the specified action.
    
        
        
        
        :param helper: The  instance this method extends.
        
        :type helper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param linkText: The inner text of the anchor element. Must not be null.
        
        :type linkText: System.String
        
        
        :param actionName: The name of the action.
        
        :type actionName: System.String
        
        
        :param controllerName: The name of the controller.
        
        :type controllerName: System.String
        
        
        :param routeValues: An  that contains the parameters for a route. The parameters are retrieved through
            reflection by examining the properties of the . This  is typically
            created using  initializer syntax. Alternatively, an
            instance containing the route
            parameters.
        
        :type routeValues: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the anchor element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent ActionLink(IHtmlHelper helper, string linkText, string actionName, string controllerName, object routeValues)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperLinkExtensions.ActionLink(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.String, System.String, System.Object, System.Object)
    
        
    
        Returns an anchor (&lt;a&gt;) element that contains a URL path to the specified action.
    
        
        
        
        :param helper: The  instance this method extends.
        
        :type helper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param linkText: The inner text of the anchor element. Must not be null.
        
        :type linkText: System.String
        
        
        :param actionName: The name of the action.
        
        :type actionName: System.String
        
        
        :param controllerName: The name of the controller.
        
        :type controllerName: System.String
        
        
        :param routeValues: An  that contains the parameters for a route. The parameters are retrieved through
            reflection by examining the properties of the . This  is typically
            created using  initializer syntax. Alternatively, an
            instance containing the route
            parameters.
        
        :type routeValues: System.Object
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the element. Alternatively, an
            instance containing the HTML
            attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the anchor element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent ActionLink(IHtmlHelper helper, string linkText, string actionName, string controllerName, object routeValues, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperLinkExtensions.RouteLink(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.Object)
    
        
    
        Returns an anchor (&lt;a&gt;) element that contains a URL path to the specified route.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param linkText: The inner text of the anchor element. Must not be null.
        
        :type linkText: System.String
        
        
        :param routeValues: An  that contains the parameters for a route. The parameters are retrieved through
            reflection by examining the properties of the . This  is typically
            created using  initializer syntax. Alternatively, an
            instance containing the route
            parameters.
        
        :type routeValues: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the anchor element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent RouteLink(IHtmlHelper htmlHelper, string linkText, object routeValues)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperLinkExtensions.RouteLink(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.Object, System.Object)
    
        
    
        Returns an anchor (&lt;a&gt;) element that contains a URL path to the specified route.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param linkText: The inner text of the anchor element. Must not be null.
        
        :type linkText: System.String
        
        
        :param routeValues: An  that contains the parameters for a route. The parameters are retrieved through
            reflection by examining the properties of the . This  is typically
            created using  initializer syntax. Alternatively, an
            instance containing the route
            parameters.
        
        :type routeValues: System.Object
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the element. Alternatively, an
            instance containing the HTML
            attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the anchor element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent RouteLink(IHtmlHelper htmlHelper, string linkText, object routeValues, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperLinkExtensions.RouteLink(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.String)
    
        
    
        Returns an anchor (&lt;a&gt;) element that contains a URL path to the specified route.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param linkText: The inner text of the anchor element. Must not be null.
        
        :type linkText: System.String
        
        
        :param routeName: The name of the route.
        
        :type routeName: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the anchor element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent RouteLink(IHtmlHelper htmlHelper, string linkText, string routeName)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperLinkExtensions.RouteLink(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.String, System.Object)
    
        
    
        Returns an anchor (&lt;a&gt;) element that contains a URL path to the specified route.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param linkText: The inner text of the anchor element. Must not be null.
        
        :type linkText: System.String
        
        
        :param routeName: The name of the route.
        
        :type routeName: System.String
        
        
        :param routeValues: An  that contains the parameters for a route. The parameters are retrieved through
            reflection by examining the properties of the . This  is typically
            created using  initializer syntax. Alternatively, an
            instance containing the route
            parameters.
        
        :type routeValues: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the anchor element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent RouteLink(IHtmlHelper htmlHelper, string linkText, string routeName, object routeValues)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperLinkExtensions.RouteLink(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.String, System.Object, System.Object)
    
        
    
        Returns an anchor (&lt;a&gt;) element that contains a URL path to the specified route.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param linkText: The inner text of the anchor element. Must not be null.
        
        :type linkText: System.String
        
        
        :param routeName: The name of the route.
        
        :type routeName: System.String
        
        
        :param routeValues: An  that contains the parameters for a route. The parameters are retrieved through
            reflection by examining the properties of the . This  is typically
            created using  initializer syntax. Alternatively, an
            instance containing the route
            parameters.
        
        :type routeValues: System.Object
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the element. Alternatively, an
            instance containing the HTML
            attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the anchor element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent RouteLink(IHtmlHelper htmlHelper, string linkText, string routeName, object routeValues, object htmlAttributes)
    

