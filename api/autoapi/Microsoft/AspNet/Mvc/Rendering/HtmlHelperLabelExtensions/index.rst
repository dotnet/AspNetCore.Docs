

HtmlHelperLabelExtensions Class
===============================



.. contents:: 
   :local:



Summary
-------

Label-related extensions for :any:`Microsoft.AspNet.Mvc.Rendering.IHtmlHelper` and :any:`Microsoft.AspNet.Mvc.Rendering.IHtmlHelper\`1`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Rendering.HtmlHelperLabelExtensions`








Syntax
------

.. code-block:: csharp

   public class HtmlHelperLabelExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/Rendering/HtmlHelperLabelExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperLabelExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperLabelExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperLabelExtensions.Label(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String)
    
        
    
        Returns a &lt;label&gt; element for the specified ``expression``.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;label&gt; element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent Label(IHtmlHelper htmlHelper, string expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperLabelExtensions.Label(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.String)
    
        
    
        Returns a &lt;label&gt; element for the specified ``expression``.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        
        
        :param labelText: The inner text of the element.
        
        :type labelText: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;label&gt; element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent Label(IHtmlHelper htmlHelper, string expression, string labelText)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperLabelExtensions.LabelForModel(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper)
    
        
    
        Returns a &lt;label&gt; element for the current model.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;label&gt; element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent LabelForModel(IHtmlHelper htmlHelper)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperLabelExtensions.LabelForModel(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.Object)
    
        
    
        Returns a &lt;label&gt; element for the current model.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the element. Alternatively, an
            instance containing the HTML
            attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;label&gt; element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent LabelForModel(IHtmlHelper htmlHelper, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperLabelExtensions.LabelForModel(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String)
    
        
    
        Returns a &lt;label&gt; element for the current model.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param labelText: The inner text of the element.
        
        :type labelText: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;label&gt; element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent LabelForModel(IHtmlHelper htmlHelper, string labelText)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperLabelExtensions.LabelForModel(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.Object)
    
        
    
        Returns a &lt;label&gt; element for the current model.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param labelText: The inner text of the element.
        
        :type labelText: System.String
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the element. Alternatively, an
            instance containing the HTML
            attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;label&gt; element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent LabelForModel(IHtmlHelper htmlHelper, string labelText, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperLabelExtensions.LabelFor<TModel, TResult>(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, TResult>>)
    
        
    
        Returns a &lt;label&gt; element for the specified ``expression``.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper{{TModel}}
        
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;label&gt; element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent LabelFor<TModel, TResult>(IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperLabelExtensions.LabelFor<TModel, TResult>(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.Object)
    
        
    
        Returns a &lt;label&gt; element for the specified ``expression``.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper{{TModel}}
        
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the element. Alternatively, an
            instance containing the HTML
            attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;label&gt; element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent LabelFor<TModel, TResult>(IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperLabelExtensions.LabelFor<TModel, TResult>(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.String)
    
        
    
        Returns a &lt;label&gt; element for the specified ``expression``.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper{{TModel}}
        
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        
        
        :param labelText: The inner text of the element.
        
        :type labelText: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;label&gt; element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent LabelFor<TModel, TResult>(IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression, string labelText)
    

