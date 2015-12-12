

HtmlHelperSelectExtensions Class
================================



.. contents:: 
   :local:



Summary
-------

Select-related extensions for :any:`Microsoft.AspNet.Mvc.Rendering.IHtmlHelper` and :any:`Microsoft.AspNet.Mvc.Rendering.IHtmlHelper\`1`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Rendering.HtmlHelperSelectExtensions`








Syntax
------

.. code-block:: csharp

   public class HtmlHelperSelectExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/Rendering/HtmlHelperSelectExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperSelectExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperSelectExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperSelectExtensions.DropDownList(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String)
    
        
    
        Returns a single-selection HTML &lt;select&gt; element for the ``expression``.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;select&gt; element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent DropDownList(IHtmlHelper htmlHelper, string expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperSelectExtensions.DropDownList(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.Rendering.SelectListItem>)
    
        
    
        Returns a single-selection HTML &lt;select&gt; element for the ``expression``, using the
        specified list items.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        
        
        :param selectList: A collection of  objects used to populate the <select> element with
            <optgroup> and <option> elements.
        
        :type selectList: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.Rendering.SelectListItem}
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;select&gt; element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent DropDownList(IHtmlHelper htmlHelper, string expression, IEnumerable<SelectListItem> selectList)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperSelectExtensions.DropDownList(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.Rendering.SelectListItem>, System.Object)
    
        
    
        Returns a single-selection HTML &lt;select&gt; element for the ``expression``, using the
        specified list items and HTML attributes.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        
        
        :param selectList: A collection of  objects used to populate the <select> element with
            <optgroup> and <option> elements.
        
        :type selectList: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.Rendering.SelectListItem}
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the <select> element. Alternatively, an
            instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;select&gt; element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent DropDownList(IHtmlHelper htmlHelper, string expression, IEnumerable<SelectListItem> selectList, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperSelectExtensions.DropDownList(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.Rendering.SelectListItem>, System.String)
    
        
    
        Returns a single-selection HTML &lt;select&gt; element for the ``expression``, using the
        specified list items and option label.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        
        
        :param selectList: A collection of  objects used to populate the <select> element with
            <optgroup> and <option> elements.
        
        :type selectList: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.Rendering.SelectListItem}
        
        
        :param optionLabel: The text for a default empty item. Does not include such an item if argument is null.
        
        :type optionLabel: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;select&gt; element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent DropDownList(IHtmlHelper htmlHelper, string expression, IEnumerable<SelectListItem> selectList, string optionLabel)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperSelectExtensions.DropDownList(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.String)
    
        
    
        Returns a single-selection HTML &lt;select&gt; element for the ``expression``, using the
        option label.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        
        
        :param optionLabel: The text for a default empty item. Does not include such an item if argument is null.
        
        :type optionLabel: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;select&gt; element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent DropDownList(IHtmlHelper htmlHelper, string expression, string optionLabel)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperSelectExtensions.DropDownListFor<TModel, TResult>(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.Rendering.SelectListItem>)
    
        
    
        Returns a single-selection HTML &lt;select&gt; element for the ``expression``, using the
        specified list items.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper{{TModel}}
        
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        
        
        :param selectList: A collection of  objects used to populate the <select> element with
            <optgroup> and <option> elements.
        
        :type selectList: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.Rendering.SelectListItem}
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;select&gt; element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent DropDownListFor<TModel, TResult>(IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression, IEnumerable<SelectListItem> selectList)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperSelectExtensions.DropDownListFor<TModel, TResult>(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.Rendering.SelectListItem>, System.Object)
    
        
    
        Returns a single-selection HTML &lt;select&gt; element for the ``expression``, using the
        specified list items and HTML attributes.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper{{TModel}}
        
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        
        
        :param selectList: A collection of  objects used to populate the <select> element with
            <optgroup> and <option> elements.
        
        :type selectList: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.Rendering.SelectListItem}
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the <select> element. Alternatively, an
            instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;select&gt; element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent DropDownListFor<TModel, TResult>(IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression, IEnumerable<SelectListItem> selectList, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperSelectExtensions.DropDownListFor<TModel, TResult>(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.Rendering.SelectListItem>, System.String)
    
        
    
        Returns a single-selection HTML &lt;select&gt; element for the ``expression``, using the
        specified list items and option label.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper{{TModel}}
        
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        
        
        :param selectList: A collection of  objects used to populate the <select> element with
            <optgroup> and <option> elements.
        
        :type selectList: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.Rendering.SelectListItem}
        
        
        :param optionLabel: The text for a default empty item. Does not include such an item if argument is null.
        
        :type optionLabel: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;select&gt; element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent DropDownListFor<TModel, TResult>(IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression, IEnumerable<SelectListItem> selectList, string optionLabel)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperSelectExtensions.ListBox(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String)
    
        
    
        Returns a multi-selection &lt;select&gt; element for the ``expression``.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;select&gt; element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent ListBox(IHtmlHelper htmlHelper, string expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperSelectExtensions.ListBox(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.Rendering.SelectListItem>)
    
        
    
        Returns a multi-selection &lt;select&gt; element for the ``expression``, using the
        specified list items.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        
        
        :param selectList: A collection of  objects used to populate the <select> element with
            <optgroup> and <option> elements.
        
        :type selectList: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.Rendering.SelectListItem}
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;select&gt; element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent ListBox(IHtmlHelper htmlHelper, string expression, IEnumerable<SelectListItem> selectList)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperSelectExtensions.ListBoxFor<TModel, TResult>(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.Rendering.SelectListItem>)
    
        
    
        Returns a multi-selection &lt;select&gt; element for the  ``expression``, using the
        specified list items.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper{{TModel}}
        
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        
        
        :param selectList: A collection of  objects used to populate the <select> element with
            <optgroup> and <option> elements.
        
        :type selectList: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.Rendering.SelectListItem}
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;select&gt; element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent ListBoxFor<TModel, TResult>(IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression, IEnumerable<SelectListItem> selectList)
    

