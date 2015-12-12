

HtmlHelper Class
================



.. contents:: 
   :local:



Summary
-------

Default implementation of :any:`Microsoft.AspNet.Mvc.Rendering.IHtmlHelper`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper`








Syntax
------

.. code-block:: csharp

   public class HtmlHelper : IHtmlHelper, ICanHasViewContext





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewFeatures/HtmlHelper.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.HtmlHelper(Microsoft.AspNet.Mvc.ViewFeatures.IHtmlGenerator, Microsoft.AspNet.Mvc.ViewEngines.ICompositeViewEngine, Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider, Microsoft.Extensions.WebEncoders.IHtmlEncoder, Microsoft.Extensions.WebEncoders.IUrlEncoder, Microsoft.Extensions.WebEncoders.IJavaScriptStringEncoder)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper` class.
    
        
        
        
        :type htmlGenerator: Microsoft.AspNet.Mvc.ViewFeatures.IHtmlGenerator
        
        
        :type viewEngine: Microsoft.AspNet.Mvc.ViewEngines.ICompositeViewEngine
        
        
        :type metadataProvider: Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider
        
        
        :type htmlEncoder: Microsoft.Extensions.WebEncoders.IHtmlEncoder
        
        
        :type urlEncoder: Microsoft.Extensions.WebEncoders.IUrlEncoder
        
        
        :type javaScriptStringEncoder: Microsoft.Extensions.WebEncoders.IJavaScriptStringEncoder
    
        
        .. code-block:: csharp
    
           public HtmlHelper(IHtmlGenerator htmlGenerator, ICompositeViewEngine viewEngine, IModelMetadataProvider metadataProvider, IHtmlEncoder htmlEncoder, IUrlEncoder urlEncoder, IJavaScriptStringEncoder javaScriptStringEncoder)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.ActionLink(System.String, System.String, System.String, System.String, System.String, System.String, System.Object, System.Object)
    
        
        
        
        :type linkText: System.String
        
        
        :type actionName: System.String
        
        
        :type controllerName: System.String
        
        
        :type protocol: System.String
        
        
        :type hostname: System.String
        
        
        :type fragment: System.String
        
        
        :type routeValues: System.Object
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           public IHtmlContent ActionLink(string linkText, string actionName, string controllerName, string protocol, string hostname, string fragment, object routeValues, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.AnonymousObjectToHtmlAttributes(System.Object)
    
        
    
        Creates a dictionary of HTML attributes from the input object,
        translating underscores to dashes in each public instance property.
        
        
        If the object is already an :any:`System.Collections.Generic.IDictionary\`2` instance, then it is
        returned as-is.
        <example><c>new { data_name="value" }</c> will translate to the entry <c>{ "data-name", "value" }</c>
        in the resulting dictionary.
        </example>
    
        
        
        
        :param htmlAttributes: Anonymous object describing HTML attributes.
        
        :type htmlAttributes: System.Object
        :rtype: System.Collections.Generic.IDictionary{System.String,System.Object}
        :return: A dictionary that represents HTML attributes.
    
        
        .. code-block:: csharp
    
           public static IDictionary<string, object> AnonymousObjectToHtmlAttributes(object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.AntiForgeryToken()
    
        
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           public IHtmlContent AntiForgeryToken()
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.BeginForm(System.String, System.String, System.Object, Microsoft.AspNet.Mvc.Rendering.FormMethod, System.Object)
    
        
        
        
        :type actionName: System.String
        
        
        :type controllerName: System.String
        
        
        :type routeValues: System.Object
        
        
        :type method: Microsoft.AspNet.Mvc.Rendering.FormMethod
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Mvc.Rendering.MvcForm
    
        
        .. code-block:: csharp
    
           public MvcForm BeginForm(string actionName, string controllerName, object routeValues, FormMethod method, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.BeginRouteForm(System.String, System.Object, Microsoft.AspNet.Mvc.Rendering.FormMethod, System.Object)
    
        
        
        
        :type routeName: System.String
        
        
        :type routeValues: System.Object
        
        
        :type method: Microsoft.AspNet.Mvc.Rendering.FormMethod
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Mvc.Rendering.MvcForm
    
        
        .. code-block:: csharp
    
           public MvcForm BeginRouteForm(string routeName, object routeValues, FormMethod method, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.CheckBox(System.String, System.Nullable<System.Boolean>, System.Object)
    
        
        
        
        :type expression: System.String
        
        
        :type isChecked: System.Nullable{System.Boolean}
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           public IHtmlContent CheckBox(string expression, bool ? isChecked, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.Contextualize(Microsoft.AspNet.Mvc.Rendering.ViewContext)
    
        
        
        
        :type viewContext: Microsoft.AspNet.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
           public virtual void Contextualize(ViewContext viewContext)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.CreateForm()
    
        
    
        Override this method to return an :any:`Microsoft.AspNet.Mvc.Rendering.MvcForm` subclass. That subclass may change 
        :dn:meth:`Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.EndForm` behavior.
    
        
        :rtype: Microsoft.AspNet.Mvc.Rendering.MvcForm
        :return: A new <see cref="T:Microsoft.AspNet.Mvc.Rendering.MvcForm" /> instance.
    
        
        .. code-block:: csharp
    
           protected virtual MvcForm CreateForm()
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.Display(System.String, System.String, System.String, System.Object)
    
        
        
        
        :type expression: System.String
        
        
        :type templateName: System.String
        
        
        :type htmlFieldName: System.String
        
        
        :type additionalViewData: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           public IHtmlContent Display(string expression, string templateName, string htmlFieldName, object additionalViewData)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.DisplayName(System.String)
    
        
        
        
        :type expression: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string DisplayName(string expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.DisplayText(System.String)
    
        
        
        
        :type expression: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string DisplayText(string expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.DropDownList(System.String, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.Rendering.SelectListItem>, System.String, System.Object)
    
        
        
        
        :type expression: System.String
        
        
        :type selectList: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.Rendering.SelectListItem}
        
        
        :type optionLabel: System.String
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           public IHtmlContent DropDownList(string expression, IEnumerable<SelectListItem> selectList, string optionLabel, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.Editor(System.String, System.String, System.String, System.Object)
    
        
        
        
        :type expression: System.String
        
        
        :type templateName: System.String
        
        
        :type htmlFieldName: System.String
        
        
        :type additionalViewData: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           public IHtmlContent Editor(string expression, string templateName, string htmlFieldName, object additionalViewData)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.Encode(System.Object)
    
        
        
        
        :type value: System.Object
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Encode(object value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.Encode(System.String)
    
        
        
        
        :type value: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Encode(string value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.EndForm()
    
        
    
        
        .. code-block:: csharp
    
           public void EndForm()
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.FormatValue(System.Object, System.String)
    
        
        
        
        :type value: System.Object
        
        
        :type format: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string FormatValue(object value, string format)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.GenerateCheckBox(Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer, System.String, System.Nullable<System.Boolean>, System.Object)
    
        
        
        
        :type modelExplorer: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        
        
        :type expression: System.String
        
        
        :type isChecked: System.Nullable{System.Boolean}
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           protected virtual IHtmlContent GenerateCheckBox(ModelExplorer modelExplorer, string expression, bool ? isChecked, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.GenerateDisplay(Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer, System.String, System.String, System.Object)
    
        
        
        
        :type modelExplorer: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        
        
        :type htmlFieldName: System.String
        
        
        :type templateName: System.String
        
        
        :type additionalViewData: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           protected virtual IHtmlContent GenerateDisplay(ModelExplorer modelExplorer, string htmlFieldName, string templateName, object additionalViewData)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.GenerateDisplayName(Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer, System.String)
    
        
        
        
        :type modelExplorer: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        
        
        :type expression: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           protected virtual string GenerateDisplayName(ModelExplorer modelExplorer, string expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.GenerateDisplayText(Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer)
    
        
        
        
        :type modelExplorer: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           protected virtual string GenerateDisplayText(ModelExplorer modelExplorer)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.GenerateDropDown(Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer, System.String, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.Rendering.SelectListItem>, System.String, System.Object)
    
        
        
        
        :type modelExplorer: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        
        
        :type expression: System.String
        
        
        :type selectList: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.Rendering.SelectListItem}
        
        
        :type optionLabel: System.String
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           protected IHtmlContent GenerateDropDown(ModelExplorer modelExplorer, string expression, IEnumerable<SelectListItem> selectList, string optionLabel, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.GenerateEditor(Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer, System.String, System.String, System.Object)
    
        
        
        
        :type modelExplorer: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        
        
        :type htmlFieldName: System.String
        
        
        :type templateName: System.String
        
        
        :type additionalViewData: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           protected virtual IHtmlContent GenerateEditor(ModelExplorer modelExplorer, string htmlFieldName, string templateName, object additionalViewData)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.GenerateForm(System.String, System.String, System.Object, Microsoft.AspNet.Mvc.Rendering.FormMethod, System.Object)
    
        
    
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
    
           protected virtual MvcForm GenerateForm(string actionName, string controllerName, object routeValues, FormMethod method, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.GenerateHidden(Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer, System.String, System.Object, System.Boolean, System.Object)
    
        
        
        
        :type modelExplorer: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        
        
        :type expression: System.String
        
        
        :type value: System.Object
        
        
        :type useViewData: System.Boolean
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           protected virtual IHtmlContent GenerateHidden(ModelExplorer modelExplorer, string expression, object value, bool useViewData, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.GenerateId(System.String)
    
        
        
        
        :type expression: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           protected virtual string GenerateId(string expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.GenerateIdFromName(System.String)
    
        
        
        
        :type fullName: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string GenerateIdFromName(string fullName)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.GenerateLabel(Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer, System.String, System.String, System.Object)
    
        
        
        
        :type modelExplorer: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        
        
        :type expression: System.String
        
        
        :type labelText: System.String
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           protected virtual IHtmlContent GenerateLabel(ModelExplorer modelExplorer, string expression, string labelText, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.GenerateListBox(Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer, System.String, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.Rendering.SelectListItem>, System.Object)
    
        
        
        
        :type modelExplorer: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        
        
        :type expression: System.String
        
        
        :type selectList: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.Rendering.SelectListItem}
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           protected IHtmlContent GenerateListBox(ModelExplorer modelExplorer, string expression, IEnumerable<SelectListItem> selectList, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.GenerateName(System.String)
    
        
        
        
        :type expression: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           protected virtual string GenerateName(string expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.GeneratePassword(Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer, System.String, System.Object, System.Object)
    
        
        
        
        :type modelExplorer: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        
        
        :type expression: System.String
        
        
        :type value: System.Object
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           protected virtual IHtmlContent GeneratePassword(ModelExplorer modelExplorer, string expression, object value, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.GenerateRadioButton(Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer, System.String, System.Object, System.Nullable<System.Boolean>, System.Object)
    
        
        
        
        :type modelExplorer: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        
        
        :type expression: System.String
        
        
        :type value: System.Object
        
        
        :type isChecked: System.Nullable{System.Boolean}
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           protected virtual IHtmlContent GenerateRadioButton(ModelExplorer modelExplorer, string expression, object value, bool ? isChecked, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.GenerateRouteForm(System.String, System.Object, Microsoft.AspNet.Mvc.Rendering.FormMethod, System.Object)
    
        
    
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
    
           protected virtual MvcForm GenerateRouteForm(string routeName, object routeValues, FormMethod method, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.GenerateTextArea(Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer, System.String, System.Int32, System.Int32, System.Object)
    
        
        
        
        :type modelExplorer: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        
        
        :type expression: System.String
        
        
        :type rows: System.Int32
        
        
        :type columns: System.Int32
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           protected virtual IHtmlContent GenerateTextArea(ModelExplorer modelExplorer, string expression, int rows, int columns, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.GenerateTextBox(Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer, System.String, System.Object, System.String, System.Object)
    
        
        
        
        :type modelExplorer: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        
        
        :type expression: System.String
        
        
        :type value: System.Object
        
        
        :type format: System.String
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           protected virtual IHtmlContent GenerateTextBox(ModelExplorer modelExplorer, string expression, object value, string format, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.GenerateValidationMessage(System.String, System.String, System.Object, System.String)
    
        
        
        
        :type expression: System.String
        
        
        :type message: System.String
        
        
        :type htmlAttributes: System.Object
        
        
        :type tag: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           protected virtual IHtmlContent GenerateValidationMessage(string expression, string message, object htmlAttributes, string tag)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.GenerateValidationSummary(System.Boolean, System.String, System.Object, System.String)
    
        
        
        
        :type excludePropertyErrors: System.Boolean
        
        
        :type message: System.String
        
        
        :type htmlAttributes: System.Object
        
        
        :type tag: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           protected virtual IHtmlContent GenerateValidationSummary(bool excludePropertyErrors, string message, object htmlAttributes, string tag)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.GenerateValue(System.String, System.Object, System.String, System.Boolean)
    
        
        
        
        :type expression: System.String
        
        
        :type value: System.Object
        
        
        :type format: System.String
        
        
        :type useViewData: System.Boolean
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           protected virtual string GenerateValue(string expression, object value, string format, bool useViewData)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.GetClientValidationRules(Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer, System.String)
    
        
        
        
        :type modelExplorer: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        
        
        :type expression: System.String
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelClientValidationRule}
    
        
        .. code-block:: csharp
    
           public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelExplorer modelExplorer, string expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.GetEnumSelectList(Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata)
    
        
    
        Returns a select list for the given ``metadata``.
    
        
        
        
        :param metadata: to generate a select list for.
        
        :type metadata: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.Rendering.SelectListItem}
        :return: An <see cref="T:System.Collections.Generic.IEnumerable`1" /> containing the select list for the given
            <paramref name="metadata" />.
    
        
        .. code-block:: csharp
    
           protected virtual IEnumerable<SelectListItem> GetEnumSelectList(ModelMetadata metadata)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.GetEnumSelectList(System.Type)
    
        
        
        
        :type enumType: System.Type
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.Rendering.SelectListItem}
    
        
        .. code-block:: csharp
    
           public IEnumerable<SelectListItem> GetEnumSelectList(Type enumType)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.GetEnumSelectList<TEnum>()
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.Rendering.SelectListItem}
    
        
        .. code-block:: csharp
    
           public IEnumerable<SelectListItem> GetEnumSelectList<TEnum>()where TEnum : struct
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.GetFormMethodString(Microsoft.AspNet.Mvc.Rendering.FormMethod)
    
        
    
        Returns the HTTP method that handles form input (GET or POST) as a string.
    
        
        
        
        :param method: The HTTP method that handles the form.
        
        :type method: Microsoft.AspNet.Mvc.Rendering.FormMethod
        :rtype: System.String
        :return: The form method string, either "get" or "post".
    
        
        .. code-block:: csharp
    
           public static string GetFormMethodString(FormMethod method)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.Hidden(System.String, System.Object, System.Object)
    
        
        
        
        :type expression: System.String
        
        
        :type value: System.Object
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           public IHtmlContent Hidden(string expression, object value, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.Id(System.String)
    
        
        
        
        :type expression: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Id(string expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.Label(System.String, System.String, System.Object)
    
        
        
        
        :type expression: System.String
        
        
        :type labelText: System.String
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           public IHtmlContent Label(string expression, string labelText, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.ListBox(System.String, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.Rendering.SelectListItem>, System.Object)
    
        
        
        
        :type expression: System.String
        
        
        :type selectList: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.Rendering.SelectListItem}
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           public IHtmlContent ListBox(string expression, IEnumerable<SelectListItem> selectList, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.Name(System.String)
    
        
        
        
        :type expression: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Name(string expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.ObjectToDictionary(System.Object)
    
        
    
        Creates a dictionary from an object, by adding each public instance property as a key with its associated
        value to the dictionary. It will expose public properties from derived types as well. This is typically
        used with objects of an anonymous type.
        
        
        If the ``value`` is already an :any:`System.Collections.Generic.IDictionary\`2` instance, then it
        is returned as-is.
        <example><c>new { data_name="value" }</c> will translate to the entry <c>{ "data_name", "value" }</c>
        in the resulting dictionary.
        </example>
    
        
        
        
        :param value: The  to be converted.
        
        :type value: System.Object
        :rtype: System.Collections.Generic.IDictionary{System.String,System.Object}
        :return: The created dictionary of property names and property values.
    
        
        .. code-block:: csharp
    
           public static IDictionary<string, object> ObjectToDictionary(object value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.PartialAsync(System.String, System.Object, Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary)
    
        
        
        
        :type partialViewName: System.String
        
        
        :type model: System.Object
        
        
        :type viewData: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Html.Abstractions.IHtmlContent}
    
        
        .. code-block:: csharp
    
           public Task<IHtmlContent> PartialAsync(string partialViewName, object model, ViewDataDictionary viewData)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.Password(System.String, System.Object, System.Object)
    
        
        
        
        :type expression: System.String
        
        
        :type value: System.Object
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           public IHtmlContent Password(string expression, object value, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.RadioButton(System.String, System.Object, System.Nullable<System.Boolean>, System.Object)
    
        
        
        
        :type expression: System.String
        
        
        :type value: System.Object
        
        
        :type isChecked: System.Nullable{System.Boolean}
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           public IHtmlContent RadioButton(string expression, object value, bool ? isChecked, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.Raw(System.Object)
    
        
        
        
        :type value: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           public IHtmlContent Raw(object value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.Raw(System.String)
    
        
        
        
        :type value: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           public IHtmlContent Raw(string value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.RenderPartialAsync(System.String, System.Object, Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary)
    
        
        
        
        :type partialViewName: System.String
        
        
        :type model: System.Object
        
        
        :type viewData: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task RenderPartialAsync(string partialViewName, object model, ViewDataDictionary viewData)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.RenderPartialCoreAsync(System.String, System.Object, Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary, System.IO.TextWriter)
    
        
        
        
        :type partialViewName: System.String
        
        
        :type model: System.Object
        
        
        :type viewData: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary
        
        
        :type writer: System.IO.TextWriter
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           protected virtual Task RenderPartialCoreAsync(string partialViewName, object model, ViewDataDictionary viewData, TextWriter writer)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.RouteLink(System.String, System.String, System.String, System.String, System.String, System.Object, System.Object)
    
        
        
        
        :type linkText: System.String
        
        
        :type routeName: System.String
        
        
        :type protocol: System.String
        
        
        :type hostName: System.String
        
        
        :type fragment: System.String
        
        
        :type routeValues: System.Object
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           public IHtmlContent RouteLink(string linkText, string routeName, string protocol, string hostName, string fragment, object routeValues, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.TextArea(System.String, System.String, System.Int32, System.Int32, System.Object)
    
        
        
        
        :type expression: System.String
        
        
        :type value: System.String
        
        
        :type rows: System.Int32
        
        
        :type columns: System.Int32
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           public IHtmlContent TextArea(string expression, string value, int rows, int columns, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.TextBox(System.String, System.Object, System.String, System.Object)
    
        
        
        
        :type expression: System.String
        
        
        :type value: System.Object
        
        
        :type format: System.String
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           public IHtmlContent TextBox(string expression, object value, string format, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.ValidationMessage(System.String, System.String, System.Object, System.String)
    
        
        
        
        :type expression: System.String
        
        
        :type message: System.String
        
        
        :type htmlAttributes: System.Object
        
        
        :type tag: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           public IHtmlContent ValidationMessage(string expression, string message, object htmlAttributes, string tag)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.ValidationSummary(System.Boolean, System.String, System.Object, System.String)
    
        
        
        
        :type excludePropertyErrors: System.Boolean
        
        
        :type message: System.String
        
        
        :type htmlAttributes: System.Object
        
        
        :type tag: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           public IHtmlContent ValidationSummary(bool excludePropertyErrors, string message, object htmlAttributes, string tag)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.Value(System.String, System.String)
    
        
        
        
        :type expression: System.String
        
        
        :type format: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Value(string expression, string format)
    

Fields
------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.ValidationInputCssClassName
    
        
    
        
        .. code-block:: csharp
    
           public static readonly string ValidationInputCssClassName
    
    .. dn:field:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.ValidationInputValidCssClassName
    
        
    
        
        .. code-block:: csharp
    
           public static readonly string ValidationInputValidCssClassName
    
    .. dn:field:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.ValidationMessageCssClassName
    
        
    
        
        .. code-block:: csharp
    
           public static readonly string ValidationMessageCssClassName
    
    .. dn:field:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.ValidationMessageValidCssClassName
    
        
    
        
        .. code-block:: csharp
    
           public static readonly string ValidationMessageValidCssClassName
    
    .. dn:field:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.ValidationSummaryCssClassName
    
        
    
        
        .. code-block:: csharp
    
           public static readonly string ValidationSummaryCssClassName
    
    .. dn:field:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.ValidationSummaryValidCssClassName
    
        
    
        
        .. code-block:: csharp
    
           public static readonly string ValidationSummaryValidCssClassName
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.Html5DateRenderingMode
    
        
        :rtype: Microsoft.AspNet.Mvc.Rendering.Html5DateRenderingMode
    
        
        .. code-block:: csharp
    
           public Html5DateRenderingMode Html5DateRenderingMode { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.IdAttributeDotReplacement
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string IdAttributeDotReplacement { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.JavaScriptStringEncoder
    
        
        :rtype: Microsoft.Extensions.WebEncoders.IJavaScriptStringEncoder
    
        
        .. code-block:: csharp
    
           public IJavaScriptStringEncoder JavaScriptStringEncoder { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.MetadataProvider
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider
    
        
        .. code-block:: csharp
    
           public IModelMetadataProvider MetadataProvider { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.TempData
    
        
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.ITempDataDictionary
    
        
        .. code-block:: csharp
    
           public ITempDataDictionary TempData { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.UrlEncoder
    
        
        :rtype: Microsoft.Extensions.WebEncoders.IUrlEncoder
    
        
        .. code-block:: csharp
    
           public IUrlEncoder UrlEncoder { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.ViewBag
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public dynamic ViewBag { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.ViewContext
    
        
        :rtype: Microsoft.AspNet.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
           public ViewContext ViewContext { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper.ViewData
    
        
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary
    
        
        .. code-block:: csharp
    
           public ViewDataDictionary ViewData { get; }
    

