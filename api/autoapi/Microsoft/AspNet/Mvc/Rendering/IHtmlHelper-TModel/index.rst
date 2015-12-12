

IHtmlHelper<TModel> Interface
=============================



.. contents:: 
   :local:



Summary
-------

An :any:`Microsoft.AspNet.Mvc.Rendering.IHtmlHelper` for Linq expressions.











Syntax
------

.. code-block:: csharp

   public interface IHtmlHelper<TModel> : IHtmlHelper





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ViewFeatures/Rendering/IHtmlHelperOfT.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>.CheckBoxFor(System.Linq.Expressions.Expression<System.Func<TModel, System.Boolean>>, System.Object)
    
        
    
        Returns an &lt;input&gt; element of type "checkbox" with value "true" and an &lt;input&gt; element of type
        "hidden" with value "false".
    
        
        
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},System.Boolean}}
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the checkbox element. Alternatively, an
            instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; elements.
    
        
        .. code-block:: csharp
    
           IHtmlContent CheckBoxFor(Expression<Func<TModel, bool>> expression, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>.DisplayFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.String, System.String, System.Object)
    
        
    
        Returns HTML markup for the ``expression``, using a display template, specified HTML field
        name, and additional view data. The template is found using the ``templateName`` or the
        ``expression``'s :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata`\.
    
        
        
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        
        
        :param templateName: The name of the template used to create the HTML markup.
        
        :type templateName: System.String
        
        
        :param htmlFieldName: A  used to disambiguate the names of HTML elements that are created for properties
            that have the same name.
        
        :type htmlFieldName: System.String
        
        
        :param additionalViewData: An anonymous  or  that can contain additional
            view data that will be merged into the  instance created for the
            template.
        
        :type additionalViewData: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the created HTML.
    
        
        .. code-block:: csharp
    
           IHtmlContent DisplayFor<TResult>(Expression<Func<TModel, TResult>> expression, string templateName, string htmlFieldName, object additionalViewData)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>.DisplayNameForInnerType<TModelItem, TResult>(System.Linq.Expressions.Expression<System.Func<TModelItem, TResult>>)
    
        
    
        Returns the display name for the specified ``expression``
        if the current model represents a collection.
    
        
        
        
        :param expression: An expression to be evaluated against an item in the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModelItem},{TResult}}}
        :rtype: System.String
        :return: A <see cref="T:System.String" /> containing the display name.
    
        
        .. code-block:: csharp
    
           string DisplayNameForInnerType<TModelItem, TResult>(Expression<Func<TModelItem, TResult>> expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>.DisplayNameFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>)
    
        
    
        Returns the display name for the specified ``expression``.
    
        
        
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        :rtype: System.String
        :return: A <see cref="T:System.String" /> containing the display name.
    
        
        .. code-block:: csharp
    
           string DisplayNameFor<TResult>(Expression<Func<TModel, TResult>> expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>.DisplayTextFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>)
    
        
    
        Returns the simple display text for the specified ``expression``.
    
        
        
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        :rtype: System.String
        :return: A <see cref="T:System.String" /> containing the simple display text.
            If the <paramref name="expression" /> result is <c>null</c>, returns
            <see cref="P:Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.NullDisplayText" />.
    
        
        .. code-block:: csharp
    
           string DisplayTextFor<TResult>(Expression<Func<TModel, TResult>> expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>.DropDownListFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.Rendering.SelectListItem>, System.String, System.Object)
    
        
    
        Returns a single-selection HTML &lt;select&gt; element for the ``expression``, using the
        specified list items, option label, and HTML attributes.
    
        
        
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        
        
        :param selectList: A collection of  objects used to populate the <select> element with
            <optgroup> and <option> elements.
        
        :type selectList: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.Rendering.SelectListItem}
        
        
        :param optionLabel: The text for a default empty item. Does not include such an item if argument is null.
        
        :type optionLabel: System.String
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the <select> element. Alternatively, an
            instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;select&gt; element.
    
        
        .. code-block:: csharp
    
           IHtmlContent DropDownListFor<TResult>(Expression<Func<TModel, TResult>> expression, IEnumerable<SelectListItem> selectList, string optionLabel, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>.EditorFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.String, System.String, System.Object)
    
        
    
        Returns HTML markup for the ``expression``, using an editor template, specified HTML field
        name, and additional view data. The template is found using the ``templateName`` or the
        ``expression``'s :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata`\.
    
        
        
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        
        
        :param templateName: The name of the template that is used to create the HTML markup.
        
        :type templateName: System.String
        
        
        :param htmlFieldName: A  used to disambiguate the names of HTML elements that are created for properties
            that have the same name.
        
        :type htmlFieldName: System.String
        
        
        :param additionalViewData: An anonymous  or  that can contain additional
            view data that will be merged into the  instance created for the
            template.
        
        :type additionalViewData: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; element(s).
    
        
        .. code-block:: csharp
    
           IHtmlContent EditorFor<TResult>(Expression<Func<TModel, TResult>> expression, string templateName, string htmlFieldName, object additionalViewData)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>.Encode(System.Object)
    
        
        
        
        :type value: System.Object
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string Encode(object value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>.Encode(System.String)
    
        
        
        
        :type value: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string Encode(string value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>.HiddenFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.Object)
    
        
    
        Returns an &lt;input&gt; element of type "hidden" for the specified ``expression``.
    
        
        
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the element. Alternatively, an
            instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; element.
    
        
        .. code-block:: csharp
    
           IHtmlContent HiddenFor<TResult>(Expression<Func<TModel, TResult>> expression, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>.IdFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>)
    
        
    
        Returns the HTML element Id for the specified ``expression``.
    
        
        
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        :rtype: System.String
        :return: A <see cref="T:System.String" /> containing the element Id.
    
        
        .. code-block:: csharp
    
           string IdFor<TResult>(Expression<Func<TModel, TResult>> expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>.LabelFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.String, System.Object)
    
        
    
        Returns a &lt;label&gt; element for the specified ``expression``.
    
        
        
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        
        
        :param labelText: The inner text of the element.
        
        :type labelText: System.String
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the element. Alternatively, an
            instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;label&gt; element.
    
        
        .. code-block:: csharp
    
           IHtmlContent LabelFor<TResult>(Expression<Func<TModel, TResult>> expression, string labelText, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>.ListBoxFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.Rendering.SelectListItem>, System.Object)
    
        
    
        Returns a multi-selection &lt;select&gt; element for the ``expression``, using the
        specified list items and HTML attributes.
    
        
        
        
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
    
           IHtmlContent ListBoxFor<TResult>(Expression<Func<TModel, TResult>> expression, IEnumerable<SelectListItem> selectList, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>.NameFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>)
    
        
    
        Returns the full HTML element name for the specified ``expression``.
    
        
        
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        :rtype: System.String
        :return: A <see cref="T:System.String" /> containing the element name.
    
        
        .. code-block:: csharp
    
           string NameFor<TResult>(Expression<Func<TModel, TResult>> expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>.PasswordFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.Object)
    
        
    
        Returns an &lt;input&gt; element of type "password" for the specified ``expression``.
    
        
        
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the element. Alternatively, an
            instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; element.
    
        
        .. code-block:: csharp
    
           IHtmlContent PasswordFor<TResult>(Expression<Func<TModel, TResult>> expression, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>.RadioButtonFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.Object, System.Object)
    
        
    
        Returns an &lt;input&gt; element of type "radio" for the specified ``expression``.
    
        
        
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        
        
        :param value: Value to include in the element. Must not be null.
        
        :type value: System.Object
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the element. Alternatively, an
            instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; element.
    
        
        .. code-block:: csharp
    
           IHtmlContent RadioButtonFor<TResult>(Expression<Func<TModel, TResult>> expression, object value, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>.Raw(System.Object)
    
        
        
        
        :type value: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           IHtmlContent Raw(object value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>.Raw(System.String)
    
        
        
        
        :type value: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           IHtmlContent Raw(string value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>.TextAreaFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.Int32, System.Int32, System.Object)
    
        
    
        Returns a &lt;textarea&gt; element for the specified ``expression``.
    
        
        
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        
        
        :param rows: Number of rows in the textarea.
        
        :type rows: System.Int32
        
        
        :param columns: Number of columns in the textarea.
        
        :type columns: System.Int32
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the element. Alternatively, an
            instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;textarea&gt; element.
    
        
        .. code-block:: csharp
    
           IHtmlContent TextAreaFor<TResult>(Expression<Func<TModel, TResult>> expression, int rows, int columns, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>.TextBoxFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.String, System.Object)
    
        
    
        Returns an &lt;input&gt; element of type "text" for the specified ``expression``.
    
        
        
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        
        
        :param format: The composite format  (see http://msdn.microsoft.com/en-us/library/txafckwd.aspx).
        
        :type format: System.String
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the element. Alternatively, an
            instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; element.
    
        
        .. code-block:: csharp
    
           IHtmlContent TextBoxFor<TResult>(Expression<Func<TModel, TResult>> expression, string format, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>.ValidationMessageFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.String, System.Object, System.String)
    
        
    
        Returns the validation message if an error exists in the :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary`
        object for the specified ``expression``.
    
        
        
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        
        
        :param message: The message to be displayed. If null or empty, method extracts an error string from the
            object. Message will always be visible but client-side
            validation may update the associated CSS class.
        
        :type message: System.String
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the  element.
            Alternatively, an  instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        
        
        :param tag: The tag to wrap the  in the generated HTML. Its default value is
            .
        
        :type tag: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the <paramref name="tag" /> element. <c>null</c> if the
            <paramref name="expression" /> is valid and client-side validation is disabled.
    
        
        .. code-block:: csharp
    
           IHtmlContent ValidationMessageFor<TResult>(Expression<Func<TModel, TResult>> expression, string message, object htmlAttributes, string tag)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>.ValueFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.String)
    
        
    
        Returns the formatted value for the specified ``expression``.
    
        
        
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        
        
        :param format: The composite format  (see http://msdn.microsoft.com/en-us/library/txafckwd.aspx).
        
        :type format: System.String
        :rtype: System.String
        :return: A <see cref="T:System.String" /> containing the formatted value.
    
        
        .. code-block:: csharp
    
           string ValueFor<TResult>(Expression<Func<TModel, TResult>> expression, string format)
    

Properties
----------

.. dn:interface:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>.ViewData
    
        
    
        Gets the current view data.
    
        
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary{{TModel}}
    
        
        .. code-block:: csharp
    
           ViewDataDictionary<TModel> ViewData { get; }
    

