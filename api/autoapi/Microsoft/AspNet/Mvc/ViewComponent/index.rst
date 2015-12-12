

ViewComponent Class
===================



.. contents:: 
   :local:



Summary
-------

A base class for view components.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewComponent`








Syntax
------

.. code-block:: csharp

   public abstract class ViewComponent





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewComponent.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ViewComponent

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ViewComponent
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewComponent.Content(System.String)
    
        
    
        Returns a result which will render HTML encoded text.
    
        
        
        
        :param content: The content, will be HTML encoded before output.
        
        :type content: System.String
        :rtype: Microsoft.AspNet.Mvc.ViewComponents.ContentViewComponentResult
        :return: A <see cref="T:Microsoft.AspNet.Mvc.ViewComponents.ContentViewComponentResult" />.
    
        
        .. code-block:: csharp
    
           public ContentViewComponentResult Content(string content)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewComponent.Json(System.Object)
    
        
    
        Returns a result which will render JSON text.
    
        
        
        
        :param value: The value to output in JSON text.
        
        :type value: System.Object
        :rtype: Microsoft.AspNet.Mvc.ViewComponents.JsonViewComponentResult
        :return: A <see cref="T:Microsoft.AspNet.Mvc.ViewComponents.JsonViewComponentResult" />.
    
        
        .. code-block:: csharp
    
           public JsonViewComponentResult Json(object value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewComponent.Json(System.Object, Newtonsoft.Json.JsonSerializerSettings)
    
        
    
        Returns a result which will render JSON text.
    
        
        
        
        :param value: The value to output in JSON text.
        
        :type value: System.Object
        
        
        :param serializerSettings: The  to be used by
            the formatter.
        
        :type serializerSettings: Newtonsoft.Json.JsonSerializerSettings
        :rtype: Microsoft.AspNet.Mvc.ViewComponents.JsonViewComponentResult
        :return: A <see cref="T:Microsoft.AspNet.Mvc.ViewComponents.JsonViewComponentResult" />.
    
        
        .. code-block:: csharp
    
           public JsonViewComponentResult Json(object value, JsonSerializerSettings serializerSettings)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewComponent.View()
    
        
    
        Returns a result which will render the partial view with name <c>"Default"</c>.
    
        
        :rtype: Microsoft.AspNet.Mvc.ViewComponents.ViewViewComponentResult
        :return: A <see cref="T:Microsoft.AspNet.Mvc.ViewComponents.ViewViewComponentResult" />.
    
        
        .. code-block:: csharp
    
           public ViewViewComponentResult View()
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewComponent.View(System.String)
    
        
    
        Returns a result which will render the partial view with name ``viewName``.
    
        
        
        
        :param viewName: The name of the partial view to render.
        
        :type viewName: System.String
        :rtype: Microsoft.AspNet.Mvc.ViewComponents.ViewViewComponentResult
        :return: A <see cref="T:Microsoft.AspNet.Mvc.ViewComponents.ViewViewComponentResult" />.
    
        
        .. code-block:: csharp
    
           public ViewViewComponentResult View(string viewName)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewComponent.View<TModel>(System.String, TModel)
    
        
    
        Returns a result which will render the partial view with name ``viewName``.
    
        
        
        
        :param viewName: The name of the partial view to render.
        
        :type viewName: System.String
        
        
        :param model: The model object for the view.
        
        :type model: {TModel}
        :rtype: Microsoft.AspNet.Mvc.ViewComponents.ViewViewComponentResult
        :return: A <see cref="T:Microsoft.AspNet.Mvc.ViewComponents.ViewViewComponentResult" />.
    
        
        .. code-block:: csharp
    
           public ViewViewComponentResult View<TModel>(string viewName, TModel model)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewComponent.View<TModel>(TModel)
    
        
    
        Returns a result which will render the partial view with name <c>"Default"</c>.
    
        
        
        
        :param model: The model object for the view.
        
        :type model: {TModel}
        :rtype: Microsoft.AspNet.Mvc.ViewComponents.ViewViewComponentResult
        :return: A <see cref="T:Microsoft.AspNet.Mvc.ViewComponents.ViewViewComponentResult" />.
    
        
        .. code-block:: csharp
    
           public ViewViewComponentResult View<TModel>(TModel model)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ViewComponent
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewComponent.HttpContext
    
        
    
        Gets the :any:`Microsoft.AspNet.Http.HttpContext`\.
    
        
        :rtype: Microsoft.AspNet.Http.HttpContext
    
        
        .. code-block:: csharp
    
           public HttpContext HttpContext { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewComponent.ModelState
    
        
    
        Gets the :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary
    
        
        .. code-block:: csharp
    
           public ModelStateDictionary ModelState { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewComponent.Request
    
        
    
        Gets the :any:`Microsoft.AspNet.Http.HttpRequest`\.
    
        
        :rtype: Microsoft.AspNet.Http.HttpRequest
    
        
        .. code-block:: csharp
    
           public HttpRequest Request { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewComponent.RouteData
    
        
    
        Gets the :dn:prop:`Microsoft.AspNet.Mvc.ViewComponent.RouteData` for the current request.
    
        
        :rtype: Microsoft.AspNet.Routing.RouteData
    
        
        .. code-block:: csharp
    
           public RouteData RouteData { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewComponent.Url
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Mvc.IUrlHelper`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.IUrlHelper
    
        
        .. code-block:: csharp
    
           public IUrlHelper Url { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewComponent.User
    
        
    
        Gets the :any:`System.Security.Principal.IPrincipal` for the current user.
    
        
        :rtype: System.Security.Principal.IPrincipal
    
        
        .. code-block:: csharp
    
           public IPrincipal User { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewComponent.ViewBag
    
        
    
        Gets the view bag.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public dynamic ViewBag { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewComponent.ViewComponentContext
    
        
        :rtype: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext
    
        
        .. code-block:: csharp
    
           public ViewComponentContext ViewComponentContext { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewComponent.ViewContext
    
        
    
        Gets the :dn:prop:`Microsoft.AspNet.Mvc.ViewComponent.ViewContext`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
           public ViewContext ViewContext { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewComponent.ViewData
    
        
    
        Gets the :any:`Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary
    
        
        .. code-block:: csharp
    
           public ViewDataDictionary ViewData { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewComponent.ViewEngine
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Mvc.ViewEngines.ICompositeViewEngine`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ViewEngines.ICompositeViewEngine
    
        
        .. code-block:: csharp
    
           public ICompositeViewEngine ViewEngine { get; set; }
    

