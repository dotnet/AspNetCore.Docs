

HtmlHelperValueExtensions Class
===============================



.. contents:: 
   :local:



Summary
-------

Value-related extensions for :any:`Microsoft.AspNet.Mvc.Rendering.IHtmlHelper` and :any:`Microsoft.AspNet.Mvc.Rendering.IHtmlHelper\`1`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Rendering.HtmlHelperValueExtensions`








Syntax
------

.. code-block:: csharp

   public class HtmlHelperValueExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/Rendering/HtmlHelperValueExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperValueExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperValueExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperValueExtensions.Value(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String)
    
        
    
        Returns the formatted value for the specified ``expression``.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        :rtype: System.String
        :return: A <see cref="T:System.String" /> containing the formatted value.
    
        
        .. code-block:: csharp
    
           public static string Value(IHtmlHelper htmlHelper, string expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperValueExtensions.ValueForModel(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper)
    
        
    
        Returns the formatted value for the current model.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        :rtype: System.String
        :return: A <see cref="T:System.String" /> containing the formatted value.
    
        
        .. code-block:: csharp
    
           public static string ValueForModel(IHtmlHelper htmlHelper)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperValueExtensions.ValueForModel(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String)
    
        
    
        Returns the formatted value for the current model.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param format: The composite format  (see http://msdn.microsoft.com/en-us/library/txafckwd.aspx).
        
        :type format: System.String
        :rtype: System.String
        :return: A <see cref="T:System.String" /> containing the formatted value.
    
        
        .. code-block:: csharp
    
           public static string ValueForModel(IHtmlHelper htmlHelper, string format)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperValueExtensions.ValueFor<TModel, TResult>(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, TResult>>)
    
        
    
        Returns the formatted value for the specified ``expression``.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper{{TModel}}
        
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        :rtype: System.String
        :return: A <see cref="T:System.String" /> containing the formatted value.
    
        
        .. code-block:: csharp
    
           public static string ValueFor<TModel, TResult>(IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression)
    

