

DefaultHtmlGenerator Class
==========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewFeatures.DefaultHtmlGenerator`








Syntax
------

.. code-block:: csharp

   public class DefaultHtmlGenerator : IHtmlGenerator





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewFeatures/DefaultHtmlGenerator.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.DefaultHtmlGenerator

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.DefaultHtmlGenerator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ViewFeatures.DefaultHtmlGenerator.DefaultHtmlGenerator(Microsoft.AspNet.Antiforgery.IAntiforgery, Microsoft.Extensions.OptionsModel.IOptions<Microsoft.AspNet.Mvc.MvcViewOptions>, Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider, Microsoft.AspNet.Mvc.IUrlHelper, Microsoft.Extensions.WebEncoders.IHtmlEncoder)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.ViewFeatures.DefaultHtmlGenerator` class.
    
        
        
        
        :param antiforgery: The  instance which is used to generate antiforgery
            tokens.
        
        :type antiforgery: Microsoft.AspNet.Antiforgery.IAntiforgery
        
        
        :param optionsAccessor: The accessor for .
        
        :type optionsAccessor: Microsoft.Extensions.OptionsModel.IOptions{Microsoft.AspNet.Mvc.MvcViewOptions}
        
        
        :param metadataProvider: The .
        
        :type metadataProvider: Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider
        
        
        :param urlHelper: The .
        
        :type urlHelper: Microsoft.AspNet.Mvc.IUrlHelper
        
        
        :param htmlEncoder: The .
        
        :type htmlEncoder: Microsoft.Extensions.WebEncoders.IHtmlEncoder
    
        
        .. code-block:: csharp
    
           public DefaultHtmlGenerator(IAntiforgery antiforgery, IOptions<MvcViewOptions> optionsAccessor, IModelMetadataProvider metadataProvider, IUrlHelper urlHelper, IHtmlEncoder htmlEncoder)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.DefaultHtmlGenerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.DefaultHtmlGenerator.Encode(System.Object)
    
        
        
        
        :type value: System.Object
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Encode(object value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.DefaultHtmlGenerator.Encode(System.String)
    
        
        
        
        :type value: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Encode(string value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.DefaultHtmlGenerator.FormatValue(System.Object, System.String)
    
        
        
        
        :type value: System.Object
        
        
        :type format: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string FormatValue(object value, string format)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.DefaultHtmlGenerator.GenerateActionLink(System.String, System.String, System.String, System.String, System.String, System.String, System.Object, System.Object)
    
        
        
        
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
    
           public virtual TagBuilder GenerateActionLink(string linkText, string actionName, string controllerName, string protocol, string hostname, string fragment, object routeValues, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.DefaultHtmlGenerator.GenerateAntiforgery(Microsoft.AspNet.Mvc.Rendering.ViewContext)
    
        
        
        
        :type viewContext: Microsoft.AspNet.Mvc.Rendering.ViewContext
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           public virtual IHtmlContent GenerateAntiforgery(ViewContext viewContext)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.DefaultHtmlGenerator.GenerateCheckBox(Microsoft.AspNet.Mvc.Rendering.ViewContext, Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer, System.String, System.Nullable<System.Boolean>, System.Object)
    
        
        
        
        :type viewContext: Microsoft.AspNet.Mvc.Rendering.ViewContext
        
        
        :type modelExplorer: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        
        
        :type expression: System.String
        
        
        :type isChecked: System.Nullable{System.Boolean}
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
           public virtual TagBuilder GenerateCheckBox(ViewContext viewContext, ModelExplorer modelExplorer, string expression, bool ? isChecked, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.DefaultHtmlGenerator.GenerateForm(Microsoft.AspNet.Mvc.Rendering.ViewContext, System.String, System.String, System.Object, System.String, System.Object)
    
        
        
        
        :type viewContext: Microsoft.AspNet.Mvc.Rendering.ViewContext
        
        
        :type actionName: System.String
        
        
        :type controllerName: System.String
        
        
        :type routeValues: System.Object
        
        
        :type method: System.String
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
           public virtual TagBuilder GenerateForm(ViewContext viewContext, string actionName, string controllerName, object routeValues, string method, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.DefaultHtmlGenerator.GenerateFormCore(Microsoft.AspNet.Mvc.Rendering.ViewContext, System.String, System.String, System.Object)
    
        
    
        Generate a &lt;form&gt; element.
    
        
        
        
        :param viewContext: A  instance for the current scope.
        
        :type viewContext: Microsoft.AspNet.Mvc.Rendering.ViewContext
        
        
        :param action: The URL where the form-data should be submitted.
        
        :type action: System.String
        
        
        :param method: The HTTP method for processing the form, either GET or POST.
        
        :type method: System.String
        
        
        :param htmlAttributes: An  that contains the HTML attributes for the element. Alternatively, an
            instance containing the HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Mvc.Rendering.TagBuilder
        :return: A <see cref="T:Microsoft.AspNet.Mvc.Rendering.TagBuilder" /> instance for the &lt;/form&gt; element.
    
        
        .. code-block:: csharp
    
           protected virtual TagBuilder GenerateFormCore(ViewContext viewContext, string action, string method, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.DefaultHtmlGenerator.GenerateHidden(Microsoft.AspNet.Mvc.Rendering.ViewContext, Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer, System.String, System.Object, System.Boolean, System.Object)
    
        
        
        
        :type viewContext: Microsoft.AspNet.Mvc.Rendering.ViewContext
        
        
        :type modelExplorer: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        
        
        :type expression: System.String
        
        
        :type value: System.Object
        
        
        :type useViewData: System.Boolean
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
           public virtual TagBuilder GenerateHidden(ViewContext viewContext, ModelExplorer modelExplorer, string expression, object value, bool useViewData, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.DefaultHtmlGenerator.GenerateHiddenForCheckbox(Microsoft.AspNet.Mvc.Rendering.ViewContext, Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer, System.String)
    
        
        
        
        :type viewContext: Microsoft.AspNet.Mvc.Rendering.ViewContext
        
        
        :type modelExplorer: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        
        
        :type expression: System.String
        :rtype: Microsoft.AspNet.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
           public virtual TagBuilder GenerateHiddenForCheckbox(ViewContext viewContext, ModelExplorer modelExplorer, string expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.DefaultHtmlGenerator.GenerateInput(Microsoft.AspNet.Mvc.Rendering.ViewContext, Microsoft.AspNet.Mvc.ViewFeatures.InputType, Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer, System.String, System.Object, System.Boolean, System.Boolean, System.Boolean, System.Boolean, System.String, System.Collections.Generic.IDictionary<System.String, System.Object>)
    
        
        
        
        :type viewContext: Microsoft.AspNet.Mvc.Rendering.ViewContext
        
        
        :type inputType: Microsoft.AspNet.Mvc.ViewFeatures.InputType
        
        
        :type modelExplorer: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        
        
        :type expression: System.String
        
        
        :type value: System.Object
        
        
        :type useViewData: System.Boolean
        
        
        :type isChecked: System.Boolean
        
        
        :type setId: System.Boolean
        
        
        :type isExplicitValue: System.Boolean
        
        
        :type format: System.String
        
        
        :type htmlAttributes: System.Collections.Generic.IDictionary{System.String,System.Object}
        :rtype: Microsoft.AspNet.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
           protected virtual TagBuilder GenerateInput(ViewContext viewContext, InputType inputType, ModelExplorer modelExplorer, string expression, object value, bool useViewData, bool isChecked, bool setId, bool isExplicitValue, string format, IDictionary<string, object> htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.DefaultHtmlGenerator.GenerateLabel(Microsoft.AspNet.Mvc.Rendering.ViewContext, Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer, System.String, System.String, System.Object)
    
        
        
        
        :type viewContext: Microsoft.AspNet.Mvc.Rendering.ViewContext
        
        
        :type modelExplorer: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        
        
        :type expression: System.String
        
        
        :type labelText: System.String
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
           public virtual TagBuilder GenerateLabel(ViewContext viewContext, ModelExplorer modelExplorer, string expression, string labelText, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.DefaultHtmlGenerator.GenerateLink(System.String, System.String, System.Object)
    
        
        
        
        :type linkText: System.String
        
        
        :type url: System.String
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
           protected virtual TagBuilder GenerateLink(string linkText, string url, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.DefaultHtmlGenerator.GeneratePassword(Microsoft.AspNet.Mvc.Rendering.ViewContext, Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer, System.String, System.Object, System.Object)
    
        
        
        
        :type viewContext: Microsoft.AspNet.Mvc.Rendering.ViewContext
        
        
        :type modelExplorer: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        
        
        :type expression: System.String
        
        
        :type value: System.Object
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
           public virtual TagBuilder GeneratePassword(ViewContext viewContext, ModelExplorer modelExplorer, string expression, object value, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.DefaultHtmlGenerator.GenerateRadioButton(Microsoft.AspNet.Mvc.Rendering.ViewContext, Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer, System.String, System.Object, System.Nullable<System.Boolean>, System.Object)
    
        
        
        
        :type viewContext: Microsoft.AspNet.Mvc.Rendering.ViewContext
        
        
        :type modelExplorer: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        
        
        :type expression: System.String
        
        
        :type value: System.Object
        
        
        :type isChecked: System.Nullable{System.Boolean}
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
           public virtual TagBuilder GenerateRadioButton(ViewContext viewContext, ModelExplorer modelExplorer, string expression, object value, bool ? isChecked, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.DefaultHtmlGenerator.GenerateRouteForm(Microsoft.AspNet.Mvc.Rendering.ViewContext, System.String, System.Object, System.String, System.Object)
    
        
        
        
        :type viewContext: Microsoft.AspNet.Mvc.Rendering.ViewContext
        
        
        :type routeName: System.String
        
        
        :type routeValues: System.Object
        
        
        :type method: System.String
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
           public TagBuilder GenerateRouteForm(ViewContext viewContext, string routeName, object routeValues, string method, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.DefaultHtmlGenerator.GenerateRouteLink(System.String, System.String, System.String, System.String, System.String, System.Object, System.Object)
    
        
        
        
        :type linkText: System.String
        
        
        :type routeName: System.String
        
        
        :type protocol: System.String
        
        
        :type hostName: System.String
        
        
        :type fragment: System.String
        
        
        :type routeValues: System.Object
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
           public virtual TagBuilder GenerateRouteLink(string linkText, string routeName, string protocol, string hostName, string fragment, object routeValues, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.DefaultHtmlGenerator.GenerateSelect(Microsoft.AspNet.Mvc.Rendering.ViewContext, Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer, System.String, System.String, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.Rendering.SelectListItem>, System.Boolean, System.Object)
    
        
        
        
        :type viewContext: Microsoft.AspNet.Mvc.Rendering.ViewContext
        
        
        :type modelExplorer: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        
        
        :type optionLabel: System.String
        
        
        :type expression: System.String
        
        
        :type selectList: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.Rendering.SelectListItem}
        
        
        :type allowMultiple: System.Boolean
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
           public TagBuilder GenerateSelect(ViewContext viewContext, ModelExplorer modelExplorer, string optionLabel, string expression, IEnumerable<SelectListItem> selectList, bool allowMultiple, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.DefaultHtmlGenerator.GenerateSelect(Microsoft.AspNet.Mvc.Rendering.ViewContext, Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer, System.String, System.String, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.Rendering.SelectListItem>, System.Collections.Generic.IReadOnlyCollection<System.String>, System.Boolean, System.Object)
    
        
        
        
        :type viewContext: Microsoft.AspNet.Mvc.Rendering.ViewContext
        
        
        :type modelExplorer: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        
        
        :type optionLabel: System.String
        
        
        :type expression: System.String
        
        
        :type selectList: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.Rendering.SelectListItem}
        
        
        :type currentValues: System.Collections.Generic.IReadOnlyCollection{System.String}
        
        
        :type allowMultiple: System.Boolean
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
           public virtual TagBuilder GenerateSelect(ViewContext viewContext, ModelExplorer modelExplorer, string optionLabel, string expression, IEnumerable<SelectListItem> selectList, IReadOnlyCollection<string> currentValues, bool allowMultiple, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.DefaultHtmlGenerator.GenerateTextArea(Microsoft.AspNet.Mvc.Rendering.ViewContext, Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer, System.String, System.Int32, System.Int32, System.Object)
    
        
        
        
        :type viewContext: Microsoft.AspNet.Mvc.Rendering.ViewContext
        
        
        :type modelExplorer: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        
        
        :type expression: System.String
        
        
        :type rows: System.Int32
        
        
        :type columns: System.Int32
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
           public virtual TagBuilder GenerateTextArea(ViewContext viewContext, ModelExplorer modelExplorer, string expression, int rows, int columns, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.DefaultHtmlGenerator.GenerateTextBox(Microsoft.AspNet.Mvc.Rendering.ViewContext, Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer, System.String, System.Object, System.String, System.Object)
    
        
        
        
        :type viewContext: Microsoft.AspNet.Mvc.Rendering.ViewContext
        
        
        :type modelExplorer: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        
        
        :type expression: System.String
        
        
        :type value: System.Object
        
        
        :type format: System.String
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
           public virtual TagBuilder GenerateTextBox(ViewContext viewContext, ModelExplorer modelExplorer, string expression, object value, string format, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.DefaultHtmlGenerator.GenerateValidationMessage(Microsoft.AspNet.Mvc.Rendering.ViewContext, System.String, System.String, System.String, System.Object)
    
        
        
        
        :type viewContext: Microsoft.AspNet.Mvc.Rendering.ViewContext
        
        
        :type expression: System.String
        
        
        :type message: System.String
        
        
        :type tag: System.String
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
           public virtual TagBuilder GenerateValidationMessage(ViewContext viewContext, string expression, string message, string tag, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.DefaultHtmlGenerator.GenerateValidationSummary(Microsoft.AspNet.Mvc.Rendering.ViewContext, System.Boolean, System.String, System.String, System.Object)
    
        
        
        
        :type viewContext: Microsoft.AspNet.Mvc.Rendering.ViewContext
        
        
        :type excludePropertyErrors: System.Boolean
        
        
        :type message: System.String
        
        
        :type headerTag: System.String
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
           public virtual TagBuilder GenerateValidationSummary(ViewContext viewContext, bool excludePropertyErrors, string message, string headerTag, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.DefaultHtmlGenerator.GetClientValidationRules(Microsoft.AspNet.Mvc.Rendering.ViewContext, Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer, System.String)
    
        
        
        
        :type viewContext: Microsoft.AspNet.Mvc.Rendering.ViewContext
        
        
        :type modelExplorer: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        
        
        :type expression: System.String
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelClientValidationRule}
    
        
        .. code-block:: csharp
    
           public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ViewContext viewContext, ModelExplorer modelExplorer, string expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.DefaultHtmlGenerator.GetCurrentValues(Microsoft.AspNet.Mvc.Rendering.ViewContext, Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer, System.String, System.Boolean)
    
        
        
        
        :type viewContext: Microsoft.AspNet.Mvc.Rendering.ViewContext
        
        
        :type modelExplorer: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        
        
        :type expression: System.String
        
        
        :type allowMultiple: System.Boolean
        :rtype: System.Collections.Generic.IReadOnlyCollection{System.String}
    
        
        .. code-block:: csharp
    
           public virtual IReadOnlyCollection<string> GetCurrentValues(ViewContext viewContext, ModelExplorer modelExplorer, string expression, bool allowMultiple)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.DefaultHtmlGenerator.GetValidationAttributes(Microsoft.AspNet.Mvc.Rendering.ViewContext, Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer, System.String)
    
        
        
        
        :type viewContext: Microsoft.AspNet.Mvc.Rendering.ViewContext
        
        
        :type modelExplorer: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        
        
        :type expression: System.String
        :rtype: System.Collections.Generic.IDictionary{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           protected virtual IDictionary<string, object> GetValidationAttributes(ViewContext viewContext, ModelExplorer modelExplorer, string expression)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.DefaultHtmlGenerator
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.DefaultHtmlGenerator.IdAttributeDotReplacement
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string IdAttributeDotReplacement { get; }
    

