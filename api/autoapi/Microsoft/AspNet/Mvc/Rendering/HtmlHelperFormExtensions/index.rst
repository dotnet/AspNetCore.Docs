

HtmlHelperFormExtensions Class
==============================



.. contents:: 
   :local:



Summary
-------

DisplayName-related extensions for :any:`Microsoft.AspNet.Mvc.Rendering.IHtmlHelper`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Rendering.HtmlHelperFormExtensions`








Syntax
------

.. code-block:: csharp

   public class HtmlHelperFormExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/Rendering/HtmlHelperFormExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperFormExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperFormExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperFormExtensions.BeginForm(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper)
    
        
    
        Renders a &lt;form&gt; start tag to the response. The &lt;form&gt;'s <c>action</c> attribute value will
        match the current request.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        :rtype: Microsoft.AspNet.Mvc.Rendering.MvcForm
        :return: An <see cref="T:Microsoft.AspNet.Mvc.Rendering.MvcForm" /> instance which renders the &lt;/form&gt; end tag when disposed.
    
        
        .. code-block:: csharp
    
           public static MvcForm BeginForm(IHtmlHelper htmlHelper)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperFormExtensions.BeginForm(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, Microsoft.AspNet.Mvc.Rendering.FormMethod)
    
        
    
        Renders a &lt;form&gt; start tag to the response. When the user submits the form, the
        current action will process the request.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param method: The HTTP method for processing the form, either GET or POST.
        
        :type method: Microsoft.AspNet.Mvc.Rendering.FormMethod
        :rtype: Microsoft.AspNet.Mvc.Rendering.MvcForm
        :return: An <see cref="T:Microsoft.AspNet.Mvc.Rendering.MvcForm" /> instance which renders the &lt;/form&gt; end tag when disposed.
    
        
        .. code-block:: csharp
    
           public static MvcForm BeginForm(IHtmlHelper htmlHelper, FormMethod method)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperFormExtensions.BeginForm(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, Microsoft.AspNet.Mvc.Rendering.FormMethod, System.Object)
    
        
    
        Renders a &lt;form&gt; start tag to the response. When the user submits the form, the
        current action will process the request.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param method: The HTTP method for processing the form, either GET or POST.
        
        :type method: Microsoft.AspNet.Mvc.Rendering.FormMethod
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the element. Alternatively, an
            instance containing the HTML
            attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Mvc.Rendering.MvcForm
        :return: An <see cref="T:Microsoft.AspNet.Mvc.Rendering.MvcForm" /> instance which renders the &lt;/form&gt; end tag when disposed.
    
        
        .. code-block:: csharp
    
           public static MvcForm BeginForm(IHtmlHelper htmlHelper, FormMethod method, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperFormExtensions.BeginForm(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.Object)
    
        
    
        Renders a &lt;form&gt; start tag to the response. When the user submits the form, the
        current action will process the request.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param routeValues: An  that contains the parameters for a route. The parameters are retrieved through
            reflection by examining the properties of the . This  is typically
            created using  initializer syntax. Alternatively, an
            instance containing the route
            parameters.
        
        :type routeValues: System.Object
        :rtype: Microsoft.AspNet.Mvc.Rendering.MvcForm
        :return: An <see cref="T:Microsoft.AspNet.Mvc.Rendering.MvcForm" /> instance which renders the &lt;/form&gt; end tag when disposed.
    
        
        .. code-block:: csharp
    
           public static MvcForm BeginForm(IHtmlHelper htmlHelper, object routeValues)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperFormExtensions.BeginForm(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.String)
    
        
    
        Renders a &lt;form&gt; start tag to the response. When the user submits the form, the action with name
        ``actionName`` will process the request.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param actionName: The name of the action method.
        
        :type actionName: System.String
        
        
        :param controllerName: The name of the controller.
        
        :type controllerName: System.String
        :rtype: Microsoft.AspNet.Mvc.Rendering.MvcForm
        :return: An <see cref="T:Microsoft.AspNet.Mvc.Rendering.MvcForm" /> instance which renders the &lt;/form&gt; end tag when disposed.
    
        
        .. code-block:: csharp
    
           public static MvcForm BeginForm(IHtmlHelper htmlHelper, string actionName, string controllerName)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperFormExtensions.BeginForm(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.String, Microsoft.AspNet.Mvc.Rendering.FormMethod)
    
        
    
        Renders a &lt;form&gt; start tag to the response. When the user submits the form, the action with name
        ``actionName`` will process the request.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param actionName: The name of the action method.
        
        :type actionName: System.String
        
        
        :param controllerName: The name of the controller.
        
        :type controllerName: System.String
        
        
        :param method: The HTTP method for processing the form, either GET or POST.
        
        :type method: Microsoft.AspNet.Mvc.Rendering.FormMethod
        :rtype: Microsoft.AspNet.Mvc.Rendering.MvcForm
        :return: An <see cref="T:Microsoft.AspNet.Mvc.Rendering.MvcForm" /> instance which renders the &lt;/form&gt; end tag when disposed.
    
        
        .. code-block:: csharp
    
           public static MvcForm BeginForm(IHtmlHelper htmlHelper, string actionName, string controllerName, FormMethod method)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperFormExtensions.BeginForm(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.String, Microsoft.AspNet.Mvc.Rendering.FormMethod, System.Object)
    
        
    
        Renders a &lt;form&gt; start tag to the response. When the user submits the form, the action with name
        ``actionName`` will process the request.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param actionName: The name of the action method.
        
        :type actionName: System.String
        
        
        :param controllerName: The name of the controller.
        
        :type controllerName: System.String
        
        
        :param method: The HTTP method for processing the form, either GET or POST.
        
        :type method: Microsoft.AspNet.Mvc.Rendering.FormMethod
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the element. Alternatively, an
            instance containing the HTML
            attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Mvc.Rendering.MvcForm
        :return: An <see cref="T:Microsoft.AspNet.Mvc.Rendering.MvcForm" /> instance which renders the &lt;/form&gt; end tag when disposed.
    
        
        .. code-block:: csharp
    
           public static MvcForm BeginForm(IHtmlHelper htmlHelper, string actionName, string controllerName, FormMethod method, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperFormExtensions.BeginForm(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.String, System.Object)
    
        
    
        Renders a &lt;form&gt; start tag to the response. When the user submits the form, the action with name
        ``actionName`` will process the request.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param actionName: The name of the action method.
        
        :type actionName: System.String
        
        
        :param controllerName: The name of the controller.
        
        :type controllerName: System.String
        
        
        :param routeValues: An  that contains the parameters for a route. The parameters are retrieved through
            reflection by examining the properties of the . This  is typically
            created using  initializer syntax. Alternatively, an
            instance containing the route
            parameters.
        
        :type routeValues: System.Object
        :rtype: Microsoft.AspNet.Mvc.Rendering.MvcForm
        :return: An <see cref="T:Microsoft.AspNet.Mvc.Rendering.MvcForm" /> instance which renders the &lt;/form&gt; end tag when disposed.
    
        
        .. code-block:: csharp
    
           public static MvcForm BeginForm(IHtmlHelper htmlHelper, string actionName, string controllerName, object routeValues)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperFormExtensions.BeginForm(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.String, System.Object, Microsoft.AspNet.Mvc.Rendering.FormMethod)
    
        
    
        Renders a &lt;form&gt; start tag to the response. When the user submits the form, the action with name
        ``actionName`` will process the request.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param actionName: The name of the action method.
        
        :type actionName: System.String
        
        
        :param controllerName: The name of the controller.
        
        :type controllerName: System.String
        
        
        :param routeValues: An  that contains the parameters for a route. The parameters are retrieved through
            reflection by examining the properties of the . This  is typically
            created using  initializer syntax. Alternatively, an
            instance containing the route
            parameters.
        
        :type routeValues: System.Object
        
        
        :param method: The HTTP method for processing the form, either GET or POST.
        
        :type method: Microsoft.AspNet.Mvc.Rendering.FormMethod
        :rtype: Microsoft.AspNet.Mvc.Rendering.MvcForm
        :return: An <see cref="T:Microsoft.AspNet.Mvc.Rendering.MvcForm" /> instance which renders the &lt;/form&gt; end tag when disposed.
    
        
        .. code-block:: csharp
    
           public static MvcForm BeginForm(IHtmlHelper htmlHelper, string actionName, string controllerName, object routeValues, FormMethod method)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperFormExtensions.BeginRouteForm(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.Object)
    
        
    
        Renders a &lt;form&gt; start tag to the response. The first route that can provide a URL with the
        specified ``routeValues`` generates the &lt;form&gt;'s <c>action</c> attribute value.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param routeValues: An  that contains the parameters for a route. The parameters are retrieved through
            reflection by examining the properties of the . This  is typically
            created using  initializer syntax. Alternatively, an
            instance containing the route
            parameters.
        
        :type routeValues: System.Object
        :rtype: Microsoft.AspNet.Mvc.Rendering.MvcForm
        :return: An <see cref="T:Microsoft.AspNet.Mvc.Rendering.MvcForm" /> instance which renders the &lt;/form&gt; end tag when disposed.
    
        
        .. code-block:: csharp
    
           public static MvcForm BeginRouteForm(IHtmlHelper htmlHelper, object routeValues)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperFormExtensions.BeginRouteForm(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String)
    
        
    
        Renders a &lt;form&gt; start tag to the response. The route with name ``routeName``
        generates the &lt;form&gt;'s <c>action</c> attribute value.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param routeName: The name of the route.
        
        :type routeName: System.String
        :rtype: Microsoft.AspNet.Mvc.Rendering.MvcForm
        :return: An <see cref="T:Microsoft.AspNet.Mvc.Rendering.MvcForm" /> instance which renders the &lt;/form&gt; end tag when disposed.
    
        
        .. code-block:: csharp
    
           public static MvcForm BeginRouteForm(IHtmlHelper htmlHelper, string routeName)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperFormExtensions.BeginRouteForm(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, Microsoft.AspNet.Mvc.Rendering.FormMethod)
    
        
    
        Renders a &lt;form&gt; start tag to the response. The route with name ``routeName``
        generates the &lt;form&gt;'s <c>action</c> attribute value.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param routeName: The name of the route.
        
        :type routeName: System.String
        
        
        :param method: The HTTP method for processing the form, either GET or POST.
        
        :type method: Microsoft.AspNet.Mvc.Rendering.FormMethod
        :rtype: Microsoft.AspNet.Mvc.Rendering.MvcForm
        :return: An <see cref="T:Microsoft.AspNet.Mvc.Rendering.MvcForm" /> instance which renders the &lt;/form&gt; end tag when disposed.
    
        
        .. code-block:: csharp
    
           public static MvcForm BeginRouteForm(IHtmlHelper htmlHelper, string routeName, FormMethod method)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperFormExtensions.BeginRouteForm(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, Microsoft.AspNet.Mvc.Rendering.FormMethod, System.Object)
    
        
    
        Renders a &lt;form&gt; start tag to the response. The route with name ``routeName``
        generates the &lt;form&gt;'s <c>action</c> attribute value.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param routeName: The name of the route.
        
        :type routeName: System.String
        
        
        :param method: The HTTP method for processing the form, either GET or POST.
        
        :type method: Microsoft.AspNet.Mvc.Rendering.FormMethod
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the element. Alternatively, an
            instance containing the HTML
            attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Mvc.Rendering.MvcForm
        :return: An <see cref="T:Microsoft.AspNet.Mvc.Rendering.MvcForm" /> instance which renders the &lt;/form&gt; end tag when disposed.
    
        
        .. code-block:: csharp
    
           public static MvcForm BeginRouteForm(IHtmlHelper htmlHelper, string routeName, FormMethod method, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperFormExtensions.BeginRouteForm(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.Object)
    
        
    
        Renders a &lt;form&gt; start tag to the response. The route with name ``routeName``
        generates the &lt;form&gt;'s <c>action</c> attribute value.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param routeName: The name of the route.
        
        :type routeName: System.String
        
        
        :param routeValues: An  that contains the parameters for a route. The parameters are retrieved through
            reflection by examining the properties of the . This  is typically
            created using  initializer syntax. Alternatively, an
            instance containing the route
            parameters.
        
        :type routeValues: System.Object
        :rtype: Microsoft.AspNet.Mvc.Rendering.MvcForm
        :return: An <see cref="T:Microsoft.AspNet.Mvc.Rendering.MvcForm" /> instance which renders the &lt;/form&gt; end tag when disposed.
    
        
        .. code-block:: csharp
    
           public static MvcForm BeginRouteForm(IHtmlHelper htmlHelper, string routeName, object routeValues)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperFormExtensions.BeginRouteForm(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.Object, Microsoft.AspNet.Mvc.Rendering.FormMethod)
    
        
    
        Renders a &lt;form&gt; start tag to the response. The route with name ``routeName``
        generates the &lt;form&gt;'s <c>action</c> attribute value.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param routeName: The name of the route.
        
        :type routeName: System.String
        
        
        :param routeValues: An  that contains the parameters for a route. The parameters are retrieved through
            reflection by examining the properties of the . This  is typically
            created using  initializer syntax. Alternatively, an
            instance containing the route
            parameters.
        
        :type routeValues: System.Object
        
        
        :param method: The HTTP method for processing the form, either GET or POST.
        
        :type method: Microsoft.AspNet.Mvc.Rendering.FormMethod
        :rtype: Microsoft.AspNet.Mvc.Rendering.MvcForm
        :return: An <see cref="T:Microsoft.AspNet.Mvc.Rendering.MvcForm" /> instance which renders the &lt;/form&gt; end tag when disposed.
    
        
        .. code-block:: csharp
    
           public static MvcForm BeginRouteForm(IHtmlHelper htmlHelper, string routeName, object routeValues, FormMethod method)
    

