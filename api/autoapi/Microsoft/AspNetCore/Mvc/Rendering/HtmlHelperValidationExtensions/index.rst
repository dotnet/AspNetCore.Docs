

HtmlHelperValidationExtensions Class
====================================






Validation-related extensions for :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` and :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper\`1`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperValidationExtensions`








Syntax
------

.. code-block:: csharp

    public class HtmlHelperValidationExtensions








.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperValidationExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperValidationExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperValidationExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperValidationExtensions.ValidationMessage(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String)
    
        
    
        
        Returns the validation message if an error exists in the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary`
        object for the specified <em>expression</em>.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: 
            A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing a :dn:prop:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext.ValidationMessageElement` element.
            <code>null</code> if the <em>expression</em> is valid and client-side validation is disabled.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent ValidationMessage(IHtmlHelper htmlHelper, string expression)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperValidationExtensions.ValidationMessage(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.Object)
    
        
    
        
        Returns the validation message if an error exists in the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary`
        object for the specified <em>expression</em>.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
    
        
        :param htmlAttributes: 
            An :any:`System.Object` that contains the HTML attributes for the
            ( :dn:prop:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext.ValidationMessageElement`\) element. Alternatively, an
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the HTML
            attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: 
            A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing a :dn:prop:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext.ValidationMessageElement` element.
            <code>null</code> if the <em>expression</em> is valid and client-side validation is disabled.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent ValidationMessage(IHtmlHelper htmlHelper, string expression, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperValidationExtensions.ValidationMessage(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.String)
    
        
    
        
        Returns the validation message if an error exists in the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary`
        object for the specified <em>expression</em>.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
    
        
        :param message: 
            The message to be displayed. If <code>null</code> or empty, method extracts an error string from the
            :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary` object. Message will always be visible but client-side
            validation may update the associated CSS class.
        
        :type message: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: 
            A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing a :dn:prop:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext.ValidationMessageElement` element.
            <code>null</code> if the <em>expression</em> is valid and client-side validation is disabled.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent ValidationMessage(IHtmlHelper htmlHelper, string expression, string message)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperValidationExtensions.ValidationMessage(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.String, System.Object)
    
        
    
        
        Returns the validation message if an error exists in the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary`
        object for the specified <em>expression</em>.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
    
        
        :param message: 
            The message to be displayed. If <code>null</code> or empty, method extracts an error string from the
            :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary` object. Message will always be visible but client-side
            validation may update the associated CSS class.
        
        :type message: System.String
    
        
        :param htmlAttributes: 
            An :any:`System.Object` that contains the HTML attributes for the
            ( :dn:prop:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext.ValidationMessageElement`\) element. Alternatively, an
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the HTML
            attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: 
            A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing a :dn:prop:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext.ValidationMessageElement` element.
            <code>null</code> if the <em>expression</em> is valid and client-side validation is disabled.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent ValidationMessage(IHtmlHelper htmlHelper, string expression, string message, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperValidationExtensions.ValidationMessage(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.String, System.String)
    
        
    
        
        Returns the validation message if an error exists in the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary`
        object for the specified <em>expression</em>.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
    
        
        :param message: 
            The message to be displayed. If <code>null</code> or empty, method extracts an error string from the
            :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary` object. Message will always be visible but client-side
            validation may update the associated CSS class.
        
        :type message: System.String
    
        
        :param tag: 
            The tag to wrap the <em>message</em> in the generated HTML. Its default value is
            :dn:prop:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext.ValidationMessageElement`\.
        
        :type tag: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: 
            A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing a <em>tag</em> element. <code>null</code> if the
            <em>expression</em> is valid and client-side validation is disabled.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent ValidationMessage(IHtmlHelper htmlHelper, string expression, string message, string tag)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperValidationExtensions.ValidationMessageFor<TModel, TResult>(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, TResult>>)
    
        
    
        
        Returns the validation message if an error exists in the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary`
        object for the specified <em>expression</em>.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper`1>{TModel}
    
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: 
            A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing a :dn:prop:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext.ValidationMessageElement` element.
            <code>null</code> if the <em>expression</em> is valid and client-side validation is disabled.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent ValidationMessageFor<TModel, TResult>(IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperValidationExtensions.ValidationMessageFor<TModel, TResult>(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.String)
    
        
    
        
        Returns the validation message if an error exists in the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary`
        object for the specified <em>expression</em>.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper`1>{TModel}
    
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
    
        
        :param message: 
            The message to be displayed. If <code>null</code> or empty, method extracts an error string from the
            :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary` object. Message will always be visible but client-side
            validation may update the associated CSS class.
        
        :type message: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: 
            A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing a :dn:prop:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext.ValidationMessageElement` element.
            <code>null</code> if the <em>expression</em> is valid and client-side validation is disabled.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent ValidationMessageFor<TModel, TResult>(IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression, string message)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperValidationExtensions.ValidationMessageFor<TModel, TResult>(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.String, System.Object)
    
        
    
        
        Returns the validation message if an error exists in the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary`
        object for the specified <em>expression</em>.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper`1>{TModel}
    
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
    
        
        :param message: 
            The message to be displayed. If <code>null</code> or empty, method extracts an error string from the
            :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary` object. Message will always be visible but client-side
            validation may update the associated CSS class.
        
        :type message: System.String
    
        
        :param htmlAttributes: 
            An :any:`System.Object` that contains the HTML attributes for the
            ( :dn:prop:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext.ValidationMessageElement`\) element. Alternatively, an
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the HTML
            attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: 
            A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing a :dn:prop:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext.ValidationMessageElement` element.
            <code>null</code> if the <em>expression</em> is valid and client-side validation is disabled.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent ValidationMessageFor<TModel, TResult>(IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression, string message, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperValidationExtensions.ValidationMessageFor<TModel, TResult>(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.String, System.String)
    
        
    
        
        Returns the validation message if an error exists in the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary`
        object for the specified <em>expression</em>.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper`1>{TModel}
    
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
    
        
        :param message: 
            The message to be displayed. If <code>null</code> or empty, method extracts an error string from the
            :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary` object. Message will always be visible but client-side
            validation may update the associated CSS class.
        
        :type message: System.String
    
        
        :param tag: 
            The tag to wrap the <em>message</em> in the generated HTML. Its default value is
            :dn:prop:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext.ValidationMessageElement`\.
        
        :type tag: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: 
            A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <em>tag</em> element. <code>null</code> if the
            <em>expression</em> is valid and client-side validation is disabled.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent ValidationMessageFor<TModel, TResult>(IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression, string message, string tag)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperValidationExtensions.ValidationSummary(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper)
    
        
    
        
        Returns an unordered list (<ul> element) of validation messages that are in the
        :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary` object.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: 
            New :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing a <div> element wrapping the <ul> element.
            :dn:field:`Microsoft.AspNetCore.Mvc.Rendering.HtmlString.Empty` if the current model is valid and client-side validation is disabled).
    
        
        .. code-block:: csharp
    
            public static IHtmlContent ValidationSummary(IHtmlHelper htmlHelper)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperValidationExtensions.ValidationSummary(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.Boolean)
    
        
    
        
        Returns an unordered list (<ul> element) of validation messages that are in the
        :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary` object.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param excludePropertyErrors: 
            If <code>true</code>, display model-level errors only; otherwise display all errors.
        
        :type excludePropertyErrors: System.Boolean
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: 
            New :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing a <div> element wrapping the <ul> element.
            :dn:field:`Microsoft.AspNetCore.Mvc.Rendering.HtmlString.Empty` if the current model is valid and client-side validation is disabled).
    
        
        .. code-block:: csharp
    
            public static IHtmlContent ValidationSummary(IHtmlHelper htmlHelper, bool excludePropertyErrors)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperValidationExtensions.ValidationSummary(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.Boolean, System.String)
    
        
    
        
        Returns an unordered list (<ul> element) of validation messages that are in the
        :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary` object.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param excludePropertyErrors: 
            If <code>true</code>, display model-level errors only; otherwise display all errors.
        
        :type excludePropertyErrors: System.Boolean
    
        
        :param message: The message to display with the validation summary.
        
        :type message: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: 
            New :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing a <div> element wrapping the
            :dn:prop:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext.ValidationSummaryMessageElement` element (which, in turn, wraps the
            <em>message</em>) and the <ul> element. :dn:field:`Microsoft.AspNetCore.Mvc.Rendering.HtmlString.Empty` if the current model
            is valid and client-side validation is disabled).
    
        
        .. code-block:: csharp
    
            public static IHtmlContent ValidationSummary(IHtmlHelper htmlHelper, bool excludePropertyErrors, string message)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperValidationExtensions.ValidationSummary(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.Boolean, System.String, System.Object)
    
        
    
        
        Returns an unordered list (<ul> element) of validation messages that are in the
        :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary` object.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param excludePropertyErrors: 
            If <code>true</code>, display model-level errors only; otherwise display all errors.
        
        :type excludePropertyErrors: System.Boolean
    
        
        :param message: The message to display with the validation summary.
        
        :type message: System.String
    
        
        :param htmlAttributes: 
            An :any:`System.Object` that contains the HTML attributes for the topmost (<div>) element.
            Alternatively, an :any:`System.Collections.Generic.IDictionary\`2` instance containing
            the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: 
            New :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing a <div> element wrapping the
            :dn:prop:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext.ValidationSummaryMessageElement` element (which wraps the
            <em>message</em>) and the <ul> element. :dn:field:`Microsoft.AspNetCore.Mvc.Rendering.HtmlString.Empty` if the current model
            is valid and client-side validation is disabled).
    
        
        .. code-block:: csharp
    
            public static IHtmlContent ValidationSummary(IHtmlHelper htmlHelper, bool excludePropertyErrors, string message, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperValidationExtensions.ValidationSummary(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.Boolean, System.String, System.String)
    
        
    
        
        Returns an unordered list (<ul> element) of validation messages that are in the
        :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary` object.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param excludePropertyErrors: 
            If <code>true</code>, display model-level errors only; otherwise display all errors.
        
        :type excludePropertyErrors: System.Boolean
    
        
        :param message: The message to display with the validation summary.
        
        :type message: System.String
    
        
        :param tag: 
            The tag to wrap the <em>message</em> in the generated HTML. Its default value is
            :dn:prop:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext.ValidationSummaryMessageElement`\.
        
        :type tag: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: 
            New :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing a <div> element wrapping the <em>tag</em> element
            and the <ul> element. :dn:field:`Microsoft.AspNetCore.Mvc.Rendering.HtmlString.Empty` if the current model is valid and client-side
            validation is disabled).
    
        
        .. code-block:: csharp
    
            public static IHtmlContent ValidationSummary(IHtmlHelper htmlHelper, bool excludePropertyErrors, string message, string tag)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperValidationExtensions.ValidationSummary(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String)
    
        
    
        
        Returns an unordered list (<ul> element) of validation messages that are in the
        :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary` object.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param message: The message to display with the validation summary.
        
        :type message: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: 
            New :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing a <div> element wrapping the
            :dn:prop:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext.ValidationSummaryMessageElement` element (which wraps the
            <em>message</em>) and the <ul> element. :dn:field:`Microsoft.AspNetCore.Mvc.Rendering.HtmlString.Empty` if the current model
            is valid and client-side validation is disabled).
    
        
        .. code-block:: csharp
    
            public static IHtmlContent ValidationSummary(IHtmlHelper htmlHelper, string message)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperValidationExtensions.ValidationSummary(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.Object)
    
        
    
        
        Returns an unordered list (<ul> element) of validation messages that are in the
        :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary` object.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param message: The message to display with the validation summary.
        
        :type message: System.String
    
        
        :param htmlAttributes: 
            An :any:`System.Object` that contains the HTML attributes for the topmost (<div>) element.
            Alternatively, an :any:`System.Collections.Generic.IDictionary\`2` instance containing
            the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: 
            New :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing a <div> element wrapping the
            :dn:prop:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext.ValidationSummaryMessageElement` element (which wraps the
            <em>message</em>) and the <ul> element. :dn:field:`Microsoft.AspNetCore.Mvc.Rendering.HtmlString.Empty` if the current model
            is valid and client-side validation is disabled).
    
        
        .. code-block:: csharp
    
            public static IHtmlContent ValidationSummary(IHtmlHelper htmlHelper, string message, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperValidationExtensions.ValidationSummary(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.Object, System.String)
    
        
    
        
        Returns an unordered list (<ul> element) of validation messages that are in the
        :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary` object.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param message: The message to display with the validation summary.
        
        :type message: System.String
    
        
        :param htmlAttributes: 
            An :any:`System.Object` that contains the HTML attributes for the topmost (<div>) element.
            Alternatively, an :any:`System.Collections.Generic.IDictionary\`2` instance containing
            the HTML attributes.
        
        :type htmlAttributes: System.Object
    
        
        :param tag: 
            The tag to wrap the <em>message</em> in the generated HTML. Its default value is
            :dn:prop:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext.ValidationSummaryMessageElement`\.
        
        :type tag: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: 
            New :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing a <div> element wrapping the <em>tag</em> element
            and the <ul> element. :dn:field:`Microsoft.AspNetCore.Mvc.Rendering.HtmlString.Empty` if the current model is valid and client-side
            validation is disabled).
    
        
        .. code-block:: csharp
    
            public static IHtmlContent ValidationSummary(IHtmlHelper htmlHelper, string message, object htmlAttributes, string tag)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperValidationExtensions.ValidationSummary(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.String)
    
        
    
        
        Returns an unordered list (<ul> element) of validation messages that are in the
        :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary` object.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param message: The message to display with the validation summary.
        
        :type message: System.String
    
        
        :param tag: 
            The tag to wrap the <em>message</em> in the generated HTML. Its default value is
            :dn:prop:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext.ValidationSummaryMessageElement`\.
        
        :type tag: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: 
            New :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing a <div> element wrapping the <em>tag</em> element
            and the <ul> element. :dn:field:`Microsoft.AspNetCore.Mvc.Rendering.HtmlString.Empty` if the current model is valid and client-side
            validation is disabled).
    
        
        .. code-block:: csharp
    
            public static IHtmlContent ValidationSummary(IHtmlHelper htmlHelper, string message, string tag)
    

