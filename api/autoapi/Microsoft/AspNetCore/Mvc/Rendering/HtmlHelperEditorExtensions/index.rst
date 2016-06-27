

HtmlHelperEditorExtensions Class
================================






Editor-related extensions for :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` and :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper\`1`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperEditorExtensions`








Syntax
------

.. code-block:: csharp

    public class HtmlHelperEditorExtensions








.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperEditorExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperEditorExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperEditorExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperEditorExtensions.Editor(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String)
    
        
    
        
        Returns HTML markup for the <em>expression</em>, using an editor template. The template is found
        using the <em>expression</em>'s :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`\.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param expression: 
            Expression name, relative to the current model. May identify a single property or an 
            :any:`System.Object` that contains the properties to edit.
        
        :type expression: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <input> element(s).
    
        
        .. code-block:: csharp
    
            public static IHtmlContent Editor(this IHtmlHelper htmlHelper, string expression)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperEditorExtensions.Editor(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.Object)
    
        
    
        
        Returns HTML markup for the <em>expression</em>, using an editor template and specified
        additional view data. The template is found using the <em>expression</em>'s 
        :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`\.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param expression: 
            Expression name, relative to the current model. May identify a single property or an 
            :any:`System.Object` that contains the properties to edit.
        
        :type expression: System.String
    
        
        :param additionalViewData: 
            An anonymous :any:`System.Object` or :any:`System.Collections.Generic.IDictionary\`2`
            that can contain additional view data that will be merged into the 
            :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary\`1` instance created for the template.
        
        :type additionalViewData: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <input> element(s).
    
        
        .. code-block:: csharp
    
            public static IHtmlContent Editor(this IHtmlHelper htmlHelper, string expression, object additionalViewData)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperEditorExtensions.Editor(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.String)
    
        
    
        
        Returns HTML markup for the <em>expression</em>, using an editor template. The template is found
        using the <em>templateName</em> or the <em>expression</em>'s 
        :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`\.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param expression: 
            Expression name, relative to the current model. May identify a single property or an 
            :any:`System.Object` that contains the properties to edit.
        
        :type expression: System.String
    
        
        :param templateName: The name of the template used to create the HTML markup.
        
        :type templateName: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <input> element(s).
    
        
        .. code-block:: csharp
    
            public static IHtmlContent Editor(this IHtmlHelper htmlHelper, string expression, string templateName)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperEditorExtensions.Editor(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.String, System.Object)
    
        
    
        
        Returns HTML markup for the <em>expression</em>, using an editor template and specified
        additional view data. The template is found using the <em>templateName</em> or the
        <em>expression</em>'s :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`\.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param expression: 
            Expression name, relative to the current model. May identify a single property or an 
            :any:`System.Object` that contains the properties to edit.
        
        :type expression: System.String
    
        
        :param templateName: The name of the template used to create the HTML markup.
        
        :type templateName: System.String
    
        
        :param additionalViewData: 
            An anonymous :any:`System.Object` or :any:`System.Collections.Generic.IDictionary\`2`
            that can contain additional view data that will be merged into the 
            :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary\`1` instance created for the template.
        
        :type additionalViewData: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <input> element(s).
    
        
        .. code-block:: csharp
    
            public static IHtmlContent Editor(this IHtmlHelper htmlHelper, string expression, string templateName, object additionalViewData)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperEditorExtensions.Editor(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.String, System.String)
    
        
    
        
        Returns HTML markup for the <em>expression</em>, using an editor template and specified HTML
        field name. The template is found using the <em>templateName</em> or the
        <em>expression</em>'s :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`\.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
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
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <input> element(s).
    
        
        .. code-block:: csharp
    
            public static IHtmlContent Editor(this IHtmlHelper htmlHelper, string expression, string templateName, string htmlFieldName)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperEditorExtensions.EditorForModel(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper)
    
        
    
        
        Returns HTML markup for the current model, using an editor template. The template is found using the
        model's :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`\.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <input> element(s).
    
        
        .. code-block:: csharp
    
            public static IHtmlContent EditorForModel(this IHtmlHelper htmlHelper)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperEditorExtensions.EditorForModel(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.Object)
    
        
    
        
        Returns HTML markup for the current model, using an editor template and specified additional view data. The
        template is found using the model's :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`\.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param additionalViewData: 
            An anonymous :any:`System.Object` or :any:`System.Collections.Generic.IDictionary\`2`
            that can contain additional view data that will be merged into the 
            :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary\`1` instance created for the template.
        
        :type additionalViewData: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <input> element(s).
    
        
        .. code-block:: csharp
    
            public static IHtmlContent EditorForModel(this IHtmlHelper htmlHelper, object additionalViewData)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperEditorExtensions.EditorForModel(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String)
    
        
    
        
        Returns HTML markup for the current model, using an editor template. The template is found using the
        <em>templateName</em> or the model's :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`\.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param templateName: The name of the template used to create the HTML markup.
        
        :type templateName: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <input> element(s).
    
        
        .. code-block:: csharp
    
            public static IHtmlContent EditorForModel(this IHtmlHelper htmlHelper, string templateName)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperEditorExtensions.EditorForModel(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.Object)
    
        
    
        
        Returns HTML markup for the current model, using an editor template and specified additional view data. The
        template is found using the <em>templateName</em> or the model's 
        :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`\.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param templateName: The name of the template used to create the HTML markup.
        
        :type templateName: System.String
    
        
        :param additionalViewData: 
            An anonymous :any:`System.Object` or :any:`System.Collections.Generic.IDictionary\`2`
            that can contain additional view data that will be merged into the 
            :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary\`1` instance created for the template.
        
        :type additionalViewData: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <input> element(s).
    
        
        .. code-block:: csharp
    
            public static IHtmlContent EditorForModel(this IHtmlHelper htmlHelper, string templateName, object additionalViewData)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperEditorExtensions.EditorForModel(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.String)
    
        
    
        
        Returns HTML markup for the current model, using an editor template and specified HTML field name. The
        template is found using the <em>templateName</em> or the model's 
        :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`\.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param templateName: The name of the template used to create the HTML markup.
        
        :type templateName: System.String
    
        
        :param htmlFieldName: 
            A :any:`System.String` used to disambiguate the names of HTML elements that are created for
            properties that have the same name.
        
        :type htmlFieldName: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <input> element(s).
    
        
        .. code-block:: csharp
    
            public static IHtmlContent EditorForModel(this IHtmlHelper htmlHelper, string templateName, string htmlFieldName)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperEditorExtensions.EditorForModel(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper, System.String, System.String, System.Object)
    
        
    
        
        Returns HTML markup for the current model, using an editor template, specified HTML field name, and
        additional view data. The template is found using the <em>templateName</em> or the model's 
        :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`\.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
    
        
        :param templateName: The name of the template used to create the HTML markup.
        
        :type templateName: System.String
    
        
        :param htmlFieldName: 
            A :any:`System.String` used to disambiguate the names of HTML elements that are created for
            properties that have the same name.
        
        :type htmlFieldName: System.String
    
        
        :param additionalViewData: 
            An anonymous :any:`System.Object` or :any:`System.Collections.Generic.IDictionary\`2`
            that can contain additional view data that will be merged into the 
            :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary\`1` instance created for the template.
        
        :type additionalViewData: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <input> element(s).
    
        
        .. code-block:: csharp
    
            public static IHtmlContent EditorForModel(this IHtmlHelper htmlHelper, string templateName, string htmlFieldName, object additionalViewData)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperEditorExtensions.EditorFor<TModel, TResult>(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, TResult>>)
    
        
    
        
        Returns HTML markup for the <em>expression</em>, using an editor template. The template is found
        using the <em>expression</em>'s :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`\.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper\`1` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper`1>{TModel}
    
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <input> element(s).
    
        
        .. code-block:: csharp
    
            public static IHtmlContent EditorFor<TModel, TResult>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperEditorExtensions.EditorFor<TModel, TResult>(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.Object)
    
        
    
        
        Returns HTML markup for the <em>expression</em>, using an editor template and specified
        additional view data. The template is found using the <em>expression</em>'s 
        :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`\.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper\`1` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper`1>{TModel}
    
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
    
        
        :param additionalViewData: 
            An anonymous :any:`System.Object` or :any:`System.Collections.Generic.IDictionary\`2`
            that can contain additional view data that will be merged into the 
            :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary\`1` instance created for the template.
        
        :type additionalViewData: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <input> element(s).
    
        
        .. code-block:: csharp
    
            public static IHtmlContent EditorFor<TModel, TResult>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression, object additionalViewData)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperEditorExtensions.EditorFor<TModel, TResult>(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.String)
    
        
    
        
        Returns HTML markup for the <em>expression</em>, using an editor template. The template is found
        using the <em>templateName</em> or the <em>expression</em>'s 
        :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`\.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper\`1` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper`1>{TModel}
    
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
    
        
        :param templateName: The name of the template that is used to create the HTML markup.
        
        :type templateName: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <input> element(s).
    
        
        .. code-block:: csharp
    
            public static IHtmlContent EditorFor<TModel, TResult>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression, string templateName)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperEditorExtensions.EditorFor<TModel, TResult>(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.String, System.Object)
    
        
    
        
        Returns HTML markup for the <em>expression</em>, using an editor template and specified
        additional view data. The template is found using the <em>templateName</em> or the
        <em>expression</em>'s :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`\.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper\`1` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper`1>{TModel}
    
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
    
        
        :param templateName: The name of the template that is used to create the HTML markup.
        
        :type templateName: System.String
    
        
        :param additionalViewData: 
            An anonymous :any:`System.Object` or :any:`System.Collections.Generic.IDictionary\`2`
            that can contain additional view data that will be merged into the 
            :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary\`1` instance created for the template.
        
        :type additionalViewData: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <input> element(s).
    
        
        .. code-block:: csharp
    
            public static IHtmlContent EditorFor<TModel, TResult>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression, string templateName, object additionalViewData)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperEditorExtensions.EditorFor<TModel, TResult>(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.String, System.String)
    
        
    
        
        Returns HTML markup for the <em>expression</em>, using an editor template and specified HTML
        field name. The template is found using the <em>templateName</em> or the
        <em>expression</em>'s :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`\.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper\`1` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper`1>{TModel}
    
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
    
        
        :param templateName: The name of the template that is used to create the HTML markup.
        
        :type templateName: System.String
    
        
        :param htmlFieldName: 
            A :any:`System.String` used to disambiguate the names of HTML elements that are created for properties
            that have the same name.
        
        :type htmlFieldName: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the <input> element(s).
    
        
        .. code-block:: csharp
    
            public static IHtmlContent EditorFor<TModel, TResult>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression, string templateName, string htmlFieldName)
    

