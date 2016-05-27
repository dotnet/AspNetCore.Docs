

HtmlHelperDisplayNameExtensions Class
=====================================






DisplayName-related extensions for :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` and :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper\`1`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperDisplayNameExtensions`








Syntax
------

.. code-block:: csharp

    public class HtmlHelperDisplayNameExtensions








.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperDisplayNameExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperDisplayNameExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperDisplayNameExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperDisplayNameExtensions.DisplayNameForModel(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper)
    
        
    
        
        Returns the display name for the current model.
    
        
    
        
        :param htmlHelper: The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper
        :rtype: System.String
        :return: A :any:`System.String` containing the display name.
    
        
        .. code-block:: csharp
    
            public static string DisplayNameForModel(IHtmlHelper htmlHelper)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperDisplayNameExtensions.DisplayNameFor<TModelItem, TResult>(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<System.Collections.Generic.IEnumerable<TModelItem>>, System.Linq.Expressions.Expression<System.Func<TModelItem, TResult>>)
    
        
    
        
        Returns the display name for the specified <em>expression</em>
        if the current model represents a collection.
    
        
    
        
        :param htmlHelper: 
            The :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper\`1` of :any:`System.Collections.Generic.IEnumerable\`1` instance this method extends.
        
        :type htmlHelper: Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper`1>{System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{TModelItem}}
    
        
        :param expression: An expression to be evaluated against an item in the current model.
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModelItem, TResult}}
        :rtype: System.String
        :return: A :any:`System.String` containing the display name.
    
        
        .. code-block:: csharp
    
            public static string DisplayNameFor<TModelItem, TResult>(IHtmlHelper<IEnumerable<TModelItem>> htmlHelper, Expression<Func<TModelItem, TResult>> expression)
    

