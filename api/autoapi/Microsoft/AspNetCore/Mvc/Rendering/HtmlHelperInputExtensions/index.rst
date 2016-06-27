

HtmlHelperInputExtensions Class
===============================






Input-related extensions for :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` and :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper\`1`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperInputExtensions`








Syntax
------

.. code-block:: csharp

    public class HtmlHelperInputExtensions








.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperInputExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperInputExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperInputExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperInputExtensions.CheckBox(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String)
    
        
    
        
        Returns an <input> element of type "checkbox" with value "true" and an <input> element of type
        "hidden" with value "false".
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <input> elements.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent CheckBox(this IHtmlHelper htmlHelper, string expression)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperInputExtensions.CheckBox(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.Boolean)
    
        
    
        
        Returns an <input> element of type "checkbox" with value "true" and an <input> element of type
        "hidden" with value "false".
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
    
        
        :param isChecked: If <code>true</code>, checkbox is initially checked.
        
        :type isChecked: System.Boolean
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <input> elements.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent CheckBox(this IHtmlHelper htmlHelper, string expression, bool isChecked)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperInputExtensions.CheckBox(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.Object)
    
        
    
        
        Returns an <input> element of type "checkbox" with value "true" and an <input> element of type
        "hidden" with value "false".
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
    
        
        :param htmlAttributes: 
            An :any:`System.Object` that contains the HTML attributes for the checkbox element. Alternatively, an 
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the HTML
            attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <input> elements.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent CheckBox(this IHtmlHelper htmlHelper, string expression, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperInputExtensions.CheckBoxFor<TModel>(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, System.Boolean>>)
    
        
    
        
        Returns an <input> element of type "checkbox" with value "true" and an <input> element of type
        "hidden" with value "false".
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper\`1` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper`1>{TModel}
    
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, System.Boolean<System.Boolean>}}
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <input> elements.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent CheckBoxFor<TModel>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> expression)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperInputExtensions.Hidden(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String)
    
        
    
        
        Returns an <input> element of type "hidden" for the specified <em>expression</em>.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <input> element.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent Hidden(this IHtmlHelper htmlHelper, string expression)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperInputExtensions.Hidden(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.Object)
    
        
    
        
        Returns an <input> element of type "hidden" for the specified <em>expression</em>.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
    
        
        :param value: If non-<code>null</code>, value to include in the element.
        
        :type value: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <input> element.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent Hidden(this IHtmlHelper htmlHelper, string expression, object value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperInputExtensions.HiddenFor<TModel, TResult>(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, TResult>>)
    
        
    
        
        Returns an <input> element of type "hidden" for the specified <em>expression</em>.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper\`1` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper`1>{TModel}
    
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <input> element.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent HiddenFor<TModel, TResult>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperInputExtensions.Password(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String)
    
        
    
        
        Returns an <input> element of type "password" for the specified <em>expression</em>.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <input> element.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent Password(this IHtmlHelper htmlHelper, string expression)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperInputExtensions.Password(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.Object)
    
        
    
        
        Returns an <input> element of type "password" for the specified <em>expression</em>.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
    
        
        :param value: If non-<code>null</code>, value to include in the element.
        
        :type value: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <input> element.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent Password(this IHtmlHelper htmlHelper, string expression, object value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperInputExtensions.PasswordFor<TModel, TResult>(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, TResult>>)
    
        
    
        
        Returns an <input> element of type "password" for the specified <em>expression</em>.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper\`1` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper`1>{TModel}
    
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <input> element.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent PasswordFor<TModel, TResult>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperInputExtensions.RadioButton(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.Object)
    
        
    
        
        Returns an <input> element of type "radio" for the specified <em>expression</em>.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
    
        
        :param value: Value to include in the element. Must not be <code>null</code>.
        
        :type value: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <input> element.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent RadioButton(this IHtmlHelper htmlHelper, string expression, object value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperInputExtensions.RadioButton(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.Object, System.Boolean)
    
        
    
        
        Returns an <input> element of type "radio" for the specified <em>expression</em>.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
    
        
        :param value: 
            If non-<code>null</code>, value to include in the element. Must not be <code>null</code> if
            <em>isChecked</em> is also <code>null</code>.
        
        :type value: System.Object
    
        
        :param isChecked: 
            If <code>true</code>, radio button is initially selected. Must not be <code>null</code> if
            <em>value</em> is also <code>null</code>.
        
        :type isChecked: System.Boolean
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <input> element.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent RadioButton(this IHtmlHelper htmlHelper, string expression, object value, bool isChecked)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperInputExtensions.RadioButton(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.Object, System.Object)
    
        
    
        
        Returns an <input> element of type "radio" for the specified <em>expression</em>.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
    
        
        :param value: 
            If non-<code>null</code>, value to include in the element. Must not be <code>null</code> if no "checked" entry exists
            in <em>htmlAttributes</em>.
        
        :type value: System.Object
    
        
        :param htmlAttributes: 
            An :any:`System.Object` that contains the HTML attributes for the element. Alternatively, an 
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the HTML
            attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <input> element.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent RadioButton(this IHtmlHelper htmlHelper, string expression, object value, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperInputExtensions.RadioButtonFor<TModel, TResult>(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.Object)
    
        
    
        
        Returns an <input> element of type "radio" for the specified <em>expression</em>.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper\`1` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper`1>{TModel}
    
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
    
        
        :param value: Value to include in the element. Must not be <code>null</code>.
        
        :type value: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <input> element.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent RadioButtonFor<TModel, TResult>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression, object value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperInputExtensions.TextArea(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String)
    
        
    
        
        Returns a <textarea> element for the specified <em>expression</em>.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <textarea> element.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent TextArea(this IHtmlHelper htmlHelper, string expression)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperInputExtensions.TextArea(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.Object)
    
        
    
        
        Returns a <textarea> element for the specified <em>expression</em>.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
    
        
        :param htmlAttributes: 
            An :any:`System.Object` that contains the HTML attributes for the element. Alternatively, an 
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the HTML
            attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <textarea> element.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent TextArea(this IHtmlHelper htmlHelper, string expression, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperInputExtensions.TextArea(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.String)
    
        
    
        
        Returns a <textarea> element for the specified <em>expression</em>.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
    
        
        :param value: If non-<code>null</code>, value to include in the element.
        
        :type value: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <textarea> element.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent TextArea(this IHtmlHelper htmlHelper, string expression, string value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperInputExtensions.TextArea(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.String, System.Object)
    
        
    
        
        Returns a <textarea> element for the specified <em>expression</em>.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
    
        
        :param value: If non-<code>null</code>, value to include in the element.
        
        :type value: System.String
    
        
        :param htmlAttributes: 
            An :any:`System.Object` that contains the HTML attributes for the element. Alternatively, an 
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the HTML
            attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <textarea> element.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent TextArea(this IHtmlHelper htmlHelper, string expression, string value, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperInputExtensions.TextAreaFor<TModel, TResult>(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, TResult>>)
    
        
    
        
        Returns a <textarea> element for the specified <em>expression</em>.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper\`1` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper`1>{TModel}
    
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <textarea> element.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent TextAreaFor<TModel, TResult>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperInputExtensions.TextAreaFor<TModel, TResult>(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.Object)
    
        
    
        
        Returns a <textarea> element for the specified <em>expression</em>.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper\`1` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper`1>{TModel}
    
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
    
        
        :param htmlAttributes: 
            An :any:`System.Object` that contains the HTML attributes for the element. Alternatively, an 
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the HTML
            attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <textarea> element.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent TextAreaFor<TModel, TResult>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperInputExtensions.TextBox(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String)
    
        
    
        
        Returns an <input> element of type "text" for the specified <em>expression</em>.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <input> element.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent TextBox(this IHtmlHelper htmlHelper, string expression)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperInputExtensions.TextBox(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.Object)
    
        
    
        
        Returns an <input> element of type "text" for the specified <em>expression</em>.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
    
        
        :param value: If non-<code>null</code>, value to include in the element.
        
        :type value: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <input> element.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent TextBox(this IHtmlHelper htmlHelper, string expression, object value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperInputExtensions.TextBox(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.Object, System.Object)
    
        
    
        
        Returns an <input> element of type "text" for the specified <em>expression</em>.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
    
        
        :param value: If non-<code>null</code>, value to include in the element.
        
        :type value: System.Object
    
        
        :param htmlAttributes: 
            An :any:`System.Object` that contains the HTML attributes for the element. Alternatively, an 
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the HTML
            attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <input> element.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent TextBox(this IHtmlHelper htmlHelper, string expression, object value, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperInputExtensions.TextBox(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.Object, System.String)
    
        
    
        
        Returns an <input> element of type "text" for the specified <em>expression</em>.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
    
        
        :param value: If non-<code>null</code>, value to include in the element.
        
        :type value: System.Object
    
        
        :param format: 
            The composite format :any:`System.String` (see http://msdn.microsoft.com/en-us/library/txafckwd.aspx).
        
        :type format: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <input> element.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent TextBox(this IHtmlHelper htmlHelper, string expression, object value, string format)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperInputExtensions.TextBoxFor<TModel, TResult>(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, TResult>>)
    
        
    
        
        Returns an <input> element of type "text" for the specified <em>expression</em>.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper\`1` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper`1>{TModel}
    
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <input> element.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent TextBoxFor<TModel, TResult>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperInputExtensions.TextBoxFor<TModel, TResult>(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.Object)
    
        
    
        
        Returns an <input> element of type "text" for the specified <em>expression</em>.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper\`1` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper`1>{TModel}
    
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
    
        
        :param htmlAttributes: 
            An :any:`System.Object` that contains the HTML attributes for the element. Alternatively, an 
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the HTML
            attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <input> element.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent TextBoxFor<TModel, TResult>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperInputExtensions.TextBoxFor<TModel, TResult>(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.String)
    
        
    
        
        Returns an <input> element of type "text" for the specified <em>expression</em>.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper\`1` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper`1>{TModel}
    
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
    
        
        :param format: 
            The composite format :any:`System.String` (see http://msdn.microsoft.com/en-us/library/txafckwd.aspx).
        
        :type format: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <input> element.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent TextBoxFor<TModel, TResult>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression, string format)
    

