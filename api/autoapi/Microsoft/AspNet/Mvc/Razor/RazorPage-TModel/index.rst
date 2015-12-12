

RazorPage<TModel> Class
=======================



.. contents:: 
   :local:



Summary
-------

Represents the properties and methods that are needed in order to render a view that uses Razor syntax.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.RazorPage`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.RazorPage\<TModel>`








Syntax
------

.. code-block:: csharp

   public abstract class RazorPage<TModel> : RazorPage, IRazorPage





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Razor/RazorPageOfT.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.RazorPage<TModel>

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.RazorPage<TModel>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorPage<TModel>.CreateModelExpression<TValue>(System.Linq.Expressions.Expression<System.Func<TModel, TValue>>)
    
        
    
        Returns a :any:`Microsoft.AspNet.Mvc.Rendering.ModelExpression` instance describing the given ``expression``.
    
        
        
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TValue}}}
        :rtype: Microsoft.AspNet.Mvc.Rendering.ModelExpression
        :return: A new <see cref="T:Microsoft.AspNet.Mvc.Rendering.ModelExpression" /> instance describing the given <paramref name="expression" />.
    
        
        .. code-block:: csharp
    
           public ModelExpression CreateModelExpression<TValue>(Expression<Func<TModel, TValue>> expression)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.RazorPage<TModel>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.RazorPage<TModel>.Model
    
        
    
        Gets the Model property of the :dn:prop:`Microsoft.AspNet.Mvc.Razor.RazorPage\`1.ViewData` property.
    
        
        :rtype: {TModel}
    
        
        .. code-block:: csharp
    
           public TModel Model { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.RazorPage<TModel>.ViewData
    
        
    
        Gets or sets the dictionary for view data.
    
        
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary{{TModel}}
    
        
        .. code-block:: csharp
    
           public ViewDataDictionary<TModel> ViewData { get; set; }
    

