

CachedExpressionCompiler Class
==============================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.CachedExpressionCompiler`








Syntax
------

.. code-block:: csharp

    public class CachedExpressionCompiler








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.CachedExpressionCompiler
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.CachedExpressionCompiler

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.CachedExpressionCompiler
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.CachedExpressionCompiler.Process<TModel, TResult>(System.Linq.Expressions.Expression<System.Func<TModel, TResult>>)
    
        
    
        
        :type expression: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TResult}}
        :rtype: System.Func<System.Func`2>{TModel, TResult}
    
        
        .. code-block:: csharp
    
            public static Func<TModel, TResult> Process<TModel, TResult>(Expression<Func<TModel, TResult>> expression)
    

