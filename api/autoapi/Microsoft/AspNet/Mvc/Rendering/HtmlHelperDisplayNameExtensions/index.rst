

HtmlHelperDisplayNameExtensions Class
=====================================



.. contents:: 
   :local:



Summary
-------

DisplayName-related extensions for :any:`Microsoft.AspNet.Mvc.Rendering.IHtmlHelper` and :any:`Microsoft.AspNet.Mvc.Rendering.IHtmlHelper\`1`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Rendering.HtmlHelperDisplayNameExtensions`








Syntax
------

.. code-block:: csharp

   public class HtmlHelperDisplayNameExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ViewFeatures/Rendering/HtmlHelperDisplayNameExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperDisplayNameExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperDisplayNameExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperDisplayNameExtensions.DisplayNameForModel(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper)
    
        
    
        Returns the display name for the current model.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        :rtype: System.String
        :return: A <see cref="T:System.String" /> containing the display name.
    
        
        .. code-block:: csharp
    
           public static string DisplayNameForModel(IHtmlHelper htmlHelper)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperDisplayNameExtensions.DisplayNameFor<TModelItem, TResult>(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<System.Collections.Generic.IEnumerable<TModelItem>>, System.Linq.Expressions.Expression<System.Func<TModelItem, TResult>>)
    
        
    
        Returns the display name for the specified ``expression``
        if the current model represents a collection.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper{System.Collections.Generic.IEnumerable{{TModelItem}}}
        
        
        :param expression: An expression to be evaluated against an item in the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModelItem},{TResult}}}
        :rtype: System.String
        :return: A <see cref="T:System.String" /> containing the display name.
    
        
        .. code-block:: csharp
    
           public static string DisplayNameFor<TModelItem, TResult>(IHtmlHelper<IEnumerable<TModelItem>> htmlHelper, Expression<Func<TModelItem, TResult>> expression)
    

