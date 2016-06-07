

IHtmlHelper Interface
=====================






Base HTML helpers.


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

    public interface IHtmlHelper








.. dn:interface:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.Html5DateRenderingMode
    
        
    
        
        Set this property to :dn:field:`Microsoft.AspNetCore.Mvc.Rendering.Html5DateRenderingMode.Rfc3339` to have templated helpers such as
        :dn:meth:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.Editor(System.String,System.String,System.String,System.Object)` and :dn:meth:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper\`1.EditorFor\`\`1(System.Linq.Expressions.Expression{System.Func{\`0,\`\`0}},System.String,System.String,System.Object)` render date and time values as RFC
        3339 compliant strings. By default these helpers render dates and times using the current culture.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.Html5DateRenderingMode
    
        
        .. code-block:: csharp
    
            Html5DateRenderingMode Html5DateRenderingMode
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.IdAttributeDotReplacement
    
        
    
        
        Gets the :any:`System.String` that replaces periods in the ID attribute of an element.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string IdAttributeDotReplacement
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.MetadataProvider
    
        
    
        
        Gets the metadata provider. Intended for use in :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` extension methods.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider
    
        
        .. code-block:: csharp
    
            IModelMetadataProvider MetadataProvider
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.TempData
    
        
    
        
        Gets the current :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary` instance.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary
    
        
        .. code-block:: csharp
    
            ITempDataDictionary TempData
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.UrlEncoder
    
        
    
        
        Gets the :dn:prop:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.UrlEncoder` to be used for encoding a URL.
    
        
        :rtype: System.Text.Encodings.Web.UrlEncoder
    
        
        .. code-block:: csharp
    
            UrlEncoder UrlEncoder
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.ViewBag
    
        
    
        
        Gets the view bag.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            dynamic ViewBag
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.ViewContext
    
        
    
        
        Gets the context information about the view.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
            ViewContext ViewContext
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.ViewData
    
        
    
        
        Gets the current view data.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary
    
        
        .. code-block:: csharp
    
            ViewDataDictionary ViewData
            {
                get;
            }
    

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.ActionLink(System.String, System.String, System.String, System.String, System.String, System.String, System.Object, System.Object)
    
        
    
        
        Returns an anchor (<a>) element that contains a URL path to the specified action.
    
        
    
        
        :param linkText: The inner text of the anchor element. Must not be <code>null</code>.
        
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
    
        
        :param routeValues: 
            An :any:`System.Object` that contains the parameters for a route. The parameters are retrieved through
            reflection by examining the properties of the :any:`System.Object`\. This :any:`System.Object` is typically
            created using :any:`System.Object` initializer syntax. Alternatively, an
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the route parameters.
        
        :type routeValues: System.Object
    
        
        :param htmlAttributes: 
            An :any:`System.Object` that contains the HTML attributes for the element. Alternatively, an
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the anchor element.
    
        
        .. code-block:: csharp
    
            IHtmlContent ActionLink(string linkText, string actionName, string controllerName, string protocol, string hostname, string fragment, object routeValues, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.AntiForgeryToken()
    
        
    
        
        Returns a <hidden> element (antiforgery token) that will be validated when the containing
        <form> is submitted.
    
        
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <hidden> element.
    
        
        .. code-block:: csharp
    
            IHtmlContent AntiForgeryToken()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.BeginForm(System.String, System.String, System.Object, Microsoft.AspNetCore.Mvc.Rendering.FormMethod, System.Nullable<System.Boolean>, System.Object)
    
        
    
        
        Renders a <form> start tag to the response. When the user submits the form, the action with name
        <em>actionName</em> will process the request.
    
        
    
        
        :param actionName: The name of the action method.
        
        :type actionName: System.String
    
        
        :param controllerName: The name of the controller.
        
        :type controllerName: System.String
    
        
        :param routeValues: 
            An :any:`System.Object` that contains the parameters for a route. The parameters are retrieved through
            reflection by examining the properties of the :any:`System.Object`\. This :any:`System.Object` is typically
            created using :any:`System.Object` initializer syntax. Alternatively, an
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the route parameters.
        
        :type routeValues: System.Object
    
        
        :param method: The HTTP method for processing the form, either GET or POST.
        
        :type method: Microsoft.AspNetCore.Mvc.Rendering.FormMethod
    
        
        :param antiforgery: 
            If <code>true</code>, <form> elements will include an antiforgery token.
            If <code>false</code>, suppresses the generation an <input> of type "hidden" with an antiforgery token.
            If <code>null</code>, <form> elements will include an antiforgery token only if
            <em>method</em> is not :dn:field:`Microsoft.AspNetCore.Mvc.Rendering.FormMethod.Get`\.
        
        :type antiforgery: System.Nullable<System.Nullable`1>{System.Boolean<System.Boolean>}
    
        
        :param htmlAttributes: 
            An :any:`System.Object` that contains the HTML attributes for the element. Alternatively, an
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.MvcForm
        :return: 
            An :any:`Microsoft.AspNetCore.Mvc.Rendering.MvcForm` instance which renders the </form> end tag when disposed.
    
        
        .. code-block:: csharp
    
            MvcForm BeginForm(string actionName, string controllerName, object routeValues, FormMethod method, bool ? antiforgery, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.BeginRouteForm(System.String, System.Object, Microsoft.AspNetCore.Mvc.Rendering.FormMethod, System.Nullable<System.Boolean>, System.Object)
    
        
    
        
        Renders a <form> start tag to the response. The route with name <em>routeName</em>
        generates the <form>'s <code>action</code> attribute value.
    
        
    
        
        :param routeName: The name of the route.
        
        :type routeName: System.String
    
        
        :param routeValues: 
            An :any:`System.Object` that contains the parameters for a route. The parameters are retrieved through
            reflection by examining the properties of the :any:`System.Object`\. This :any:`System.Object` is typically
            created using :any:`System.Object` initializer syntax. Alternatively, an
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the route parameters.
        
        :type routeValues: System.Object
    
        
        :param method: The HTTP method for processing the form, either GET or POST.
        
        :type method: Microsoft.AspNetCore.Mvc.Rendering.FormMethod
    
        
        :param antiforgery: 
            If <code>true</code>, <form> elements will include an antiforgery token.
            If <code>false</code>, suppresses the generation an <input> of type "hidden" with an antiforgery token.
            If <code>null</code>, <form> elements will include an antiforgery token only if
            <em>method</em> is not :dn:field:`Microsoft.AspNetCore.Mvc.Rendering.FormMethod.Get`\.
        
        :type antiforgery: System.Nullable<System.Nullable`1>{System.Boolean<System.Boolean>}
    
        
        :param htmlAttributes: 
            An :any:`System.Object` that contains the HTML attributes for the element. Alternatively, an
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.MvcForm
        :return: 
            An :any:`Microsoft.AspNetCore.Mvc.Rendering.MvcForm` instance which renders the </form> end tag when disposed.
    
        
        .. code-block:: csharp
    
            MvcForm BeginRouteForm(string routeName, object routeValues, FormMethod method, bool ? antiforgery, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.CheckBox(System.String, System.Nullable<System.Boolean>, System.Object)
    
        
    
        
        Returns an <input> element of type "checkbox" with value "true" and an <input> element of type
        "hidden" with value "false".
    
        
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
    
        
        :param isChecked: If <code>true</code>, checkbox is initially checked.
        
        :type isChecked: System.Nullable<System.Nullable`1>{System.Boolean<System.Boolean>}
    
        
        :param htmlAttributes: 
            An :any:`System.Object` that contains the HTML attributes for the checkbox element. Alternatively, an
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <input> elements.
    
        
        .. code-block:: csharp
    
            IHtmlContent CheckBox(string expression, bool ? isChecked, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.Display(System.String, System.String, System.String, System.Object)
    
        
    
        
        Returns HTML markup for the <em>expression</em>, using a display template, specified HTML field
        name, and additional view data. The template is found using the <em>templateName</em> or the
        <em>expression</em>'s :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`\.
    
        
    
        
        :param expression: 
            Expression name, relative to the current model. May identify a single property or an
            :any:`System.Object` that contains the properties to display.
        
        :type expression: System.String
    
        
        :param templateName: The name of the template used to create the HTML markup.
        
        :type templateName: System.String
    
        
        :param htmlFieldName: 
            A :any:`System.String` used to disambiguate the names of HTML elements that are created for
            properties that have the same name.
        
        :type htmlFieldName: System.String
    
        
        :param additionalViewData: 
            An anonymous :any:`System.Object` or :any:`System.Collections.Generic.IDictionary\`2` that can contain additional
            view data that will be merged into the :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary\`1` instance created for the
            template.
        
        :type additionalViewData: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the created HTML.
    
        
        .. code-block:: csharp
    
            IHtmlContent Display(string expression, string templateName, string htmlFieldName, object additionalViewData)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.DisplayName(System.String)
    
        
    
        
        Returns the display name for the specified <em>expression</em>.
    
        
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        :rtype: System.String
        :return: A :any:`System.String` containing the display name.
    
        
        .. code-block:: csharp
    
            string DisplayName(string expression)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.DisplayText(System.String)
    
        
    
        
        Returns the simple display text for the specified <em>expression</em>.
    
        
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        :rtype: System.String
        :return: 
            A :any:`System.String` containing the simple display text.
            If the expression result is <code>null</code>, returns :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.NullDisplayText`\.
    
        
        .. code-block:: csharp
    
            string DisplayText(string expression)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.DropDownList(System.String, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>, System.String, System.Object)
    
        
    
        
        Returns a single-selection HTML <select> element for the <em>expression</em>,
        using the specified list items, option label, and HTML attributes.
    
        
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
    
        
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
    
            IHtmlContent DropDownList(string expression, IEnumerable<SelectListItem> selectList, string optionLabel, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.Editor(System.String, System.String, System.String, System.Object)
    
        
    
        
        Returns HTML markup for the <em>expression</em>, using an editor template, specified HTML field
        name, and additional view data. The template is found using the <em>templateName</em> or the
        <em>expression</em>'s :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`\.
    
        
    
        
        :param expression: 
            Expression name, relative to the current model. May identify a single property or an
            :any:`System.Object` that contains the properties to edit.
        
        :type expression: System.String
    
        
        :param templateName: The name of the template used to create the HTML markup.
        
        :type templateName: System.String
    
        
        :param htmlFieldName: 
            A :any:`System.String` used to disambiguate the names of HTML elements that are created for
            properties that have the same name.
        
        :type htmlFieldName: System.String
    
        
        :param additionalViewData: 
            An anonymous :any:`System.Object` or :any:`System.Collections.Generic.IDictionary\`2` that can contain additional
            view data that will be merged into the :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary\`1` instance created for the
            template.
        
        :type additionalViewData: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <input> element(s).
    
        
        .. code-block:: csharp
    
            IHtmlContent Editor(string expression, string templateName, string htmlFieldName, object additionalViewData)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.Encode(System.Object)
    
        
    
        
        Converts the <em>value</em> to an HTML-encoded :any:`System.String`\.
    
        
    
        
        :param value: The :any:`System.Object` to encode.
        
        :type value: System.Object
        :rtype: System.String
        :return: The HTML-encoded :any:`System.String`\.
    
        
        .. code-block:: csharp
    
            string Encode(object value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.Encode(System.String)
    
        
    
        
        Converts the specified :any:`System.String` to an HTML-encoded :any:`System.String`\.
    
        
    
        
        :param value: The :any:`System.String` to encode.
        
        :type value: System.String
        :rtype: System.String
        :return: The HTML-encoded :any:`System.String`\.
    
        
        .. code-block:: csharp
    
            string Encode(string value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.EndForm()
    
        
    
        
        Renders the </form> end tag to the response.
    
        
    
        
        .. code-block:: csharp
    
            void EndForm()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.FormatValue(System.Object, System.String)
    
        
    
        
        Formats the value.
    
        
    
        
        :param value: The value.
        
        :type value: System.Object
    
        
        :param format: 
            The composite format :any:`System.String` (see http://msdn.microsoft.com/en-us/library/txafckwd.aspx).
        
        :type format: System.String
        :rtype: System.String
        :return: A :any:`System.String` containing the formatted value.
    
        
        .. code-block:: csharp
    
            string FormatValue(object value, string format)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.GenerateIdFromName(System.String)
    
        
    
        
        Returns an HTML element Id for the specified expression <em>fullName</em>.
    
        
    
        
        :param fullName: 
            Fully-qualified expression name, ignoring the current model. Must not be <code>null</code>.
        
        :type fullName: System.String
        :rtype: System.String
        :return: A :any:`System.String` containing the element Id.
    
        
        .. code-block:: csharp
    
            string GenerateIdFromName(string fullName)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.GetEnumSelectList(System.Type)
    
        
    
        
        Returns a select list for the given <em>enumType</em>.
    
        
    
        
        :param enumType: :any:`System.Type` to generate a select list for.
        
        :type enumType: System.Type
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.Rendering.SelectListItem<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>}
        :return: 
            An :any:`System.Collections.Generic.IEnumerable\`1` containing the select list for the given
            <em>enumType</em>.
    
        
        .. code-block:: csharp
    
            IEnumerable<SelectListItem> GetEnumSelectList(Type enumType)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.GetEnumSelectList<TEnum>()
    
        
    
        
        Returns a select list for the given <em>TEnum</em>.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.Rendering.SelectListItem<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>}
        :return: 
            An :any:`System.Collections.Generic.IEnumerable\`1` containing the select list for the given
            <em>TEnum</em>.
    
        
        .. code-block:: csharp
    
            IEnumerable<SelectListItem> GetEnumSelectList<TEnum>()where TEnum : struct
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.Hidden(System.String, System.Object, System.Object)
    
        
    
        
        Returns an <input> element of type "hidden" for the specified <em>expression</em>.
    
        
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
    
        
        :param value: If non-<code>null</code>, value to include in the element.
        
        :type value: System.Object
    
        
        :param htmlAttributes: 
            An :any:`System.Object` that contains the HTML attributes for the element. Alternatively, an
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <input> element.
    
        
        .. code-block:: csharp
    
            IHtmlContent Hidden(string expression, object value, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.Id(System.String)
    
        
    
        
        Returns the HTML element Id for the specified <em>expression</em>.
    
        
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        :rtype: System.String
        :return: A :any:`System.String` containing the element Id.
    
        
        .. code-block:: csharp
    
            string Id(string expression)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.Label(System.String, System.String, System.Object)
    
        
    
        
        Returns a <label> element for the specified <em>expression</em>.
    
        
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
    
        
        :param labelText: The inner text of the element.
        
        :type labelText: System.String
    
        
        :param htmlAttributes: 
            An :any:`System.Object` that contains the HTML attributes for the element. Alternatively, an
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <label> element.
    
        
        .. code-block:: csharp
    
            IHtmlContent Label(string expression, string labelText, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.ListBox(System.String, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>, System.Object)
    
        
    
        
        Returns a multi-selection <select> element for the <em>expression</em>, using the
        specified list items and HTML attributes.
    
        
    
        
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
    
            IHtmlContent ListBox(string expression, IEnumerable<SelectListItem> selectList, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.Name(System.String)
    
        
    
        
        Returns the full HTML element name for the specified <em>expression</em>.
    
        
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        :rtype: System.String
        :return: A :any:`System.String` containing the element name.
    
        
        .. code-block:: csharp
    
            string Name(string expression)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.PartialAsync(System.String, System.Object, Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary)
    
        
    
        
        Returns HTML markup for the specified partial view.
    
        
    
        
        :param partialViewName: 
            The name of the partial view used to create the HTML markup. Must not be <code>null</code>.
        
        :type partialViewName: System.String
    
        
        :param model: A model to pass into the partial view.
        
        :type model: System.Object
    
        
        :param viewData: A :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary` to pass into the partial view.
        
        :type viewData: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Html.IHtmlContent<Microsoft.AspNetCore.Html.IHtmlContent>}
        :return: 
            A :any:`System.Threading.Tasks.Task` that on completion returns a new :any:`Microsoft.AspNetCore.Html.IHtmlContent` instance containing
            the created HTML.
    
        
        .. code-block:: csharp
    
            Task<IHtmlContent> PartialAsync(string partialViewName, object model, ViewDataDictionary viewData)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.Password(System.String, System.Object, System.Object)
    
        
    
        
        Returns an <input> element of type "password" for the specified <em>expression</em>.
    
        
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
    
        
        :param value: If non-<code>null</code>, value to include in the element.
        
        :type value: System.Object
    
        
        :param htmlAttributes: 
            An :any:`System.Object` that contains the HTML attributes for the element. Alternatively, an
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <input> element.
    
        
        .. code-block:: csharp
    
            IHtmlContent Password(string expression, object value, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.RadioButton(System.String, System.Object, System.Nullable<System.Boolean>, System.Object)
    
        
    
        
        Returns an <input> element of type "radio" for the specified <em>expression</em>.
    
        
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
    
        
        :param value: 
            If non-<code>null</code>, value to include in the element. Must not be <code>null</code> if
            <em>isChecked</em> is also <code>null</code> and no "checked" entry exists in
            <em>htmlAttributes</em>.
        
        :type value: System.Object
    
        
        :param isChecked: 
            If <code>true</code>, radio button is initially selected. Must not be <code>null</code> if
            <em>value</em> is also <code>null</code> and no "checked" entry exists in
            <em>htmlAttributes</em>.
        
        :type isChecked: System.Nullable<System.Nullable`1>{System.Boolean<System.Boolean>}
    
        
        :param htmlAttributes: 
            An :any:`System.Object` that contains the HTML attributes for the element. Alternatively, an
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <input> element.
    
        
        .. code-block:: csharp
    
            IHtmlContent RadioButton(string expression, object value, bool ? isChecked, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.Raw(System.Object)
    
        
    
        
        Wraps HTML markup from the string representation of an :any:`System.Object` in an
        :any:`Microsoft.AspNetCore.Mvc.Rendering.HtmlString`\, without HTML-encoding the string representation.
    
        
    
        
        :param value: The :any:`System.Object` to wrap.
        
        :type value: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the wrapped string representation.
    
        
        .. code-block:: csharp
    
            IHtmlContent Raw(object value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.Raw(System.String)
    
        
    
        
        Wraps HTML markup in an :any:`Microsoft.AspNetCore.Mvc.Rendering.HtmlString`\, without HTML-encoding the specified
        <em>value</em>.
    
        
    
        
        :param value: HTML markup :any:`System.String`\.
        
        :type value: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the wrapped :any:`System.String`\.
    
        
        .. code-block:: csharp
    
            IHtmlContent Raw(string value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.RenderPartialAsync(System.String, System.Object, Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary)
    
        
    
        
        Renders HTML markup for the specified partial view.
    
        
    
        
        :param partialViewName: 
            The name of the partial view used to create the HTML markup. Must not be <code>null</code>.
        
        :type partialViewName: System.String
    
        
        :param model: A model to pass into the partial view.
        
        :type model: System.Object
    
        
        :param viewData: A :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary` to pass into the partial view.
        
        :type viewData: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary
        :rtype: System.Threading.Tasks.Task
        :return: A :any:`System.Threading.Tasks.Task` that renders the created HTML when it executes.
    
        
        .. code-block:: csharp
    
            Task RenderPartialAsync(string partialViewName, object model, ViewDataDictionary viewData)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.RouteLink(System.String, System.String, System.String, System.String, System.String, System.Object, System.Object)
    
        
    
        
        Returns an anchor (<a>) element that contains a URL path to the specified route.
    
        
    
        
        :param linkText: The inner text of the anchor element. Must not be <code>null</code>.
        
        :type linkText: System.String
    
        
        :param routeName: The name of the route.
        
        :type routeName: System.String
    
        
        :param protocol: The protocol for the URL, such as "http" or "https".
        
        :type protocol: System.String
    
        
        :param hostName: The host name for the URL.
        
        :type hostName: System.String
    
        
        :param fragment: The URL fragment name (the anchor name).
        
        :type fragment: System.String
    
        
        :param routeValues: 
            An :any:`System.Object` that contains the parameters for a route. The parameters are retrieved through
            reflection by examining the properties of the :any:`System.Object`\. This :any:`System.Object` is typically
            created using :any:`System.Object` initializer syntax. Alternatively, an
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the route parameters.
        
        :type routeValues: System.Object
    
        
        :param htmlAttributes: 
            An :any:`System.Object` that contains the HTML attributes for the element. Alternatively, an
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the anchor element.
    
        
        .. code-block:: csharp
    
            IHtmlContent RouteLink(string linkText, string routeName, string protocol, string hostName, string fragment, object routeValues, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.TextArea(System.String, System.String, System.Int32, System.Int32, System.Object)
    
        
    
        
        Returns a <textarea> element for the specified <em>expression</em>.
    
        
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
    
        
        :param value: If non-<code>null</code>, value to include in the element.
        
        :type value: System.String
    
        
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
    
            IHtmlContent TextArea(string expression, string value, int rows, int columns, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.TextBox(System.String, System.Object, System.String, System.Object)
    
        
    
        
        Returns an <input> element of type "text" for the specified <em>current</em>.
    
        
    
        
        :param current: Expression name, relative to the current model.
        
        :type current: System.String
    
        
        :param value: If non-<code>null</code>, value to include in the element.
        
        :type value: System.Object
    
        
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
    
            IHtmlContent TextBox(string current, object value, string format, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.ValidationMessage(System.String, System.String, System.Object, System.String)
    
        
    
        
        Returns the validation message if an error exists in the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary` object
        for the specified <em>expression</em>.
    
        
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
    
        
        :param message: 
            The message to be displayed. If <code>null</code> or empty, method extracts an error string from the
            :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary` object. Message will always be visible but client-side validation may
            update the associated CSS class.
        
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
            A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing a <em>tag</em> element. <code>null</code> if the
            <em>expression</em> is valid and client-side validation is disabled.
    
        
        .. code-block:: csharp
    
            IHtmlContent ValidationMessage(string expression, string message, object htmlAttributes, string tag)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.ValidationSummary(System.Boolean, System.String, System.Object, System.String)
    
        
    
        
        Returns an unordered list (<ul> element) of validation messages that are in the
        :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary` object.
    
        
    
        
        :param excludePropertyErrors: 
            If <code>true</code>, display model-level errors only; otherwise display all errors.
        
        :type excludePropertyErrors: System.Boolean
    
        
        :param message: The message to display with the validation summary.
        
        :type message: System.String
    
        
        :param htmlAttributes: 
            An :any:`System.Object` that contains the HTML attributes for the topmost (<div>) element.
            Alternatively, an :any:`System.Collections.Generic.IDictionary\`2` instance containing the HTML attributes.
        
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
    
            IHtmlContent ValidationSummary(bool excludePropertyErrors, string message, object htmlAttributes, string tag)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.Value(System.String, System.String)
    
        
    
        
        Returns the formatted value for the specified <em>expression</em>.
    
        
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
    
        
        :param format: 
            The composite format :any:`System.String` (see http://msdn.microsoft.com/en-us/library/txafckwd.aspx).
        
        :type format: System.String
        :rtype: System.String
        :return: A :any:`System.String` containing the formatted value.
    
        
        .. code-block:: csharp
    
            string Value(string expression, string format)
    

