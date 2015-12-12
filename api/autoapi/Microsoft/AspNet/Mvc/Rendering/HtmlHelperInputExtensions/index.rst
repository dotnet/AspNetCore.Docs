

HtmlHelperInputExtensions Class
===============================



.. contents:: 
   :local:



Summary
-------

Input-related extensions for :any:`Microsoft.AspNet.Mvc.Rendering.IHtmlHelper` and :any:`Microsoft.AspNet.Mvc.Rendering.IHtmlHelper\`1`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Rendering.HtmlHelperInputExtensions`








Syntax
------

.. code-block:: csharp

   public class HtmlHelperInputExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ViewFeatures/Rendering/HtmlHelperInputExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperInputExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperInputExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperInputExtensions.CheckBox(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String)
    
        
    
        Returns an &lt;input&gt; element of type "checkbox" with value "true" and an &lt;input&gt; element of type
        "hidden" with value "false".
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; elements.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent CheckBox(IHtmlHelper htmlHelper, string expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperInputExtensions.CheckBox(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.Boolean)
    
        
    
        Returns an &lt;input&gt; element of type "checkbox" with value "true" and an &lt;input&gt; element of type
        "hidden" with value "false".
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        
        
        :param isChecked: If true, checkbox is initially checked.
        
        :type isChecked: System.Boolean
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; elements.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent CheckBox(IHtmlHelper htmlHelper, string expression, bool isChecked)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperInputExtensions.CheckBox(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.Object)
    
        
    
        Returns an &lt;input&gt; element of type "checkbox" with value "true" and an &lt;input&gt; element of type
        "hidden" with value "false".
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the checkbox element. Alternatively, an
            instance containing the HTML
            attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; elements.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent CheckBox(IHtmlHelper htmlHelper, string expression, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperInputExtensions.CheckBoxFor<TModel>(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, System.Boolean>>)
    
        
    
        Returns an &lt;input&gt; element of type "checkbox" with value "true" and an &lt;input&gt; element of type
        "hidden" with value "false".
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper{{TModel}}
        
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},System.Boolean}}
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; elements.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent CheckBoxFor<TModel>(IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperInputExtensions.Hidden(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String)
    
        
    
        Returns an &lt;input&gt; element of type "hidden" for the specified ``expression``.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent Hidden(IHtmlHelper htmlHelper, string expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperInputExtensions.Hidden(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.Object)
    
        
    
        Returns an &lt;input&gt; element of type "hidden" for the specified ``expression``.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        
        
        :param value: If non-null, value to include in the element.
        
        :type value: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent Hidden(IHtmlHelper htmlHelper, string expression, object value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperInputExtensions.HiddenFor<TModel, TResult>(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, TResult>>)
    
        
    
        Returns an &lt;input&gt; element of type "hidden" for the specified ``expression``.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper{{TModel}}
        
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent HiddenFor<TModel, TResult>(IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperInputExtensions.Password(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String)
    
        
    
        Returns an &lt;input&gt; element of type "password" for the specified ``expression``.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent Password(IHtmlHelper htmlHelper, string expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperInputExtensions.Password(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.Object)
    
        
    
        Returns an &lt;input&gt; element of type "password" for the specified ``expression``.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        
        
        :param value: If non-null, value to include in the element.
        
        :type value: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent Password(IHtmlHelper htmlHelper, string expression, object value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperInputExtensions.PasswordFor<TModel, TResult>(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, TResult>>)
    
        
    
        Returns an &lt;input&gt; element of type "password" for the specified ``expression``.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper{{TModel}}
        
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent PasswordFor<TModel, TResult>(IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperInputExtensions.RadioButton(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.Object)
    
        
    
        Returns an &lt;input&gt; element of type "radio" for the specified ``expression``.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        
        
        :param value: Value to include in the element. Must not be null.
        
        :type value: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent RadioButton(IHtmlHelper htmlHelper, string expression, object value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperInputExtensions.RadioButton(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.Object, System.Boolean)
    
        
    
        Returns an &lt;input&gt; element of type "radio" for the specified ``expression``.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        
        
        :param value: If non-null, value to include in the element. Must not be null if
            is also null.
        
        :type value: System.Object
        
        
        :param isChecked: If true, radio button is initially selected. Must not be null if
            is also null.
        
        :type isChecked: System.Boolean
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent RadioButton(IHtmlHelper htmlHelper, string expression, object value, bool isChecked)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperInputExtensions.RadioButton(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.Object, System.Object)
    
        
    
        Returns an &lt;input&gt; element of type "radio" for the specified ``expression``.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        
        
        :param value: If non-null, value to include in the element. Must not be null if no "checked" entry exists
            in .
        
        :type value: System.Object
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the element. Alternatively, an
            instance containing the HTML
            attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent RadioButton(IHtmlHelper htmlHelper, string expression, object value, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperInputExtensions.RadioButtonFor<TModel, TResult>(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.Object)
    
        
    
        Returns an &lt;input&gt; element of type "radio" for the specified ``expression``.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper{{TModel}}
        
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        
        
        :param value: Value to include in the element. Must not be null.
        
        :type value: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent RadioButtonFor<TModel, TResult>(IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression, object value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperInputExtensions.TextArea(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String)
    
        
    
        Returns a &lt;textarea&gt; element for the specified ``expression``.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;textarea&gt; element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent TextArea(IHtmlHelper htmlHelper, string expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperInputExtensions.TextArea(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.Object)
    
        
    
        Returns a &lt;textarea&gt; element for the specified ``expression``.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the element. Alternatively, an
            instance containing the HTML
            attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;textarea&gt; element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent TextArea(IHtmlHelper htmlHelper, string expression, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperInputExtensions.TextArea(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.String)
    
        
    
        Returns a &lt;textarea&gt; element for the specified ``expression``.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        
        
        :param value: If non-null, value to include in the element.
        
        :type value: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;textarea&gt; element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent TextArea(IHtmlHelper htmlHelper, string expression, string value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperInputExtensions.TextArea(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.String, System.Object)
    
        
    
        Returns a &lt;textarea&gt; element for the specified ``expression``.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        
        
        :param value: If non-null, value to include in the element.
        
        :type value: System.String
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the element. Alternatively, an
            instance containing the HTML
            attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;textarea&gt; element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent TextArea(IHtmlHelper htmlHelper, string expression, string value, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperInputExtensions.TextAreaFor<TModel, TResult>(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, TResult>>)
    
        
    
        Returns a &lt;textarea&gt; element for the specified ``expression``.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper{{TModel}}
        
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;textarea&gt; element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent TextAreaFor<TModel, TResult>(IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperInputExtensions.TextAreaFor<TModel, TResult>(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.Object)
    
        
    
        Returns a &lt;textarea&gt; element for the specified ``expression``.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper{{TModel}}
        
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the element. Alternatively, an
            instance containing the HTML
            attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;textarea&gt; element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent TextAreaFor<TModel, TResult>(IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperInputExtensions.TextBox(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String)
    
        
    
        Returns an &lt;input&gt; element of type "text" for the specified ``expression``.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent TextBox(IHtmlHelper htmlHelper, string expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperInputExtensions.TextBox(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.Object)
    
        
    
        Returns an &lt;input&gt; element of type "text" for the specified ``expression``.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        
        
        :param value: If non-null, value to include in the element.
        
        :type value: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent TextBox(IHtmlHelper htmlHelper, string expression, object value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperInputExtensions.TextBox(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.Object, System.Object)
    
        
    
        Returns an &lt;input&gt; element of type "text" for the specified ``expression``.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        
        
        :param value: If non-null, value to include in the element.
        
        :type value: System.Object
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the element. Alternatively, an
            instance containing the HTML
            attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent TextBox(IHtmlHelper htmlHelper, string expression, object value, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperInputExtensions.TextBox(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.Object, System.String)
    
        
    
        Returns an &lt;input&gt; element of type "text" for the specified ``expression``.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        
        
        :param value: If non-null, value to include in the element.
        
        :type value: System.Object
        
        
        :param format: The composite format  (see http://msdn.microsoft.com/en-us/library/txafckwd.aspx).
        
        :type format: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent TextBox(IHtmlHelper htmlHelper, string expression, object value, string format)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperInputExtensions.TextBoxFor<TModel, TResult>(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, TResult>>)
    
        
    
        Returns an &lt;input&gt; element of type "text" for the specified ``expression``.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper{{TModel}}
        
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent TextBoxFor<TModel, TResult>(IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperInputExtensions.TextBoxFor<TModel, TResult>(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.Object)
    
        
    
        Returns an &lt;input&gt; element of type "text" for the specified ``expression``.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper{{TModel}}
        
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the element. Alternatively, an
            instance containing the HTML
            attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent TextBoxFor<TModel, TResult>(IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperInputExtensions.TextBoxFor<TModel, TResult>(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.String)
    
        
    
        Returns an &lt;input&gt; element of type "text" for the specified ``expression``.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper{{TModel}}
        
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        
        
        :param format: The composite format  (see http://msdn.microsoft.com/en-us/library/txafckwd.aspx).
        
        :type format: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; element.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent TextBoxFor<TModel, TResult>(IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression, string format)
    

