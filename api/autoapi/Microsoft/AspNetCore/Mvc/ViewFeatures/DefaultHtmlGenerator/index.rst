

DefaultHtmlGenerator Class
==========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewFeatures`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewFeatures.DefaultHtmlGenerator`








Syntax
------

.. code-block:: csharp

    public class DefaultHtmlGenerator : IHtmlGenerator








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.DefaultHtmlGenerator
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.DefaultHtmlGenerator

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.DefaultHtmlGenerator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewFeatures.DefaultHtmlGenerator.DefaultHtmlGenerator(Microsoft.AspNetCore.Antiforgery.IAntiforgery, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Mvc.MvcViewOptions>, Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider, Microsoft.AspNetCore.Mvc.Routing.IUrlHelperFactory, System.Text.Encodings.Web.HtmlEncoder, Microsoft.AspNetCore.Mvc.Internal.ClientValidatorCache)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.DefaultHtmlGenerator` class.
    
        
    
        
        :param antiforgery: The :any:`Microsoft.AspNetCore.Antiforgery.IAntiforgery` instance which is used to generate antiforgery
            tokens.
        
        :type antiforgery: Microsoft.AspNetCore.Antiforgery.IAntiforgery
    
        
        :param optionsAccessor: The accessor for :any:`Microsoft.AspNetCore.Mvc.MvcOptions`\.
        
        :type optionsAccessor: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Mvc.MvcViewOptions<Microsoft.AspNetCore.Mvc.MvcViewOptions>}
    
        
        :param metadataProvider: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider`\.
        
        :type metadataProvider: Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider
    
        
        :param urlHelperFactory: The :any:`Microsoft.AspNetCore.Mvc.Routing.IUrlHelperFactory`\.
        
        :type urlHelperFactory: Microsoft.AspNetCore.Mvc.Routing.IUrlHelperFactory
    
        
        :param htmlEncoder: The :any:`System.Text.Encodings.Web.HtmlEncoder`\.
        
        :type htmlEncoder: System.Text.Encodings.Web.HtmlEncoder
    
        
        :param clientValidatorCache: The :any:`Microsoft.AspNetCore.Mvc.Internal.ClientValidatorCache` that provides
            a list of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IClientModelValidator`\s.
        
        :type clientValidatorCache: Microsoft.AspNetCore.Mvc.Internal.ClientValidatorCache
    
        
        .. code-block:: csharp
    
            public DefaultHtmlGenerator(IAntiforgery antiforgery, IOptions<MvcViewOptions> optionsAccessor, IModelMetadataProvider metadataProvider, IUrlHelperFactory urlHelperFactory, HtmlEncoder htmlEncoder, ClientValidatorCache clientValidatorCache)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.DefaultHtmlGenerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.DefaultHtmlGenerator.AddValidationAttributes(Microsoft.AspNetCore.Mvc.Rendering.ViewContext, Microsoft.AspNetCore.Mvc.Rendering.TagBuilder, Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer, System.String)
    
        
    
        
        Adds validation attributes to the <em>tagBuilder</em> if client validation
        is enabled.
    
        
    
        
        :param viewContext: A :any:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext` instance for the current scope.
        
        :type viewContext: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        :param tagBuilder: A :any:`Microsoft.AspNetCore.Mvc.Rendering.TagBuilder` instance.
        
        :type tagBuilder: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder
    
        
        :param modelExplorer: The :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer` for the <em>expression</em>.
        
        :type modelExplorer: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
    
        
        .. code-block:: csharp
    
            protected virtual void AddValidationAttributes(ViewContext viewContext, TagBuilder tagBuilder, ModelExplorer modelExplorer, string expression)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.DefaultHtmlGenerator.Encode(System.Object)
    
        
    
        
        :type value: System.Object
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Encode(object value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.DefaultHtmlGenerator.Encode(System.String)
    
        
    
        
        :type value: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Encode(string value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.DefaultHtmlGenerator.FormatValue(System.Object, System.String)
    
        
    
        
        :type value: System.Object
    
        
        :type format: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string FormatValue(object value, string format)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.DefaultHtmlGenerator.GenerateActionLink(Microsoft.AspNetCore.Mvc.Rendering.ViewContext, System.String, System.String, System.String, System.String, System.String, System.String, System.Object, System.Object)
    
        
    
        
        :type viewContext: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        :type linkText: System.String
    
        
        :type actionName: System.String
    
        
        :type controllerName: System.String
    
        
        :type protocol: System.String
    
        
        :type hostname: System.String
    
        
        :type fragment: System.String
    
        
        :type routeValues: System.Object
    
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
            public virtual TagBuilder GenerateActionLink(ViewContext viewContext, string linkText, string actionName, string controllerName, string protocol, string hostname, string fragment, object routeValues, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.DefaultHtmlGenerator.GenerateAntiforgery(Microsoft.AspNetCore.Mvc.Rendering.ViewContext)
    
        
    
        
        :type viewContext: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
    
        
        .. code-block:: csharp
    
            public virtual IHtmlContent GenerateAntiforgery(ViewContext viewContext)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.DefaultHtmlGenerator.GenerateCheckBox(Microsoft.AspNetCore.Mvc.Rendering.ViewContext, Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer, System.String, System.Nullable<System.Boolean>, System.Object)
    
        
    
        
        :type viewContext: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        :type modelExplorer: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
    
        
        :type expression: System.String
    
        
        :type isChecked: System.Nullable<System.Nullable`1>{System.Boolean<System.Boolean>}
    
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
            public virtual TagBuilder GenerateCheckBox(ViewContext viewContext, ModelExplorer modelExplorer, string expression, bool ? isChecked, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.DefaultHtmlGenerator.GenerateForm(Microsoft.AspNetCore.Mvc.Rendering.ViewContext, System.String, System.String, System.Object, System.String, System.Object)
    
        
    
        
        :type viewContext: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        :type actionName: System.String
    
        
        :type controllerName: System.String
    
        
        :type routeValues: System.Object
    
        
        :type method: System.String
    
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
            public virtual TagBuilder GenerateForm(ViewContext viewContext, string actionName, string controllerName, object routeValues, string method, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.DefaultHtmlGenerator.GenerateFormCore(Microsoft.AspNetCore.Mvc.Rendering.ViewContext, System.String, System.String, System.Object)
    
        
    
        
        Generate a <form> element.
    
        
    
        
        :param viewContext: A :any:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext` instance for the current scope.
        
        :type viewContext: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        :param action: The URL where the form-data should be submitted.
        
        :type action: System.String
    
        
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
    
            protected virtual TagBuilder GenerateFormCore(ViewContext viewContext, string action, string method, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.DefaultHtmlGenerator.GenerateGroupsAndOptions(System.String, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>)
    
        
    
        
        :type optionLabel: System.String
    
        
        :type selectList: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.Rendering.SelectListItem<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>}
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
    
        
        .. code-block:: csharp
    
            public IHtmlContent GenerateGroupsAndOptions(string optionLabel, IEnumerable<SelectListItem> selectList)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.DefaultHtmlGenerator.GenerateHidden(Microsoft.AspNetCore.Mvc.Rendering.ViewContext, Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer, System.String, System.Object, System.Boolean, System.Object)
    
        
    
        
        :type viewContext: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        :type modelExplorer: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
    
        
        :type expression: System.String
    
        
        :type value: System.Object
    
        
        :type useViewData: System.Boolean
    
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
            public virtual TagBuilder GenerateHidden(ViewContext viewContext, ModelExplorer modelExplorer, string expression, object value, bool useViewData, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.DefaultHtmlGenerator.GenerateHiddenForCheckbox(Microsoft.AspNetCore.Mvc.Rendering.ViewContext, Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer, System.String)
    
        
    
        
        :type viewContext: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        :type modelExplorer: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
    
        
        :type expression: System.String
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
            public virtual TagBuilder GenerateHiddenForCheckbox(ViewContext viewContext, ModelExplorer modelExplorer, string expression)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.DefaultHtmlGenerator.GenerateInput(Microsoft.AspNetCore.Mvc.Rendering.ViewContext, Microsoft.AspNetCore.Mvc.ViewFeatures.InputType, Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer, System.String, System.Object, System.Boolean, System.Boolean, System.Boolean, System.Boolean, System.String, System.Collections.Generic.IDictionary<System.String, System.Object>)
    
        
    
        
        :type viewContext: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        :type inputType: Microsoft.AspNetCore.Mvc.ViewFeatures.InputType
    
        
        :type modelExplorer: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
    
        
        :type expression: System.String
    
        
        :type value: System.Object
    
        
        :type useViewData: System.Boolean
    
        
        :type isChecked: System.Boolean
    
        
        :type setId: System.Boolean
    
        
        :type isExplicitValue: System.Boolean
    
        
        :type format: System.String
    
        
        :type htmlAttributes: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
            protected virtual TagBuilder GenerateInput(ViewContext viewContext, InputType inputType, ModelExplorer modelExplorer, string expression, object value, bool useViewData, bool isChecked, bool setId, bool isExplicitValue, string format, IDictionary<string, object> htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.DefaultHtmlGenerator.GenerateLabel(Microsoft.AspNetCore.Mvc.Rendering.ViewContext, Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer, System.String, System.String, System.Object)
    
        
    
        
        :type viewContext: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        :type modelExplorer: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
    
        
        :type expression: System.String
    
        
        :type labelText: System.String
    
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
            public virtual TagBuilder GenerateLabel(ViewContext viewContext, ModelExplorer modelExplorer, string expression, string labelText, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.DefaultHtmlGenerator.GenerateLink(System.String, System.String, System.Object)
    
        
    
        
        :type linkText: System.String
    
        
        :type url: System.String
    
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
            protected virtual TagBuilder GenerateLink(string linkText, string url, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.DefaultHtmlGenerator.GeneratePassword(Microsoft.AspNetCore.Mvc.Rendering.ViewContext, Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer, System.String, System.Object, System.Object)
    
        
    
        
        :type viewContext: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        :type modelExplorer: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
    
        
        :type expression: System.String
    
        
        :type value: System.Object
    
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
            public virtual TagBuilder GeneratePassword(ViewContext viewContext, ModelExplorer modelExplorer, string expression, object value, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.DefaultHtmlGenerator.GenerateRadioButton(Microsoft.AspNetCore.Mvc.Rendering.ViewContext, Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer, System.String, System.Object, System.Nullable<System.Boolean>, System.Object)
    
        
    
        
        :type viewContext: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        :type modelExplorer: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
    
        
        :type expression: System.String
    
        
        :type value: System.Object
    
        
        :type isChecked: System.Nullable<System.Nullable`1>{System.Boolean<System.Boolean>}
    
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
            public virtual TagBuilder GenerateRadioButton(ViewContext viewContext, ModelExplorer modelExplorer, string expression, object value, bool ? isChecked, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.DefaultHtmlGenerator.GenerateRouteForm(Microsoft.AspNetCore.Mvc.Rendering.ViewContext, System.String, System.Object, System.String, System.Object)
    
        
    
        
        :type viewContext: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        :type routeName: System.String
    
        
        :type routeValues: System.Object
    
        
        :type method: System.String
    
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
            public TagBuilder GenerateRouteForm(ViewContext viewContext, string routeName, object routeValues, string method, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.DefaultHtmlGenerator.GenerateRouteLink(Microsoft.AspNetCore.Mvc.Rendering.ViewContext, System.String, System.String, System.String, System.String, System.String, System.Object, System.Object)
    
        
    
        
        :type viewContext: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        :type linkText: System.String
    
        
        :type routeName: System.String
    
        
        :type protocol: System.String
    
        
        :type hostName: System.String
    
        
        :type fragment: System.String
    
        
        :type routeValues: System.Object
    
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
            public virtual TagBuilder GenerateRouteLink(ViewContext viewContext, string linkText, string routeName, string protocol, string hostName, string fragment, object routeValues, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.DefaultHtmlGenerator.GenerateSelect(Microsoft.AspNetCore.Mvc.Rendering.ViewContext, Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer, System.String, System.String, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>, System.Boolean, System.Object)
    
        
    
        
        :type viewContext: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        :type modelExplorer: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
    
        
        :type optionLabel: System.String
    
        
        :type expression: System.String
    
        
        :type selectList: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.Rendering.SelectListItem<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>}
    
        
        :type allowMultiple: System.Boolean
    
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
            public TagBuilder GenerateSelect(ViewContext viewContext, ModelExplorer modelExplorer, string optionLabel, string expression, IEnumerable<SelectListItem> selectList, bool allowMultiple, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.DefaultHtmlGenerator.GenerateSelect(Microsoft.AspNetCore.Mvc.Rendering.ViewContext, Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer, System.String, System.String, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>, System.Collections.Generic.ICollection<System.String>, System.Boolean, System.Object)
    
        
    
        
        :type viewContext: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        :type modelExplorer: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
    
        
        :type optionLabel: System.String
    
        
        :type expression: System.String
    
        
        :type selectList: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.Rendering.SelectListItem<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>}
    
        
        :type currentValues: System.Collections.Generic.ICollection<System.Collections.Generic.ICollection`1>{System.String<System.String>}
    
        
        :type allowMultiple: System.Boolean
    
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
            public virtual TagBuilder GenerateSelect(ViewContext viewContext, ModelExplorer modelExplorer, string optionLabel, string expression, IEnumerable<SelectListItem> selectList, ICollection<string> currentValues, bool allowMultiple, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.DefaultHtmlGenerator.GenerateTextArea(Microsoft.AspNetCore.Mvc.Rendering.ViewContext, Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer, System.String, System.Int32, System.Int32, System.Object)
    
        
    
        
        :type viewContext: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        :type modelExplorer: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
    
        
        :type expression: System.String
    
        
        :type rows: System.Int32
    
        
        :type columns: System.Int32
    
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
            public virtual TagBuilder GenerateTextArea(ViewContext viewContext, ModelExplorer modelExplorer, string expression, int rows, int columns, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.DefaultHtmlGenerator.GenerateTextBox(Microsoft.AspNetCore.Mvc.Rendering.ViewContext, Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer, System.String, System.Object, System.String, System.Object)
    
        
    
        
        :type viewContext: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        :type modelExplorer: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
    
        
        :type expression: System.String
    
        
        :type value: System.Object
    
        
        :type format: System.String
    
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
            public virtual TagBuilder GenerateTextBox(ViewContext viewContext, ModelExplorer modelExplorer, string expression, object value, string format, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.DefaultHtmlGenerator.GenerateValidationMessage(Microsoft.AspNetCore.Mvc.Rendering.ViewContext, Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer, System.String, System.String, System.String, System.Object)
    
        
    
        
        :type viewContext: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        :type modelExplorer: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
    
        
        :type expression: System.String
    
        
        :type message: System.String
    
        
        :type tag: System.String
    
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
            public virtual TagBuilder GenerateValidationMessage(ViewContext viewContext, ModelExplorer modelExplorer, string expression, string message, string tag, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.DefaultHtmlGenerator.GenerateValidationSummary(Microsoft.AspNetCore.Mvc.Rendering.ViewContext, System.Boolean, System.String, System.String, System.Object)
    
        
    
        
        :type viewContext: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        :type excludePropertyErrors: System.Boolean
    
        
        :type message: System.String
    
        
        :type headerTag: System.String
    
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
            public virtual TagBuilder GenerateValidationSummary(ViewContext viewContext, bool excludePropertyErrors, string message, string headerTag, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.DefaultHtmlGenerator.GetCurrentValues(Microsoft.AspNetCore.Mvc.Rendering.ViewContext, Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer, System.String, System.Boolean)
    
        
    
        
        :type viewContext: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        :type modelExplorer: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
    
        
        :type expression: System.String
    
        
        :type allowMultiple: System.Boolean
        :rtype: System.Collections.Generic.ICollection<System.Collections.Generic.ICollection`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public virtual ICollection<string> GetCurrentValues(ViewContext viewContext, ModelExplorer modelExplorer, string expression, bool allowMultiple)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.DefaultHtmlGenerator
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.DefaultHtmlGenerator.IdAttributeDotReplacement
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string IdAttributeDotReplacement { get; }
    

