

HtmlHelperFormExtensions Class
==============================






Form-related extensions for :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperFormExtensions`








Syntax
------

.. code-block:: csharp

    public class HtmlHelperFormExtensions








.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperFormExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperFormExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperFormExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperFormExtensions.BeginForm(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper)
    
        
    
        
        Renders a <form> start tag to the response. The <form>'s <code>action</code> attribute value will
        match the current request.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.MvcForm
        :return: 
            An :any:`Microsoft.AspNetCore.Mvc.Rendering.MvcForm` instance which renders the </form> end tag when disposed.
    
        
        .. code-block:: csharp
    
            public static MvcForm BeginForm(this IHtmlHelper htmlHelper)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperFormExtensions.BeginForm(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, Microsoft.AspNetCore.Mvc.Rendering.FormMethod)
    
        
    
        
        Renders a <form> start tag to the response. When the user submits the form, the
        current action will process the request.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param method: The HTTP method for processing the form, either GET or POST.
        
        :type method: Microsoft.AspNetCore.Mvc.Rendering.FormMethod
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.MvcForm
        :return: 
            An :any:`Microsoft.AspNetCore.Mvc.Rendering.MvcForm` instance which renders the </form> end tag when disposed.
    
        
        .. code-block:: csharp
    
            public static MvcForm BeginForm(this IHtmlHelper htmlHelper, FormMethod method)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperFormExtensions.BeginForm(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, Microsoft.AspNetCore.Mvc.Rendering.FormMethod, System.Nullable<System.Boolean>, System.Object)
    
        
    
        
        Renders a <form> start tag to the response. When the user submits the form, the
        current action will process the request.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param method: The HTTP method for processing the form, either GET or POST.
        
        :type method: Microsoft.AspNetCore.Mvc.Rendering.FormMethod
    
        
        :param antiforgery: 
            If <code>true</code>, <form> elements will include an antiforgery token.
            If <code>false</code>, suppresses the generation an <input> of type "hidden" with an antiforgery token.
            If <code>null</code>, <form> elements will include an antiforgery token only if
            <em>method</em> is not :dn:field:`Microsoft.AspNetCore.Mvc.Rendering.FormMethod.Get`\.
        
        :type antiforgery: System.Nullable<System.Nullable`1>{System.Boolean<System.Boolean>}
    
        
        :param htmlAttributes: 
            An :any:`System.Object` that contains the HTML attributes for the element. Alternatively, an 
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the HTML
            attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.MvcForm
        :return: 
            An :any:`Microsoft.AspNetCore.Mvc.Rendering.MvcForm` instance which renders the </form> end tag when disposed.
    
        
        .. code-block:: csharp
    
            public static MvcForm BeginForm(this IHtmlHelper htmlHelper, FormMethod method, bool ? antiforgery, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperFormExtensions.BeginForm(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, Microsoft.AspNetCore.Mvc.Rendering.FormMethod, System.Object)
    
        
    
        
        Renders a <form> start tag to the response. When the user submits the form, the
        current action will process the request.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param method: The HTTP method for processing the form, either GET or POST.
        
        :type method: Microsoft.AspNetCore.Mvc.Rendering.FormMethod
    
        
        :param htmlAttributes: 
            An :any:`System.Object` that contains the HTML attributes for the element. Alternatively, an 
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the HTML
            attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.MvcForm
        :return: 
            An :any:`Microsoft.AspNetCore.Mvc.Rendering.MvcForm` instance which renders the </form> end tag when disposed.
    
        
        .. code-block:: csharp
    
            public static MvcForm BeginForm(this IHtmlHelper htmlHelper, FormMethod method, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperFormExtensions.BeginForm(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.Nullable<System.Boolean>)
    
        
    
        
        Renders a <form> start tag to the response. The <form>'s <code>action</code> attribute value will
        match the current request.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param antiforgery: 
            If <code>true</code>, <form> elements will include an antiforgery token.
            If <code>false</code>, suppresses the generation an <input> of type "hidden" with an antiforgery token.
            If <code>null</code>, <form> elements will include an antiforgery token.
        
        :type antiforgery: System.Nullable<System.Nullable`1>{System.Boolean<System.Boolean>}
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.MvcForm
        :return: 
            An :any:`Microsoft.AspNetCore.Mvc.Rendering.MvcForm` instance which renders the </form> end tag when disposed.
    
        
        .. code-block:: csharp
    
            public static MvcForm BeginForm(this IHtmlHelper htmlHelper, bool ? antiforgery)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperFormExtensions.BeginForm(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.Object)
    
        
    
        
        Renders a <form> start tag to the response. When the user submits the form, the
        current action will process the request.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param routeValues: 
            An :any:`System.Object` that contains the parameters for a route. The parameters are retrieved through
            reflection by examining the properties of the :any:`System.Object`\. This :any:`System.Object` is typically
            created using :any:`System.Object` initializer syntax. Alternatively, an 
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the route
            parameters.
        
        :type routeValues: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.MvcForm
        :return: 
            An :any:`Microsoft.AspNetCore.Mvc.Rendering.MvcForm` instance which renders the </form> end tag when disposed.
    
        
        .. code-block:: csharp
    
            public static MvcForm BeginForm(this IHtmlHelper htmlHelper, object routeValues)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperFormExtensions.BeginForm(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.String)
    
        
    
        
        Renders a <form> start tag to the response. When the user submits the form, the action with name
        <em>actionName</em> will process the request.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param actionName: The name of the action method.
        
        :type actionName: System.String
    
        
        :param controllerName: The name of the controller.
        
        :type controllerName: System.String
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.MvcForm
        :return: 
            An :any:`Microsoft.AspNetCore.Mvc.Rendering.MvcForm` instance which renders the </form> end tag when disposed.
    
        
        .. code-block:: csharp
    
            public static MvcForm BeginForm(this IHtmlHelper htmlHelper, string actionName, string controllerName)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperFormExtensions.BeginForm(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.String, Microsoft.AspNetCore.Mvc.Rendering.FormMethod)
    
        
    
        
        Renders a <form> start tag to the response. When the user submits the form, the action with name
        <em>actionName</em> will process the request.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param actionName: The name of the action method.
        
        :type actionName: System.String
    
        
        :param controllerName: The name of the controller.
        
        :type controllerName: System.String
    
        
        :param method: The HTTP method for processing the form, either GET or POST.
        
        :type method: Microsoft.AspNetCore.Mvc.Rendering.FormMethod
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.MvcForm
        :return: 
            An :any:`Microsoft.AspNetCore.Mvc.Rendering.MvcForm` instance which renders the </form> end tag when disposed.
    
        
        .. code-block:: csharp
    
            public static MvcForm BeginForm(this IHtmlHelper htmlHelper, string actionName, string controllerName, FormMethod method)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperFormExtensions.BeginForm(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.String, Microsoft.AspNetCore.Mvc.Rendering.FormMethod, System.Object)
    
        
    
        
        Renders a <form> start tag to the response. When the user submits the form, the action with name
        <em>actionName</em> will process the request.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param actionName: The name of the action method.
        
        :type actionName: System.String
    
        
        :param controllerName: The name of the controller.
        
        :type controllerName: System.String
    
        
        :param method: The HTTP method for processing the form, either GET or POST.
        
        :type method: Microsoft.AspNetCore.Mvc.Rendering.FormMethod
    
        
        :param htmlAttributes: 
            An :any:`System.Object` that contains the HTML attributes for the element. Alternatively, an 
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the HTML
            attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.MvcForm
        :return: 
            An :any:`Microsoft.AspNetCore.Mvc.Rendering.MvcForm` instance which renders the </form> end tag when disposed.
    
        
        .. code-block:: csharp
    
            public static MvcForm BeginForm(this IHtmlHelper htmlHelper, string actionName, string controllerName, FormMethod method, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperFormExtensions.BeginForm(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.String, System.Object)
    
        
    
        
        Renders a <form> start tag to the response. When the user submits the form, the action with name
        <em>actionName</em> will process the request.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param actionName: The name of the action method.
        
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
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.MvcForm
        :return: 
            An :any:`Microsoft.AspNetCore.Mvc.Rendering.MvcForm` instance which renders the </form> end tag when disposed.
    
        
        .. code-block:: csharp
    
            public static MvcForm BeginForm(this IHtmlHelper htmlHelper, string actionName, string controllerName, object routeValues)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperFormExtensions.BeginForm(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.String, System.Object, Microsoft.AspNetCore.Mvc.Rendering.FormMethod)
    
        
    
        
        Renders a <form> start tag to the response. When the user submits the form, the action with name
        <em>actionName</em> will process the request.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param actionName: The name of the action method.
        
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
    
        
        :param method: The HTTP method for processing the form, either GET or POST.
        
        :type method: Microsoft.AspNetCore.Mvc.Rendering.FormMethod
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.MvcForm
        :return: 
            An :any:`Microsoft.AspNetCore.Mvc.Rendering.MvcForm` instance which renders the </form> end tag when disposed.
    
        
        .. code-block:: csharp
    
            public static MvcForm BeginForm(this IHtmlHelper htmlHelper, string actionName, string controllerName, object routeValues, FormMethod method)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperFormExtensions.BeginRouteForm(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.Object)
    
        
    
        
        Renders a <form> start tag to the response. The first route that can provide a URL with the
        specified <em>routeValues</em> generates the <form>'s <code>action</code> attribute value.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param routeValues: 
            An :any:`System.Object` that contains the parameters for a route. The parameters are retrieved through
            reflection by examining the properties of the :any:`System.Object`\. This :any:`System.Object` is typically
            created using :any:`System.Object` initializer syntax. Alternatively, an 
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the route
            parameters.
        
        :type routeValues: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.MvcForm
        :return: 
            An :any:`Microsoft.AspNetCore.Mvc.Rendering.MvcForm` instance which renders the </form> end tag when disposed.
    
        
        .. code-block:: csharp
    
            public static MvcForm BeginRouteForm(this IHtmlHelper htmlHelper, object routeValues)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperFormExtensions.BeginRouteForm(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.Object, System.Nullable<System.Boolean>)
    
        
    
        
        Renders a <form> start tag to the response. The first route that can provide a URL with the
        specified <em>routeValues</em> generates the <form>'s <code>action</code> attribute value.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param routeValues: 
            An :any:`System.Object` that contains the parameters for a route. The parameters are retrieved through
            reflection by examining the properties of the :any:`System.Object`\. This :any:`System.Object` is typically
            created using :any:`System.Object` initializer syntax. Alternatively, an 
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the route
            parameters.
        
        :type routeValues: System.Object
    
        
        :param antiforgery: 
            If <code>true</code>, <form> elements will include an antiforgery token.
            If <code>false</code>, suppresses the generation an <input> of type "hidden" with an antiforgery token.
            If <code>null</code>, <form> elements will include an antiforgery token.
        
        :type antiforgery: System.Nullable<System.Nullable`1>{System.Boolean<System.Boolean>}
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.MvcForm
        :return: 
            An :any:`Microsoft.AspNetCore.Mvc.Rendering.MvcForm` instance which renders the </form> end tag when disposed.
    
        
        .. code-block:: csharp
    
            public static MvcForm BeginRouteForm(this IHtmlHelper htmlHelper, object routeValues, bool ? antiforgery)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperFormExtensions.BeginRouteForm(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String)
    
        
    
        
        Renders a <form> start tag to the response. The route with name <em>routeName</em>
        generates the <form>'s <code>action</code> attribute value.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param routeName: The name of the route.
        
        :type routeName: System.String
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.MvcForm
        :return: 
            An :any:`Microsoft.AspNetCore.Mvc.Rendering.MvcForm` instance which renders the </form> end tag when disposed.
    
        
        .. code-block:: csharp
    
            public static MvcForm BeginRouteForm(this IHtmlHelper htmlHelper, string routeName)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperFormExtensions.BeginRouteForm(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, Microsoft.AspNetCore.Mvc.Rendering.FormMethod)
    
        
    
        
        Renders a <form> start tag to the response. The route with name <em>routeName</em>
        generates the <form>'s <code>action</code> attribute value.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param routeName: The name of the route.
        
        :type routeName: System.String
    
        
        :param method: The HTTP method for processing the form, either GET or POST.
        
        :type method: Microsoft.AspNetCore.Mvc.Rendering.FormMethod
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.MvcForm
        :return: 
            An :any:`Microsoft.AspNetCore.Mvc.Rendering.MvcForm` instance which renders the </form> end tag when disposed.
    
        
        .. code-block:: csharp
    
            public static MvcForm BeginRouteForm(this IHtmlHelper htmlHelper, string routeName, FormMethod method)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperFormExtensions.BeginRouteForm(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, Microsoft.AspNetCore.Mvc.Rendering.FormMethod, System.Object)
    
        
    
        
        Renders a <form> start tag to the response. The route with name <em>routeName</em>
        generates the <form>'s <code>action</code> attribute value.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param routeName: The name of the route.
        
        :type routeName: System.String
    
        
        :param method: The HTTP method for processing the form, either GET or POST.
        
        :type method: Microsoft.AspNetCore.Mvc.Rendering.FormMethod
    
        
        :param htmlAttributes: 
            An :any:`System.Object` that contains the HTML attributes for the element. Alternatively, an 
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the HTML
            attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.MvcForm
        :return: 
            An :any:`Microsoft.AspNetCore.Mvc.Rendering.MvcForm` instance which renders the </form> end tag when disposed.
    
        
        .. code-block:: csharp
    
            public static MvcForm BeginRouteForm(this IHtmlHelper htmlHelper, string routeName, FormMethod method, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperFormExtensions.BeginRouteForm(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.Nullable<System.Boolean>)
    
        
    
        
        Renders a <form> start tag to the response. The route with name <em>routeName</em>
        generates the <form>'s <code>action</code> attribute value.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param routeName: The name of the route.
        
        :type routeName: System.String
    
        
        :param antiforgery: 
            If <code>true</code>, <form> elements will include an antiforgery token.
            If <code>false</code>, suppresses the generation an <input> of type "hidden" with an antiforgery token.
            If <code>null</code>, <form> elements will include an antiforgery token.
        
        :type antiforgery: System.Nullable<System.Nullable`1>{System.Boolean<System.Boolean>}
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.MvcForm
        :return: 
            An :any:`Microsoft.AspNetCore.Mvc.Rendering.MvcForm` instance which renders the </form> end tag when disposed.
    
        
        .. code-block:: csharp
    
            public static MvcForm BeginRouteForm(this IHtmlHelper htmlHelper, string routeName, bool ? antiforgery)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperFormExtensions.BeginRouteForm(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.Object)
    
        
    
        
        Renders a <form> start tag to the response. The route with name <em>routeName</em>
        generates the <form>'s <code>action</code> attribute value.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param routeName: The name of the route.
        
        :type routeName: System.String
    
        
        :param routeValues: 
            An :any:`System.Object` that contains the parameters for a route. The parameters are retrieved through
            reflection by examining the properties of the :any:`System.Object`\. This :any:`System.Object` is typically
            created using :any:`System.Object` initializer syntax. Alternatively, an 
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the route
            parameters.
        
        :type routeValues: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.MvcForm
        :return: 
            An :any:`Microsoft.AspNetCore.Mvc.Rendering.MvcForm` instance which renders the </form> end tag when disposed.
    
        
        .. code-block:: csharp
    
            public static MvcForm BeginRouteForm(this IHtmlHelper htmlHelper, string routeName, object routeValues)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperFormExtensions.BeginRouteForm(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.Object, Microsoft.AspNetCore.Mvc.Rendering.FormMethod)
    
        
    
        
        Renders a <form> start tag to the response. The route with name <em>routeName</em>
        generates the <form>'s <code>action</code> attribute value.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param routeName: The name of the route.
        
        :type routeName: System.String
    
        
        :param routeValues: 
            An :any:`System.Object` that contains the parameters for a route. The parameters are retrieved through
            reflection by examining the properties of the :any:`System.Object`\. This :any:`System.Object` is typically
            created using :any:`System.Object` initializer syntax. Alternatively, an 
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the route
            parameters.
        
        :type routeValues: System.Object
    
        
        :param method: The HTTP method for processing the form, either GET or POST.
        
        :type method: Microsoft.AspNetCore.Mvc.Rendering.FormMethod
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.MvcForm
        :return: 
            An :any:`Microsoft.AspNetCore.Mvc.Rendering.MvcForm` instance which renders the </form> end tag when disposed.
    
        
        .. code-block:: csharp
    
            public static MvcForm BeginRouteForm(this IHtmlHelper htmlHelper, string routeName, object routeValues, FormMethod method)
    

