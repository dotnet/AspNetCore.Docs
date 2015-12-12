

HtmlHelper<TModel> Class
========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper\<TModel>`








Syntax
------

.. code-block:: csharp

   public class HtmlHelper<TModel> : HtmlHelper, ICanHasViewContext, IHtmlHelper<TModel>, IHtmlHelper





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewFeatures/HtmlHelperOfT.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper<TModel>

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper<TModel>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper<TModel>.HtmlHelper(Microsoft.AspNet.Mvc.ViewFeatures.IHtmlGenerator, Microsoft.AspNet.Mvc.ViewEngines.ICompositeViewEngine, Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider, Microsoft.Extensions.WebEncoders.IHtmlEncoder, Microsoft.Extensions.WebEncoders.IUrlEncoder, Microsoft.Extensions.WebEncoders.IJavaScriptStringEncoder)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper\`1` class.
    
        
        
        
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

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper<TModel>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper<TModel>.CheckBoxFor(System.Linq.Expressions.Expression<System.Func<TModel, System.Boolean>>, System.Object)
    
        
        
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},System.Boolean}}
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           public IHtmlContent CheckBoxFor(Expression<Func<TModel, bool>> expression, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper<TModel>.Contextualize(Microsoft.AspNet.Mvc.Rendering.ViewContext)
    
        
        
        
        :type viewContext: Microsoft.AspNet.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
           public override void Contextualize(ViewContext viewContext)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper<TModel>.DisplayFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.String, System.String, System.Object)
    
        
        
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        
        
        :type templateName: System.String
        
        
        :type htmlFieldName: System.String
        
        
        :type additionalViewData: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           public IHtmlContent DisplayFor<TResult>(Expression<Func<TModel, TResult>> expression, string templateName, string htmlFieldName, object additionalViewData)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper<TModel>.DisplayNameForInnerType<TModelItem, TResult>(System.Linq.Expressions.Expression<System.Func<TModelItem, TResult>>)
    
        
        
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModelItem},{TResult}}}
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string DisplayNameForInnerType<TModelItem, TResult>(Expression<Func<TModelItem, TResult>> expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper<TModel>.DisplayNameFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>)
    
        
        
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string DisplayNameFor<TResult>(Expression<Func<TModel, TResult>> expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper<TModel>.DisplayTextFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>)
    
        
        
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string DisplayTextFor<TResult>(Expression<Func<TModel, TResult>> expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper<TModel>.DropDownListFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.Rendering.SelectListItem>, System.String, System.Object)
    
        
        
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        
        
        :type selectList: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.Rendering.SelectListItem}
        
        
        :type optionLabel: System.String
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           public IHtmlContent DropDownListFor<TResult>(Expression<Func<TModel, TResult>> expression, IEnumerable<SelectListItem> selectList, string optionLabel, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper<TModel>.EditorFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.String, System.String, System.Object)
    
        
        
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        
        
        :type templateName: System.String
        
        
        :type htmlFieldName: System.String
        
        
        :type additionalViewData: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           public IHtmlContent EditorFor<TResult>(Expression<Func<TModel, TResult>> expression, string templateName, string htmlFieldName, object additionalViewData)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper<TModel>.GetExpressionName<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>)
    
        
        
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           protected string GetExpressionName<TResult>(Expression<Func<TModel, TResult>> expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper<TModel>.GetModelExplorer<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>)
    
        
        
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
    
        
        .. code-block:: csharp
    
           protected ModelExplorer GetModelExplorer<TResult>(Expression<Func<TModel, TResult>> expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper<TModel>.HiddenFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.Object)
    
        
        
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           public IHtmlContent HiddenFor<TResult>(Expression<Func<TModel, TResult>> expression, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper<TModel>.IdFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>)
    
        
        
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string IdFor<TResult>(Expression<Func<TModel, TResult>> expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper<TModel>.LabelFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.String, System.Object)
    
        
        
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        
        
        :type labelText: System.String
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           public IHtmlContent LabelFor<TResult>(Expression<Func<TModel, TResult>> expression, string labelText, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper<TModel>.ListBoxFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.Rendering.SelectListItem>, System.Object)
    
        
        
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        
        
        :type selectList: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.Rendering.SelectListItem}
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           public IHtmlContent ListBoxFor<TResult>(Expression<Func<TModel, TResult>> expression, IEnumerable<SelectListItem> selectList, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper<TModel>.NameFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>)
    
        
        
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string NameFor<TResult>(Expression<Func<TModel, TResult>> expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper<TModel>.PasswordFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.Object)
    
        
        
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           public IHtmlContent PasswordFor<TResult>(Expression<Func<TModel, TResult>> expression, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper<TModel>.RadioButtonFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.Object, System.Object)
    
        
        
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        
        
        :type value: System.Object
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           public IHtmlContent RadioButtonFor<TResult>(Expression<Func<TModel, TResult>> expression, object value, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper<TModel>.TextAreaFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.Int32, System.Int32, System.Object)
    
        
        
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        
        
        :type rows: System.Int32
        
        
        :type columns: System.Int32
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           public IHtmlContent TextAreaFor<TResult>(Expression<Func<TModel, TResult>> expression, int rows, int columns, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper<TModel>.TextBoxFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.String, System.Object)
    
        
        
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        
        
        :type format: System.String
        
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           public IHtmlContent TextBoxFor<TResult>(Expression<Func<TModel, TResult>> expression, string format, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper<TModel>.ValidationMessageFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.String, System.Object, System.String)
    
        
        
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        
        
        :type message: System.String
        
        
        :type htmlAttributes: System.Object
        
        
        :type tag: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           public IHtmlContent ValidationMessageFor<TResult>(Expression<Func<TModel, TResult>> expression, string message, object htmlAttributes, string tag)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper<TModel>.ValueFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.String)
    
        
        
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        
        
        :type format: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ValueFor<TResult>(Expression<Func<TModel, TResult>> expression, string format)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper<TModel>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelper<TModel>.ViewData
    
        
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary{{TModel}}
    
        
        .. code-block:: csharp
    
           public ViewDataDictionary<TModel> ViewData { get; }
    

