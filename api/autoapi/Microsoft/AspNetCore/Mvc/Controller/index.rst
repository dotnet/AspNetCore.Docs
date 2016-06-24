

Controller Class
================






A base class for an MVC controller with view support.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ControllerBase`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Controller`








Syntax
------

.. code-block:: csharp

    public abstract class Controller : ControllerBase, IActionFilter, IAsyncActionFilter, IFilterMetadata, IDisposable








.. dn:class:: Microsoft.AspNetCore.Mvc.Controller
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Controller

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Controller
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Controller.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Controller.Dispose(System.Boolean)
    
        
    
        
        Releases all resources currently used by this :any:`Microsoft.AspNetCore.Mvc.Controller` instance.
    
        
    
        
        :param disposing: <code>true</code> if this method is being invoked by the :dn:meth:`Microsoft.AspNetCore.Mvc.Controller.Dispose` method,
                otherwise <code>false</code>.
        
        :type disposing: System.Boolean
    
        
        .. code-block:: csharp
    
            protected virtual void Dispose(bool disposing)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Controller.Json(System.Object)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.JsonResult` object that serializes the specified <em>data</em> object
        to JSON.
    
        
    
        
        :param data: The object to serialize.
        
        :type data: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.JsonResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.JsonResult` that serializes the specified <em>data</em>
            to JSON format for the response.
    
        
        .. code-block:: csharp
    
            public virtual JsonResult Json(object data)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Controller.Json(System.Object, Newtonsoft.Json.JsonSerializerSettings)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.JsonResult` object that serializes the specified <em>data</em> object
        to JSON.
    
        
    
        
        :param data: The object to serialize.
        
        :type data: System.Object
    
        
        :param serializerSettings: The :any:`Newtonsoft.Json.JsonSerializerSettings` to be used by
            the formatter.
        
        :type serializerSettings: Newtonsoft.Json.JsonSerializerSettings
        :rtype: Microsoft.AspNetCore.Mvc.JsonResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.JsonResult` that serializes the specified <em>data</em>
            as JSON format for the response.
    
        
        .. code-block:: csharp
    
            public virtual JsonResult Json(object data, JsonSerializerSettings serializerSettings)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Controller.OnActionExecuted(Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext)
    
        
    
        
        Called after the action method is invoked.
    
        
    
        
        :param context: The action executed context.
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext
    
        
        .. code-block:: csharp
    
            public virtual void OnActionExecuted(ActionExecutedContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Controller.OnActionExecuting(Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext)
    
        
    
        
        Called before the action method is invoked.
    
        
    
        
        :param context: The action executing context.
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext
    
        
        .. code-block:: csharp
    
            public virtual void OnActionExecuting(ActionExecutingContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Controller.OnActionExecutionAsync(Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext, Microsoft.AspNetCore.Mvc.Filters.ActionExecutionDelegate)
    
        
    
        
        Called before the action method is invoked.
    
        
    
        
        :param context: The action executing context.
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext
    
        
        :param next: The :any:`Microsoft.AspNetCore.Mvc.Filters.ActionExecutionDelegate` to execute. Invoke this delegate in the body
            of :dn:meth:`Microsoft.AspNetCore.Mvc.Controller.OnActionExecutionAsync(Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext,Microsoft.AspNetCore.Mvc.Filters.ActionExecutionDelegate)` to continue execution of the action.
        
        :type next: Microsoft.AspNetCore.Mvc.Filters.ActionExecutionDelegate
        :rtype: System.Threading.Tasks.Task
        :return: A :any:`System.Threading.Tasks.Task` instance.
    
        
        .. code-block:: csharp
    
            public virtual Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Controller.PartialView()
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.PartialViewResult` object that renders a partial view to the response.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.PartialViewResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.PartialViewResult` object for the response.
    
        
        .. code-block:: csharp
    
            public virtual PartialViewResult PartialView()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Controller.PartialView(System.Object)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.PartialViewResult` object by specifying a <em>model</em>
        to be rendered by the partial view.
    
        
    
        
        :param model: The model that is rendered by the partial view.
        
        :type model: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.PartialViewResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.PartialViewResult` object for the response.
    
        
        .. code-block:: csharp
    
            public virtual PartialViewResult PartialView(object model)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Controller.PartialView(System.String)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.PartialViewResult` object by specifying a <em>viewName</em>.
    
        
    
        
        :param viewName: The name of the view that is rendered to the response.
        
        :type viewName: System.String
        :rtype: Microsoft.AspNetCore.Mvc.PartialViewResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.PartialViewResult` object for the response.
    
        
        .. code-block:: csharp
    
            public virtual PartialViewResult PartialView(string viewName)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Controller.PartialView(System.String, System.Object)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.PartialViewResult` object by specifying a <em>viewName</em>
        and the <em>model</em> to be rendered by the partial view.
    
        
    
        
        :param viewName: The name of the partial view that is rendered to the response.
        
        :type viewName: System.String
    
        
        :param model: The model that is rendered by the partial view.
        
        :type model: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.PartialViewResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.PartialViewResult` object for the response.
    
        
        .. code-block:: csharp
    
            public virtual PartialViewResult PartialView(string viewName, object model)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Controller.View()
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.ViewResult` object that renders a view to the response.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.ViewResult` object for the response.
    
        
        .. code-block:: csharp
    
            public virtual ViewResult View()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Controller.View(System.Object)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.ViewResult` object by specifying a <em>model</em>
        to be rendered by the view.
    
        
    
        
        :param model: The model that is rendered by the view.
        
        :type model: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.ViewResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.ViewResult` object for the response.
    
        
        .. code-block:: csharp
    
            public virtual ViewResult View(object model)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Controller.View(System.String)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.ViewResult` object by specifying a <em>viewName</em>.
    
        
    
        
        :param viewName: The name of the view that is rendered to the response.
        
        :type viewName: System.String
        :rtype: Microsoft.AspNetCore.Mvc.ViewResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.ViewResult` object for the response.
    
        
        .. code-block:: csharp
    
            public virtual ViewResult View(string viewName)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Controller.View(System.String, System.Object)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.ViewResult` object by specifying a <em>viewName</em>
        and the <em>model</em> to be rendered by the view.
    
        
    
        
        :param viewName: The name of the view that is rendered to the response.
        
        :type viewName: System.String
    
        
        :param model: The model that is rendered by the view.
        
        :type model: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.ViewResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.ViewResult` object for the response.
    
        
        .. code-block:: csharp
    
            public virtual ViewResult View(string viewName, object model)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Controller.ViewComponent(System.String)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.ViewComponentResult` by specifying the name of a view component to render.
    
        
    
        
        :param componentName: 
            The view component name. Can be a view component 
            :dn:prop:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptor.ShortName` or 
            :dn:prop:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptor.FullName`\.
        
        :type componentName: System.String
        :rtype: Microsoft.AspNetCore.Mvc.ViewComponentResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.ViewComponentResult` object for the response.
    
        
        .. code-block:: csharp
    
            public virtual ViewComponentResult ViewComponent(string componentName)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Controller.ViewComponent(System.String, System.Object)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.ViewComponentResult` by specifying the name of a view component to render.
    
        
    
        
        :param componentName: 
            The view component name. Can be a view component 
            :dn:prop:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptor.ShortName` or 
            :dn:prop:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptor.FullName`\.
        
        :type componentName: System.String
    
        
        :param arguments: 
            An :any:`System.Object` with properties representing arguments to be passed to the invoked view component
            method. Alternatively, an :any:`System.Collections.Generic.IDictionary\`2` instance
            containing the invocation arguments.
        
        :type arguments: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.ViewComponentResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.ViewComponentResult` object for the response.
    
        
        .. code-block:: csharp
    
            public virtual ViewComponentResult ViewComponent(string componentName, object arguments)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Controller.ViewComponent(System.Type)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.ViewComponentResult` by specifying the :any:`System.Type` of a view component to
        render.
    
        
    
        
        :param componentType: The view component :any:`System.Type`\.
        
        :type componentType: System.Type
        :rtype: Microsoft.AspNetCore.Mvc.ViewComponentResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.ViewComponentResult` object for the response.
    
        
        .. code-block:: csharp
    
            public virtual ViewComponentResult ViewComponent(Type componentType)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Controller.ViewComponent(System.Type, System.Object)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.ViewComponentResult` by specifying the :any:`System.Type` of a view component to
        render.
    
        
    
        
        :param componentType: The view component :any:`System.Type`\.
        
        :type componentType: System.Type
    
        
        :param arguments: 
            An :any:`System.Object` with properties representing arguments to be passed to the invoked view component
            method. Alternatively, an :any:`System.Collections.Generic.IDictionary\`2` instance
            containing the invocation arguments.
        
        :type arguments: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.ViewComponentResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.ViewComponentResult` object for the response.
    
        
        .. code-block:: csharp
    
            public virtual ViewComponentResult ViewComponent(Type componentType, object arguments)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Controller
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Controller.TempData
    
        
    
        
        Gets or sets :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary` used by :any:`Microsoft.AspNetCore.Mvc.ViewResult`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary
    
        
        .. code-block:: csharp
    
            public ITempDataDictionary TempData { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Controller.ViewBag
    
        
    
        
        Gets the dynamic view bag.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public dynamic ViewBag { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Controller.ViewData
    
        
    
        
        Gets or sets :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary` used by :any:`Microsoft.AspNetCore.Mvc.ViewResult` and :dn:prop:`Microsoft.AspNetCore.Mvc.Controller.ViewBag`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary
    
        
        .. code-block:: csharp
    
            public ViewDataDictionary ViewData { get; set; }
    

