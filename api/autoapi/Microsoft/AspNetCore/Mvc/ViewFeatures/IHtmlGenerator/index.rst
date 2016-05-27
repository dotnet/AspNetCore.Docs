

IHtmlGenerator Interface
========================






Contract for a service supporting :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` and <code>ITagHelper</code> implementations.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewFeatures`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IHtmlGenerator








.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator.IdAttributeDotReplacement
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string IdAttributeDotReplacement
            {
                get;
            }
    

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator.Encode(System.Object)
    
        
    
        
        :type value: System.Object
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string Encode(object value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator.Encode(System.String)
    
        
    
        
        :type value: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string Encode(string value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator.FormatValue(System.Object, System.String)
    
        
    
        
        :type value: System.Object
    
        
        :type format: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string FormatValue(object value, string format)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator.GenerateActionLink(Microsoft.AspNetCore.Mvc.Rendering.ViewContext, System.String, System.String, System.String, System.String, System.String, System.String, System.Object, System.Object)
    
        
    
        
        Generate a <a> element for a link to an action.
    
        
    
        
        :param viewContext: The :any:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext` instance for the current scope.
        
        :type viewContext: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        :param linkText: The text to insert inside the element.
        
        :type linkText: System.String
    
        
        :param actionName: The name of the action method.
        
        :type actionName: System.String
    
        
        :param controllerName: The name of the controller.
        
        :type controllerName: System.String
    
        
        :param protocol: The protocol (scheme) for the generated link.
        
        :type protocol: System.String
    
        
        :param hostname: The hostname for the generated link.
        
        :type hostname: System.String
    
        
        :param fragment: The fragment for the genrated link.
        
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
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder
        :return: 
            A :any:`Microsoft.AspNetCore.Mvc.Rendering.TagBuilder` instance for the <a> element.
    
        
        .. code-block:: csharp
    
            TagBuilder GenerateActionLink(ViewContext viewContext, string linkText, string actionName, string controllerName, string protocol, string hostname, string fragment, object routeValues, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator.GenerateAntiforgery(Microsoft.AspNetCore.Mvc.Rendering.ViewContext)
    
        
    
        
        Generate an <input type="hidden".../> element containing an antiforgery token.
    
        
    
        
        :param viewContext: The :any:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext` instance for the current scope.
        
        :type viewContext: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: 
            An :any:`Microsoft.AspNetCore.Html.IHtmlContent` instance for the <input type="hidden".../> element. Intended to be used
            inside a <form> element.
    
        
        .. code-block:: csharp
    
            IHtmlContent GenerateAntiforgery(ViewContext viewContext)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator.GenerateCheckBox(Microsoft.AspNetCore.Mvc.Rendering.ViewContext, Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer, System.String, System.Nullable<System.Boolean>, System.Object)
    
        
    
        
        Generate a <input type="checkbox".../> element.
    
        
    
        
        :param viewContext: The :any:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext` instance for the current scope.
        
        :type viewContext: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        :param modelExplorer: The :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer` for the <em>expression</em>.
        
        :type modelExplorer: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
    
        
        :param isChecked: The initial state of the checkbox element.
        
        :type isChecked: System.Nullable<System.Nullable`1>{System.Boolean<System.Boolean>}
    
        
        :param htmlAttributes: 
            An :any:`System.Object` that contains the HTML attributes for the element. Alternatively, an
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder
        :return: 
            A :any:`Microsoft.AspNetCore.Mvc.Rendering.TagBuilder` instance for the <input type="checkbox".../> element.
    
        
        .. code-block:: csharp
    
            TagBuilder GenerateCheckBox(ViewContext viewContext, ModelExplorer modelExplorer, string expression, bool ? isChecked, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator.GenerateForm(Microsoft.AspNetCore.Mvc.Rendering.ViewContext, System.String, System.String, System.Object, System.String, System.Object)
    
        
    
        
        Generate a <form> element. When the user submits the form, the action with name
        <em>actionName</em> will process the request.
    
        
    
        
        :param viewContext: A :any:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext` instance for the current scope.
        
        :type viewContext: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
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
        
        :type method: System.String
    
        
        :param htmlAttributes: 
            An :any:`System.Object` that contains the HTML attributes for the element. Alternatively, an
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder
        :return: 
            A :any:`Microsoft.AspNetCore.Mvc.Rendering.TagBuilder` instance for the </form> element.
    
        
        .. code-block:: csharp
    
            TagBuilder GenerateForm(ViewContext viewContext, string actionName, string controllerName, object routeValues, string method, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator.GenerateGroupsAndOptions(System.String, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>)
    
        
    
        
        Generates <optgroup> and <option> elements.
    
        
    
        
        :param optionLabel: Optional text for a default empty <option> element.
        
        :type optionLabel: System.String
    
        
        :param selectList: 
            A collection of :any:`Microsoft.AspNetCore.Mvc.Rendering.SelectListItem` objects used to generate <optgroup> and <option>
            elements.
        
        :type selectList: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.Rendering.SelectListItem<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>}
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: 
            An :any:`Microsoft.AspNetCore.Html.IHtmlContent` instance for <optgroup> and <option> elements.
    
        
        .. code-block:: csharp
    
            IHtmlContent GenerateGroupsAndOptions(string optionLabel, IEnumerable<SelectListItem> selectList)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator.GenerateHidden(Microsoft.AspNetCore.Mvc.Rendering.ViewContext, Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer, System.String, System.Object, System.Boolean, System.Object)
    
        
    
        
        :type viewContext: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        :type modelExplorer: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
    
        
        :type expression: System.String
    
        
        :type value: System.Object
    
        
        :type useViewData: System.Boolean
    
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
            TagBuilder GenerateHidden(ViewContext viewContext, ModelExplorer modelExplorer, string expression, object value, bool useViewData, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator.GenerateHiddenForCheckbox(Microsoft.AspNetCore.Mvc.Rendering.ViewContext, Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer, System.String)
    
        
    
        
        Generate an additional <input type="hidden".../> for checkboxes. This addresses scenarios where
        unchecked checkboxes are not sent in the request. Sending a hidden input makes it possible to know that the
        checkbox was present on the page when the request was submitted.
    
        
    
        
        :type viewContext: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        :type modelExplorer: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
    
        
        :type expression: System.String
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
            TagBuilder GenerateHiddenForCheckbox(ViewContext viewContext, ModelExplorer modelExplorer, string expression)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator.GenerateLabel(Microsoft.AspNetCore.Mvc.Rendering.ViewContext, Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer, System.String, System.String, System.Object)
    
        
    
        
        :type viewContext: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        :type modelExplorer: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
    
        
        :type expression: System.String
    
        
        :type labelText: System.String
    
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
            TagBuilder GenerateLabel(ViewContext viewContext, ModelExplorer modelExplorer, string expression, string labelText, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator.GeneratePassword(Microsoft.AspNetCore.Mvc.Rendering.ViewContext, Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer, System.String, System.Object, System.Object)
    
        
    
        
        :type viewContext: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        :type modelExplorer: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
    
        
        :type expression: System.String
    
        
        :type value: System.Object
    
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
            TagBuilder GeneratePassword(ViewContext viewContext, ModelExplorer modelExplorer, string expression, object value, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator.GenerateRadioButton(Microsoft.AspNetCore.Mvc.Rendering.ViewContext, Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer, System.String, System.Object, System.Nullable<System.Boolean>, System.Object)
    
        
    
        
        :type viewContext: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        :type modelExplorer: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
    
        
        :type expression: System.String
    
        
        :type value: System.Object
    
        
        :type isChecked: System.Nullable<System.Nullable`1>{System.Boolean<System.Boolean>}
    
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
            TagBuilder GenerateRadioButton(ViewContext viewContext, ModelExplorer modelExplorer, string expression, object value, bool ? isChecked, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator.GenerateRouteForm(Microsoft.AspNetCore.Mvc.Rendering.ViewContext, System.String, System.Object, System.String, System.Object)
    
        
    
        
        Generate a <form> element. The route with name <em>routeName</em> generates the
        <form>'s <code>action</code> attribute value.
    
        
    
        
        :param viewContext: A :any:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext` instance for the current scope.
        
        :type viewContext: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        :param routeName: The name of the route.
        
        :type routeName: System.String
    
        
        :param routeValues: 
            An :any:`System.Object` that contains the parameters for a route. The parameters are retrieved through
            reflection by examining the properties of the :any:`System.Object`\. This :any:`System.Object` is typically
            created using :any:`System.Object` initializer syntax. Alternatively, an
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the route parameters.
        
        :type routeValues: System.Object
    
        
        :param method: The HTTP method for processing the form, either GET or POST.
        
        :type method: System.String
    
        
        :param htmlAttributes: 
            An :any:`System.Object` that contains the HTML attributes for the element. Alternatively, an
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder
        :return: 
            A :any:`Microsoft.AspNetCore.Mvc.Rendering.TagBuilder` instance for the </form> element.
    
        
        .. code-block:: csharp
    
            TagBuilder GenerateRouteForm(ViewContext viewContext, string routeName, object routeValues, string method, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator.GenerateRouteLink(Microsoft.AspNetCore.Mvc.Rendering.ViewContext, System.String, System.String, System.String, System.String, System.String, System.Object, System.Object)
    
        
    
        
        Generate a <a> element for a link to an action.
    
        
    
        
        :param viewContext: The :any:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext` instance for the current scope.
        
        :type viewContext: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        :param linkText: The text to insert inside the element.
        
        :type linkText: System.String
    
        
        :param routeName: The name of the route to use for link generation.
        
        :type routeName: System.String
    
        
        :param protocol: The protocol (scheme) for the generated link.
        
        :type protocol: System.String
    
        
        :param hostName: The hostname for the generated link.
        
        :type hostName: System.String
    
        
        :param fragment: The fragment for the genrated link.
        
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
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder
        :return: 
            A :any:`Microsoft.AspNetCore.Mvc.Rendering.TagBuilder` instance for the <a> element.
    
        
        .. code-block:: csharp
    
            TagBuilder GenerateRouteLink(ViewContext viewContext, string linkText, string routeName, string protocol, string hostName, string fragment, object routeValues, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator.GenerateSelect(Microsoft.AspNetCore.Mvc.Rendering.ViewContext, Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer, System.String, System.String, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>, System.Boolean, System.Object)
    
        
    
        
        Generate a <select> element for the <em>expression</em>.
    
        
    
        
        :param viewContext: A :any:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext` instance for the current scope.
        
        :type viewContext: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        :param modelExplorer: 
            :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer` for the <em>expression</em>. If <code>null</code>, determines validation
            attributes using <em>viewContext</em> and the <em>expression</em>.
        
        :type modelExplorer: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
    
        
        :param optionLabel: Optional text for a default empty <option> element.
        
        :type optionLabel: System.String
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
    
        
        :param selectList: 
            A collection of :any:`Microsoft.AspNetCore.Mvc.Rendering.SelectListItem` objects used to populate the <select> element with
            <optgroup> and <option> elements. If <code>null</code>, finds this collection at
            <code>ViewContext.ViewData[expression]</code>.
        
        :type selectList: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.Rendering.SelectListItem<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>}
    
        
        :param allowMultiple: 
            If <code>true</code>, includes a <code>multiple</code> attribute in the generated HTML. Otherwise generates a
            single-selection <select> element.
        
        :type allowMultiple: System.Boolean
    
        
        :param htmlAttributes: 
            An :any:`System.Object` that contains the HTML attributes for the <select> element. Alternatively, an
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder
        :return: A new :any:`Microsoft.AspNetCore.Mvc.Rendering.TagBuilder` describing the <select> element.
    
        
        .. code-block:: csharp
    
            TagBuilder GenerateSelect(ViewContext viewContext, ModelExplorer modelExplorer, string optionLabel, string expression, IEnumerable<SelectListItem> selectList, bool allowMultiple, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator.GenerateSelect(Microsoft.AspNetCore.Mvc.Rendering.ViewContext, Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer, System.String, System.String, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>, System.Collections.Generic.ICollection<System.String>, System.Boolean, System.Object)
    
        
    
        
        Generate a <select> element for the <em>expression</em>.
    
        
    
        
        :param viewContext: A :any:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext` instance for the current scope.
        
        :type viewContext: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        :param modelExplorer: 
            :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer` for the <em>expression</em>. If <code>null</code>, determines validation
            attributes using <em>viewContext</em> and the <em>expression</em>.
        
        :type modelExplorer: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
    
        
        :param optionLabel: Optional text for a default empty <option> element.
        
        :type optionLabel: System.String
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
    
        
        :param selectList: 
            A collection of :any:`Microsoft.AspNetCore.Mvc.Rendering.SelectListItem` objects used to populate the <select> element with
            <optgroup> and <option> elements. If <code>null</code>, finds this collection at
            <code>ViewContext.ViewData[expression]</code>.
        
        :type selectList: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.Rendering.SelectListItem<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>}
    
        
        :param currentValues: 
            An :any:`System.Collections.Generic.ICollection\`1` containing values for <option> elements to select. If
            <code>null</code>, selects <option> elements based on :dn:prop:`Microsoft.AspNetCore.Mvc.Rendering.SelectListItem.Selected` values in
            <em>selectList</em>.
        
        :type currentValues: System.Collections.Generic.ICollection<System.Collections.Generic.ICollection`1>{System.String<System.String>}
    
        
        :param allowMultiple: 
            If <code>true</code>, includes a <code>multiple</code> attribute in the generated HTML. Otherwise generates a
            single-selection <select> element.
        
        :type allowMultiple: System.Boolean
    
        
        :param htmlAttributes: 
            An :any:`System.Object` that contains the HTML attributes for the <select> element. Alternatively, an
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder
        :return: A new :any:`Microsoft.AspNetCore.Mvc.Rendering.TagBuilder` describing the <select> element.
    
        
        .. code-block:: csharp
    
            TagBuilder GenerateSelect(ViewContext viewContext, ModelExplorer modelExplorer, string optionLabel, string expression, IEnumerable<SelectListItem> selectList, ICollection<string> currentValues, bool allowMultiple, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator.GenerateTextArea(Microsoft.AspNetCore.Mvc.Rendering.ViewContext, Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer, System.String, System.Int32, System.Int32, System.Object)
    
        
    
        
        :type viewContext: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        :type modelExplorer: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
    
        
        :type expression: System.String
    
        
        :type rows: System.Int32
    
        
        :type columns: System.Int32
    
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
            TagBuilder GenerateTextArea(ViewContext viewContext, ModelExplorer modelExplorer, string expression, int rows, int columns, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator.GenerateTextBox(Microsoft.AspNetCore.Mvc.Rendering.ViewContext, Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer, System.String, System.Object, System.String, System.Object)
    
        
    
        
        :type viewContext: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        :type modelExplorer: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
    
        
        :type expression: System.String
    
        
        :type value: System.Object
    
        
        :type format: System.String
    
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
            TagBuilder GenerateTextBox(ViewContext viewContext, ModelExplorer modelExplorer, string expression, object value, string format, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator.GenerateValidationMessage(Microsoft.AspNetCore.Mvc.Rendering.ViewContext, Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer, System.String, System.String, System.String, System.Object)
    
        
    
        
        Generate a <em>tag</em> element if the <em>viewContext</em>'s
        :dn:prop:`Microsoft.AspNetCore.Mvc.ActionContext.ModelState` contains an error for the <em>expression</em>.
    
        
    
        
        :param viewContext: A :any:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext` instance for the current scope.
        
        :type viewContext: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        :param modelExplorer: The :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer` for the <em>expression</em>.
        
        :type modelExplorer: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
    
        
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
    
        
        :param htmlAttributes: 
            An :any:`System.Object` that contains the HTML attributes for the element. Alternatively, an
            :any:`System.Collections.Generic.IDictionary\`2` instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder
        :return: 
            A :any:`Microsoft.AspNetCore.Mvc.Rendering.TagBuilder` containing a <em>tag</em> element if the
            <em>viewContext</em>'s :dn:prop:`Microsoft.AspNetCore.Mvc.ActionContext.ModelState` contains an error for the
            <em>expression</em> or (as a placeholder) if client-side validation is enabled. <code>null</code> if
            the <em>expression</em> is valid and client-side validation is disabled.
    
        
        .. code-block:: csharp
    
            TagBuilder GenerateValidationMessage(ViewContext viewContext, ModelExplorer modelExplorer, string expression, string message, string tag, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator.GenerateValidationSummary(Microsoft.AspNetCore.Mvc.Rendering.ViewContext, System.Boolean, System.String, System.String, System.Object)
    
        
    
        
        :type viewContext: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        :type excludePropertyErrors: System.Boolean
    
        
        :type message: System.String
    
        
        :type headerTag: System.String
    
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
            TagBuilder GenerateValidationSummary(ViewContext viewContext, bool excludePropertyErrors, string message, string headerTag, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator.GetCurrentValues(Microsoft.AspNetCore.Mvc.Rendering.ViewContext, Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer, System.String, System.Boolean)
    
        
    
        
        Gets the collection of current values for the given <em>expression</em>.
    
        
    
        
        :param viewContext: A :any:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext` instance for the current scope.
        
        :type viewContext: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        :param modelExplorer: 
            :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer` for the <em>expression</em>. If <code>null</code>, calculates the
            <em>expression</em> result using :dn:meth:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.Eval(System.String)`\.
        
        :type modelExplorer: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
    
        
        :param allowMultiple: 
            If <code>true</code>, require a collection <em>expression</em> result. Otherwise, treat result as a
            single value.
        
        :type allowMultiple: System.Boolean
        :rtype: System.Collections.Generic.ICollection<System.Collections.Generic.ICollection`1>{System.String<System.String>}
        :return: 
            <p>
            <code>null</code> if no <em>expression</em> result is found. Otherwise a
            :any:`System.Collections.Generic.ICollection\`1` containing current values for the given
            <em>expression</em>.
            </p>
            <p>
            Converts the <em>expression</em> result to a :any:`System.String`\. If that result is an
            :any:`System.Collections.IEnumerable` type, instead converts each item in the collection and returns
            them separately.
            </p>
            <p>
            If the <em>expression</em> result or the element type is an :any:`System.Enum`\, returns a
            :any:`System.String` containing the integer representation of the :any:`System.Enum` value as well
            as all :any:`System.Enum` names for that value. Otherwise returns the default :any:`System.String`
            conversion of the value.
            </p>
    
        
        .. code-block:: csharp
    
            ICollection<string> GetCurrentValues(ViewContext viewContext, ModelExplorer modelExplorer, string expression, bool allowMultiple)
    

