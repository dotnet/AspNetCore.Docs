

HtmlHelper<TModel> Class
========================





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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper\<TModel>`








Syntax
------

.. code-block:: csharp

    public class HtmlHelper<TModel> : HtmlHelper, IViewContextAware, IHtmlHelper<TModel>, IHtmlHelper








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper`1
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper<TModel>

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper<TModel>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper<TModel>.HtmlHelper(Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator, Microsoft.AspNetCore.Mvc.ViewEngines.ICompositeViewEngine, Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider, Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.IViewBufferScope, System.Text.Encodings.Web.HtmlEncoder, System.Text.Encodings.Web.UrlEncoder, Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ExpressionTextCache)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper\`1` class.
    
        
    
        
        :type htmlGenerator: Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator
    
        
        :type viewEngine: Microsoft.AspNetCore.Mvc.ViewEngines.ICompositeViewEngine
    
        
        :type metadataProvider: Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider
    
        
        :type bufferScope: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.IViewBufferScope
    
        
        :type htmlEncoder: System.Text.Encodings.Web.HtmlEncoder
    
        
        :type urlEncoder: System.Text.Encodings.Web.UrlEncoder
    
        
        :type expressionTextCache: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ExpressionTextCache
    
        
        .. code-block:: csharp
    
            public HtmlHelper(IHtmlGenerator htmlGenerator, ICompositeViewEngine viewEngine, IModelMetadataProvider metadataProvider, IViewBufferScope bufferScope, HtmlEncoder htmlEncoder, UrlEncoder urlEncoder, ExpressionTextCache expressionTextCache)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper<TModel>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper<TModel>.CheckBoxFor(System.Linq.Expressions.Expression<System.Func<TModel, System.Boolean>>, System.Object)
    
        
    
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, System.Boolean<System.Boolean>}}
    
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
    
        
        .. code-block:: csharp
    
            public IHtmlContent CheckBoxFor(Expression<Func<TModel, bool>> expression, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper<TModel>.Contextualize(Microsoft.AspNetCore.Mvc.Rendering.ViewContext)
    
        
    
        
        :type viewContext: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
            public override void Contextualize(ViewContext viewContext)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper<TModel>.DisplayFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.String, System.String, System.Object)
    
        
    
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
    
        
        :type templateName: System.String
    
        
        :type htmlFieldName: System.String
    
        
        :type additionalViewData: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
    
        
        .. code-block:: csharp
    
            public IHtmlContent DisplayFor<TResult>(Expression<Func<TModel, TResult>> expression, string templateName, string htmlFieldName, object additionalViewData)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper<TModel>.DisplayNameForInnerType<TModelItem, TResult>(System.Linq.Expressions.Expression<System.Func<TModelItem, TResult>>)
    
        
    
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModelItem, TResult}}
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string DisplayNameForInnerType<TModelItem, TResult>(Expression<Func<TModelItem, TResult>> expression)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper<TModel>.DisplayNameFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>)
    
        
    
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string DisplayNameFor<TResult>(Expression<Func<TModel, TResult>> expression)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper<TModel>.DisplayTextFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>)
    
        
    
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string DisplayTextFor<TResult>(Expression<Func<TModel, TResult>> expression)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper<TModel>.DropDownListFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>, System.String, System.Object)
    
        
    
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
    
        
        :type selectList: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.Rendering.SelectListItem<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>}
    
        
        :type optionLabel: System.String
    
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
    
        
        .. code-block:: csharp
    
            public IHtmlContent DropDownListFor<TResult>(Expression<Func<TModel, TResult>> expression, IEnumerable<SelectListItem> selectList, string optionLabel, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper<TModel>.EditorFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.String, System.String, System.Object)
    
        
    
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
    
        
        :type templateName: System.String
    
        
        :type htmlFieldName: System.String
    
        
        :type additionalViewData: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
    
        
        .. code-block:: csharp
    
            public IHtmlContent EditorFor<TResult>(Expression<Func<TModel, TResult>> expression, string templateName, string htmlFieldName, object additionalViewData)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper<TModel>.GetExpressionName<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>)
    
        
    
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            protected string GetExpressionName<TResult>(Expression<Func<TModel, TResult>> expression)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper<TModel>.GetModelExplorer<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>)
    
        
    
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
    
        
        .. code-block:: csharp
    
            protected ModelExplorer GetModelExplorer<TResult>(Expression<Func<TModel, TResult>> expression)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper<TModel>.HiddenFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.Object)
    
        
    
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
    
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
    
        
        .. code-block:: csharp
    
            public IHtmlContent HiddenFor<TResult>(Expression<Func<TModel, TResult>> expression, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper<TModel>.IdFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>)
    
        
    
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string IdFor<TResult>(Expression<Func<TModel, TResult>> expression)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper<TModel>.LabelFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.String, System.Object)
    
        
    
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
    
        
        :type labelText: System.String
    
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
    
        
        .. code-block:: csharp
    
            public IHtmlContent LabelFor<TResult>(Expression<Func<TModel, TResult>> expression, string labelText, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper<TModel>.ListBoxFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>, System.Object)
    
        
    
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
    
        
        :type selectList: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.Rendering.SelectListItem<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>}
    
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
    
        
        .. code-block:: csharp
    
            public IHtmlContent ListBoxFor<TResult>(Expression<Func<TModel, TResult>> expression, IEnumerable<SelectListItem> selectList, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper<TModel>.NameFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>)
    
        
    
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string NameFor<TResult>(Expression<Func<TModel, TResult>> expression)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper<TModel>.PasswordFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.Object)
    
        
    
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
    
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
    
        
        .. code-block:: csharp
    
            public IHtmlContent PasswordFor<TResult>(Expression<Func<TModel, TResult>> expression, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper<TModel>.RadioButtonFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.Object, System.Object)
    
        
    
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
    
        
        :type value: System.Object
    
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
    
        
        .. code-block:: csharp
    
            public IHtmlContent RadioButtonFor<TResult>(Expression<Func<TModel, TResult>> expression, object value, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper<TModel>.TextAreaFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.Int32, System.Int32, System.Object)
    
        
    
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
    
        
        :type rows: System.Int32
    
        
        :type columns: System.Int32
    
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
    
        
        .. code-block:: csharp
    
            public IHtmlContent TextAreaFor<TResult>(Expression<Func<TModel, TResult>> expression, int rows, int columns, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper<TModel>.TextBoxFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.String, System.Object)
    
        
    
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
    
        
        :type format: System.String
    
        
        :type htmlAttributes: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
    
        
        .. code-block:: csharp
    
            public IHtmlContent TextBoxFor<TResult>(Expression<Func<TModel, TResult>> expression, string format, object htmlAttributes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper<TModel>.ValidationMessageFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.String, System.Object, System.String)
    
        
    
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
    
        
        :type message: System.String
    
        
        :type htmlAttributes: System.Object
    
        
        :type tag: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
    
        
        .. code-block:: csharp
    
            public IHtmlContent ValidationMessageFor<TResult>(Expression<Func<TModel, TResult>> expression, string message, object htmlAttributes, string tag)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper<TModel>.ValueFor<TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.String)
    
        
    
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
    
        
        :type format: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ValueFor<TResult>(Expression<Func<TModel, TResult>> expression, string format)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper<TModel>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper<TModel>.ViewData
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary`1>{TModel}
    
        
        .. code-block:: csharp
    
            public ViewDataDictionary<TModel> ViewData { get; }
    

