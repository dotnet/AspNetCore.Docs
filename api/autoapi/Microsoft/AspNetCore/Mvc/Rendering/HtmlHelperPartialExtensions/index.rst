

HtmlHelperPartialExtensions Class
=================================






PartialView-related extensions for :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperPartialExtensions`








Syntax
------

.. code-block:: csharp

    public class HtmlHelperPartialExtensions








.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperPartialExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperPartialExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperPartialExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperPartialExtensions.Partial(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String)
    
        
    
        
        Returns HTML markup for the specified partial view.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param partialViewName: 
            The name of the partial view used to create the HTML markup. Must not be <code>null</code>.
        
        :type partialViewName: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: 
            Returns a new :any:`Microsoft.AspNetCore.Html.IHtmlContent` instance containing the created HTML.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent Partial(this IHtmlHelper htmlHelper, string partialViewName)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperPartialExtensions.Partial(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary)
    
        
    
        
        Returns HTML markup for the specified partial view.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param partialViewName: 
            The name of the partial view used to create the HTML markup. Must not be <code>null</code>.
        
        :type partialViewName: System.String
    
        
        :param viewData: A :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary` to pass into the partial view.
        
        :type viewData: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: 
            Returns a new :any:`Microsoft.AspNetCore.Html.IHtmlContent` instance containing the created HTML.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent Partial(this IHtmlHelper htmlHelper, string partialViewName, ViewDataDictionary viewData)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperPartialExtensions.Partial(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.Object)
    
        
    
        
        Returns HTML markup for the specified partial view.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param partialViewName: 
            The name of the partial view used to create the HTML markup. Must not be <code>null</code>.
        
        :type partialViewName: System.String
    
        
        :param model: A model to pass into the partial view.
        
        :type model: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: 
            Returns a new :any:`Microsoft.AspNetCore.Html.IHtmlContent` instance containing the created HTML.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent Partial(this IHtmlHelper htmlHelper, string partialViewName, object model)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperPartialExtensions.Partial(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.Object, Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary)
    
        
    
        
        Returns HTML markup for the specified partial view.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param partialViewName: 
            The name of the partial view used to create the HTML markup. Must not be <code>null</code>.
        
        :type partialViewName: System.String
    
        
        :param model: A model to pass into the partial view.
        
        :type model: System.Object
    
        
        :param viewData: A :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary` to pass into the partial view.
        
        :type viewData: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: 
            Returns a new :any:`Microsoft.AspNetCore.Html.IHtmlContent` instance containing the created HTML.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent Partial(this IHtmlHelper htmlHelper, string partialViewName, object model, ViewDataDictionary viewData)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperPartialExtensions.PartialAsync(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String)
    
        
    
        
        Returns HTML markup for the specified partial view.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param partialViewName: 
            The name of the partial view used to create the HTML markup. Must not be <code>null</code>.
        
        :type partialViewName: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Html.IHtmlContent<Microsoft.AspNetCore.Html.IHtmlContent>}
        :return: 
            A :any:`System.Threading.Tasks.Task` that on completion returns a new :any:`Microsoft.AspNetCore.Html.IHtmlContent` instance containing
            the created HTML.
    
        
        .. code-block:: csharp
    
            public static Task<IHtmlContent> PartialAsync(this IHtmlHelper htmlHelper, string partialViewName)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperPartialExtensions.PartialAsync(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary)
    
        
    
        
        Returns HTML markup for the specified partial view.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param partialViewName: 
            The name of the partial view used to create the HTML markup. Must not be <code>null</code>.
        
        :type partialViewName: System.String
    
        
        :param viewData: A :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary` to pass into the partial view.
        
        :type viewData: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Html.IHtmlContent<Microsoft.AspNetCore.Html.IHtmlContent>}
        :return: 
            A :any:`System.Threading.Tasks.Task` that on completion returns a new :any:`Microsoft.AspNetCore.Html.IHtmlContent` instance containing
            the created HTML.
    
        
        .. code-block:: csharp
    
            public static Task<IHtmlContent> PartialAsync(this IHtmlHelper htmlHelper, string partialViewName, ViewDataDictionary viewData)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperPartialExtensions.PartialAsync(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.Object)
    
        
    
        
        Returns HTML markup for the specified partial view.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param partialViewName: 
            The name of the partial view used to create the HTML markup. Must not be <code>null</code>.
        
        :type partialViewName: System.String
    
        
        :param model: A model to pass into the partial view.
        
        :type model: System.Object
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Html.IHtmlContent<Microsoft.AspNetCore.Html.IHtmlContent>}
        :return: 
            A :any:`System.Threading.Tasks.Task` that on completion returns a new :any:`Microsoft.AspNetCore.Html.IHtmlContent` instance containing
            the created HTML.
    
        
        .. code-block:: csharp
    
            public static Task<IHtmlContent> PartialAsync(this IHtmlHelper htmlHelper, string partialViewName, object model)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperPartialExtensions.RenderPartial(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String)
    
        
    
        
        Renders HTML markup for the specified partial view.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param partialViewName: 
            The name of the partial view used to create the HTML markup. Must not be <code>null</code>.
        
        :type partialViewName: System.String
    
        
        .. code-block:: csharp
    
            public static void RenderPartial(this IHtmlHelper htmlHelper, string partialViewName)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperPartialExtensions.RenderPartial(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary)
    
        
    
        
        Renders HTML markup for the specified partial view.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param partialViewName: 
            The name of the partial view used to create the HTML markup. Must not be <code>null</code>.
        
        :type partialViewName: System.String
    
        
        :param viewData: A :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary` to pass into the partial view.
        
        :type viewData: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary
    
        
        .. code-block:: csharp
    
            public static void RenderPartial(this IHtmlHelper htmlHelper, string partialViewName, ViewDataDictionary viewData)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperPartialExtensions.RenderPartial(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.Object)
    
        
    
        
        Renders HTML markup for the specified partial view.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param partialViewName: 
            The name of the partial view used to create the HTML markup. Must not be <code>null</code>.
        
        :type partialViewName: System.String
    
        
        :param model: A model to pass into the partial view.
        
        :type model: System.Object
    
        
        .. code-block:: csharp
    
            public static void RenderPartial(this IHtmlHelper htmlHelper, string partialViewName, object model)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperPartialExtensions.RenderPartialAsync(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String)
    
        
    
        
        Renders HTML markup for the specified partial view.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param partialViewName: 
            The name of the partial view used to create the HTML markup. Must not be <code>null</code>.
        
        :type partialViewName: System.String
        :rtype: System.Threading.Tasks.Task
        :return: A :any:`System.Threading.Tasks.Task` that renders the created HTML when it executes.
    
        
        .. code-block:: csharp
    
            public static Task RenderPartialAsync(this IHtmlHelper htmlHelper, string partialViewName)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperPartialExtensions.RenderPartialAsync(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary)
    
        
    
        
        Renders HTML markup for the specified partial view.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param partialViewName: 
            The name of the partial view used to create the HTML markup. Must not be <code>null</code>.
        
        :type partialViewName: System.String
    
        
        :param viewData: A :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary` to pass into the partial view.
        
        :type viewData: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary
        :rtype: System.Threading.Tasks.Task
        :return: A :any:`System.Threading.Tasks.Task` that renders the created HTML when it executes.
    
        
        .. code-block:: csharp
    
            public static Task RenderPartialAsync(this IHtmlHelper htmlHelper, string partialViewName, ViewDataDictionary viewData)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperPartialExtensions.RenderPartialAsync(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.Object)
    
        
    
        
        Renders HTML markup for the specified partial view.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param partialViewName: 
            The name of the partial view used to create the HTML markup. Must not be <code>null</code>.
        
        :type partialViewName: System.String
    
        
        :param model: A model to pass into the partial view.
        
        :type model: System.Object
        :rtype: System.Threading.Tasks.Task
        :return: A :any:`System.Threading.Tasks.Task` that renders the created HTML when it executes.
    
        
        .. code-block:: csharp
    
            public static Task RenderPartialAsync(this IHtmlHelper htmlHelper, string partialViewName, object model)
    

