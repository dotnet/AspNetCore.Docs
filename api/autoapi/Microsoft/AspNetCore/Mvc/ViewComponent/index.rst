

ViewComponent Class
===================






A base class for view components.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewComponent`








Syntax
------

.. code-block:: csharp

    public abstract class ViewComponent








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponent
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponent

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponent
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewComponent.HttpContext
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Http.HttpContext`\.
    
        
        :rtype: Microsoft.AspNetCore.Http.HttpContext
    
        
        .. code-block:: csharp
    
            public HttpContext HttpContext
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewComponent.ModelState
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary
    
        
        .. code-block:: csharp
    
            public ModelStateDictionary ModelState
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewComponent.Request
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Http.HttpRequest`\.
    
        
        :rtype: Microsoft.AspNetCore.Http.HttpRequest
    
        
        .. code-block:: csharp
    
            public HttpRequest Request
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewComponent.RouteData
    
        
    
        
        Gets the :dn:prop:`Microsoft.AspNetCore.Mvc.ViewComponent.RouteData` for the current request.
    
        
        :rtype: Microsoft.AspNetCore.Routing.RouteData
    
        
        .. code-block:: csharp
    
            public RouteData RouteData
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewComponent.Url
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.IUrlHelper`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.IUrlHelper
    
        
        .. code-block:: csharp
    
            public IUrlHelper Url
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewComponent.User
    
        
    
        
        Gets the :any:`System.Security.Principal.IPrincipal` for the current user.
    
        
        :rtype: System.Security.Principal.IPrincipal
    
        
        .. code-block:: csharp
    
            public IPrincipal User
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewComponent.ViewBag
    
        
    
        
        Gets the view bag.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public dynamic ViewBag
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewComponent.ViewComponentContext
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext
    
        
        .. code-block:: csharp
    
            public ViewComponentContext ViewComponentContext
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewComponent.ViewContext
    
        
    
        
        Gets the :dn:prop:`Microsoft.AspNetCore.Mvc.ViewComponent.ViewContext`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
            public ViewContext ViewContext
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewComponent.ViewData
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary
    
        
        .. code-block:: csharp
    
            public ViewDataDictionary ViewData
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewComponent.ViewEngine
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.ViewEngines.ICompositeViewEngine`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewEngines.ICompositeViewEngine
    
        
        .. code-block:: csharp
    
            public ICompositeViewEngine ViewEngine
            {
                get;
                set;
            }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponent
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewComponent.Content(System.String)
    
        
    
        
        Returns a result which will render HTML encoded text.
    
        
    
        
        :param content: The content, will be HTML encoded before output.
        
        :type content: System.String
        :rtype: Microsoft.AspNetCore.Mvc.ViewComponents.ContentViewComponentResult
        :return: A :any:`Microsoft.AspNetCore.Mvc.ViewComponents.ContentViewComponentResult`\.
    
        
        .. code-block:: csharp
    
            public ContentViewComponentResult Content(string content)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewComponent.View()
    
        
    
        
        Returns a result which will render the partial view with name <code>"Default"</code>.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewComponents.ViewViewComponentResult
        :return: A :any:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewViewComponentResult`\.
    
        
        .. code-block:: csharp
    
            public ViewViewComponentResult View()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewComponent.View(System.String)
    
        
    
        
        Returns a result which will render the partial view with name <em>viewName</em>.
    
        
    
        
        :param viewName: The name of the partial view to render.
        
        :type viewName: System.String
        :rtype: Microsoft.AspNetCore.Mvc.ViewComponents.ViewViewComponentResult
        :return: A :any:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewViewComponentResult`\.
    
        
        .. code-block:: csharp
    
            public ViewViewComponentResult View(string viewName)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewComponent.View<TModel>(System.String, TModel)
    
        
    
        
        Returns a result which will render the partial view with name <em>viewName</em>.
    
        
    
        
        :param viewName: The name of the partial view to render.
        
        :type viewName: System.String
    
        
        :param model: The model object for the view.
        
        :type model: TModel
        :rtype: Microsoft.AspNetCore.Mvc.ViewComponents.ViewViewComponentResult
        :return: A :any:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewViewComponentResult`\.
    
        
        .. code-block:: csharp
    
            public ViewViewComponentResult View<TModel>(string viewName, TModel model)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewComponent.View<TModel>(TModel)
    
        
    
        
        Returns a result which will render the partial view with name <code>"Default"</code>.
    
        
    
        
        :param model: The model object for the view.
        
        :type model: TModel
        :rtype: Microsoft.AspNetCore.Mvc.ViewComponents.ViewViewComponentResult
        :return: A :any:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewViewComponentResult`\.
    
        
        .. code-block:: csharp
    
            public ViewViewComponentResult View<TModel>(TModel model)
    

