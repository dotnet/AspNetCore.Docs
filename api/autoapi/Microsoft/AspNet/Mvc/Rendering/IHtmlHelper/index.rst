

IHtmlHelper Interface
=====================



.. contents:: 
   :local:



Summary
-------

Base HTML helpers.











Syntax
------

.. code-block:: csharp

   public interface IHtmlHelper





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ViewFeatures/Rendering/IHtmlHelper.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper.ActionLink(System.String, System.String, System.String, System.String, System.String, System.String, System.Object, System.Object)
    
        
    
        Returns an anchor (&lt;a&gt;) element that contains a URL path to the specified action.
    
        
        
        
        :param linkText: The inner text of the anchor element. Must not be null.
        
        :type linkText: System.String
        
        
        :param actionName: The name of the action.
        
        :type actionName: System.String
        
        
        :param controllerName: The name of the controller.
        
        :type controllerName: System.String
        
        
        :param protocol: The protocol for the URL, such as "http" or "https".
        
        :type protocol: System.String
        
        
        :param hostname: The host name for the URL.
        
        :type hostname: System.String
        
        
        :param fragment: The URL fragment name (the anchor name).
        
        :type fragment: System.String
        
        
        :param routeValues: An  that contains the parameters for a route. The parameters are retrieved through
            reflection by examining the properties of the . This  is typically
            created using  initializer syntax. Alternatively, an
            instance containing the route parameters.
        
        :type routeValues: System.Object
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the element. Alternatively, an
            instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the anchor element.
    
        
        .. code-block:: csharp
    
           IHtmlContent ActionLink(string linkText, string actionName, string controllerName, string protocol, string hostname, string fragment, object routeValues, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper.AntiForgeryToken()
    
        
    
        Returns a &lt;hidden&gt; element (antiforgery token) that will be validated when the containing
        &lt;form&gt; is submitted.
    
        
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;hidden&gt; element.
    
        
        .. code-block:: csharp
    
           IHtmlContent AntiForgeryToken()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper.BeginForm(System.String, System.String, System.Object, Microsoft.AspNet.Mvc.Rendering.FormMethod, System.Object)
    
        
    
        Renders a &lt;form&gt; start tag to the response. When the user submits the form, the action with name
        ``actionName`` will process the request.
    
        
        
        
        :param actionName: The name of the action method.
        
        :type actionName: System.String
        
        
        :param controllerName: The name of the controller.
        
        :type controllerName: System.String
        
        
        :param routeValues: An  that contains the parameters for a route. The parameters are retrieved through
            reflection by examining the properties of the . This  is typically
            created using  initializer syntax. Alternatively, an
            instance containing the route parameters.
        
        :type routeValues: System.Object
        
        
        :param method: The HTTP method for processing the form, either GET or POST.
        
        :type method: Microsoft.AspNet.Mvc.Rendering.FormMethod
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the element. Alternatively, an
            instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Mvc.Rendering.MvcForm
        :return: An <see cref="T:Microsoft.AspNet.Mvc.Rendering.MvcForm" /> instance which renders the &lt;/form&gt; end tag when disposed.
    
        
        .. code-block:: csharp
    
           MvcForm BeginForm(string actionName, string controllerName, object routeValues, FormMethod method, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper.BeginRouteForm(System.String, System.Object, Microsoft.AspNet.Mvc.Rendering.FormMethod, System.Object)
    
        
    
        Renders a &lt;form&gt; start tag to the response. The route with name ``routeName``
        generates the &lt;form&gt;'s <c>action</c> attribute value.
    
        
        
        
        :param routeName: The name of the route.
        
        :type routeName: System.String
        
        
        :param routeValues: An  that contains the parameters for a route. The parameters are retrieved through
            reflection by examining the properties of the . This  is typically
            created using  initializer syntax. Alternatively, an
            instance containing the route parameters.
        
        :type routeValues: System.Object
        
        
        :param method: The HTTP method for processing the form, either GET or POST.
        
        :type method: Microsoft.AspNet.Mvc.Rendering.FormMethod
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the element. Alternatively, an
            instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Mvc.Rendering.MvcForm
        :return: An <see cref="T:Microsoft.AspNet.Mvc.Rendering.MvcForm" /> instance which renders the &lt;/form&gt; end tag when disposed.
    
        
        .. code-block:: csharp
    
           MvcForm BeginRouteForm(string routeName, object routeValues, FormMethod method, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper.CheckBox(System.String, System.Nullable<System.Boolean>, System.Object)
    
        
    
        Returns an &lt;input&gt; element of type "checkbox" with value "true" and an &lt;input&gt; element of type
        "hidden" with value "false".
    
        
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        
        
        :param isChecked: If true, checkbox is initially checked.
        
        :type isChecked: System.Nullable{System.Boolean}
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the checkbox element. Alternatively, an
            instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; elements.
    
        
        .. code-block:: csharp
    
           IHtmlContent CheckBox(string expression, bool ? isChecked, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper.Display(System.String, System.String, System.String, System.Object)
    
        
    
        Returns HTML markup for the ``expression``, using a display template, specified HTML field
        name, and additional view data. The template is found using the ``templateName`` or the
        ``expression``'s :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata`\.
    
        
        
        
        :param expression: Expression name, relative to the current model. May identify a single property or an
            that contains the properties to display.
        
        :type expression: System.String
        
        
        :param templateName: The name of the template used to create the HTML markup.
        
        :type templateName: System.String
        
        
        :param htmlFieldName: A  used to disambiguate the names of HTML elements that are created for
            properties that have the same name.
        
        :type htmlFieldName: System.String
        
        
        :param additionalViewData: An anonymous  or  that can contain additional
            view data that will be merged into the  instance created for the
            template.
        
        :type additionalViewData: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the created HTML.
    
        
        .. code-block:: csharp
    
           IHtmlContent Display(string expression, string templateName, string htmlFieldName, object additionalViewData)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper.DisplayName(System.String)
    
        
    
        Returns the display name for the specified ``expression``.
    
        
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        :rtype: System.String
        :return: A <see cref="T:System.String" /> containing the display name.
    
        
        .. code-block:: csharp
    
           string DisplayName(string expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper.DisplayText(System.String)
    
        
    
        Returns the simple display text for the specified ``expression``.
    
        
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        :rtype: System.String
        :return: A <see cref="T:System.String" /> containing the simple display text.
            If the expression result is <c>null</c>, returns <see cref="P:Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.NullDisplayText" />.
    
        
        .. code-block:: csharp
    
           string DisplayText(string expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper.DropDownList(System.String, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.Rendering.SelectListItem>, System.String, System.Object)
    
        
    
        Returns a single-selection HTML &lt;select&gt; element for the ``expression``,
        using the specified list items, option label, and HTML attributes.
    
        
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        
        
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
    
           IHtmlContent DropDownList(string expression, IEnumerable<SelectListItem> selectList, string optionLabel, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper.Editor(System.String, System.String, System.String, System.Object)
    
        
    
        Returns HTML markup for the ``expression``, using an editor template, specified HTML field
        name, and additional view data. The template is found using the ``templateName`` or the
        ``expression``'s :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata`\.
    
        
        
        
        :param expression: Expression name, relative to the current model. May identify a single property or an
            that contains the properties to edit.
        
        :type expression: System.String
        
        
        :param templateName: The name of the template used to create the HTML markup.
        
        :type templateName: System.String
        
        
        :param htmlFieldName: A  used to disambiguate the names of HTML elements that are created for
            properties that have the same name.
        
        :type htmlFieldName: System.String
        
        
        :param additionalViewData: An anonymous  or  that can contain additional
            view data that will be merged into the  instance created for the
            template.
        
        :type additionalViewData: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; element(s).
    
        
        .. code-block:: csharp
    
           IHtmlContent Editor(string expression, string templateName, string htmlFieldName, object additionalViewData)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper.Encode(System.Object)
    
        
    
        Converts the ``value`` to an HTML-encoded :any:`System.String`\.
    
        
        
        
        :param value: The  to encode.
        
        :type value: System.Object
        :rtype: System.String
        :return: The HTML-encoded <see cref="T:System.String" />.
    
        
        .. code-block:: csharp
    
           string Encode(object value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper.Encode(System.String)
    
        
    
        Converts the specified :any:`System.String` to an HTML-encoded :any:`System.String`\.
    
        
        
        
        :param value: The  to encode.
        
        :type value: System.String
        :rtype: System.String
        :return: The HTML-encoded <see cref="T:System.String" />.
    
        
        .. code-block:: csharp
    
           string Encode(string value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper.EndForm()
    
        
    
        Renders the &lt;/form&gt; end tag to the response.
    
        
    
        
        .. code-block:: csharp
    
           void EndForm()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper.FormatValue(System.Object, System.String)
    
        
    
        Formats the value.
    
        
        
        
        :param value: The value.
        
        :type value: System.Object
        
        
        :param format: The composite format  (see http://msdn.microsoft.com/en-us/library/txafckwd.aspx).
        
        :type format: System.String
        :rtype: System.String
        :return: A <see cref="T:System.String" /> containing the formatted value.
    
        
        .. code-block:: csharp
    
           string FormatValue(object value, string format)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper.GenerateIdFromName(System.String)
    
        
    
        Returns an HTML element Id for the specified expression ``fullName``.
    
        
        
        
        :param fullName: Fully-qualified expression name, ignoring the current model. Must not be null.
        
        :type fullName: System.String
        :rtype: System.String
        :return: A <see cref="T:System.String" /> containing the element Id.
    
        
        .. code-block:: csharp
    
           string GenerateIdFromName(string fullName)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper.GetClientValidationRules(Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer, System.String)
    
        
    
        Returns information about about client validation rules for the specified ``metadata`` or
        ``expression``. Intended for use in :any:`Microsoft.AspNet.Mvc.Rendering.IHtmlHelper` extension methods.
    
        
        
        
        :type modelExplorer: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        
        
        :param expression: Expression name, relative to the current model. Used to determine  when
            is null; ignored otherwise.
        
        :type expression: System.String
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelClientValidationRule}
        :return: An <see cref="T:System.Collections.Generic.IEnumerable`1" /> containing the relevant rules.
    
        
        .. code-block:: csharp
    
           IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelExplorer modelExplorer, string expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper.GetEnumSelectList(System.Type)
    
        
    
        Returns a select list for the given ``enumType``.
    
        
        
        
        :param enumType: to generate a select list for.
        
        :type enumType: System.Type
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.Rendering.SelectListItem}
        :return: An <see cref="T:System.Collections.Generic.IEnumerable`1" /> containing the select list for the given
            <paramref name="enumType" />.
    
        
        .. code-block:: csharp
    
           IEnumerable<SelectListItem> GetEnumSelectList(Type enumType)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper.GetEnumSelectList<TEnum>()
    
        
    
        Returns a select list for the given ``TEnum``.
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.Rendering.SelectListItem}
        :return: An <see cref="T:System.Collections.Generic.IEnumerable`1" /> containing the select list for the given
            <typeparamref name="TEnum" />.
    
        
        .. code-block:: csharp
    
           IEnumerable<SelectListItem> GetEnumSelectList<TEnum>()where TEnum : struct
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper.Hidden(System.String, System.Object, System.Object)
    
        
    
        Returns an &lt;input&gt; element of type "hidden" for the specified ``expression``.
    
        
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        
        
        :param value: If non-null, value to include in the element.
        
        :type value: System.Object
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the element. Alternatively, an
            instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; element.
    
        
        .. code-block:: csharp
    
           IHtmlContent Hidden(string expression, object value, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper.Id(System.String)
    
        
    
        Returns the HTML element Id for the specified ``expression``.
    
        
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        :rtype: System.String
        :return: A <see cref="T:System.String" /> containing the element Id.
    
        
        .. code-block:: csharp
    
           string Id(string expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper.Label(System.String, System.String, System.Object)
    
        
    
        Returns a &lt;label&gt; element for the specified ``expression``.
    
        
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        
        
        :param labelText: The inner text of the element.
        
        :type labelText: System.String
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the element. Alternatively, an
            instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;label&gt; element.
    
        
        .. code-block:: csharp
    
           IHtmlContent Label(string expression, string labelText, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper.ListBox(System.String, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.Rendering.SelectListItem>, System.Object)
    
        
    
        Returns a multi-selection &lt;select&gt; element for the ``expression``, using the
        specified list items and HTML attributes.
    
        
        
        
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
    
           IHtmlContent ListBox(string expression, IEnumerable<SelectListItem> selectList, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper.Name(System.String)
    
        
    
        Returns the full HTML element name for the specified ``expression``.
    
        
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        :rtype: System.String
        :return: A <see cref="T:System.String" /> containing the element name.
    
        
        .. code-block:: csharp
    
           string Name(string expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper.PartialAsync(System.String, System.Object, Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary)
    
        
    
        Returns HTML markup for the specified partial view.
    
        
        
        
        :param partialViewName: The name of the partial view used to create the HTML markup. Must not be null.
        
        :type partialViewName: System.String
        
        
        :param model: A model to pass into the partial view.
        
        :type model: System.Object
        
        
        :param viewData: A  to pass into the partial view.
        
        :type viewData: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Html.Abstractions.IHtmlContent}
        :return: A <see cref="T:System.Threading.Tasks.Task" /> that on completion returns a new <see cref="T:Microsoft.AspNet.Mvc.Rendering.HtmlString" /> containing
            the created HTML.
    
        
        .. code-block:: csharp
    
           Task<IHtmlContent> PartialAsync(string partialViewName, object model, ViewDataDictionary viewData)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper.Password(System.String, System.Object, System.Object)
    
        
    
        Returns an &lt;input&gt; element of type "password" for the specified ``expression``.
    
        
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        
        
        :param value: If non-null, value to include in the element.
        
        :type value: System.Object
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the element. Alternatively, an
            instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; element.
    
        
        .. code-block:: csharp
    
           IHtmlContent Password(string expression, object value, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper.RadioButton(System.String, System.Object, System.Nullable<System.Boolean>, System.Object)
    
        
    
        Returns an &lt;input&gt; element of type "radio" for the specified ``expression``.
    
        
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        
        
        :param value: If non-null, value to include in the element. Must not be null if
            is also null and no "checked" entry exists in
            .
        
        :type value: System.Object
        
        
        :param isChecked: If true, radio button is initially selected. Must not be null if
            is also null and no "checked" entry exists in
            .
        
        :type isChecked: System.Nullable{System.Boolean}
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the element. Alternatively, an
            instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; element.
    
        
        .. code-block:: csharp
    
           IHtmlContent RadioButton(string expression, object value, bool ? isChecked, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper.Raw(System.Object)
    
        
    
        Wraps HTML markup from the string representation of an :any:`System.Object` in an 
        :any:`Microsoft.AspNet.Mvc.Rendering.HtmlString`\, without HTML-encoding the string representation.
    
        
        
        
        :param value: The  to wrap.
        
        :type value: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the wrapped string representation.
    
        
        .. code-block:: csharp
    
           IHtmlContent Raw(object value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper.Raw(System.String)
    
        
    
        Wraps HTML markup in an :any:`Microsoft.AspNet.Mvc.Rendering.HtmlString`\, without HTML-encoding the specified
        ``value``.
    
        
        
        
        :param value: HTML markup .
        
        :type value: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the wrapped <see cref="T:System.String" />.
    
        
        .. code-block:: csharp
    
           IHtmlContent Raw(string value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper.RenderPartialAsync(System.String, System.Object, Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary)
    
        
    
        Renders HTML markup for the specified partial view.
    
        
        
        
        :param partialViewName: The name of the partial view used to create the HTML markup. Must not be null.
        
        :type partialViewName: System.String
        
        
        :param model: A model to pass into the partial view.
        
        :type model: System.Object
        
        
        :param viewData: A  to pass into the partial view.
        
        :type viewData: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary
        :rtype: System.Threading.Tasks.Task
        :return: A <see cref="T:System.Threading.Tasks.Task" /> that renders the created HTML when it executes.
    
        
        .. code-block:: csharp
    
           Task RenderPartialAsync(string partialViewName, object model, ViewDataDictionary viewData)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper.RouteLink(System.String, System.String, System.String, System.String, System.String, System.Object, System.Object)
    
        
    
        Returns an anchor (&lt;a&gt;) element that contains a URL path to the specified route.
    
        
        
        
        :param linkText: The inner text of the anchor element. Must not be null.
        
        :type linkText: System.String
        
        
        :param routeName: The name of the route.
        
        :type routeName: System.String
        
        
        :param protocol: The protocol for the URL, such as "http" or "https".
        
        :type protocol: System.String
        
        
        :param hostName: The host name for the URL.
        
        :type hostName: System.String
        
        
        :param fragment: The URL fragment name (the anchor name).
        
        :type fragment: System.String
        
        
        :param routeValues: An  that contains the parameters for a route. The parameters are retrieved through
            reflection by examining the properties of the . This  is typically
            created using  initializer syntax. Alternatively, an
            instance containing the route parameters.
        
        :type routeValues: System.Object
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the element. Alternatively, an
            instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the anchor element.
    
        
        .. code-block:: csharp
    
           IHtmlContent RouteLink(string linkText, string routeName, string protocol, string hostName, string fragment, object routeValues, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper.TextArea(System.String, System.String, System.Int32, System.Int32, System.Object)
    
        
    
        Returns a &lt;textarea&gt; element for the specified ``expression``.
    
        
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        
        
        :param value: If non-null, value to include in the element.
        
        :type value: System.String
        
        
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
    
           IHtmlContent TextArea(string expression, string value, int rows, int columns, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper.TextBox(System.String, System.Object, System.String, System.Object)
    
        
    
        Returns an &lt;input&gt; element of type "text" for the specified ``current``.
    
        
        
        
        :param current: Expression name, relative to the current model.
        
        :type current: System.String
        
        
        :param value: If non-null, value to include in the element.
        
        :type value: System.Object
        
        
        :param format: The composite format  (see http://msdn.microsoft.com/en-us/library/txafckwd.aspx).
        
        :type format: System.String
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the element. Alternatively, an
            instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; element.
    
        
        .. code-block:: csharp
    
           IHtmlContent TextBox(string current, object value, string format, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper.ValidationMessage(System.String, System.String, System.Object, System.String)
    
        
    
        Returns the validation message if an error exists in the :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary` object
        for the specified ``expression``.
    
        
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        
        
        :param message: The message to be displayed. If null or empty, method extracts an error string from the
            object. Message will always be visible but client-side validation may
            update the associated CSS class.
        
        :type message: System.String
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the  element.
            Alternatively, an  instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        
        
        :param tag: The tag to wrap the  in the generated HTML. Its default value is
            .
        
        :type tag: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing a <paramref name="tag" /> element. <c>null</c> if the
            <paramref name="expression" /> is valid and client-side validation is disabled.
    
        
        .. code-block:: csharp
    
           IHtmlContent ValidationMessage(string expression, string message, object htmlAttributes, string tag)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper.ValidationSummary(System.Boolean, System.String, System.Object, System.String)
    
        
    
        Returns an unordered list (&lt;ul&gt; element) of validation messages that are in the 
        :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary` object.
    
        
        
        
        :param excludePropertyErrors: If true, display model-level errors only; otherwise display all errors.
        
        :type excludePropertyErrors: System.Boolean
        
        
        :param message: The message to display with the validation summary.
        
        :type message: System.String
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the topmost (<div>) element.
            Alternatively, an  instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        
        
        :param tag: The tag to wrap the  in the generated HTML. Its default value is
            .
        
        :type tag: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: New <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing a &lt;div&gt; element wrapping the <paramref name="tag" /> element
            and the &lt;ul&gt; element. <see cref="F:Microsoft.AspNet.Mvc.Rendering.HtmlString.Empty" /> if the current model is valid and client-side
            validation is disabled).
    
        
        .. code-block:: csharp
    
           IHtmlContent ValidationSummary(bool excludePropertyErrors, string message, object htmlAttributes, string tag)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper.Value(System.String, System.String)
    
        
    
        Returns the formatted value for the specified ``expression``.
    
        
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        
        
        :param format: The composite format  (see http://msdn.microsoft.com/en-us/library/txafckwd.aspx).
        
        :type format: System.String
        :rtype: System.String
        :return: A <see cref="T:System.String" /> containing the formatted value.
    
        
        .. code-block:: csharp
    
           string Value(string expression, string format)
    

Properties
----------

.. dn:interface:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper.Html5DateRenderingMode
    
        
    
        Set this property to :dn:field:`Microsoft.AspNet.Mvc.Rendering.Html5DateRenderingMode.Rfc3339` to have templated helpers such as 
        :dn:meth:`Microsoft.AspNet.Mvc.Rendering.IHtmlHelper.Editor(System.String,System.String,System.String,System.Object)` and :dn:meth:`Microsoft.AspNet.Mvc.Rendering.IHtmlHelper\`1.EditorFor\`\`1(System.Linq.Expressions.Expression{System.Func{\`0,\`\`0}},System.String,System.String,System.Object)` render date and time values as RFC
        3339 compliant strings. By default these helpers render dates and times using the current culture.
    
        
        :rtype: Microsoft.AspNet.Mvc.Rendering.Html5DateRenderingMode
    
        
        .. code-block:: csharp
    
           Html5DateRenderingMode Html5DateRenderingMode { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper.IdAttributeDotReplacement
    
        
    
        Gets the :any:`System.String` that replaces periods in the ID attribute of an element.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string IdAttributeDotReplacement { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper.JavaScriptStringEncoder
    
        
    
        Gets the :any:`Microsoft.Extensions.WebEncoders.IJavaScriptStringEncoder` to be used for encoding JavaScript.
    
        
        :rtype: Microsoft.Extensions.WebEncoders.IJavaScriptStringEncoder
    
        
        .. code-block:: csharp
    
           IJavaScriptStringEncoder JavaScriptStringEncoder { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper.MetadataProvider
    
        
    
        Gets the metadata provider. Intended for use in :any:`Microsoft.AspNet.Mvc.Rendering.IHtmlHelper` extension methods.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider
    
        
        .. code-block:: csharp
    
           IModelMetadataProvider MetadataProvider { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper.TempData
    
        
    
        Gets the current :any:`Microsoft.AspNet.Mvc.ViewFeatures.ITempDataDictionary` instance.
    
        
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.ITempDataDictionary
    
        
        .. code-block:: csharp
    
           ITempDataDictionary TempData { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper.UrlEncoder
    
        
    
        Gets the :any:`Microsoft.Extensions.WebEncoders.IUrlEncoder` to be used for encoding a URL.
    
        
        :rtype: Microsoft.Extensions.WebEncoders.IUrlEncoder
    
        
        .. code-block:: csharp
    
           IUrlEncoder UrlEncoder { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper.ViewBag
    
        
    
        Gets the view bag.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           dynamic ViewBag { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper.ViewContext
    
        
    
        Gets the context information about the view.
    
        
        :rtype: Microsoft.AspNet.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
           ViewContext ViewContext { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper.ViewData
    
        
    
        Gets the current view data.
    
        
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary
    
        
        .. code-block:: csharp
    
           ViewDataDictionary ViewData { get; }
    

