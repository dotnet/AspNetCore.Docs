

CachedExpressionCompiler Class
==============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewFeatures.CachedExpressionCompiler`








Syntax
------

.. code-block:: csharp

   public class CachedExpressionCompiler





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewFeatures/CachedExpressionCompiler.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.CachedExpressionCompiler

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.CachedExpressionCompiler
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.CachedExpressionCompiler.Process<TModel, TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>)
    
        
        
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        :rtype: System.Func{{TModel},{TResult}}
    
        
        .. code-block:: csharp
    
           public static Func<TModel, TResult> Process<TModel, TResult>(Expression<Func<TModel, TResult>> expression)
    

