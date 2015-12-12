

UrlHelperExtensions Class
=========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.UrlHelperExtensions`








Syntax
------

.. code-block:: csharp

   public class UrlHelperExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/UrlHelperExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.UrlHelperExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.UrlHelperExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.UrlHelperExtensions.Action(Microsoft.AspNet.Mvc.IUrlHelper)
    
        
    
        Generates a fully qualified or absolute URL for an action method.
    
        
        
        
        :type helper: Microsoft.AspNet.Mvc.IUrlHelper
        :rtype: System.String
        :return: The fully qualified or absolute URL to an action method.
    
        
        .. code-block:: csharp
    
           public static string Action(IUrlHelper helper)
    
    .. dn:method:: Microsoft.AspNet.Mvc.UrlHelperExtensions.Action(Microsoft.AspNet.Mvc.IUrlHelper, System.String)
    
        
    
        Generates a fully qualified or absolute URL for an action method by using the specified action name.
    
        
        
        
        :type helper: Microsoft.AspNet.Mvc.IUrlHelper
        
        
        :param action: The name of the action method.
        
        :type action: System.String
        :rtype: System.String
        :return: The fully qualified or absolute URL to an action method.
    
        
        .. code-block:: csharp
    
           public static string Action(IUrlHelper helper, string action)
    
    .. dn:method:: Microsoft.AspNet.Mvc.UrlHelperExtensions.Action(Microsoft.AspNet.Mvc.IUrlHelper, System.String, System.Object)
    
        
    
        Generates a fully qualified or absolute URL for an action method by using the specified action name,
        and route values.
    
        
        
        
        :type helper: Microsoft.AspNet.Mvc.IUrlHelper
        
        
        :param action: The name of the action method.
        
        :type action: System.String
        
        
        :param values: An object that contains route values.
        
        :type values: System.Object
        :rtype: System.String
        :return: The fully qualified or absolute URL to an action method.
    
        
        .. code-block:: csharp
    
           public static string Action(IUrlHelper helper, string action, object values)
    
    .. dn:method:: Microsoft.AspNet.Mvc.UrlHelperExtensions.Action(Microsoft.AspNet.Mvc.IUrlHelper, System.String, System.String)
    
        
    
        Generates a fully qualified or absolute URL for an action method by using the specified action name,
        and controller name.
    
        
        
        
        :type helper: Microsoft.AspNet.Mvc.IUrlHelper
        
        
        :param action: The name of the action method.
        
        :type action: System.String
        
        
        :param controller: The name of the controller.
        
        :type controller: System.String
        :rtype: System.String
        :return: The fully qualified or absolute URL to an action method.
    
        
        .. code-block:: csharp
    
           public static string Action(IUrlHelper helper, string action, string controller)
    
    .. dn:method:: Microsoft.AspNet.Mvc.UrlHelperExtensions.Action(Microsoft.AspNet.Mvc.IUrlHelper, System.String, System.String, System.Object)
    
        
    
        Generates a fully qualified or absolute URL for an action method by using the specified action name,
        controller name, and route values.
    
        
        
        
        :type helper: Microsoft.AspNet.Mvc.IUrlHelper
        
        
        :param action: The name of the action method.
        
        :type action: System.String
        
        
        :param controller: The name of the controller.
        
        :type controller: System.String
        
        
        :param values: An object that contains route values.
        
        :type values: System.Object
        :rtype: System.String
        :return: The fully qualified or absolute URL to an action method.
    
        
        .. code-block:: csharp
    
           public static string Action(IUrlHelper helper, string action, string controller, object values)
    
    .. dn:method:: Microsoft.AspNet.Mvc.UrlHelperExtensions.Action(Microsoft.AspNet.Mvc.IUrlHelper, System.String, System.String, System.Object, System.String)
    
        
    
        Generates a fully qualified or absolute URL for an action method by using the specified action name,
        controller name, route values, and protocol to use.
    
        
        
        
        :type helper: Microsoft.AspNet.Mvc.IUrlHelper
        
        
        :param action: The name of the action method.
        
        :type action: System.String
        
        
        :param controller: The name of the controller.
        
        :type controller: System.String
        
        
        :param values: An object that contains route values.
        
        :type values: System.Object
        
        
        :param protocol: The protocol for the URL, such as "http" or "https".
        
        :type protocol: System.String
        :rtype: System.String
        :return: The fully qualified or absolute URL to an action method.
    
        
        .. code-block:: csharp
    
           public static string Action(IUrlHelper helper, string action, string controller, object values, string protocol)
    
    .. dn:method:: Microsoft.AspNet.Mvc.UrlHelperExtensions.Action(Microsoft.AspNet.Mvc.IUrlHelper, System.String, System.String, System.Object, System.String, System.String)
    
        
    
        Generates a fully qualified or absolute URL for an action method by using the specified action name,
        controller name, route values, protocol to use, and host name.
    
        
        
        
        :type helper: Microsoft.AspNet.Mvc.IUrlHelper
        
        
        :param action: The name of the action method.
        
        :type action: System.String
        
        
        :param controller: The name of the controller.
        
        :type controller: System.String
        
        
        :param values: An object that contains route values.
        
        :type values: System.Object
        
        
        :param protocol: The protocol for the URL, such as "http" or "https".
        
        :type protocol: System.String
        
        
        :param host: The host name for the URL.
        
        :type host: System.String
        :rtype: System.String
        :return: The fully qualified or absolute URL to an action method.
    
        
        .. code-block:: csharp
    
           public static string Action(IUrlHelper helper, string action, string controller, object values, string protocol, string host)
    
    .. dn:method:: Microsoft.AspNet.Mvc.UrlHelperExtensions.Action(Microsoft.AspNet.Mvc.IUrlHelper, System.String, System.String, System.Object, System.String, System.String, System.String)
    
        
    
        Generates a fully qualified or absolute URL for an action method by using the specified action name,
        controller name, route values, protocol to use, host name and fragment.
    
        
        
        
        :type helper: Microsoft.AspNet.Mvc.IUrlHelper
        
        
        :param action: The name of the action method.
        
        :type action: System.String
        
        
        :param controller: The name of the controller.
        
        :type controller: System.String
        
        
        :param values: An object that contains route values.
        
        :type values: System.Object
        
        
        :param protocol: The protocol for the URL, such as "http" or "https".
        
        :type protocol: System.String
        
        
        :param host: The host name for the URL.
        
        :type host: System.String
        
        
        :param fragment: The fragment for the URL.
        
        :type fragment: System.String
        :rtype: System.String
        :return: The fully qualified or absolute URL to an action method.
    
        
        .. code-block:: csharp
    
           public static string Action(IUrlHelper helper, string action, string controller, object values, string protocol, string host, string fragment)
    
    .. dn:method:: Microsoft.AspNet.Mvc.UrlHelperExtensions.RouteUrl(Microsoft.AspNet.Mvc.IUrlHelper, System.Object)
    
        
    
        Generates a fully qualified or absolute URL for the specified route values.
    
        
        
        
        :type helper: Microsoft.AspNet.Mvc.IUrlHelper
        
        
        :param values: An object that contains route values.
        
        :type values: System.Object
        :rtype: System.String
        :return: The fully qualified or absolute URL.
    
        
        .. code-block:: csharp
    
           public static string RouteUrl(IUrlHelper helper, object values)
    
    .. dn:method:: Microsoft.AspNet.Mvc.UrlHelperExtensions.RouteUrl(Microsoft.AspNet.Mvc.IUrlHelper, System.String)
    
        
    
        Generates a fully qualified or absolute URL for the specified route name.
    
        
        
        
        :type helper: Microsoft.AspNet.Mvc.IUrlHelper
        
        
        :param routeName: The name of the route that is used to generate URL.
        
        :type routeName: System.String
        :rtype: System.String
        :return: The fully qualified or absolute URL.
    
        
        .. code-block:: csharp
    
           public static string RouteUrl(IUrlHelper helper, string routeName)
    
    .. dn:method:: Microsoft.AspNet.Mvc.UrlHelperExtensions.RouteUrl(Microsoft.AspNet.Mvc.IUrlHelper, System.String, System.Object)
    
        
    
        Generates a fully qualified or absolute URL for the specified route values by
        using the specified route name.
    
        
        
        
        :type helper: Microsoft.AspNet.Mvc.IUrlHelper
        
        
        :param routeName: The name of the route that is used to generate URL.
        
        :type routeName: System.String
        
        
        :param values: An object that contains route values.
        
        :type values: System.Object
        :rtype: System.String
        :return: The fully qualified or absolute URL.
    
        
        .. code-block:: csharp
    
           public static string RouteUrl(IUrlHelper helper, string routeName, object values)
    
    .. dn:method:: Microsoft.AspNet.Mvc.UrlHelperExtensions.RouteUrl(Microsoft.AspNet.Mvc.IUrlHelper, System.String, System.Object, System.String)
    
        
    
        Generates a fully qualified or absolute URL for the specified route values by
        using the specified route name, and protocol to use.
    
        
        
        
        :type helper: Microsoft.AspNet.Mvc.IUrlHelper
        
        
        :param routeName: The name of the route that is used to generate URL.
        
        :type routeName: System.String
        
        
        :param values: An object that contains route values.
        
        :type values: System.Object
        
        
        :param protocol: The protocol for the URL, such as "http" or "https".
        
        :type protocol: System.String
        :rtype: System.String
        :return: The fully qualified or absolute URL.
    
        
        .. code-block:: csharp
    
           public static string RouteUrl(IUrlHelper helper, string routeName, object values, string protocol)
    
    .. dn:method:: Microsoft.AspNet.Mvc.UrlHelperExtensions.RouteUrl(Microsoft.AspNet.Mvc.IUrlHelper, System.String, System.Object, System.String, System.String)
    
        
    
        Generates a fully qualified or absolute URL for the specified route values by
        using the specified route name, protocol to use, and host name.
    
        
        
        
        :type helper: Microsoft.AspNet.Mvc.IUrlHelper
        
        
        :param routeName: The name of the route that is used to generate URL.
        
        :type routeName: System.String
        
        
        :param values: An object that contains route values.
        
        :type values: System.Object
        
        
        :param protocol: The protocol for the URL, such as "http" or "https".
        
        :type protocol: System.String
        
        
        :param host: The host name for the URL.
        
        :type host: System.String
        :rtype: System.String
        :return: The fully qualified or absolute URL.
    
        
        .. code-block:: csharp
    
           public static string RouteUrl(IUrlHelper helper, string routeName, object values, string protocol, string host)
    
    .. dn:method:: Microsoft.AspNet.Mvc.UrlHelperExtensions.RouteUrl(Microsoft.AspNet.Mvc.IUrlHelper, System.String, System.Object, System.String, System.String, System.String)
    
        
    
        Generates a fully qualified or absolute URL for the specified route values by
        using the specified route name, protocol to use, host name and fragment.
    
        
        
        
        :type helper: Microsoft.AspNet.Mvc.IUrlHelper
        
        
        :param routeName: The name of the route that is used to generate URL.
        
        :type routeName: System.String
        
        
        :param values: An object that contains route values.
        
        :type values: System.Object
        
        
        :param protocol: The protocol for the URL, such as "http" or "https".
        
        :type protocol: System.String
        
        
        :param host: The host name for the URL.
        
        :type host: System.String
        
        
        :param fragment: The fragment for the URL.
        
        :type fragment: System.String
        :rtype: System.String
        :return: The fully qualified or absolute URL.
    
        
        .. code-block:: csharp
    
           public static string RouteUrl(IUrlHelper helper, string routeName, object values, string protocol, string host, string fragment)
    

