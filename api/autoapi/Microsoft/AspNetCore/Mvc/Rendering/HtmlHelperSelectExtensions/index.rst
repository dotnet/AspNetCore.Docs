

HtmlHelperSelectExtensions Class
================================






Select-related extensions for :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` and :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper\`1`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperSelectExtensions`








Syntax
------

.. code-block:: csharp

    public class HtmlHelperSelectExtensions








.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperSelectExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperSelectExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperSelectExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperSelectExtensions.DropDownList(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String)
    
        
    
        
        Returns a single-selection HTML <select> element for the <em>expression</em>.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <select> element.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent DropDownList(this IHtmlHelper htmlHelper, string expression)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperSelectExtensions.DropDownList(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>)
    
        
    
        
        Returns a single-selection HTML <select> element for the <em>expression</em>, using the
        specified list items.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
    
        
        :param selectList: 
            A collection of :any:`Microsoft.AspNetCore.Mvc.Rendering.SelectListItem` objects used to populate the <select> element with
            <optgroup> and <option> elements.
        
        :type selectList: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.Rendering.SelectListItem<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>}
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <select> element.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent DropDownList(this IHtmlHelper htmlHelper, string expression, IEnumerable<SelectListItem> selectList)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperSelectExtensions.DropDownList(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>, System.Object)
    
        
    
        
        Returns a single-selection HTML <select> element for the <em>expression</em>, using the
        specified list items and HTML attributes.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
    
        
        :param selectList: 
            A collection of :any:`Microsoft.AspNetCore.Mvc.Rendering.SelectListItem` objects used to populate the <select> element with
            <optgroup> and <option> elements.
        
        :type selectList: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.Rendering.SelectListItem<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>}
    
        
        :param htmlAttributes: 
            An :any:`System.Object` that contains the HTML attributes for the <select> element. Alternatively, an 
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <select> element.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent DropDownList(this IHtmlHelper htmlHelper, string expression, IEnumerable<SelectListItem> selectList, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperSelectExtensions.DropDownList(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>, System.String)
    
        
    
        
        Returns a single-selection HTML <select> element for the <em>expression</em>, using the
        specified list items and option label.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
    
        
        :param selectList: 
            A collection of :any:`Microsoft.AspNetCore.Mvc.Rendering.SelectListItem` objects used to populate the <select> element with
            <optgroup> and <option> elements.
        
        :type selectList: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.Rendering.SelectListItem<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>}
    
        
        :param optionLabel: 
            The text for a default empty item. Does not include such an item if argument is <code>null</code>.
        
        :type optionLabel: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <select> element.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent DropDownList(this IHtmlHelper htmlHelper, string expression, IEnumerable<SelectListItem> selectList, string optionLabel)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperSelectExtensions.DropDownList(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.String)
    
        
    
        
        Returns a single-selection HTML <select> element for the <em>expression</em>, using the
        option label.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
    
        
        :param optionLabel: 
            The text for a default empty item. Does not include such an item if argument is <code>null</code>.
        
        :type optionLabel: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <select> element.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent DropDownList(this IHtmlHelper htmlHelper, string expression, string optionLabel)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperSelectExtensions.DropDownListFor<TModel, TResult>(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>)
    
        
    
        
        Returns a single-selection HTML <select> element for the <em>expression</em>, using the
        specified list items.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper\`1` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper`1>{TModel}
    
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
    
        
        :param selectList: 
            A collection of :any:`Microsoft.AspNetCore.Mvc.Rendering.SelectListItem` objects used to populate the <select> element with
            <optgroup> and <option> elements.
        
        :type selectList: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.Rendering.SelectListItem<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>}
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <select> element.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent DropDownListFor<TModel, TResult>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression, IEnumerable<SelectListItem> selectList)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperSelectExtensions.DropDownListFor<TModel, TResult>(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>, System.Object)
    
        
    
        
        Returns a single-selection HTML <select> element for the <em>expression</em>, using the
        specified list items and HTML attributes.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper\`1` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper`1>{TModel}
    
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
    
        
        :param selectList: 
            A collection of :any:`Microsoft.AspNetCore.Mvc.Rendering.SelectListItem` objects used to populate the <select> element with
            <optgroup> and <option> elements.
        
        :type selectList: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.Rendering.SelectListItem<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>}
    
        
        :param htmlAttributes: 
            An :any:`System.Object` that contains the HTML attributes for the <select> element. Alternatively, an 
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <select> element.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent DropDownListFor<TModel, TResult>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression, IEnumerable<SelectListItem> selectList, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperSelectExtensions.DropDownListFor<TModel, TResult>(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>, System.String)
    
        
    
        
        Returns a single-selection HTML <select> element for the <em>expression</em>, using the
        specified list items and option label.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper\`1` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper`1>{TModel}
    
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
    
        
        :param selectList: 
            A collection of :any:`Microsoft.AspNetCore.Mvc.Rendering.SelectListItem` objects used to populate the <select> element with
            <optgroup> and <option> elements.
        
        :type selectList: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.Rendering.SelectListItem<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>}
    
        
        :param optionLabel: 
            The text for a default empty item. Does not include such an item if argument is <code>null</code>.
        
        :type optionLabel: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <select> element.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent DropDownListFor<TModel, TResult>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression, IEnumerable<SelectListItem> selectList, string optionLabel)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperSelectExtensions.ListBox(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String)
    
        
    
        
        Returns a multi-selection <select> element for the <em>expression</em>.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <select> element.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent ListBox(this IHtmlHelper htmlHelper, string expression)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperSelectExtensions.ListBox(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>)
    
        
    
        
        Returns a multi-selection <select> element for the <em>expression</em>, using the
        specified list items.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
    
        
        :param selectList: 
            A collection of :any:`Microsoft.AspNetCore.Mvc.Rendering.SelectListItem` objects used to populate the <select> element with
            <optgroup> and <option> elements.
        
        :type selectList: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.Rendering.SelectListItem<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>}
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <select> element.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent ListBox(this IHtmlHelper htmlHelper, string expression, IEnumerable<SelectListItem> selectList)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperSelectExtensions.ListBoxFor<TModel, TResult>(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>)
    
        
    
        
        Returns a multi-selection <select> element for the  <em>expression</em>, using the
        specified list items.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper\`1` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper`1>{TModel}
    
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
    
        
        :param selectList: 
            A collection of :any:`Microsoft.AspNetCore.Mvc.Rendering.SelectListItem` objects used to populate the <select> element with
            <optgroup> and <option> elements.
        
        :type selectList: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.Rendering.SelectListItem<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>}
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <select> element.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent ListBoxFor<TModel, TResult>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression, IEnumerable<SelectListItem> selectList)
    

