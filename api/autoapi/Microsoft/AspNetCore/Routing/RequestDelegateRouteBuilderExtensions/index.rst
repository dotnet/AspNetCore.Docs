

RequestDelegateRouteBuilderExtensions Class
===========================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Routing`
Assemblies
    * Microsoft.AspNetCore.Routing

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Routing.RequestDelegateRouteBuilderExtensions`








Syntax
------

.. code-block:: csharp

    public class RequestDelegateRouteBuilderExtensions








.. dn:class:: Microsoft.AspNetCore.Routing.RequestDelegateRouteBuilderExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Routing.RequestDelegateRouteBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Routing.RequestDelegateRouteBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Routing.RequestDelegateRouteBuilderExtensions.MapDelete(Microsoft.AspNetCore.Routing.IRouteBuilder, System.String, Microsoft.AspNetCore.Http.RequestDelegate)
    
        
    
        
        Adds a route to the :any:`Microsoft.AspNetCore.Routing.IRouteBuilder` that only matches HTTP DELETE requests for the given
        <em>template</em>, and <em>handler</em>.
    
        
    
        
        :param builder: The :any:`Microsoft.AspNetCore.Routing.IRouteBuilder`\.
        
        :type builder: Microsoft.AspNetCore.Routing.IRouteBuilder
    
        
        :param template: The route template.
        
        :type template: System.String
    
        
        :param handler: The :any:`Microsoft.AspNetCore.Http.RequestDelegate` route handler.
        
        :type handler: Microsoft.AspNetCore.Http.RequestDelegate
        :rtype: Microsoft.AspNetCore.Routing.IRouteBuilder
        :return: A reference to the <em>builder</em> after this operation has completed.
    
        
        .. code-block:: csharp
    
            public static IRouteBuilder MapDelete(IRouteBuilder builder, string template, RequestDelegate handler)
    
    .. dn:method:: Microsoft.AspNetCore.Routing.RequestDelegateRouteBuilderExtensions.MapDelete(Microsoft.AspNetCore.Routing.IRouteBuilder, System.String, System.Action<Microsoft.AspNetCore.Builder.IApplicationBuilder>)
    
        
    
        
        Adds a route to the :any:`Microsoft.AspNetCore.Routing.IRouteBuilder` that only matches HTTP DELETE requests for the given
        <em>template</em>, and <em>action</em>.
    
        
    
        
        :param builder: The :any:`Microsoft.AspNetCore.Routing.IRouteBuilder`\.
        
        :type builder: Microsoft.AspNetCore.Routing.IRouteBuilder
    
        
        :param template: The route template.
        
        :type template: System.String
    
        
        :param action: The action to apply to the :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder`\.
        
        :type action: System.Action<System.Action`1>{Microsoft.AspNetCore.Builder.IApplicationBuilder<Microsoft.AspNetCore.Builder.IApplicationBuilder>}
        :rtype: Microsoft.AspNetCore.Routing.IRouteBuilder
        :return: A reference to the <em>builder</em> after this operation has completed.
    
        
        .. code-block:: csharp
    
            public static IRouteBuilder MapDelete(IRouteBuilder builder, string template, Action<IApplicationBuilder> action)
    
    .. dn:method:: Microsoft.AspNetCore.Routing.RequestDelegateRouteBuilderExtensions.MapGet(Microsoft.AspNetCore.Routing.IRouteBuilder, System.String, Microsoft.AspNetCore.Http.RequestDelegate)
    
        
    
        
        Adds a route to the :any:`Microsoft.AspNetCore.Routing.IRouteBuilder` that only matches HTTP GET requests for the given
        <em>template</em>, and <em>handler</em>.
    
        
    
        
        :param builder: The :any:`Microsoft.AspNetCore.Routing.IRouteBuilder`\.
        
        :type builder: Microsoft.AspNetCore.Routing.IRouteBuilder
    
        
        :param template: The route template.
        
        :type template: System.String
    
        
        :param handler: The :any:`Microsoft.AspNetCore.Http.RequestDelegate` route handler.
        
        :type handler: Microsoft.AspNetCore.Http.RequestDelegate
        :rtype: Microsoft.AspNetCore.Routing.IRouteBuilder
        :return: A reference to the <em>builder</em> after this operation has completed.
    
        
        .. code-block:: csharp
    
            public static IRouteBuilder MapGet(IRouteBuilder builder, string template, RequestDelegate handler)
    
    .. dn:method:: Microsoft.AspNetCore.Routing.RequestDelegateRouteBuilderExtensions.MapGet(Microsoft.AspNetCore.Routing.IRouteBuilder, System.String, System.Action<Microsoft.AspNetCore.Builder.IApplicationBuilder>)
    
        
    
        
        Adds a route to the :any:`Microsoft.AspNetCore.Routing.IRouteBuilder` that only matches HTTP GET requests for the given
        <em>template</em>, and <em>action</em>.
    
        
    
        
        :param builder: The :any:`Microsoft.AspNetCore.Routing.IRouteBuilder`\.
        
        :type builder: Microsoft.AspNetCore.Routing.IRouteBuilder
    
        
        :param template: The route template.
        
        :type template: System.String
    
        
        :param action: The action to apply to the :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder`\.
        
        :type action: System.Action<System.Action`1>{Microsoft.AspNetCore.Builder.IApplicationBuilder<Microsoft.AspNetCore.Builder.IApplicationBuilder>}
        :rtype: Microsoft.AspNetCore.Routing.IRouteBuilder
        :return: A reference to the <em>builder</em> after this operation has completed.
    
        
        .. code-block:: csharp
    
            public static IRouteBuilder MapGet(IRouteBuilder builder, string template, Action<IApplicationBuilder> action)
    
    .. dn:method:: Microsoft.AspNetCore.Routing.RequestDelegateRouteBuilderExtensions.MapPost(Microsoft.AspNetCore.Routing.IRouteBuilder, System.String, Microsoft.AspNetCore.Http.RequestDelegate)
    
        
    
        
        Adds a route to the :any:`Microsoft.AspNetCore.Routing.IRouteBuilder` that only matches HTTP POST requests for the given
        <em>template</em>, and <em>handler</em>.
    
        
    
        
        :param builder: The :any:`Microsoft.AspNetCore.Routing.IRouteBuilder`\.
        
        :type builder: Microsoft.AspNetCore.Routing.IRouteBuilder
    
        
        :param template: The route template.
        
        :type template: System.String
    
        
        :param handler: The :any:`Microsoft.AspNetCore.Http.RequestDelegate` route handler.
        
        :type handler: Microsoft.AspNetCore.Http.RequestDelegate
        :rtype: Microsoft.AspNetCore.Routing.IRouteBuilder
        :return: A reference to the <em>builder</em> after this operation has completed.
    
        
        .. code-block:: csharp
    
            public static IRouteBuilder MapPost(IRouteBuilder builder, string template, RequestDelegate handler)
    
    .. dn:method:: Microsoft.AspNetCore.Routing.RequestDelegateRouteBuilderExtensions.MapPost(Microsoft.AspNetCore.Routing.IRouteBuilder, System.String, System.Action<Microsoft.AspNetCore.Builder.IApplicationBuilder>)
    
        
    
        
        Adds a route to the :any:`Microsoft.AspNetCore.Routing.IRouteBuilder` that only matches HTTP POST requests for the given
        <em>template</em>, and <em>action</em>.
    
        
    
        
        :param builder: The :any:`Microsoft.AspNetCore.Routing.IRouteBuilder`\.
        
        :type builder: Microsoft.AspNetCore.Routing.IRouteBuilder
    
        
        :param template: The route template.
        
        :type template: System.String
    
        
        :param action: The action to apply to the :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder`\.
        
        :type action: System.Action<System.Action`1>{Microsoft.AspNetCore.Builder.IApplicationBuilder<Microsoft.AspNetCore.Builder.IApplicationBuilder>}
        :rtype: Microsoft.AspNetCore.Routing.IRouteBuilder
        :return: A reference to the <em>builder</em> after this operation has completed.
    
        
        .. code-block:: csharp
    
            public static IRouteBuilder MapPost(IRouteBuilder builder, string template, Action<IApplicationBuilder> action)
    
    .. dn:method:: Microsoft.AspNetCore.Routing.RequestDelegateRouteBuilderExtensions.MapPut(Microsoft.AspNetCore.Routing.IRouteBuilder, System.String, Microsoft.AspNetCore.Http.RequestDelegate)
    
        
    
        
        Adds a route to the :any:`Microsoft.AspNetCore.Routing.IRouteBuilder` that only matches HTTP PUT requests for the given
        <em>template</em>, and <em>handler</em>.
    
        
    
        
        :param builder: The :any:`Microsoft.AspNetCore.Routing.IRouteBuilder`\.
        
        :type builder: Microsoft.AspNetCore.Routing.IRouteBuilder
    
        
        :param template: The route template.
        
        :type template: System.String
    
        
        :param handler: The :any:`Microsoft.AspNetCore.Http.RequestDelegate` route handler.
        
        :type handler: Microsoft.AspNetCore.Http.RequestDelegate
        :rtype: Microsoft.AspNetCore.Routing.IRouteBuilder
        :return: A reference to the <em>builder</em> after this operation has completed.
    
        
        .. code-block:: csharp
    
            public static IRouteBuilder MapPut(IRouteBuilder builder, string template, RequestDelegate handler)
    
    .. dn:method:: Microsoft.AspNetCore.Routing.RequestDelegateRouteBuilderExtensions.MapPut(Microsoft.AspNetCore.Routing.IRouteBuilder, System.String, System.Action<Microsoft.AspNetCore.Builder.IApplicationBuilder>)
    
        
    
        
        Adds a route to the :any:`Microsoft.AspNetCore.Routing.IRouteBuilder` that only matches HTTP PUT requests for the given
        <em>template</em>, and <em>action</em>.
    
        
    
        
        :param builder: The :any:`Microsoft.AspNetCore.Routing.IRouteBuilder`\.
        
        :type builder: Microsoft.AspNetCore.Routing.IRouteBuilder
    
        
        :param template: The route template.
        
        :type template: System.String
    
        
        :param action: The action to apply to the :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder`\.
        
        :type action: System.Action<System.Action`1>{Microsoft.AspNetCore.Builder.IApplicationBuilder<Microsoft.AspNetCore.Builder.IApplicationBuilder>}
        :rtype: Microsoft.AspNetCore.Routing.IRouteBuilder
        :return: A reference to the <em>builder</em> after this operation has completed.
    
        
        .. code-block:: csharp
    
            public static IRouteBuilder MapPut(IRouteBuilder builder, string template, Action<IApplicationBuilder> action)
    
    .. dn:method:: Microsoft.AspNetCore.Routing.RequestDelegateRouteBuilderExtensions.MapRoute(Microsoft.AspNetCore.Routing.IRouteBuilder, System.String, Microsoft.AspNetCore.Http.RequestDelegate)
    
        
    
        
        Adds a route to the :any:`Microsoft.AspNetCore.Routing.IRouteBuilder` for the given <em>template</em>, and
        <em>handler</em>.
    
        
    
        
        :param builder: The :any:`Microsoft.AspNetCore.Routing.IRouteBuilder`\.
        
        :type builder: Microsoft.AspNetCore.Routing.IRouteBuilder
    
        
        :param template: The route template.
        
        :type template: System.String
    
        
        :param handler: The :any:`Microsoft.AspNetCore.Http.RequestDelegate` route handler.
        
        :type handler: Microsoft.AspNetCore.Http.RequestDelegate
        :rtype: Microsoft.AspNetCore.Routing.IRouteBuilder
        :return: A reference to the <em>builder</em> after this operation has completed.
    
        
        .. code-block:: csharp
    
            public static IRouteBuilder MapRoute(IRouteBuilder builder, string template, RequestDelegate handler)
    
    .. dn:method:: Microsoft.AspNetCore.Routing.RequestDelegateRouteBuilderExtensions.MapRoute(Microsoft.AspNetCore.Routing.IRouteBuilder, System.String, System.Action<Microsoft.AspNetCore.Builder.IApplicationBuilder>)
    
        
    
        
        Adds a route to the :any:`Microsoft.AspNetCore.Routing.IRouteBuilder` for the given <em>template</em>, and
        <em>action</em>.
    
        
    
        
        :param builder: The :any:`Microsoft.AspNetCore.Routing.IRouteBuilder`\.
        
        :type builder: Microsoft.AspNetCore.Routing.IRouteBuilder
    
        
        :param template: The route template.
        
        :type template: System.String
    
        
        :param action: The action to apply to the :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder`\.
        
        :type action: System.Action<System.Action`1>{Microsoft.AspNetCore.Builder.IApplicationBuilder<Microsoft.AspNetCore.Builder.IApplicationBuilder>}
        :rtype: Microsoft.AspNetCore.Routing.IRouteBuilder
        :return: A reference to the <em>builder</em> after this operation has completed.
    
        
        .. code-block:: csharp
    
            public static IRouteBuilder MapRoute(IRouteBuilder builder, string template, Action<IApplicationBuilder> action)
    
    .. dn:method:: Microsoft.AspNetCore.Routing.RequestDelegateRouteBuilderExtensions.MapVerb(Microsoft.AspNetCore.Routing.IRouteBuilder, System.String, System.String, Microsoft.AspNetCore.Http.RequestDelegate)
    
        
    
        
        Adds a route to the :any:`Microsoft.AspNetCore.Routing.IRouteBuilder` that only matches HTTP requests for the given
        <em>verb</em>, <em>template</em>, and <em>handler</em>.
    
        
    
        
        :param builder: The :any:`Microsoft.AspNetCore.Routing.IRouteBuilder`\.
        
        :type builder: Microsoft.AspNetCore.Routing.IRouteBuilder
    
        
        :param verb: The HTTP verb allowed by the route.
        
        :type verb: System.String
    
        
        :param template: The route template.
        
        :type template: System.String
    
        
        :param handler: The :any:`Microsoft.AspNetCore.Http.RequestDelegate` route handler.
        
        :type handler: Microsoft.AspNetCore.Http.RequestDelegate
        :rtype: Microsoft.AspNetCore.Routing.IRouteBuilder
        :return: A reference to the <em>builder</em> after this operation has completed.
    
        
        .. code-block:: csharp
    
            public static IRouteBuilder MapVerb(IRouteBuilder builder, string verb, string template, RequestDelegate handler)
    
    .. dn:method:: Microsoft.AspNetCore.Routing.RequestDelegateRouteBuilderExtensions.MapVerb(Microsoft.AspNetCore.Routing.IRouteBuilder, System.String, System.String, System.Action<Microsoft.AspNetCore.Builder.IApplicationBuilder>)
    
        
    
        
        Adds a route to the :any:`Microsoft.AspNetCore.Routing.IRouteBuilder` that only matches HTTP requests for the given
        <em>verb</em>, <em>template</em>, and <em>action</em>.
    
        
    
        
        :param builder: The :any:`Microsoft.AspNetCore.Routing.IRouteBuilder`\.
        
        :type builder: Microsoft.AspNetCore.Routing.IRouteBuilder
    
        
        :param verb: The HTTP verb allowed by the route.
        
        :type verb: System.String
    
        
        :param template: The route template.
        
        :type template: System.String
    
        
        :param action: The action to apply to the :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder`\.
        
        :type action: System.Action<System.Action`1>{Microsoft.AspNetCore.Builder.IApplicationBuilder<Microsoft.AspNetCore.Builder.IApplicationBuilder>}
        :rtype: Microsoft.AspNetCore.Routing.IRouteBuilder
        :return: A reference to the <em>builder</em> after this operation has completed.
    
        
        .. code-block:: csharp
    
            public static IRouteBuilder MapVerb(IRouteBuilder builder, string verb, string template, Action<IApplicationBuilder> action)
    

