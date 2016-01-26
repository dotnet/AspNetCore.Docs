

HtmlHelperPartialExtensions Class
=================================



.. contents:: 
   :local:



Summary
-------

PartialView-related extensions for :any:`Microsoft.AspNet.Mvc.Rendering.IHtmlHelper`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Rendering.HtmlHelperPartialExtensions`








Syntax
------

.. code-block:: csharp

   public class HtmlHelperPartialExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/Rendering/HtmlHelperPartialExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperPartialExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperPartialExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperPartialExtensions.Partial(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String)
    
        
    
        Returns HTML markup for the specified partial view.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param partialViewName: The name of the partial view used to create the HTML markup. Must not be null.
        
        :type partialViewName: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: Returns a new <see cref="T:Microsoft.AspNet.Mvc.Rendering.HtmlString" /> containing the created HTML.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent Partial(IHtmlHelper htmlHelper, string partialViewName)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperPartialExtensions.Partial(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary)
    
        
    
        Returns HTML markup for the specified partial view.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param partialViewName: The name of the partial view used to create the HTML markup. Must not be null.
        
        :type partialViewName: System.String
        
        
        :param viewData: A  to pass into the partial view.
        
        :type viewData: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: Returns a new <see cref="T:Microsoft.AspNet.Mvc.Rendering.HtmlString" /> containing the created HTML.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent Partial(IHtmlHelper htmlHelper, string partialViewName, ViewDataDictionary viewData)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperPartialExtensions.Partial(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.Object)
    
        
    
        Returns HTML markup for the specified partial view.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param partialViewName: The name of the partial view used to create the HTML markup. Must not be null.
        
        :type partialViewName: System.String
        
        
        :param model: A model to pass into the partial view.
        
        :type model: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: Returns a new <see cref="T:Microsoft.AspNet.Mvc.Rendering.HtmlString" /> containing the created HTML.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent Partial(IHtmlHelper htmlHelper, string partialViewName, object model)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperPartialExtensions.Partial(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.Object, Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary)
    
        
    
        Returns HTML markup for the specified partial view.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param partialViewName: The name of the partial view used to create the HTML markup. Must not be null.
        
        :type partialViewName: System.String
        
        
        :param model: A model to pass into the partial view.
        
        :type model: System.Object
        
        
        :param viewData: A  to pass into the partial view.
        
        :type viewData: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: Returns a new <see cref="T:Microsoft.AspNet.Mvc.Rendering.HtmlString" /> containing the created HTML.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent Partial(IHtmlHelper htmlHelper, string partialViewName, object model, ViewDataDictionary viewData)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperPartialExtensions.PartialAsync(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String)
    
        
    
        Returns HTML markup for the specified partial view.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param partialViewName: The name of the partial view used to create the HTML markup. Must not be null.
        
        :type partialViewName: System.String
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Html.Abstractions.IHtmlContent}
        :return: A <see cref="T:System.Threading.Tasks.Task" /> that on completion returns a new <see cref="T:Microsoft.AspNet.Mvc.Rendering.HtmlString" /> containing
            the created HTML.
    
        
        .. code-block:: csharp
    
           public static Task<IHtmlContent> PartialAsync(IHtmlHelper htmlHelper, string partialViewName)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperPartialExtensions.PartialAsync(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary)
    
        
    
        Returns HTML markup for the specified partial view.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param partialViewName: The name of the partial view used to create the HTML markup. Must not be null.
        
        :type partialViewName: System.String
        
        
        :param viewData: A  to pass into the partial view.
        
        :type viewData: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Html.Abstractions.IHtmlContent}
        :return: A <see cref="T:System.Threading.Tasks.Task" /> that on completion returns a new <see cref="T:Microsoft.AspNet.Mvc.Rendering.HtmlString" /> containing
            the created HTML.
    
        
        .. code-block:: csharp
    
           public static Task<IHtmlContent> PartialAsync(IHtmlHelper htmlHelper, string partialViewName, ViewDataDictionary viewData)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperPartialExtensions.PartialAsync(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.Object)
    
        
    
        Returns HTML markup for the specified partial view.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param partialViewName: The name of the partial view used to create the HTML markup. Must not be null.
        
        :type partialViewName: System.String
        
        
        :param model: A model to pass into the partial view.
        
        :type model: System.Object
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Html.Abstractions.IHtmlContent}
        :return: A <see cref="T:System.Threading.Tasks.Task" /> that on completion returns a new <see cref="T:Microsoft.AspNet.Mvc.Rendering.HtmlString" /> containing
            the created HTML.
    
        
        .. code-block:: csharp
    
           public static Task<IHtmlContent> PartialAsync(IHtmlHelper htmlHelper, string partialViewName, object model)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperPartialExtensions.RenderPartialAsync(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String)
    
        
    
        Renders HTML markup for the specified partial view.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param partialViewName: The name of the partial view used to create the HTML markup. Must not be null.
        
        :type partialViewName: System.String
        :rtype: System.Threading.Tasks.Task
        :return: A <see cref="T:System.Threading.Tasks.Task" /> that renders the created HTML when it executes.
    
        
        .. code-block:: csharp
    
           public static Task RenderPartialAsync(IHtmlHelper htmlHelper, string partialViewName)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperPartialExtensions.RenderPartialAsync(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary)
    
        
    
        Renders HTML markup for the specified partial view.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param partialViewName: The name of the partial view used to create the HTML markup. Must not be null.
        
        :type partialViewName: System.String
        
        
        :param viewData: A  to pass into the partial view.
        
        :type viewData: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary
        :rtype: System.Threading.Tasks.Task
        :return: A <see cref="T:System.Threading.Tasks.Task" /> that renders the created HTML when it executes.
    
        
        .. code-block:: csharp
    
           public static Task RenderPartialAsync(IHtmlHelper htmlHelper, string partialViewName, ViewDataDictionary viewData)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperPartialExtensions.RenderPartialAsync(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.Object)
    
        
    
        Renders HTML markup for the specified partial view.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param partialViewName: The name of the partial view used to create the HTML markup. Must not be null.
        
        :type partialViewName: System.String
        
        
        :param model: A model to pass into the partial view.
        
        :type model: System.Object
        :rtype: System.Threading.Tasks.Task
        :return: A <see cref="T:System.Threading.Tasks.Task" /> that renders the created HTML when it executes.
    
        
        .. code-block:: csharp
    
           public static Task RenderPartialAsync(IHtmlHelper htmlHelper, string partialViewName, object model)
    

