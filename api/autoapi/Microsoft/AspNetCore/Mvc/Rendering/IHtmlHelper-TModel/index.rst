

IHtmlHelper<TModel> Interface
=============================






An :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` for Linq expressions.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Rendering`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IHtmlHelper<TModel> : IHtmlHelper








.. dn:interface:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper`1
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TModel>

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TModel>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TModel>.CheckBoxFor(System.Linq.Expressions.Expression<System.Func<TModel, System.Boolean>>, System.Object)
    
        
    
        
        Returns an <input> element of type "checkbox" with value "true" and an <input> element of type
        "hidden" with value "false".
    
        
    
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, System.Boolean<System.Boolean>}}
    
        
        :param htmlAttributes: 
            An :any:`System.Object` that contains the HTML attributes for the checkbox element. Alternatively, an 
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <input> elements.
    
        
        .. code-block:: csharp
    
            IHtmlContent CheckBoxFor(Expression<Func<TModel, bool>> expression, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TModel>.DisplayFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.String, System.String, System.Object)
    
        
    
        
        Returns HTML markup for the <em>expression</em>, using a display template, specified HTML field
        name, and additional view data. The template is found using the <em>templateName</em> or the
        <em>expression</em>'s :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`\.
    
        
    
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
    
        
        :param templateName: The name of the template used to create the HTML markup.
        
        :type templateName: System.String
    
        
        :param htmlFieldName: 
            A :any:`System.String` used to disambiguate the names of HTML elements that are created for properties
            that have the same name.
        
        :type htmlFieldName: System.String
    
        
        :param additionalViewData: 
            An anonymous :any:`System.Object` or :any:`System.Collections.Generic.IDictionary\`2` that can contain additional
            view data that will be merged into the :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary\`1` instance created for the
            template.
        
        :type additionalViewData: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the created HTML.
    
        
        .. code-block:: csharp
    
            IHtmlContent DisplayFor<TResult>(Expression<Func<TModel, TResult>> expression, string templateName, string htmlFieldName, object additionalViewData)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TModel>.DisplayNameForInnerType<TModelItem, TResult>(System.Linq.Expressions.Expression<System.Func<TModelItem, TResult>>)
    
        
    
        
        Returns the display name for the specified <em>expression</em>
        if the current model represents a collection.
    
        
    
        
        :param expression: An expression to be evaluated against an item in the current model.
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModelItem, TResult}}
        :rtype: System.String
        :return: A :any:`System.String` containing the display name.
    
        
        .. code-block:: csharp
    
            string DisplayNameForInnerType<TModelItem, TResult>(Expression<Func<TModelItem, TResult>> expression)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TModel>.DisplayNameFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>)
    
        
    
        
        Returns the display name for the specified <em>expression</em>.
    
        
    
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
        :rtype: System.String
        :return: A :any:`System.String` containing the display name.
    
        
        .. code-block:: csharp
    
            string DisplayNameFor<TResult>(Expression<Func<TModel, TResult>> expression)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TModel>.DisplayTextFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>)
    
        
    
        
        Returns the simple display text for the specified <em>expression</em>.
    
        
    
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
        :rtype: System.String
        :return: 
            A :any:`System.String` containing the simple display text.
            If the <em>expression</em> result is <code>null</code>, returns 
            :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.NullDisplayText`\.
    
        
        .. code-block:: csharp
    
            string DisplayTextFor<TResult>(Expression<Func<TModel, TResult>> expression)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TModel>.DropDownListFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>, System.String, System.Object)
    
        
    
        
        Returns a single-selection HTML <select> element for the <em>expression</em>, using the
        specified list items, option label, and HTML attributes.
    
        
    
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
    
        
        :param selectList: 
            A collection of :any:`Microsoft.AspNetCore.Mvc.Rendering.SelectListItem` objects used to populate the <select> element with
            <optgroup> and <option> elements.
        
        :type selectList: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.Rendering.SelectListItem<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>}
    
        
        :param optionLabel: 
            The text for a default empty item. Does not include such an item if argument is <code>null</code>.
        
        :type optionLabel: System.String
    
        
        :param htmlAttributes: 
            An :any:`System.Object` that contains the HTML attributes for the <select> element. Alternatively, an 
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <select> element.
    
        
        .. code-block:: csharp
    
            IHtmlContent DropDownListFor<TResult>(Expression<Func<TModel, TResult>> expression, IEnumerable<SelectListItem> selectList, string optionLabel, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TModel>.EditorFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.String, System.String, System.Object)
    
        
    
        
        Returns HTML markup for the <em>expression</em>, using an editor template, specified HTML field
        name, and additional view data. The template is found using the <em>templateName</em> or the
        <em>expression</em>'s :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`\.
    
        
    
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
    
        
        :param templateName: The name of the template that is used to create the HTML markup.
        
        :type templateName: System.String
    
        
        :param htmlFieldName: 
            A :any:`System.String` used to disambiguate the names of HTML elements that are created for properties
            that have the same name.
        
        :type htmlFieldName: System.String
    
        
        :param additionalViewData: 
            An anonymous :any:`System.Object` or :any:`System.Collections.Generic.IDictionary\`2` that can contain additional
            view data that will be merged into the :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary\`1` instance created for the
            template.
        
        :type additionalViewData: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <input> element(s).
    
        
        .. code-block:: csharp
    
            IHtmlContent EditorFor<TResult>(Expression<Func<TModel, TResult>> expression, string templateName, string htmlFieldName, object additionalViewData)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TModel>.Encode(System.Object)
    
        
    
        
        :type value: System.Object
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string Encode(object value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TModel>.Encode(System.String)
    
        
    
        
        :type value: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string Encode(string value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TModel>.HiddenFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.Object)
    
        
    
        
        Returns an <input> element of type "hidden" for the specified <em>expression</em>.
    
        
    
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
    
        
        :param htmlAttributes: 
            An :any:`System.Object` that contains the HTML attributes for the element. Alternatively, an 
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <input> element.
    
        
        .. code-block:: csharp
    
            IHtmlContent HiddenFor<TResult>(Expression<Func<TModel, TResult>> expression, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TModel>.IdFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>)
    
        
    
        
        Returns the HTML element Id for the specified <em>expression</em>.
    
        
    
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
        :rtype: System.String
        :return: A :any:`System.String` containing the element Id.
    
        
        .. code-block:: csharp
    
            string IdFor<TResult>(Expression<Func<TModel, TResult>> expression)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TModel>.LabelFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.String, System.Object)
    
        
    
        
        Returns a <label> element for the specified <em>expression</em>.
    
        
    
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
    
        
        :param labelText: The inner text of the element.
        
        :type labelText: System.String
    
        
        :param htmlAttributes: 
            An :any:`System.Object` that contains the HTML attributes for the element. Alternatively, an 
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <label> element.
    
        
        .. code-block:: csharp
    
            IHtmlContent LabelFor<TResult>(Expression<Func<TModel, TResult>> expression, string labelText, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TModel>.ListBoxFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>, System.Object)
    
        
    
        
        Returns a multi-selection <select> element for the <em>expression</em>, using the
        specified list items and HTML attributes.
    
        
    
        
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
    
            IHtmlContent ListBoxFor<TResult>(Expression<Func<TModel, TResult>> expression, IEnumerable<SelectListItem> selectList, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TModel>.NameFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>)
    
        
    
        
        Returns the full HTML element name for the specified <em>expression</em>.
    
        
    
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
        :rtype: System.String
        :return: A :any:`System.String` containing the element name.
    
        
        .. code-block:: csharp
    
            string NameFor<TResult>(Expression<Func<TModel, TResult>> expression)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TModel>.PasswordFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.Object)
    
        
    
        
        Returns an <input> element of type "password" for the specified <em>expression</em>.
    
        
    
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
    
        
        :param htmlAttributes: 
            An :any:`System.Object` that contains the HTML attributes for the element. Alternatively, an 
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <input> element.
    
        
        .. code-block:: csharp
    
            IHtmlContent PasswordFor<TResult>(Expression<Func<TModel, TResult>> expression, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TModel>.RadioButtonFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.Object, System.Object)
    
        
    
        
        Returns an <input> element of type "radio" for the specified <em>expression</em>.
    
        
    
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
    
        
        :param value: Value to include in the element. Must not be <code>null</code>.
        
        :type value: System.Object
    
        
        :param htmlAttributes: 
            An :any:`System.Object` that contains the HTML attributes for the element. Alternatively, an 
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <input> element.
    
        
        .. code-block:: csharp
    
            IHtmlContent RadioButtonFor<TResult>(Expression<Func<TModel, TResult>> expression, object value, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TModel>.Raw(System.Object)
    
        
    
        
        :type value: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
    
        
        .. code-block:: csharp
    
            IHtmlContent Raw(object value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TModel>.Raw(System.String)
    
        
    
        
        :type value: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
    
        
        .. code-block:: csharp
    
            IHtmlContent Raw(string value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TModel>.TextAreaFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.Int32, System.Int32, System.Object)
    
        
    
        
        Returns a <textarea> element for the specified <em>expression</em>.
    
        
    
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
    
        
        :param rows: Number of rows in the textarea.
        
        :type rows: System.Int32
    
        
        :param columns: Number of columns in the textarea.
        
        :type columns: System.Int32
    
        
        :param htmlAttributes: 
            An :any:`System.Object` that contains the HTML attributes for the element. Alternatively, an 
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <textarea> element.
    
        
        .. code-block:: csharp
    
            IHtmlContent TextAreaFor<TResult>(Expression<Func<TModel, TResult>> expression, int rows, int columns, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TModel>.TextBoxFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.String, System.Object)
    
        
    
        
        Returns an <input> element of type "text" for the specified <em>expression</em>.
    
        
    
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
    
        
        :param format: 
            The composite format :any:`System.String` (see http://msdn.microsoft.com/en-us/library/txafckwd.aspx).
        
        :type format: System.String
    
        
        :param htmlAttributes: 
            An :any:`System.Object` that contains the HTML attributes for the element. Alternatively, an 
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <input> element.
    
        
        .. code-block:: csharp
    
            IHtmlContent TextBoxFor<TResult>(Expression<Func<TModel, TResult>> expression, string format, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TModel>.ValidationMessageFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.String, System.Object, System.String)
    
        
    
        
        Returns the validation message if an error exists in the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary`
        object for the specified <em>expression</em>.
    
        
    
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
    
        
        :param message: 
            The message to be displayed. If <code>null</code> or empty, method extracts an error string from the 
            :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary` object. Message will always be visible but client-side
            validation may update the associated CSS class.
        
        :type message: System.String
    
        
        :param htmlAttributes: 
            An :any:`System.Object` that contains the HTML attributes for the <em>tag</em> element.
            Alternatively, an :any:`System.Collections.Generic.IDictionary\`2` instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
    
        
        :param tag: 
            The tag to wrap the <em>message</em> in the generated HTML. Its default value is 
            :dn:prop:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext.ValidationMessageElement`\.
        
        :type tag: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: 
            A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <em>tag</em> element. <code>null</code> if the
            <em>expression</em> is valid and client-side validation is disabled.
    
        
        .. code-block:: csharp
    
            IHtmlContent ValidationMessageFor<TResult>(Expression<Func<TModel, TResult>> expression, string message, object htmlAttributes, string tag)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TModel>.ValueFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.String)
    
        
    
        
        Returns the formatted value for the specified <em>expression</em>.
    
        
    
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
    
        
        :param format: 
            The composite format :any:`System.String` (see http://msdn.microsoft.com/en-us/library/txafckwd.aspx).
        
        :type format: System.String
        :rtype: System.String
        :return: A :any:`System.String` containing the formatted value.
    
        
        .. code-block:: csharp
    
            string ValueFor<TResult>(Expression<Func<TModel, TResult>> expression, string format)
    

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TModel>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TModel>.ViewData
    
        
    
        
        Gets the current view data.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary`1>{TModel}
    
        
        .. code-block:: csharp
    
            ViewDataDictionary<TModel> ViewData { get; }
    

