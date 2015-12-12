

HtmlHelperValidationExtensions Class
====================================



.. contents:: 
   :local:



Summary
-------

Validation-related extensions for :any:`Microsoft.AspNet.Mvc.Rendering.IHtmlHelper` and :any:`Microsoft.AspNet.Mvc.Rendering.IHtmlHelper\`1`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Rendering.HtmlHelperValidationExtensions`








Syntax
------

.. code-block:: csharp

   public class HtmlHelperValidationExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/Rendering/HtmlHelperValidationExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperValidationExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperValidationExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperValidationExtensions.ValidationMessage(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String)
    
        
    
        Returns the validation message if an error exists in the :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary`
        object for the specified ``expression``.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing a <see cref="P:Microsoft.AspNet.Mvc.Rendering.ViewContext.ValidationMessageElement" /> element.
            <c>null</c> if the <paramref name="expression" /> is valid and client-side validation is disabled.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent ValidationMessage(IHtmlHelper htmlHelper, string expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperValidationExtensions.ValidationMessage(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.Object)
    
        
    
        Returns the validation message if an error exists in the :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary`
        object for the specified ``expression``.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the
            () element. Alternatively, an
            instance containing the HTML
            attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing a <see cref="P:Microsoft.AspNet.Mvc.Rendering.ViewContext.ValidationMessageElement" /> element.
            <c>null</c> if the <paramref name="expression" /> is valid and client-side validation is disabled.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent ValidationMessage(IHtmlHelper htmlHelper, string expression, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperValidationExtensions.ValidationMessage(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.String)
    
        
    
        Returns the validation message if an error exists in the :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary`
        object for the specified ``expression``.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        
        
        :param message: The message to be displayed. If null or empty, method extracts an error string from the
            object. Message will always be visible but client-side
            validation may update the associated CSS class.
        
        :type message: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing a <see cref="P:Microsoft.AspNet.Mvc.Rendering.ViewContext.ValidationMessageElement" /> element.
            <c>null</c> if the <paramref name="expression" /> is valid and client-side validation is disabled.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent ValidationMessage(IHtmlHelper htmlHelper, string expression, string message)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperValidationExtensions.ValidationMessage(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.String, System.Object)
    
        
    
        Returns the validation message if an error exists in the :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary`
        object for the specified ``expression``.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        
        
        :param message: The message to be displayed. If null or empty, method extracts an error string from the
            object. Message will always be visible but client-side
            validation may update the associated CSS class.
        
        :type message: System.String
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the
            () element. Alternatively, an
            instance containing the HTML
            attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing a <see cref="P:Microsoft.AspNet.Mvc.Rendering.ViewContext.ValidationMessageElement" /> element.
            <c>null</c> if the <paramref name="expression" /> is valid and client-side validation is disabled.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent ValidationMessage(IHtmlHelper htmlHelper, string expression, string message, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperValidationExtensions.ValidationMessage(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.String, System.String)
    
        
    
        Returns the validation message if an error exists in the :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary`
        object for the specified ``expression``.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        
        
        :param message: The message to be displayed. If null or empty, method extracts an error string from the
            object. Message will always be visible but client-side
            validation may update the associated CSS class.
        
        :type message: System.String
        
        
        :param tag: The tag to wrap the  in the generated HTML. Its default value is
            .
        
        :type tag: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing a <paramref name="tag" /> element. <c>null</c> if the
            <paramref name="expression" /> is valid and client-side validation is disabled.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent ValidationMessage(IHtmlHelper htmlHelper, string expression, string message, string tag)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperValidationExtensions.ValidationMessageFor<TModel, TResult>(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, TResult>>)
    
        
    
        Returns the validation message if an error exists in the :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary`
        object for the specified ``expression``.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper{{TModel}}
        
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing a <see cref="P:Microsoft.AspNet.Mvc.Rendering.ViewContext.ValidationMessageElement" /> element.
            <c>null</c> if the <paramref name="expression" /> is valid and client-side validation is disabled.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent ValidationMessageFor<TModel, TResult>(IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperValidationExtensions.ValidationMessageFor<TModel, TResult>(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.String)
    
        
    
        Returns the validation message if an error exists in the :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary`
        object for the specified ``expression``.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper{{TModel}}
        
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        
        
        :param message: The message to be displayed. If null or empty, method extracts an error string from the
            object. Message will always be visible but client-side
            validation may update the associated CSS class.
        
        :type message: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing a <see cref="P:Microsoft.AspNet.Mvc.Rendering.ViewContext.ValidationMessageElement" /> element.
            <c>null</c> if the <paramref name="expression" /> is valid and client-side validation is disabled.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent ValidationMessageFor<TModel, TResult>(IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression, string message)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperValidationExtensions.ValidationMessageFor<TModel, TResult>(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.String, System.Object)
    
        
    
        Returns the validation message if an error exists in the :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary`
        object for the specified ``expression``.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper{{TModel}}
        
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        
        
        :param message: The message to be displayed. If null or empty, method extracts an error string from the
            object. Message will always be visible but client-side
            validation may update the associated CSS class.
        
        :type message: System.String
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the
            () element. Alternatively, an
            instance containing the HTML
            attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing a <see cref="P:Microsoft.AspNet.Mvc.Rendering.ViewContext.ValidationMessageElement" /> element.
            <c>null</c> if the <paramref name="expression" /> is valid and client-side validation is disabled.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent ValidationMessageFor<TModel, TResult>(IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression, string message, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperValidationExtensions.ValidationMessageFor<TModel, TResult>(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.String, System.String)
    
        
    
        Returns the validation message if an error exists in the :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary`
        object for the specified ``expression``.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper{{TModel}}
        
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        
        
        :param message: The message to be displayed. If null or empty, method extracts an error string from the
            object. Message will always be visible but client-side
            validation may update the associated CSS class.
        
        :type message: System.String
        
        
        :param tag: The tag to wrap the  in the generated HTML. Its default value is
            .
        
        :type tag: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the <paramref name="tag" /> element. <c>null</c> if the
            <paramref name="expression" /> is valid and client-side validation is disabled.
    
        
        .. code-block:: csharp
    
           public static IHtmlContent ValidationMessageFor<TModel, TResult>(IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression, string message, string tag)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperValidationExtensions.ValidationSummary(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper)
    
        
    
        Returns an unordered list (&lt;ul&gt; element) of validation messages that are in the 
        :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary` object.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: New <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing a &lt;div&gt; element wrapping the &lt;ul&gt; element.
            <see cref="F:Microsoft.AspNet.Mvc.Rendering.HtmlString.Empty" /> if the current model is valid and client-side validation is disabled).
    
        
        .. code-block:: csharp
    
           public static IHtmlContent ValidationSummary(IHtmlHelper htmlHelper)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperValidationExtensions.ValidationSummary(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.Boolean)
    
        
    
        Returns an unordered list (&lt;ul&gt; element) of validation messages that are in the 
        :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary` object.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param excludePropertyErrors: If true, display model-level errors only; otherwise display all errors.
        
        :type excludePropertyErrors: System.Boolean
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: New <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing a &lt;div&gt; element wrapping the &lt;ul&gt; element.
            <see cref="F:Microsoft.AspNet.Mvc.Rendering.HtmlString.Empty" /> if the current model is valid and client-side validation is disabled).
    
        
        .. code-block:: csharp
    
           public static IHtmlContent ValidationSummary(IHtmlHelper htmlHelper, bool excludePropertyErrors)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperValidationExtensions.ValidationSummary(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.Boolean, System.String)
    
        
    
        Returns an unordered list (&lt;ul&gt; element) of validation messages that are in the 
        :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary` object.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param excludePropertyErrors: If true, display model-level errors only; otherwise display all errors.
        
        :type excludePropertyErrors: System.Boolean
        
        
        :param message: The message to display with the validation summary.
        
        :type message: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: New <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing a &lt;div&gt; element wrapping the
            <see cref="P:Microsoft.AspNet.Mvc.Rendering.ViewContext.ValidationSummaryMessageElement" /> element (which, in turn, wraps the
            <paramref name="message" />) and the &lt;ul&gt; element. <see cref="F:Microsoft.AspNet.Mvc.Rendering.HtmlString.Empty" /> if the current model
            is valid and client-side validation is disabled).
    
        
        .. code-block:: csharp
    
           public static IHtmlContent ValidationSummary(IHtmlHelper htmlHelper, bool excludePropertyErrors, string message)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperValidationExtensions.ValidationSummary(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.Boolean, System.String, System.Object)
    
        
    
        Returns an unordered list (&lt;ul&gt; element) of validation messages that are in the 
        :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary` object.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param excludePropertyErrors: If true, display model-level errors only; otherwise display all errors.
        
        :type excludePropertyErrors: System.Boolean
        
        
        :param message: The message to display with the validation summary.
        
        :type message: System.String
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the topmost (<div>) element.
            Alternatively, an  instance containing
            the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: New <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing a &lt;div&gt; element wrapping the
            <see cref="P:Microsoft.AspNet.Mvc.Rendering.ViewContext.ValidationSummaryMessageElement" /> element (which wraps the
            <paramref name="message" />) and the &lt;ul&gt; element. <see cref="F:Microsoft.AspNet.Mvc.Rendering.HtmlString.Empty" /> if the current model
            is valid and client-side validation is disabled).
    
        
        .. code-block:: csharp
    
           public static IHtmlContent ValidationSummary(IHtmlHelper htmlHelper, bool excludePropertyErrors, string message, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperValidationExtensions.ValidationSummary(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.Boolean, System.String, System.String)
    
        
    
        Returns an unordered list (&lt;ul&gt; element) of validation messages that are in the 
        :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary` object.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param excludePropertyErrors: If true, display model-level errors only; otherwise display all errors.
        
        :type excludePropertyErrors: System.Boolean
        
        
        :param message: The message to display with the validation summary.
        
        :type message: System.String
        
        
        :param tag: The tag to wrap the  in the generated HTML. Its default value is
            .
        
        :type tag: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: New <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing a &lt;div&gt; element wrapping the <paramref name="tag" /> element
            and the &lt;ul&gt; element. <see cref="F:Microsoft.AspNet.Mvc.Rendering.HtmlString.Empty" /> if the current model is valid and client-side
            validation is disabled).
    
        
        .. code-block:: csharp
    
           public static IHtmlContent ValidationSummary(IHtmlHelper htmlHelper, bool excludePropertyErrors, string message, string tag)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperValidationExtensions.ValidationSummary(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String)
    
        
    
        Returns an unordered list (&lt;ul&gt; element) of validation messages that are in the 
        :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary` object.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param message: The message to display with the validation summary.
        
        :type message: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: New <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing a &lt;div&gt; element wrapping the
            <see cref="P:Microsoft.AspNet.Mvc.Rendering.ViewContext.ValidationSummaryMessageElement" /> element (which wraps the
            <paramref name="message" />) and the &lt;ul&gt; element. <see cref="F:Microsoft.AspNet.Mvc.Rendering.HtmlString.Empty" /> if the current model
            is valid and client-side validation is disabled).
    
        
        .. code-block:: csharp
    
           public static IHtmlContent ValidationSummary(IHtmlHelper htmlHelper, string message)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperValidationExtensions.ValidationSummary(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.Object)
    
        
    
        Returns an unordered list (&lt;ul&gt; element) of validation messages that are in the 
        :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary` object.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param message: The message to display with the validation summary.
        
        :type message: System.String
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the topmost (<div>) element.
            Alternatively, an  instance containing
            the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: New <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing a &lt;div&gt; element wrapping the
            <see cref="P:Microsoft.AspNet.Mvc.Rendering.ViewContext.ValidationSummaryMessageElement" /> element (which wraps the
            <paramref name="message" />) and the &lt;ul&gt; element. <see cref="F:Microsoft.AspNet.Mvc.Rendering.HtmlString.Empty" /> if the current model
            is valid and client-side validation is disabled).
    
        
        .. code-block:: csharp
    
           public static IHtmlContent ValidationSummary(IHtmlHelper htmlHelper, string message, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperValidationExtensions.ValidationSummary(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.Object, System.String)
    
        
    
        Returns an unordered list (&lt;ul&gt; element) of validation messages that are in the 
        :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary` object.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param message: The message to display with the validation summary.
        
        :type message: System.String
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the topmost (<div>) element.
            Alternatively, an  instance containing
            the HTML attributes.
        
        :type htmlAttributes: System.Object
        
        
        :param tag: The tag to wrap the  in the generated HTML. Its default value is
            .
        
        :type tag: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: New <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing a &lt;div&gt; element wrapping the <paramref name="tag" /> element
            and the &lt;ul&gt; element. <see cref="F:Microsoft.AspNet.Mvc.Rendering.HtmlString.Empty" /> if the current model is valid and client-side
            validation is disabled).
    
        
        .. code-block:: csharp
    
           public static IHtmlContent ValidationSummary(IHtmlHelper htmlHelper, string message, object htmlAttributes, string tag)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperValidationExtensions.ValidationSummary(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.String)
    
        
    
        Returns an unordered list (&lt;ul&gt; element) of validation messages that are in the 
        :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary` object.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param message: The message to display with the validation summary.
        
        :type message: System.String
        
        
        :param tag: The tag to wrap the  in the generated HTML. Its default value is
            .
        
        :type tag: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: New <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing a &lt;div&gt; element wrapping the <paramref name="tag" /> element
            and the &lt;ul&gt; element. <see cref="F:Microsoft.AspNet.Mvc.Rendering.HtmlString.Empty" /> if the current model is valid and client-side
            validation is disabled).
    
        
        .. code-block:: csharp
    
           public static IHtmlContent ValidationSummary(IHtmlHelper htmlHelper, string message, string tag)
    

