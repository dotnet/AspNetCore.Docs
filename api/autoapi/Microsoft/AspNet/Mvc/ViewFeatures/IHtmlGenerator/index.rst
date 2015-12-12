

IHtmlGenerator Interface
========================



.. contents:: 
   :local:



Summary
-------

Contract for a service supporting :any:`Microsoft.AspNet.Mvc.Rendering.IHtmlHelper` and <c>ITagHelper</c> implementations.











Syntax
------

.. code-block:: csharp

   public interface IHtmlGenerator





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewFeatures/IHtmlGenerator.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.ViewFeatures.IHtmlGenerator

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.ViewFeatures.IHtmlGenerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.IHtmlGenerator.Encode(System.Object)
    
        
        
        
        :type value: System.Object
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string Encode(object value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.IHtmlGenerator.Encode(System.String)
    
        
        
        
        :type value: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string Encode(string value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.IHtmlGenerator.FormatValue(System.Object, System.String)
    
        
        
        
        :type value: System.Object
        
        
        :type format: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string FormatValue(object value, string format)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.IHtmlGenerator.GenerateActionLink(System.String, System.String, System.String, System.String, System.String, System.String, System.Object, System.Object)
    
        
        
        
        :type linkText: System.String
        
        
        :type actionName: System.String
        
        
        :type controllerName: System.String
        
        
        :type protocol: System.String
        
        
        :type hostname: System.String
        
        
        :type fragment: System.String
        
        
        :type routeValues: System.Object
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
           TagBuilder GenerateActionLink(string linkText, string actionName, string controllerName, string protocol, string hostname, string fragment, object routeValues, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.IHtmlGenerator.GenerateAntiforgery(Microsoft.AspNet.Mvc.Rendering.ViewContext)
    
        
    
        Genrate an &lt;input type="hidden".../&gt; element containing an antiforgery token.
    
        
        
        
        :param viewContext: The  instance for the current scope.
        
        :type viewContext: Microsoft.AspNet.Mvc.Rendering.ViewContext
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: An <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> instance for the &lt;input type="hidden".../&gt; element.
    
        
        .. code-block:: csharp
    
           IHtmlContent GenerateAntiforgery(ViewContext viewContext)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.IHtmlGenerator.GenerateCheckBox(Microsoft.AspNet.Mvc.Rendering.ViewContext, Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer, System.String, System.Nullable<System.Boolean>, System.Object)
    
        
    
        Generate a &lt;input type="checkbox".../&gt; element.
    
        
        
        
        :param viewContext: The  instance for the current scope.
        
        :type viewContext: Microsoft.AspNet.Mvc.Rendering.ViewContext
        
        
        :param modelExplorer: The  for the model.
        
        :type modelExplorer: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        
        
        :param expression: The model expression.
        
        :type expression: System.String
        
        
        :param isChecked: The initial state of the checkbox element.
        
        :type isChecked: System.Nullable{System.Boolean}
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the element. Alternatively, an
            instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Mvc.Rendering.TagBuilder
        :return: A <see cref="T:Microsoft.AspNet.Mvc.Rendering.TagBuilder" /> instance for the &lt;input type="checkbox".../&gt; element.
    
        
        .. code-block:: csharp
    
           TagBuilder GenerateCheckBox(ViewContext viewContext, ModelExplorer modelExplorer, string expression, bool ? isChecked, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.IHtmlGenerator.GenerateForm(Microsoft.AspNet.Mvc.Rendering.ViewContext, System.String, System.String, System.Object, System.String, System.Object)
    
        
    
        Generate a &lt;form&gt; element. When the user submits the form, the action with name
        ``actionName`` will process the request.
    
        
        
        
        :param viewContext: A  instance for the current scope.
        
        :type viewContext: Microsoft.AspNet.Mvc.Rendering.ViewContext
        
        
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
        
        :type method: System.String
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the element. Alternatively, an
            instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Mvc.Rendering.TagBuilder
        :return: A <see cref="T:Microsoft.AspNet.Mvc.Rendering.TagBuilder" /> instance for the &lt;/form&gt; element.
    
        
        .. code-block:: csharp
    
           TagBuilder GenerateForm(ViewContext viewContext, string actionName, string controllerName, object routeValues, string method, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.IHtmlGenerator.GenerateHidden(Microsoft.AspNet.Mvc.Rendering.ViewContext, Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer, System.String, System.Object, System.Boolean, System.Object)
    
        
        
        
        :type viewContext: Microsoft.AspNet.Mvc.Rendering.ViewContext
        
        
        :type modelExplorer: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        
        
        :type expression: System.String
        
        
        :type value: System.Object
        
        
        :type useViewData: System.Boolean
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
           TagBuilder GenerateHidden(ViewContext viewContext, ModelExplorer modelExplorer, string expression, object value, bool useViewData, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.IHtmlGenerator.GenerateHiddenForCheckbox(Microsoft.AspNet.Mvc.Rendering.ViewContext, Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer, System.String)
    
        
    
        Generate an additional &lt;input type="hidden".../&gt; for checkboxes. This addresses scenarios where
        unchecked checkboxes are not sent in the request. Sending a hidden input makes it possible to know that the
        checkbox was present on the page when the request was submitted.
    
        
        
        
        :type viewContext: Microsoft.AspNet.Mvc.Rendering.ViewContext
        
        
        :type modelExplorer: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        
        
        :type expression: System.String
        :rtype: Microsoft.AspNet.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
           TagBuilder GenerateHiddenForCheckbox(ViewContext viewContext, ModelExplorer modelExplorer, string expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.IHtmlGenerator.GenerateLabel(Microsoft.AspNet.Mvc.Rendering.ViewContext, Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer, System.String, System.String, System.Object)
    
        
        
        
        :type viewContext: Microsoft.AspNet.Mvc.Rendering.ViewContext
        
        
        :type modelExplorer: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        
        
        :type expression: System.String
        
        
        :type labelText: System.String
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
           TagBuilder GenerateLabel(ViewContext viewContext, ModelExplorer modelExplorer, string expression, string labelText, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.IHtmlGenerator.GeneratePassword(Microsoft.AspNet.Mvc.Rendering.ViewContext, Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer, System.String, System.Object, System.Object)
    
        
        
        
        :type viewContext: Microsoft.AspNet.Mvc.Rendering.ViewContext
        
        
        :type modelExplorer: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        
        
        :type expression: System.String
        
        
        :type value: System.Object
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
           TagBuilder GeneratePassword(ViewContext viewContext, ModelExplorer modelExplorer, string expression, object value, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.IHtmlGenerator.GenerateRadioButton(Microsoft.AspNet.Mvc.Rendering.ViewContext, Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer, System.String, System.Object, System.Nullable<System.Boolean>, System.Object)
    
        
        
        
        :type viewContext: Microsoft.AspNet.Mvc.Rendering.ViewContext
        
        
        :type modelExplorer: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        
        
        :type expression: System.String
        
        
        :type value: System.Object
        
        
        :type isChecked: System.Nullable{System.Boolean}
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
           TagBuilder GenerateRadioButton(ViewContext viewContext, ModelExplorer modelExplorer, string expression, object value, bool ? isChecked, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.IHtmlGenerator.GenerateRouteForm(Microsoft.AspNet.Mvc.Rendering.ViewContext, System.String, System.Object, System.String, System.Object)
    
        
    
        Generate a &lt;form&gt; element. The route with name ``routeName`` generates the
        &lt;form&gt;'s <c>action</c> attribute value.
    
        
        
        
        :param viewContext: A  instance for the current scope.
        
        :type viewContext: Microsoft.AspNet.Mvc.Rendering.ViewContext
        
        
        :param routeName: The name of the route.
        
        :type routeName: System.String
        
        
        :param routeValues: An  that contains the parameters for a route. The parameters are retrieved through
            reflection by examining the properties of the . This  is typically
            created using  initializer syntax. Alternatively, an
            instance containing the route parameters.
        
        :type routeValues: System.Object
        
        
        :param method: The HTTP method for processing the form, either GET or POST.
        
        :type method: System.String
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the element. Alternatively, an
            instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Mvc.Rendering.TagBuilder
        :return: A <see cref="T:Microsoft.AspNet.Mvc.Rendering.TagBuilder" /> instance for the &lt;/form&gt; element.
    
        
        .. code-block:: csharp
    
           TagBuilder GenerateRouteForm(ViewContext viewContext, string routeName, object routeValues, string method, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.IHtmlGenerator.GenerateRouteLink(System.String, System.String, System.String, System.String, System.String, System.Object, System.Object)
    
        
        
        
        :type linkText: System.String
        
        
        :type routeName: System.String
        
        
        :type protocol: System.String
        
        
        :type hostName: System.String
        
        
        :type fragment: System.String
        
        
        :type routeValues: System.Object
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
           TagBuilder GenerateRouteLink(string linkText, string routeName, string protocol, string hostName, string fragment, object routeValues, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.IHtmlGenerator.GenerateSelect(Microsoft.AspNet.Mvc.Rendering.ViewContext, Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer, System.String, System.String, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.Rendering.SelectListItem>, System.Boolean, System.Object)
    
        
    
        Generate a &lt;select&gt; element for the ``expression``.
    
        
        
        
        :param viewContext: A  instance for the current scope.
        
        :type viewContext: Microsoft.AspNet.Mvc.Rendering.ViewContext
        
        
        :param modelExplorer: for the . If null, determines validation
            attributes using  and the .
        
        :type modelExplorer: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        
        
        :param optionLabel: Optional text for a default empty <option> element.
        
        :type optionLabel: System.String
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        
        
        :param selectList: A collection of  objects used to populate the <select> element with
            <optgroup> and <option> elements. If null, finds this collection at
            ViewContext.ViewData[expression].
        
        :type selectList: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.Rendering.SelectListItem}
        
        
        :param allowMultiple: If true, includes a multiple attribute in the generated HTML. Otherwise generates a
            single-selection <select> element.
        
        :type allowMultiple: System.Boolean
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the <select> element. Alternatively, an
            instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Mvc.Rendering.TagBuilder
        :return: A new <see cref="T:Microsoft.AspNet.Mvc.Rendering.TagBuilder" /> describing the &lt;select&gt; element.
    
        
        .. code-block:: csharp
    
           TagBuilder GenerateSelect(ViewContext viewContext, ModelExplorer modelExplorer, string optionLabel, string expression, IEnumerable<SelectListItem> selectList, bool allowMultiple, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.IHtmlGenerator.GenerateSelect(Microsoft.AspNet.Mvc.Rendering.ViewContext, Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer, System.String, System.String, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.Rendering.SelectListItem>, System.Collections.Generic.IReadOnlyCollection<System.String>, System.Boolean, System.Object)
    
        
    
        Generate a &lt;select&gt; element for the ``expression``.
    
        
        
        
        :param viewContext: A  instance for the current scope.
        
        :type viewContext: Microsoft.AspNet.Mvc.Rendering.ViewContext
        
        
        :param modelExplorer: for the . If null, determines validation
            attributes using  and the .
        
        :type modelExplorer: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        
        
        :param optionLabel: Optional text for a default empty <option> element.
        
        :type optionLabel: System.String
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        
        
        :param selectList: A collection of  objects used to populate the <select> element with
            <optgroup> and <option> elements. If null, finds this collection at
            ViewContext.ViewData[expression].
        
        :type selectList: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.Rendering.SelectListItem}
        
        
        :param currentValues: An  containing values for <option> elements to select. If
            null, selects <option> elements based on  values in
            .
        
        :type currentValues: System.Collections.Generic.IReadOnlyCollection{System.String}
        
        
        :param allowMultiple: If true, includes a multiple attribute in the generated HTML. Otherwise generates a
            single-selection <select> element.
        
        :type allowMultiple: System.Boolean
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the <select> element. Alternatively, an
            instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Mvc.Rendering.TagBuilder
        :return: A new <see cref="T:Microsoft.AspNet.Mvc.Rendering.TagBuilder" /> describing the &lt;select&gt; element.
    
        
        .. code-block:: csharp
    
           TagBuilder GenerateSelect(ViewContext viewContext, ModelExplorer modelExplorer, string optionLabel, string expression, IEnumerable<SelectListItem> selectList, IReadOnlyCollection<string> currentValues, bool allowMultiple, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.IHtmlGenerator.GenerateTextArea(Microsoft.AspNet.Mvc.Rendering.ViewContext, Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer, System.String, System.Int32, System.Int32, System.Object)
    
        
        
        
        :type viewContext: Microsoft.AspNet.Mvc.Rendering.ViewContext
        
        
        :type modelExplorer: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        
        
        :type expression: System.String
        
        
        :type rows: System.Int32
        
        
        :type columns: System.Int32
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
           TagBuilder GenerateTextArea(ViewContext viewContext, ModelExplorer modelExplorer, string expression, int rows, int columns, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.IHtmlGenerator.GenerateTextBox(Microsoft.AspNet.Mvc.Rendering.ViewContext, Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer, System.String, System.Object, System.String, System.Object)
    
        
        
        
        :type viewContext: Microsoft.AspNet.Mvc.Rendering.ViewContext
        
        
        :type modelExplorer: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        
        
        :type expression: System.String
        
        
        :type value: System.Object
        
        
        :type format: System.String
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
           TagBuilder GenerateTextBox(ViewContext viewContext, ModelExplorer modelExplorer, string expression, object value, string format, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.IHtmlGenerator.GenerateValidationMessage(Microsoft.AspNet.Mvc.Rendering.ViewContext, System.String, System.String, System.String, System.Object)
    
        
        
        
        :type viewContext: Microsoft.AspNet.Mvc.Rendering.ViewContext
        
        
        :type expression: System.String
        
        
        :type message: System.String
        
        
        :type tag: System.String
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
           TagBuilder GenerateValidationMessage(ViewContext viewContext, string expression, string message, string tag, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.IHtmlGenerator.GenerateValidationSummary(Microsoft.AspNet.Mvc.Rendering.ViewContext, System.Boolean, System.String, System.String, System.Object)
    
        
        
        
        :type viewContext: Microsoft.AspNet.Mvc.Rendering.ViewContext
        
        
        :type excludePropertyErrors: System.Boolean
        
        
        :type message: System.String
        
        
        :type headerTag: System.String
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
           TagBuilder GenerateValidationSummary(ViewContext viewContext, bool excludePropertyErrors, string message, string headerTag, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.IHtmlGenerator.GetClientValidationRules(Microsoft.AspNet.Mvc.Rendering.ViewContext, Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer, System.String)
    
        
        
        
        :type viewContext: Microsoft.AspNet.Mvc.Rendering.ViewContext
        
        
        :type modelExplorer: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        
        
        :type expression: System.String
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelClientValidationRule}
    
        
        .. code-block:: csharp
    
           IEnumerable<ModelClientValidationRule> GetClientValidationRules(ViewContext viewContext, ModelExplorer modelExplorer, string expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.IHtmlGenerator.GetCurrentValues(Microsoft.AspNet.Mvc.Rendering.ViewContext, Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer, System.String, System.Boolean)
    
        
    
        Gets the collection of current values for the given ``expression``.
    
        
        
        
        :param viewContext: A  instance for the current scope.
        
        :type viewContext: Microsoft.AspNet.Mvc.Rendering.ViewContext
        
        
        :param modelExplorer: for the . If null, calculates the
            result using .
        
        :type modelExplorer: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        
        
        :param allowMultiple: If true, require a collection  result. Otherwise, treat result as a
            single value.
        
        :type allowMultiple: System.Boolean
        :rtype: System.Collections.Generic.IReadOnlyCollection{System.String}
        :return: <para>
            <c>null</c> if no <paramref name="expression" /> result is found. Otherwise an
            <see cref="T:System.Collections.Generic.IReadOnlyCollection`1" /> containing current values for the given
            <paramref name="expression" />.
            </para>
            <para>
            Converts the <paramref name="expression" /> result to a <see cref="T:System.String" />. If that result is an
            <see cref="T:System.Collections.IEnumerable" /> type, instead converts each item in the collection and returns
            them separately.
            </para>
            <para>
            If the <paramref name="expression" /> result or the element type is an <see cref="T:System.Enum" />, returns a
            <see cref="T:System.String" /> containing the integer representation of the <see cref="T:System.Enum" /> value as well
            as all <see cref="T:System.Enum" /> names for that value. Otherwise returns the default <see cref="T:System.String" />
            conversion of the value.
            </para>
    
        
        .. code-block:: csharp
    
           IReadOnlyCollection<string> GetCurrentValues(ViewContext viewContext, ModelExplorer modelExplorer, string expression, bool allowMultiple)
    

Properties
----------

.. dn:interface:: Microsoft.AspNet.Mvc.ViewFeatures.IHtmlGenerator
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.IHtmlGenerator.IdAttributeDotReplacement
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string IdAttributeDotReplacement { get; }
    

